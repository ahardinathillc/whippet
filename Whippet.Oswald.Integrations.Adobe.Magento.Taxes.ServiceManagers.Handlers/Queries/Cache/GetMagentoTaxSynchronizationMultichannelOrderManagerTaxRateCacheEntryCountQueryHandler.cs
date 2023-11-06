using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery"/> objects.
    /// </summary>
    public class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryQueryHandlerBase<GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryQueryHandler<GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler(IWhippetQueryRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> HandleAsync(GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = null;
                WhippetResultContainer<long> countResult = null;

                List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> countItems = null;

                MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry dummyEntry = null;

                try
                {
                    countResult = await Repository.GetEntryCountForCacheAsync(query.Cache);
                    countResult.ThrowIfFailed();

                    countItems = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>();

                    for (long i = 0; i < countResult.Item; i++)
                    {
                        countItems.Add(dummyEntry);
                    }

                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(countResult.Result, countItems);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(e);
                }

                return result;
            }
        }
    }
}
