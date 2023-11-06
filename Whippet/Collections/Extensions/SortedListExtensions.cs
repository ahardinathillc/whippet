using System;
using System.Collections.Generic;
using System.Linq;

namespace Athi.Whippet.Collections.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="SortedDictionary{TKey, TValue}"/> objects. This class cannot be inherited.
    /// </summary>
    public static class SortedListExtensions
    {
        /// <summary>
        /// Appends the specified <see cref="IEnumerable{T}"/> collection of <see cref="KeyValuePair{TKey, TValue}"/> objects to the <see cref="SortedList{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="T">Type of value stored in the list.</typeparam>
        /// <param name="list"><see cref="SortedList{TKey, TValue}"/> object to append values to.</param>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection to append.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Append<T>(this SortedList<int, T> list, IEnumerable<KeyValuePair<int, T>> collection)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            else if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else
            {
                int newIndex = -1;

                if (!list.Any())
                {
                    foreach (KeyValuePair<int, T> entry in collection)
                    {
                        list.Add(entry.Key, entry.Value);
                    }
                }
                else
                {
                    newIndex = list.Keys.Max();
                    newIndex = newIndex + 1;    // set it to the next value

                    foreach (KeyValuePair<int, T> entry in collection)
                    {
                        list.Add(newIndex, entry.Value);
                        newIndex++;
                    }
                }
            }
        }
    }
}

