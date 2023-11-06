using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Collections.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IDictionary{TKey, TValue}"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// Attempts to get the value from the dictionary and, if unsuccessful, will return the supplied default value.
        /// </summary>
        /// <typeparam name="TKey">Type of key in the dictionary.</typeparam>
        /// <typeparam name="TValue">Type of value in the dictionary.</typeparam>
        /// <param name="dictionary"><see cref="IDictionary{TKey, TValue}"/> object.</param>
        /// <param name="key">Key accessor for the value.</param>
        /// <param name="defaultValue">Default <typeparamref name="TValue"/> value to return if the key does not exist.</param>
        /// <returns><typeparamref name="TValue"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            else
            {
                TValue value;
                
                if (!dictionary.TryGetValue(key, out value))
                {
                    value = defaultValue;
                }

                return value;
            }
        }

        /// <summary>
        /// Imports all values from the specified <see cref="IEnumerable{T}"/> collection to the specified <see cref="IDictionary{TKey, TValue}"/>. If <paramref name="dictionary"/> contains a key that already exists in <see cref="IEnumerable{T}"/>, the associated value is updated.
        /// </summary>
        /// <typeparam name="TKey">Type of key.</typeparam>
        /// <typeparam name="TValue">Type of value.</typeparam>
        /// <param name="dictionary">Destination <see cref="IDictionary{TKey, TValue}"/> to import the values.</param>
        /// <param name="toImport">Source <see cref="IEnumerable{T}"/> collection to import values from.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException" />
        public static void ImportValues<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> toImport)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            else if (toImport == null)
            {
                throw new ArgumentNullException(nameof(toImport));
            }
            else
            {
                if (toImport.Any())
                {
                    foreach (KeyValuePair<TKey, TValue> entry in toImport)
                    {
                        if (!dictionary.ContainsKey(entry.Key))
                        {
                            dictionary.Add(entry.Key, entry.Value);
                        }
                        else
                        {
                            dictionary[entry.Key] = entry.Value;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds the specified collection of keys to the <see cref="IDictionary{TKey, TValue}"/> with <typeparamref name="TValue"/>'s default value. If the key already exists, it is ignored and the associated value is left intact.
        /// </summary>
        /// <typeparam name="TKey">Type of key.</typeparam>
        /// <typeparam name="TValue">Type of value.</typeparam>
        /// <param name="dictionary"><see cref="IDictionary{TKey, TValue}"/> object in which to add <paramref name="keys"/>.</param>
        /// <param name="keys"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TKey"/> objects.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException" />
        /// <exception cref="NotSupportedException" />
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            else if (keys == null)
            {
                throw new ArgumentNullException(nameof(keys));
            }
            else
            {
                if (keys.Any())
                {
                    foreach (TKey key in keys.Distinct())
                    {
                        if (!dictionary.ContainsKey(key))
                        {
                            dictionary.Add(key, default(TValue));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns the current <see cref="IDictionary{TKey, TValue}"/> object as an <see cref="IReadOnlyDictionary{TKey, TValue}"/> object.
        /// </summary>
        /// <typeparam name="TKey">Object type of the key in the dictionary.</typeparam>
        /// <typeparam name="TValue">Value type of the key in the dictionary.</typeparam>
        /// <param name="dictionary"><see cref="IDictionary{TKey, TValue}"/> object to convert.</param>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
}
