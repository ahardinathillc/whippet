using System;
using System.Linq;
using NHibernate;
using FluentNHibernate.Cfg;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Represents a default <see cref="ISessionFactory"/> provider for NHibernate using Fluent NHibernate. This class cannot be inherited.
    /// </summary>
    public static class DefaultNHibernateSessionFactory
    {
        /// <summary>
        /// Creates a new <see cref="ISessionFactory"/> instance based the provided <see cref="NHibernateConfigurationOptions"/>.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> object that provides configuration options to NHibernate.</param>
        /// <returns><see cref="ISessionFactory"/> instance used to access the data store via NHibernate.</returns>
        public static ISessionFactory Create(NHibernateConfigurationOptions options)
        {
            FluentConfiguration baseConfig = Fluently.Configure();
            ISessionFactory factory = null;

            if (options.CacheConfiguration != null)
            {
                baseConfig.Cache(options.CacheConfiguration);
            }

            if (options.CollectionTypeFactoryType != null)
            {
                baseConfig.CollectionTypeFactory(options.CollectionTypeFactoryType);
            }

            if (options.DatabaseConfiguration != null)
            {
                baseConfig.Database(options.DatabaseConfiguration);
            }

            if(options.LoggingConfiguration != null)
            {
                baseConfig.Diagnostics(options.LoggingConfiguration);
            }

            if(options.MappingConfiguration != null)
            {
                baseConfig.Mappings(options.MappingConfiguration);
            }

            if(options.ProxyFactoryType != null)
            {
                baseConfig.ProxyFactoryFactory(options.ProxyFactoryType);
            }

            if (options.NHibernateConfiguration != null)
            {
                baseConfig.ExposeConfiguration(options.NHibernateConfiguration);
            }

            if (options.Properties != null && options.Properties.Any())
            {
                baseConfig.ExposeConfiguration(c =>
                {
                    options.Properties.ExportToConfiguration(c);
                });
            }

            try
            {
                factory = baseConfig.BuildSessionFactory();
                return factory;
            }
            catch (Exception)
            {
                if (factory != null)
                {
                    factory.Dispose();
                    factory = null;
                }

                throw;
            }
        }
    }
}
