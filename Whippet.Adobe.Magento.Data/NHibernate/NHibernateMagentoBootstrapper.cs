using System;
using NHibernate;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Bootstrapper that provides methods for creating NHibernate database connections. This class cannot be inherited.
    /// </summary>
    public static class NHibernateMagentoBootstrapper
    {
        /// <summary>
        /// Creates an <see cref="ISessionFactory"/> object for creating connections to the database.
        /// </summary>
        /// <param name="connectionString">Connection string to assign to the internal session connection strings.</param>
        /// <param name="mappings">NHibernate Fluent mappings to apply for the session.</param>
        /// <returns><see cref="ISessionFactory"/> objects.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ISessionFactory CreateSessionFactory(string connectionString, IEnumerable<NHibernateBootstrapperMappingDelegate> mappings = null)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            else
            {
                NHibernateConfigurationOptions options;

                if (mappings != null && mappings.Any())
                {
                    foreach (NHibernateBootstrapperMappingDelegate bmd in mappings)
                    {
                        bmd(ref options);
                    }
                }

                NHibernateConfigurationHelper.ConfigureForMySqlWithConnectionString(ref options, connectionString);

                return DefaultNHibernateSessionFactory.Create(options);
            }
        }
    }
}