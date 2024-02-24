using System;
using Npgsql.Internal.Postgres;
using Npgsql.PostgresTypes;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a PostgreSQL multirange data type.
    /// </summary>
    /// <remarks>See <a href="https://www.postgresql.org/docs/current/static/rangetypes.html">PostgreSQL</a> for more information.</remarks>
    public sealed class WhippetPostgreSqlMultirangeType : IWhippetPostgreSqlType
    {
        /// <summary>
        /// Gets or sets the internal <see cref="PostgresRangeType"/> object.
        /// </summary>
        private PostgresMultirangeType InternalType
        { get; set; }

        /// <summary>
        /// Represents the data type's unique ID that identifies the type in a given database. This property is read-only.
        /// </summary>
        public uint OID
        {
            get
            {
                return InternalType.OID;
            }
        }

        /// <summary>
        /// Gets the data type's namespace (or schema). This property is read-only.
        /// </summary>
        public string Namespace
        {
            get
            {
                return InternalType.Namespace;
            }
        }

        /// <summary>
        /// Represents the data type's name. This property is read-only.
        /// </summary>
        public string Name
        {
            get
            {
                return InternalType.Name;
            }
        }

        /// <summary>
        /// Gets full name of the backend type (including its namespace). This property is read-only.
        /// </summary>
        public string FullName
        {
            get
            {
                return InternalType.FullName;
            }
        }

        /// <summary>
        /// Gets the display name for the backend type including the namespace unless it is <b>pg_catalog</b>. This property is read-only.
        /// </summary>
        public string DisplayName
        {
            get
            {
                return InternalType.DisplayName;
            }
        }

        /// <summary>
        /// Gets the data type's internal PostgreSQL name. This property is read-only.
        /// </summary>
        public string InternalName
        {
            get
            {
                return InternalType.InternalName;
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetPostgreSqlRangeType"/> of this multirange. This property is read-only.
        /// </summary>
        public WhippetPostgreSqlRangeType Subrange
        {
            get
            {
                return InternalType.Subrange == null ? null : new WhippetPostgreSqlRangeType(InternalType.Subrange);
            }
        }

        /// <summary>
        /// Data type if the type is a PostgreSQL array (if any). This property is read-only.
        /// </summary>
        public WhippetPostgreSqlArrayType Array
        {
            get
            {
                return InternalType.Array == null ? null : new WhippetPostgreSqlArrayType(InternalType.Array);
            }
        }
        
        /// <summary>
        /// Data type if the type is a PostgreSQL range (if any). This property is read-only.
        /// </summary>
        public WhippetPostgreSqlRangeType Range
        {
            get
            {
                return InternalType.Range == null ? null : new WhippetPostgreSqlRangeType(InternalType.Range);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlMultirangeType"/> class with no arguments.
        /// </summary>
        private WhippetPostgreSqlMultirangeType()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlMultirangeType"/> class with the specified <see cref="PostgresRangeType"/> object.
        /// </summary>
        /// <param name="type"><see cref="PostgresMultirangeType"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlMultirangeType(PostgresMultirangeType type)
            : this()
        {
            ArgumentNullException.ThrowIfNull(type);
            InternalType = type;
        }
        
        /// <summary>
        /// Returns the current instance as a <see cref="PostgresType"/> object.
        /// </summary>
        /// <returns><see cref="PostgresType"/> object.</returns>
        PostgresType IWhippetPostgreSqlType.ToPostgresType()
        {
            return InternalType;
        }

        public static implicit operator WhippetPostgreSqlMultirangeType(PostgresMultirangeType type)
        {
            return (type == null) ? null : new WhippetPostgreSqlMultirangeType(type);
        }

        public static implicit operator PostgresMultirangeType(WhippetPostgreSqlMultirangeType type)
        {
            return (type == null) ? null : type.InternalType;
        }
        
    }
}
