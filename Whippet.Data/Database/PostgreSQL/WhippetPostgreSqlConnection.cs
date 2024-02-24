using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Net.Security;
using System.Transactions;
using Npgsql;
using IsolationLevel = System.Data.IsolationLevel;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a connection to a PostgreSQL database. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetPostgreSqlConnection : WhippetDatabaseConnection<NpgsqlConnection>, ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// This event is unsupported by <see cref="WhippetPostgreSqlConnection"/>. Use <see cref="DbConnection.StateChange"/> instead.
        /// </summary>
        public new event EventHandler Disposed
        {
            add
            {
                InternalConnection.Disposed += value;
            }
            remove
            {
                InternalConnection.Disposed -= value;
            }
        }
        
        /// <summary>
        /// Fires when PostgreSQL notices are received from PostgreSQL.
        /// </summary>
        public event NoticeEventHandler Notice
        {
            add
            {
                InternalConnection.Notice += value;
            }
            remove
            {
                InternalConnection.Notice -= value;
            }
        }

        /// <summary>
        /// Fires when PostgreSQL notifications are received from PostgreSQL.
        /// </summary>
        public event NotificationEventHandler Notification
        {
            add
            {
                InternalConnection.Notification += value;
            }
            remove
            {
                InternalConnection.Notification -= value;
            }
        }

        /// <summary>
        /// Selects the local Secure Sockets Layer (SSL) certificate used for authentication.
        /// </summary>
        public ProvideClientCertificatesCallback ProvideClientCertificatesCallback
        {
            get
            {
                return InternalConnection.ProvideClientCertificatesCallback;
            }
            set
            {
                InternalConnection.ProvideClientCertificatesCallback = value;
            }
        }

        /// <summary>
        /// When using SSL/TLS, this is a callback that allows customizing how the PostgreSQL-provided certificate is verified. This is an advanced API; consider using <see cref="SslMode.VerifyFull"/> or <see cref="SslMode.VerifyCA"/> instead.
        /// </summary>
        public RemoteCertificateValidationCallback UserCertificateValidationCallback
        {
            get
            {
                return InternalConnection.UserCertificateValidationCallback;
            }
            set
            {
                InternalConnection.UserCertificateValidationCallback = value;
            }
        }

        /// <summary>
        /// Gets the version of the PostgreSQL server currently connected to. This property is read-only.
        /// </summary>
        [Browsable(false)]
        public Version PostgreSqlVersion
        {
            get
            {
                return InternalConnection.PostgreSqlVersion;
            }
        }
        
        /// <summary>
        /// The name of the current database or the name of the database to be used after a connection is opened. This property is read-only.
        /// </summary>
        public override string Database
        {
            get
            {
                return InternalConnection.Database;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ISite"/> of the component.
        /// </summary>
        public override ISite Site
        {
            get
            {
                return InternalConnection.Site;
            }
            set
            {
                InternalConnection.Site = value;
            }
        }

        /// <summary>
        /// Indicates the current connection state of the current instance. This property is read-only.
        /// </summary>
        public override ConnectionState State
        {
            get
            {
                return InternalConnection.State;
            }
        }

        /// <summary>
        /// Gets or sets the connection string to the data source.
        /// </summary>
        public override string ConnectionString
        {
            get
            {
                return InternalConnection.ConnectionString;
            }
            set
            {
                InternalConnection.ConnectionString = value;
            }
        }

        /// <summary>
        /// Gets the time (in seconds) to wait while trying to establish a connection before terminating the attempt and generating an error. This property is read-only.
        /// </summary>
        public override int ConnectionTimeout
        {
            get
            {
                return InternalConnection.ConnectionTimeout;
            }
        }

        /// <summary>
        /// Gets the string identifying the database server. This property is read-only.
        /// </summary>
        public override string DataSource
        {
            get
            {
                return InternalConnection.DataSource;
            }
        }

        /// <summary>
        /// The PostgreSQL server version as returned by the <b>server_version</b> option. This property is read-only.
        /// </summary>
        public override string ServerVersion
        {
            get
            {
                return InternalConnection.ServerVersion;
            }
        }

        /// <summary>
        /// Gets the backend server host name. This property is read-only.
        /// </summary>
        [Browsable(true)]
        public string Host
        {
            get
            {
                return InternalConnection.Host;
            }
        }

        /// <summary>
        /// Gets the backend server port. This property is read-only.
        /// </summary>
        [Browsable(true)]
        public int Port
        {
            get
            {
                return InternalConnection.Port;
            }
        }

        /// <summary>
        /// Gets the time (in seconds) to wait while trying to execute a command before terminating the attempt and generating an error. This property is read-only.
        /// </summary>
        public int CommandTimeout
        {
            get
            {
                return InternalConnection.CommandTimeout;
            }
        }

        /// <summary>
        /// Gets the user name of the current session. This property is read-only.
        /// </summary>
        public string Username
        {
            get
            {
                return InternalConnection.UserName;
            }
        }

        /// <summary>
        /// Gets the current state of the connection. This property is read-only.
        /// </summary>
        [Browsable(false)]
        public ConnectionState FullState
        {
            get
            {
                return InternalConnection.FullState;
            }
        }

        /// <summary>
        /// Indicates whether this <see cref="WhippetPostgreSqlCommand"/> instance supports the <see cref="WhippetPostgreSqlBatch"/> class. This property is read-only.
        /// </summary>
        public override bool CanCreateBatch
        {
            get
            {
                return InternalConnection.CanCreateBatch;
            }
        }

        /// <summary>
        /// Gets the process ID of the backend server. This property is read-only.
        /// </summary>
        public int ProcessID
        {
            get
            {
                return InternalConnection.ProcessID;
            }
        }

        /// <summary>
        /// Reports whether the backend uses the newer integer timestamp representation. This property is read-only.
        /// </summary>
        [Browsable(false)]
        public bool HasIntegerDateTimes
        {
            get
            {
                return InternalConnection.HasIntegerDateTimes;
            }
        }

        /// <summary>
        /// Gets the connection's timezone as reported by PostgreSQL, in the IANA/Olson database format. This property is read-only.
        /// </summary>
        [Browsable(false)]
        public string Timezone
        {
            get
            {
                return InternalConnection.Timezone;
            }
        }

        /// <summary>
        /// Holds all PostgreSQL parameters received for this connection. This property is read-only.
        /// </summary>
        public IReadOnlyDictionary<string, string> PostgresParameters
        {
            get
            {
                return InternalConnection.PostgresParameters;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlConnection"/> class with no arguments.
        /// </summary>
        public WhippetPostgreSqlConnection()
            : base(new NpgsqlConnection())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlConnection"/> class with the specified connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used to open a connection to the MySQL database.</param>
        public WhippetPostgreSqlConnection(string connectionString)
            : base(new NpgsqlConnection(connectionString))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlConnection"/> class with the specified <see cref="MySqlConnection"/>.
        /// </summary>
        /// <param name="connection"><see cref="WhippetPostgreSqlConnection"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetPostgreSqlConnection(NpgsqlConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Creates and returns a <see cref="WhippetPostgreSqlCommand"/> object associated with the <see cref="WhippetPostgreSqlConnection"/>.
        /// </summary>
        /// <returns><see cref="WhippetPostgreSqlCommand"/> object.</returns>
        public new WhippetPostgreSqlCommand CreateCommand()
        {
            return new WhippetPostgreSqlCommand(InternalConnection.CreateCommand());
        }

        /// <summary>
        /// Returns a new instance of the provider's class that implements the <see cref="WhippetPostgreSqlBatch"/> class.
        /// </summary>
        /// <returns>A new instance of <see cref="WhippetPostgreSqlBatch"/>.</returns>
        public new WhippetPostgreSqlBatch CreateBatch()
        {
            return InternalConnection.CreateBatch();
        }

        /// <summary>
        /// Begins a database transaction.
        /// </summary>
        /// <returns>A <see cref="WhippetPostgreSqlTransaction"/> object representing a new transaction.</returns>
        public new WhippetPostgreSqlTransaction BeginTransaction()
        {
            return InternalConnection.BeginTransaction();
        }
        
        /// <summary>
        /// Begins a database transaction.
        /// </summary>
        /// <param name="level">The isolation level under which the transaction should run.</param>
        /// <returns>A <see cref="WhippetPostgreSqlTransaction"/> object representing a new transaction.</returns>
        public new WhippetPostgreSqlTransaction BeginTransaction(IsolationLevel level)
        {
            return InternalConnection.BeginTransaction(level);
        }

        /// <summary>
        /// Asynchronously begins a database transaction.
        /// </summary>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns><see cref="ValueTask{TResult}"/> containing the created <see cref="WhippetPostgreSqlTransaction"/> object.</returns>
        public new async ValueTask<WhippetPostgreSqlTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            NpgsqlTransaction trans = await InternalConnection.BeginTransactionAsync(cancellationToken);
            return trans;
        }

        /// <summary>
        /// Asynchronously begins a database transaction.
        /// </summary>
        /// <param name="level">The isolation level under which the transaction should run.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns><see cref="ValueTask{TResult}"/> containing the created <see cref="WhippetPostgreSqlTransaction"/> object.</returns>
        public new async ValueTask<WhippetPostgreSqlTransaction> BeginTransactionAsync(IsolationLevel level, CancellationToken cancellationToken = default)
        {
            NpgsqlTransaction trans = await InternalConnection.BeginTransactionAsync(level, cancellationToken);
            return trans;
        }

        /// <summary>
        /// Enlists in the specified transaction. 
        /// </summary>
        /// <param name="transaction">Transaction to enlist.</param>
        public override void EnlistTransaction(Transaction transaction)
        {
            InternalConnection.EnlistTransaction(transaction);
        }

        /// <summary>
        /// Releases the connection. If the connection is pooled, it will be returned to the pool and made available for re-use. If it is non-pooled, the physical connection will be closed.
        /// </summary>
        public override void Close()
        {
            InternalConnection.Close();
        }

        /// <summary>
        /// Asynchronously releases the connection. If the connection is pooled, it will be returned to the pool and made available for re-use. If it is non-pooled, the physical connection will be closed.
        /// </summary>
        /// <returns><see cref="Task"/> object.</returns>
        public override Task CloseAsync()
        {
            return InternalConnection.CloseAsync();
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public new void Dispose()
        {
            InternalConnection.Dispose();
        }
        
        /// <summary>
        /// Asynchronously disposes of the current object and releases its resources from memory.
        /// </summary>
        /// <returns><see cref="ValueTask"/> object.</returns>
        public override ValueTask DisposeAsync()
        {
            return InternalConnection.DisposeAsync();
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            return ((ICloneable)(InternalConnection)).Clone();
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the specified connection string.
        /// </summary>
        /// <param name="connectionString">Connection string to apply to the new instance.</param>
        /// <returns><see cref="WhippetPostgreSqlConnection"/> object.</returns>
        public WhippetPostgreSqlConnection Clone(string connectionString)
        {
            return InternalConnection.CloneWith(connectionString);
        }
        
        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return.</typeparam>
        /// <returns>Duplicate instance of the current object.</returns>
        TObject IWhippetCloneable.Clone<TObject>(Guid? createdBy)
        {
            return (TObject)(((ICloneable)(this)).Clone());
        }

        /// <summary>
        /// Changes the current database by disconnecting from the actual database and connecting to the specified.
        /// </summary>
        /// <param name="databaseName">The name of the database to use in place of the current database.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override void ChangeDatabase(string databaseName)
        {
            InternalConnection.ChangeDatabase(databaseName);
        }

        /// <summary>
        /// Begins a binary <b>COPY FROM STDIN</b> operation, a high-performance data import mechanism to a PostgreSQL table.
        /// </summary>
        /// <param name="copyFromCommand">A <b>COPY FROM STDIN</b> database command.</param>
        /// <returns><see cref="WhippetPostgreSqlBinaryImporter"/> object which can be used to write rows and columns.</returns>
        public WhippetPostgreSqlBinaryImporter BeginBinaryImport(string copyFromCommand)
        {
            return InternalConnection.BeginBinaryImport(copyFromCommand);
        }

        /// <summary>
        /// Begins an asynchronous binary <b>COPY FROM STDIN</b> operation, a high-performance data import mechanism to a PostgreSQL table.
        /// </summary>
        /// <param name="copyFromCommand">A <b>COPY FROM STDIN</b> database command.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns><see cref="Task{TResult}"/> object.</returns>
        public async Task<WhippetPostgreSqlBinaryImporter> BeginBinaryImportAsync(string copyFromCommand, CancellationToken cancellationToken = default)
        {
            return await InternalConnection.BeginBinaryImportAsync(copyFromCommand, cancellationToken);
        }
        
        
    }
}
