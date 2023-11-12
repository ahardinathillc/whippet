using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetTaxRuleByIdQuery"/> objects.
    /// </summary>
    public class GetTaxRuleByIdQueryHandler : TaxRuleQueryHandlerBase<GetTaxRuleByIdQuery>, ITaxRuleQueryHandler<GetTaxRuleByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTaxRuleByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetTaxRuleByIdQueryHandler(IWhippetQueryRepository<TaxRule> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<TaxRule>>> HandleAsync(GetTaxRuleByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<TaxRule> queryResult = await ((IWhippetRepository<TaxRule, uint>)(Repository)).GetAsync(Convert.ToUInt32(query.ID));
                return queryResult.ToEnumerableResult();
            }
        }
    }
}