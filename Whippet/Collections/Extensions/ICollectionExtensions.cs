using System;
using System.Collections;
using System.Collections.Generic;

namespace Athi.Whippet.Collections.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ICollection{T}"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Adds the specified <see cref="IEnumerable{T}"/> set to the base collection.
        /// </summary>
        /// <typeparam name="T">Type of item to add.</typeparam>
        /// <param name="baseCollection">Base <see cref="ICollection{T}"/> in which elements are added to.</param>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection of elements to add.</param>
        /// <exception cref="ArgumentNullException" />
        [Obsolete("This method is obsolete. Use nuget package BetterStringExtensions instead.", false)]
        public static void AddRange<T>(this ICollection<T> baseCollection, IEnumerable<T> collection)
        {
            ArgumentNullException.ThrowIfNull(baseCollection);
            ArgumentNullException.ThrowIfNull(collection);

            foreach (T item in collection)
            {
                baseCollection.Add(item);
            }
        }
    }
}
