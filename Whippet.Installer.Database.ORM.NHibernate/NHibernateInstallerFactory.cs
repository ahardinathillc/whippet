using System;
using System.Reflection;
using System.Text;
using Athi.Whippet.Data.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Athi.Whippet.Installer.Database.ORM.NHibernate
{
    /// <summary>
    /// Factory used for creating NHibernate objects that are used in the installation process. This class cannot be inherited.
    /// </summary>
    public sealed class NHibernateInstallerFactory : NHibernateFactoryBase
    {
        private static NHibernateInstallerFactory _factory;
        
        /// <summary>
        /// Gets a singleton instance of the current object. This property is read-only.
        /// </summary>
        public static new NHibernateInstallerFactory Instance
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new NHibernateInstallerFactory();
                }

                return _factory;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateInstallerFactory"/> class with no arguments.
        /// </summary>
        private NHibernateInstallerFactory()
            : base()
        { }

        /// <summary>
        /// Enables the option to update the target data source schemas to match the current implementation.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> options.</param>
        /// <param name="useStandardOut">If <see langword="true"/>, output (such as exceptions) will be printed to standard output.</param>
        /// <param name="updateSchemas">If <see langword="true"/>, existing schemas will be updated to match the current implementation of the entity mappings as well as create new schemas for missing mappings.</param>
        public void UpdateSchema(ref NHibernateConfigurationOptions options, bool useStandardOut = true, bool updateSchemas = true)
        {
            options.NHibernateConfiguration = new Action<Configuration>(config => new SchemaUpdate(config).Execute(useStandardOut, updateSchemas));
        }

        /// <summary>
        /// Updates the data store specified in <paramref name="options"/>.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> that specify the destination data store and options.</param>
        /// <returns></returns>
        public WhippetResult Install(NHibernateConfigurationOptions options)
        {
            WhippetResult result = WhippetResult.Success;
            
            ISessionFactory sessionFactory = null;
            ISession session = null;

            SortedList<int, Exception> exceptions = null;

            Exception currentException = null;
            Exception originalException = null;
            
            StringBuilder exceptionBuilder = null;
            
            int i = 1;
            
            exceptionBuilder = new StringBuilder();
            
            try
            {
                exceptions = new SortedList<int, Exception>();
                
                sessionFactory = DefaultNHibernateSessionFactory.Create(options);
                session = sessionFactory.OpenSession();
            }
            catch (Exception e)
            {
                originalException = e;
                currentException = e;
                
                do
                {
                    exceptions.Add(i, currentException);
                    i++;
                    
                    currentException = e.InnerException;
                } while (currentException != null);
            }

            if ((exceptions != null) && (exceptions.Count > 0))
            {
                foreach (Exception caughtException in exceptions.OrderByDescending(k => k.Key).Select(e => e.Value))
                {
                    exceptionBuilder.AppendLine(caughtException.Message);
                }

                result = new WhippetResult(WhippetResultSeverity.Failure, exceptionBuilder.ToString(), originalException);
            }

            return result;
        }
    }
}
