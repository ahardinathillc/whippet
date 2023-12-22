using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Base class for all factories used for creating NHibernate objects that are used in an installation process or application initialization. This class must be inherited.
    /// </summary>
    public abstract class NHibernateFactoryBase
    {
        /// <summary>
        /// Gets a singleton instance of the current object. This property is read-only.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        protected static NHibernateFactoryBase Instance
        {
            get
            {
                throw new InvalidOperationException("This property must be overridden in a derived class.");
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateFactoryBase"/> class with no arguments.
        /// </summary>
        protected NHibernateFactoryBase()
        { }
        
        /// <summary>
        /// Creates a new <see cref="NHibernateConfigurationOptions"/> instance with no configuration preloaded.
        /// </summary>
        /// <returns><see cref="NHibernateConfigurationOptions"/> instance.</returns>
        public virtual NHibernateConfigurationOptions CreateConfigurationOptions()
        {
            return new NHibernateConfigurationOptions();
        }

        /// <summary>
        /// Configures Fluent mappings for the specified assemblies.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> object to configure.</param>
        /// <param name="assemblies"><see cref="Assembly"/> objects containing the mappings to load.</param>
        public virtual void ConfigureMappings(ref NHibernateConfigurationOptions options, IEnumerable<Assembly> assemblies)
        {
            ArgumentNullException.ThrowIfNull(assemblies);

            if (assemblies.Any())
            {
                foreach (Assembly asm in assemblies)
                {
                    options.MappingConfiguration = new Action<MappingConfiguration>(mapping =>
                        {
                            mapping.FluentMappings.AddFromAssembly(asm);
                        }
                    );
                }
            }
        }

        /// <summary>
        /// Configures Fluent mappings for the specified types.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> object to configure.</param>
        /// <param name="types"><see cref="Type"/> objects containing the mappings to load.</param>
        public virtual void ConfigureMappings(ref NHibernateConfigurationOptions options, IEnumerable<Type> types)
        {
            ArgumentNullException.ThrowIfNull(types);

            if (types.Any())
            {
                ConfigureMappings(ref options, types.Select(t => t.Assembly));
            }
        }
        
        /// <summary>
        /// Configures the <see cref="NHibernateConfigurationOptions"/> to use a specific database type with a given connection string.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> object to configure.</param>
        /// <param name="databaseDialect">Specifies the type of database to configure NHibernate for.</param>
        /// <param name="connectionString">Connection string of the database.</param>
        public static void ConfigureDatabaseServer(ref NHibernateConfigurationOptions options, SupportedWhippetDatabaseTypes databaseDialect, string connectionString)
        {
            options.DatabaseConfiguration = new Func<IPersistenceConfigurer>(() =>
            {
                IPersistenceConfigurer pConfig = null;
                
                switch (databaseDialect)
                {
                    case SupportedWhippetDatabaseTypes.MsSql2012:
                        pConfig = MsSqlConfiguration.MsSql2012
                            .ConnectionString(connectionString)
                            .ShowSql();
                        break;
                    case SupportedWhippetDatabaseTypes.Sqlite:
                        pConfig = SQLiteConfiguration
                            .Standard
                            .ConnectionString(connectionString);
                        break;
                    default:
                        throw new InvalidEnumArgumentException(nameof(databaseDialect), Convert.ToInt32(databaseDialect), typeof(SupportedWhippetDatabaseTypes));
                }

                return pConfig;
            });
        }
    }
}
