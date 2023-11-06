using System;
using NHibernate;

namespace Athi.Whippet.Data.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="WhippetResultContainer{T}"/> objects. This class cannot be inherited.
    /// </summary>
    public static class WhippetResultContainerExtensions
    {
        /// <summary>
        /// Throws an <see cref="ObjectNotFoundException"/> if the <see cref="WhippetResultContainer{T}.HasItem"/> property is <see langword="false"/>.
        /// </summary>
        /// <typeparam name="T">Type of object captured by the result container.</typeparam>
        /// <param name="result"><see cref="WhippetResultContainer{T}"/> instance.</param>
        /// <param name="identifier">Identifier used to locate the object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectNotFoundException"></exception>
        public static void ThrowIfObjectNotFound<T>(this WhippetResultContainer<T> result, object identifier)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            else if (identifier == null)
            {
                throw new ArgumentNullException(nameof(identifier));
            }
            else
            {
                if (!result.HasItem)
                {
                    throw new ObjectNotFoundException(identifier, typeof(T));
                }
            }
        }
    }
}

