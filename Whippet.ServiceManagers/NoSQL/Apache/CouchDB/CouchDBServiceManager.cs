using System;
using CouchDB.Driver;
using CouchDB.Driver.Options;
using CouchDB.Driver.Types;
using Athi.Whippet.Services;
using Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB;

namespace Athi.Whippet.ServiceManagers.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Base class for all Whippet service managers that utilize an Apache CouchDB repository. Service managers handle business-logic interactions for domain entities in the application. This class must be inherited.
    /// </summary>
    public abstract class CouchDBServiceManager : CouchContext, IAsyncDisposable, IDisposable, IServiceManager
    {
        /// <summary>
        /// Gets the <see cref="IWhippetServiceContext"/> object used to locate specific objects through inversion of control (IoC). This property is read-only.
        /// </summary>
        protected virtual IWhippetServiceContext ServiceLocator
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CouchDBServiceManager"/> class with the default currently-configured <see cref="IWhippetServiceContext"/>. If no context is configured, <see cref="ServiceLocator"/> will not be available.
        /// </summary>
        /// <param name="options"><see cref="CouchOptions"/> determine how the <see cref="CouchContext"/> is configured.</param>
        /// <exception cref="ArgumentNullException" />
        protected CouchDBServiceManager(CouchOptions options)
            : this(WhippetServiceLocator.Current, false, options)
        {
            ArgumentNullException.ThrowIfNull(options);
        }

        /// <summary>
        /// Initializes a new instance of hte <see cref="ServiceManager"/> class with the specified <see cref="IWhippetServiceContext"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object to initialize with.</param>
        /// <param name="options"><see cref="CouchOptions"/> determine how the <see cref="CouchContext"/> is configured.</param>
        /// <exception cref="ArgumentNullException" />
        protected CouchDBServiceManager(IWhippetServiceContext serviceLocator, CouchOptions options)
            : this(serviceLocator, true, options)
        {
            ArgumentNullException.ThrowIfNull(options);
        }

        /// <summary>
        /// Initializes a new instance of hte <see cref="ServiceManager"/> class with the specified <see cref="IWhippetServiceContext"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object to initialize with.</param>
        /// <param name="throwOnNullServiceLocator">If <see langword="true"/>, will throw an <see cref="ArgumentNullException"/> exception if <paramref name="serviceLocator"/> is <see langword="null"/>.</param>
        /// <param name="options"><see cref="CouchOptions"/> delegate that determine how the <see cref="CouchContext"/> is configured.</param>
        /// <exception cref="ArgumentNullException" />
        private CouchDBServiceManager(IWhippetServiceContext serviceLocator, bool throwOnNullServiceLocator, CouchOptions options)
            : base(options)
        {
            if (serviceLocator == null && throwOnNullServiceLocator)
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }
            else if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
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
            if (ServiceLocator != null)
            {
                ServiceLocator.Dispose();
                ServiceLocator = null;
            }

            Task.Run(() => DisposeAsync());
        }
    }
}

