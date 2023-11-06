using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamar;

namespace Athi.Whippet.Services.Lamar
{
    /// <summary>
    /// Service locator that utilizes <a href="https://jasperfx.github.io/lamar/">Lamar</a> by Jeremy D. Miller, et al. This class cannot be inherited.
    /// </summary>
    public sealed class LamarServiceLocator : WhippetServiceLocator, IWhippetServiceContext
    {
        /// <summary>
        /// Gets the main "container" that acts as the internal service locator. This property is read-only.
        /// </summary>
        public IContainer Container
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LamarServiceLocator"/> class with the specified <see cref="IContainer"/> object.
        /// </summary>
        /// <param name="container"><see cref="IContainer"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public LamarServiceLocator(IContainer container)
            : base()
        {
            if(container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            else
            {
                Container = container;
            }
        }

        /// <summary>
        /// Gets an instance of the specified type. 
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator.</returns>
        public override T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }

        /// <summary>
        /// Gets an instance of the specified type based on the given name. 
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator indexed by the specified <paramref name="name"/>.</returns>
        public override T GetInstance<T>(string name)
        {
            return Container.GetInstance<T>(name);
        }

        /// <summary>
        /// Gets a boxed version of the specified requested type. 
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        public override object GetInstance(Type serviceType)
        {
            return Container.GetInstance(serviceType);
        }

        /// <summary>
        /// Gets a boxed version of the specified requested type. 
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        public override object GetInstance(Type serviceType, string name)
        {
            return Container.GetInstance(serviceType, name);
        }

        /// <summary>
        /// Gets an instance of the specified type. This method will not throw an exception when an error is encountered and instead will return the default value for the type. 
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator.</returns>
        public override T TryGetInstance<T>()
        {
            return Container.TryGetInstance<T>();
        }

        /// <summary>
        /// Gets an instance of the specified type based on the given name. This method will not throw an exception when an error is encountered and instead will return the default value for the type. 
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of type <typeparamref name="T"/> as configured in the service locator.</returns>
        public override T TryGetInstance<T>(string name)
        {
            return Container.TryGetInstance<T>(name);
        }

        /// <summary>
        /// Gets a boxed version of the specified requested type. This method will not throw an exception when an error is encountered and instead will return the default value for the type. 
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        public override object TryGetInstance(Type serviceType)
        {
            return Container.TryGetInstance(serviceType);
        }

        /// <summary>
        /// Gets a boxed version of the specified requested type. This method will not throw an exception when an error is encountered and instead will return the default value for the type. 
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the object to retrieve.</param>
        /// <param name="name">Name of the entry to retrieve.</param>
        /// <returns>Instance of the specified <see cref="Type"/> boxed as an <see cref="object"/>.</returns>
        public override object TryGetInstance(Type serviceType, string name)
        {
            return Container.TryGetInstance(serviceType, name);
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type. 
        /// </summary>
        /// <typeparam name="T">Requested type of type <typeparamref name="T"/>.</typeparam>
        /// <returns><see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type.</returns>
        public override IReadOnlyList<T> GetAllInstances<T>()
        {
            return Container.GetAllInstances<T>();
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type. 
        /// </summary>
        /// <param name="serviceType"><see cref="Type"/> that represents the objects to retrieve.</param>
        /// <returns><see cref="IReadOnlyList{T}"/> of all currently registered instances of the specified type.</returns>
        public override IEnumerable GetAllInstances(Type serviceType)
        {
            return Container.GetAllInstances(serviceType);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory. 
        /// </summary>
        public override void Dispose()
        {
            Container.Dispose();
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory. This method must be overridden.
        /// </summary>
        /// <returns></returns>
        public override async ValueTask DisposeAsync()
        {
            await Container.DisposeAsync();
        }

        /// <summary>
        /// Gets the main "container" that acts as the internal service locator. Note that this is not required for all implementations and may return <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">Type of container to return.</typeparam>
        /// <returns>Container of type <typeparamref name="T"/> or <see langword="null"/> if no container is configured.</returns>
        /// <exception cref="InvalidCastException" />
        protected override T GetContainerInternal<T>() where T : class
        {
            if (!typeof(T).Equals(typeof(Container)))
            {
                throw new InvalidCastException();
            }
            else
            {
                return (T)(Container);
            }
        }
    }
}
