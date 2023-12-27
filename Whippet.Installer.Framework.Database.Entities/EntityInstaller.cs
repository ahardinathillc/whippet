using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.ServiceManagers;

namespace Athi.Whippet.Installer.Framework.Database.Entities
{
    /// <summary>
    /// Installs the Whippet database. This class cannot be inherited.
    /// </summary>
    public sealed class EntityInstaller : InstallerBase, IInstaller
    {
        /// <summary>
        /// Indicates whether the installer supports asynchronous execution. This property is read-only.
        /// </summary>
        public override bool SupportsAsync
        {
            get
            {
                return false;
            }
        }
        
        /// <summary>
        /// Gets or sets the <see cref="NHibernateConfigurationOptions"/> to supply to the installer actions.
        /// </summary>
        private NHibernateConfigurationOptions NHibernateOptions
        { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="SortedList{TKey,TValue}"/> of <see cref="ISeedServiceManager"/> objects indexed by their execution order.
        /// </summary>
        private SortedList<int, ISeedServiceManager> Seeds
        { get; set; }
       
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityInstaller"/> class with the specified parameters.
        /// </summary>
        /// <param name="actions">Collection of <see cref="IInstallerAction"/> actions to perform sorted by their execution order.</param>
        /// <param name="updateProgressPercentage"><see cref="Action{T}"/> that updates the current progress percentage of the task execution.</param>
        /// <param name="errorHandler"><see cref="Action{T}"/> that handles caught exceptions and processes them, such as logging.</param>
        private EntityInstaller(IEnumerable<KeyValuePair<int, IInstallerAction>> actions, Action<double> updateProgressPercentage = null, Action<Exception> errorHandler = null)
            : base(actions, updateProgressPercentage, errorHandler)
        { }

        /// <summary>
        /// Executes the current installer with the provided arguments.
        /// </summary>
        /// <param name="args">Arguments to supply to the install actions (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override WhippetResultContainer<object> Install(params object[] args)
        {
            WhippetResultContainer<object> result = null;
            int complete = 0;
            
            try
            {
                foreach (KeyValuePair<int, IInstallerAction> action in Actions)
                {
                    if (action.Value != null)
                    {
                        result = action.Value.Execute(NHibernateOptions, Seeds);
                        complete++;
                        UpdateProgress(complete);
                    }

                    if (!result.IsSuccess)
                    {
                        HandleError(result.Exception);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<object>(e);
                HandleError(e);
            }

            return result;
        }

        /// <summary>
        /// Executes the current installer asynchronously with the specified parameters.
        /// </summary>
        /// <param name="args">Parameters to pass to the installer actions (if any).</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public override Task<WhippetResultContainer<object>> InstallAsync(IEnumerable<object> args = null, CancellationToken token = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EntityInstaller"/> class with the specified parameters.
        /// </summary>
        /// <param name="configuration"><see cref="NHibernateConfigurationOptions"/> object that contains the database information for creating the entities.</param>
        /// <param name="seeds"><see cref="IEnumerable{T}"/> collection of <see cref="IWhippetEntity"/> objects that are to be seeded in the data store indexed by their execution order.</param>
        /// <param name="updateProgressPercentage"><see cref="Action{T}"/> that updates the progress percentage of the installer.</param>
        /// <param name="errorHandler"><see cref="Action{T}"/> that reports exceptions to an external caller.</param>
        /// <returns><see cref="EntityInstaller"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityInstaller CreateInstaller(NHibernateConfigurationOptions configuration, IEnumerable<KeyValuePair<int, ISeedServiceManager>> seeds = null, Action<double> updateProgressPercentage = null, Action<Exception> errorHandler = null)
        {
            SortedList<int, IInstallerAction> actions = new SortedList<int, IInstallerAction>();

            EntityInstaller installer = null;
            
            IInstallerAction schemaAction = null;
            IInstallerAction seedAction = null;

            if (seeds == null)
            {
                seeds = new SortedList<int, ISeedServiceManager>();
            }

            schemaAction = new SchemaAction();
            seedAction = new SeedAction();

            actions.Add(0, schemaAction);
            actions.Add(1, seedAction);
            
            installer = new EntityInstaller(actions, updateProgressPercentage, errorHandler);
            installer.NHibernateOptions = configuration;
            installer.Seeds = (seeds is SortedList<int, ISeedServiceManager>) ? (SortedList<int, ISeedServiceManager>)(seeds) : new SortedList<int, ISeedServiceManager>(new Dictionary<int, ISeedServiceManager>(seeds));

            return installer;
        }
    }
}
