using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Database.NoSQL;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Tools.DatabaseManager
{
    /// <summary>
    /// Represents a database type (e.g., Microsoft SQL Server, MySQL, etc.) that Whippet can connect to.
    /// </summary>
    public class WhippetDatabaseType : WhippetNoSQLEntity, IWhippetNoSQLEntity, IWhippetActiveEntity, IEqualityComparer<WhippetDatabaseType>
    {
        private static readonly Guid DB_TYPE_SQLSERVER = new Guid("08ff013f-7c4d-4a37-945a-dcb5ad92ca4b");

        private string _name;

        private static List<WhippetDatabaseType> _knownTypes;

        /// <summary>
        /// Gets all primitive known database types to Whippet. This property is read-only.
        /// </summary>
        public static IReadOnlyList<WhippetDatabaseType> KnownTypes
        {
            get
            {
                if (_knownTypes == null)
                {
                    _knownTypes = new List<WhippetDatabaseType>();
                    _knownTypes.Add(new WhippetDatabaseType(DB_TYPE_SQLSERVER, "Microsoft SQL Server", true) { KnownType = WhippetDatabaseKnownType.SqlServer });
                }

                return _knownTypes.AsReadOnly();
            }
        }

        /// <summary>
        /// Name of the database type that describes the platform that hosts the database.
        /// </summary>
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
        /// Specifies whether the type is currently active.
        /// </summary>
        public virtual bool Active
        { get; set; }

        /// <summary>
        /// Gets the <see cref="WhippetDatabaseKnownType"/> value for the current <see cref="WhippetDatabaseType"/> object. This property is read-only.
        /// </summary>
        public WhippetDatabaseKnownType KnownType
        { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDatabaseType"/> class with no arguments.
        /// </summary>
        public WhippetDatabaseType()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDatabaseType"/> class.
        /// </summary>
        /// <param name="id">Record ID of the <see cref="WhippetDatabaseType"/>.</param>
        /// <param name="name">Name of the database type.</param>
        /// <param name="active">Specifies whether the type is currently active.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDatabaseType(Guid id, string name, bool active)
            : this()
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
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDatabaseType"/> class.
        /// </summary>
        /// <param name="name">Name of the database type.</param>
        /// <param name="active">Specifies whether the type is currently active.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDatabaseType(string name, bool active)
            : this(Guid.NewGuid(), name, active)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as WhippetDatabaseType);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetDatabaseType obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="a">First object to compare.</param>
        /// <param name="b">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetDatabaseType a, WhippetDatabaseType b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase) && (a.Active == b.Active);
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
        public int GetHashCode(WhippetDatabaseType obj)
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
