using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using NodaTime;
using Npgsql;
using Npgsql.Schema;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Reads a forward-only stream of rows from a data source. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetPostgreSqlDataReader : DbDataReader, IDbColumnSchemaGenerator, IDataRecord, IEnumerable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="NpgsqlDataReader"/> object.
        /// </summary>
        private NpgsqlDataReader InternalReader
        { get; set; }

        /// <summary>
        /// Gets the value of the specified column as an instance of <see cref="Object"/>. This property is read-only.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public override object this[int ordinal]
        {
            get
            {
                return InternalReader[ordinal];
            }
        }

        /// <summary>
        /// Gets the value of the specified column as an instance of <see cref="Object"/>. This property is read-only.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public override object this[string name]
        {
            get
            {
                return InternalReader[name];
            }
        }

        /// <summary>
        /// Gets the number of fields in the <see cref="WhippetPostgreSqlDataReader"/> that are not hidden. This property is read-only.
        /// </summary>
        public override int VisibleFieldCount
        {
            get
            {
                return InternalReader.VisibleFieldCount;
            }
        }

        /// <summary>
        /// Indicates the depth of nesting for the current row. This property is read-only.
        /// </summary>
        public override int Depth
        {
            get
            {
                return InternalReader.Depth;
            }
        }

        /// <summary>
        /// Indicates whether the data reader is closed. This property is read-only.
        /// </summary>
        public override bool IsClosed
        {
            get
            {
                return InternalReader.IsClosed;
            }
        }

        /// <summary>
        /// Indicates the number of rows changed, inserted, or deleted by execution of the SQL statement. This property is read-only.
        /// </summary>
        /// <exception cref="OverflowException"></exception>
        public override int RecordsAffected
        {
            get
            {
                return InternalReader.RecordsAffected;
            }
        }

        /// <summary>
        /// Indicates the number of rows changed, inserted, or deleted by execution of the SQL statement. This property is read-only.
        /// </summary>
        public ulong Rows
        {
            get
            {
                return InternalReader.Rows;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="WhippetPostgreSqlDataReader"/> contains one or more rows. This property is read-only.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        public override bool HasRows
        {
            get
            {
                return InternalReader.HasRows;
            }
        }

        /// <summary>
        /// Indicates whether the reader is currently positioned on a row (i.e., reading a column is possible). This property is read-only.
        /// </summary>
        /// <remarks>This property is different from <see cref="HasRows"/> in that <see cref="HasRows"/> will return <see langword="true"/> even if attempting to read a column will fail.</remarks>
        public bool IsOnRow
        {
            get
            {
                return InternalReader.IsOnRow;
            }
        }

        /// <summary>
        /// Gets the number of columns in the current row. This property is read-only.
        /// </summary>
        public override int FieldCount
        {
            get
            {
                return InternalReader.FieldCount;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlDataReader"/> class with no arguments.
        /// </summary>
        private WhippetPostgreSqlDataReader()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlDataReader"/> class with the specified <see cref="NpgsqlDataReader"/> object.
        /// </summary>
        /// <param name="reader"><see cref="NpgsqlDataReader"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlDataReader(NpgsqlDataReader reader)
            : this()
        {
            ArgumentNullException.ThrowIfNull(reader);
            InternalReader = reader;
        }

        /// <summary>
        /// Advances the reader to the next record in a result set.
        /// </summary>
        /// <returns><see langword="true"/> if there are more rows; otherwise, <see langword="false"/>.</returns>
        public override bool Read()
        {
            return InternalReader.Read();
        }

        /// <summary>
        /// Asynchronously advances the reader to the next record in a result set.
        /// </summary>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns><see cref="Task{TResult}"/> object.</returns>
        public override Task<bool> ReadAsync(CancellationToken cancellationToken)
        {
            return InternalReader.ReadAsync(cancellationToken);
        }

        /// <summary>
        /// Advances the reader to the next result when reading the results of a batch of statements.
        /// </summary>
        /// <returns><see langword="true"/> if there are more results; otherwise, <see langword="false"/>.</returns>
        public override bool NextResult()
        {
            return InternalReader.NextResult();
        }

        /// <summary>
        /// Asynchronously advances the reader to the next result when reading the results of a batch of statements.
        /// </summary>
        /// <param name="cancellationToken">An optional token to cancel the asynchronous operation.</param>
        /// <returns><see cref="Task{TResult}"/> object.</returns>
        public override Task<bool> NextResultAsync(CancellationToken cancellationToken)
        {
            return InternalReader.NextResultAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the name of the column given the zero-based column ordinal.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The name of the specified column.</returns>
        public override string GetName(int ordinal)
        {
            return InternalReader.GetName(ordinal);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public new void Dispose()
        {
            InternalReader.Dispose();
        }
        
        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        /// <returns><see cref="ValueTask"/> struct.</returns>
        public override ValueTask DisposeAsync()
        {
            return InternalReader.DisposeAsync();
        }

        /// <summary>
        /// Closes the <see cref="WhippetPostgreSqlDataReader"/>.
        /// </summary>
        public override void Close()
        {
            InternalReader.Close();
        }

        /// <summary>
        /// Asynchronously closes the <see cref="WhippetPostgreSqlDataReader"/>.
        /// </summary>
        /// <returns><see cref="Task"/> object.</returns>
        public override Task CloseAsync()
        {
            return InternalReader.CloseAsync();
        }
        
        /// <summary>
        /// Gets the value of the specified column as a <see cref="Boolean"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override bool GetBoolean(int ordinal)
        {
            return InternalReader.GetBoolean(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Boolean"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public bool GetBoolean(string column)
        {
            return InternalReader.GetBoolean(column);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Boolean"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override byte GetByte(int ordinal)
        {
            return InternalReader.GetByte(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Byte"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public byte GetByte(string column)
        {
            return InternalReader.GetByte(column);
        }

        /// <summary>
        /// Reads a stream of bytes from the specified column offset into the buffer array starting at the given buffer offset.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <param name="dataOffset">The index within the field from which to begin the read operation.</param>
        /// <param name="buffer">The buffer into which to read the stream of bytes.</param>
        /// <param name="bufferOffset">The index within the buffer where the write operation is to start.</param>
        /// <param name="length">The maximum length to copy into the buffer.</param>
        /// <returns>The actual number of bytes read.</returns>
        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return InternalReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        /// Reads a stream of bytes from the specified column offset into the buffer array starting at the given buffer offset.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <param name="dataOffset">The index within the field from which to begin the read operation.</param>
        /// <param name="buffer">The buffer into which to read the stream of bytes.</param>
        /// <param name="bufferOffset">The index within the buffer where the write operation is to start.</param>
        /// <param name="length">The maximum length to copy into the buffer.</param>
        /// <returns>The actual number of bytes read.</returns>
        public long GetBytes(string column, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return InternalReader.GetBytes(column, dataOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Boolean"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override char GetChar(int ordinal)
        {
            return InternalReader.GetChar(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Char"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public char GetChar(string column)
        {
            return InternalReader.GetChar(column);
        }

        /// <summary>
        /// Reads a stream of characters from the specified column offset into the buffer array starting at the given buffer offset.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <param name="dataOffset">The index within the field from which to begin the read operation.</param>
        /// <param name="buffer">The buffer into which to read the stream of bytes.</param>
        /// <param name="bufferOffset">The index within the buffer where the write operation is to start.</param>
        /// <param name="length">The maximum length to copy into the buffer.</param>
        /// <returns>The actual number of characters read.</returns>
        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return InternalReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        /// Reads a stream of characters from the specified column offset into the buffer array starting at the given buffer offset.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <param name="dataOffset">The index within the field from which to begin the read operation.</param>
        /// <param name="buffer">The buffer into which to read the stream of bytes.</param>
        /// <param name="bufferOffset">The index within the buffer where the write operation is to start.</param>
        /// <param name="length">The maximum length to copy into the buffer.</param>
        /// <returns>The actual number of characters read.</returns>
        public long GetChars(string column, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return InternalReader.GetChars(column, dataOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        /// Gets the read-only column schema collection.
        /// </summary>
        /// <returns>The read-only column schema collection.</returns>
        public ReadOnlyCollection<WhippetPostgreSqlColumn> GetColumnSchema()
        {
            return Task.Run(() => GetColumnSchemaAsync()).Result;
        }

        /// <summary>
        /// Gets the read-only column schema collection.
        /// </summary>
        /// <returns>The read-only column schema collection.</returns>
        public async Task<ReadOnlyCollection<WhippetPostgreSqlColumn>> GetColumnSchemaAsync(CancellationToken cancellationToken = default)
        {
            List<WhippetPostgreSqlColumn> wColumns = null;
            ReadOnlyCollection<NpgsqlDbColumn> columns = await InternalReader.GetColumnSchemaAsync(cancellationToken);

            if (columns != null)
            {
                wColumns = (columns.Count > 0) ? new List<WhippetPostgreSqlColumn>(columns.Count) : new List<WhippetPostgreSqlColumn>();

                foreach (NpgsqlDbColumn column in columns)
                {
                    wColumns.Add(new WhippetPostgreSqlColumn(column));
                }
            }

            return (wColumns == null) ? null : wColumns.AsReadOnly();
        }
        
        /// <summary>
        /// Gets the read-only column schema collection.
        /// </summary>
        /// <returns>The read-only column schema collection.</returns>
        ReadOnlyCollection<DbColumn> IDbColumnSchemaGenerator.GetColumnSchema()
        {
            return ((IDbColumnSchemaGenerator)(InternalReader)).GetColumnSchema();
        }

        /// <summary>
        /// Gets a string representing the data type of the specified column.
        /// </summary>
        /// <param name="ordinal">The zero-based ordinal position of the column to find.</param>
        /// <returns>The string representing the data type of the specified column.</returns>
        public override string GetDataTypeName(int ordinal)
        {
            return InternalReader.GetDataTypeName(ordinal);
        }

        /// <summary>
        /// Gets a string representing the data type of the specified column.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The string representing the data type of the specified column.</returns>
        public string GetDataTypeName(string column)
        {
            return InternalReader.GetDataTypeName(column);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override DateTime GetDateTime(int ordinal)
        {
            return InternalReader.GetDateTime(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public DateTime GetDateTime(string column)
        {
            return InternalReader.GetDateTime(column);
        }

        /// <summary>
        /// Gets the value of the specified column as an <see cref="Instant"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public Instant GetNodaDateTime(int ordinal)
        {
            return Instant.FromDateTimeUtc(GetDateTime(ordinal));
        }

        /// <summary>
        /// Gets the value of the specified column as an <see cref="Instant"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public Instant GetNodaDateTime(string column)
        {
            return Instant.FromDateTimeUtc(GetDateTime(column));
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Decimal"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override decimal GetDecimal(int ordinal)
        {
            return InternalReader.GetDecimal(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Decimal"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public decimal GetDecimal(string column)
        {
            return InternalReader.GetDecimal(column);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Double"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override double GetDouble(int ordinal)
        {
            return InternalReader.GetDouble(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Double"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public double GetDouble(string column)
        {
            return InternalReader.GetDouble(column);
        }
        
        /// <summary>
        /// Returns an <see cref="IEnumerator"/> that iterates through the <see cref="WhippetMySqlDataReader"/>.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> for the <see cref="WhippetMySqlDataReader"/>.</returns>
        public override IEnumerator GetEnumerator()
        {
            return InternalReader.GetEnumerator();
        }

        /// <summary>
        /// Gets the <see cref="Type"/> that is the data type of the object.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The <see cref="Type"/> that is the data type of the object. If the type does not exist on the client (such as a User-Defined Type [UDT] returned from the database), <see langword="null"/> is returned.</returns>
        public override Type GetFieldType(int ordinal)
        {
            return InternalReader.GetFieldType(ordinal);
        }

        /// <summary>
        /// Gets the <see cref="Type"/> that is the data type of the object.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The <see cref="Type"/> that is the data type of the object. If the type does not exist on the client (such as a User-Defined Type [UDT] returned from the database), <see langword="null"/> is returned.</returns>
        public Type GetFieldType(string column)
        {
            return InternalReader.GetFieldType(column);
        }

        /// <summary>
        /// Synchronously gets the value of the specified column as the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The returned object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IndexOutOfRangeException" />
        /// <exception cref="System.Data.SqlTypes.SqlNullValueException" />
        /// <exception cref="InvalidCastException" />
        public override T GetFieldValue<T>(int ordinal)
        {
            return InternalReader.GetFieldValue<T>(ordinal);
        }

        /// <summary>
        /// Synchronously gets the value of the specified column as the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="column">Name of the column.</param>
        /// <returns>The returned object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IndexOutOfRangeException" />
        /// <exception cref="SqlNullValueException" />
        /// <exception cref="InvalidCastException" />
        public T GetFieldValue<T>(string column)
        {
            return InternalReader.GetFieldValue<T>(column);
        }

        /// <summary>
        /// Asynchronously gets the value of the specified column as the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <param name="cancellationToken">The cancellation instruction which propagates a notification that operations should be cancelled.</param>
        /// <returns>The returned object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IndexOutOfRangeException" />
        /// <exception cref="SqlNullValueException" />
        /// <exception cref="InvalidCastException" />
        public override Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken cancellationToken)
        {
            return InternalReader.GetFieldValueAsync<T>(ordinal, cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the value of the specified column as the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="column">Name of the column.</param>
        /// <param name="cancellationToken">The cancellation instruction which propagates a notification that operations should be cancelled.</param>
        /// <returns>The returned object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IndexOutOfRangeException" />
        /// <exception cref="SqlNullValueException" />
        /// <exception cref="InvalidCastException" />
        public Task<T> GetFieldValueAsync<T>(string column, CancellationToken cancellationToken)
        {
            return InternalReader.GetFieldValueAsync<T>(column, cancellationToken);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Single"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override float GetFloat(int ordinal)
        {
            return InternalReader.GetFloat(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Single"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public float GetFloat(string column)
        {
            return InternalReader.GetFloat(column);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Guid"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override Guid GetGuid(int ordinal)
        {
            return InternalReader.GetGuid(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="Guid"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public Guid GetGuid(string column)
        {
            return InternalReader.GetGuid(column);
        }

        /// <summary>
        /// Serves as a default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return InternalReader.GetHashCode();
        }

        /// <summary>
        /// Gets the value of the specified column as an <see cref="Int16"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override short GetInt16(int ordinal)
        {
            return InternalReader.GetInt16(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as an <see cref="Int32"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override int GetInt32(int ordinal)
        {
            return InternalReader.GetInt32(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as an <see cref="Int64"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override long GetInt64(int ordinal)
        {
            return InternalReader.GetInt64(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as an <see cref="Int16"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public short GetInt16(string column)
        {
            return InternalReader.GetInt16(column);
        }

        /// <summary>
        /// Gets the value of the specified column as an <see cref="Int32"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public int GetInt32(string column)
        {
            return InternalReader.GetInt32(column);
        }

        /// <summary>
        /// Gets the value of the specified column as an <see cref="Int64"/>.
        /// </summary>
        /// <param name="column">Name of the column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public long GetInt64(string column)
        {
            return InternalReader.GetInt64(column);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public TimeSpan GetTimeSpan(int ordinal)
        {
            return InternalReader.GetTimeSpan(ordinal);
        }
        
        /// <summary>
        /// Gets the column ordinal for the specified column name.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The zero-based column ordinal.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        public override int GetOrdinal(string name)
        {
            return InternalReader.GetOrdinal(name);
        }

        /// <summary>
        /// Gets the .NET <see cref="Type"/> that is a representation of the underlying provider-specific field type.
        /// </summary>
        /// <param name="ordinal">Zero-based column ordinal.</param>
        /// <returns><see cref="Type"/> object that represents the underlying provider-specific field type.</returns>
        public override Type GetProviderSpecificFieldType(int ordinal)
        {
            return InternalReader.GetProviderSpecificFieldType(ordinal);
        }

        /// <summary>
        /// Gets an object that is a representation of the underlying provider-specific value.
        /// </summary>
        /// <param name="ordinal">Zero-based column ordinal.</param>
        /// <returns>An object that is a representation of the underlying provider specific value.</returns>
        public override object GetProviderSpecificValue(int ordinal)
        {
            return InternalReader.GetProviderSpecificValue(ordinal);
        }

        /// <summary>
        /// Gets an array of objects that are a representation of the underlying provider-specific values.
        /// </summary>
        /// <param name="values">Array into which to copy the column values.</param>
        /// <returns>The number of values copied into the specified array.</returns>
        public override int GetProviderSpecificValues(object[] values)
        {
            return InternalReader.GetProviderSpecificValues(values);
        }

        /// <summary>
        /// Gets a <see cref="DataTable"/> that describes the column metadata of the <see cref="WhippetMySqlDataReader"/>.
        /// </summary>
        /// <returns><see cref="DataTable"/> that describes the column metadata.</returns>
        /// <exception cref="InvalidOperationException" />
        public override DataTable GetSchemaTable()
        {
            return InternalReader.GetSchemaTable();
        }

        /// <summary>
        /// Gets a <see cref="DataTable"/> that describes the column metadata of the <see cref="WhippetMySqlDataReader"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token used to stop the operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException" />
        public override Task<DataTable> GetSchemaTableAsync(CancellationToken cancellationToken = default)
        {
            return InternalReader.GetSchemaTableAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves binary, image, varbinary, UDT, and variant data types as a <see cref="Stream"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns><see cref="Stream"/> object.</returns>
        /// <exception cref="InvalidCastException" />
        public override Stream GetStream(int ordinal)
        {
            return InternalReader.GetStream(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="String"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public override string GetString(int ordinal)
        {
            return InternalReader.GetString(ordinal);
        }

        /// <summary>
        /// Retrieves CHAR, NCHAR, NTEXT, NVARCHAR, TEXT, VARCHAR, and variant data types as a <see cref="TextReader"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns><see cref="TextReader"/> containing the column value.</returns>
        /// <exception cref="InvalidCastException" />
        public override TextReader GetTextReader(int ordinal)
        {
            return InternalReader.GetTextReader(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column in its native format.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The raw column value or <see cref="DBNull.Value"/> for <see langword="null"/> database columns.</returns>
        public override object GetValue(int ordinal)
        {
            return InternalReader.GetValue(ordinal);
        }

        /// <summary>
        /// Populates an object array with the column values of the current row.
        /// </summary>
        /// <param name="values">Object array into which to copy the attribute columns.</param>
        /// <returns>The number of columns copied.</returns>
        public override int GetValues(object[] values)
        {
            return InternalReader.GetValues(values);
        }

        /// <summary>
        /// Indicates whether the column contains non-existent or missing values.
        /// </summary>
        /// <param name="ordinal">THe zero-based column ordinal.</param>
        /// <returns><see langword="true"/> if the specified column value is equivalent to <see cref="DBNull.Value"/>; otherwise, <see langword="false"/>.</returns>
        public override bool IsDBNull(int ordinal)
        {
            return InternalReader.IsDBNull(ordinal);
        }

        /// <summary>
        /// Indicates whether the column contains non-existent or missing values.
        /// </summary>
        /// <param name="ordinal">THe zero-based column ordinal.</param>
        /// <param name="cancellationToken">The cancellation instruction which propagates a notification that operations should be canceled.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken)
        {
            return InternalReader.IsDBNullAsync(ordinal, cancellationToken);
        }
        
        /// <summary>
        /// Returns an <see cref="IDataReader"/> for the specified column ordinal.
        /// </summary>
        /// <param name="i">The zero-based column ordinal.</param>
        /// <returns><see cref="IDataReader"/> object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IDataReader IDataRecord.GetData(int i)
        {
            return ((IDataRecord)(InternalReader)).GetData(i);
        }
        
        public static implicit operator WhippetPostgreSqlDataReader(NpgsqlDataReader reader)
        {
            return (reader == null) ? null : new WhippetPostgreSqlDataReader(reader);
        }

        public static implicit operator NpgsqlDataReader(WhippetPostgreSqlDataReader reader)
        {
            return (reader == null) ? null : reader.InternalReader;
        }

    }
}
