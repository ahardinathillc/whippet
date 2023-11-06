using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllTaxRatesQuery"/> objects.
    /// </summary>
    public class GetAllTaxRatesQueryHandler : TaxRateQueryHandlerBase<GetAllTaxRatesQuery>, ITaxRateQueryHandler<GetAllTaxRatesQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTaxRatesQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllTaxRatesQueryHandler(IWhippetQueryRepository<TaxRate> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<TaxRate>>> HandleAsync(GetAllTaxRatesQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<TaxRate>> queryResult = await ((IWhippetRepository<TaxRate, int>)(Repository)).GetAllAsync();
                return queryResult;
            }
        }
    }
}
