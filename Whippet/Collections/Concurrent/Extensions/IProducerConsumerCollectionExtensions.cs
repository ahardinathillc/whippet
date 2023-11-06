using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Athi.Whippet.Collections.Concurrent.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IProducerConsumerCollection{T}"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IProducerConsumerCollectionExtensions
    {
        /// <summary>
        /// Adds the specified collection of objects of type <typeparamref name="T"/> to the <see cref="IProducerConsumerCollection{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of objects to add.</typeparam>
        /// <param name="collection"><see cref="IProducerConsumerCollection{T}"/> object.</param>
        /// <param name="toAdd"><see cref="IEnumerable{T}"/> collection of objects to add.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of objects that were unable to be added to <paramref name="collection"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> TryAddRange<T>(this IProducerConsumerCollection<T> collection, IEnumerable<T> toAdd)
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
                List<T> failedObjects = new List<T>();

                foreach (T item in toAdd)
                {
                    if (!collection.TryAdd(item))
                    {
                        failedObjects.Add(item);
                    }
                }

                return failedObjects.AsReadOnly();
            }
        }
    }
}

