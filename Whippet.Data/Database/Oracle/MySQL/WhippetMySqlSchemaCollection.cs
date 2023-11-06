using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using Athi.Whippet.Data.Database.Oracle.MySQL.Extensions;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Represents a schema and its contents. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMySqlSchemaCollection
    {
        /// <summary>
        /// Gets or sets the internal <see cref="MySqlSchemaCollection"/> object.
        /// </summary>
        private MySqlSchemaCollection InternalCollection
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the schema.
        /// </summary>
        public string Name
        {
            get
            {
                return InternalCollection.Name;
            }
            set
            {
                InternalCollection.Name = value;
            }
        }

        /// <summary>
        /// Gets the list of columns in the schema. This property is read-only.
        /// </summary>
        public IReadOnlyList<WhippetMySqlSchemaColumn> Columns
        {
            get
            {
                return new List<WhippetMySqlSchemaColumn>(InternalCollection.Columns.Select(c => c.ToWhippetMySqlSchemaColumn())).AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the list of rows in the schema. This property is read-only.
        /// </summary>
        public IReadOnlyList<WhippetMySqlSchemaRow> Rows
        {
            get
            {
                return new List<WhippetMySqlSchemaRow>(InternalCollection.Rows.Select(r => new WhippetMySqlSchemaRow(r))).AsReadOnly();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlSchemaCollection"/> class with no arguments.
        /// </summary>
        public WhippetMySqlSchemaCollection()
            : this(new MySqlSchemaCollection())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlSchemaCollection"/> class with the specified name.
        /// </summary>
        /// <param name="name">Name of the schema.</param>
        public WhippetMySqlSchemaCollection(string name)
            : this(new MySqlSchemaCollection(name))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlSchemaCollection"/> class with the specified <see cref="DataTable"/>.
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/> to initialize with.</param>
        public WhippetMySqlSchemaCollection(DataTable dataTable)
            : this(new MySqlSchemaCollection(dataTable))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlSchemaCollection"/> class with the specified <see cref="MySqlSchemaCollection"/>.
        /// </summary>
        /// <param name="collection"><see cref="MySqlSchemaCollection"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetMySqlSchemaCollection(MySqlSchemaCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else
            {
                InternalCollection = collection;
            }
        }

        public static implicit operator WhippetMySqlSchemaCollection(MySqlSchemaCollection collection)
        {
            return (collection == null) ? null : new WhippetMySqlSchemaCollection(collection);
        }

        public static implicit operator MySqlSchemaCollection(WhippetMySqlSchemaCollection collection)
        {
            return (collection == null) ? null : collection.InternalCollection;
        }
    }
}

