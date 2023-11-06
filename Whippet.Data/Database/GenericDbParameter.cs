using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using Humanizer;
using NHibernate.Mapping;

namespace Athi.Whippet.Data.Database
{
    /// <summary>
    /// Provides a generic implementation of <see cref="DbParameter"/> that is independent of a data store vendor. This class cannot be inherited.
    /// </summary>
    public sealed class GenericDbParameter : DbParameter, IDbDataParameter, IDataParameter, ICloneable
    {
        /// <summary>
        /// Gets or sets the <see cref="System.Data.DbType"/> of the parameter.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [RefreshProperties(RefreshProperties.All)]
        public override DbType DbType
        { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.
        /// </summary>
        [DefaultValue(ParameterDirection.Input)]
        [RefreshProperties(RefreshProperties.All)]
        public override ParameterDirection Direction
        { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the parameter accepts null values.
        /// </summary>
        [Browsable(false)]
        [DesignOnly(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsNullable
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="DbParameter"/>.
        /// </summary>
        [DefaultValue("")]
        public override string ParameterName
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum size, in bytes, of the data within the column.
        /// </summary>
        public override int Size
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the source column mapped to the <see cref="DataSet"/> and used for loading or returning the <see cref="Value"/>.
        /// </summary>
        [DefaultValue("")]
        public override string SourceColumn
        { get; set; }

        /// <summary>
        /// Gets or sets a value which indicates whether the source column is nullable. This allows <see cref="DbCommandBuilder"/> to correctly generate Update statements for nullable columns.
        /// </summary>
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [RefreshProperties(RefreshProperties.All)]
        public override bool SourceColumnNullMapping
        { get; set; }

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.All)]
        public override object Value
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDbParameter"/> class with no arguments.
        /// </summary>
        public GenericDbParameter()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDbParameter"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        public GenericDbParameter(string name, object value)
            : this()
        {
            ParameterName = name;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDbParameter"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        /// <param name="dbType">Parameter value type.</param>
        public GenericDbParameter(string name, object value, DbType dbType)
            : this(name, value)
        {
            DbType = dbType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDbParameter"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        /// <param name="dbType">Parameter value type.</param>
        /// <param name="direction">Parameter direction.</param>
        public GenericDbParameter(string name, object value, DbType dbType, ParameterDirection direction)
            : this(name, value, dbType)
        {
            Direction = direction;
        }

        /// <summary>
        /// Resets the DbType property to its original settings.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override void ResetDbType()
        {
            DbType = default(DbType);
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public GenericDbParameter Clone()
        {
            GenericDbParameter parameter = new GenericDbParameter(ParameterName, Value, DbType, Direction);

            parameter.IsNullable = IsNullable;
            parameter.Precision = Precision;
            parameter.Scale = Scale;
            parameter.Size = Size;
            parameter.SourceColumn = SourceColumn;
            parameter.SourceColumnNullMapping = SourceColumnNullMapping;
            parameter.SourceVersion = SourceVersion;

            return parameter;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(ParameterName) ? base.ToString() : ParameterName + " (" + Convert.ToString(DbType) + ")";
        }

        /// <summary>
        /// Converts the current <see cref="GenericDbParameter"/> to an <see cref="IDbDataParameter"/> of the specified type.
        /// </summary>
        /// <typeparam name="T"><see cref="IDbDataParameter"/> type to convert the current instance into.</typeparam>
        /// <returns>Instance of type <typeparamref name="T"/> that contains the current parameter values.</returns>
        public T ToParameterType<T>() where T : IDbDataParameter, new()
        {
            T parameter = new T();

            parameter.ParameterName = ParameterName;
            parameter.Value = Value;
            parameter.DbType = DbType;
            parameter.Direction = Direction;
            parameter.Precision = Precision;
            parameter.Scale = Scale;
            parameter.Size = Size;
            parameter.SourceColumn = SourceColumn;
            parameter.SourceVersion = SourceVersion;

            if (parameter is DbParameter)
            {
                ((DbParameter)((object)(parameter))).IsNullable = IsNullable;
                ((DbParameter)((object)(parameter))).SourceColumnNullMapping = SourceColumnNullMapping;
            }

            return parameter;
        }
    }
}

