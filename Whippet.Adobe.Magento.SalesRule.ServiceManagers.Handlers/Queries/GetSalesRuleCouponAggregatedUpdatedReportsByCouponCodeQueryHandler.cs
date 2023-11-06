using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQuery"/> objects.
    /// </summary>
    public class GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQueryHandler : SalesRuleCouponAggregatedUpdatedReportQueryHandlerBase<GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQuery>, ISalesRuleCouponAggregatedUpdatedReportQueryHandler<GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQueryHandler(IWhippetQueryRepository<SalesRuleCouponAggregatedUpdatedReport> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedUpdatedReport>>> HandleAsync(GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedUpdatedReport>> result = await Repository.GetForCouponAsync(query.Code);
                return result;
            }
        }
    }
}
