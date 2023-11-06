using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Security;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Represents a connection to a SQL Server database. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetSqlServerConnection : WhippetDatabaseConnection<SqlConnection>, IWhippetCloneable, ICloneable
    {
        /// <summary>
        /// Default database name used by Whippet on Microsoft SQL Server instances.
        /// </summary>
        public const string DefaultDatabaseName = "Whippet";

        /// <summary>
        /// Default schema name used by Whippet on Microsoft SQL Server instances.
        /// </summary>
        public const string DefaultSchemaName = "whippet";

        /// <summary>
        /// Gets or sets the access token for the connection.
        /// </summary>
        [Browsable(false)]
        public string AccessToken
        {
            get
            {
                return InternalConnection.AccessToken;
            }
            set
            {
                InternalConnection.AccessToken = value;
            }
        }

        /// <summary>
        /// Gets the connection ID of the most recent connection attempt, regardless of whether the attempt succeeded or failed. This property is read-only.
        /// </summary>
        public Guid ClientConnectionID
        {
            get
            {
                return InternalConnection.ClientConnectionId;
            }
        }

        /// <summary>
        /// Gets or sets the time-to-live (TTL) for column encryption key entries in the column encryption key cache for the <a href="https://docs.microsoft.com/en-us/sql/relational-databases/security/encryption/always-encrypted-database-engine">Always Encrypted</a> feature. The default value is two (2) hours. Zero (0) means no caching at all.
        /// </summary>
        public static TimeSpan ColumnEncryptionKeyCacheTTL
        {
            get
            {
                return SqlConnection.ColumnEncryptionKeyCacheTtl;
            }
            set
            {
                SqlConnection.ColumnEncryptionKeyCacheTtl = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether query metadata caching is enabled (<see langword="true"/>) or not (<see langword="false"/>) for parameterized queries running against <a href="https://docs.microsoft.com/en-us/sql/relational-databases/security/encryption/always-encrypted-database-engine">Always Encrypted</a> enabled databases. The default value is <see langword="true"/>.
        /// </summary>
        public static bool ColumnEncryptionQueryMetadataCacheEnabled
        {
            get
            {
                return SqlConnection.ColumnEncryptionQueryMetadataCacheEnabled;
            }
            set
            {
                SqlConnection.ColumnEncryptionQueryMetadataCacheEnabled = value;
            }
        }

        /// <summary>
        /// Allows you to set a list of trusted key paths for a database server. If while processing an application query the driver receives a key path that is not on the list, the query will fail. This property provides additional protection against security attacks that involve a compromised SQL Server providing fake key paths, which may lead to leaking key store credentials. This property is read-only.
        /// </summary>
        public static IDictionary<string, IList<string>> ColumnEncryptionTrustedMasterKeyPaths
        {
            get
            {
                return SqlConnection.ColumnEncryptionTrustedMasterKeyPaths;
            }
        }

        /// <summary>
        /// Gets the default wait time (in seconds) before terminating the attempt to execute a command and generating an error. The default is 30 seconds. This property is read-only.
        /// </summary>
        public int CommandTimeout
        {
            get
            {
                return InternalConnection.CommandTimeout;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="SqlCredential"/> object for this connection.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        public SqlCredential Credential
        {
            get
            {
                return InternalConnection.Credential;
            }
            set
            {
                InternalConnection.Credential = value;
            }
        }

        /// <summary>
        /// If <see langword="true"/>, errors that were previously treated as exceptions are now handled as <see cref="SqlConnection.InfoMessage"/> events. All events fire immediately and are handled by the event handler. Otherwise, <see cref="SqlConnection.InfoMessage"/> events are handled at the end of the procedure.
        /// </summary>
        public bool FireInfoMessageEventOnUserErrors
        {
            get
            {
                return InternalConnection.FireInfoMessageEventOnUserErrors;
            }
            set
            {
                InternalConnection.FireInfoMessageEventOnUserErrors = value;
            }
        }

        /// <summary>
        /// Gets the size (in bytes) of network packets used to communicate with an instance of SQL Server. This property is read-only.
        /// </summary>
        public int PacketSize
        {
            get
            {
                return InternalConnection.PacketSize;
            }
        }

        /// <summary>
        /// Gets or sets a value that specifies the <see cref="SqlRetryLogicBaseProvider"/> object bound to this command.
        /// </summary>
        public SqlRetryLogicBaseProvider RetryLogicProvider
        {
            get
            {
                return InternalConnection.RetryLogicProvider;
            }
            set
            {
                InternalConnection.RetryLogicProvider = value;
            }
        }

        /// <summary>
        /// Gets the server process ID (SPID) of the active connection. This property is read-only.
        /// </summary>
        public int ServerProcessID
        {
            get
            {
                return InternalConnection.ServerProcessId;
            }
        }

        /// <summary>
        /// If <see langword="true"/>, enables statistics gathering for the current connection.
        /// </summary>
        public bool StatisticsEnabled
        {
            get
            {
                return InternalConnection.StatisticsEnabled;
            }
            set
            {
                InternalConnection.StatisticsEnabled = value;
            }
        }

        /// <summary>
        /// Gets a string that identifies the database client. This property is read-only.
        /// </summary>
        public string WorkstationID
        {
            get
            {
                return InternalConnection.WorkstationId;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerConnection"/> class with no arguments.
        /// </summary>
        public WhippetSqlServerConnection()
            : this(new SqlConnection())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerConnection"/> class with the specified <see cref="SqlConnection"/> object.
        /// </summary>
        /// <param name="sqlConnection"><see cref="SqlConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSqlServerConnection(SqlConnection sqlConnection)
            : base(sqlConnection)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerConnection"/> class with the specified connection string.
        /// </summary>
        /// <param name="connectionString">The connection used to open the SQL Server database.</param>
        /// <exception cref="ArgumentException" />
        public WhippetSqlServerConnection(string connectionString)
            : this(new SqlConnection(connectionString))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerConnection"/> class with the specified connection string and credential.
        /// </summary>
        /// <param name="connectionString">The connection used to open the SQL Server database.</param>
        /// <param name="credential">A <see cref="SqlCredential"/> object.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSqlServerConnection(string connectionString, SqlCredential credential)
            : this(new SqlConnection(connectionString, credential))
        { }

        /// <summary>
        /// Starts a database transaction.
        /// </summary>
        /// <returns>An object representing the new transaction.</returns>
        public new SqlTransaction BeginTransaction()
        {
            return InternalConnection.BeginTransaction();
        }

        /// <summary>
        /// Starts a database transaction with the specified isolation level.
        /// </summary>
        /// <param name="isolationLevel">The isolation level under which the transaction should run.</param>
        /// <returns>An object representing the new transaction.</returns>
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        public new SqlTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return InternalConnection.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Changes the SQL Server password for the user indicated in the connection string to the supplied new password.
        /// </summary>
        /// <param name="connectionString">The connection string that contains enough information to connect to the server you want. The connection string must contain the user ID and the current password.</param>
        /// <param name="newPassword">The new password to set. This password must comply with any password security policy set on the server, including minimum length, requirements for specific characters, etc.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public static void ChangePassword(string connectionString, string newPassword)
        {
            SqlConnection.ChangePassword(connectionString, newPassword);
        }

        /// <summary>
        /// Changes the SQL Server password for the user indicated in the <see cref="SqlCredential"/> parameter.
        /// </summary>
        /// <param name="connectionString">The connection string that contains enough information to connect to the server you want.</param>
        /// <param name="credential">A <see cref="SqlCredential"/> object.</param>
        /// <param name="newPassword">The new (read-only) password. This password must comply with any password security policy set on the server, including minimum length, requirements for specific characters, etc.</param>
        public static void ChangePassword(string connectionString, SqlCredential credential, SecureString newPassword)
        {
            SqlConnection.ChangePassword(connectionString, credential, newPassword);
        }

        /// <summary>
        /// Empties the connection pool.
        /// </summary>
        public static void ClearAllPools()
        {
            SqlConnection.ClearAllPools();
        }

        /// <summary>
        /// Empties the connection pool associated with the specified connection.
        /// </summary>
        /// <param name="connection">The <see cref="SqlConnection"/> to be cleared from the pool.</param>
        public static void ClearPool(SqlConnection connection)
        {
            SqlConnection.ClearPool(connection);
        }

        /// <summary>
        /// Creates and returns a <see cref="SqlCommand"/> object associated with the <see cref="WhippetSqlServerConnection"/>.
        /// </summary>
        /// <returns>A <see cref="SqlCommand"/> object.</returns>
        public new SqlCommand CreateCommand()
        {
            return InternalConnection.CreateCommand();
        }

        /// <summary>
        /// Opens a database connection with the property settings specified by the connection string.
        /// </summary>
        /// <param name="overrides">Options to override default connection opening behaviors.</param>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="SqlException" />.
        /// <exception cref="ConfigurationErrorsException" />
        public void Open(SqlConnectionOverrides overrides)
        {
            InternalConnection.Open(overrides);
        }

        /// <summary>
        /// Registers the column encryption key store providers. This function should only be called once in an app. This does shallow copying of the dictionary so that the app cannot alter the custom provider list once it has been set. The built-in column master key store providers that are available for the Windows Certificate Store, CNG Store and CSP are pre-registered.
        /// </summary>
        /// <param name="customProviders">Dictionary of custom column encryption key store providers.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="InvalidOperationException" />
        public static void RegisterColumnEncryptionKeyStoreProviders(IDictionary<string, SqlColumnEncryptionKeyStoreProvider> customProviders)
        {
            SqlConnection.RegisterColumnEncryptionKeyStoreProviders(customProviders);
        }

        /// <summary>
        /// Registers the column encryption key store providers on the current instance. If this function has been called, any providers registered using <see cref="RegisterColumnEncryptionKeyStoreProviders(IDictionary{string, SqlColumnEncryptionKeyStoreProvider})"/> will be ignored. This function can be called more than once. This does shallow copying of the dictionary so that the app cannot alter the custom provider list once it has been set.
        /// </summary>
        /// <param name="customProviders">Dictionary of custom column encryption key store providers.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public void RegisterColumnEncryptionKeyStoreProvidersOnConnection(IDictionary<string, SqlColumnEncryptionKeyStoreProvider> customProviders)
        {
            InternalConnection.RegisterColumnEncryptionKeyStoreProvidersOnConnection(customProviders);
        }

        /// <summary>
        /// If statistics gathering is enabled, all values are reset to zero.
        /// </summary>
        public void ResetStatistics()
        {
            InternalConnection.ResetStatistics();
        }

        /// <summary>
        /// Returns a name/value pair collection of internal properties at the point in time the method is called.
        /// </summary>
        /// <returns>Returns a reference of type <see cref="IDictionary{TKey, TValue}"/> of (string, object) items.</returns>
        public IDictionary<string, object> RetrieveInternalInfo()
        {
            return InternalConnection.RetrieveInternalInfo();
        }

        /// <summary>
        /// Returns a name/value pair collection of statistics at the point in time the method is called.
        /// </summary>
        /// <returns>Returns a reference type of <see cref="IDictionary"/> of <see cref="DictionaryEntry"/> items.</returns>
        public IDictionary RetrieveStatistics()
        {
            return InternalConnection.RetrieveStatistics();
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public object Clone()
        {
            WhippetSqlServerConnection connection = null;

            if (!String.IsNullOrWhiteSpace(ConnectionString))
            {
                if (Credential == null)
                {
                    connection = new WhippetSqlServerConnection(ConnectionString);
                }
                else
                {
                    connection = new WhippetSqlServerConnection(ConnectionString, new SqlCredential(Credential.UserId, Credential.Password));
                }
            }
            else
            {
                connection = new WhippetSqlServerConnection();
            }

            return connection;
        }

        /// <summary>
        /// Removes unsupported keywords for <see cref="SqlConnection"/> objects that are compatible with .NET Core 3.5 or prior releases.
        /// </summary>
        /// <param name="rawConnectionString">Original connection string to sanitize.</param>
        /// <returns>Sanitized connection string.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string RemoveUnsupportedKeywords(string rawConnectionString)
        {
            if (String.IsNullOrWhiteSpace(rawConnectionString))
            {
                throw new ArgumentNullException(nameof(rawConnectionString));
            }
            else
            {
                WhippetSqlServerConnectionStringBuilder builder = null;
                StringBuilder rawBuilder = new StringBuilder();

                string sanitizedString = null;

                string[] unsupportedOptions = new[]
                {
                "pool blocking period",
                "multiple active result sets",
                "trust server certificate",
                "authentication",
                "application intent",
                "multi subnet failover",
                "connect retry count",
                "connect retry interval",
                "column encryption setting",
                "enclave attestation url",
                "attestation protocol",
                "command timeout",
                "ip address preference"
            };

                builder = new WhippetSqlServerConnectionStringBuilder(rawConnectionString);

                foreach (string entry in builder.Keys)
                {
                    if (!unsupportedOptions.Contains(entry, StringComparer.InvariantCultureIgnoreCase))
                    {
                        rawBuilder.Append(entry);
                        rawBuilder.Append("=");
                        rawBuilder.Append(builder[entry]);
                        rawBuilder.Append(';');
                    }
                }

                sanitizedString = rawBuilder.ToString();

                if (!sanitizedString.Contains(nameof(WhippetSqlServerConnectionStringBuilder.TrustServerCertificate), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!sanitizedString.EndsWith(';'))
                    {
                        sanitizedString = sanitizedString + ';';
                    }

                    sanitizedString = sanitizedString + nameof(WhippetSqlServerConnectionStringBuilder.TrustServerCertificate) + "=" + Convert.ToString(builder.TrustServerCertificate);
                }

                return sanitizedString;
            }
        }

        /// <summary>
        /// Removes all options that have "NotSpecified" assigned to their value.
        /// </summary>
        /// <param name="sqlConnectionString">SQL Server connection string.</param>
        /// <returns>SQL Server connection string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string RemoveNotSpecifiedOptions(string sqlConnectionString)
        {
            if (String.IsNullOrWhiteSpace(sqlConnectionString))
            {
                throw new ArgumentNullException(nameof(sqlConnectionString));
            }
            else
            {
                WhippetSqlServerConnectionStringBuilder builder = null;
                StringBuilder rawBuilder = new StringBuilder();

                if (!String.IsNullOrWhiteSpace(sqlConnectionString))
                {
                    builder = new WhippetSqlServerConnectionStringBuilder(sqlConnectionString);

                    foreach (string entry in builder.Keys)
                    {
                        if (!Convert.ToString(builder[entry]).Equals("NotSpecified", StringComparison.InvariantCultureIgnoreCase) && !String.IsNullOrWhiteSpace(Convert.ToString(builder[entry])))
                        {
                            rawBuilder.Append(entry);
                            rawBuilder.Append("=");
                            rawBuilder.Append(builder[entry]);
                            rawBuilder.Append(';');
                        }
                    }
                }

                return rawBuilder.ToString();
            }
        }

        /// <summary>
        /// Converts the specified <see cref="SqlConnection"/> object to a <see cref="WhippetSqlServerConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="SqlConnection"/> object.</param>
        public static implicit operator WhippetSqlServerConnection(SqlConnection connection)
        {
            return (connection == null) ? null : new WhippetSqlServerConnection(connection);
        }

        /// <summary>
        /// Converts the specified <see cref="WhippetSqlServerConnection"/> object to a <see cref="SqlConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="SqlConnection"/> object.</param>
        public static implicit operator SqlConnection(WhippetSqlServerConnection connection)
        {
            return (connection == null) ? null : connection.InternalConnection;
        }
    }
}
