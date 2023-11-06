using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSalesRuleCouponAggregatedReportsForPeriodQuery"/> objects.
    /// </summary>
    public class GetSalesRuleCouponAggregatedReportsForPeriodQueryHandler : SalesRuleCouponAggregatedReportQueryHandlerBase<GetSalesRuleCouponAggregatedReportsForPeriodQuery>, ISalesRuleCouponAggregatedReportQueryHandler<GetSalesRuleCouponAggregatedReportsForPeriodQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedReportsForPeriodQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesRuleCouponAggregatedReportsForPeriodQueryHandler(IWhippetQueryRepository<SalesRuleCouponAggregatedReport> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>>> HandleAsync(GetSalesRuleCouponAggregatedReportsForPeriodQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>> result = await Repository.GetForPeriodAsync(query.FromPeriod, query.ToPeriod);
                return result;
            }
        }
    }
}
