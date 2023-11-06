using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Services;

namespace Athi.Whippet.ServiceManagers
{
    /// <summary>
    /// Base class for all Whippet service managers. Service managers handle business-logic interactions for domain entities in the application. This class must be inherited.
    /// </summary>
    public abstract class ServiceManager : IDisposable, IServiceManager
    {
        /// <summary>
        /// Gets the <see cref="IWhippetServiceContext"/> object used to locate specific objects through inversion of control (IoC). This property is read-only.
        /// </summary>
        protected virtual IWhippetServiceContext ServiceLocator
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager"/> class with the default currently-configured <see cref="IWhippetServiceContext"/>. If no context is configured, <see cref="ServiceLocator"/> will not be available.
        /// </summary>
        protected ServiceManager()
            : this(WhippetServiceLocator.Current, false)
        { }

        /// <summary>
        /// Initializes a new instance of hte <see cref="ServiceManager"/> class with the specified <see cref="IWhippetServiceContext"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected ServiceManager(IWhippetServiceContext serviceLocator)
            : this(serviceLocator, true)
        { }

        /// <summary>
        /// Initializes a new instance of hte <see cref="ServiceManager"/> class with the specified <see cref="IWhippetServiceContext"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object to initialize with.</param>
        /// <param name="throwOnNullServiceLocator">If <see langword="true"/>, will throw an <see cref="ArgumentNullException"/> exception if <paramref name="serviceLocator"/> is <see langword="null"/>.</param>
        /// <exception cref="ArgumentNullException" />
        private ServiceManager(IWhippetServiceContext serviceLocator, bool throwOnNullServiceLocator)
        {
            if(serviceLocator == null && throwOnNullServiceLocator)
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }
            else
            {
                ServiceLocator = serviceLocator;
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public virtual void Dispose()
        {
            if(ServiceLocator != null)
            {
                ServiceLocator.Dispose();
                ServiceLocator = null;
            }
        }
    }
}
