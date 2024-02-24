using System;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Provides an API for a binary <b>COPY FROM</b> operation, a high-performance data import mechanism to a PostgreSQL table. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetPostgreSqlBinaryImporter : IDisposable, IAsyncDisposable
    {
        private TimeSpan _timeout;
        
        /// <summary>
        /// Gets or sets the internal <see cref="NpgsqlBinaryImporter"/> object.
        /// </summary>
        private NpgsqlBinaryImporter InternalImporter
        { get; set; }

        /// <summary>
        /// Gets or sets the current timeout.
        /// </summary>
        public TimeSpan Timeout
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value;
                InternalImporter.Timeout = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBinaryImporter"/> class with no arguments.
        /// </summary>
        private WhippetPostgreSqlBinaryImporter()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlBinaryImporter"/> class with the specified <see cref="NpgsqlBinaryImporter"/> object.
        /// </summary>
        /// <param name="importer"><see cref="NpgsqlBinaryImporter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlBinaryImporter(NpgsqlBinaryImporter importer)
            : this()
        {
            ArgumentNullException.ThrowIfNull(importer);
            InternalImporter = importer;
        }

        /// <summary>
        /// Starts writing a single row.
        /// </summary>
        public void StartRow()
        {
            InternalImporter.StartRow();
        }

        /// <summary>
        /// Asynchronously starts writing a single row.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public Task StartRowAsync(CancellationToken cancellationToken = default)
        {
            return InternalImporter.StartRowAsync(cancellationToken);
        }

        /// <summary>
        /// Writes a single column to the current row.
        /// </summary>
        /// <param name="value">The value to be written.</param>
        /// <typeparam name="T">The type of the column to be written. It must correspond to the actual type or data corruption will occur.</typeparam>
        public void Write<T>(T value)
        {
            InternalImporter.Write<T>(value);
        }
        
        /// <summary>
        /// Asynchronously writes a single column to the current row.
        /// </summary>
        /// <param name="value">The value to be written.</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
        /// <typeparam name="T">The type of the column to be written. It must correspond to the actual type or data corruption will occur.</typeparam>
        /// <returns><see cref="Task"/> object.</returns>
        public Task WriteAsync<T>(T value, CancellationToken cancellationToken = default)
        {
            return InternalImporter.WriteAsync<T>(value, cancellationToken);
        }

        /// <summary>
        /// Writes a single column to the current row.
        /// </summary>
        /// <param name="value">The value to be written.</param>
        /// <param name="postgresType">In some cases <typeparamref name="T"/> isn't enough to infer the data type to be written to the database. This parameter can be used to unambiguously specify the type. An example is the JSONB type, for which <typeparamref name="T"/> will be a simple string but for which <paramref name="postgresType"/> must be specified as <see cref="NpgsqlDbType.Jsonb"/>.</param>
        /// <typeparam name="T">The .NET type of the column to be written.</typeparam>
        public void Write<T>(T value, NpgsqlDbType postgresType)
        {
            InternalImporter.Write<T>(value, postgresType);
        }
        
        /// <summary>
        /// Writes a single column to the current row.
        /// </summary>
        /// <param name="value">The value to be written.</param>
        /// <param name="postgresType">In some cases <typeparamref name="T"/> isn't enough to infer the data type to be written to the database. This parameter can be used to unambiguously specify the type. An example is the JSONB type, for which <typeparamref name="T"/> will be a simple string but for which <paramref name="postgresType"/> must be specified as <see cref="NpgsqlDbType.Jsonb"/>.</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
        /// <typeparam name="T">The .NET type of the column to be written.</typeparam>
        /// <returns><see cref="Task"/> object.</returns>
        public Task WriteAsync<T>(T value, NpgsqlDbType postgresType, CancellationToken cancellationToken = default)
        {
            return InternalImporter.WriteAsync<T>(value, cancellationToken);
        }

        /// <summary>
        /// Writes a single column to the current row.
        /// </summary>
        /// <param name="value">The value to be written.</param>
        /// <param name="dataTypeName">In some cases <typeparamref name="T"/> isn't enough to infer the data type to be written to the database. This parameter can be used to unambiguously specify the type.</param>
        /// <typeparam name="T">The .NET type of the column to be written.</typeparam>
        public void Write<T>(T value, string dataTypeName)
        {
            InternalImporter.Write<T>(value, dataTypeName);
        }
        
        /// <summary>
        /// Writes a single column to the current row.
        /// </summary>
        /// <param name="value">The value to be written.</param>
        /// <param name="dataTypeName">In some cases <typeparamref name="T"/> isn't enough to infer the data type to be written to the database. This parameter can be used to unambiguously specify the type.</param>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
        /// <typeparam name="T">The .NET type of the column to be written.</typeparam>
        /// <returns><see cref="Task"/> object.</returns>
        public Task WriteAsync<T>(T value, string dataTypeName, CancellationToken cancellationToken = default)
        {
            return InternalImporter.WriteAsync<T>(value, dataTypeName, cancellationToken);
        }

        /// <summary>
        /// Writes a single null column value.
        /// </summary>
        public void WriteNull()
        {
            InternalImporter.WriteNull();
        }

        /// <summary>
        /// Asynchronously writes a single null column value.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public Task WriteNullAsync(CancellationToken cancellationToken = default)
        {
            return InternalImporter.WriteNullAsync(cancellationToken);
        }

        /// <summary>
        /// Writes an entire row of columns.
        /// </summary>
        /// <param name="values">An array of column values to be written as a single row.</param>
        public void WriteRow(params object[] values)
        {
            InternalImporter.WriteRow(values);
        }

        /// <summary>
        /// Asynchronously writes an entire row of columns.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
        /// <param name="values">An array of column values to be written as a single row.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public Task WriteRowAsync(CancellationToken cancellationToken = default, params object[] values)
        {
            return InternalImporter.WriteRowAsync(cancellationToken, values);
        }

        /// <summary>
        /// Completes the import operation.
        /// </summary>
        /// <returns>Number of rows written.</returns>
        public ulong Complete()
        {
            return InternalImporter.Complete();
        }

        /// <summary>
        /// Asynchronously completes the import operation.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
        /// <returns><see cref="ValueTask{TResult}"/> struct.</returns>
        public ValueTask<ulong> CompleteAsync(CancellationToken cancellationToken = default)
        {
            return InternalImporter.CompleteAsync(cancellationToken);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public void Dispose()
        {
            InternalImporter.Dispose();
        }

        /// <summary>
        /// Asynchronously disposes of the current object and releases its resources from memory.
        /// </summary>
        /// <returns><see cref="ValueTask{TResult}"/> struct.</returns>
        public ValueTask DisposeAsync()
        {
            return InternalImporter.DisposeAsync();
        }

        /// <summary>
        /// Terminates the ongoing binary import and puts the connection back into the idle state where regular commands can be executed.
        /// </summary>
        public void Close()
        {
            InternalImporter.Close();
        }

        /// <summary>
        /// Asynchronously terminates the ongoing binary import and puts the connection back into the idle state where regular commands can be executed.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
        /// <returns><see cref="ValueTask"/> struct.</returns>
        public ValueTask CloseAsync(CancellationToken cancellationToken = default)
        {
            return InternalImporter.CloseAsync(cancellationToken);
        }

        public static implicit operator NpgsqlBinaryImporter(WhippetPostgreSqlBinaryImporter importer)
        {
            return importer == null ? null : importer.InternalImporter;
        }
        
        public static implicit operator WhippetPostgreSqlBinaryImporter(NpgsqlBinaryImporter importer)
        {
            return importer == null ? null : new WhippetPostgreSqlBinaryImporter(importer);
        }
    }
}
