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
    /// Represents a data repository for managing <see cref="WhippetPasswordBlacklist"/> entity objects.
    /// </summary>
    public interface IWhippetPasswordBlacklistRepository : IWhippetEntityRepository<WhippetPasswordBlacklist, Guid>, IWhippetRepository<WhippetPasswordBlacklist, Guid>, IWhippetQueryRepository<WhippetPasswordBlacklist>
    {
        /// <summary>
        /// Retrieves the <see cref="WhippetPasswordBlacklist"/> with the specified password.
        /// </summary>
        /// <param name="password">Password to search for.</param>
        /// <param name="tenant">Tenant to filter by, if any.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<WhippetPasswordBlacklist>> Get(string password, IWhippetTenant tenant);

        /// <summary>
        /// Retrieves the <see cref="WhippetPasswordBlacklist"/> with the specified password.
        /// </summary>
        /// <param name="password">Password to search for.</param>
        /// <param name="tenant">Tenant to filter by, if any.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<WhippetPasswordBlacklist>>> GetAsync(string password, IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}