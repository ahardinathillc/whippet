using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.AccessControl.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetRole"/> objects.
    /// </summary>
    public interface IWhippetRoleRepository : IWhippetEntityRepository<WhippetRole, Guid>, IWhippetQueryRepository<WhippetRole>
    {
        /// <summary>
        /// Gets the specified role based on its name.
        /// </summary>
        /// <param name="roleName">Name of the role to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to search for the role in.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<WhippetRole> GetByName(string roleName, IWhippetTenant tenant);

        /// <summary>
        /// Asynchronously gets the specified role based on its name.
        /// </summary>
        /// <param name="roleName">Name of the role to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to search for the role in.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<WhippetRole>> GetByNameAsync(string roleName, IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all roles for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the roles for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetRole>> GetByTenant(IWhippetTenant tenant);

        /// <summary>
        /// Asynchronously gets all roles for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the roles for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetRole>>> GetByTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
