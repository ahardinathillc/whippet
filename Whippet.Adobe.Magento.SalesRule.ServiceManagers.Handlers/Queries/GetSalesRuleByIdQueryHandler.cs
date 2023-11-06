using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSalesRuleByIdQuery"/> objects.
    /// </summary>
    public class GetSalesRuleByIdQueryHandler : SalesRuleQueryHandlerBase<GetSalesRuleByIdQuery>, ISalesRuleQueryHandler<GetSalesRuleByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesRuleByIdQueryHandler(IWhippetQueryRepository<SalesRule> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesRule>>> HandleAsync(GetSalesRuleByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<SalesRule> result = null;

                if ((Repository is IMagentoRowNumberEntityRepository<SalesRule>) && query.RowID.HasValue)
                {
                    result = await ((IMagentoRowNumberEntityRepository<SalesRule>)(Repository)).GetAsync(query.RowID.Value, query.RuleID);
                }
                else
                {
                    result = await ((IWhippetExternalQueryRepository<SalesRule, uint>)(Repository)).GetAsync(query.RuleID);
                }

                return result.ToEnumerableResult();
            }
        }
    }
}
