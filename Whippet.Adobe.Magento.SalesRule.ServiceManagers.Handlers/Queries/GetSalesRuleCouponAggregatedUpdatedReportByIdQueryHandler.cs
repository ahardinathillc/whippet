using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSalesRuleCouponAggregatedUpdatedReportByIdQuery"/> objects.
    /// </summary>
    public class GetSalesRuleCouponAggregatedUpdatedReportByIdQueryHandler : SalesRuleCouponAggregatedUpdatedReportQueryHandlerBase<GetSalesRuleCouponAggregatedUpdatedReportByIdQuery>, ISalesRuleCouponAggregatedUpdatedReportQueryHandler<GetSalesRuleCouponAggregatedUpdatedReportByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedUpdatedReportByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesRuleCouponAggregatedUpdatedReportByIdQueryHandler(IWhippetQueryRepository<SalesRuleCouponAggregatedUpdatedReport> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedUpdatedReport>>> HandleAsync(GetSalesRuleCouponAggregatedUpdatedReportByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<SalesRuleCouponAggregatedUpdatedReport> result = await ((IWhippetExternalQueryRepository<SalesRuleCouponAggregatedUpdatedReport, uint>)(Repository)).GetAsync(query.ID);
                return result.ToEnumerableResult();
            }
        }
    }
}
