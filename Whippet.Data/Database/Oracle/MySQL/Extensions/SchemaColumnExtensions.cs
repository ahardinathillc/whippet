using System;
using MySql.Data.MySqlClient;

namespace Athi.Whippet.Data.Database.Oracle.MySQL.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="SchemaColumn"/> objects. This class cannot be inherited.
    /// </summary>
    public static class SchemaColumnExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="SchemaColumn"/> object to a <see cref="WhippetMySqlSchemaColumn"/> object.
        /// </summary>
        /// <param name="column"><see cref="SchemaColumn"/> object to convert.</param>
        /// <returns><see cref="WhippetMySqlSchemaColumn"/> object.</returns>
        public static WhippetMySqlSchemaColumn ToWhippetMySqlSchemaColumn(this SchemaColumn column)
        {
            WhippetMySqlSchemaColumn wsCol = null;

            if (column != null)
            {
                if (column is WhippetMySqlSchemaColumn)
                {
                    wsCol = (WhippetMySqlSchemaColumn)(column);
                }
                else
                {
                    wsCol = new WhippetMySqlSchemaColumn() { Name = column.Name, Type = column.Type };
                }
            }

            return wsCol;
        }
    }
}
