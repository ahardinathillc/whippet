using System;
using Npgsql.Internal.Postgres;
using Npgsql.PostgresTypes;

namespace Athi.Whippet.Data.Database.PostgreSQL
{
    /// <summary>
    /// Represents a PostgreSQL data type as discovered from <b>pg_type</b>.
    /// </summary>
    public interface IWhippetPostgreSqlType
    {
        /// <summary>
        /// Represents the data type's unique ID that identifies the type in a given database. This property is read-only.
        /// </summary>
        uint OID
        { get; }

        /// <summary>
        /// Gets the data type's namespace (or schema). This property is read-only.
        /// </summary>
        string Namespace
        { get; }

        /// <summary>
        /// Represents the data type's name. This property is read-only.
        /// </summary>
        string Name
        { get; }

        /// <summary>
        /// Gets full name of the backend type (including its namespace). This property is read-only.
        /// </summary>
        string FullName
        { get; }

        /// <summary>
        /// Gets the display name for the backend type including the namespace unless it is <b>pg_catalog</b>. This property is read-only.
        /// </summary>
        string DisplayName
        { get; }

        /// <summary>
        /// Gets the data type's internal PostgreSQL name. This property is read-only.
        /// </summary>
        string InternalName
        { get; }
        
        /// <summary>
        /// Data type if the type is a PostgreSQL array (if any). This property is read-only.
        /// </summary>
        WhippetPostgreSqlArrayType Array
        { get; }
        
        /// <summary>
        /// Data type if the type is a PostgreSQL range (if any). This property is read-only.
        /// </summary>
        WhippetPostgreSqlRangeType Range
        { get; }

        /// <summary>
        /// Returns the current instance as a <see cref="PostgresType"/> object.
        /// </summary>
        /// <returns><see cref="PostgresType"/> object.</returns>
        PostgresType ToPostgresType();
    }
}
