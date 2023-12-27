using System;
using Athi.Whippet.Data;
using NHibernate;
using Athi.Whippet.Data.NHibernate;

namespace Athi.Whippet.Installer.Framework.Database.Entities
{
    /// <summary>
    /// Performs a database seed for the appropriate RDBMS. This class must be inherited.
    /// </summary>
    internal class SeedAction : InstallerActionBase, IInstallerAction
    {
        /// <summary>
        /// Indicates whether the action supports asynchronous execution. This property is read-only.
        /// </summary>
        public override bool SupportsAsync
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeedAction"/> class with no arguments.
        /// </summary>
        public SeedAction()
            : base("Creating Seed Data")
        { }

        /// <summary>
        /// Executes the current action with the specified parameters.
        /// </summary>
        /// <param name="args">Parameters to pass to the action (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override WhippetResultContainer<object> Execute(params object[] args)
        {
            ISession session = null;
            ISessionFactory factory = null;
            
            SortedList<int, IWhippetEntitySeed> seeds = null;

            NHibernateConfigurationOptions options = default(NHibernateConfigurationOptions);
            
            WhippetResultContainer<object> result = null;
            
            VerifyParameters(typeof(NHibernateConfigurationOptions), args);
            VerifyParameters(typeof(IEnumerable<KeyValuePair<int, IWhippetEntitySeed>>), args);

            options = (NHibernateConfigurationOptions)(args.First(a => a is NHibernateConfigurationOptions));
            seeds = new SortedList<int, IWhippetEntitySeed>(
                new Dictionary<int, IWhippetEntitySeed>(
                    (IEnumerable<KeyValuePair<int, IWhippetEntitySeed>>)(args.First(a => a is IEnumerable<KeyValuePair<int, IWhippetEntitySeed>>))
                    )
                );
            
            try
            {
                factory = DefaultNHibernateSessionFactory.Create(options);
                session = factory.OpenSession();

                foreach (KeyValuePair<int, IWhippetEntitySeed> seedEntry in seeds)
                {
                    result = new WhippetResultContainer<object>(seedEntry.Value.Seed(session), options);
                    result.ThrowIfFailed();
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<object>(WhippetResult.Success, options);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<object>(e);
            }
            finally
            {
                if (session != null)
                {
                    session.Dispose();
                    session = null;
                }
                
                if (factory != null)
                {
                    factory.Dispose();
                    factory = null;
                }
            }

            return result;
        }
    }
}
