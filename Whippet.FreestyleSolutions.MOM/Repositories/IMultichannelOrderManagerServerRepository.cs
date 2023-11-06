using System;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerServer"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerServerRepository : IWhippetEntityRepository<MultichannelOrderManagerServer, Guid>, IWhippetRepository<MultichannelOrderManagerServer, Guid>, IWhippetQueryRepository<MultichannelOrderManagerServer>
    {
        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerServer"/> object with the specified server name.
        /// </summary>
        /// <param name="serverName">Server name of the <see cref="MultichannelOrderManagerServer"/>.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the server is registered with.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MultichannelOrderManagerServer> Get(string serverName, IWhippetTenant tenant);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerServer"/> object with the specified server name.
        /// </summary>
        /// <param name="serverName">Server name of the <see cref="MultichannelOrderManagerServer"/>.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the server is registered with.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MultichannelOrderManagerServer>> GetAsync(string serverName, IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerServer"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="MultichannelOrderManagerServer"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerServer>> GetServersForTenant(IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerServer"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="MultichannelOrderManagerServer"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerServer>>> GetServersForTenantAsync(IWhippetTenant tenant);
    }
}

