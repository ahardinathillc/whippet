using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Web.Mvc.Security.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetViewPermissionEntry"/> objects.
    /// </summary>
    public interface IWhippetViewPermissionEntryRepository : IWhippetEntityRepository<WhippetViewPermissionEntry, Guid>, IWhippetQueryRepository<WhippetViewPermissionEntry>
    {
        /// <summary>
        /// Retrieves all <see cref="WhippetViewPermissionEntry"/> objects for the specified <see cref="WhippetMvcSecurityPermission"/>.
        /// </summary>
        /// <param name="permission"><see cref="WhippetMvcSecurityPermission"/> to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> GetByPermission(WhippetMvcSecurityPermission permission, IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="WhippetViewPermissionEntry"/> objects for the specified <see cref="WhippetMvcSecurityPermission"/>.
        /// </summary>
        /// <param name="permission"><see cref="WhippetMvcSecurityPermission"/> to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> GetByPermissionAsync(WhippetMvcSecurityPermission permission, IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="WhippetViewPermissionEntry"/> objects for the specified collection of <see cref="WhippetMvcSecurityPermission"/> objects.
        /// </summary>
        /// <param name="permissions"><see cref="WhippetMvcSecurityPermission"/> objects to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> GetForPermissions(IEnumerable<WhippetMvcSecurityPermission> permissions, IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="WhippetViewPermissionEntry"/> objects for the specified collection of <see cref="WhippetMvcSecurityPermission"/> objects.
        /// </summary>
        /// <param name="permissions"><see cref="WhippetMvcSecurityPermission"/> objects to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> GetForPermissionsAsync(IEnumerable<WhippetMvcSecurityPermission> permissions, IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all view permission entries for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the permissions for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> GetByTenant(IWhippetTenant tenant);

        /// <summary>
        /// Gets all view permission entries for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the permissions for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> GetByTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
