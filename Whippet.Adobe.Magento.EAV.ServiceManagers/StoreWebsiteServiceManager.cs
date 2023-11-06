using System;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.EAV.Repositories;
using Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IStoreWebsite"/> domain objects.
    /// </summary>
    public class StoreWebsiteServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IStoreWebsiteRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IStoreWebsiteRepository WebsiteRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsiteServiceManager"/> class with the specified <see cref="IStoreWebsiteRepository"/> object.
        /// </summary>
        /// <param name="couponRepository"><see cref="IStoreWebsiteRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StoreWebsiteServiceManager(IStoreWebsiteRepository couponRepository)
            : base()
        {
            if (couponRepository == null)
            {
                throw new ArgumentNullException(nameof(couponRepository));
            }
            else
            {
                WebsiteRepository = couponRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsiteServiceManager"/> class with the specified <see cref="IStoreWebsiteRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="couponRepository"><see cref="IStoreWebsiteRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StoreWebsiteServiceManager(IWhippetServiceContext serviceLocator, IStoreWebsiteRepository couponRepository)
            : base(serviceLocator)
        {
            if (couponRepository == null)
            {
                throw new ArgumentNullException(nameof(couponRepository));
            }
            else
            {
                WebsiteRepository = couponRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IStoreWebsite"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IStoreWebsite"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IStoreWebsite>> GetWebsite(ushort id)
        {
            IStoreWebsiteQueryHandler<GetStoreWebsiteByIdQuery> handler = new GetStoreWebsiteByIdQueryHandler(WebsiteRepository);
            WhippetResultContainer<IEnumerable<StoreWebsite>> result = await handler.HandleAsync(new GetStoreWebsiteByIdQuery(id));
            return new WhippetResultContainer<IStoreWebsite>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IStoreWebsite"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IStoreWebsite>>> GetWebsites()
        {
            IStoreWebsiteQueryHandler<GetAllStoreWebsitesQuery> handler = new GetAllStoreWebsitesQueryHandler(WebsiteRepository);
            WhippetResultContainer<IEnumerable<StoreWebsite>> result = await handler.HandleAsync(new GetAllStoreWebsitesQuery());
            return new WhippetResultContainer<IEnumerable<IStoreWebsite>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (WebsiteRepository != null)
            {
                WebsiteRepository.Dispose();
                WebsiteRepository = null;
            }

            base.Dispose();
        }
    }
}
