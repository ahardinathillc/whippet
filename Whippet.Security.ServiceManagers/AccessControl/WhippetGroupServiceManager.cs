using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Security.AccessControl.Extensions;
using Athi.Whippet.Security.AccessControl.Repositories;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Queries;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Commands;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Commands;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IWhippetGroup"/> domain objects.
    /// </summary>
    public class WhippetGroupServiceManager : ServiceManager, IDisposable
    {
        private const string SYSGROUP__USERS = "Users";
        private const string SYSGROUP__ADMINS = "Administrators";

        /// <summary>
        /// Gets the <see cref="IWhippetGroupRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetGroupRepository GroupRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupServiceManager"/> class with the specified <see cref="IWhippetGroupRepository"/> object.
        /// </summary>
        /// <param name="groupRepository"><see cref="IWhippetGroupRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetGroupServiceManager(IWhippetGroupRepository groupRepository)
            : base()
        {
            if (groupRepository == null)
            {
                throw new ArgumentNullException(nameof(groupRepository));
            }
            else
            {
                GroupRepository = groupRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupServiceManager"/> class with the specified <see cref="IWhippetGroupRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="groupRepository"><see cref="IWhippetGroupRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetGroupServiceManager(IWhippetServiceContext serviceLocator, IWhippetGroupRepository groupRepository)
            : base(serviceLocator)
        {
            if (groupRepository == null)
            {
                throw new ArgumentNullException(nameof(groupRepository));
            }
            else
            {
                GroupRepository = groupRepository;
            }
        }

        /// <summary>
        /// Gets the specified <see cref="IWhippetGroup"/> by its name and associated <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="name">Name of the group to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the group is associated with or <see langword="null"/> to use the default tenant.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetGroup>> GetWhippetGroup(string name, IWhippetTenant tenant = null)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                IWhippetGroupQueryHandler<GetWhippetGroupByNameQuery> handler = new GetWhippetGroupByNameQueryHandler(GroupRepository);
                WhippetResultContainer<IEnumerable<WhippetGroup>> result = await handler.HandleAsync(new GetWhippetGroupByNameQuery(name, tenant));

                return new WhippetResultContainer<IWhippetGroup>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the specified <see cref="IWhippetGroup"/> by its ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="IWhippetGroup"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetGroup>> GetWhippetGroup(Guid id)
        {
            IWhippetGroupQueryHandler<GetWhippetGroupByIdQuery> handler = new GetWhippetGroupByIdQueryHandler(GroupRepository);
            WhippetResultContainer<IEnumerable<WhippetGroup>> result = await handler.HandleAsync(new GetWhippetGroupByIdQuery(id));

            return new WhippetResultContainer<IWhippetGroup>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IWhippetGroup"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to retrieve groups for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetGroup>>> GetWhippetGroups(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IWhippetGroupQueryHandler<GetWhippetGroupsByTenantQuery> handler = new GetWhippetGroupsByTenantQueryHandler(GroupRepository);
                WhippetResultContainer<IEnumerable<WhippetGroup>> result = await handler.HandleAsync(new GetWhippetGroupsByTenantQuery(tenant));

                return new WhippetResultContainer<IEnumerable<IWhippetGroup>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new user group.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroup"/> to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IWhippetGroup> CreateWhippetGroup(IWhippetGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                return Task.Run(() => CreateWhippetGroupAsync(group)).Result;
            }
        }

        /// <summary>
        /// Creates a new user group.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroup"/> to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetGroup>> CreateWhippetGroupAsync(IWhippetGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetGroupCommandHandler<CreateWhippetGroupCommand> handler = new CreateWhippetGroupCommandHandler(GroupRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateWhippetGroupCommand(group.ToWhippetGroup()));

                    if (createResult.IsSuccess)
                    {
                        await GroupRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IWhippetGroup>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetGroup>(createResult, group);

            }
        }

        /// <summary>
        /// Updates an existing Whippet group.
        /// </summary>
        /// <param name="group">Group to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated group.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetGroup> UpdateWhippetGroup(IWhippetGroup group)
        {
            return Task<WhippetResultContainer<IWhippetGroup>>.Run(() => UpdateWhippetGroupAsync(group)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet group.
        /// </summary>
        /// <param name="group">Group to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated group.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetGroup>> UpdateWhippetGroupAsync(IWhippetGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetGroupCommandHandler<UpdateWhippetGroupCommand> handler = new UpdateWhippetGroupCommandHandler(GroupRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateWhippetGroupCommand(group.ToWhippetGroup()));

                    if (updateResult.IsSuccess)
                    {
                        await GroupRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetGroup>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetGroup>(updateResult, group);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet group.
        /// </summary>
        /// <param name="group">Group to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted group.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetGroup> DeleteWhippetGroup(IWhippetGroup group)
        {
            return Task<WhippetResultContainer<IWhippetGroup>>.Run(() => DeleteWhippetGroupAsync(group)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet group.
        /// </summary>
        /// <param name="group">Group to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted group.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetGroup>> DeleteWhippetGroupAsync(IWhippetGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetGroupCommandHandler<DeleteWhippetGroupCommand> handler = new DeleteWhippetGroupCommandHandler(GroupRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteWhippetGroupCommand(group.ToWhippetGroup()));

                    if (updateResult.IsSuccess)
                    {
                        await GroupRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetGroup>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetGroup>(updateResult, group);
            }
        }

        /// <summary>
        /// Creates the default system groups for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to create the groups for.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetResult CreateDefaultGroups(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => CreateDefaultGroupsAsync(tenant)).Result;
            }
        }

        /// <summary>
        /// Creates the default system groups for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to create the groups for.</param>
        /// <returns><see cref="WhippetResult"/> of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResult> CreateDefaultGroupsAsync(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                WhippetResultContainer<IWhippetGroup> groupResult = null;

                IWhippetUser sysUser = null;

                IWhippetGroup adminGroup = null;
                IWhippetGroup usersGroup = null;

                bool createAdminGroup = false;
                bool createUsersGroup = false;

                groupResult = await GetAdministratorsGroup(tenant);

                if (groupResult.IsSuccess)
                {
                    createAdminGroup = !groupResult.HasItem;

                    groupResult = await GetUsersGroup(tenant);

                    if (groupResult.IsSuccess)
                    {
                        createUsersGroup = !groupResult.HasItem;
                    }
                    else
                    {
                        result = groupResult.Result;
                    }
                }
                else
                {
                    result = groupResult.Result;
                }

                if (result.IsSuccess)
                {
                    if (createAdminGroup)
                    {
                        adminGroup = new WhippetGroup(Guid.NewGuid(), SYSGROUP__ADMINS, null, true, tenant.ToWhippetTenant(), Instant.FromDateTimeUtc(DateTime.UtcNow), sysUser.CreateNonInteractiveSystemUser().ID, null, null, true, false);
                    }

                    if (createUsersGroup)
                    {
                        usersGroup = new WhippetGroup(Guid.NewGuid(), SYSGROUP__USERS, null, true, tenant.ToWhippetTenant(), Instant.FromDateTimeUtc(DateTime.UtcNow), sysUser.CreateNonInteractiveSystemUser().ID, null, null, true, false);
                    }

                    if (adminGroup != null)
                    {
                        groupResult = await CreateWhippetGroupAsync(adminGroup);
                    }

                    if (groupResult.IsSuccess && usersGroup != null)
                    {
                        groupResult = await CreateWhippetGroupAsync(usersGroup);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the administrators system group.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetGroup>> GetAdministratorsGroup(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return await GetSystemGroup(tenant, SYSGROUP__ADMINS);
            }
        }

        /// <summary>
        /// Gets the users system group.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetGroup>> GetUsersGroup(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return await GetSystemGroup(tenant, SYSGROUP__USERS);
            }
        }

        /// <summary>
        /// Gets the system group with the specified name.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private async Task<WhippetResultContainer<IWhippetGroup>> GetSystemGroup(IWhippetTenant tenant, string groupName)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else if (String.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                WhippetResultContainer<IEnumerable<IWhippetGroup>> tenantGroups = await GetWhippetGroups(tenant);
                WhippetResultContainer<IWhippetGroup> groupResult = null;

                if (tenantGroups.IsSuccess)
                {
                    groupResult = new WhippetResultContainer<IWhippetGroup>(tenantGroups.Result, tenantGroups.Item.Where(g => String.Equals(g.Name, groupName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault());
                }
                else
                {
                    groupResult = new WhippetResultContainer<IWhippetGroup>(tenantGroups.Result, null);
                }

                return groupResult;
            }
        }
    }
}
