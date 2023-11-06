using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.Repositories;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMagentoServer"/> domain objects.
    /// </summary>
    public class MagentoServerServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMagentoServerRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMagentoServerRepository ServerRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoServerServiceManager"/> class with the specified <see cref="IMagentoServerRepository"/> object.
        /// </summary>
        /// <param name="serverRepository"><see cref="IMagentoServerRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoServerServiceManager(IMagentoServerRepository serverRepository)
            : base()
        {
            if (serverRepository == null)
            {
                throw new ArgumentNullException(nameof(serverRepository));
            }
            else
            {
                ServerRepository = serverRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoServerServiceManager"/> class with the specified <see cref="IMagentoServerRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="serverRepository"><see cref="IMagentoServerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoServerServiceManager(IWhippetServiceContext serviceLocator, IMagentoServerRepository serverRepository)
            : base(serviceLocator)
        {
            if (serverRepository == null)
            {
                throw new ArgumentNullException(nameof(serverRepository));
            }
            else
            {
                ServerRepository = serverRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IMagentoServer"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IMagentoServer"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IMagentoServer>> GetServer(Guid id)
        {
            IMagentoServerQueryHandler<GetMagentoServerByIdQuery> handler = new GetMagentoServerByIdQueryHandler(ServerRepository);
            WhippetResultContainer<IEnumerable<MagentoServer>> result = await handler.HandleAsync(new GetMagentoServerByIdQuery(id));
            return new WhippetResultContainer<IMagentoServer>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IMagentoServer"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMagentoServer>>> GetServersForTenant(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IMagentoServerQueryHandler<GetMagentoServersForTenantQuery> handler = new GetMagentoServersForTenantQueryHandler(ServerRepository);
            WhippetResultContainer<IEnumerable<MagentoServer>> result = await handler.HandleAsync(new GetMagentoServersForTenantQuery(tenant));
            return new WhippetResultContainer<IEnumerable<IMagentoServer>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new SMTP server entry.
        /// </summary>
        /// <param name="server"><see cref="IMagentoServer"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoServer> CreateMagentoServer(IMagentoServer server)
        {
            return Task<WhippetResultContainer<IMagentoServer>>.Run(() => CreateMagentoServerAsync(server)).Result;
        }

        /// <summary>
        /// Creates a new SMTP server entry.
        /// </summary>
        /// <param name="server"><see cref="IMagentoServer"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoServer>> CreateMagentoServerAsync(IMagentoServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateMagentoServerCommand> handler = new CreateMagentoServerCommandHandler(ServerRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateMagentoServerCommand(server.ToMagentoServer()));

                    if (result.IsSuccess)
                    {
                        await ServerRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoServer>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoServer>(result, server);
            }
        }

        /// <summary>
        /// Updates an existing store.
        /// </summary>
        /// <param name="server"><see cref="IMagentoServer"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoServer> UpdateMagentoServer(IMagentoServer server)
        {
            return Task<WhippetResultContainer<IMagentoServer>>.Run(() => UpdateMagentoServerAsync(server)).Result;
        }

        /// <summary>
        /// Updates an existing store.
        /// </summary>
        /// <param name="server"><see cref="IMagentoServer"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoServer>> UpdateMagentoServerAsync(IMagentoServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateMagentoServerCommand> handler = new UpdateMagentoServerCommandHandler(ServerRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateMagentoServerCommand(server.ToMagentoServer()));

                    if (result.IsSuccess)
                    {
                        await ServerRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoServer>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoServer>(result, server);
            }
        }

        /// <summary>
        /// Deletes an existing store.
        /// </summary>
        /// <param name="server"><see cref="IMagentoServer"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoServer> DeleteMagentoServer(IMagentoServer server)
        {
            return Task<WhippetResultContainer<IMagentoServer>>.Run(() => DeleteMagentoServerAsync(server)).Result;
        }

        /// <summary>
        /// Deletes an existing store.
        /// </summary>
        /// <param name="server"><see cref="IMagentoServer"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoServer>> DeleteMagentoServerAsync(IMagentoServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteMagentoServerCommand> handler = new DeleteMagentoServerCommandHandler(ServerRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteMagentoServerCommand(server.ToMagentoServer()));

                    if (result.IsSuccess)
                    {
                        await ServerRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoServer>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoServer>(result, server);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (ServerRepository != null)
            {
                ServerRepository.Dispose();
                ServerRepository = null;
            }

            base.Dispose();
        }
    }
}
