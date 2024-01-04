using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;

namespace Athi.Whippet.Data.NHibernate.FluentNHibernate
{
    /// <summary>
    /// Base class for all <see cref="IWhippetEntity"/> mappings. This class must be inherited.
    /// </summary>
    /// <typeparam name="T"><see cref="IWhippetEntity"/> object that is to be mapped.</typeparam>
    /// <remarks>See https://github.com/nhibernate/fluent-nhibernate/wiki/Fluent-mapping for more information.</remarks>
    public abstract class WhippetFluentMap<T> : ClassMap<T>, IMappingProvider where T : IWhippetEntity, new()
    {
        private static object _syncRoot;

        protected const string DEFAULT_SCHEMA = "Whippet";

        private Dictionary<string, IReadOnlyList<IDbDataParameter>> _rawSqlProcedures;

        /// <summary>
        /// Provides a collection of raw SQL statements that provide ad-hoc stored procedures for the entity. This property is read-only.
        /// </summary>
        public IReadOnlyDictionary<string, IReadOnlyList<IDbDataParameter>> RawSqlProcedures
        {
            get
            {
                return InternalRawSqlProcedures;
            }
        }

        /// <summary>
        /// Gets the internal <see cref="IDictionary{TKey, TValue}"/> collection of raw SQL statements that provide ad-hoc stored procedures for the entity. This property is read-only.
        /// </summary>
        protected virtual Dictionary<string, IReadOnlyList<IDbDataParameter>> InternalRawSqlProcedures
        {
            get
            {
                if (_rawSqlProcedures == null)
                {
                    _rawSqlProcedures = new Dictionary<string, IReadOnlyList<IDbDataParameter>>();
                }

                return _rawSqlProcedures;
            }
        }

        /// <summary>
        /// Gets an <see cref="object"/> instance used for invoking object extension methods. This property is read-only.
        /// </summary>
        protected static object ObjectExtensionMethods
        {
            get
            {
                if (_syncRoot == null)
                {
                    _syncRoot = new object();
                }

                return _syncRoot;
            }
        }

        /// <summary>
        /// Gets the default primary key column name for the entity for mapping. Override this property to change the primary key column name that will be mapped in the data source. This property is read-only.
        /// </summary>
        protected virtual string DefaultPrimaryKeyColumnName
        {
            get
            {
                return nameof(IWhippetEntity.ID);
            }
        }

        /// <summary>
        /// Gets the length value that instructs Fluent NHibernate to create an NVARCHAR(MAX) column. This property is read-only.
        /// </summary>
        protected static int SqlServerNVarCharMaxLength
        {
            get
            {
                return 4001;
            }
        }

        /// <summary>
        /// Gets the custom SQL type to create a VARBINARY(MAX) column in Fluent NHibernate. This property is read-only.
        /// </summary>
        protected static string SqlServerVarBinaryMaxCustomType
        {
            get
            {
                return "VARBINARY (MAX)";
            }
        }

        /// <summary>
        /// Gets the fully qualified table name of the current mapping. This property is read-only.
        /// </summary>
        public string FullyQualifiedTableName
        {
            get
            {
                return String.IsNullOrWhiteSpace(TableSchema) ? TableName : TableSchema + "." + TableName;
            }
        }

        /// <summary>
        /// Gets the mapping's schema. This property is read-only.
        /// </summary>
        public virtual string TableSchema
        { get; private set; }

        /// <summary>
        /// Gets the mapping's table. This property is read-only.
        /// </summary>
        public virtual string TableName
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetFluentMap{T}"/> class with no arguments. Will default the primary key to <see cref="DefaultPrimaryKeyColumnName"/>.
        /// </summary>
        private WhippetFluentMap()
            : this(String.Empty, String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetFluentMap{T}"/> class with the specified parameters.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected WhippetFluentMap(string table, string schema = DEFAULT_SCHEMA, bool useDefaultPrimaryKeyBinding = true)
            : base()
        {
            if (String.IsNullOrWhiteSpace(schema))
            {
                schema = DEFAULT_SCHEMA;
            }

            ConfigureDefaultBindings(table, schema, useDefaultPrimaryKeyBinding);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetFluentMap{T}"/> class with the specified attribute store and mapping providers.
        /// </summary>
        /// <param name="attributes">Attributes to apply to the entity.</param>
        /// <param name="providers">Mapping providers.</param>
        protected WhippetFluentMap(AttributeStore attributes, MappingProviderStore providers)
            : base(attributes, providers)
        { }

        /// <summary>
        /// On SQL Server for Linux, values that are not MAX are getting cut in half, possibly due to collation or unicode storage. To ensure that the right length is kept in tact, this method will adjust the value provided so that SQL Server will reflect it.
        /// </summary>
        /// <param name="value">Original length value.</param>
        /// <returns>Adjusted length value that will be adjusted by SQL Server for Linux.</returns>
        protected virtual int AdjustNvarCharSizeForSqlServer(int value)
        {
            return value * 2;
        }

        /// <summary>
        /// Configures the default bindings and map setup. This is method is called from the constructor.
        /// </summary>
        /// <param name="table">Name of the table the entity is bound to.</param>
        /// <param name="schema">Schema the table is a member of. The schema must already exist in the database.</param>
        /// <param name="useDefaultPrimaryKeyBinding">If <see langword="true"/>, will default to using the default primary key column specified by <see cref="DefaultPrimaryKeyColumnName"/>. Otherwise, will not set any identity bindings.</param>
        protected virtual void ConfigureDefaultBindings(string table, string schema, bool useDefaultPrimaryKeyBinding)
        {
            if (useDefaultPrimaryKeyBinding)
            {
                Id(x => x.ID)
                    .Column(DefaultPrimaryKeyColumnName)
                    .Not.Nullable()
                    .UniqueKey(DefaultPrimaryKeyColumnName);
            }

            if (!String.IsNullOrWhiteSpace(schema))
            {
                Schema(schema);
            }

            if (!String.IsNullOrWhiteSpace(table))
            {
                Table(table);
            }

            TableSchema = schema;
            TableName = table;
        }

        /// <summary>
        /// Assigns the specified prefix to the given table name.
        /// </summary>
        /// <param name="tableName">Name of the table to assign the prefix to.</param>
        /// <param name="prefix">Prefix to assign to the table name.</param>
        /// <param name="withSquareBrackets">If <see langword="true"/>, will enclose the completed name in square brackets.</param>
        /// <returns>Table name decorated with the specified prefix.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected static string PrefixTableName(string prefix, string tableName, bool withSquareBrackets = true)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(tableName);
            return PrefixTableName(new[] { prefix }, tableName);
        }
        
        /// <summary>
        /// Assigns the specified prefixes to the given table name.
        /// </summary>
        /// <param name="prefixes">Prefixes to assign to the table name.</param>
        /// <param name="tableName">Name of the table to assign the prefixes to.</param>
        /// <param name="withSquareBrackets">If <see langword="true"/>, will enclose the completed name in square brackets.</param>
        /// <returns>Table name decorated with the specified prefixes.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected static string PrefixTableName(IEnumerable<string> prefixes, string tableName, bool withSquareBrackets = true)
        {
            if (String.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException(nameof(tableName));
            }
            else
            {
                StringBuilder builder = new StringBuilder();

                if (withSquareBrackets)
                {
                    builder.Append('[');
                }
                
                if (prefixes != null)
                {
                    foreach (string prefix in prefixes)
                    {
                        if (!String.IsNullOrWhiteSpace(prefix))
                        {
                            builder.Append(prefix);

                            if (!prefix.EndsWith('.'))
                            {
                                builder.Append('.');
                            }

                            builder.Replace("..", ".");     // retro-fix for instances where two periods are present
                        }
                    }
                }

                builder.Append(tableName);

                if (withSquareBrackets)
                {
                    builder.Append(']');
                }
                
                return builder.ToString();
            }
        }

        /// <summary>
        /// Decorates the specified column name to ensure that it does not clash with a reserved keyword.
        /// </summary>
        /// <param name="columnName">Column name to decorate.</param>
        /// <returns>Decorated column name.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected static string MakeReservedWordColumnName(string columnName)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(columnName);
            return "__" + columnName + "__";
        }
    }
}
