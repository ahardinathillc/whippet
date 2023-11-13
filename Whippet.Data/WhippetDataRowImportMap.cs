using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a collection of <see cref="WhippetDataRowImportMapEntry"/> objects that collectively provide a mapping for an entity and an external source. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetDataRowImportMap : IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable, IEnumerable<WhippetDataRowImportMapEntry>, ICollection<WhippetDataRowImportMapEntry>, IList<WhippetDataRowImportMapEntry>, ICloneable, IWhippetCloneable
    {
        private List<WhippetDataRowImportMapEntry> _list;

        /// <summary>
        /// Gets the internal <see cref="List{T}"/> of <see cref="WhippetDataRowImportMapEntry"/> objects. This property is read-only.
        /// </summary>
        private List<WhippetDataRowImportMapEntry> InternalList
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WhippetDataRowImportMapEntry>();
                }

                return _list;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetDataRowImportMapEntry"/> object at the specified index.
        /// </summary>
        /// <param name="index">Index in which to get or set the object.</param>
        /// <returns><see cref="WhippetDataRowImportMapEntry"/> object contained at the specified index.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public WhippetDataRowImportMapEntry this[int index]
        {
            get
            {
                return InternalList[index];
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    // check to make sure that the value does not already exist

                    if (IndexOf(value) != index && IndexOf(value) >= 0)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        InternalList[index] = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WhippetDataRowImportMapEntry"/> object with the specified property.
        /// </summary>
        /// <param name="property"><see cref="WhippetDataRowImportMapEntry"/> property name.</param>
        /// <returns><see cref="WhippetDataRowImportMapEntry"/> object with the matching property name (if found).</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDataRowImportMapEntry this[string property]
        {
            get
            {
                if (String.IsNullOrWhiteSpace(property))
                {
                    throw new ArgumentNullException(nameof(property));
                }
                else
                {
                    return (from e in InternalList where String.Equals(e.Property, property, StringComparison.InvariantCultureIgnoreCase) select e).FirstOrDefault();
                }
            }
            set
            {
                if (String.IsNullOrWhiteSpace(property))
                {
                    throw new ArgumentNullException(nameof(property));
                }
                else
                {
                    WhippetDataRowImportMapEntry entry = this[property];

                    if (entry != null)
                    {
                        Remove(entry);
                    }

                    Add(entry);
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="WhippetDataRowImportMapEntry.Column"/> value based on the specified <see cref="WhippetDataRowImportMapEntry.Property"/> value.
        /// </summary>
        /// <param name="key"><see cref="WhippetDataRowImportMapEntry.Property"/> value.</param>
        /// <returns><see cref="WhippetDataRowImportMapEntry.Column"/> value.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="KeyNotFoundException"></exception>
        string IDictionary<string, string>.this[string key]
        {
            get
            {
                if (String.IsNullOrWhiteSpace(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                else
                {
                    WhippetDataRowImportMapEntry entry = (from l in InternalList where String.Equals(l.Property, key, StringComparison.InvariantCultureIgnoreCase) select l).FirstOrDefault();

                    if (entry == null)
                    {
                        throw new KeyNotFoundException();
                    }
                    else
                    {
                        return entry.Column;
                    }
                }
            }
            set
            {
                WhippetDataRowImportMapEntry entry = (from l in InternalList where String.Equals(l.Property, key, StringComparison.InvariantCultureIgnoreCase) select l).FirstOrDefault();
                WhippetDataRowImportMapEntry newEntry = null;

                if (entry == null)
                {
                    throw new KeyNotFoundException();
                }
                else
                {
                    newEntry = new WhippetDataRowImportMapEntry(key, value);

                    InternalList.Remove(entry);
                    InternalList.Add(newEntry);
                }
            }
        }

        /// <summary>
        /// Gets all keys stored in the current <see cref="IDictionary{TKey, TValue}"/>. This property is read-only.
        /// </summary>
        ICollection<string> IDictionary<string, string>.Keys
        {
            get
            {
                return new List<string>(InternalList.Select(e => e.Property).ToList());
            }
        }

        /// <summary>
        /// Gets all values stored in the current <see cref="IDictionary{TKey, TValue}"/>. This property is read-only.
        /// </summary>
        ICollection<string> IDictionary<string, string>.Values
        {
            get
            {
                return new List<string>(InternalList.Select(e => e.Column).ToList());
            }
        }

        /// <summary>
        /// Gets the total number of items in the collection. This property is read-only.
        /// </summary>
        public int Count
        {
            get
            {
                return InternalList.Count;
            }
        }

        /// <summary>
        /// Indicates whether the collection is read-only. This property is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDataRowImportMap"/> class with no arguments.
        /// </summary>
        public WhippetDataRowImportMap()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDataRowImportMap"/> class with the specified <see cref="IEnumerable{T}"/> collection of <see cref="WhippetDataRowImportMapEntry"/> objects.
        /// </summary>
        /// <param name="entries"><see cref="IEnumerable{T}"/> collection of <see cref="WhippetDataRowImportMapEntry"/> objects.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDataRowImportMap(IEnumerable<WhippetDataRowImportMapEntry> entries)
            : this()
        {
            if (entries == null)
            {
                throw new ArgumentNullException(nameof(entries));
            }
            else
            {
                foreach (WhippetDataRowImportMapEntry e in entries.Distinct())
                {
                    Add(e);
                }
            }
        }

        /// <summary>
        /// Determines if the collection contains any entries with the specified key.
        /// </summary>
        /// <param name="key">Key to filter by.</param>
        /// <returns><see langword="true"/> if the collection contains the specified key; otherwise, <see langword="false"/>.</returns>
        bool IDictionary<string, string>.ContainsKey(string key)
        {
            return InternalList.Where(e => String.Equals(e.Property, key, StringComparison.InvariantCultureIgnoreCase)).Any();
        }

        /// <summary>
        /// Adds the specified key/value pair to the current collection.
        /// </summary>
        /// <param name="key">Key to add.</param>
        /// <param name="value">Value to add.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        void IDictionary<string, string>.Add(string key, string value)
        {
            Add(new WhippetDataRowImportMapEntry(key, value));
        }

        /// <summary>
        /// Adds the specified key/value pair to the current collection.
        /// </summary>
        /// <param name="item"><see cref="KeyValuePair{TKey, TValue}"/> to add to the collection.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item)
        {
            ((IDictionary<string, string>)(this)).Add(item.Key, item.Value);
        }

        /// <summary>
        /// Adds the specified <see cref="WhippetDataRowImportMapEntry"/> to the current collection.
        /// </summary>
        /// <param name="entry"><see cref="WhippetDataRowImportMapEntry"/> object to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Add(WhippetDataRowImportMapEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                if (((IDictionary<string, string>)(this)).ContainsKey(entry.Property))
                {
                    throw new ArgumentException();
                }
                else
                {
                    InternalList.Add(entry);
                }
            }
        }

        /// <summary>
        /// Removes the <see cref="WhippetDataRowImportMapEntry"/> with the specified <see cref="WhippetDataRowImportMapEntry.Property"/> value.
        /// </summary>
        /// <param name="property"><see cref="WhippetDataRowImportMapEntry.Property"/> value.</param>
        /// <returns><see langword="true"/> if the entry was removed; otherwise, <see langword="false"/>.</returns>
        public bool Remove(string property)
        {
            bool removed = false;
            WhippetDataRowImportMapEntry entry = null;

            if (((IDictionary<string, string>)(this)).ContainsKey(property))
            {
                entry = (from l in InternalList where String.Equals(l.Property, property, StringComparison.InvariantCultureIgnoreCase) select l).FirstOrDefault();

                if (entry != null)
                {
                    removed = InternalList.Remove(entry);
                }
            }

            return removed;
        }

        /// <summary>
        /// Removes the <see cref="WhippetDataRowImportMapEntry"/> with the specified <see cref="KeyValuePair{TKey, TValue}"/>.
        /// </summary>
        /// <param name="item"><see cref="KeyValuePair{TKey, TValue}"/> value.</param>
        /// <returns><see langword="true"/> if the entry was removed; otherwise, <see langword="false"/>.</returns>
        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Removes the specified <see cref="WhippetDataRowImportMapEntry"/>.
        /// </summary>
        /// <param name="entry"><see cref="WhippetDataRowImportMapEntry"/> value.</param>
        /// <returns><see langword="true"/> if the entry was removed; otherwise, <see langword="false"/>.</returns>
        public bool Remove(WhippetDataRowImportMapEntry entry)
        {
            return (entry == null) ? false : Remove(entry.Property);
        }

        /// <summary>
        /// Attempts to retrieve the value with the specified key.
        /// </summary>
        /// <param name="key">Key to search for.</param>
        /// <param name="value">Value associated with <paramref name="key"/>.</param>
        /// <returns><see langword="true"/> if the value was retrieved successfully; otherwise, <see langword="false"/>.</returns>
        bool IDictionary<string, string>.TryGetValue(string key, out string value)
        {
            bool found = false;
            value = String.Empty;

            if (((IDictionary<string, string>)(this)).ContainsKey(key))
            {
                try
                {
                    value = ((IDictionary<string, string>)(this))[key];
                    found = true;
                }
                catch
                {
                    found = false;
                }
            }

            return found;
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            InternalList.Clear();
        }

        /// <summary>
        /// Indicates whether the collection contains the specified <see cref="KeyValuePair{TKey, TValue}"/>.
        /// </summary>
        /// <param name="item"><see cref="KeyValuePair{TKey, TValue}"/> to search for.</param>
        /// <returns><see langword="true"/> if the collection contains the specified <see cref="KeyValuePair{TKey, TValue}"/>; otherwise, <see langword="false"/>.</returns>
        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item)
        {
            return ((IDictionary<string, string>)(this)).ContainsKey(item.Key) && String.Equals(item.Value, ((IDictionary<string, string>)(this))[item.Key]);
        }

        /// <summary>
        /// Indicates whether the collection contains the specified <see cref="WhippetDataRowImportMapEntry"/>.
        /// </summary>
        /// <param name="entry"><see cref="WhippetDataRowImportMapEntry"/> object to search for.</param>
        /// <returns><see langword="true"/> if the collection contains the specified <see cref="WhippetDataRowImportMapEntry"/>; otherwise, <see langword="false"/>.</returns>
        public bool Contains(WhippetDataRowImportMapEntry entry)
        {
            return (entry == null) ? false : InternalList.Where(e => String.Equals(e.Property, entry.Property, StringComparison.InvariantCultureIgnoreCase) && String.Equals(e.Column, entry.Column, StringComparison.InvariantCultureIgnoreCase)).Any();
        }

        /// <summary>
        /// Copies the elements of the current collection to the destination array.
        /// </summary>
        /// <param name="array">Destination array.</param>
        /// <param name="arrayIndex">Zero-based index at which copying begins.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, string>>)(ToDictionary())).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Copies the elements of the current collection to the destination array.
        /// </summary>
        /// <param name="array">Destination array.</param>
        /// <param name="arrayIndex">Zero-based index at which copying begins.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        void ICollection<WhippetDataRowImportMapEntry>.CopyTo(WhippetDataRowImportMapEntry[] array, int arrayIndex)
        {
            InternalList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> object.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object.</returns>
        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
        {
            return ToDictionary().GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object.</returns>
        IEnumerator<WhippetDataRowImportMapEntry> IEnumerable<WhippetDataRowImportMapEntry>.GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }

        /// <summary>
        /// Converts the current instance to a <see cref="Dictionary{TKey, TValue}"/> object.
        /// </summary>
        /// <returns><see cref="Dictionary{TKey, TValue}"/> object.</returns>
        private Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (WhippetDataRowImportMapEntry entry in InternalList)
            {
                dict.Add(entry.Property, entry.Column);
            }

            return dict;
        }

        /// <summary>
        /// Gets the index of the specified <see cref="WhippetDataRowImportMapEntry"/>.
        /// </summary>
        /// <param name="entry"><see cref="WhippetDataRowImportMapEntry"/> object.</param>
        /// <returns>Index of the object or -1 if the object could not be found.</returns>
        public int IndexOf(WhippetDataRowImportMapEntry entry)
        {
            int index = -1;

            if (entry != null)
            {
                for (int i = 0; i < InternalList.Count; i++)
                {
                    if (entry.Equals(InternalList[i]))
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// Inserts a <see cref="WhippetDataRowImportMapEntry"/> object into the collection at the specified index.
        /// </summary>
        /// <param name="index">Index at which to insert the <see cref="WhippetDataRowImportMapEntry"/>.</param>
        /// <param name="entry"><see cref="WhippetDataRowImportMapEntry"/> object to insert.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public void Insert(int index, WhippetDataRowImportMapEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                InternalList.Insert(index, entry);
            }
        }

        /// <summary>
        /// Removes the <see cref="WhippetDataRowImportMapEntry"/> at the specified index.
        /// </summary>
        /// <param name="index">Index of the <see cref="WhippetDataRowImportMapEntry"/> object to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public void RemoveAt(int index)
        {
            InternalList.RemoveAt(index);
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        object ICloneable.Clone()
        {
            WhippetDataRowImportMap map = new WhippetDataRowImportMap();

            foreach (WhippetDataRowImportMapEntry entry in InternalList)
            {
                map.Add(entry.Clone<WhippetDataRowImportMapEntry>());
            }

            return map;
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

        /// <summary>
        /// Gets the column name that the specified property name is mapped to.
        /// </summary>
        /// <param name="propertyName">Property name to retrieve the column name for.</param>
        /// <returns>Column name.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public string GetColumnName(string propertyName)
        {
            return this[propertyName].Column;
        }
    }
}
