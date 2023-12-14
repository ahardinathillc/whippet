using System;
using Athi.Whippet.Services;
using Athi.Whippet.Data;

namespace Athi.Whippet.ServiceManagers
{
    /// <summary>
    /// Base class for all <see cref="ServiceManager"/> objects that contain a single <see cref="IWhippetDetachedRepository{TEntity}"/> object. This class must be inherited.
    /// </summary>
    public abstract class WhippetEntityServiceManager<TEntity, TRepository> : ServiceManager, IServiceManager, IDisposable
        where TRepository : class, IWhippetDetachedRepository<TEntity>
    {
        /// <summary>
        /// Gets the <see cref="IWhippetDetachedRepository{TEntity}"/> that database commands are executed against. This property is read-only.
        /// </summary>
        protected virtual TRepository Repository
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityServiceManager{TEntity, TRepository}"/> class with the default currently-configured <see cref="IWhippetServiceContext"/>. If no context is configured, <see cref="ServiceManager.ServiceLocator"/> will not be available.
        /// </summary>
        private WhippetEntityServiceManager()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityServiceManager{TEntity, TRepository}"/> class with the specified <typeparamref name="TRepository"/> object and the default currently-configured <see cref="IWhippetServiceContext"/>. If no context is configured, <see cref="ServiceManager.ServiceLocator"/> will not be available.
        /// </summary>
        /// <param name="repository"><typeparamref name="TRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetEntityServiceManager(TRepository repository)
            : this(repository, WhippetServiceLocator.Current)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityServiceManager{TEntity, TRepository}"/> class with the specified <typeparamref name="TRepository"/> object and <see cref="IWhippetServiceContext"/> object.
        /// </summary>
        /// <param name="repository"><typeparamref name="TRepository"/> object to initialize with.</param>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetEntityServiceManager(TRepository repository, IWhippetServiceContext serviceLocator)
            : base(serviceLocator)
        {
            ArgumentNullException.ThrowIfNull(repository);
            Repository = repository;
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (Repository != null && (Repository is IDisposable))
            {
                ((IDisposable)(Repository)).Dispose();
                Repository = null;
            }
        }
    }
}
