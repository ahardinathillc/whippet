using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Athi.Whippet.Collections.Concurrent.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ConcurrentBag{T}"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ConcurrentBagExtensions
    {
        /// <summary>
        /// Adds the specified collection of objects of type <typeparamref name="T"/> to the <see cref="ConcurrentBag{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of objects to add.</typeparam>
        /// <param name="collection"><see cref="ConcurrentBag{T}"/> object.</param>
        /// <param name="toAdd"><see cref="IEnumerable{T}"/> collection of objects to add.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddRange<T>(this ConcurrentBag<T> collection, IEnumerable<T> toAdd)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else if (toAdd == null)
            {
                throw new ArgumentNullException(nameof(toAdd));
            }
            else
            {
                foreach (T item in toAdd)
                {
                    collection.Add(item);
                }
            }
        }
    }
}

