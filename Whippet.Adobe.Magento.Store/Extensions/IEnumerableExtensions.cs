using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Athi.Whippet.Adobe.Magento.Store.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IEnumerable{T}"/> objects. This class cannot be inherited.
    /// </summary>
    internal static class IEnumerableExtensions
    {
        /// <summary>
        /// Compares two <see cref="IEnumerable{T}"/> collections of <see cref="KeyValuePair{TKey,TValue}"/> objects containing a <see cref="StoreLinkType"/> and <see cref="StoreLinkValue"/> for equality.
        /// </summary>
        /// <param name="baseCollection">Base <see cref="IEnumerable{T}"/> collection.</param>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection to compare against.</param>
        /// <returns><see langword="true"/> if the collections are equal; otherwise, <see langword="false"/>.</returns>
        internal static bool _Equals(this IEnumerable<KeyValuePair<StoreLinkType, StoreLinkValue>> baseCollection, IEnumerable<KeyValuePair<StoreLinkType, StoreLinkValue>> collection)
        {
            bool equals = (baseCollection == null) && (collection == null);
            bool found = false;
            
            if (!equals && (baseCollection != null) && (collection != null))
            {
                foreach (KeyValuePair<StoreLinkType, StoreLinkValue> entry in baseCollection)
                {
                    found = false;
                    
                    foreach (KeyValuePair<StoreLinkType, StoreLinkValue> collectionEntry in collection)
                    {
                        if (collectionEntry.Key == entry.Key)
                        {
                            found = true;
                            equals = (entry.Value.URL == null) && (entry.Value.URL == null);

                            if (!equals && (entry.Value.URL != null) && (collectionEntry.Value.URL != null))
                            {
                                equals = entry.Value.URL.Equals(collectionEntry.Value.URL);
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (found)
                        {
                            break;
                        }
                    }

                    if (!found)
                    {
                        break;
                    }
                }
            }
            
            return equals;
        }
    }
}
