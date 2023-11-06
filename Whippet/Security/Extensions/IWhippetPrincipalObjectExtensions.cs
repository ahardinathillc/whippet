using System;
using System.Reflection;

namespace Athi.Whippet.Security.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IWhippetPrincipalObject"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IWhippetPrincipalObjectExtensions
    {
        /// <summary>
        /// Creates a new instance of type <typeparamref name="T"/> based on the specified <see cref="IWhippetPrincipalObject"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="IWhippetPrincipalObject"/> concrete class type to instantiate from the underlying object type.</typeparam>
        /// <param name="principalObject"><see cref="IWhippetPrincipalObject"/> object to instantiate.</param>
        /// <returns>Object instance of type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="MethodAccessException" />
        /// <exception cref="MemberAccessException" />
        /// <exception cref="System.Runtime.InteropServices.InvalidComObjectException" />
        /// <exception cref="MissingMethodException" />
        /// <exception cref="System.Runtime.InteropServices.COMException" />
        /// <exception cref="TypeLoadException" />
        public static T CreateInstance<T>(this IWhippetPrincipalObject principalObject)
            where T : IWhippetPrincipalObject, new()
        {
            if (principalObject == null)
            {
                throw new ArgumentNullException(nameof(principalObject));
            }
            else
            {
                return (T)(Activator.CreateInstance(principalObject.GetType()));
            }
        }
    }
}

