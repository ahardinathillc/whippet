using System;
using Npgsql.PostgresTypes;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a PostgreSQL array data type which can hold multiple values in a single column. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetPostgreSqlArrayType : IWhippetPostgreSqlType
    {
        /// <summary>
        /// Gets or sets the internal <see cref="PostgresArrayType"/> object.
        /// </summary>
        private PostgresArrayType InternalType
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
        /// Data type if the type is a PostgreSQL array (if any). This property is read-only.
        /// </summary>
        public WhippetPostgreSqlArrayType Array
        {
            get
            {
                return InternalType.Array;
            }
        }

        /// <summary>
        /// Data type if the type is a PostgreSQL range (if any). This property is read-only.
        /// </summary>
        public WhippetPostgreSqlRangeType Range
        {
            get
            {
                return InternalType.Range;
            }
        }

        /// <summary>
        /// Gets the PostgreSQL data type of the element contained within this array. This property is read-only.
        /// </summary>
        public IWhippetPostgreSqlType Element
        {
            get
            {
                return (InternalType.Element == null) ? null : new WhippetPostgreSqlType(InternalType.Element);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlArrayType"/> class with no arguments.
        /// </summary>
        private WhippetPostgreSqlArrayType()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPostgreSqlArrayType"/> class with the specified <see cref="PostgresArrayType"/> object.
        /// </summary>
        /// <param name="type"><see cref="PostgresArrayType"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetPostgreSqlArrayType(PostgresArrayType type)
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

        public static implicit operator WhippetPostgreSqlArrayType(PostgresArrayType type)
        {
            return (type == null) ? null : new WhippetPostgreSqlArrayType(type);
        }

        public static implicit operator PostgresArrayType(WhippetPostgreSqlArrayType type)
        {
            return (type == null) ? null : type.InternalType;
        }
    }
}
