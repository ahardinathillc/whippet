using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Services
{
    /// <summary>
    /// Base class for all service locators in Whippet. This class must be inherited.
    /// </summary>
    public abstract class WhippetServiceLocator : IServiceProvider, IWhippetServiceContext, IDisposable
    {
        /// <summary>
        /// Gets or sets the current <see cref="IWhippetServiceContext"/> service locator instance.
        /// </summary>
        public static IWhippetServiceContext Current
        { get; set; }

        /// <summary>
        /// Indicates whether <see cref="Current"/> has a value assigned to it. This property is read-only.
        /// </summary>
        public static bool DefaultServiceLocatorConfigured
        {
            get
            {
                return Current != null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetServiceLocator"/> class with no arguments.
        /// </summary>
        protected WhippetServiceLocator()
        { }

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type <paramref name="serviceType"/> or <see langword="null"/> if there is no service object of type <paramref name="serviceType"/>.</returns>
        object IServiceProvider.GetService(Type serviceType)
        {
            return GetInstance(serviceType);
        }

        /// <summary>
        /// Gets an instance of the specified type. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator.</returns>
        public abstract T GetInstance<T>();

        /// <summary>
        /// Gets an instance of the specified type based on the given name. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator indexed by the specified <paramref name="name"/>.</returns>
        public abstract T GetInstance<T>(string name);

        /// <summary>
        /// Gets a boxed version of the specified requested type. This method must be overridden.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        public abstract object GetInstance(Type serviceType);

        /// <summary>
        /// Gets a boxed version of the specified requested type. This method must be overridden.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        public abstract object GetInstance(Type serviceType, string name);

        /// <summary>
        /// Gets an instance of the specified type. This method will not throw an exception when an error is encountered and instead will return the default value for the type. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator.</returns>
        public abstract T TryGetInstance<T>();

        /// <summary>
        /// Gets an instance of the specified type based on the given name. This method will not throw an exception when an error is encountered and instead will return the default value for the type. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator.</returns>
        public abstract T TryGetInstance<T>(string name);

        /// <summary>
        /// Gets a boxed version of the specified requested type. This method will not throw an exception when an error is encountered and instead will return the default value for the type. This method must be overridden.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        public abstract object TryGetInstance(Type serviceType);

        /// <summary>
        /// Gets a boxed version of the specified requested type. This method will not throw an exception when an error is encountered and instead will return the default value for the type. This method must be overridden.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        public abstract object TryGetInstance(Type serviceType, string name);

        /// <summary>
        /// Gets an <see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type. This method must be overridden.
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <returns><see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type.</returns>
        public abstract IReadOnlyList<T> GetAllInstances<T>();

        /// <summary>
        /// Gets an <see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type. This method must be overridden.
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the objects to retrieve.</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type.</returns>
        public abstract IEnumerable GetAllInstances(Type serviceType);

        /// <summary>
        /// Disposes of the current object and releases its resources from memory. This method must be overridden.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Disposes of the current object and releases its resources from memory. This method must be overridden.
        /// </summary>
        /// <returns></returns>
        public abstract ValueTask DisposeAsync();

        /// <summary>
        /// Gets the main "container" that acts as the internal service locator. Note that this is not required for all implementations and may return <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">Type of container to return.</typeparam>
        /// <returns>Container of type <typeparamref name="T"/> or <see langword="null"/> if no container is configured.</returns>
        T IWhippetServiceContext.GetContainer<T>() where T : class
        {
            return GetContainerInternal<T>();
        }

        /// <summary>
        /// Gets the main "container" that acts as the internal service locator. Note that this is not required for all implementations and may return <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">Type of container to return.</typeparam>
        /// <returns>Container of type <typeparamref name="T"/> or <see langword="null"/> if no container is configured.</returns>
        protected virtual T GetContainerInternal<T>() where T : class, IServiceProvider
        {
            return null;
        }
    }
}
