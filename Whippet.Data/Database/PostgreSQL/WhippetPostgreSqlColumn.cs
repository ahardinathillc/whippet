using System;
using System.Data.Common;
using Npgsql.PostgresTypes;
using Npgsql.Schema;
using NpgsqlTypes;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Provides schema information about a column in PostgreSQL. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetPostgreSqlColumn : DbColumn
    {
        private NpgsqlDbColumn _col;
        
        /// <summary>
        /// Gets or sets the internal <see cref="NpgsqlDbColumn"/> object.
        /// </summary>
        private NpgsqlDbColumn InternalColumn
        {
            get
            {
                if (_col == null)
                {
                    _col = new NpgsqlDbColumn();
                }

                return _col;
            }
            set
            {
                _col = value;
            }
        }

        /// <summary>
        /// Gets the object based on the column property name. This property is read-only.
        /// </summary>
        /// <param name="property">The column property name.</param>
        public override object this[string property]
        {
            get
            {
                return InternalColumn[property];
            }
        }
        
        /// <summary>
        /// Gets a nullable boolean value that indicates whether <see cref="DBNull"/> values are allowed in this column, or returns <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? AllowDBNull
        {
            get
            {
                return InternalColumn.AllowDBNull;
            }
        }

        /// <summary>
        /// Gets the catalog name associated with the data source; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new string BaseCatalogName
        {
            get
            {
                return InternalColumn.BaseCatalogName;
            }
        }

        /// <summary>
        /// Gets the base column name; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new string BaseColumnName
        {
            get
            {
                return InternalColumn.BaseColumnName;
            }
        }

        /// <summary>
        /// Gets the base schema name associated with the data source; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new string BaseSchemaName
        {
            get
            {
                return InternalColumn.BaseSchemaName;
            }
        }

        /// <summary>
        /// Gets the base server name associated with the column; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new string BaseServerName
        {
            get
            {
                return InternalColumn.BaseServerName;
            }
        }

        /// <summary>
        /// Gets the base table name in the schema; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new string BaseTableName
        {
            get
            {
                return InternalColumn.BaseTableName;
            }
        }

        /// <summary>
        /// Gets the name of the column. This property is read-only.
        /// </summary>
        public new string ColumnName
        {
            get
            {
                return InternalColumn.ColumnName;
            }
        }

        /// <summary>
        /// Gets the column position (ordinal) in the datasource row; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new int? ColumnOrdinal
        {
            get
            {
                return InternalColumn.ColumnOrdinal;
            }
        }

        /// <summary>
        /// Gets the column size; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new int? ColumnSize
        {
            get
            {
                return InternalColumn.ColumnSize;
            }
        }

        /// <summary>
        /// Gets the type of data stored in the column. This property is read-only.
        /// </summary>
        public new Type DataType
        {
            get
            {
                return InternalColumn.DataType;
            }
        }

        /// <summary>
        /// Gets the name of the data type; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new string DataTypeName
        {
            get
            {
                return InternalColumn.DataTypeName;
            }
        }

        /// <summary>
        /// Gets a nullable boolean value that indicates whether this column is aliased; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? IsAliased
        {
            get
            {
                return InternalColumn.IsAliased;
            }
        }

        /// <summary>
        /// Gets a nullable boolean value that indicates whether values in this column are automatically incremented; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? IsAutoIncrement
        {
            get
            {
                return InternalColumn.IsAutoIncrement;
            }
        }

        /// <summary>
        /// Gets a nullable boolean value that indicates whether the column is an expression; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? IsExpression
        {
            get
            {
                return InternalColumn.IsExpression;
            }
        }

        /// <summary>
        /// Gets a nullable boolean value that indicates whether the column is hidden; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? IsHidden
        {
            get
            {
                return InternalColumn.IsHidden;
            }
        }

        /// <summary>
        /// Gets a nullable boolean value that indicates whether the column is an identity; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? IsIdentity
        {
            get
            {
                return InternalColumn.IsIdentity;
            }
        }

        /// <summary>
        /// Gets a nullable boolean value that indicates whether the column is a key; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? IsKey
        {
            get
            {
                return InternalColumn.IsKey;
            }
        }

        /// <summary>
        /// Gets a nullable boolean value that indicates whether the column contains long data; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? IsLong
        {
            get
            {
                return InternalColumn.IsLong;
            }
        }

        /// <summary>
        /// Gets a nullable boolean value that indicates whether the column is read-only; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? IsReadOnly
        {
            get
            {
                return InternalColumn.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets a nullable boolean value that indicates whether a unique constraint applies to this column; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new bool? IsUnique
        {
            get
            {
                return InternalColumn.IsUnique;
            }
        }

        /// <summary>
        /// Gets the numeric precision of the column data; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new int? NumericPrecision
        {
            get
            {
                return InternalColumn.NumericPrecision;
            }
        }
        
        /// <summary>
        /// Gets a nullable <see cref="Int32"/> value that either returns <see langword="null"/> or the numeric scale of the column data. This property is read-only.
        /// </summary>
        public new int? NumericScale
        {
            get
            {
                return InternalColumn.NumericScale;
            }
        }

        /// <summary>
        /// Gets the assembly-qualified name of the <see cref="Type"/> of the type of data stored in the column; otherwise, <see langword="null"/> if no value is set. This property is read-only.
        /// </summary>
        public new string UdtAssemblyQualifiedName
        {
            get
            {
                return InternalColumn.UdtAssemblyQualifiedName;
            }
        }

        /// <summary>
        /// Gets the <see cref="IWhippetPostgreSqlType"/> describing the type of this column. This property is read-only.
        /// </summary>
        public IWhippetPostgreSqlType PostgresType
        {
            get
            {
                return InternalColumn.PostgresType == null ? null : new WhippetPostgreSqlType(InternalColumn.PostgresType);
            }
        }

        /// <summary>
        /// Represents the OID of the type of this column in the PostgreSQL <b>pg_type</b> catalog table. This property is read-only.
        /// </summary>
        public uint TypeOID
        {
            get
            {
                return InternalColumn.TypeOID;
            }
        }

        /// <summary>
        /// Represents the OID of the PostgreSQL table of this column. This property is read-only.
        /// </summary>
        public uint TableOID
        {
            get
            {
                return InternalColumn.TableOID;
            }
        }

        /// <summary>
        /// Gets the column's position within its table. This property is read-only.
        /// </summary>
        public short? ColumnAttributeNumber
        {
            get
            {
                return InternalColumn.ColumnAttributeNumber;
            }
        }

        /// <summary>
        /// Gets the default SQL expression for this column. This property is read-only.
        /// </summary>
        public string DefaultValue
        {
            get
            {
                return InternalColumn.DefaultValue;
            }
        }

        /// <summary>
        /// Gets the PostgreSQL database type for the column. This property is read-only.
        /// </summary>
        public NpgsqlDbType? PostgreSqlDbType
        {
            get
            {
                return InternalColumn.NpgsqlDbType;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlColumn"/> class with no arguments.
        /// </summary>
        public WhippetPostgreSqlColumn()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlColumn"/> class with the specified <see cref="NpgsqlDbColumn"/> object. 
        /// </summary>
        /// <param name="column"><see cref="NpgsqlDbColumn"/> object to initialize with.</param>
        public WhippetPostgreSqlColumn(NpgsqlDbColumn column)
        {
            InternalColumn = column;
        }

        public static implicit operator WhippetPostgreSqlColumn(NpgsqlDbColumn column)
        {
            return (column == null) ? null : new WhippetPostgreSqlColumn(column);
        }

        public static implicit operator NpgsqlDbColumn(WhippetPostgreSqlColumn column)
        {
            return (column == null) ? null : column.InternalColumn;
        }
    }
}
