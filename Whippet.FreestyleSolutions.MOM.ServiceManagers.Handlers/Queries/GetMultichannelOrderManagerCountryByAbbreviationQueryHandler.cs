using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerCountryByAbbreviationQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerCountryByAbbreviationQueryHandler : MultichannelOrderManagerCountryQueryHandlerBase<GetMultichannelOrderManagerCountryByAbbreviationQuery>, IMultichannelOrderManagerCountryQueryHandler<GetMultichannelOrderManagerCountryByAbbreviationQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCountryByAbbreviationQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerCountryByAbbreviationQueryHandler(IWhippetQueryRepository<MultichannelOrderManagerCountry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>> HandleAsync(GetMultichannelOrderManagerCountryByAbbreviationQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<MultichannelOrderManagerCountry> result = await ((IMultichannelOrderManagerCountryRepository)(Repository)).GetCountryByAbbreviationAsync(query.Abbreviation);
                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>(result.Result, new[] { result.Item });
            }
        }
    }
}
