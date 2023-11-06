using System;
using MySql.Data.MySqlClient;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Represents a row within a schema. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMySqlSchemaRow
    {
        /// <summary>
        /// Gets or sets the internal <see cref="MySqlSchemaRow"/> object.
        /// </summary>
        private MySqlSchemaRow InternalObject
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlSchemaRow"/> object with no arguments.
        /// </summary>
        private WhippetMySqlSchemaRow()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlSchemaRow"/> object with the specified <see cref="MySqlSchemaRow"/> object.
        /// </summary>
        /// <param name="schemaRow"><see cref="MySqlSchemaRow"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetMySqlSchemaRow(MySqlSchemaRow schemaRow)
            : this()
        {
            if (schemaRow == null)
            {
                throw new ArgumentNullException(nameof(schemaRow));
            }
            else
            {
                InternalObject = schemaRow;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlSchemaRow"/> class with the specified <see cref="WhippetMySqlSchemaCollection"/> object.
        /// </summary>
        /// <param name="collection"><see cref="WhippetMySqlSchemaCollection"/> object to initialize with.</param>
        public WhippetMySqlSchemaRow(WhippetMySqlSchemaCollection collection)
            : this(new MySqlSchemaRow(collection))
        { }

        public static implicit operator WhippetMySqlSchemaRow(MySqlSchemaRow row)
        {
            return (row == null) ? null : new WhippetMySqlSchemaRow(row);
        }

        public static implicit operator MySqlSchemaRow(WhippetMySqlSchemaRow row)
        {
            return (row == null) ? null : row.InternalObject;
        }
    }
}

