using System;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Represents a security category for a view in Whippet. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetViewSecurityCategory : IEqualityComparer<WhippetViewSecurityCategory>
    {
        /// <summary>
        /// Gets the unique ID of the <see cref="WhippetViewSecurityCategory"/>. This property is read-only.
        /// </summary>
        public Guid ID
        { get; private set; }

        /// <summary>
        /// Gets the name of the <see cref="WhippetViewSecurityCategory"/>. This property is read-only.
        /// </summary>
        public string Name
        { get; private set; }

        /// <summary>
        /// Gets the parent <see cref="WhippetViewSecurityCategory"/> object that the current instance belongs to. This property is read-only.
        /// </summary>
        public WhippetViewSecurityCategory Parent
        { get; private set; }

        /// <summary>
        /// Gets the unique ID of <see cref="Parent"/> (if any). This property is read-only.
        /// </summary>
        internal Guid? ParentID
        {
            get
            {
                return (Parent == null) ? null : Parent.ID;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewSecurityCategory"/> class with no arguments.
        /// </summary>
        private WhippetViewSecurityCategory()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewSecurityCategory"/> class with the specified ID and name.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="WhippetViewSecurityCategory"/>.</param>
        /// <param name="name">Name of the <see cref="WhippetViewSecurityCategory"/>.</param>
        /// <param name="parent">Parent <see cref="WhippetViewSecurityCategory"/> that the instance belongs to.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetViewSecurityCategory(Guid id, string name, WhippetViewSecurityCategory parent = null)
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
                Parent = parent;
            }
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as WhippetViewSecurityCategory);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetViewSecurityCategory obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetViewSecurityCategory x, WhippetViewSecurityCategory y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    x.ID.Equals(y.ID)
                        && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase)
                        && ((x.Parent == null && y.Parent == null) || (x.Parent != null && y.Parent != null && x.Parent.Equals(y.Parent)));
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code.</returns>
        public int GetHashCode(WhippetViewSecurityCategory obj)
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
        /// Gets the name of the <see cref="WhippetViewSecurityCategory"/>.
        /// </summary>
        /// <returns>Name of the <see cref="WhippetViewSecurityCategory"/>.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Equality comparer class used for comparing <see cref="WhippetViewSecurityCategory"/> objects. This class cannot be inherited.
        /// </summary>
        public sealed class WhippetViewSecurityCategoryEqualityComparer : EqualityComparer<WhippetViewSecurityCategory>, IEqualityComparer<WhippetViewSecurityCategory>
        {
            private static WhippetViewSecurityCategoryEqualityComparer _instance;

            /// <summary>
            /// Gets a singleton instance of the <see cref="WhippetViewSecurityCategoryEqualityComparer"/> class. This property is read-only.
            /// </summary>
            public static new WhippetViewSecurityCategoryEqualityComparer Default
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new WhippetViewSecurityCategoryEqualityComparer();
                    }

                    return _instance;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="WhippetViewSecurityCategoryEqualityComparer"/> class with no arguments.
            /// </summary>
            private WhippetViewSecurityCategoryEqualityComparer()
                : base()
            { }

            /// <summary>
            /// Compares the two objects for equality.
            /// </summary>
            /// <param name="x">First object to compare.</param>
            /// <param name="y">Second object to compare.</param>
            /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
            public override bool Equals(WhippetViewSecurityCategory x, WhippetViewSecurityCategory y)
            {
                bool equals = (x == null && y == null);

                if (!equals && (x != null) && (y != null))
                {
                    equals = x.Equals(y);
                }

                return equals;
            }

            /// <summary>
            /// Gets the hash code for the specified object.
            /// </summary>
            /// <param name="obj">Object to get the hash code for.</param>
            /// <returns>Hash code.</returns>
            public override int GetHashCode(WhippetViewSecurityCategory obj)
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
        }
    }
}

