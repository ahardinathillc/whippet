using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSalesRuleCouponByIdQuery"/> objects.
    /// </summary>
    public class GetSalesRuleCouponByIdQueryHandler : SalesRuleCouponQueryHandlerBase<GetSalesRuleCouponByIdQuery>, ISalesRuleCouponQueryHandler<GetSalesRuleCouponByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesRuleCouponByIdQueryHandler(IWhippetQueryRepository<SalesRuleCoupon> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesRuleCoupon>>> HandleAsync(GetSalesRuleCouponByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<SalesRuleCoupon> result = await ((IWhippetExternalQueryRepository<SalesRuleCoupon, uint>)(Repository)).GetAsync(query.CouponID);
                return result.ToEnumerableResult();
            }
        }
    }
}
