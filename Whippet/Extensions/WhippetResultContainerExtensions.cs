using System;
using System.Collections;

namespace Athi.Whippet.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="WhippetResultContainer{T}"/> objects. This class cannot be inherited.
    /// </summary>
    public static class WhippetResultContainerExtensions
    {
        /// <summary>
        /// Determines whether all items in the collection are <see langword="null"/>.
        /// </summary>
        /// <typeparam name="TItemType">Type of item stored in the <see cref="WhippetResultContainer{T}"/>.</typeparam>
        /// <param name="result"><see cref="WhippetResultContainer{T}"/> object.</param>
        /// <returns><see langword="true"/> if all items in the collection are <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
        public static bool AllItemsAreNull<TItemType>(this WhippetResultContainer<TItemType> result) where TItemType : IEnumerable
        {
            bool allNull = true;

            if (result == null)
            {
                allNull = true;
            }
            else
            {
                foreach (object item in result.Item)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    else
                    {
                        allNull = false;
                        break;
                    }
                }
            }

            return allNull;
        }
    }
}

