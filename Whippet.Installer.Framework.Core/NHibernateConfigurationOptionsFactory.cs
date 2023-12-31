using System;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.Database.Oracle.MySQL;
using Athi.Whippet.Data.NHibernate;

namespace Athi.Whippet.Installer.Framework.Core
{
    /// <summary>
    /// Factory used for creating <see cref="NHibernateConfigurationOptions"/> objects from a given connection string and database type. This class cannot be inherited.
    /// </summary>
    public static class NHibernateConfigurationOptionsFactory
    {
        /// <summary>
        /// Creates a new <see cref="NHibernateConfigurationOptions"/> instance based on the specified connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used to connect to the data store.</param>
        /// <param name="dbType"><see cref="Type"/> that describes which vendor to use.</param>
        /// <returns><see cref="NHibernateConfigurationOptions"/> object that was created.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static NHibernateConfigurationOptions CreateNHibernateConfiguration(string connectionString, Type dbType)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            else if (dbType == null)
            {
                throw new ArgumentNullException(nameof(dbType));
            }
            else
            {
                NHibernateConfigurationOptions options = new NHibernateConfigurationOptions();
                
                if (dbType.Equals(typeof(WhippetSqlServerConnection)))
                {
                    NHibernateConfigurationHelper.ConfigureForSqlServerWithConnectionString(options, WhippetSqlServerConnectionStringBuilder.EnsureDockerCompatibility(connectionString));
                }
                else if (dbType.Equals(typeof(WhippetMySqlConnection)))
                {
                    NHibernateConfigurationHelper.ConfigureForMySqlWithConnectionString(options, connectionString);
                }
                else
                {
                    throw new ArgumentException("Database connection of type " + dbType.FullName + " is not supported.");
                }
                
                return options;
            }
        }
    }
}
