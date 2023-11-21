using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a collection of <see cref="MagentoCustomAttribute"/> objects. This class cannot be inherited.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public sealed class MagentoCustomAttributeCollection : IDictionary<string, string>, IDictionary, IReadOnlyDictionary<string, string>, ISerializable, IDeserializationCallback, IEnumerable<MagentoCustomAttribute>, ICollection<KeyValuePair<string, string>>, IEquatable<MagentoCustomAttributeCollection>
    {
        private Dictionary<string, string> _dict;

        /// <summary>
        /// Gets or sets the internal <see cref="Dictionary{TKey,TValue}"/> object.
        /// </summary>
        private Dictionary<string, string> InternalDictionary
        {
            get
            {
                if (_dict == null)
                {
                    _dict = new Dictionary<string, string>();
                }

                return _dict;
            }
            set
            {
                _dict = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <param name="key">The key of the element to get or set.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public string this[string key]
        {
            get
            {
                return InternalDictionary[key];
            }
            set
            {
                InternalDictionary[key] = value;
            }
        }

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <param name="key">The key of the element to get or set.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        object IDictionary.this[object key]
        {
            get
            {
                return ((IDictionary)(InternalDictionary))[key];
            }
            set
            {
                ((IDictionary)(InternalDictionary))[key] = value;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="IDictionary"/> object has a fixed size. This property is read-only.
        /// </summary>
        bool IDictionary.IsFixedSize
        {
            get
            {
                return ((IDictionary)(InternalDictionary)).IsFixedSize;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="IDictionary"/> is read-only. This property is read-only.
        /// </summary>
        bool IDictionary.IsReadOnly
        {
            get
            {
                return ((IDictionary)(InternalDictionary)).IsReadOnly;
            }
        }
        
        /// <summary>
        /// Indicates whether access to the <see cref="ICollection"/> is synchronized (thread safe). This property is read-only.
        /// </summary>
        bool ICollection.IsSynchronized
        {
            get
            {
                return ((ICollection)(InternalDictionary)).IsSynchronized;
            }
        }

        /// <summary>
        /// Get an object that can be used to synchronize access across the <see cref="ICollection"/>. 
        /// </summary>
        object ICollection.SyncRoot
        {
            get
            {
                return ((ICollection)(InternalDictionary)).SyncRoot;
            }
        }
        
        /// <summary>
        /// Indicates whether the collection is read-only. This property is read-only.
        /// </summary>
        bool ICollection<KeyValuePair<string, string>>.IsReadOnly
        {
            get
            {
                return false;
            }
        }
        
        /// <summary>
        /// Gets the total number of elements in the <see cref="MagentoCustomAttributeCollection"/>. This property is read-only.
        /// </summary>
        public int Count
        {
            get
            {
                return InternalDictionary.Count;
            }
        }

        /// <summary>
        /// Gets an <see cref="ICollection"/> of all the keys in the <see cref="IDictionary"/> object. This property is read-only.
        /// </summary>
        ICollection IDictionary.Keys
        {
            get
            {
                return ((IDictionary)(InternalDictionary)).Keys;
            }
        }
        
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection containing the keys in the <see cref="MagentoCustomAttributeCollection"/>. This property is read-only.
        /// </summary>
        public IEnumerable<string> Keys
        {
            get
            {
                return InternalDictionary.Keys;
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection containing the keys in the <see cref="MagentoCustomAttributeCollection"/>. This property is read-only.
        /// </summary>
        ICollection<string> IDictionary<string, string>.Keys
        {
            get
            {
                return InternalDictionary.Keys;
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> containing the values in the <see cref="MagentoCustomAttributeCollection"/>. This property is read-only.
        /// </summary>
        public IEnumerable<string> Values
        {
            get
            {
                return InternalDictionary.Values;
            }
        }

        /// <summary>
        /// Gets an <see cref="ICollection"/> of all the values in the <see cref="IDictionary"/> object. This property is read-only.
        /// </summary>
        ICollection IDictionary.Values
        {
            get
            {
                return ((IDictionary)(InternalDictionary)).Values;
            }
        }
        
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection containing the values in the <see cref="MagentoCustomAttributeCollection"/>. This property is read-only.
        /// </summary>
        ICollection<string> IDictionary<string, string>.Values
        {
            get
            {
                return InternalDictionary.Values;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoCustomAttributeCollection"/> class with no arguments.
        /// </summary>
        public MagentoCustomAttributeCollection()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoCustomAttributeCollection"/> class that contains elements copied from the specified <see cref="IDictionary{TKey, TValue}"/> and uses the default equality comparer for the key type.
        /// </summary>
        /// <param name="collection"><see cref="IDictionary{TKey,TValue}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoCustomAttributeCollection(IDictionary<string, string> collection)
            : this()
        {
            InternalDictionary = new Dictionary<string, string>(collection, StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoCustomAttributeCollection"/> class that contains elements copied from the specified <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">The <see cref="IEnumerable{T}"/> whose elements are copied to the new <see cref="MagentoCustomAttributeCollection"/>.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoCustomAttributeCollection(IEnumerable<KeyValuePair<string, string>> collection)
            : this()
        {
            InternalDictionary = new Dictionary<string, string>(collection, StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Adds the specified <see cref="MagentoCustomAttribute"/> object to the current collection.
        /// </summary>
        /// <param name="entry"><see cref="MagentoCustomAttribute"/> object to add.</param>
        public void Add(MagentoCustomAttribute entry)
        {
            ((IDictionary<string, string>)(this)).Add(entry.Code, entry.Value);
        }

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        void IDictionary<string, string>.Add(string key, string value)
        {
            InternalDictionary.Add(key, value);
        }

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="value"><see cref="KeyValuePair{TKey,TValue}"/> value to add to the dictionary.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> value)
        {
            ((IDictionary<string, string>)(this)).Add(value.Key, value.Value);
        }

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        void IDictionary.Add(object key, object value)
        {
            ((IDictionary)(InternalDictionary)).Add(key, value);
        }
        
        /// <summary>
        /// Determines whether the <see cref="MagentoCustomAttributeCollection"/> contains an element with the specified code.
        /// </summary>
        /// <param name="code"><see cref="MagentoCustomAttribute.Code"/> to locate in the <see cref="MagentoCustomAttributeCollection"/>.</param>
        /// <returns><see langword="true"/> if the <see cref="MagentoCustomAttributeCollection"/> contains an element with the code; otherwise, <see langword="false"/>.</returns>
        public bool ContainsCode(string code)
        {
            return ((IDictionary<string, string>)(this)).ContainsKey(code);
        }

        /// <summary>
        /// Determines whether the <see cref="IDictionary{TKey,TValue}"/> contains the specified key.
        /// </summary>
        /// <param name="key">Key to search for.</param>
        /// <returns><see langword="true"/> if the <see cref="IReadOnlyDictionary{TKey, TValue}"/> contains an element with the key; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        bool IDictionary.Contains(object key)
        {
            return ((IDictionary)(InternalDictionary)).Contains(key);
        }
        
        /// <summary>
        /// Determines whether the <see cref="IDictionary{TKey,TValue}"/> contains an element with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="IDictionary{TKey,TValue}"/>.</param>
        /// <returns><see langword="true"/> if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the code; otherwise, <see langword="false"/>.</returns>
        bool IDictionary<string, string>.ContainsKey(string key)
        {
            return InternalDictionary.ContainsKey(key);
        }

        /// <summary>
        /// Determines whether the <see cref="IReadOnlyDictionary{TKey,TValue}"/> contains an element with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="IReadOnlyDictionary{TKey,TValue}"/>.</param>
        /// <returns><see langword="true"/> if the <see cref="IReadOnlyDictionary{TKey, TValue}"/> contains an element with the code; otherwise, <see langword="false"/>.</returns>
        bool IReadOnlyDictionary<string, string>.ContainsKey(string key)
        {
            return InternalDictionary.ContainsKey(key);
        }
        
        /// <summary>
        /// Determines whether the <see cref="ICollection{T}"/> contains the specified element.
        /// </summary>
        /// <param name="value"><see cref="KeyValuePair{TKey,TValue}"/> object to locate.</param>
        /// <returns><see langword="true"/> if the <see cref="ICollection{T}"/> contains the sepcified value; otherwise, <see langword="false"/>.</returns>
        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> value)
        {
            return ((ICollection<KeyValuePair<string, string>>)(InternalDictionary)).Contains(value);
        }

        /// <summary>
        /// Removes the <see cref="MagentoCustomAttribute"/> object with the specified code.
        /// </summary>
        /// <param name="code"><see cref="MagentoCustomAttribute.Code"/> of the <see cref="MagentoCustomAttribute"/> to remove.</param>
        /// <returns><see langword="true"/> if the element is successfully removed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public bool Remove(string code)
        {
            return InternalDictionary.Remove(code);
        }

        /// <summary>
        /// Removes the specified value from the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="value">Value to remove.</param>
        /// <returns><see langword="true"/> if the element is successfully removed; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> value)
        {
            return ((ICollection<KeyValuePair<string, string>>)(InternalDictionary)).Remove(value);
        }

        /// <summary>
        /// Removes the element with the specified key from the <see cref="IDictionary"/>.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        void IDictionary.Remove(object key)
        {
            ((IDictionary)(InternalDictionary)).Remove(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter.</param>
        /// <returns><see langword="true"/> if the object contains an element with the specified key; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        bool IDictionary<string, string>.TryGetValue(string key, out string value)
        {
            return InternalDictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter.</param>
        /// <returns><see langword="true"/> if the object contains an element with the specified key; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        bool IReadOnlyDictionary<string, string>.TryGetValue(string key, out string value)
        {
            return InternalDictionary.TryGetValue(key, out value);
        }
        
        /// <summary>
        /// Removes all elements from the collection.
        /// </summary>
        public void Clear()
        {
            InternalDictionary.Clear();
        }

        /// <summary>
        /// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="Array"/>, starting at the specified array index.
        /// </summary>
        /// <param name="array">One-dimensional <see cref="Array"/> that serves as the destination in which the elements are copied.</param>
        /// <param name="arrayIndex">Zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, string>>)(InternalDictionary)).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Copies the elements of the <see cref="ICollection"/> to an <see cref="Array"/>, starting at the specified array index.
        /// </summary>
        /// <param name="array">One-dimensional <see cref="Array"/> that serves as the destination in which the elements are copied.</param>
        /// <param name="arrayIndex">Zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            ((ICollection)(InternalDictionary)).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object used to iterate over each item in the collection.</returns>
        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, string>>)(InternalDictionary)).GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object used to iterate over each item in the collection.</returns>
        public IEnumerator<MagentoCustomAttribute> GetEnumerator()
        {
            foreach (KeyValuePair<string, string> entry in InternalDictionary)
            {
                yield return new MagentoCustomAttribute(entry.Key, entry.Value);
            }
        }

        /// <summary>
        /// Gets the enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> object used to iterate over each item in the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalDictionary.GetEnumerator();
        }
        
        /// <summary>
        /// Gets the enumerator used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IDictionaryEnumerator"/> object used to iterate over each item in the <see cref="IDictionary"/>.</returns>
        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return ((IDictionary)(InternalDictionary)).GetEnumerator();
        }

        /// <summary>
        /// Runs when the entire object graph has been deserialized.
        /// </summary>
        /// <param name="sender">The object that initiated the callback.</param>
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            ((IDeserializationCallback)(InternalDictionary)).OnDeserialization(sender);
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> object to populate with data.</param>
        /// <param name="context">The destination for this serialization.</param>
        /// <exception cref="SecurityException"></exception>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ((ISerializable)(InternalDictionary)).GetObjectData(info, context);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is IDictionary<string, string>) ? false : InternalEquals((IDictionary<string, string>)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MagentoCustomAttributeCollection obj)
        {
            return (obj == null) ? false : InternalEquals(obj);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        private bool InternalEquals(IDictionary<string, string> obj)
        {
            bool equals = false;

            if (obj != null && (obj.Count == Count))
            {
                equals = Keys.SequenceEqual(obj.Keys, StringComparer.InvariantCultureIgnoreCase)
                            && Values.SequenceEqual(obj.Values, StringComparer.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current instance.
        /// </summary>
        /// <returns>Hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            foreach (KeyValuePair<string, string> entry in ((IDictionary<string, string>)(this)))
            {
                hash.Add(entry.Key.GetHashCode());

                if (!String.IsNullOrWhiteSpace(entry.Value))
                {
                    hash.Add(entry.Value.GetHashCode());
                }
            }

            return hash.ToHashCode();
        }
    }
}
