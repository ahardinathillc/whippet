using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Athi.Whippet.Data.NHibernate;

namespace Athi.Whippet.Data.Database.Microsoft.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="WhippetSqlServerConnection"/> objects. This class cannot be inherited.
    /// </summary>
    public static class WhippetSqlServerConnectionExtensions
    {
        /// <summary>
        /// Loads the default connection string for Whippet based on the value in <see cref="NHibernateConstantsIndex.PrimaryConnectionStringName"/> into the specified <see cref="WhippetSqlServerConnection"/>.
        /// </summary>
        /// <param name="connection"><see cref="WhippetSqlServerConnection"/> object to load the connection string into.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void LoadWhippetConnectionStringFromConfigurationFile(this WhippetSqlServerConnection connection, bool defaultToWhippetDatabase = true)
        {
            if(connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            else
            {
                SqlConnectionStringBuilder builder = null;

                LoadConnectionStringFromConfigurationFile(connection, NHibernateConstantsIndex.PrimaryConnectionStringName);

                if(!defaultToWhippetDatabase)
                {
                    // default to master instead

                    builder = new SqlConnectionStringBuilder(connection.ConnectionString);
                    builder.InitialCatalog = "master";
                    connection.ConnectionString = builder.ConnectionString;
                }
            }
        }

        /// <summary>
        /// Loads the connection string from the configuration file based on the specified configuration key.
        /// </summary>
        /// <param name="connection"><see cref="WhippetSqlServerConnection"/> object to load the connection string into.</param>
        /// <param name="configurationFileKey">Configuration file key of the connection string to load.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ConfigurationErrorsException"></exception>
        public static void LoadConnectionStringFromConfigurationFile(this WhippetSqlServerConnection connection, string configurationFileKey)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            else if(String.IsNullOrWhiteSpace(configurationFileKey))
            {
                throw new ArgumentNullException(nameof(configurationFileKey));
            }
            else
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings[configurationFileKey].ConnectionString;
            }
        }

        /// <summary>
        /// Determines if the default Whippet database exists. Uses the value specified by the <see cref="WhippetSqlServerConnection.DefaultDatabaseName"/> field.
        /// </summary>
        /// <param name="connection"><see cref="WhippetSqlServerConnection"/> object used to connect to the database.</param>
        /// <param name="closeConnectionOnComplete">If <see langword="true"/>, <paramref name="connection"/> will be closed before the method returns.</param>
        /// <returns><see langword="true"/> if the database exists; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool DatabaseExists(this WhippetSqlServerConnection connection, bool closeConnectionOnComplete = true)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            else if(String.IsNullOrWhiteSpace(connection.ConnectionString))
            {
                throw new ArgumentNullException(nameof(connection.ConnectionString));
            }
            else
            {
                SqlConnectionStringBuilder csBuilder = new SqlConnectionStringBuilder();
                string dbName = csBuilder.InitialCatalog;

                if(String.IsNullOrWhiteSpace(dbName))
                {
                    dbName = WhippetSqlServerConnection.DefaultDatabaseName;
                }

                return DatabaseExists(connection, dbName, closeConnectionOnComplete);
            }
        }

        /// <summary>
        /// Determines if the specified database exists.
        /// </summary>
        /// <param name="connection"><see cref="WhippetSqlServerConnection"/> object used to connect to the database.</param>
        /// <param name="databaseName">Name of the database to search for.</param>
        /// <param name="closeConnectionOnComplete">If <see langword="true"/>, <paramref name="connection"/> will be closed before the method returns.</param>
        /// <returns><see langword="true"/> if the database exists; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool DatabaseExists(this WhippetSqlServerConnection connection, string databaseName, bool closeConnectionOnComplete = true)
        {
            if(connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            else if(String.IsNullOrWhiteSpace(databaseName))
            {
                throw new ArgumentNullException(nameof(databaseName));
            }
            else
            {
                SqlDataReader reader = null;
                SqlCommand command = null;
                SqlParameter pDatabaseName = null;

                bool exists = false;

                try
                {
                    command = connection.CreateCommand();
                    command.CommandText = "IF EXISTS (SELECT name FROM master.sys.databases WHERE name = @name) SELECT 1 ELSE SELECT 0";

                    pDatabaseName = command.CreateParameter();
                    pDatabaseName.ParameterName = "@name";
                    pDatabaseName.Value = databaseName;
                    pDatabaseName.SqlDbType = SqlDbType.NVarChar;

                    command.Parameters.Add(pDatabaseName);

                    if(connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    reader = command.ExecuteReader();

                    exists = (reader.Read() && Convert.ToBoolean(reader[0]));
                }
                finally
                {
                    if(closeConnectionOnComplete)
                    {
                        connection.Close();
                    }
                }

                return exists;
            }
        }

        /// <summary>
        /// Executes the specified SQL script.
        /// </summary>
        /// <param name="connection"><see cref="WhippetSqlServerConnection"/> object used to connect to the database.</param>
        /// <param name="scriptContents">SQL script contents.</param>
        /// <param name="closeConnectionOnComplete">If <see langword="true"/>, <paramref name="connection"/> will be closed before the method returns.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ExecuteScript(this WhippetSqlServerConnection connection, string scriptContents, bool closeConnectionOnComplete = true)
        {
            if(connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            else if(String.IsNullOrWhiteSpace(scriptContents))
            {
                throw new ArgumentNullException(nameof(scriptContents));
            }
            else
            {
                IEnumerable<string> commands = Regex.Split(scriptContents, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                SqlCommand command = null;

                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    if (commands.Any())
                    {
                        foreach (string c in commands)
                        {
                            command = connection.CreateCommand();
                            command.CommandText = c;

                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            finally
                            {
                                if(command != null)
                                {
                                    command.Dispose();
                                    command = null;
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if(closeConnectionOnComplete)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
