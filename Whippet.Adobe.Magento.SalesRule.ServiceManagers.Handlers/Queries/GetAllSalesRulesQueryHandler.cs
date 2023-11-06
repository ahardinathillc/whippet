using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllSalesRulesQuery"/> objects.
    /// </summary>
    public class GetAllSalesRulesQueryHandler : SalesRuleQueryHandlerBase<GetAllSalesRulesQuery>, ISalesRuleQueryHandler<GetAllSalesRulesQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesRulesQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllSalesRulesQueryHandler(IWhippetQueryRepository<SalesRule> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesRule>>> HandleAsync(GetAllSalesRulesQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesRule>> result = await ((IMagentoRowNumberEntityRepository<SalesRule>)(Repository)).GetAllAsync();
                return result;
            }
        }
    }
}
