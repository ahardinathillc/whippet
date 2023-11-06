using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries
{
    public class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQueryHandler : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryQueryHandlerBase<GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQuery>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryQueryHandler<GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQueryHandler(IWhippetQueryRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> HandleAsync(GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = null;

                try
                {
                    result = await Repository.GetPayloadAsync(query.Cache, query.StartingIndex, query.Count);
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
