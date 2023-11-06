using System;
using System.Configuration;
using FluentNHibernate.Cfg.Db;

namespace Athi.Whippet.Data.NHibernate
{
    /// <summary>
    /// Configuration helper class used for configuring <see cref="NHibernateConfigurationOptions"/> instances. This class cannot be inherited.
    /// </summary>
    public static class NHibernateConfigurationHelper
    {
        /// <summary>
        /// Configures NHibernate for use with a SQL Server database engine.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="connectionStringName">Connection string name to retrieve from the configuration file. If <see cref="String.Empty"/> or <see langword="null"/>, will use <see cref="NHibernateConstantsIndex.PrimaryConnectionStringName"/>.</param>
        public static void ConfigureForSqlServer(ref NHibernateConfigurationOptions options, string connectionStringName = null)
        {
            string csName = String.IsNullOrWhiteSpace(connectionStringName) ? ConfigurationManager.ConnectionStrings[NHibernateConstantsIndex.PrimaryConnectionStringName].ConnectionString : ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            options.DatabaseConfiguration = new Func<IPersistenceConfigurer>(() => MsSqlConfiguration.MsSql2012.ConnectionString(csName));
        }

        /// <summary>
        /// Configures NHibernate for use with a SQL Server database engine.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="connectionString">Connection string to use.</param>
        public static void ConfigureForSqlServerWithConnectionString(ref NHibernateConfigurationOptions options, string connectionString)
        {
            options.DatabaseConfiguration = new Func<IPersistenceConfigurer>(() => MsSqlConfiguration.MsSql2012.ConnectionString(c => c.Is(connectionString)));
        }

        /// <summary>
        /// Configures NHibernate for use with a SQLite database engine.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="dbFile">Fully qualified path name to the database file to create. If <see langword="null"/>, will create the database in memory.</param>
        public static void ConfigureForSqlite(ref NHibernateConfigurationOptions options, string dbFile = null)
        {
            if (String.IsNullOrWhiteSpace(dbFile))
            {
                options.DatabaseConfiguration = new Func<IPersistenceConfigurer>(() => SQLiteConfiguration.Standard.InMemory());
            }
            else
            {
                options.DatabaseConfiguration = new Func<IPersistenceConfigurer>(() => SQLiteConfiguration.Standard.UsingFile(dbFile));
            }
        }

        /// <summary>
        /// Configures NHibernate for use with a MySQL database engine.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="connectionStringName">Connection string name to retrieve from the configuration file. If <see cref="String.Empty"/> or <see langword="null"/>, will use <see cref="NHibernateConstantsIndex.PrimaryConnectionStringName"/>.</param>
        public static void ConfigureForMySql(ref NHibernateConfigurationOptions options, string connectionStringName = null)
        {
            string csName = String.IsNullOrWhiteSpace(connectionStringName) ? ConfigurationManager.ConnectionStrings[NHibernateConstantsIndex.PrimaryConnectionStringName].ConnectionString : ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            options.DatabaseConfiguration = new Func<IPersistenceConfigurer>(() => MySQLConfiguration.Standard.ConnectionString(csName));
        }

        /// <summary>
        /// Configures NHibernate for use with a MySQL database engine.
        /// </summary>
        /// <param name="options"><see cref="NHibernateConfigurationOptions"/> struct.</param>
        /// <param name="connectionString">Connection string to use.</param>
        public static void ConfigureForMySqlWithConnectionString(ref NHibernateConfigurationOptions options, string connectionString)
        {
            options.DatabaseConfiguration = new Func<IPersistenceConfigurer>(() => MySQLConfiguration.Standard.ConnectionString(c => c.Is(connectionString)));
        }
    }
}
