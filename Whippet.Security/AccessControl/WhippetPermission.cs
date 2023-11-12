using System;
using System.Collections.Generic;
using Athi.Whippet.Extensions;

namespace Athi.Whippet.Security.AccessControl
{
    /// <summary>
    /// Base class for all permission objects in Whippet. <see cref="WhippetPermission"/> instances correlate to a <see cref="WhippetPermissionType"/> that determines what security functionalities are available for a particular object. This class must be inherited.
    /// </summary>
    public abstract class WhippetPermission : IWhippetPermission, IEqualityComparer<IWhippetPermission>, ICloneable
    {
        /// <summary>
        /// Gets the unique ID of the permission. This property is read-only.
        /// </summary>
        public Guid ID
        { get; private set; }

        /// <summary>
        /// Gets the type of permission represented by the current instance. This property is read-only.
        /// </summary>
        public WhippetPermissionType Type
        { get; private set; }

        /// <summary>
        /// Gets the name of the permission represented by the current instance. This property is read-only.
        /// </summary>
        public string Name
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPermission"/> class with no arguments.
        /// </summary>
        private WhippetPermission()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPermission"/> class.
        /// </summary>
        /// <param name="id">Unique ID of the permission.</param>
        /// <param name="type">Type of permission represented by the current instance. The enumeration can only contain one assigned value.</param>
        /// <param name="name">Name that describes the permission.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetPermission(Guid id, WhippetPermissionType type, string name)
            : this()
        {
            if (type.HasMultipleFlags())
            {
                throw new ArgumentException();
            }
            else if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                ID = id;
                Type = type;
                Name = name;
            }
        }

        /// <summary>
        /// Creates a duplicate instance of the current object. This method must be overridden.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public abstract object Clone();

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public virtual TObject Clone<TObject>(Guid? createdBy = null)
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
            return (obj == null || !(obj is IWhippetPermission)) ? false : Equals(obj as IWhippetPermission);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetPermission obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IWhippetPermission x, IWhippetPermission y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.ID.Equals(y.ID)
                    && x.Type == y.Type
                    && String.Equals(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);
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
        /// <param name="obj"><see cref="IWhippetPermission"/> object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(IWhippetPermission obj)
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
            return ("[" + ID.ToString("D") + "] " + Name).Trim() + " (" + Type.ToString() + ")";
        }
    }
}