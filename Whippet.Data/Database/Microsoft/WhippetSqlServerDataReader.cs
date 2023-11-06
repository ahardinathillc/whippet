using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Data.Common;
using System.Collections.ObjectModel;
using System.Threading;
using System.Collections;
using System.IO;
using System.Data.SqlTypes;
using System.Xml;
using Microsoft.Data.SqlClient;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Data.Database.Microsoft.DataClassification;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Provides a way of reading a forward-only stream of rows from a SQL Server database. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetSqlServerDataReader : DbDataReader, IDataReader, IDataRecord, IDisposable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SqlDataReader"/> object.
        /// </summary>
        private SqlDataReader InternalReader
        { get; set; }

        /// <summary>
        /// Gets the value of the specified column in its native format given the column ordinal.
        /// </summary>
        /// <param name="i">The zero-based column ordinal.</param>
        /// <returns>The value of the specified column in its native format.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        public override object this[int i]
        {
            get
            {
                return InternalReader[i];
            }
        }

        /// <summary>
        /// Gets the value of the specified column in its native format given the column name.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The value of the specified column in its native format.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        public override object this[string name]
        {
            get
            {
                return InternalReader[name];
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetSqlServerConnection"/> associated with the <see cref="WhippetSqlServerDataReader"/>. This property is read-only.
        /// </summary>
        private WhippetSqlServerConnection Connection
        {
            get
            {
                WhippetSqlServerConnection connection = null;

                IEnumerable<PropertyInfo> props = InternalReader.GetType().GetNonPublicProperties();
                PropertyInfo pInfo = props.Where(p => String.Equals(p.Name, nameof(Connection), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (pInfo != null)
                {
                    connection = pInfo.GetValue(InternalReader) as WhippetSqlServerConnection;
                }

                return connection;
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
        /// Gets the number of columns in the current row. This property is read-only.
        /// </summary>
        /// <exception cref="NotSupportedException" />
        public override int FieldCount
        {
            get
            {
                return InternalReader.FieldCount;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="WhippetSqlServerDataReader"/> contains one or more rows. This property is read-only.
        /// </summary>
        public override bool HasRows
        {
            get
            {
                return InternalReader.HasRows;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="WhippetSqlServerDataReader"/> instance has been closed. This property is read-only.
        /// </summary>
        public override bool IsClosed
        {
            get
            {
                return InternalReader.IsClosed;
            }
        }

        /// <summary>
        /// Gets the number of rows changed, inserted, or deleted by execution of the Transact-SQL statement. This property is read-only.
        /// </summary>
        public override int RecordsAffected
        {
            get
            {
                return InternalReader.RecordsAffected;
            }
        }

        /// <summary>
        /// Gets the sensitivity classification information associated with the current <see cref="WhippetSqlServerDataReader"/>. This property is read-only.
        /// </summary>
        public WhippetSqlServerSensitivityClassification SensitivityClassification
        {
            get
            {
                return InternalReader.SensitivityClassification;
            }
        }

        /// <summary>
        /// Gets the number of fields in the <see cref="WhippetSqlServerDataReader"/> that are not hidden. This property is read-only.
        /// </summary>
        public override int VisibleFieldCount
        {
            get
            {
                return InternalReader.VisibleFieldCount;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerDataReader"/> class with the specified <see cref="SqlDataReader"/> object.
        /// </summary>
        /// <param name="reader"><see cref="SqlDataReader"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerDataReader(SqlDataReader reader)
            : base()
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
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
        public ReadOnlyCollection<DbColumn> GetColumnSchema()
        {
            return InternalReader.GetColumnSchema();
        }

        /// <summary>
        /// Gets the read-only column schema collection.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token used to stop the operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override Task<ReadOnlyCollection<DbColumn>> GetColumnSchemaAsync(CancellationToken cancellationToken = default)
        {
            return InternalReader.GetColumnSchemaAsync(cancellationToken);
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
        /// Gets the value of the specified column as a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public DateTimeOffset GetDateTimeOffset(int ordinal)
        {
            return InternalReader.GetDateTimeOffset(ordinal);
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
        /// Returns an <see cref="IEnumerator"/> that iterates through the <see cref="WhippetSqlServerDataReader"/>.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> for the <see cref="WhippetSqlServerDataReader"/>.</returns>
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
        /// <param name="column">The zero-based column column.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="InvalidCastException" />
        public long GetInt64(string column)
        {
            return InternalReader.GetInt64(column);
        }

        /// <summary>
        /// Gets the name of the specified column.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The name of the specified column.</returns>
        public override string GetName(int ordinal)
        {
            return InternalReader.GetName(ordinal);
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
        /// Gets the value of the specified column as a <see cref="SqlBinary"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlBinary"/>.</returns>
        public SqlBinary GetSqlBinary(int ordinal)
        {
            return InternalReader.GetSqlBinary(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlBoolean"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlBoolean"/>.</returns>
        public SqlBoolean GetSqlBoolean(int ordinal)
        {
            return InternalReader.GetSqlBoolean(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlByte"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlByte"/>.</returns>
        public SqlByte GetSqlByte(int ordinal)
        {
            return InternalReader.GetSqlByte(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlBytes"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlBytes"/>.</returns>
        public SqlBytes GetSqlBytes(int ordinal)
        {
            return InternalReader.GetSqlBytes(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlChars"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlChars"/>.</returns>
        public SqlChars GetSqlChars(int ordinal)
        {
            return InternalReader.GetSqlChars(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlDateTime"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlDateTime"/>.</returns>
        public SqlDateTime GetSqlDateTime(int ordinal)
        {
            return InternalReader.GetSqlDateTime(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlDecimal"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlDecimal"/>.</returns>
        public SqlDecimal GetSqlDecimal(int ordinal)
        {
            return InternalReader.GetSqlDecimal(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlDouble"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlDouble"/>.</returns>
        public SqlDouble GetSqlDouble(int ordinal)
        {
            return InternalReader.GetSqlDouble(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlGuid"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlGuid"/>.</returns>
        public SqlGuid GetSqlGuid(int ordinal)
        {
            return InternalReader.GetSqlGuid(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlInt16"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlInt16"/>.</returns>
        public SqlInt16 GetSqlInt16(int ordinal)
        {
            return InternalReader.GetSqlInt16(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlInt32"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlInt32"/>.</returns>
        public SqlInt32 GetSqlInt32(int ordinal)
        {
            return InternalReader.GetSqlInt32(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlInt64"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlInt64"/>.</returns>
        public SqlInt64 GetSqlInt64(int ordinal)
        {
            return InternalReader.GetSqlInt64(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlMoney"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlMoney"/>.</returns>
        public SqlMoney GetSqlMoney(int ordinal)
        {
            return InternalReader.GetSqlMoney(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlSingle"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlSingle"/>.</returns>
        public SqlSingle GetSqlSingle(int ordinal)
        {
            return InternalReader.GetSqlSingle(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlString"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlString"/>.</returns>
        public SqlString GetSqlString(int ordinal)
        {
            return InternalReader.GetSqlString(ordinal);
        }

        /// <summary>
        /// Gets the value of the specified column as a SQL Server type.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a SQL Server type.</returns>
        public object GetSqlValue(int ordinal)
        {
            return InternalReader.GetSqlValue(ordinal);
        }

        /// <summary>
        /// Fills an object array that contains the values for all the columns in the record expressed as SQL Server types.
        /// </summary>
        /// <param name="values">Destination array in which to copy the values.</param>
        /// <returns>Number of columns copied.</returns>
        /// <exception cref="ArgumentNullException" />
        public int GetSqlValues(object[] values)
        {
            return InternalReader.GetSqlValues(values);
        }

        /// <summary>
        /// Gets the value of the specified column as a <see cref="SqlXml"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column expressed as a <see cref="SqlXml"/>.</returns>
        public SqlXml GetSqlXml(int ordinal)
        {
            return InternalReader.GetSqlXml(ordinal);
        }

        /// <summary>
        /// Gets a <see cref="DataTable"/> that describes the column metadata of the <see cref="WhippetSqlServerDataReader"/>.
        /// </summary>
        /// <returns><see cref="DataTable"/> that describes the column metadata.</returns>
        /// <exception cref="InvalidOperationException" />
        public override DataTable GetSchemaTable()
        {
            return InternalReader.GetSchemaTable();
        }

        /// <summary>
        /// Gets a <see cref="DataTable"/> that describes the column metadata of the <see cref="WhippetSqlServerDataReader"/>.
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
        /// Retrieves XML data as an <see cref="XmlReader"/>.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns><see cref="XmlReader"/> containing the column data.</returns>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="IndexOutOfRangeException" />
        /// <exception cref="InvalidCastException" />
        public XmlReader GetXmlReader(int ordinal)
        {
            return InternalReader.GetXmlReader(ordinal);
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
        /// Advances the data reader to the next result when reading the results of batch Transact-SQL statements.
        /// </summary>
        /// <returns><see langword="true"/> if there are more result sets; otherwise, <see langword="false"/>.</returns>
        public override bool NextResult()
        {
            return InternalReader.NextResult();
        }

        /// <summary>
        /// Advances the data reader to the next result when reading the results of batch Transact-SQL statements.
        /// </summary>
        /// <param name="cancellationToken">The cancellation instruction which propagates a notification that operations should be canceled.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="SqlException" />
        public override Task<bool> NextResultAsync(CancellationToken cancellationToken)
        {
            return InternalReader.NextResultAsync(cancellationToken);
        }

        /// <summary>
        /// Advances the <see cref="WhippetSqlServerDataReader"/> to the next record.
        /// </summary>
        /// <returns><see langword="true"/> if there are more rows; otherwise, <see langword="false"/>.</returns>
        public override bool Read()
        {
            return InternalReader.Read();
        }

        /// <summary>
        /// Asynchronously advances the <see cref="WhippetSqlServerDataReader"/> to the next record.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="DbException" />
        public new Task<bool> ReadAsync()
        {
            return InternalReader.ReadAsync();
        }

        /// <summary>
        /// Asynchronously advances the <see cref="WhippetSqlServerDataReader"/> to the next record.
        /// </summary>
        /// <param name="cancellationToken">The cancellation instruction which propagates a notification that operations should be canceled.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="SqlException" />
        public override Task<bool> ReadAsync(CancellationToken cancellationToken)
        {
            return InternalReader.ReadAsync(cancellationToken);
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

        /// <summary>
        /// Closes the <see cref="WhippetSqlServerDataReader"/> object.
        /// </summary>
        public override void Close()
        {
            InternalReader.Close();
        }

        /// <summary>
        /// Closes the <see cref="WhippetSqlServerDataReader"/> object.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public override Task CloseAsync()
        {
            return InternalReader.CloseAsync();
        }

        /// <summary>
        /// Disposes of the object and releases all resources used by the current instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Dispose()
        {
            InternalReader.Dispose();
        }

        /// <summary>
        /// Asynchronously disposes of the object and releases all resources used by the current instance.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public override ValueTask DisposeAsync()
        {
            return InternalReader.DisposeAsync();
        }

        /// <summary>
        /// Returns a nested data reader for the requested column.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>A data reader.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new DbDataReader GetData(int ordinal)
        {
            return InternalReader.GetData(ordinal);
        }

        public static implicit operator WhippetSqlServerDataReader(SqlDataReader reader)
        {
            return (reader == null) ? null : new WhippetSqlServerDataReader(reader);
        }

        public static implicit operator SqlDataReader(WhippetSqlServerDataReader reader)
        {
            return (reader == null) ? null : reader.InternalReader;
        }
    }
}
