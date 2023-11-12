using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetTaxClassByIdQuery"/> objects.
    /// </summary>
    public class GetTaxClassByIdQueryHandler : TaxClassQueryHandlerBase<GetTaxClassByIdQuery>, ITaxClassQueryHandler<GetTaxClassByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTaxClassByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetTaxClassByIdQueryHandler(IWhippetQueryRepository<TaxClass> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<TaxClass>>> HandleAsync(GetTaxClassByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<TaxClass> queryResult = await ((IWhippetRepository<TaxClass, short>)(Repository)).GetAsync(query.ID);
                return queryResult.ToEnumerableResult();
            }
        }
    }
}