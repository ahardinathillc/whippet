using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using Npgsql;
using Npgsql.PostgresTypes;
using NpgsqlTypes;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a parameter to a <see cref="WhippetPostgreSqlCommand"/> object. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetPostgreSqlParameter : DbParameter, IDataParameter, IDbDataParameter, ICloneable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="Np"/> object.
        /// </summary>
        private NpgsqlParameter InternalParameter
        { get; set; }

        /// <summary>
        /// Gets or sets the database data type of the parameter.
        /// </summary>
        public override DbType DbType
        {
            get
            {
                return InternalParameter.DbType;
            }
            set
            {
                InternalParameter.DbType = value;
            }
        }

        /// <summary>
        /// Specifies whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.
        /// </summary>
        /// <exception cref="ArgumentException" />
        [RefreshProperties(RefreshProperties.All)]
        public override ParameterDirection Direction
        {
            get
            {
                return InternalParameter.Direction;
            }
            set
            {
                InternalParameter.Direction = value;
            }
        }

        /// <summary>
        /// Indicates whether the parameter accepts null values. <see cref="IsNullable"/> is not used to validate the parameter's value 
        /// and will not prevent sending or receiving a null value when executing a command.
        /// </summary>
        [DefaultValue(false)]
        public override bool IsNullable
        {
            get
            {
                return InternalParameter.IsNullable;
            }
            set
            {
                InternalParameter.IsNullable = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the <see cref="WhippetPostgreSqlParameter"/>.
        /// </summary>
        public override string ParameterName
        {
            get
            {
                return InternalParameter.ParameterName;
            }
            set
            {
                InternalParameter.ParameterName = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of digits used to represent the <see cref="Value"/> property.
        /// </summary>
        [DefaultValue(0)]
        public new byte Precision
        {
            get
            {
                return InternalParameter.Precision;
            }
            set
            {
                InternalParameter.Precision = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of decimal places to which <see cref="Value"/> is resolved.
        /// </summary>
        [DefaultValue(0)]
        public new byte Scale
        {
            get
            {
                return InternalParameter.Scale;
            }
            set
            {
                InternalParameter.Scale = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum size, in bytes, of the data within the column.
        /// </summary>
        public override int Size
        {
            get
            {
                return InternalParameter.Size;
            }
            set
            {
                InternalParameter.Size = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the source column mapped to the <see cref="DataSet"/> and used for loading or returning the <see cref="Value"/>.
        /// </summary>
        public override string SourceColumn
        {
            get
            {
                return InternalParameter.SourceColumn;
            }
            set
            {
                InternalParameter.SourceColumn = value;
            }
        }

        /// <summary>
        /// Sets or gets a value which indicates whether the source column is nullable. This allows <see cref="WhippetMySqlCommandBuilder"/> to correctly generate update statements for nullable columns.
        /// </summary>
        public override bool SourceColumnNullMapping
        {
            get
            {
                return InternalParameter.SourceColumnNullMapping;
            }
            set
            {
                InternalParameter.SourceColumnNullMapping = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="DataRowVersion"/> to use when loading <see cref="Value"/>.
        /// </summary>
        public override DataRowVersion SourceVersion
        {
            get
            {
                return InternalParameter.SourceVersion;
            }
            set
            {
                InternalParameter.SourceVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        [TypeConverter(typeof(StringConverter))]
        public override object Value
        {
            get
            {
                return InternalParameter.Value;
            }
            set
            {
                InternalParameter.Value = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        public object PostgreSqlValue
        {
            get
            {
                return InternalParameter.NpgsqlValue;
            }
            set
            {
                InternalParameter.NpgsqlValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        public NpgsqlDbType PostgreSqlType
        {
            get
            {
                return InternalParameter.NpgsqlDbType;
            }
            set
            {
                InternalParameter.NpgsqlDbType = value;
            }
        }

        /// <summary>
        /// Gets or sets the PostgreSQL type that will be sent to the database for this parameter.
        /// </summary>
        public string DataTypeName
        {
            get
            {
                return InternalParameter.DataTypeName;
            }
            set
            {
                InternalParameter.DataTypeName = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection the parameter belongs to (if any).
        /// </summary>
        public WhippetPostgreSqlParameterCollection Collection
        {
            get
            {
                return InternalParameter.Collection;
            }
            set
            {
                InternalParameter.Collection = value;
            }
        }

        /// <summary>
        /// Gets the PostgreSQL data type, such as <b>int4</b> or <b>text</b>, as discovered from <b>pg_type</b>. This property is automatically
        /// set if parameters have been derived via <see cref="WhippetPostgreSqlCommandBuilder.DeriveParameters"/> and can be used to acquire additional
        /// information about the parameters' data type.
        /// </summary>
        public PostgresType Type
        {
            get
            {
                return InternalParameter.PostgresType;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameter"/> class with no arguments.
        /// </summary>
        public WhippetPostgreSqlParameter()
            : this(new NpgsqlParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameter"/> class with the specified <see cref="NpgsqlParameter"/>.
        /// </summary>
        /// <param name="parameter"><see cref="NpgsqlParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlParameter(NpgsqlParameter parameter)
            : base()
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else
            {
                InternalParameter = parameter;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameter"/> class that uses the parameter name and data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="NpgsqlTypes.NpgsqlDbType"/> values.</param>
        /// <exception cref="ArgumentException" />
        public WhippetPostgreSqlParameter(string parameterName, NpgsqlDbType dbType)
            : this(new NpgsqlParameter(parameterName, dbType))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameter"/> class that uses the parameter name, data type, and size.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="NpgsqlTypes.NpgsqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <exception cref="ArgumentException" />
        public WhippetPostgreSqlParameter(string parameterName, NpgsqlDbType dbType, int size)
            : this(new NpgsqlParameter(parameterName, dbType, size))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameter"/> class that uses the parameter name, the <see cref="System.Data.DbType"/>, the size, and the source column name.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="System.Data.DbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <param name="sourceColumn">The name of the source column if this <see cref="WhippetPostgreSqlParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        public WhippetPostgreSqlParameter(string parameterName, DbType dbType, int size, string sourceColumn)
            : this(new NpgsqlParameter(parameterName, dbType, size, sourceColumn))
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameter"/> class that uses the parameter name, the <see cref="NpgsqlTypes.NpgsqlDbType"/>, the size, and the source column name.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="NpgsqlTypes.NpgsqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <param name="sourceColumn">The name of the source column if this <see cref="WhippetPostgreSqlParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        public WhippetPostgreSqlParameter(string parameterName, NpgsqlDbType dbType, int size, string sourceColumn)
            : this(new NpgsqlParameter(parameterName, dbType, size, sourceColumn))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameter"/> class that uses the parameter name and value.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="value">An <see cref="object"/> that is the value of the <see cref="WhippetPostgreSqlParameter"/>.</param>
        public WhippetPostgreSqlParameter(string parameterName, object value)
            : this(new NpgsqlParameter(parameterName, value))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameter"/> class.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="parameterType">One of the <see cref="NpgsqlTypes.NpgsqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <param name="sourceColumn">The name of the source column.</param>
        /// <param name="direction">One of the <see cref="ParameterDirection"/> values.</param>
        /// <param name="isNullable"><see langword="true"/> if the value of the field can be <see langword="null"/>; otherwise, <see langword="false"/>.</param>
        /// <param name="precision">The total number of digits to the left and right of the decimal point to which <see cref="Value"/> is resolved.</param>
        /// <param name="scale">The total number of decimal places to which <see cref="Value"/> is resolved.</param>
        /// <param name="sourceVersion">One of the <see cref="DataRowVersion"/> values.</param>
        /// <param name="value">An <see cref="object"/> that is the value of the <see cref="WhippetPostgreSqlParameter"/>.</param>
        public WhippetPostgreSqlParameter(string parameterName, NpgsqlDbType parameterType, int size, string sourceColumn, ParameterDirection direction, bool isNullable, byte precision, byte scale, DataRowVersion sourceVersion, object value)
            : this(new NpgsqlParameter(parameterName, parameterType, size, sourceColumn, direction, isNullable, precision, scale, sourceVersion, value))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlParameter"/> class.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="parameterType">One of the <see cref="System.Data.DbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <param name="sourceColumn">The name of the source column.</param>
        /// <param name="direction">One of the <see cref="ParameterDirection"/> values.</param>
        /// <param name="isNullable"><see langword="true"/> if the value of the field can be <see langword="null"/>; otherwise, <see langword="false"/>.</param>
        /// <param name="precision">The total number of digits to the left and right of the decimal point to which <see cref="Value"/> is resolved.</param>
        /// <param name="scale">The total number of decimal places to which <see cref="Value"/> is resolved.</param>
        /// <param name="sourceVersion">One of the <see cref="DataRowVersion"/> values.</param>
        /// <param name="value">An <see cref="object"/> that is the value of the <see cref="WhippetPostgreSqlParameter"/>.</param>
        public WhippetPostgreSqlParameter(string parameterName, DbType parameterType, int size, string sourceColumn, ParameterDirection direction, bool isNullable, byte precision, byte scale, DataRowVersion sourceVersion, object value)
            : this(new NpgsqlParameter(parameterName, parameterType, size, sourceColumn, direction, isNullable, precision, scale, sourceVersion, value))
        { }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public WhippetPostgreSqlParameter Clone()
        {
            return ((ICloneable)(this)).Clone() as WhippetPostgreSqlParameter;
        }
        
        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            return new WhippetPostgreSqlParameter(((ICloneable)(InternalParameter)).Clone() as NpgsqlParameter);
        }

        /// <summary>
        /// Resets the type associated with this <see cref="WhippetPostgreSqlParameter"/>.
        /// </summary>
        public override void ResetDbType()
        {
            InternalParameter.ResetDbType();
        }

        /// <summary>
        /// Gets a <see cref="string"/> that contains the <see cref="ParameterName"/>.
        /// </summary>
        /// <returns>Parameter name.</returns>
        public override string ToString()
        {
            return InternalParameter.ToString();
        }

        public static implicit operator WhippetPostgreSqlParameter(NpgsqlParameter parameter)
        {
            return (parameter == null) ? null : new WhippetPostgreSqlParameter(parameter);
        }

        public static implicit operator NpgsqlParameter(WhippetPostgreSqlParameter parameter)
        {
            return (parameter == null) ? null : parameter.InternalParameter;
        }
    }
}
