using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Collections.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IEnumerable{T}"/> instances. This class cannot be inherited.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Performs the specified action on each element of the <see cref="IEnumerable{T}"/> collection.
        /// </summary>
        /// <typeparam name="T">Type of object stored in the collection.</typeparam>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection to perform each action on.</param>
        /// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the <see cref="IEnumerable{T}"/> collection.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException" />
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            else if(action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            else
            {
                if(collection is List<T>)
                {
                    ((List<T>)(collection)).ForEach(action);
                }
                else
                {
                    foreach(T item in collection)
                    {
                        action(item);
                    }
                }
            }
        }

        /// <summary>
        /// Returns all elements in the specified collection as a delimited string.
        /// </summary>
        /// <typeparam name="T">Type of object stored in the collection.</typeparam>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection.</param>
        /// <param name="delimiter">Delimiter to separate each item or <see langword="null"/> or <see cref="String.Empty"/> to use no delimiter.</param>
        /// <returns>Delimited string reprenting the contents of the collection.</returns>
        public static string ToDelimitedString<T>(this IEnumerable<T> collection, string delimiter)
        {
            StringBuilder builder = new StringBuilder();

            T[] array = null;

            if (collection != null && collection.Any())
            {
                array = collection.ToArray();

                for (int i = 0; i < array.Length; i++)
                {
                    builder.Append(array[i]);

                    if (i < (array.Length - 1))
                    {
                        if (!String.IsNullOrEmpty(delimiter))
                        {
                            builder.Append(delimiter);
                        }
                    }
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> collection of duplicate entries in the specified source.
        /// </summary>
        /// <typeparam name="TSource">Type of item stored in the collection to check.</typeparam>
        /// <typeparam name="TKey">Type of selector item to use when grouping instances.</typeparam>
        /// <param name="source">Source <see cref="IEnumerable{T}"/> collection.</param>
        /// <param name="selector"><see cref="Func{T1, TResult}"/> delegate used to group the entries.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of duplicate entries.</returns>
        /// <exception cref="ArgumentNullException" />
        public static IEnumerable<TSource> Duplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            else if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }
            else
            {
                IEnumerable<IGrouping<TKey, TSource>> grouped = source.GroupBy(selector);
                IEnumerable<IGrouping<TKey, TSource>> moreThanOne = grouped.Where(i => i.IsMultiple());

                return moreThanOne.SelectMany(i => i);
            }
        }

        /// <summary>
        /// Checks to see if the <see cref="IEnumerable{T}"/> collection contains duplicate elements.
        /// </summary>
        /// <param name="enumerable"><see cref="IEnumerable{T}"/> collection to check.</param>
        /// <typeparam name="TSource">Type of object contained in the <see cref="IEnumerable{T}"/> collection.</typeparam>
        /// <returns><see langword="true"/> if the collection contains duplicate elements; otherwise, <see langword="false"/>.</returns>
        public static bool ContainsDuplicates<TSource>(this IEnumerable<TSource> enumerable)
        {
            bool duplicates = false;
            HashSet<TSource> knownKeys = null;
            
            if (enumerable != null && enumerable.Any())
            {
                knownKeys = new HashSet<TSource>();
                duplicates = enumerable.Any(item => !knownKeys.Add(item));
            }

            return duplicates;
        }

        /// <summary>
        /// Determines if the specified <see cref="IEnumerable{T}"/> collection has more than one item in it without traversing the whole collection.
        /// </summary>
        /// <typeparam name="T">Type of item stored in the collection.</typeparam>
        /// <param name="source"><see cref="IEnumerable{T}"/> collection to check.</param>
        /// <returns><see langword="true"/> if the collection contains at least two items; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsMultiple<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            else
            {
                IEnumerator<T> enumerator = source.GetEnumerator();
                return enumerator.MoveNext() && enumerator.MoveNext();
            }
        }

        /// <summary>
        /// Converts the specified item to an iterative instance.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="item">Item to convert to an <see cref="IEnumerable{T}"/> instance.</param>
        /// <returns><see cref="IEnumerable{T}"/> object.</returns>
        public static IEnumerable<T> AsEnumerable<T>(this T item)
        {
            yield return item;
        }
    }
}
