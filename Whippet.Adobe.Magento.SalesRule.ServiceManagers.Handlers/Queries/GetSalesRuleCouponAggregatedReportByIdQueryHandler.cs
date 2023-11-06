using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSalesRuleCouponAggregatedReportByIdQuery"/> objects.
    /// </summary>
    public class GetSalesRuleCouponAggregatedReportByIdQueryHandler : SalesRuleCouponAggregatedReportQueryHandlerBase<GetSalesRuleCouponAggregatedReportByIdQuery>, ISalesRuleCouponAggregatedReportQueryHandler<GetSalesRuleCouponAggregatedReportByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedReportByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesRuleCouponAggregatedReportByIdQueryHandler(IWhippetQueryRepository<SalesRuleCouponAggregatedReport> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>>> HandleAsync(GetSalesRuleCouponAggregatedReportByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<SalesRuleCouponAggregatedReport> result = await ((IWhippetExternalQueryRepository<SalesRuleCouponAggregatedReport, uint>)(Repository)).GetAsync(query.ID);
                return result.ToEnumerableResult();
            }
        }
    }
}
