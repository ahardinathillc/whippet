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
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Web.Mvc.Security.Extensions;
using Athi.Whippet.Web.Mvc.Security.Repositories;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Queries;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Commands;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IWhippetViewPermissionEntry"/> domain objects.
    /// </summary>
    public class WhippetViewPermissionEntryServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetViewPermissionEntryRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetViewPermissionEntryRepository PermissionRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntryServiceManager"/> class with the specified <see cref="IWhippetViewPermissionEntryRepository"/> object.
        /// </summary>
        /// <param name="permissionRepository"><see cref="IWhippetViewPermissionEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetViewPermissionEntryServiceManager(IWhippetViewPermissionEntryRepository permissionRepository)
            : base()
        {
            if (permissionRepository == null)
            {
                throw new ArgumentNullException(nameof(permissionRepository));
            }
            else
            {
                PermissionRepository = permissionRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntryServiceManager"/> class with the specified <see cref="IWhippetViewPermissionEntryRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="permissionRepository"><see cref="IWhippetViewPermissionEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetViewPermissionEntryServiceManager(IWhippetServiceContext serviceLocator, IWhippetViewPermissionEntryRepository permissionRepository)
            : base(serviceLocator)
        {
            if (permissionRepository == null)
            {
                throw new ArgumentNullException(nameof(permissionRepository));
            }
            else
            {
                PermissionRepository = permissionRepository;
            }
        }

        /// <summary>
        /// Gets the <see cref="IWhippetViewPermissionEntry"/> based on the specified ID.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetViewPermissionEntry>> GetPermissionEntry(Guid id)
        {
            IWhippetViewPermissionEntryQueryHandler<GetWhippetViewPermissionEntryByIdQuery> handler = new GetWhippetViewPermissionEntryByIdQueryHandler(PermissionRepository);
            WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> result = await handler.HandleAsync(new GetWhippetViewPermissionEntryByIdQuery(id));

            return new WhippetResultContainer<IWhippetViewPermissionEntry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IWhippetViewPermissionEntry"/> objects for the specified <see cref="WhippetMvcSecurityPermission"/>.
        /// </summary>
        /// <param name="permission"><see cref="WhippetMvcSecurityPermission"/> to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetViewPermissionEntry>>> GetPermissionEntries(WhippetMvcSecurityPermission permission, IWhippetTenant tenant)
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
                IWhippetViewPermissionEntryQueryHandler<GetWhippetViewPermissionEntriesByPermissionQuery> handler = new GetWhippetViewPermissionEntriesByPermissionQueryHandler(PermissionRepository);
                WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> result = await handler.HandleAsync(new GetWhippetViewPermissionEntriesByPermissionQuery(permission, tenant));

                return new WhippetResultContainer<IEnumerable<IWhippetViewPermissionEntry>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetViewPermissionEntry"/> objects for the specified collection of <see cref="WhippetMvcSecurityPermission"/> objects.
        /// </summary>
        /// <param name="permissions"><see cref="WhippetMvcSecurityPermission"/> objects to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetViewPermissionEntry>>> GetPermissionEntries(IEnumerable<WhippetMvcSecurityPermission> permissions, IWhippetTenant tenant)
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
                IWhippetViewPermissionEntryQueryHandler<GetWhippetViewPermissionEntriesByPermissionsQuery> handler = new GetWhippetViewPermissionEntriesByPermissionsQueryHandler(PermissionRepository);
                WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> result = await handler.HandleAsync(new GetWhippetViewPermissionEntriesByPermissionsQuery(permissions, tenant));

                return new WhippetResultContainer<IEnumerable<IWhippetViewPermissionEntry>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetViewPermissionEntry"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetViewPermissionEntry>>> GetPermissionEntries(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IWhippetViewPermissionEntryQueryHandler<GetWhippetViewPermissionEntriesByTenantQuery> handler = new GetWhippetViewPermissionEntriesByTenantQueryHandler(PermissionRepository);
                WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> result = await handler.HandleAsync(new GetWhippetViewPermissionEntriesByTenantQuery(tenant));

                return new WhippetResultContainer<IEnumerable<IWhippetViewPermissionEntry>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new Whippet view permission entry.
        /// </summary>
        /// <param name="permission">View permission entry to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created permission entr.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetViewPermissionEntry> CreateWhippetViewPermissionEntry(IWhippetViewPermissionEntry permission)
        {
            return Task<WhippetResultContainer<IWhippetViewPermissionEntry>>.Run(() => CreateWhippetViewPermissionEntryAsync(permission)).Result;
        }

        /// <summary>
        /// Creates a new Whippet view permission entry.
        /// </summary>
        /// <param name="permission">View permission entry to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created permission.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetViewPermissionEntry>> CreateWhippetViewPermissionEntryAsync(IWhippetViewPermissionEntry permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetCommandHandler<CreateWhippetViewPermissionEntryCommand> handler = new CreateWhippetViewPermissionEntryCommandHandler(PermissionRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateWhippetViewPermissionEntryCommand(permission.ToWhippetViewPermissionEntry()));

                    if (createResult.IsSuccess)
                    {
                        await PermissionRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IWhippetViewPermissionEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetViewPermissionEntry>(createResult, permission);
            }
        }

        /// <summary>
        /// Updates an existing Whippet permission.
        /// </summary>
        /// <param name="permission">Permission to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated permission.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetViewPermissionEntry> UpdateWhippetViewPermissionEntry(IWhippetViewPermissionEntry permission)
        {
            return Task<WhippetResultContainer<IWhippetViewPermissionEntry>>.Run(() => UpdateWhippetViewPermissionEntryAsync(permission)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet permission.
        /// </summary>
        /// <param name="permission">Permission to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated permission.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetViewPermissionEntry>> UpdateWhippetViewPermissionEntryAsync(IWhippetViewPermissionEntry permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateWhippetViewPermissionEntryCommand> handler = new UpdateWhippetViewPermissionEntryCommandHandler(PermissionRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateWhippetViewPermissionEntryCommand(permission.ToWhippetViewPermissionEntry()));

                    if (updateResult.IsSuccess)
                    {
                        await PermissionRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetViewPermissionEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetViewPermissionEntry>(updateResult, permission);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet permission.
        /// </summary>
        /// <param name="permission">Permission to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted permission.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetViewPermissionEntry> DeleteWhippetViewPermissionEntry(IWhippetViewPermissionEntry permission)
        {
            return Task<WhippetResultContainer<IWhippetViewPermissionEntry>>.Run(() => DeleteWhippetViewPermissionEntryAsync(permission)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet permission.
        /// </summary>
        /// <param name="permission">Permission to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted permission.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetViewPermissionEntry>> DeleteWhippetViewPermissionEntryAsync(IWhippetViewPermissionEntry permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<DeleteWhippetViewPermissionEntryCommand> handler = new DeleteWhippetViewPermissionEntryCommandHandler(PermissionRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteWhippetViewPermissionEntryCommand(permission.ToWhippetViewPermissionEntry()));

                    if (updateResult.IsSuccess)
                    {
                        await PermissionRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetViewPermissionEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetViewPermissionEntry>(updateResult, permission);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (PermissionRepository != null)
            {
                PermissionRepository.Dispose();
                PermissionRepository = null;
            }

            base.Dispose();
        }

    }
}
