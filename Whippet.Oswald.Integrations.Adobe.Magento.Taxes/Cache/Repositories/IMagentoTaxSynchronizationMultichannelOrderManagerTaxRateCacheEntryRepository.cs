using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
    /// </summary>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository : IWhippetEntityRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry, Guid>, IWhippetQueryRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>
    {
        /// <summary>
        /// Gets a set amount of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects from the specified starting index for an <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="startingIndex">Starting index from which to start collecting records.</param>
        /// <param name="count">Total number of records to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> GetPayload(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int startingIndex, int count);

        /// <summary>
        /// Gets a set amount of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects from the specified starting index for an <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="startingIndex">Starting index from which to start collecting records.</param>
        /// <param name="count">Total number of records to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> GetPayloadAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int startingIndex, int count, CancellationToken? cancellationToken = null);
                
        /// <summary>
        /// Gets the total number of entries for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to get the total number of entries for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<long> GetEntryCountForCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache);

        /// <summary>
        /// Gets the total number of entries for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to get the total number of entries for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<long>> GetEntryCountForCacheAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null);
        
        /// <summary>
        /// Gets all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to get entries for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> Get(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache);

        /// <summary>
        /// Gets all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to get entries for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> GetAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Deletes all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to delete all entries from.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<long> Delete(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache);

        /// <summary>
        /// Deletes all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to delete all entries from.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<long>> DeleteAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null);
    }
}
