using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.AccessControl.Extensions;
using Athi.Whippet.Security.AccessControl.Repositories;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Queries;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Commands;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IWhippetRole"/> domain objects.
    /// </summary>
    public class WhippetRoleServiceManager : ServiceManager, IDisposable
    {
        private const string SYSROLE__USER = "User";
        private const string SYSROLE__ADMIN = "Administrator";

        /// <summary>
        /// Gets the <see cref="IWhippetRoleRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetRoleRepository RoleRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleServiceManager"/> class with the specified <see cref="IWhippetRoleRepository"/> object.
        /// </summary>
        /// <param name="roleRepository"><see cref="IWhippetRoleRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetRoleServiceManager(IWhippetRoleRepository roleRepository)
            : base()
        {
            if (roleRepository == null)
            {
                throw new ArgumentNullException(nameof(roleRepository));
            }
            else
            {
                RoleRepository = roleRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleServiceManager"/> class with the specified <see cref="IWhippetRoleRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="roleRepository"><see cref="IWhippetRoleRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetRoleServiceManager(IWhippetServiceContext serviceLocator, IWhippetRoleRepository roleRepository)
            : base(serviceLocator)
        {
            if (roleRepository == null)
            {
                throw new ArgumentNullException(nameof(roleRepository));
            }
            else
            {
                RoleRepository = roleRepository;
            }
        }

        /// <summary>
        /// Gets the specified <see cref="IWhippetRole"/> by its name and associated <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="name">Name of the role to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the role is associated with or <see langword="null"/> to use the default tenant.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetRole>> GetWhippetRole(string name, IWhippetTenant tenant = null)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                IWhippetRoleQueryHandler<GetWhippetRoleByNameQuery> handler = new GetWhippetRoleByNameQueryHandler(RoleRepository);
                WhippetResultContainer<IEnumerable<WhippetRole>> result = await handler.HandleAsync(new GetWhippetRoleByNameQuery(name, tenant));

                return new WhippetResultContainer<IWhippetRole>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the specified <see cref="IWhippetRole"/> by its ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="IWhippetRole"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetRole>> GetWhippetRole(Guid id)
        {
            IWhippetRoleQueryHandler<GetWhippetRoleByIdQuery> handler = new GetWhippetRoleByIdQueryHandler(RoleRepository);
            WhippetResultContainer<IEnumerable<WhippetRole>> result = await handler.HandleAsync(new GetWhippetRoleByIdQuery(id));

            return new WhippetResultContainer<IWhippetRole>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IWhippetRole"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to retrieve roles for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetRole>>> GetWhippetRoles(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IWhippetRoleQueryHandler<GetWhippetRolesByTenantQuery> handler = new GetWhippetRolesByTenantQueryHandler(RoleRepository);
                WhippetResultContainer<IEnumerable<WhippetRole>> result = await handler.HandleAsync(new GetWhippetRolesByTenantQuery(tenant));

                return new WhippetResultContainer<IEnumerable<IWhippetRole>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new user role.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRole"/> to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IWhippetRole> CreateWhippetRole(IWhippetRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                return Task.Run(() => CreateWhippetRoleAsync(role)).Result;
            }
        }

        /// <summary>
        /// Creates a new user role.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRole"/> to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetRole>> CreateWhippetRoleAsync(IWhippetRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetRoleCommandHandler<CreateWhippetRoleCommand> handler = new CreateWhippetRoleCommandHandler(RoleRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateWhippetRoleCommand(role.ToWhippetRole()));

                    if (createResult.IsSuccess)
                    {
                        await RoleRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IWhippetRole>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetRole>(createResult, role);

            }
        }

        /// <summary>
        /// Updates an existing Whippet role.
        /// </summary>
        /// <param name="role">Role to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated role.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetRole> UpdateWhippetRole(IWhippetRole role)
        {
            return Task<WhippetResultContainer<IWhippetRole>>.Run(() => UpdateWhippetRoleAsync(role)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet role.
        /// </summary>
        /// <param name="role">Role to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated role.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetRole>> UpdateWhippetRoleAsync(IWhippetRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetRoleCommandHandler<UpdateWhippetRoleCommand> handler = new UpdateWhippetRoleCommandHandler(RoleRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateWhippetRoleCommand(role.ToWhippetRole()));

                    if (updateResult.IsSuccess)
                    {
                        await RoleRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetRole>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetRole>(updateResult, role);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet role.
        /// </summary>
        /// <param name="role">Role to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted role.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetRole> DeleteWhippetRole(IWhippetRole role)
        {
            return Task<WhippetResultContainer<IWhippetRole>>.Run(() => DeleteWhippetRoleAsync(role)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet role.
        /// </summary>
        /// <param name="role">Role to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted role.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetRole>> DeleteWhippetRoleAsync(IWhippetRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetRoleCommandHandler<DeleteWhippetRoleCommand> handler = new DeleteWhippetRoleCommandHandler(RoleRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteWhippetRoleCommand(role.ToWhippetRole()));

                    if (updateResult.IsSuccess)
                    {
                        await RoleRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetRole>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetRole>(updateResult, role);
            }
        }

        /// <summary>
        /// Creates the default system roles for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to create the roles for.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetResult CreateDefaultRoles(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => CreateDefaultRolesAsync(tenant)).Result;
            }
        }

        /// <summary>
        /// Creates the default system roles for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to create the roles for.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResult> CreateDefaultRolesAsync(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                WhippetResultContainer<IWhippetRole> roleResult = null;

                IWhippetUser sysUser = null;

                IWhippetRole adminRole = null;
                IWhippetRole usersRole = null;

                bool createAdminRole = false;
                bool createUsersRole = false;

                roleResult = await GetAdministratorRole(tenant);

                if (roleResult.IsSuccess)
                {
                    createAdminRole = !roleResult.HasItem;

                    roleResult = await GetUserRole(tenant);

                    if (roleResult.IsSuccess)
                    {
                        createUsersRole = !roleResult.HasItem;
                    }
                    else
                    {
                        result = roleResult.Result;
                    }
                }
                else
                {
                    result = roleResult.Result;
                }

                if (result.IsSuccess)
                {
                    if (createAdminRole)
                    {
                        adminRole = new WhippetRole(Guid.NewGuid(), SYSROLE__ADMIN, null, true, tenant.ToWhippetTenant(), Instant.FromDateTimeUtc(DateTime.UtcNow), sysUser.CreateNonInteractiveSystemUser().ID, null, null, true, false);
                    }

                    if (createUsersRole)
                    {
                        usersRole = new WhippetRole(Guid.NewGuid(), SYSROLE__USER, null, true, tenant.ToWhippetTenant(), Instant.FromDateTimeUtc(DateTime.UtcNow), sysUser.CreateNonInteractiveSystemUser().ID, null, null, true, false);
                    }

                    if (adminRole != null)
                    {
                        roleResult = await CreateWhippetRoleAsync(adminRole);
                    }

                    if (roleResult.IsSuccess && usersRole != null)
                    {
                        roleResult = await CreateWhippetRoleAsync(usersRole);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the administrators system role.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetRole>> GetAdministratorRole(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return await GetSystemRole(tenant, SYSROLE__ADMIN);
            }
        }

        /// <summary>
        /// Gets the users system role.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetRole>> GetUserRole(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return await GetSystemRole(tenant, SYSROLE__USER);
            }
        }

        /// <summary>
        /// Gets the system role with the specified name.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private async Task<WhippetResultContainer<IWhippetRole>> GetSystemRole(IWhippetTenant tenant, string roleName)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                WhippetResultContainer<IEnumerable<IWhippetRole>> tenantRoles = await GetWhippetRoles(tenant);
                WhippetResultContainer<IWhippetRole> roleResult = null;

                if (tenantRoles.IsSuccess)
                {
                    roleResult = new WhippetResultContainer<IWhippetRole>(tenantRoles.Result, tenantRoles.Item.Where(g => String.Equals(g.Name, roleName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault());
                }
                else
                {
                    roleResult = new WhippetResultContainer<IWhippetRole>(tenantRoles.Result, null);
                }

                return roleResult;
            }
        }
    }
}
