using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Represents a parameter to a <see cref="WhippetMySqlCommand"/> object. This class cannot be inherited.
    /// </summary>
    public class WhippetMySqlParameter : DbParameter, IDataParameter, IDbDataParameter, ICloneable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="MySqlParameter"/> object.
        /// </summary>
        private MySqlParameter InternalParameter
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
        /// Gets or sets the <see cref="MySql.Data.MySqlClient.MySqlDbType"/> of the parameter.
        /// </summary>
        public MySqlDbType MySqlDbType
        {
            get
            {
                return InternalParameter.MySqlDbType;
            }
            set
            {
                InternalParameter.MySqlDbType = value;
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
        /// Returns the possible values for this parameter if this paramter is of type <see cref="MySql.Data.MySqlClient.MySqlDbType.Set"/> or <see cref="MySql.Data.MySqlClient.MySqlDbType.Enum"/>. Otherwise, <see langword="null"/> is returned. This property is read-only.
        /// </summary>
        public IList PossibleValues
        {
            get
            {
                return InternalParameter.PossibleValues;
            }
        }

        /// <summary>
        /// Gets or sets the name of the <see cref="WhippetMySqlParameter"/>.
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
        /// Initializes a new instance of the <see cref="WhippetMySqlParameter"/> class with no arguments.
        /// </summary>
        public WhippetMySqlParameter()
            : this(new MySqlParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlParameter"/> class with the specified <see cref="MySqlParameter"/>.
        /// </summary>
        /// <param name="parameter"><see cref="MySqlParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetMySqlParameter(MySqlParameter parameter)
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
        /// Initializes a new instance of the <see cref="WhippetMySqlParameter"/> class that uses the parameter name and data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="MySql.Data.MySqlClient.MySqlDbType"/> values.</param>
        /// <exception cref="ArgumentException" />
        public WhippetMySqlParameter(string parameterName, MySqlDbType dbType)
            : this(new MySqlParameter(parameterName, dbType))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlParameter"/> class that uses the parameter name, data type, and size.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="MySql.Data.MySqlClient.MySqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <exception cref="ArgumentException" />
        public WhippetMySqlParameter(string parameterName, MySqlDbType dbType, int size)
            : this(new MySqlParameter(parameterName, dbType, size))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlParameter"/> class.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="MySql.Data.MySqlClient.MySqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <param name="direction">One of the <see cref="ParameterDirection"/> values.</param>
        /// <param name="isNullable"><see langword="true"/> if the value of the field can be <see langword="null"/>; otherwise, <see langword="false"/>.</param>
        /// <param name="precision">The total number of digits to the left and right of the decimal point to which <see cref="Value"/> is resolved.</param>
        /// <param name="scale">The total number of decimal places to which <see cref="Value"/> is resolved.</param>
        /// <param name="sourceColumn">The name of the source column if this <see cref="WhippetMySqlParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        /// <param name="sourceVersion">One of the <see cref="DataRowVersion"/> values.</param>
        /// <param name="value">An <see cref="object"/> that is the value of the <see cref="WhippetMySqlParameter"/>.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public WhippetMySqlParameter(string parameterName, MySqlDbType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
            : this(new MySqlParameter(parameterName, dbType, size, direction, isNullable, precision, scale, sourceColumn, sourceVersion, value))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlParameter"/> class that uses the parameter name, the <see cref="MySql.Data.MySqlClient.MySqlDbType"/>, the size, and the source column name.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="MySql.Data.MySqlClient.MySqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <param name="sourceColumn">The name of the source column if this <see cref="WhippetMySqlParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        public WhippetMySqlParameter(string parameterName, MySqlDbType dbType, int size, string sourceColumn)
            : this(new MySqlParameter(parameterName, dbType, size, sourceColumn))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlParameter"/> class that uses the parameter name and value.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="value">An <see cref="object"/> that is the value of the <see cref="WhippetMySqlParameter"/>.</param>
        public WhippetMySqlParameter(string parameterName, object value)
            : this(new MySqlParameter(parameterName, value))
        { }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            return new WhippetMySqlParameter(((ICloneable)(InternalParameter)).Clone() as MySqlParameter);
        }

        /// <summary>
        /// Resets the type associated with this <see cref="WhippetMySqlParameter"/>.
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

        public static implicit operator WhippetMySqlParameter(MySqlParameter parameter)
        {
            return (parameter == null) ? null : new WhippetMySqlParameter(parameter);
        }

        public static implicit operator MySqlParameter(WhippetMySqlParameter parameter)
        {
            return (parameter == null) ? null : parameter.InternalParameter;
        }
    }
}
