using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Athi.Whippet.Data.Database;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.Database.Oracle.MySQL;

namespace Athi.Whippet.Installer.Framework.Database
{
    /// <summary>
    /// Factory that creates <see cref="WhippetDatabaseConnection"/> objects based on a user's selection in the installer. This class cannot be inherited.
    /// </summary>
    public static class DatabaseConnectionFactory
    {
        private static Dictionary<Type, string> _availableConnectionTypes;
        
        /// <summary>
        /// Gets the available connection types for the installer. This property is read-only.
        /// </summary>
        private static Dictionary<Type, string> _AvailableConnectionTypes
        {
            get
            {
                if (_availableConnectionTypes == null)
                {
                    _availableConnectionTypes = new Dictionary<Type, string>();
                }

                return _availableConnectionTypes;
            }
        }
        
        /// <summary>
        /// Gets the available connection types for the installer. This property is read-only.
        /// </summary>
        public static IReadOnlyDictionary<Type, string> AvailableConnectionTypes
        {
            get
            {
                return new ReadOnlyDictionary<Type, string>(_AvailableConnectionTypes);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnectionFactory"/> class with no arguments.
        /// </summary>
        static DatabaseConnectionFactory()
        {
            _AvailableConnectionTypes.Add(typeof(WhippetSqlServerConnection), "Microsoft SQL Server");
            _AvailableConnectionTypes.Add(typeof(WhippetMySqlConnection), "MySQL");
        }

        /// <summary>
        /// Creates a new database connection with the given connection string.
        /// </summary>
        /// <param name="connectionString">Connection string to create the new connection with.</param>
        /// <typeparam name="TConnection">Type of database connection to create.</typeparam>
        /// <returns><typeparamref name="TConnection"/> object.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static TConnection CreateConnection<TConnection>(string connectionString) where TConnection : WhippetDatabaseConnection, new()
        {
            if (!AvailableConnectionTypes.ContainsKey(typeof(TConnection)))
            {
                throw new ArgumentException("Connection type " + typeof(TConnection) + " is not supported.");
            }
            else
            {
                TConnection connection = default(TConnection);
                
                WhippetSqlServerConnection sqlConnection = null;
                WhippetMySqlConnection mySqlConnection = null;

                if (typeof(TConnection).Equals(typeof(WhippetSqlServerConnection)))
                {
                    sqlConnection = new WhippetSqlServerConnection(connectionString);
                    connection = (TConnection)((object)(sqlConnection));
                }
                else if (typeof(TConnection).Equals(typeof(WhippetMySqlConnection)))
                {
                    mySqlConnection = new WhippetMySqlConnection(connectionString);
                    connection = (TConnection)((object)(mySqlConnection));
                }

                return connection;
            }
        }
    }
}
