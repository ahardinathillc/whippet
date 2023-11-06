using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerRestEndpoint"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerRestEndpointRepository : IWhippetEntityRepository<MultichannelOrderManagerRestEndpoint, Guid>, IWhippetQueryRepository<MultichannelOrderManagerRestEndpoint>
    {
        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MultichannelOrderManagerRestEndpoint"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerRestEndpoint>> GetForTenant(IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MultichannelOrderManagerRestEndpoint"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerRestEndpoint>>> GetForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
