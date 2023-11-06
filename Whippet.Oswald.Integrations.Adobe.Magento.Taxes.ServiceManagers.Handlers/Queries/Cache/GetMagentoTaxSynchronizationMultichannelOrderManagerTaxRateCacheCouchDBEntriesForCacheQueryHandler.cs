using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery"/> objects.
    /// </summary>
    public class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQueryHandler : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryQueryHandlerBase<GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryQueryHandler<GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQueryHandler(IWhippetQueryRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>> HandleAsync(GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> result = null;

                if (query.StartingRecordNumber.HasValue && query.Count.HasValue)
                {
                    result = await ((IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository)(Repository)).GetEntriesForCacheAsync(query.Cache, query.StartingRecordNumber.Value, query.Count.Value);
                }
                else
                {
                    result = await ((IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository)(Repository)).GetEntriesForCacheAsync(query.Cache);
                }

                return new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>(result.Result, result.Item);
            }
        }
    }
}
