using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Reflection
{
    /// <summary>
    /// Represents a read-only container of <see cref="Type"/> objects used for building complete derived <see cref="Type"/> inference trees.
    /// </summary>
    public interface ITypeCatalog
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects that are currently loaded. This property is read-only.
        /// </summary>
        IEnumerable<Type> LoadedTypes
        { get; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all derived <see cref="Type"/> objects from the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="type"><see cref="Type"/> object to infer derived <see cref="Type"/> objects from.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<Type> GetDerivedTypes(Type type);

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all derived <see cref="Type"/> objects from the specified <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">Object type to infer derived <see cref="Type"/> objects from.</typeparam>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        IEnumerable<Type> GetDerivedTypes<T>();

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all generic interfaces from the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="type"><see cref="Type"/> object to list all generic interface <see cref="Type"/> objects from.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<Type> GetGenericInterfaceImplementations(Type type);

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all generic interfaces from the specified <typeparamref name="T"/> object.
        /// </summary>
        /// <typeparam name="T">Object type to get all generic interface implementations for.</typeparam>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<Type> GetGenericInterfaceImplementations<T>();

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all interfaces from the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="type"><see cref="Type"/> object to list all interface <see cref="Type"/> objects from.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<Type> GetInterfaceImplementations(Type type);

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all interfaces from the specified <typeparamref name="T"/> object.
        /// </summary>
        /// <typeparam name="T">Object type to get all interface implementations for.</typeparam>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        IEnumerable<Type> GetInterfaceImplementations<T>();
    }
}
