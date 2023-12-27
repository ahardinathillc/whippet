using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Athi.Whippet.Data.NHibernate;

namespace Athi.Whippet.Installer.Framework.Database.Entities
{
    /// <summary>
    /// Performs a database update for the appropriate RDBMS. This class must be inherited.
    /// </summary>
    internal class SchemaAction : InstallerActionBase, IInstallerAction
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
        /// Initializes a new instance of the <see cref="SchemaAction"/> class with no arguments.
        /// </summary>
        public SchemaAction()
            : base("Creating and Updating Schemas")
        { }

        /// <summary>
        /// Executes the current action with the specified parameters.
        /// </summary>
        /// <param name="args">Parameters to pass to the action (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override WhippetResultContainer<object> Execute(params object[] args)
        {
            ISessionFactory factory = null;

            ISession session = null;
            
            WhippetResultContainer<object> result = null;
            
            NHibernateConfigurationOptions options = default(NHibernateConfigurationOptions);
            
            VerifyParameters(typeof(NHibernateConfigurationOptions), args);

            options = (NHibernateConfigurationOptions)(args.First(arg => arg is NHibernateConfigurationOptions));
            
            options.NHibernateConfiguration = new Action<Configuration>(config =>
            {
                new SchemaUpdate(config).Execute(false, true);
            });

            try
            {
                factory = DefaultNHibernateSessionFactory.Create(options);
                session = factory.OpenSession();

                result = new WhippetResultContainer<object>(WhippetResult.Success, options);
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
