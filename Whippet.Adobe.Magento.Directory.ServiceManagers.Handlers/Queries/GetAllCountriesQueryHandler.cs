using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllCountriesQuery"/> objects.
    /// </summary>
    public class GetAllCountriesQueryHandler : CountryQueryHandlerBase<GetAllCountriesQuery>, ICountryQueryHandler<GetAllCountriesQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCountriesQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllCountriesQueryHandler(IWhippetQueryRepository<Country> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<Country>>> HandleAsync(GetAllCountriesQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<Country>> result = await ((IWhippetExternalQueryRepository<Country, WhippetNonNullableString>)(Repository)).GetAllAsync();
                return result;
            }
        }
    }
}
