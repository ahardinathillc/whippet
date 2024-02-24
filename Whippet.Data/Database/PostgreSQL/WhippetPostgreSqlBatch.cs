using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a batch of commands which can be executed against a data source in a single round trip. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetPostgreSqlBatch : DbBatch
    {
        /// <summary>
        /// Gets or sets the internal <see cref="NpgsqlBatch"/> object.
        /// </summary>
        private NpgsqlBatch InternalBatch
        { get; set; }

        /// <summary>
        /// Gets the collection of <see cref="WhippetPostgreSqlBatchCommand"/> objects. This property is read-only.
        /// </summary>
        public new WhippetPostgreSqlBatchCommandCollection BatchCommands
        {
            get
            {
                return InternalBatch.BatchCommands;
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="DbBatchCommand"/> objects. This property is read-only.
        /// </summary>
        protected override DbBatchCommandCollection DbBatchCommands
        {
            get
            {
                return BatchCommands;
            }
        }

        /// <summary>
        /// Gets or sets the wait time (in seconds) before terminating the attempt to execute the batch and generating an error.
        /// </summary>
        public override int Timeout
        {
            get
            {
                return InternalBatch.Timeout;
            }
            set
            {
                InternalBatch.Timeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetPostgreSqlConnection"/> used by the <see cref="WhippetPostgreSqlBatch"/>.
        /// </summary>
        public new WhippetPostgreSqlConnection Connection
        {
            get
            {
                return InternalBatch.Connection;
            }
            set
            {
                InternalBatch.Connection = value;
            }
        }

        protected override DbConnection DbConnection { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="WhippetPostgreSqlTransaction"/> on which the <see cref="WhippetPostgreSqlBatch"/> executes.
        /// </summary>
        public new WhippetPostgreSqlTransaction Transaction
        {
            get
            {
                return InternalBatch.Transaction;
            }
            set
            {
                InternalBatch.Transaction = value;
            }
        }

        protected override DbTransaction DbTransaction { get; set; }

        /// <summary>
        /// Controls whether to place error barriers between all batch commands within this batch. By default, this value is <see langword="false"/>.
        /// </summary>
        public bool EnableErrorBarriers
        {
            get
            {
                return InternalBatch.EnableErrorBarriers;
            }
            set
            {
                InternalBatch.EnableErrorBarriers = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatch"/> class with no arguments.
        /// </summary>
        public WhippetPostgreSqlBatch()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatch"/> class with the specified <see cref="NpgsqlBatch"/> object.
        /// </summary>
        /// <param name="batch"><see cref="NpgsqlBatch"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlBatch(NpgsqlBatch batch)
            : this()
        {
            ArgumentNullException.ThrowIfNull(batch);
            InternalBatch = batch;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatch"/> class with the specified <see cref="WhippetPostgreSqlConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="WhippetPostgreSqlConnection"/> object.</param>
        public WhippetPostgreSqlBatch(WhippetPostgreSqlConnection connection)
            : this(new NpgsqlBatch(connection))
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatch"/> class with the specified <see cref="WhippetPostgreSqlTransaction"/> object.
        /// </summary>
        /// <param name="transaction"><see cref="WhippetPostgreSqlTransaction"/> object.</param>
        public WhippetPostgreSqlBatch(WhippetPostgreSqlTransaction transaction)
            : this(new NpgsqlBatch(null, transaction))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBatch"/> class.
        /// </summary>
        /// <param name="connection"><see cref="WhippetPostgreSqlConnection"/> object.</param>
        /// <param name="transaction"><see cref="WhippetPostgreSqlTransaction"/> object.</param>
        public WhippetPostgreSqlBatch(WhippetPostgreSqlConnection connection, WhippetPostgreSqlTransaction transaction)
            : this(new NpgsqlBatch(connection, transaction))
        { }

        /// <summary>
        /// Creates a new <see cref="WhippetPostgreSqlBatchCommand"/> object. 
        /// </summary>
        /// <returns><see cref="WhippetPostgreSqlBatchCommand"/> object.</returns>
        public new WhippetPostgreSqlBatchCommand CreateBatchCommand()
        {
            return InternalBatch.CreateBatchCommand();
        }

        /// <summary>
        /// Executes the batch against its connection, returning a <see cref="WhippetPostgreSqlDataReader"/> which can be used to access the results.
        /// </summary>
        /// <param name="behavior">One of the enumeration values that specifies options for batch execution and data retrieval.</param>
        /// <returns><see cref="WhippetPostgreSqlDataReader"/> object.</returns>
        public new WhippetPostgreSqlDataReader ExecuteReader(CommandBehavior behavior = CommandBehavior.Default)
        {
            NpgsqlDataReader reader = InternalBatch.ExecuteReader(behavior);
            return reader == null ? null : new WhippetPostgreSqlDataReader(reader);
        }

        /// <summary>
        /// Asynchronously executes the batch against its connection, returning a <see cref="WhippetPostgreSqlDataReader"/> which can be used to access the results.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns><see cref="WhippetPostgreSqlDataReader"/> object.</returns>
        public new async Task<WhippetPostgreSqlDataReader> ExecuteReaderAsync(CancellationToken cancellationToken = default)
        {
            NpgsqlDataReader reader = await InternalBatch.ExecuteReaderAsync(cancellationToken);
            return reader == null ? null : new WhippetPostgreSqlDataReader(reader);
        }
        
        /// <summary>
        /// Asynchronously executes the batch against its connection, returning a <see cref="WhippetPostgreSqlDataReader"/> which can be used to access the results.
        /// </summary>
        /// <param name="behavior">One of the enumeration values that specifies options for batch execution and data retrieval.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns><see cref="WhippetPostgreSqlDataReader"/> object.</returns>
        public new async Task<WhippetPostgreSqlDataReader> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken = default)
        {
            NpgsqlDataReader reader = await InternalBatch.ExecuteReaderAsync(behavior, cancellationToken);
            return reader == null ? null : new WhippetPostgreSqlDataReader(reader);
        }

        /// <summary>
        /// Executes the batch against its connection object, returning the total number of rows affected across all the batch commands.
        /// </summary>
        /// <returns>The total number of rows affected across all the batch commands.</returns>
        public override int ExecuteNonQuery()
        {
            return InternalBatch.ExecuteNonQuery();
        }

        /// <summary>
        /// Asynchronously executes the batch against its connection object, returning the total number of rows affected across all the batch commands.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="DbException"></exception>
        /// <exception cref="OperationCanceledException"></exception>
        public override Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken = default)
        {
            return InternalBatch.ExecuteNonQueryAsync(cancellationToken);
        }

        /// <summary>
        /// Executes the batch and returns the first column of the first row in the first returned result set. All other columns, rows, and result sets are ignored.
        /// </summary>
        /// <returns>The first column of the first row in the first result set.</returns>
        /// <exception cref="DbException"></exception>
        public override object ExecuteScalar()
        {
            return InternalBatch.ExecuteScalar();
        }

        /// <summary>
        /// Asynchronously executes the batch and returns the first column of the first row in the first returned result set. All other columns, rows, and result sets are ignored.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="DbException"></exception>
        /// <exception cref="OperationCanceledException"></exception>
        public override Task<object> ExecuteScalarAsync(CancellationToken cancellationToken = default)
        {
            return InternalBatch.ExecuteScalarAsync(cancellationToken);
        }

        /// <summary>
        /// Creates a prepared (or compiled) version of the batch, or each of its commands, on the data source.
        /// </summary>
        public override void Prepare()
        {
            InternalBatch.Prepare();
        }

        /// <summary>
        /// Asynchronously creates a prepared (or compiled) version of the batch, or each of its commands, on the data source.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="OperationCanceledException"></exception>
        public override Task PrepareAsync(CancellationToken cancellationToken = default)
        {
            return InternalBatch.PrepareAsync(cancellationToken);
        }

        /// <summary>
        /// Attempts to cancel the execution of the <see cref="WhippetPostgreSqlBatch"/>.
        /// </summary>
        public override void Cancel()
        {
            InternalBatch.Cancel();
        }

        /// <summary>
        /// Disposes of the current object and releases its resource from memory.
        /// </summary>
        public override void Dispose()
        {
            InternalBatch.Dispose();
        }

        /// <summary>
        /// Asynchronously disposes of the current object and releases its resource from memory.
        /// </summary>
        /// <returns><see cref="ValueTask"/> struct.</returns>
        public override ValueTask DisposeAsync()
        {
            return InternalBatch.DisposeAsync();
        }

        /// <summary>
        /// Executes the batch against its connection, returning a <see cref="DbDataReader"/> which can be used to access the results.
        /// </summary>
        /// <param name="behavior">One of the enumeration values that specifies options for batch execution and data retrieval.</param>
        /// <returns><see cref="DbDataReader"/> object.</returns>
        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            return ExecuteReader(behavior);
        }
        
        /// <summary>
        /// Asynchronously executes the batch against its connection, returning a <see cref="DbDataReader"/> which can be used to access the results.
        /// </summary>
        /// <param name="behavior">One of the enumeration values that specifies options for batch execution and data retrieval.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns><see cref="DbDataReader"/> object.</returns>
        protected override async Task<DbDataReader> ExecuteDbDataReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken = default)
        {
            return await ExecuteReaderAsync(behavior, cancellationToken);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="DbBatchCommand"/> object.
        /// </summary>
        /// <returns>A <see cref="DbBatchCommand"/> object.</returns>
        protected override DbBatchCommand CreateDbBatchCommand()
        {
            return CreateBatchCommand();
        }

        public static implicit operator NpgsqlBatch(WhippetPostgreSqlBatch batch)
        {
            return (batch == null) ? null : batch.InternalBatch;
        }

        public static implicit operator WhippetPostgreSqlBatch(NpgsqlBatch batch)
        {
            return (batch == null) ? null : new WhippetPostgreSqlBatch(batch);
        }
    }
}
