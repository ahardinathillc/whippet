using System;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.Directory.Repositories;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IRegion"/> domain objects.
    /// </summary>
    public class RegionServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IRegionRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IRegionRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionServiceManager"/> class with the specified <see cref="IRegionRepository"/> object.
        /// </summary>
        /// <param name="regionRepository"><see cref="IRegionRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RegionServiceManager(IRegionRepository regionRepository)
            : base()
        {
            if (regionRepository == null)
            {
                throw new ArgumentNullException(nameof(regionRepository));
            }
            else
            {
                Repository = regionRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionServiceManager"/> class with the specified <see cref="IRegionRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="regionRepository"><see cref="IRegionRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RegionServiceManager(IWhippetServiceContext serviceLocator, IRegionRepository regionRepository)
            : base(serviceLocator)
        {
            if (regionRepository == null)
            {
                throw new ArgumentNullException(nameof(regionRepository));
            }
            else
            {
                Repository = regionRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IRegion"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IRegion"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IRegion>> Get(uint id)
        {
            IRegionQueryHandler<GetRegionByIdQuery> handler = new GetRegionByIdQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<Region>> result = await handler.HandleAsync(new GetRegionByIdQuery(id));
            return new WhippetResultContainer<IRegion>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IRegion"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IRegion>>> Gets()
        {
            IRegionQueryHandler<GetAllRegionsQuery> handler = new GetAllRegionsQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<Region>> result = await handler.HandleAsync(new GetAllRegionsQuery());
            return new WhippetResultContainer<IEnumerable<IRegion>>(result.Result, result.Item);
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
