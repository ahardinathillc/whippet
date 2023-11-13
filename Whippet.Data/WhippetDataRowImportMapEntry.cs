using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents an individual mapping entry 
    /// </summary>
    public sealed class WhippetDataRowImportMapEntry : Tuple<string, string>, IEqualityComparer<WhippetDataRowImportMapEntry>, ICloneable, IWhippetCloneable
    {
        /// <summary>
        /// Property name that <see cref="Column"/> is mapped to. This property is read-only.
        /// </summary>
        public string Property
        {
            get
            {
                return Item1;
            }
        }

        /// <summary>
        /// External column name that <see cref="Property"/> is mapped to. This property is read-only.
        /// </summary>
        public string Column
        {
            get
            {
                return Item2;
            }
        }

        /// <summary>
        /// Represents the property name that <see cref="Item2"/> is mapped to. This property is read-only.
        /// </summary>
        public new string Item1
        {
            get
            {
                return base.Item1;
            }
        }

        /// <summary>
        /// Represents the external column name that <see cref="Item1"/> is mapped to. This property is read-only.
        /// </summary>
        public new string Item2
        {
            get
            {
                return base.Item2;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDataRowImportMapEntry"/> class with the specified property and column.
        /// </summary>
        /// <param name="propertyName">Name of the entity's property that <paramref name="columnName"/> will assign a value to.</param>
        /// <param name="columnName">Name of the external column that assigns a value to the property specified by <paramref name="propertyName"/>.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetDataRowImportMapEntry(string propertyName, string columnName)
            : base(propertyName, columnName)
        {
            if (String.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            else if (String.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentNullException(nameof(columnName));
            }
        }

        /// <summary>
        /// Compares the current object to the specified instance for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as WhippetDataRowImportMapEntry);
        }

        /// <summary>
        /// Compares the current object to the specified instance for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetDataRowImportMapEntry obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="a">First object to compare.</param>
        /// <param name="b">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetDataRowImportMapEntry a, WhippetDataRowImportMapEntry b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals = String.Equals(a.Item1, b.Item1, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(a.Item2, b.Item2, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Returns the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(WhippetDataRowImportMapEntry obj)
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
            return String.Format("[Property: {0} | Column: {1}]", Item1, Item2);
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            return new WhippetDataRowImportMapEntry(Property, Column);
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(((ICloneable)(this)).Clone());
        }
    }
}
