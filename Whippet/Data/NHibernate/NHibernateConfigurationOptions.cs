using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Diagnostics;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Provides configuraiton options to set up an <see cref="ISessionFactory"/> instance in a session factory.
    /// </summary>
    public struct NHibernateConfigurationOptions
    {
        private NHibernatePropertyCollection _props;

        /// <summary>
        /// Configures cache settings for the connection.
        /// </summary>
        public Action<CacheSettingsBuilder> CacheConfiguration
        { get; set; }

        /// <summary>
        /// Specifies the collection factory type.
        /// </summary>
        public Type CollectionTypeFactoryType
        { get; set; }

        /// <summary>
        /// Allows for configuration of the database.
        /// </summary>
        public Func<IPersistenceConfigurer> DatabaseConfiguration
        { get; set; }

        /// <summary>
        /// Allows for configuration of logging.
        /// </summary>
        public Action<DiagnosticsConfiguration> LoggingConfiguration
        { get; set; }

        /// <summary>
        /// Allows for configuration of the NHibernate engine.
        /// </summary>
        public Action<Configuration> NHibernateConfiguration
        { get; set; }

        /// <summary>
        /// Allows for configuration of entity mappings.
        /// </summary>
        public Action<MappingConfiguration> MappingConfiguration
        { get; set; }

        /// <summary>
        /// Specifies the proxy factory type.
        /// </summary>
        public Type ProxyFactoryType
        { get; set; }

        /// <summary>
        /// Gets or sets the properties to apply to the NHibernate configuration.
        /// </summary>
        public NHibernatePropertyCollection Properties
        {
            get
            {
                if (_props == null)
                {
                    _props = new NHibernatePropertyCollection();
                }

                return _props;
            }
            set
            {
                _props = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateConfigurationOptions"/> structure with no arguments.
        /// </summary>
        static NHibernateConfigurationOptions()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateConfigurationOptions"/> structure with the specified <see cref="IPersistenceConfigurer"/> configuration delegate.
        /// </summary>
        /// <param name="databaseConfiguration">Delegate that is used to provide configuration information for the desired database to use with the current session.</param>
        public NHibernateConfigurationOptions(Func<IPersistenceConfigurer> databaseConfiguration)
            : this()
        {
            DatabaseConfiguration = databaseConfiguration;
        }
    }
}
