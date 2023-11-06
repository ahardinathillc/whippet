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
using Athi.Whippet.Security.Tenants.ServiceManagers.Queries;
using Athi.Whippet.Security.Tenants.ServiceManagers.Commands;
using Athi.Whippet.Security.Tenants.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Security.Tenants.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Security.Cryptography;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Security.Tenants.Repositories;

namespace Athi.Whippet.Security.Tenants.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="WhippetTenantServiceManager"/> domain objects.
    /// </summary>
    public class WhippetTenantServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetTenantRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetTenantRepository TenantRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenantServiceManager"/> class with the specified <see cref="IWhippetTenantRepository"/> object.
        /// </summary>
        /// <param name="ipAddressBlacklistRepository"><see cref="IWhippetTenantRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetTenantServiceManager(IWhippetTenantRepository tenantRepository)
            : base()
        {
            if (tenantRepository == null)
            {
                throw new ArgumentNullException(nameof(tenantRepository));
            }
            else
            {
                TenantRepository = tenantRepository;
            }
        }

        /// <summary>
        /// Gets the <see cref="IWhippetTenant"/> that matches the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IWhippetTenant"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetTenant>> GetTenant(Guid id)
        {
            IWhippetTenantQueryHandler<GetWhippetTenantByIdQuery> handler = new GetWhippetTenantByIdQueryHandler(TenantRepository);
            WhippetResultContainer<IEnumerable<WhippetTenant>> result = await handler.HandleAsync(new GetWhippetTenantByIdQuery(id));

            return new WhippetResultContainer<IWhippetTenant>(result.Result, result.Item?.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IWhippetTenant"/> objects registered in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetTenant>>> GetTenants()
        {
            IWhippetTenantQueryHandler<GetWhippetTenantsQuery> handler = new GetWhippetTenantsQueryHandler(TenantRepository);
            WhippetResultContainer<IEnumerable<WhippetTenant>> result = await handler.HandleAsync(new GetWhippetTenantsQuery());

            return new WhippetResultContainer<IEnumerable<IWhippetTenant>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new <see cref="WhippetTenant"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetTenant> CreateTenant(IWhippetTenant tenant)
        {
            return Task<WhippetResultContainer<IWhippetTenant>>.Run(() => CreateTenantAsync(tenant)).Result;
        }

        /// <summary>
        /// Updates an existing <see cref="WhippetTenant"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetTenant> UpdateTenant(IWhippetTenant tenant)
        {
            return Task<WhippetResultContainer<IWhippetTenant>>.Run(() => UpdateTenantAsync(tenant)).Result;
        }

        /// <summary>
        /// Deletes an existing <see cref="WhippetTenant"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetTenant> DeleteTenant(IWhippetTenant tenant)
        {
            return Task<WhippetResultContainer<IWhippetTenant>>.Run(() => DeleteTenantAsync(tenant)).Result;
        }

        /// <summary>
        /// Creates a new <see cref="WhippetTenant"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetTenant>> CreateTenantAsync(IWhippetTenant tenant)
        {
            if(tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetTenantCommandHandler<CreateWhippetTenantCommand> handler = new CreateWhippetTenantCommandHandler(TenantRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateWhippetTenantCommand(tenant.ToWhippetTenant()));

                    if (createResult.IsSuccess)
                    {
                        await TenantRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IWhippetUser>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetTenant>(createResult, tenant);
            }
        }

        /// <summary>
        /// Updates an existing <see cref="WhippetTenant"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetTenant>> UpdateTenantAsync(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetTenantCommandHandler<UpdateWhippetTenantCommand> handler = new UpdateWhippetTenantCommandHandler(TenantRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateWhippetTenantCommand(tenant.ToWhippetTenant()));

                    if (updateResult.IsSuccess)
                    {
                        await TenantRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetUser>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetTenant>(updateResult, tenant);
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="WhippetTenant"/> object in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted tenant.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetTenant>> DeleteTenantAsync(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResult deleteResult = null;
                IWhippetTenantCommandHandler<DeleteWhippetTenantCommand> handler = new DeleteWhippetTenantCommandHandler(TenantRepository);

                try
                {
                    deleteResult = await handler.HandleAsync(new DeleteWhippetTenantCommand(tenant.ToWhippetTenant()));

                    if (deleteResult.IsSuccess)
                    {
                        await TenantRepository.CommitAsync();
                        deleteResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    deleteResult = new WhippetResultContainer<IWhippetUser>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetTenant>(deleteResult, tenant);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="WhippetTenant.Root"/> in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the root tenant.</returns>
        public WhippetResultContainer<IWhippetTenant> CreateRootTenant()
        {
            return Task.Run(() => CreateRootTenantAsync()).Result;
        }

        /// <summary>
        /// Creates an instance of <see cref="WhippetTenant.Root"/> in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the root tenant.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetTenant>> CreateRootTenantAsync()
        {
            WhippetResultContainer<WhippetTenant> rootResult = await TenantRepository.CreateRootTenantAsync();
            return WhippetResultContainer<WhippetTenant>.CastTo<IWhippetTenant, WhippetTenant>(rootResult);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (TenantRepository != null)
            {
                TenantRepository.Dispose();
                TenantRepository = null;
            }

            base.Dispose();
        }
    }
}
