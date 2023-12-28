using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Threading;
using System.Transactions;
using System.Reflection;
using DatabaseIsolationLevel = System.Data.IsolationLevel;

namespace Athi.Whippet.Data.Database
{
    /// <summary>
    /// Base class for all database connections in Whippet. This class must be inherited.
    /// </summary>
    public abstract class WhippetDatabaseConnection : DbConnection
    {
        private string _dockerCs;
        
        /// <summary>
        /// Gets the <see cref="DbConnection.ConnectionString"/> to use for Docker containers. The connection string must contain the key &quot;docker_container=true&quot; in order to be sanitized correctly; otherwise, the original value for <see cref="DbConnection.ConnectionString"/> is used. This property is read-only. 
        /// </summary>
        /// <remarks>This property is typically used for NHibernate as it uses the original <see cref="System.Data.SqlClient"/> instead of the new version provided by Microsoft.</remarks>
        public virtual string DockerConnectionString
        {
            get
            {
                return String.IsNullOrWhiteSpace(_dockerCs) ? ConnectionString : _dockerCs;
            }
            protected set
            {
                _dockerCs = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDatabaseConnection"/> class with no arguments.
        /// </summary>
        protected WhippetDatabaseConnection()
            : base()
        { }

        /// <summary>
        /// Changes the current database for an open connection or, alternatively, the database specified in the connection string.
        /// </summary>
        /// <param name="databaseName">Name of the database to change to.</param>
        /// <param name="connectionStringOnly">If <see langword="true"/>, will change the database specified in <see cref="DbConnection.Database"/> to the value represented by <paramref name="databaseName"/> irrespective of connection state.</param>
        public virtual void ChangeDatabase(string databaseName, bool connectionStringOnly)
        {
            if (connectionStringOnly)
            {
                ChangeConnectionStringDatabase(databaseName);
            }
            else
            {
                ChangeDatabase(databaseName);
            }
        }

        /// <summary>
        /// Asynchronously changes the current database for an open connection or, alternatively, the database specified in the connection string.
        /// </summary>
        /// <param name="databaseName">Name of the database to change to.</param>
        /// <param name="connectionStringOnly">If <see langword="true"/>, will change the database specified in <see cref="DbConnection.Database"/> to the value represented by <paramref name="databaseName"/> irrespective of connection state.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public virtual async Task ChangeDatabaseAsync(string databaseName, bool connectionStringOnly, CancellationToken cancellationToken = default)
        {
            if (connectionStringOnly)
            {
                ChangeConnectionStringDatabase(databaseName);
            }
            else
            {
                await ChangeDatabaseAsync(databaseName, cancellationToken);
            }
        }

        /// <summary>
        /// Changes the value specified in <see cref="DbConnection.Database"/> in <see cref="DbConnection.ConnectionString"/>. This method must be overridden.
        /// </summary>
        /// <param name="databaseName">Name of the database to change to in <see cref="DbConnection.ConnectionString"/>.</param>
        protected abstract void ChangeConnectionStringDatabase(string databaseName);
    }

    /// <summary>
    /// Base class for <see cref="WhippetDatabaseConnection"/> objects that wrap an existing implementation. This class must be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="IDbConnection"/> class that is wrapped by the current instance.</typeparam>
    public abstract class WhippetDatabaseConnection<T> : WhippetDatabaseConnection, IDbConnection where T : IDbConnection
    {
        /// <summary>
        /// Occurs when the state of the connection changes.
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public override event StateChangeEventHandler StateChange
        {
            add
            {
                if(IsDbConnection)
                {
                    (InternalConnection as DbConnection).StateChange += value;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            remove
            {
                if (IsDbConnection)
                {
                    (InternalConnection as DbConnection).StateChange -= value;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }

        /// <summary>
        /// Gets the internal database connection. This property is read-only.
        /// </summary>
        protected T InternalConnection
        { get; private set; }

        /// <summary>
        /// Indicates whether <see cref="InternalConnection"/> is a <see cref="DbConnection"/> object. This property is read-only.
        /// </summary>
        private bool IsDbConnection
        {
            get
            {
                return InternalConnection is DbConnection;
            }
        }

        /// <summary>
        /// This is an internal API and not meant to be executed by your code. This property is read-only.
        /// </summary>
        public override bool CanCreateBatch
        {
            get
            {
                return IsDbConnection ? (InternalConnection as DbConnection).CanCreateBatch : false;
            }
        }

        /// <summary>
        /// Gets or sets the string used to open a database.
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
        /// Gets the time to wait (in seconds) while trying to establish a connection before terminating the attempt and generating an error. This property is read-only.
        /// </summary>
        public override int ConnectionTimeout
        {
            get
            {
                return InternalConnection.ConnectionTimeout;
            }
        }

        /// <summary>
        /// Gets the name of the current database or the database to be used after a connection is opened. This property is read-only.
        /// </summary>
        public override string Database
        {
            get
            {
                return InternalConnection.Database;
            }
        }

        /// <summary>
        /// Gets the name of the current database after a connection is opened, or the database name specified in the connection string before the connection is opened. This property is read-only.
        /// </summary>
        public override string DataSource
        {
            get
            {
                return IsDbConnection ? (InternalConnection as DbConnection).DataSource : String.Empty;
            }
        }

        /// <summary>
        /// Gets the current state of the connection. This property is read-only.
        /// </summary>
        public override ConnectionState State
        {
            get
            {
                return InternalConnection.State;
            }
        }

        /// <summary>
        /// Gets a string that represents the version of the server to which the object is connected. This property is read-only.
        /// </summary>
        public override string ServerVersion
        {
            get
            {
                return IsDbConnection ? (InternalConnection as DbConnection).ServerVersion : String.Empty;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDatabaseConnection{T}"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> object of type <typeparamref name="T"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetDatabaseConnection(T connection)
            : base()
        {
            if(connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            else
            {
                InternalConnection = connection;
            }
        }

        /// <summary>
        /// Changes the current database for an open connection.
        /// </summary>
        /// <param name="databaseName">The name of the database for the connection to use.</param>
        public override void ChangeDatabase(string databaseName)
        {
            InternalConnection.ChangeDatabase(databaseName);
        }

        /// <summary>
        /// Asynchronously changes the current database for an open connection.
        /// </summary>
        /// <param name="databaseName">The name of the database for the connection to use.</param>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="NotSupportedException" />
        public override Task ChangeDatabaseAsync(string databaseName, CancellationToken cancellationToken = default)
        {
            if(!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).ChangeDatabaseAsync(databaseName, cancellationToken);
            }
        }

        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public override void Close()
        {
            InternalConnection.Close();
        }

        /// <summary>
        /// Asynchronously closes the connection to the database.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public override Task CloseAsync()
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).CloseAsync();
            }
        }

        /// <summary>
        /// This is an internal API and not meant to be executed by your code.
        /// </summary>
        /// <returns><see cref="DbBatch"/> object.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public new DbBatch CreateBatch()
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).CreateBatch();
            }
        }

        /// <summary>
        /// Creates and returns a <see cref="DbCommand"/> object associated with the current connection.
        /// </summary>
        /// <returns>A <see cref="DbCommand"/> object.</returns>
        public new DbCommand CreateCommand()
        {
            IDbCommand command = ((IDbConnection)(this)).CreateCommand();
            return (command is DbCommand) ? (command as DbCommand) : null;
        }

        /// <summary>
        /// Creates and returns an <see cref="IDbCommand"/> object associated with the current connection.
        /// </summary>
        /// <returns>An <see cref="IDbCommand"/> object.</returns>
        IDbCommand IDbConnection.CreateCommand()
        {
            return InternalConnection.CreateCommand();
        }

        /// <summary>
        /// Disposes of the current connection and releases its resources from memory.
        /// </summary>
        public new void Dispose()
        {
            InternalConnection.Dispose();
        }

        /// <summary>
        /// Asynchronously disposes the connection object.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        /// <exception cref="NotSupportedException"></exception>
        public override ValueTask DisposeAsync()
        {
            if(!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).DisposeAsync();
            }
        }

        /// <summary>
        /// Enlists in the specified transaction.
        /// </summary>
        /// <param name="transaction">A reference to an existing <see cref="Transaction"/> in which to enlist.</param>
        /// <exception cref="NotSupportedException"></exception>
        public override void EnlistTransaction(Transaction transaction)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                (InternalConnection as DbConnection).EnlistTransaction(transaction);
            }
        }

        /// <summary>
        /// Returns schema information for the data source of this <see cref="WhippetDatabaseConnection{T}"/>.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> that contains schema information.</returns>
        /// <exception cref="NotSupportedException" />
        public override DataTable GetSchema()
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).GetSchema();
            }
        }

        /// <summary>
        /// Returns schema information for the data source of this <see cref="WhippetDatabaseConnection{T}"/> using the specified string for the schema name.
        /// </summary>
        /// <param name="collectionName">Specifies the name of the schema to return.</param>
        /// <returns>A <see cref="DataTable"/> that contains schema information.</returns>
        /// <exception cref="NotSupportedException" />
        public override DataTable GetSchema(string collectionName)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).GetSchema(collectionName);
            }
        }

        /// <summary>
        /// Returns schema information for the data source of this <see cref="WhippetDatabaseConnection{T}"/> using the specified string for the schema name and the specified array of strings for the restriction values.
        /// </summary>
        /// <param name="collectionName">Specifies the name of the schema to return.</param>
        /// <param name="restrictionValues">Specifies a set of restriction values for the requested schema.</param>
        /// <returns>A <see cref="DataTable"/> that contains schema information.</returns>
        /// <exception cref="NotSupportedException" />
        public override DataTable GetSchema(string collectionName, string[] restrictionValues)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).GetSchema(collectionName, restrictionValues);
            }
        }

        /// <summary>
        /// This is an asynchronous version of <see cref="GetSchema"/>. The <paramref name="cancellationToken"/> can optionally be honored. The default implementation invokes the synchronous 
        /// <see cref="GetSchema"/> call and returns a completed task. The default implementation will return a cancelled task if passed an already cancelled <paramref name="cancellationToken"/>. 
        /// Exceptions thrown by <see cref="GetSchema"/> will be communicated via the returned <see cref="Task.Exception"/> property.
        /// </summary>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="NotSupportedException" />
        public override Task<DataTable> GetSchemaAsync(CancellationToken cancellationToken = default)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).GetSchemaAsync(cancellationToken);
            }
        }

        /// <summary>
        /// This is an asynchronous version of <see cref="GetSchema(string)"/>. The <paramref name="cancellationToken"/> can optionally be honored. The default implementation invokes the synchronous 
        /// <see cref="GetSchema(string)"/> call and returns a completed task. The default implementation will return a cancelled task if passed an already cancelled <paramref name="cancellationToken"/>. 
        /// Exceptions thrown by <see cref="GetSchema(string)"/> will be communicated via the returned <see cref="Task.Exception"/> property.
        /// </summary>
        /// <param name="collectionName">Specifies the name of the schema to return.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="NotSupportedException" />
        public override Task<DataTable> GetSchemaAsync(string collectionName, CancellationToken cancellationToken = default)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).GetSchemaAsync(collectionName, cancellationToken);
            }
        }

        /// <summary>
        /// This is an asynchronous version of <see cref="GetSchema(string, string[])"/>. The <paramref name="cancellationToken"/> can optionally be honored. The default implementation invokes the synchronous 
        /// <see cref="GetSchema(string, string[])"/> call and returns a completed task. The default implementation will return a cancelled task if passed an already cancelled <paramref name="cancellationToken"/>. 
        /// Exceptions thrown by <see cref="GetSchema(string, string[])"/> will be communicated via the returned <see cref="Task.Exception"/> property.
        /// </summary>
        /// <param name="collectionName">Specifies the name of the schema to return.</param>
        /// <param name="restrictionValues">Specifies a set of restriction values for the requested schema.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="NotSupportedException" />
        public override Task<DataTable> GetSchemaAsync(string collectionName, string[] restrictionValues, CancellationToken cancellationToken = default)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).GetSchemaAsync(collectionName, restrictionValues, cancellationToken);
            }
        }

        /// <summary>
        /// Opens a database connection with the settings specified by the <see cref="ConnectionString"/>.
        /// </summary>
        public override void Open()
        {
            InternalConnection.Open();
        }

        /// <summary>
        /// An asynchronous version of <see cref="Open()"/>, which opens a database connection with the settings specified by the <see cref="ConnectionString"/> property. This method invokes the virtual method <see cref="OpenAsync(CancellationToken)"/> with <see cref="CancellationToken.None"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="NotSupportedException" />
        public new Task OpenAsync()
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).OpenAsync();
            }
        }

        /// <summary>
        /// An asynchronous version of <see cref="Open()"/>, which opens a database connection with the settings specified by the <see cref="ConnectionString"/> property. The cancellation token can be optionally honored. The default implementation invokes the synchronous 
        /// <see cref="Open()"/> call and returns a completed task. The default implementation will return a cancelled task if passed an already cancelled <paramref name="cancellationToken"/>. Exceptions thrown by <see cref="Open()"/> will 
        /// be communicated via the returned <see cref="Task.Exception"/> property. Do not invoke other methods and properties of the <see cref="WhippetDatabaseConnection{T}"/> object until the returned <see cref="Task"/> is complete.
        /// </summary>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>A task representing the asynchronous instruction.</returns>
        /// <exception cref="NotSupportedException" />
        public override Task OpenAsync(CancellationToken cancellationToken)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                return (InternalConnection as DbConnection).OpenAsync(cancellationToken);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override DbTransaction BeginDbTransaction(DatabaseIsolationLevel isolationLevel)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                DbTransaction dbTrans = null;
                MethodInfo mInfo = typeof(T).GetMethod(nameof(BeginDbTransaction), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, new[] { typeof(DatabaseIsolationLevel) });

                object[] parameters = new object[] { isolationLevel };

                if(mInfo != null)
                {
                    dbTrans = (DbTransaction)(mInfo.Invoke(InternalConnection, parameters));
                }

                return dbTrans;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        protected override ValueTask<DbTransaction> BeginDbTransactionAsync(DatabaseIsolationLevel isolationLevel, CancellationToken cancellationToken)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                ValueTask<DbTransaction> vtTrans = new ValueTask<DbTransaction>();
                MethodInfo mInfo = typeof(T).GetMethod(nameof(BeginDbTransactionAsync), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, new[] { typeof(DatabaseIsolationLevel), typeof(CancellationToken) });

                object[] parameters = new object[] { isolationLevel, cancellationToken };

                if (mInfo != null)
                {
                    vtTrans = (ValueTask<DbTransaction>)(mInfo.Invoke(InternalConnection, parameters));
                }

                return vtTrans;
            }
        }

        /// <summary>
        /// Event that is fired when the <see cref="ConnectionState"/> changes.
        /// </summary>
        /// <param name="stateChange">Event arguments that detail the state change.</param>
        /// <exception cref="NotSupportedException"></exception>
        protected override void OnStateChange(StateChangeEventArgs stateChange)
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                MethodInfo mInfo = typeof(T).GetMethod(nameof(OnStateChange), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, new[] { typeof(StateChangeEventArgs) });

                object[] parameters = new object[] { stateChange };

                if (mInfo != null)
                {
                    mInfo.Invoke(InternalConnection, parameters);
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="DbCommand"/> object.
        /// </summary>
        /// <returns><see cref="DbCommand"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override DbCommand CreateDbCommand()
        {
            if (!IsDbConnection)
            {
                throw new NotSupportedException();
            }
            else
            {
                DbCommand command = null;
                MethodInfo mInfo = typeof(T).GetMethod(nameof(CreateDbCommand), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, Type.EmptyTypes);

                if (mInfo != null)
                {
                    command = (DbCommand)(mInfo.Invoke(InternalConnection, null));
                }

                return command;
            }
        }
    }
}
