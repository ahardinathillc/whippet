using System;
using System.Collections.Generic;
using Athi.Whippet.Security.AccessControl;

namespace Athi.Whippet.Web.Mvc.Security
{
    /// <summary>
    /// Represents a permission that is applied to a particular view in Whippet. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMvcSecurityPermission : WhippetPermission, IWhippetPermission, IEqualityComparer<WhippetMvcSecurityPermission>
    {
        private readonly WhippetViewProfile _View;

        /// <summary>
        /// Gets the <see cref="WhippetViewProfile"/> that represents the view the permission applies to. This property is read-only.
        /// </summary>
        public WhippetViewProfile View
        {
            get
            {
                return _View;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPermission"/> class.
        /// </summary>
        /// <param name="id">Unique ID of the permission.</param>
        /// <param name="type">Type of permission represented by the current instance. The enumeration can only contain one assigned value.</param>
        /// <param name="name">Name that describes the permission.</param>
        /// K<param name="view"><see cref="WhippetViewProfile"/> of the view the permission applies to.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetMvcSecurityPermission(Guid id, WhippetPermissionType type, string name, WhippetViewProfile view)
            : base(id, type, name)
        {
            _View = view;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            return new WhippetMvcSecurityPermission(ID, Type, Name, (View == null ? null : View.Clone<WhippetViewProfile>()));
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public override TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is WhippetMvcSecurityPermission)) ? false : Equals(obj as WhippetMvcSecurityPermission);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetMvcSecurityPermission obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetMvcSecurityPermission x, WhippetMvcSecurityPermission y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = base.Equals(x, y);

                if (equals)
                {
                    equals = ((x.View == null) && (y.View == null)) || ((x.View != null) && (y.View != null) && (x.View.Equals(y.View)));
                }
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IWhippetPermission"/> object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(WhippetMvcSecurityPermission obj)
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
            return (base.ToString() + (View != null ? " - " + View.ToString() : "")).Trim();
        }

        /// <summary>
        /// Provides an equality comparer for <see cref="WhippetMvcSecurityPermission"/> objects. This class cannot be inherited.
        /// </summary>
        public sealed class WhippetMvcSecurityPermissionEqualityComparer : EqualityComparer<WhippetMvcSecurityPermission>, IEqualityComparer<WhippetMvcSecurityPermission>
        {
            private static WhippetMvcSecurityPermissionEqualityComparer _instance;

            /// <summary>
            /// Gets a singleton instance of the <see cref="WhippetMvcSecurityPermissionEqualityComparer"/> class. This property is read-only.
            /// </summary>
            public new static WhippetMvcSecurityPermissionEqualityComparer Default
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new WhippetMvcSecurityPermissionEqualityComparer();
                    }

                    return _instance;
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="WhippetMvcSecurityPermissionEqualityComparer"/> class with no arguments.
            /// </summary>
            private WhippetMvcSecurityPermissionEqualityComparer()
                : base()
            { }

            /// <summary>
            /// Compares two objects for equality.
            /// </summary>
            /// <param name="x">First object to compare.</param>
            /// <param name="y">Second object to compare.</param>
            /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
            public override bool Equals(WhippetMvcSecurityPermission x, WhippetMvcSecurityPermission y)
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
            /// <param name="obj"><see cref="IWhippetPermission"/> object to get the hash code for.</param>
            /// <returns>Hash code for the specified object.</returns>
            /// <exception cref="ArgumentNullException"></exception>
            public override int GetHashCode(WhippetMvcSecurityPermission obj)
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

