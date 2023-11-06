using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Services
{
    /// <summary>
    /// Provides support to service locators to retrieve a specific object through inversion of control (IoC).
    /// </summary>
    public interface IWhippetServiceContext : IServiceProvider, IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Gets an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator.</returns>
        T GetInstance<T>();

        /// <summary>
        /// Gets an instance of the specified type based on the given name.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator indexed by the specified <paramref name="name"/>.</returns>
        T GetInstance<T>(string name);

        /// <summary>
        /// Gets a boxed version of the specified requested type.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        object GetInstance(Type serviceType);

        /// <summary>
        /// Gets a boxed version of the specified requested type.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        object GetInstance(Type serviceType, string name);

        /// <summary>
        /// Gets an instance of the specified type. This method will not throw an exception when an error is encountered and instead will return the default value for the type.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator.</returns>
        T TryGetInstance<T>();

        /// <summary>
        /// Gets an instance of the specified type based on the given name. This method will not throw an exception when an error is encountered and instead will return the default value for the type.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator.</returns>
        T TryGetInstance<T>(string name);

        /// <summary>
        /// Gets a boxed version of the specified requested type. This method will not throw an exception when an error is encountered and instead will return the default value for the type.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        object TryGetInstance(Type serviceType);

        /// <summary>
        /// Gets a boxed version of the specified requested type. This method will not throw an exception when an error is encountered and instead will return the default value for the type.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        object TryGetInstance(Type serviceType, string name);

        /// <summary>
        /// Gets an <see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <returns><see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type.</returns>
        IReadOnlyList<T> GetAllInstances<T>();

        /// <summary>
        /// Gets an <see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the objects to retrieve.</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type.</returns>
        IEnumerable GetAllInstances(Type serviceType);

        /// <summary>
        /// Gets the main "container" that acts as the internal service locator. Note that this is not required for all implementations and may return <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">Type of container to return.</typeparam>
        /// <returns>Container of type <typeparamref name="T"/> or <see langword="null"/> if no container is configured.</returns>
        T GetContainer<T>() where T : class, IServiceProvider
        {
            return null;
        }
    }
}
