using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Represents a connection to a MySQL database. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMySqlConnection : WhippetDatabaseConnection<MySqlConnection>
    {
        /// <summary>
        /// Returns the ID of the server thread the connection is executing on. This property is read-only.
        /// </summary>
        [Browsable(false)]
        public int ServerThread
        {
            get
            {
                return InternalConnection.ServerThread;
            }
        }

        /// <summary>
        /// Indicates if the connection should use compression when communicating with the server. This property is read-only.
        /// </summary>
        [Browsable(false)]
        public bool UseCompression
        {
            get
            {
                return InternalConnection.UseCompression;
            }
        }

        /// <summary>
        /// Indicates whether the password associated to the connection is expired. This property is read-only.
        /// </summary>
        public bool IsPasswordExpired
        {
            get
            {
                return InternalConnection.IsPasswordExpired;
            }
        }

        /// <summary>
        /// Occurs when FIDO authentication request to perform gesture action on a device.
        /// </summary>
        public event FidoActionCallback FidoActionRequested
        {
            add
            {
                InternalConnection.FidoActionRequested += value;
            }
            remove
            {
                InternalConnection.FidoActionRequested -= value;
            }
        }

        /// <summary>
        /// Occurs when MySQL returns warnings as a result of executing a command or query.
        /// </summary>
        public event MySqlInfoMessageEventHandler InfoMessage
        {
            add
            {
                InternalConnection.InfoMessage += value;
            }
            remove
            {
                InternalConnection.InfoMessage -= value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlConnection"/> class with no arguments.
        /// </summary>
        public WhippetMySqlConnection()
            : base(new MySqlConnection())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlConnection"/> class with the specified connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used to open a connection to the MySQL database.</param>
        public WhippetMySqlConnection(string connectionString)
            : base(new MySqlConnection(connectionString))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlConnection"/> class with the specified <see cref="MySqlConnection"/>.
        /// </summary>
        /// <param name="connection"><see cref="MySqlConnection"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetMySqlConnection(MySqlConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Begins a new transaction on the current connection.
        /// </summary>
        /// <returns><see cref="WhippetMySqlTransaction"/> object.</returns>
        public new WhippetMySqlTransaction BeginTransaction()
        {
            return InternalConnection.BeginTransaction();
        }

        /// <summary>
        /// Begins a new transaction on the current connection.
        /// </summary>
        /// <param name="iso"><see cref="IsolationLevel"/> to apply to the transaction.</param>
        /// <param name="scope">Scope of the transaction.</param>
        /// <returns><see cref="WhippetMySqlTransaction"/> object.</returns>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="NotSupportedException" />
        public WhippetMySqlTransaction BeginTransaction(IsolationLevel iso, string scope = "")
        {
            return InternalConnection.BeginTransaction(iso, scope);
        }

        /// <summary>
        /// Pings the server.
        /// </summary>
        /// <returns><see langword="true"/> if the ping was successful; otherwise, <see langword="false"/>.</returns>
        public bool Ping()
        {
            return InternalConnection.Ping();
        }

        /// <summary>
        /// Creates and returns a new <see cref="WhippetMySqlCommand"/> object associated with the current <see cref="WhippetMySqlConnection"/>.
        /// </summary>
        /// <returns></returns>
        public new WhippetMySqlCommand CreateCommand()
        {
            return InternalConnection.CreateCommand();
        }

        /// <summary>
        /// Cancels the query after the specified time interval.
        /// </summary>
        /// <param name="timeout">The length of time (in seconds) to wait for the cancellation of the command execution.</param>
        public void CancelQuery(int timeout)
        {
            InternalConnection.CancelQuery(timeout);
        }

        /// <summary>
        /// Gets a schema collection based on the provided restriction values.
        /// </summary>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="restrictionValues">The values to restrict.</param>
        /// <returns><see cref="WhippetMySqlSchemaCollection"/> object.</returns>
        public WhippetMySqlSchemaCollection GetSchemaCollection(string collectionName, IEnumerable<string> restrictionValues)
        {
            return InternalConnection.GetSchemaCollection(collectionName, restrictionValues?.ToArray());
        }

        /// <summary>
        /// Empties the connection pool associated with the specified connection.
        /// </summary>
        /// <param name="connection">The <see cref="WhippetMySqlConnection"/> associated with the pool to be cleared.</param>
        public static void ClearPool(WhippetMySqlConnection connection)
        {
            MySqlConnection.ClearPool(connection);
        }

        /// <summary>
        /// Clears all connection pools.
        /// </summary>
        public static void ClearAllPools()
        {
            MySqlConnection.ClearAllPools();
        }

        /// <summary>
        /// Changes the current database.
        /// </summary>
        /// <param name="databaseName">Name of the database to switch to.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public Task ChangeDatabaseAsync(string databaseName)
        {
            return InternalConnection.ChangeDatabaseAsync(databaseName);
        }

        /// <summary>
        /// Changes the value specified in <see cref="System.Data.Common.DbConnection.Database"/> in <see cref="System.Data.Common.DbConnection.ConnectionString"/>. This method must be overridden.
        /// </summary>
        /// <param name="databaseName">Name of the database to change to in <see cref="System.Data.Common.DbConnection.ConnectionString"/>.</param>
        protected override void ChangeConnectionStringDatabase(string databaseName)
        {
            WhippetMySqlConnectionStringBuilder csBuilder = null;
            
            if (!String.IsNullOrWhiteSpace(ConnectionString))
            {
                csBuilder = new WhippetMySqlConnectionStringBuilder(ConnectionString);
                csBuilder.Database = databaseName;

                ConnectionString = csBuilder.ToString();
            }
        }

        public static implicit operator MySqlConnection(WhippetMySqlConnection connection)
        {
            return (connection == null) ? null : connection.InternalConnection;
        }

        public static implicit operator WhippetMySqlConnection(MySqlConnection connection)
        {
            return (connection == null) ? null : new WhippetMySqlConnection(connection);
        }
    }
}
