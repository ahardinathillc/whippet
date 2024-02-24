using System;
using Npgsql.Internal.Postgres;
using Npgsql.PostgresTypes;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a PostgreSQL range data type.
    /// </summary>
    /// <remarks>See <a href="https://www.postgresql.org/docs/current/static/rangetypes.html">PostgreSQL</a> for more information.</remarks>
    public sealed class WhippetPostgreSqlRangeType : IWhippetPostgreSqlType
    {
        /// <summary>
        /// Gets or sets the internal <see cref="PostgresRangeType"/> object.
        /// </summary>
        private PostgresRangeType InternalType
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
        /// Gets the <see cref="IWhippetPostgreSqlType"/> of the subtype of this range. This property is read-only.
        /// </summary>
        public IWhippetPostgreSqlType Subtype
        {
            get
            {
                return InternalType.Subtype == null ? null : new WhippetPostgreSqlType(InternalType.Subtype);
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetPostgreSqlMultirangeType"/> of the multirange of this range. This property is read-only.
        /// </summary>
        public WhippetPostgreSqlMultirangeType Multirange
        {
            get
            {
                return InternalType.Multirange == null ? null : new WhippetPostgreSqlMultirangeType(InternalType.Multirange);
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
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlRangeType"/> class with no arguments.
        /// </summary>
        private WhippetPostgreSqlRangeType()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlRangeType"/> class with the specified <see cref="PostgresRangeType"/> object.
        /// </summary>
        /// <param name="type"><see cref="PostgresRangeType"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlRangeType(PostgresRangeType type)
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

        public static implicit operator WhippetPostgreSqlRangeType(PostgresRangeType type)
        {
            return (type == null) ? null : new WhippetPostgreSqlRangeType(type);
        }

        public static implicit operator PostgresRangeType(WhippetPostgreSqlRangeType type)
        {
            return (type == null) ? null : type.InternalType;
        }
        
    }
}
