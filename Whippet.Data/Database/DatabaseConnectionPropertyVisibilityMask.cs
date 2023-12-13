using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Athi.Whippet.Collections.Extensions;

namespace Athi.Whippet.Data.Database
{
    /// <summary>
    /// Provides an index of specifying which database properties are to be included in construction of a connection string. This class cannot be inherited.
    /// </summary>
    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    public sealed class DatabaseConnectionPropertyVisibilityMask : IEnumerable<KeyValuePair<string, bool>>, IEnumerable
    {
        private IDictionary<string, bool> _dict;

        /// <summary>
        /// Gets the <see cref="IDictionary{TKey, TValue}"/> containing the properties indexed by name and their associated visibility.
        /// </summary>
        private IDictionary<string, bool> Properties
        {
            get
            {
                if (_dict == null)
                {
                    _dict = new Dictionary<string, bool>(StringComparer.InvariantCultureIgnoreCase);
                }

                return _dict;
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the specified property.
        /// </summary>
        /// <param name="propertyName">Name of the property to set the visibility for.</param>
        /// <exception cref="KeyNotFoundException"></exception>
        public bool this[string propertyName]
        {
            get
            {
                return Properties[propertyName];
            }
            set
            {
                Properties[propertyName] = value;
            }
        }

        /// <summary>
        /// Gets the total number of properties currently indexed. This property is read-only.
        /// </summary>
        public int Count
        {
            get
            {
                return Properties.Count;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnectionPropertyVisibilityMask"/> class with no arguments.
        /// </summary>
        private DatabaseConnectionPropertyVisibilityMask()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnectionPropertyVisibilityMask"/> class with the specified <see cref="IEnumerable{T}"/> collection of properties indexed by name and their associated visibility.
        /// </summary>
        /// <param name="mask"><see cref="IEnumerable{T}"/> collection of properties indexed by name and their associated visibility.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DatabaseConnectionPropertyVisibilityMask(IEnumerable<KeyValuePair<string, bool>> mask)
            : this()
        {
            ArgumentNullException.ThrowIfNull(mask);
            Properties.AddRange(mask);
        }

        /// <summary>
        /// Gets an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object.</returns>
        IEnumerator<KeyValuePair<string, bool>> IEnumerable<KeyValuePair<string, bool>>.GetEnumerator()
        {
            return Properties.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> object.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, bool>>)(this)).GetEnumerator();
        }
    }
}
