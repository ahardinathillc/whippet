using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="WhippetIpAddressBlacklist"/> entity objects.
    /// </summary>
    public interface IWhippetIpAddressBlacklistRepository : IWhippetEntityRepository<WhippetIpAddressBlacklist, Guid>, IWhippetRepository<WhippetIpAddressBlacklist, Guid>, IWhippetQueryRepository<WhippetIpAddressBlacklist>
    {
        /// <summary>
        /// Retrieves the <see cref="WhippetIpAddressBlacklist"/> with the specified IP address.
        /// </summary>
        /// <param name="ipAddress">IP address to search for.</param>
        /// <param name="tenant">Tenant to filter by, if any.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>> Get(string ipAddress, IWhippetTenant tenant);

        /// <summary>
        /// Retrieves the <see cref="WhippetIpAddressBlacklist"/> with the specified IP address.
        /// </summary>
        /// <param name="ipAddress">IP address to search for.</param>
        /// <param name="tenant">Tenant to filter by, if any.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>>> GetAsync(string ipAddress, IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
