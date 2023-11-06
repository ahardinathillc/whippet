using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Athi.Whippet.Data.Database.Oracle.MySQL.Extensions;

namespace Athi.Whippet.Data.Database.Oracle.MySQL
{
    /// <summary>
    /// Represents a collection of query attributes relevant to a <see cref="WhippetMySqlCommand"/>. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetMySqlAttributeCollection : IEnumerable<WhippetMySqlAttribute>, IReadOnlyList<WhippetMySqlAttribute>
    {
        /// <summary>
        /// Gets or sets the internal <see cref="MySqlAttributeCollection"/> object.
        /// </summary>
        private MySqlAttributeCollection InternalCollection
        { get; set; }

        /// <summary>
        /// Gets the total number of <see cref="WhippetMySqlAttribute"/> objects in the collection. This property is read-only.
        /// </summary>
        public int Count
        {
            get
            {
                return InternalCollection.Count;
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetMySqlAttribute"/> object at the specified index. This property is read-only.
        /// </summary>
        /// <param name="index">Index of the item to retrieve.</param>
        /// <returns><see cref="WhippetMySqlAttribute"/> object.</returns>
        /// <exception cref="IndexOutOfRangeException" />
        public WhippetMySqlAttribute this[int index]
        {
            get
            {
                return InternalCollection[index].ToWhippetMySqlAttribute();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlAttributeCollection"/> class with no arguments.
        /// </summary>
        private WhippetMySqlAttributeCollection()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetMySqlAttributeCollection"/> class with the specified <see cref="MySqlAttributeCollection"/> object.
        /// </summary>
        /// <param name="collection"><see cref="MySqlAttributeCollection"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetMySqlAttributeCollection(MySqlAttributeCollection collection)
            : this()
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

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            InternalCollection.Clear();
        }

        /// <summary>
        /// Adds a query attribute to the collection.
        /// </summary>
        /// <param name="attribute"><see cref="WhippetMySqlAttribute"/> to add.</param>
        /// <returns><see cref="WhippetMySqlAttribute"/> object that was added.</returns>
        public WhippetMySqlAttribute SetAttribute(WhippetMySqlAttribute attribute)
        {
            return SetAttribute((MySqlAttribute)(attribute));
        }

        /// <summary>
        /// Adds a query attribute to the collection.
        /// </summary>
        /// <param name="attribute"><see cref="MySqlAttribute"/> to add.</param>
        /// <returns><see cref="WhippetMySqlAttribute"/> object that was added.</returns>
        public WhippetMySqlAttribute SetAttribute(MySqlAttribute attribute)
        {
            return InternalCollection.SetAttribute(attribute).ToWhippetMySqlAttribute();
        }

        /// <summary>
        /// Adds a query attribute to the collection.
        /// </summary>
        /// <param name="attributeName">Name of the query attribute.</param>
        /// <param name="value">Value of the query attribute.</param>
        /// <returns><see cref="WhippetMySqlAttribute"/> object that was added.</returns>
        public WhippetMySqlAttribute SetAttribute(string attributeName, object value)
        {
            return InternalCollection.SetAttribute(attributeName, value).ToWhippetMySqlAttribute();
        }

        /// <summary>
        /// Returns an enumerator used to iterate through the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<WhippetMySqlAttribute>)(this)).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator used to iterate through the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> used to iterate through the collection.</returns>
        IEnumerator<WhippetMySqlAttribute> IEnumerable<WhippetMySqlAttribute>.GetEnumerator()
        {
            IEnumerator<MySqlAttribute> enumerator = InternalCollection.GetEnumerator();

            if (enumerator != null)
            {
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current.ToWhippetMySqlAttribute();
                }
            }
        }

        public static implicit operator WhippetMySqlAttributeCollection(MySqlAttributeCollection collection)
        {
            return (collection == null) ? null : new WhippetMySqlAttributeCollection(collection);
        }

        public static implicit operator MySqlAttributeCollection(WhippetMySqlAttributeCollection collection)
        {
            return (collection == null) ? null : collection.InternalCollection;
        }
    }
}

