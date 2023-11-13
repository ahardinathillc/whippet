using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> domain objects.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheServiceManager : ServiceManager
    {
        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository CacheRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheServiceManager"/> class with the specified <see cref=""/>
        /// </summary>
        /// <param name="cacheRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheServiceManager(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository cacheRepository)
            : base()
        {
            if (cacheRepository == null)
            {
                throw new ArgumentNullException(nameof(cacheRepository));
            }
            else
            {
                CacheRepository = cacheRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheServiceManager"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="cacheRepository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheServiceManager(IWhippetServiceContext serviceLocator, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository cacheRepository)
            : base(serviceLocator)
        {
            if (cacheRepository == null)
            {
                throw new ArgumentNullException(nameof(cacheRepository));
            }
            else
            {
                CacheRepository = cacheRepository;
            }
        }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> based on the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> GetCache(Guid id)
        {
            GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQueryHandler(CacheRepository);
            WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQuery(id));
            return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get the cache for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> GetCache(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheForTenantQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheForTenantQueryHandler(CacheRepository);
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheForTenantQuery(tenant));
                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get the cache for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>> GetCaches(IMultichannelOrderManagerServer momServer)
        {
            if (momServer == null)
            {
                throw new ArgumentNullException(nameof(momServer));
            }
            else
            {
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCachesByServerQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCachesByServerQueryHandler(CacheRepository);
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCachesByServerQuery(momServer));
                return new WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new Magento tax rate cache entry.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                return Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>.Run(() => CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheAsync(cache)).Result;
            }
        }

        /// <summary>
        /// Creates a new Magento tax rate cache entry.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</returns>
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;
                MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache newCache = null;


                IWhippetCommandHandler<CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand> handler = new CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler(CacheRepository);

                try
                {
                    newCache = cache.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache();
                    result = await handler.HandleAsync(new CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand(newCache));

                    if (result.IsSuccess)
                    {
                        await CacheRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(result, newCache);
            }
        }

        /// <summary>
        /// Updates an existing Magento tax rate cache entry.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                return Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>.Run(() => UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheAsync(cache)).Result;
            }
        }

        /// <summary>
        /// Updates an existing Magento tax rate cache entry.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand> handler = new UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler(CacheRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand(cache.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache()));

                    if (result.IsSuccess)
                    {
                        await CacheRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(result, cache);
            }
        }

        /// <summary>
        /// Deletes an existing Magento tax rate cache entry.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                return Task.Run(() => DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheAsync(cache)).Result;
            }
        }

        /// <summary>
        /// Deletes an existing Magento tax rate cache entry.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand> handler = new DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler(CacheRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand(cache.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache()));

                    if (result.IsSuccess)
                    {
                        await CacheRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(result, cache);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CacheRepository != null)
            {
                CacheRepository.Dispose();
                CacheRepository = null;
            }

            base.Dispose();
        }
    }
}
