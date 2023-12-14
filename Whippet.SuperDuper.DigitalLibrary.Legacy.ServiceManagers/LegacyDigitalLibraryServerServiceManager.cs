using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Queries;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Queries;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Commands;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Commands;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Repositories;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Extensions;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="LegacyDigitalLibraryServer"/> domain objects.
    /// </summary>
    public class LegacyDigitalLibraryServerServiceManager : WhippetEntityServiceManager<LegacyDigitalLibraryServer, ILegacyDigitalLibraryServerRepository>, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityServiceManager{TEntity, TRepository}"/> class with the specified <see cref="ILegacyDigitalLibraryServerRepository"/> object and the default currently-configured <see cref="IWhippetServiceContext"/>. If no context is configured, <see cref="ServiceManager.ServiceLocator"/> will not be available.
        /// </summary>
        /// <param name="repository"><see cref="ILegacyDigitalLibraryServerRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public LegacyDigitalLibraryServerServiceManager(ILegacyDigitalLibraryServerRepository repository)
            : base(repository)
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibraryServerServiceManager"/> class with the specified <see cref="ILegacyDigitalLibraryServerRepository"/> object and <see cref="IWhippetServiceContext"/> object.
        /// </summary>
        /// <param name="repository"><see cref="ILegacyDigitalLibraryServerRepository"/> object to initialize with.</param>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacyDigitalLibraryServerServiceManager(ILegacyDigitalLibraryServerRepository repository, IWhippetServiceContext serviceLocator)
            : base(repository, serviceLocator)
        { }

        /// <summary>
        /// Gets the specified <see cref="ILegacyDigitalLibraryServer"/> object with the given ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ILegacyDigitalLibraryServer"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        public virtual async Task<WhippetResultContainer<ILegacyDigitalLibraryServer>> GetServer(Guid id)
        {
             GetLegacyDigitalLibraryServerByIdQueryHandler handler = new GetLegacyDigitalLibraryServerByIdQueryHandler(Repository);
             WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>> result = await handler.HandleAsync(new GetLegacyDigitalLibraryServerByIdQuery(id));
             return new WhippetResultContainer<ILegacyDigitalLibraryServer>(result.Result, result.EnumerableSingleResult<ILegacyDigitalLibraryServer>());
        }

        /// <summary>
        /// Gets all <see cref="ILegacyDigitalLibraryServer"/> objects in the system.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object ot filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ILegacyDigitalLibraryServer>>> GetServers(IWhippetTenant tenant = null)
        {
            GetLegacyDigitalLibraryServersForTenantQueryHandler tenantHandler = null;
            GetAllLegacyDigitalLibraryServersQueryHandler handler = null;
            
            WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>> result = null;

            if (tenant == null)
            {
                tenantHandler = new GetLegacyDigitalLibraryServersForTenantQueryHandler(Repository);
                result = await tenantHandler.HandleAsync(new GetLegacyDigitalLibraryServersForTenantQuery(tenant));
            }
            else
            {
                handler = new GetAllLegacyDigitalLibraryServersQueryHandler(Repository);
                result = await handler.HandleAsync(new GetAllLegacyDigitalLibraryServersQuery());
            }

            return new WhippetResultContainer<IEnumerable<ILegacyDigitalLibraryServer>>(result.Result, result.Item.Select(i => i));
        }
        
        /// <summary>
        /// Creates a new legacy Digital Library server.
        /// </summary>
        /// <param name="server">Legacy server entry to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created server.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ILegacyDigitalLibraryServer>> CreateLegacyDigitalLibraryServer(ILegacyDigitalLibraryServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetCommandHandler<CreateLegacyDigitalLibraryServerCommand> handler = new CreateLegacyDigitalLibraryServerCommandHandler(Repository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateLegacyDigitalLibraryServerCommand(server.ToLegacyDigitalLibraryServer()));

                    if (createResult.IsSuccess)
                    {
                        await Repository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<ILegacyDigitalLibraryServer>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ILegacyDigitalLibraryServer>(createResult, server);
            }
        }

        /// <summary>
        /// Updates an existing legacy Digital Library server.
        /// </summary>
        /// <param name="server">Legacy server to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated server.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ILegacyDigitalLibraryServer>> UpdateLegacyDigitalLibraryServer(ILegacyDigitalLibraryServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateLegacyDigitalLibraryServerCommand> handler = new UpdateLegacyDigitalLibraryServerCommandHandler(Repository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateLegacyDigitalLibraryServerCommand(server.ToLegacyDigitalLibraryServer()));

                    if (updateResult.IsSuccess)
                    {
                        await Repository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<ILegacyDigitalLibraryServer>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ILegacyDigitalLibraryServer>(updateResult, server);
            }
        }

        /// <summary>
        /// Deletes an existing legacy Digital Library server.
        /// </summary>
        /// <param name="server">Legacy server to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted server.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ILegacyDigitalLibraryServer>> DeleteLegacyDigitalLibraryServer(ILegacyDigitalLibraryServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<DeleteLegacyDigitalLibraryServerCommand> handler = new DeleteLegacyDigitalLibraryServerCommandHandler(Repository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteLegacyDigitalLibraryServerCommand(server.ToLegacyDigitalLibraryServer()));

                    if (updateResult.IsSuccess)
                    {
                        await Repository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<ILegacyDigitalLibraryServer>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ILegacyDigitalLibraryServer>(updateResult, server);
            }
        }        
    }
}
