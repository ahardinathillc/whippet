using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;

namespace Athi.Whippet.Data.Database.Microsoft
{
    /// <summary>
    /// Represents a parameter to a <see cref="WhippetSqlServerCommand"/> and optionally its mapping to <see cref="DataSet"/> columns. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetSqlServerParameter : DbParameter, IDataParameter, IDbDataParameter, ICloneable
    {
        /// <summary>
        /// Gets or sets the internal <see cref="SqlParameter"/> object.
        /// </summary>
        private SqlParameter InternalParameter
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SqlCompareOptions"/> value that defines how string comparisons should be performed for this parameter.
        /// </summary>
        [Browsable(false)]
        public SqlCompareOptions CompareInfo
        {
            get
            {
                return InternalParameter.CompareInfo;
            }
            set
            {
                InternalParameter.CompareInfo = value;
            }
        }

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
        /// Enforces encryption of a parameter when using Always Encrypted. If SQL Server informs the driver that the parameter does not need to be encrypted, the query 
        /// using the parameter will fail. This property provides additional protection against security attacks that involve a compromised SQL Server providing incorrect 
        /// encryption metadata to the client, which may lead to data disclosure.
        /// </summary>
        public bool ForceColumnEncryption
        {
            get
            {
                return InternalParameter.ForceColumnEncryption;
            }
            set
            {
                InternalParameter.ForceColumnEncryption = value;
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
        /// Specifies the locale identifier that determines conventions and language for a particular region.
        /// </summary>
        [Browsable(false)]
        public int LocaleId
        {
            get
            {
                return InternalParameter.LocaleId;
            }
            set
            {
                InternalParameter.LocaleId = value;
            }
        }

        /// <summary>
        /// Specifies the offset to the <see cref="Value"/> property.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public int Offset
        {
            get
            {
                return InternalParameter.Offset;
            }
            set
            {
                InternalParameter.Offset = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the <see cref="WhippetSqlServerParameter"/>.
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
        /// Sets or gets a value which indicates whether the source column is nullable. This allows <see cref="WhippetSqlServerCommandBuilder"/> to correctly generate update statements for nullable columns.
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
        /// Gets or sets the database data type of the parameter.
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        [DbProviderSpecificTypeProperty(true)]
        public SqlDbType SqlDbType
        {
            get
            {
                return InternalParameter.SqlDbType;
            }
            set
            {
                InternalParameter.SqlDbType = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the parameter as an SQL type.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SqlValue
        {
            get
            {
                return InternalParameter.SqlValue;
            }
            set
            {
                InternalParameter.SqlValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the type name for a table-valued parameter.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public string TypeName
        {
            get
            {
                return InternalParameter.TypeName;
            }
            set
            {
                InternalParameter.TypeName = value;
            }
        }

        /// <summary>
        /// Gets or sets a string that represents a user-defined type as a parameter.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public string UdtTypeName
        {
            get
            {
                return InternalParameter.UdtTypeName;
            }
            set
            {
                InternalParameter.UdtTypeName = value;
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
        /// Gets or sets the name of the database where the schema collection for this XML instance is located.
        /// </summary>
        public string XmlSchemaCollectionDatabase
        {
            get
            {
                return InternalParameter.XmlSchemaCollectionDatabase;
            }
            set
            {
                InternalParameter.XmlSchemaCollectionDatabase = value;
            }
        }

        /// <summary>
        /// Specifies the name of the schema collection for this XML instance.
        /// </summary>
        public string XmlSchemaCollectionName
        {
            get
            {
                return InternalParameter.XmlSchemaCollectionName;
            }
            set
            {
                InternalParameter.XmlSchemaCollectionName = value;
            }
        }

        /// <summary>
        /// Specifies the owning relational schema where the schema collection for this XML instance is located.
        /// </summary>
        public string XmlSchemaCollectionOwningSchema
        {
            get
            {
                return InternalParameter.XmlSchemaCollectionOwningSchema;
            }
            set
            {
                InternalParameter.XmlSchemaCollectionOwningSchema = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerParameter"/> class with no arguments.
        /// </summary>
        public WhippetSqlServerParameter()
            : this(new SqlParameter())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerParameter"/> class with the specified <see cref="SqlParameter"/>.
        /// </summary>
        /// <param name="parameter"><see cref="SqlParameter"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSqlServerParameter(SqlParameter parameter)
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
        /// Initializes a new instance of the <see cref="WhippetSqlServerParameter"/> class that uses the parameter name and data type.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <exception cref="ArgumentException" />
        public WhippetSqlServerParameter(string parameterName, SqlDbType dbType)
            : this(new SqlParameter(parameterName, dbType))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerParameter"/> class that uses the parameter name, data type, and size.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <exception cref="ArgumentException" />
        public WhippetSqlServerParameter(string parameterName, SqlDbType dbType, int size)
            : this(new SqlParameter(parameterName, dbType, size))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerParameter"/> class.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <param name="direction">One of the <see cref="ParameterDirection"/> values.</param>
        /// <param name="isNullable"><see langword="true"/> if the value of the field can be <see langword="null"/>; otherwise, <see langword="false"/>.</param>
        /// <param name="precision">The total number of digits to the left and right of the decimal point to which <see cref="Value"/> is resolved.</param>
        /// <param name="scale">The total number of decimal places to which <see cref="Value"/> is resolved.</param>
        /// <param name="sourceColumn">The name of the source column if this <see cref="WhippetSqlServerParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        /// <param name="sourceVersion">One of the <see cref="DataRowVersion"/> values.</param>
        /// <param name="value">An <see cref="object"/> that is the value of the <see cref="WhippetSqlServerParameter"/>.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public WhippetSqlServerParameter(string parameterName, SqlDbType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
            : this(new SqlParameter(parameterName, dbType, size, direction, isNullable, precision, scale, sourceColumn, sourceVersion, value))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerParameter"/> class.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <param name="direction">One of the <see cref="ParameterDirection"/> values.</param>
        /// <param name="precision">The total number of digits to the left and right of the decimal point to which <see cref="Value"/> is resolved.</param>
        /// <param name="scale">The total number of decimal places to which <see cref="Value"/> is resolved.</param>
        /// <param name="sourceColumn">The name of the source column if this <see cref="WhippetSqlServerParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        /// <param name="sourceVersion">One of the <see cref="DataRowVersion"/> values.</param>
        /// <param name="sourceColumnNullMapping"><see langword="true"/> if the source column is nullable; otherwise, <see langword="false"/>.</param>
        /// <param name="value">An <see cref="object"/> that is the value of the <see cref="WhippetSqlServerParameter"/>.</param>
        /// <param name="xmlSchemaCollectionDatabase">The name of the database where the schema collection for this XML instance is located.</param>
        /// <param name="xmlSchemaCollectionOwningSchema">The owning relational schema where the schema collection for this XML instance is located.</param>
        /// <param name="xmlSchemaCollectionName">The name of the schema collection for this parameter.</param>
        public WhippetSqlServerParameter(string parameterName, SqlDbType dbType, int size, ParameterDirection direction, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, bool sourceColumnNullMapping, object value, string xmlSchemaCollectionDatabase, string xmlSchemaCollectionOwningSchema, string xmlSchemaCollectionName)
            : this(new SqlParameter(parameterName, dbType, size, direction, precision, scale, sourceColumn, sourceVersion, sourceColumnNullMapping, value, xmlSchemaCollectionDatabase, xmlSchemaCollectionOwningSchema, xmlSchemaCollectionName))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerParameter"/> class that uses the parameter name, the <see cref="System.Data.SqlDbType"/>, the size, and the source column name.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="dbType">One of the <see cref="System.Data.SqlDbType"/> values.</param>
        /// <param name="size">The length of the parameter.</param>
        /// <param name="sourceColumn">The name of the source column if this <see cref="WhippetSqlServerParameter"/> is used in a call to <see cref="DbDataAdapter.Update(DataSet)"/>.</param>
        public WhippetSqlServerParameter(string parameterName, SqlDbType dbType, int size, string sourceColumn)
            : this(new SqlParameter(parameterName, dbType, size, sourceColumn))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSqlServerParameter"/> class that uses the parameter name and value.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to map.</param>
        /// <param name="value">An <see cref="object"/> that is the value of the <see cref="WhippetSqlServerParameter"/>.</param>
        public WhippetSqlServerParameter(string parameterName, object value)
            : this(new SqlParameter(parameterName, value))
        { }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            return new WhippetSqlServerParameter(((ICloneable)(InternalParameter)).Clone() as SqlParameter);
        }

        /// <summary>
        /// Resets the type associated with this <see cref="WhippetSqlServerParameter"/>.
        /// </summary>
        public override void ResetDbType()
        {
            InternalParameter.ResetDbType();
        }

        /// <summary>
        /// Resets the type associated with this <see cref="WhippetSqlServerParameter"/>.
        /// </summary>
        public void ResetSqlDbType()
        {
            InternalParameter.ResetSqlDbType();
        }

        /// <summary>
        /// Gets a <see cref="string"/> that contains the <see cref="ParameterName"/>.
        /// </summary>
        /// <returns>Parameter name.</returns>
        public override string ToString()
        {
            return InternalParameter.ToString();
        }

        public static implicit operator WhippetSqlServerParameter(SqlParameter parameter)
        {
            return (parameter == null) ? null : new WhippetSqlServerParameter(parameter);
        }

        public static implicit operator SqlParameter(WhippetSqlServerParameter parameter)
        {
            return (parameter == null) ? null : parameter.InternalParameter;
        }
    }
}
