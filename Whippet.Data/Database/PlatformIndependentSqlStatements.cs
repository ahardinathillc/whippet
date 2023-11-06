using System;
namespace Athi.Whippet.Data.Database
{
    /// <summary>
    /// Provides common SQL statements that are applicable to all database systems that utilize the SQL-92 or SQL-98 standard. This class cannot be inherited.
    /// </summary>
    public static class PlatformIndependentSqlStatements
    {
        /// <summary>
        /// Represents the <strong>NULL</strong> keyword.
        /// </summary>
        public const string NULL = "NULL";

        /// <summary>
        /// Generates a DELETE statement where only one column value is used to filter the rows to be deleted.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <param name="columnName">Column name.</param>
        /// <param name="value">Value used to filter rows.</param>
        /// <param name="isStringLiteral">If <see langword="true"/>, will decorate <paramref name="value"/> (if not already).</param>
        /// <returns>SQL statement.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string GenerateSingleDeleteStatement(string tableName, string columnName, string value, bool isStringLiteral = false)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(tableName);
            ArgumentNullException.ThrowIfNullOrEmpty(columnName);

            if (isStringLiteral)
            {
                if (!value.StartsWith('\''))
                {
                    value = '\'' + value;
                }

                if (!value.EndsWith('\''))
                {
                    value = value + '\\';
                }
            }

            return String.Format("DELETE FROM {0} WHERE {1}={2}", tableName, columnName, (value == null) ? NULL : value);
        }
    }
}

