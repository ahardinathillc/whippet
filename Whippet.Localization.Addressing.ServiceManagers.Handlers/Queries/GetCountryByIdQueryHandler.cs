using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Queries;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetCountryByIdQuery"/> objects.
    /// </summary>
    public class GetCountryByIdQueryHandler : CountryQueryHandlerBase<GetCountryByIdQuery>, ICountryQueryHandler<GetCountryByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCountryByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetCountryByIdQueryHandler(IWhippetQueryRepository<Country> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<Country>>> HandleAsync(GetCountryByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<Country> queryResult = await Repository.GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<Country>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}
