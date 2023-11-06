using System;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.EAV.Repositories;
using Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IStore"/> domain objects.
    /// </summary>
    public class StoreServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IStoreRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IStoreRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreServiceManager"/> class with the specified <see cref="IStoreRepository"/> object.
        /// </summary>
        /// <param name="storeRepository"><see cref="IStoreRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StoreServiceManager(IStoreRepository storeRepository)
            : base()
        {
            if (storeRepository == null)
            {
                throw new ArgumentNullException(nameof(storeRepository));
            }
            else
            {
                Repository = storeRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreServiceManager"/> class with the specified <see cref="IStoreRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="storeRepository"><see cref="IStoreRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StoreServiceManager(IWhippetServiceContext serviceLocator, IStoreRepository storeRepository)
            : base(serviceLocator)
        {
            if (storeRepository == null)
            {
                throw new ArgumentNullException(nameof(storeRepository));
            }
            else
            {
                Repository = storeRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IStore"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IStore"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IStore>> Get(ushort id)
        {
            IStoreQueryHandler<GetStoreByIdQuery> handler = new GetStoreByIdQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<Store>> result = await handler.HandleAsync(new GetStoreByIdQuery(id));
            return new WhippetResultContainer<IStore>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IStore"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IStore>>> Gets()
        {
            IStoreQueryHandler<GetAllStoresQuery> handler = new GetAllStoresQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<Store>> result = await handler.HandleAsync(new GetAllStoresQuery());
            return new WhippetResultContainer<IEnumerable<IStore>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (Repository != null)
            {
                Repository.Dispose();
                Repository = null;
            }

            base.Dispose();
        }
    }
}
