using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Database.NoSQL;
using LiteDB;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Tools.DatabaseManager
{
    /// <summary>
    /// Represents a database that hosts Whippet.
    /// </summary>
    public class WhippetDatabase : WhippetNoSQLEntity, IWhippetNoSQLEntity, IWhippetActiveEntity, IEqualityComparer<WhippetDatabase>
    {
        private WhippetDatabaseType _type;

        private string _name;

        private BsonDocument _values;

        /// <summary>
        /// Gets or sets the <see cref="WhippetDatabaseType"/> of the current database.
        /// </summary>
        public virtual WhippetDatabaseType Type
        {
            get
            {
                if (_type == null)
                {
                    _type = new WhippetDatabaseType();
                }

                return _type;
            }
            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// Name to assign to the database entry.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Connection string assigned to the database. A connection string builder object is recommended to parse the individual pieces.
        /// </summary>
        public virtual string ConnectionString
        { get; set; }

        /// <summary>
        /// Specifies whether the current database is active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Gets a dictionary of all platform-specific properties and their assigned values. This property is read-only.
        /// </summary>
        public virtual BsonDocument OtherValues
        { 
            get
            {
                if (_values == null)
                {
                    _values = new BsonDocument();
                }

                return _values;
            }
            set
            {
                _values = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDatabase"/> class with no arguments.
        /// </summary>
        public WhippetDatabase()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDatabase"/> class.
        /// </summary>
        /// <param name="id">Unique ID of the entry.</param>
        /// <param name="name">Name to assign to the database entry.</param>
        /// <param name="active">Indicates whether the database entry is active.</param>
        /// <param name="connectionString">Connection string assigned to the database.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetDatabase(Guid id, string name, bool active, string connectionString)
            : base()
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                ID = id;
                Name = name;
                Active = active;
                ConnectionString = connectionString;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDatabase"/> class.
        /// </summary>
        /// <param name="name">Name to assign to the database entry.</param>
        /// <param name="active">Indicates whether the database entry is active.</param>
        /// <param name="connectionString">Connection string assigned to the database.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetDatabase(string name, bool active, string connectionString)
            : this(Guid.NewGuid(), name, active, connectionString)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as WhippetDatabase);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetDatabase obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="a">First object to compare.</param>
        /// <param name="b">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetDatabase a, WhippetDatabase b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase)
                    && a.Type.Equals(b.Type)
                    && a.Active == b.Active
                    && String.Equals(a.ConnectionString, b.ConnectionString, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(WhippetDatabase obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }
    }
}
