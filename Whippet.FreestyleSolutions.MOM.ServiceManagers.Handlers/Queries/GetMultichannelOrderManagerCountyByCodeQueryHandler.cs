using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerCountyByCodeQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerCountyByCodeQueryHandler : MultichannelOrderManagerCountyQueryHandlerBase<GetMultichannelOrderManagerCountyByCodeQuery>, IMultichannelOrderManagerCountyQueryHandler<GetMultichannelOrderManagerCountyByCodeQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCountyByCodeQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerCountyByCodeQueryHandler(IWhippetQueryRepository<MultichannelOrderManagerCounty> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>> HandleAsync(GetMultichannelOrderManagerCountyByCodeQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<MultichannelOrderManagerCounty> result = await Repository.GetCountyByCodeAsync(query.Code, query.StateAbbreviation);
                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>(result.Result, new[] { result.Item });
            }
        }
    }
}
