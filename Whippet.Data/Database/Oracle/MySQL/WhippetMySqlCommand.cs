﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Athi.Whippet.Extensions;
using Microsoft.Data.SqlClient;
using Athi.Whippet.Data.Database.Microsoft;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Represents a SQL statement to execute against a MySQL database. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMySqlCommand : DbCommand, ICloneable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="MySqlCommand"/> object.
        /// </summary>
        private MySqlCommand InternalCommand
        { get; set; }

        /// <summary>
        /// Occurs when the component is disposed by a call to the <see cref="Dispose"/> method.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public new event EventHandler Disposed
        {
            add
            {
                InternalCommand.Disposed += value;
            }
            remove
            {
                InternalCommand.Disposed -= value;
            }
        }

        /// <summary>
        /// Provides the ID of the last inserted row or -1 if none exists. This property is read-only.
        /// </summary>
        [Browsable(false)]
        public long LastInsertedID
        {
            get
            {
                return InternalCommand.LastInsertedId;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="Prepare"/> method has been invoked. This property is read-only.
        /// </summary>
        public bool IsPrepared
        {
            get
            {
                return InternalCommand.IsPrepared;
            }
        }

        /// <summary>
        /// Specifies the <see cref="ISite"/> of the <see cref="Component"/>.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ISite Site
        {
            get
            {
                return InternalCommand.Site;
            }
            set
            {
                InternalCommand.Site = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="IContainer"/> that contains the <see cref="Component"/>. This property is read-only.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new IContainer Container
        {
            get
            {
                return InternalCommand.Container;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="Component"/> is currently in design mode. This property is read-only.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private new bool DesignMode
        {
            get
            {
                IEnumerable<PropertyInfo> props = InternalCommand.GetType().GetNonPublicProperties();
                PropertyInfo designMode = props.Where(p => String.Equals(p.Name, nameof(DesignMode), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                bool dm = false;

                if (designMode != null)
                {
                    dm = Convert.ToBoolean(designMode.GetValue(InternalCommand));
                }

                return dm;
            }
        }

        /// <summary>
        /// Gets the list of event handlers that are attached to the current <see cref="Component"/>. This property is read-only.
        /// </summary>
        private new EventHandlerList Events
        {
            get
            {
                IEnumerable<PropertyInfo> props = InternalCommand.GetType().GetNonPublicProperties();
                PropertyInfo events = props.Where(p => String.Equals(p.Name, nameof(Events), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                EventHandlerList eventList = null;

                if (events != null)
                {
                    eventList = events.GetValue(InternalCommand) as EventHandlerList;
                }

                return eventList;
            }
        }

        /// <summary>
        /// Gets or sets the Transact-SQL statement, table name or stored procedure to execute
        /// </summary>
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.All)]
        public override string CommandText
        {
            get
            {
                return InternalCommand.CommandText;
            }
            set
            {
                InternalCommand.CommandText = value;
            }
        }

        /// <summary>
        /// Gets or sets the wait time (in seconds) before terminating the attempt to execute a command and generating an error. The default is 30 seconds.
        /// </summary>
        /// <exception cref="ArgumentException" />
        public override int CommandTimeout
        {
            get
            {
                return InternalCommand.CommandTimeout;
            }
            set
            {
                InternalCommand.CommandTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating how the <see cref="CommandText"/> property is to be interpreted.
        /// </summary>
        [DefaultValue(1)]
        [RefreshProperties(RefreshProperties.All)]
        public override CommandType CommandType
        {
            get
            {
                return InternalCommand.CommandType;
            }
            set
            {
                InternalCommand.CommandType = value;
            }
        }


        /// <summary>
        /// Gets or sets the <see cref="WhippetMySqlConnection"/> used by this instance of the <see cref="WhippetMySqlCommand"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        [DefaultValue(null)]
        public new WhippetMySqlConnection Connection
        {
            get
            {
                return InternalCommand.Connection;
            }
            set
            {
                InternalCommand.Connection = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetMySqlConnection"/> used by this instance of the <see cref="WhippetMySqlCommand"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        protected override DbConnection DbConnection
        {
            get
            {
                return Connection;
            }
            set
            {
                InternalCommand.Connection = value as MySqlConnection;
            }
        }

        /// <summary>
        /// Gets the collection of all <see cref="DbParameter"/> objects currently assigned to the <see cref="WhippetMySqlCommand"/>. This property is read-only.
        /// </summary>
        protected override DbParameterCollection DbParameterCollection
        {
            get
            {
                return InternalCommand.Parameters;
            }
        }

        /// <summary>
        /// Indicates whether the component can raise an event. This property is read-only.
        /// </summary>
        protected override bool CanRaiseEvents
        {
            get
            {
                IEnumerable<PropertyInfo> props = InternalCommand.GetType().GetNonPublicProperties();
                PropertyInfo raiseEvents = props.Where(p => String.Equals(p.Name, nameof(CanRaiseEvents), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                bool re = false;

                if (raiseEvents != null)
                {
                    re = Convert.ToBoolean(raiseEvents.GetValue(InternalCommand));
                }

                return re;
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="System.Data.Common.DbTransaction"/> instance.
        /// </summary>
        protected override DbTransaction DbTransaction
        {
            get
            {
                IEnumerable<PropertyInfo> props = InternalCommand.GetType().GetNonPublicProperties();
                PropertyInfo dbTransaction = props.Where(p => String.Equals(p.Name, nameof(DbTransaction), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                DbTransaction trans = null;

                if (dbTransaction != null)
                {
                    trans = dbTransaction.GetValue(InternalCommand) as DbTransaction;
                }

                return trans;
            }
            set
            {
                IEnumerable<PropertyInfo> props = InternalCommand.GetType().GetNonPublicProperties();
                PropertyInfo dbTransaction = props.Where(p => String.Equals(p.Name, nameof(DbTransaction), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (dbTransaction != null)
                {
                    dbTransaction.SetValue(InternalCommand, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the command object should be visible in a Windows Form Designer control.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(true)]
        [DesignOnly(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool DesignTimeVisible
        {
            get
            {
                return InternalCommand.DesignTimeVisible;
            }
            set
            {
                InternalCommand.DesignTimeVisible = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetMySqlParameterCollection"/> associated with the current command. This property is read-only.
        /// </summary>
        public new WhippetMySqlParameterCollection Parameters
        {
            get
            {
                return InternalCommand.Parameters;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetMySqlTransaction"/> within which the <see cref="WhippetMySqlCommand"/> executes.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new WhippetMySqlTransaction Transaction
        {
            get
            {
                return InternalCommand.Transaction;
            }
            set
            {
                InternalCommand.Transaction = value;
            }
        }

        /// <summary>
        /// Gets or sets how command results are applied to the <see cref="DataRow"/> when used by the <see cref="DbDataAdapter.Update(DataSet)"/> method of the <see cref="DbDataAdapter"/>.
        /// </summary>
        [DefaultValue(3)]
        public override UpdateRowSource UpdatedRowSource
        {
            get
            {
                return InternalCommand.UpdatedRowSource;
            }
            set
            {
                InternalCommand.UpdatedRowSource = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetMySqlAttributeCollection"/> which contains the query attributes defined for the statement. This property is read-only.
        /// </summary>
        public WhippetMySqlAttributeCollection Attributes
        {
            get
            {
                return InternalCommand.Attributes;
            }
        }

        /// <summary>
        /// Specifies whether caching is enabled.
        /// </summary>
        public bool EnableCaching
        {
            get
            {
                return InternalCommand.EnableCaching;
            }
            set
            {
                InternalCommand.EnableCaching = value;
            }
        }

        /// <summary>
        /// Specifies the amount of seconds that a TableDirect result should be cached.
        /// </summary>
        public int CacheAge
        {
            get
            {
                return InternalCommand.CacheAge;
            }
            set
            {
                InternalCommand.CacheAge = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlCommand"/> class with no arguments.
        /// </summary>
        public WhippetMySqlCommand()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlCommand"/> class with the specified <see cref="MySqlCommand"/> object.
        /// </summary>
        /// <param name="command"><see cref="MySqlCommand"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetMySqlCommand(MySqlCommand command)
            : base()
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            else
            {
                InternalCommand = command;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlCommand"/> class with the text of the query.
        /// </summary>
        /// <param name="commandText">The text of the query.</param>
        public WhippetMySqlCommand(string commandText)
            : this(new MySqlCommand(commandText))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlCommand"/> class with the text of the query.
        /// </summary>
        /// <param name="commandText">The text of the query.</param>
        /// <param name="connection">A <see cref="WhippetMySqlConnection"/> that represents the connection to an instance of SQL Server.</param>
        public WhippetMySqlCommand(string commandText, WhippetMySqlConnection connection)
            : this(new MySqlCommand(commandText, connection))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlCommand"/> class with the text of the query.
        /// </summary>
        /// <param name="commandText">The text of the query.</param>
        /// <param name="connection">A <see cref="WhippetMySqlConnection"/> that represents the connection to an instance of SQL Server.</param>
        /// <param name="transaction">The <see cref="WhippetMySqlTransaction"/> in which the <see cref="WhippetMySqlCommand"/> executes.</param>
        public WhippetMySqlCommand(string commandText, WhippetMySqlConnection connection, WhippetMySqlTransaction transaction)
            : this(new MySqlCommand(commandText, connection, transaction))
        { }

        /// <summary>
        /// Initiates the asynchronous execution of the Transact-SQL statement or stored procedure that is described by this <see cref="WhippetMySqlCommand"/>.
        /// </summary>
        /// <returns>An <see cref="IAsyncResult"/> object that can be used to poll or wait for results, or both. This value is also needed when invoking <see cref="EndExecuteNonQuery(IAsyncResult)"/>.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="IOException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="ObjectDisposedException" />
        public IAsyncResult BeginExecuteNonQuery()
        {
            return InternalCommand.BeginExecuteNonQuery();
        }

        /// <summary>
        /// Initiates the asynchronous execution of the Transact-SQL statement or stored procedure that is described by this <see cref="WhippetMySqlCommand"/>.
        /// </summary>
        /// <param name="callback">An <see cref="AsyncCallback"/> delegate that is invoked when the command's execution has completed or <see langword="null"/> to indicate that no callback is required.</param>
        /// <param name="stateObject">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback procedure using the <see cref="IAsyncResult.AsyncState"/> property.</param>
        /// <returns>An <see cref="IAsyncResult"/> object that can be used to poll or wait for results, or both. This value is also needed when invoking <see cref="EndExecuteNonQuery(IAsyncResult)"/>.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IOException" />
        /// <exception cref="ObjectDisposedException" />
        public IAsyncResult BeginExecuteNonQuery(AsyncCallback callback, object stateObject)
        {
            return InternalCommand.BeginExecuteNonQuery(callback, stateObject);
        }

        /// <summary>
        /// Initiates the asynchronous execution of the Transact-SQL statement or stored procedure that is described by this <see cref="WhippetMySqlCommand"/> and retrieves one or more result sets from the server.
        /// </summary>
        /// <returns>An <see cref="IAsyncResult"/> object that can be used to poll or wait for results, or both. This value is also needed when invoking <see cref="EndExecuteReader(IAsyncResult)"/> which returns a <see cref="WhippetMySqlDataReader"/> instance that can be used to retrieve the returned rows.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IOException" />
        /// <exception cref="ObjectDisposedException" />
        public IAsyncResult BeginExecuteReader()
        {
            return InternalCommand.BeginExecuteReader();
        }

        /// <summary>
        /// Initiates the asynchronous execution of the Transact-SQL statement or stored procedure that is described by this <see cref="WhippetMySqlCommand"/> and retrieves one or more result sets from the server.
        /// </summary>
        /// <param name="behavior">Indicates the options for statement execution and data retrieval.</param>
        /// <returns>An <see cref="IAsyncResult"/> object that can be used to poll or wait for results, or both. This value is also needed when invoking <see cref="EndExecuteReader(IAsyncResult)"/> which returns a <see cref="WhippetMySqlDataReader"/> instance that can be used to retrieve the returned rows.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IOException" />
        /// <exception cref="ObjectDisposedException" />
        public IAsyncResult BeginExecuteReader(CommandBehavior behavior)
        {
            return InternalCommand.BeginExecuteReader(behavior);
        }

        /// <summary>
        /// Attempts to cancel the execution of the <see cref="WhippetMySqlCommand"/>.
        /// </summary>
        public override void Cancel()
        {
            InternalCommand.Cancel();
        }

        /// <summary>
        /// Creates a new <see cref="WhippetMySqlCommand"/> object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new <see cref="WhippetMySqlCommand"/> object that is a copy of this instance.</returns>
        object ICloneable.Clone()
        {
            return InternalCommand.Clone();
        }

        /// <summary>
        /// Creates a new database parameter.
        /// </summary>
        /// <returns><see cref="DbParameter"/> object.</returns>
        protected override DbParameter CreateDbParameter()
        {
            return CreateParameter();
        }

        /// <summary>
        /// Creates a new instance of a <see cref="WhippetMySqlParameter"/> object.
        /// </summary>
        /// <returns><see cref="WhippetMySqlParameter"/></returns>
        public new WhippetMySqlParameter CreateParameter()
        {
            return InternalCommand.CreateParameter();
        }

        /// <summary>
        /// Finishes asynchronous execution of a Transact-SQL statement.
        /// </summary>
        /// <param name="asyncResult">The <see cref="IAsyncResult"/> object returned by the call to <see cref="BeginExecuteNonQuery"/></param>.
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="SqlException" />
        public int EndExecuteNonQuery(IAsyncResult asyncResult)
        {
            return InternalCommand.EndExecuteNonQuery(asyncResult);
        }

        /// <summary>
        /// Finishes asynchronous execution of a SQL statement and returns the requested <see cref="WhippetMySqlDataReader"/>.
        /// </summary>
        /// <param name="result">The <see cref="IAsyncResult"/> returned by the call to <see cref="BeginExecuteReader"/>.</param>
        /// <returns>A <see cref="WhippetMySqlDataReader"/> object that can be used to retrieve the requested rows.</returns>
        public WhippetMySqlDataReader EndExecuteReader(IAsyncResult result)
        {
            return InternalCommand.EndExecuteReader(result);
        }

        /// <summary>
        /// Sends the <see cref="CommandText"/> to the <see cref="Connection"/> and builds a <see cref="WhippetMySqlDataReader"/>.
        /// </summary>
        /// <returns><see cref="WhippetMySqlDataReader"/> object.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IOException" />
        /// <exception cref="ObjectDisposedException" />
        public new WhippetMySqlDataReader ExecuteReader()
        {
            return InternalCommand.ExecuteReader();
        }

        /// <summary>
        /// Sends the <see cref="CommandText"/> to the <see cref="Connection"/> and builds a <see cref="WhippetMySqlDataReader"/>.
        /// </summary>
        /// <param name="behavior">A <see cref="CommandBehavior"/> value.</param>
        /// <returns><see cref="WhippetMySqlDataReader"/> object.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IOException" />
        /// <exception cref="ObjectDisposedException" />
        public new WhippetMySqlDataReader ExecuteReader(CommandBehavior behavior)
        {
            return InternalCommand.ExecuteReader(behavior);
        }

        /// <summary>
        /// Sends the <see cref="CommandText"/> to the <see cref="Connection"/> and builds a <see cref="WhippetMySqlDataReader"/>.
        /// </summary>
        /// <param name="behavior">A <see cref="CommandBehavior"/> value.</param>
        /// <returns><see cref="WhippetMySqlDataReader"/> object.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IOException" />
        /// <exception cref="ObjectDisposedException" />
        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            return ExecuteReader(behavior);
        }

        /// <summary>
        /// Sends the <see cref="CommandText"/> to the <see cref="Connection"/> and builds a <see cref="WhippetMySqlDataReader"/>.
        /// </summary>
        /// <param name="behavior">A <see cref="CommandBehavior"/> value.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IOException" />
        /// <exception cref="ObjectDisposedException" />
        protected override async Task<DbDataReader> ExecuteDbDataReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken)
        {
            return await ExecuteReaderAsync(behavior, cancellationToken);
        }

        /// <summary>
        /// Executes the query and returns the first column of the first row in the result set returned.
        /// </summary>
        /// <returns>First column of the first row returned in the result set.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IOException" />
        /// <exception cref="ObjectDisposedException" />
        public override object ExecuteScalar()
        {
            return InternalCommand.ExecuteScalar();
        }

        /// <summary>
        /// Executes the query and returns the first column of the first row in the result set returned.
        /// </summary>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>First column of the first row returned in the result set.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IOException" />
        /// <exception cref="ObjectDisposedException" />
        public override Task<object> ExecuteScalarAsync(CancellationToken cancellationToken)
        {
            return InternalCommand.ExecuteScalarAsync(cancellationToken);
        }

        /// <summary>
        /// Creates a prepared version of the command on an instance of SQL Server.
        /// </summary>
        public override void Prepare()
        {
            InternalCommand.Prepare();
        }

        /// <summary>
        /// Creates a prepared version of the command on an instance of SQL Server.
        /// </summary>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override Task PrepareAsync(CancellationToken cancellationToken = default)
        {
            return InternalCommand.PrepareAsync(cancellationToken);
        }

        /// <summary>
        /// Disposes of the object and releases its resources from memory.
        /// </summary>
        /// <returns><see cref="ValueTask"/></returns>
        public override ValueTask DisposeAsync()
        {
            return InternalCommand.DisposeAsync();
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public new void Dispose()
        {
            InternalCommand.Dispose();
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> if the current object is being disposed.</param>
        protected override void Dispose(bool disposing)
        {
            MethodInfo method = InternalCommand.GetType().GetMethod(nameof(Dispose), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(bool) }, null);

            if (method != null)
            {
                method.Invoke(InternalCommand, new object[] { disposing });
            }
        }

        /// <summary>
        /// Returns an object that represents a service provided by the <see cref="Component"/> or by its <see cref="Container"/>.
        /// </summary>
        /// <param name="service">A service provided by the <see cref="Component"/>.</param>
        /// <returns>An <see cref="Object"/> that represents a service provided by the <see cref="Component"/> or <see langword="null"/> if the <see cref="Component"/> does not provide the specified service.</returns>
        protected override object GetService(Type service)
        {
            MethodInfo method = InternalCommand.GetType().GetMethod(nameof(GetService), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(Type) }, null);
            object serviceObj = null;

            if (method != null)
            {
                serviceObj = method.Invoke(InternalCommand, new object[] { service });
            }

            return serviceObj;
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="IOException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="ObjectDisposedException" />
        public override int ExecuteNonQuery()
        {
            return InternalCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        /// </summary>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="IOException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="ObjectDisposedException" />
        public override Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken)
        {
            return InternalCommand.ExecuteNonQueryAsync(cancellationToken);
        }

        /// <summary>
        /// Returns a <see cref="String"/> containing the name of the <see cref="Component"/> (if any).
        /// </summary>
        /// <returns>A <see cref="String"/> containing the name of the <see cref="Component"/> (if any) or <see langword="null"/> if the <see cref="Component"/> is unnamed.</returns>
        public override string ToString()
        {
            return InternalCommand.ToString();
        }

        /// <summary>
        /// Creates a shallow copy of the current <see cref="MarshalByRefObject"/>.
        /// </summary>
        /// <param name="cloneIdentity">If <see langword="false"/>, the current <see cref="MarshalByRefObject"/> object's identity will be deleted, which will cause the object to be assigned a new identity when it is marshaled across a remoting boundary. If <see langword="true"/>, the object's current identity is copied to its clone, which will cause remoting client calls to be routed to the remote server object.</param>
        /// <returns>A shallow copy of the current <see cref="MarshalByRefObject"/> object.</returns>
        private new MarshalByRefObject MemberwiseClone(bool cloneIdentity)
        {
            MethodInfo method = InternalCommand.GetType().GetMethod(nameof(MemberwiseClone), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(bool) }, null);
            MarshalByRefObject refObj = null;

            if (method != null)
            {
                refObj = method.Invoke(InternalCommand, new object[] { cloneIdentity }) as MarshalByRefObject;
            }

            return refObj;
        }

        /// <summary>
        /// Executes the Transact-SQL script stored in <see cref="CommandText"/> against the current <see cref="Connection"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidCastException" />
        /// <exception cref="SqlException" />
        /// <exception cref="IOException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="ObjectDisposedException" />
        public void ExecuteSqlScript()
        {
            if (String.IsNullOrWhiteSpace(CommandText))
            {
                throw new ArgumentNullException(nameof(CommandText));
            }
            else
            {
                IEnumerable<string> commandStrings = Regex.Split(CommandText, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                CommandType = CommandType.Text;

                foreach (string commandString in commandStrings)
                {
                    if (!String.IsNullOrWhiteSpace(commandString))
                    {
                        CommandText = commandString;
                        ExecuteNonQuery();
                    }
                }
            }
        }

        public static implicit operator WhippetMySqlCommand(MySqlCommand command)
        {
            return (command == null) ? null : new WhippetMySqlCommand(command);
        }

        public static implicit operator MySqlCommand(WhippetMySqlCommand command)
        {
            return (command == null) ? null : command.InternalCommand;
        }
    }
}