using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSalesRuleCouponBySalesRuleQuery"/> objects.
    /// </summary>
    public class GetSalesRuleCouponBySalesRuleQueryHandler : SalesRuleCouponQueryHandlerBase<GetSalesRuleCouponBySalesRuleQuery>, ISalesRuleCouponQueryHandler<GetSalesRuleCouponBySalesRuleQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponBySalesRuleQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesRuleCouponBySalesRuleQueryHandler(IWhippetQueryRepository<SalesRuleCoupon> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesRuleCoupon>>> HandleAsync(GetSalesRuleCouponBySalesRuleQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesRuleCoupon>> result = await Repository.GetForRuleAsync(query.SalesRule);
                return result;
            }
        }
    }
}
