using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Web.Mvc.Security.EntityMappings;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Web.Mvc.Security.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetViewPermissionEntry"/> objects.
    /// </summary>
    public class WhippetViewPermissionEntryRepository : WhippetEntityRepository<WhippetViewPermissionEntry>, IWhippetViewPermissionEntryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetViewPermissionEntryRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetViewPermissionEntryRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <see cref="WhippetViewPermissionEntry"/> objects for the specified <see cref="WhippetMvcSecurityPermission"/>.
        /// </summary>
        /// <param name="permission"><see cref="WhippetMvcSecurityPermission"/> to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> GetByPermission(WhippetMvcSecurityPermission permission, IWhippetTenant tenant)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetByPermissionAsync(permission, tenant)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetViewPermissionEntry"/> objects for the specified <see cref="WhippetMvcSecurityPermission"/>.
        /// </summary>
        /// <param name="permission"><see cref="WhippetMvcSecurityPermission"/> to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> GetByPermissionAsync(WhippetMvcSecurityPermission permission, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<WhippetViewPermissionEntry> queryResults = await Context.QueryOver<WhippetViewPermissionEntry>()
                    .Where(entry => entry.PermissionID == permission.ID)
                    .JoinQueryOver(wpe => wpe.Tenant)
                    .Where(wt => wt.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetViewPermissionEntry"/> objects for the specified collection of <see cref="WhippetMvcSecurityPermission"/> objects.
        /// </summary>
        /// <param name="permissions"><see cref="WhippetMvcSecurityPermission"/> objects to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> GetForPermissions(IEnumerable<WhippetMvcSecurityPermission> permissions, IWhippetTenant tenant)
        {
            if (permissions == null)
            {
                throw new ArgumentNullException(nameof(permissions));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetForPermissionsAsync(permissions, tenant)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetViewPermissionEntry"/> objects for the specified collection of <see cref="WhippetMvcSecurityPermission"/> objects.
        /// </summary>
        /// <param name="permissions"><see cref="WhippetMvcSecurityPermission"/> objects to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> GetForPermissionsAsync(IEnumerable<WhippetMvcSecurityPermission> permissions, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (permissions == null)
            {
                throw new ArgumentNullException(nameof(permissions));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> result = await GetByTenantAsync(tenant, cancellationToken);
                List<WhippetViewPermissionEntry> filteredEntries = null;

                if (result.IsSuccess && result.HasItem)
                {
                    filteredEntries = new List<WhippetViewPermissionEntry>(result.Item.Where(wvpe => permissions.Select(p => p.ID).Contains(wvpe.PermissionID)));
                    result = new WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>(WhippetResult.Success, filteredEntries);
                }

                return result;
            }
        }

        /// <summary>
        /// Gets all view permission entries for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the permissions for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> GetByTenant(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetByTenantAsync(tenant)).Result;
            }
        }

        /// <summary>
        /// Gets all view permission entries for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the permissions for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> GetByTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<WhippetViewPermissionEntry> queryResults = await Context.QueryOver<WhippetViewPermissionEntry>()
                    .JoinQueryOver(wpe => wpe.Tenant)
                    .Where(wt => wt.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
