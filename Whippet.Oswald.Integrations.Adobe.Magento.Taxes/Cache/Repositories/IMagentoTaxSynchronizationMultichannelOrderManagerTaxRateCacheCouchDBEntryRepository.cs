using System;
using Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories
{
    /// <summary>
    /// Represents an Apache CouchDB repository for <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects.
    /// </summary>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository : IWhippetCouchDBRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>, IWhippetQueryRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>
    {
        /// <summary>
        /// Returns all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> GetEntriesForCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache);

        /// <summary>
        /// Returns the first <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that has the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="recordNumber">Record number to filter by.</param>
        /// <param name="count">Number of records to return.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> GetEntriesForCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber, int count);
        
        /// <summary>
        /// Returns all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>> GetEntriesForCacheAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Returns the first <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that has the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="recordNumber">Record number to filter by.</param>
        /// <param name="count">Number of records to return.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>> GetEntriesForCacheAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber, int count, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Returns the first <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that has the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="recordNumber">Record number to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> GetEntryByRecordNumber(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber);
        
        /// <summary>
        /// Returns the first <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that has the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="recordNumber">Record number to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> GetEntryByRecordNumberAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Deletes all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<int> DeleteAllEntries(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache);

        /// <summary>
        /// Deletes all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<int>> DeleteAllEntriesAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null);
    }
}
