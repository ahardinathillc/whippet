using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQuery"/> objects.
    /// </summary>
    public class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQueryHandler : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheQueryHandlerBase<GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQuery>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheQueryHandler<GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQueryHandler(IWhippetQueryRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>> HandleAsync(GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> result = await Repository.GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>(result.Result, new[] { result.Item });
            }
        }
    }
}
