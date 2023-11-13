using System;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects.
    /// </summary>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository : IWhippetEntityRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache, Guid>, IWhippetQueryRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>
    {
        /// <summary>
        /// Gets the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the cache for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> GetCacheForTenant(IWhippetTenant tenant);

        /// <summary>
        /// Gets the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the cache for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> GetCacheForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects for the specified <see cref="IMultichannelOrderManagerServer"/>.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> GetCachesForMultichannelOrderManagerServer(IMultichannelOrderManagerServer server);

        /// <summary>
        /// Retrieves all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects for the specified <see cref="IMultichannelOrderManagerServer"/>.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>> GetCachesForMultichannelOrderManagerServerAsync(IMultichannelOrderManagerServer server, CancellationToken? cancellationToken = null);
    }
}
