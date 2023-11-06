using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllSalesRuleCouponAggregatedUpdatedReportsQuery"/> objects.
    /// </summary>
    public class GetAllSalesRuleCouponAggregatedUpdatedReportsQueryHandler : SalesRuleCouponAggregatedUpdatedReportQueryHandlerBase<GetAllSalesRuleCouponAggregatedUpdatedReportsQuery>, ISalesRuleCouponAggregatedUpdatedReportQueryHandler<GetAllSalesRuleCouponAggregatedUpdatedReportsQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesRuleCouponAggregatedUpdatedReportsQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllSalesRuleCouponAggregatedUpdatedReportsQueryHandler(IWhippetQueryRepository<SalesRuleCouponAggregatedUpdatedReport> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedUpdatedReport>>> HandleAsync(GetAllSalesRuleCouponAggregatedUpdatedReportsQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedUpdatedReport>> result = await ((IWhippetExternalQueryRepository<SalesRuleCouponAggregatedUpdatedReport, uint>)(Repository)).GetAllAsync();
                return result;
            }
        }
    }
}
