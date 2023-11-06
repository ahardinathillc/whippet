using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.Tenants.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetTenant"/> objects.
    /// </summary>
    public interface IWhippetTenantRepository : IWhippetEntityRepository<WhippetTenant, Guid>, IWhippetQueryRepository<WhippetTenant>
    {
        /// <summary>
        /// Creates the root tenant.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<WhippetTenant> CreateRootTenant();

        /// <summary>
        /// Creates the root tenant.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<WhippetTenant>> CreateRootTenantAsync(CancellationToken? cancellationToken = null);
    }
}
