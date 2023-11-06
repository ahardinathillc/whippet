using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerCountryByCodeQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerCountryByCodeQueryHandler : MultichannelOrderManagerCountryQueryHandlerBase<GetMultichannelOrderManagerCountryByCodeQuery>, IMultichannelOrderManagerCountryQueryHandler<GetMultichannelOrderManagerCountryByCodeQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCountryByCodeQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerCountryByCodeQueryHandler(IWhippetQueryRepository<MultichannelOrderManagerCountry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>> HandleAsync(GetMultichannelOrderManagerCountryByCodeQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<MultichannelOrderManagerCountry> result = await ((IMultichannelOrderManagerCountryRepository)(Repository)).GetCountryByCodeAsync(query.Code);
                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>(result.Result, new[] { result.Item });
            }
        }
    }
}
