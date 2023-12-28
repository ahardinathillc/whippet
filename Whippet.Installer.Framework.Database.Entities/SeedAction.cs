using System;
using Athi.Whippet.Data;
using NHibernate;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.ServiceManagers;

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
            SortedList<int, ISeedServiceManager> seeds = null;

            NHibernateConfigurationOptions options = default(NHibernateConfigurationOptions);
            
            WhippetResultContainer<object> result = null;
            
            VerifyParameters(typeof(NHibernateConfigurationOptions), args);
            VerifyParameters(typeof(SortedList<int, ISeedServiceManager>), args);

            options = (NHibernateConfigurationOptions)(args.First(a => a is NHibernateConfigurationOptions));
            seeds = (SortedList<int, ISeedServiceManager>)(args.First(a => a is SortedList<int, ISeedServiceManager>));
            
            try
            {
                foreach (KeyValuePair<int, ISeedServiceManager> seedEntry in seeds)
                {
                    result = new WhippetResultContainer<object>(seedEntry.Value.Seed(), seedEntry);
                    result.ThrowIfFailed();
                }

                if (result == null)
                {
                    result = new WhippetResultContainer<object>(WhippetResult.Success, null);
                }
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<object>(e);
            }

            return result;
        }
    }
}
