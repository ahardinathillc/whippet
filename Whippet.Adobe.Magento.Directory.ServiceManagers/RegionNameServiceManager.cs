using System;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.Directory.Repositories;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IRegionName"/> domain objects.
    /// </summary>
    public class RegionNameServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IRegionNameRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IRegionNameRepository Repository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionNameServiceManager"/> class with the specified <see cref="IRegionNameRepository"/> object.
        /// </summary>
        /// <param name="regionRepository"><see cref="IRegionNameRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RegionNameServiceManager(IRegionNameRepository regionRepository)
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
        /// Initializes a new instance of the <see cref="RegionNameServiceManager"/> class with the specified <see cref="IRegionNameRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="regionRepository"><see cref="IRegionNameRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RegionNameServiceManager(IWhippetServiceContext serviceLocator, IRegionNameRepository regionRepository)
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
        /// Retrieves the <see cref="IRegionName"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IRegionName"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IRegionName>> Get(RegionNameKey id)
        {
            IRegionNameQueryHandler<GetRegionNameByIdQuery> handler = new GetRegionNameByIdQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<RegionName>> result = await handler.HandleAsync(new GetRegionNameByIdQuery(id));
            return new WhippetResultContainer<IRegionName>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IRegionName"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IRegionName>>> Gets()
        {
            IRegionNameQueryHandler<GetAllRegionNamesQuery> handler = new GetAllRegionNamesQueryHandler(Repository);
            WhippetResultContainer<IEnumerable<RegionName>> result = await handler.HandleAsync(new GetAllRegionNamesQuery());
            return new WhippetResultContainer<IEnumerable<IRegionName>>(result.Result, result.Item);
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
