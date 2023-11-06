using System;
using System.Text;
using SqlKata;
using SqlKata.Execution;

namespace Athi.Whippet.Data.Extensions.SqlKata
{
    /// <summary>
    /// Provides extension methods to <see cref="QueryFactory"/> objects. This class cannot be inherited.
    /// </summary>
    public static class QueryFactoryExtensions
    {
        /// <summary>
        /// Creates an alias statement for the specified SQL object.
        /// </summary>
        /// <param name="factory"><see cref="QueryFactory"/> object.</param>
        /// <param name="sqlObject">SQL object to create the alias for.</param>
        /// <param name="aliasName">Alias name to apply in the SQL statement.</param>
        /// <param name="includeAs">If <see langword="true"/>, will include the SQL "AS" keyword in the alias definition.</param>
        /// <returns>SQL statement that aliases the specified <paramref name="sqlObject"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string CreateAlias(this QueryFactory factory, string sqlObject, string aliasName, bool includeAs)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(sqlObject);
            ArgumentNullException.ThrowIfNullOrEmpty(aliasName);

            return sqlObject + " " + (includeAs ? "AS " : "") + aliasName;
        }

        /// <summary>
        /// Creates an accessor statement in the form of [schema].[object].[column].
        /// </summary>
        /// <param name="factory"><see cref="QueryFactory"/> object.</param>
        /// <param name="schema">Database schema (if any).</param>
        /// <param name="table">Table or object name.</param>
        /// <param name="column">Column name.</param>
        /// <returns>SQL statement.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string SchemaColumn(this QueryFactory factory, string schema, string table, string column)
        {
            StringBuilder builder = null;

            ArgumentNullException.ThrowIfNullOrEmpty(table);
            ArgumentNullException.ThrowIfNullOrEmpty(column);

            builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(schema))
            {
                builder.Append(schema);

                if (!builder.ToString().EndsWith('.'))
                {
                    builder.Append('.');
                }
            }

            builder.Append(table);

            if (!builder.ToString().EndsWith('.'))
            {
                builder.Append('.');
            }

            builder.Append(column);

            return builder.ToString();
        }

        /// <summary>
        /// Creates an accessor statement in the form of [schema].[object].[column].
        /// </summary>
        /// <param name="factory"><see cref="QueryFactory"/> object.</param>
        /// <param name="table">Table or object name.</param>
        /// <param name="column">Column name.</param>
        /// <returns>SQL statement.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string SchemaColumn(this QueryFactory factory, string table, string column)
        {
            return SchemaColumn(factory, null, table, column);
        }
    }
}

