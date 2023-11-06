using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerRestEndpointsForTenantQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerRestEndpointsForTenantQueryHandler : MultichannelOrderManagerRestEndpointQueryHandlerBase<GetMultichannelOrderManagerRestEndpointsForTenantQuery>, IMultichannelOrderManagerRestEndpointQueryHandler<GetMultichannelOrderManagerRestEndpointsForTenantQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerRestEndpointsForTenantQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerRestEndpointsForTenantQueryHandler(IWhippetQueryRepository<MultichannelOrderManagerRestEndpoint> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerRestEndpoint>>> HandleAsync(GetMultichannelOrderManagerRestEndpointsForTenantQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerRestEndpoint>> queryResult = await Repository.GetForTenantAsync(query.Tenant);
                return queryResult;
            }
        }
    }
}
