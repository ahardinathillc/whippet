using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerServer"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerServerServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerServerRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerServerRepository ServerRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServerServiceManager"/> class with the specified <see cref=""/>
        /// </summary>
        /// <param name="accountRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerServerServiceManager(IMultichannelOrderManagerServerRepository accountRepository)
            : base()
        {
            if (accountRepository == null)
            {
                throw new ArgumentNullException(nameof(accountRepository));
            }
            else
            {
                ServerRepository = accountRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServerServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerServerRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="accountRepository"><see cref="IMultichannelOrderManagerServerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerServerServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerServerRepository accountRepository)
            : base(serviceLocator)
        {
            if (accountRepository == null)
            {
                throw new ArgumentNullException(nameof(accountRepository));
            }
            else
            {
                ServerRepository = accountRepository;
            }
        }

        /// <summary>
        /// Gets all <see cref="IMultichannelOrderManagerServer"/> objects based on the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve all servers for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerServer>>> GetMultichannelOrderManagerServers(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                GetMultichannelOrderManagerServersForTenantQueryHandler handler = new GetMultichannelOrderManagerServersForTenantQueryHandler(ServerRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerServer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerServersForTenantQuery(tenant));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerServer>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerServer"/> object with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="IMultichannelOrderManagerServer"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerServer>> GetMultichannelOrderManagerServer(Guid id)
        {
            GetMultichannelOrderManagerServerByIdQueryHandler handler = new GetMultichannelOrderManagerServerByIdQueryHandler(ServerRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerServer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerServerByIdQuery(id));
            return new WhippetResultContainer<IMultichannelOrderManagerServer>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerServer"/> object with the specified name.
        /// </summary>
        /// <param name="serverName">Name of the <see cref="IMultichannelOrderManagerServer"/> to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the <see cref="IMultichannelOrderManagerServer"/> is associated with.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerServer>> GetMultichannelOrderManagerServer(string serverName, IWhippetTenant tenant)
        {
            GetMultichannelOrderManagerServerByNameQueryHandler handler = new GetMultichannelOrderManagerServerByNameQueryHandler(ServerRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerServer>> result = await handler.HandleAsync(new GetMultichannelOrderManagerServerByNameQuery(serverName, tenant));
            return new WhippetResultContainer<IMultichannelOrderManagerServer>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Creates a new Multichannel Order Manager server entry.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMultichannelOrderManagerServer"/> object.</returns>
        public virtual WhippetResultContainer<IMultichannelOrderManagerServer> CreateMultichannelOrderManagerServer(IMultichannelOrderManagerServer server)
        {
            return Task<WhippetResultContainer<IMultichannelOrderManagerServer>>.Run(() => CreateMultichannelOrderManagerServerAsync(server)).Result;
        }

        /// <summary>
        /// Creates a new Multichannel Order Manager server entry.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMultichannelOrderManagerServer"/> object.</returns>
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerServer>> CreateMultichannelOrderManagerServerAsync(IMultichannelOrderManagerServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateMultichannelOrderManagerServerCommand> handler = new CreateMultichannelOrderManagerServerCommandHandler(ServerRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateMultichannelOrderManagerServerCommand(server.ToMultichannelOrderManagerServer()));

                    if (result.IsSuccess)
                    {
                        await ServerRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMultichannelOrderManagerServer>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMultichannelOrderManagerServer>(result, server);
            }
        }

        /// <summary>
        /// Updates an existing Multichannel Order Manager server entry.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMultichannelOrderManagerServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMultichannelOrderManagerServer> UpdateMultichannelOrderManagerServer(IMultichannelOrderManagerServer server)
        {
            return Task<WhippetResultContainer<IMultichannelOrderManagerServer>>.Run(() => UpdateMultichannelOrderManagerServerAsync(server)).Result;
        }

        /// <summary>
        /// Updates an existing Multichannel Order Manager server entry.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMultichannelOrderManagerServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerServer>> UpdateMultichannelOrderManagerServerAsync(IMultichannelOrderManagerServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateMultichannelOrderManagerServerCommand> handler = new UpdateMultichannelOrderManagerServerCommandHandler(ServerRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateMultichannelOrderManagerServerCommand(server.ToMultichannelOrderManagerServer()));

                    if (result.IsSuccess)
                    {
                        await ServerRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMultichannelOrderManagerServer>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMultichannelOrderManagerServer>(result, server);
            }
        }

        /// <summary>
        /// Deletes an existing Multichannel Order Manager server entry.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMultichannelOrderManagerServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMultichannelOrderManagerServer> DeleteMultichannelOrderManagerServer(IMultichannelOrderManagerServer server)
        {
            return Task.Run(() => DeleteMultichannelOrderManagerServerAsync(server)).Result;
        }

        /// <summary>
        /// Deletes an existing Multichannel Order Manager server entry.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMultichannelOrderManagerServer"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerServer>> DeleteMultichannelOrderManagerServerAsync(IMultichannelOrderManagerServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteMultichannelOrderManagerServerCommand> handler = new DeleteMultichannelOrderManagerServerCommandHandler(ServerRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteMultichannelOrderManagerServerCommand(server.ToMultichannelOrderManagerServer()));

                    if (result.IsSuccess)
                    {
                        await ServerRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMultichannelOrderManagerServer>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMultichannelOrderManagerServer>(result, server);
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