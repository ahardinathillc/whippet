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
    /// Service manager for <see cref="IMagentoRestEndpoint"/> domain objects.
    /// </summary>
    public class MagentoRestEndpointServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMagentoRestEndpointRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMagentoRestEndpointRepository RestEndpointRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpointServiceManager"/> class with the specified <see cref="IMagentoRestEndpointRepository"/> object.
        /// </summary>
        /// <param name="endpointRepository"><see cref="IMagentoRestEndpointRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoRestEndpointServiceManager(IMagentoRestEndpointRepository endpointRepository)
            : base()
        {
            if (endpointRepository == null)
            {
                throw new ArgumentNullException(nameof(endpointRepository));
            }
            else
            {
                RestEndpointRepository = endpointRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpointServiceManager"/> class with the specified <see cref="IMagentoRestEndpointRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="endpointRepository"><see cref="IMagentoRestEndpointRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoRestEndpointServiceManager(IWhippetServiceContext serviceLocator, IMagentoRestEndpointRepository endpointRepository)
            : base(serviceLocator)
        {
            if (endpointRepository == null)
            {
                throw new ArgumentNullException(nameof(endpointRepository));
            }
            else
            {
                RestEndpointRepository = endpointRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IMagentoRestEndpoint"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IMagentoRestEndpoint"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IMagentoRestEndpoint>> GetRestEndpoint(Guid id)
        {
            IMagentoRestEndpointQueryHandler<GetMagentoRestEndpointByIdQuery> handler = new GetMagentoRestEndpointByIdQueryHandler(RestEndpointRepository);
            WhippetResultContainer<IEnumerable<MagentoRestEndpoint>> result = await handler.HandleAsync(new GetMagentoRestEndpointByIdQuery(id));
            return new WhippetResultContainer<IMagentoRestEndpoint>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IMagentoRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMagentoRestEndpoint>>> GetRestEndpointsForTenant(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IMagentoRestEndpointQueryHandler<GetMagentoRestEndpointsForTenantQuery> handler = new GetMagentoRestEndpointsForTenantQueryHandler(RestEndpointRepository);
            WhippetResultContainer<IEnumerable<MagentoRestEndpoint>> result = await handler.HandleAsync(new GetMagentoRestEndpointsForTenantQuery(tenant));
            return new WhippetResultContainer<IEnumerable<IMagentoRestEndpoint>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new SMTP endpoint entry.
        /// </summary>
        /// <param name="endpoint"><see cref="IMagentoRestEndpoint"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoRestEndpoint> CreateMagentoRestEndpoint(IMagentoRestEndpoint endpoint)
        {
            return Task<WhippetResultContainer<IMagentoRestEndpoint>>.Run(() => CreateMagentoRestEndpointAsync(endpoint)).Result;
        }

        /// <summary>
        /// Creates a new SMTP endpoint entry.
        /// </summary>
        /// <param name="endpoint"><see cref="IMagentoRestEndpoint"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoRestEndpoint>> CreateMagentoRestEndpointAsync(IMagentoRestEndpoint endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateMagentoRestEndpointCommand> handler = new CreateMagentoRestEndpointCommandHandler(RestEndpointRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateMagentoRestEndpointCommand(endpoint.ToMagentoRestEndpoint()));

                    if (result.IsSuccess)
                    {
                        await RestEndpointRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoRestEndpoint>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoRestEndpoint>(result, endpoint);
            }
        }

        /// <summary>
        /// Updates an existing store.
        /// </summary>
        /// <param name="endpoint"><see cref="IMagentoRestEndpoint"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoRestEndpoint> UpdateMagentoRestEndpoint(IMagentoRestEndpoint endpoint)
        {
            return Task<WhippetResultContainer<IMagentoRestEndpoint>>.Run(() => UpdateMagentoRestEndpointAsync(endpoint)).Result;
        }

        /// <summary>
        /// Updates an existing store.
        /// </summary>
        /// <param name="endpoint"><see cref="IMagentoRestEndpoint"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoRestEndpoint>> UpdateMagentoRestEndpointAsync(IMagentoRestEndpoint endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateMagentoRestEndpointCommand> handler = new UpdateMagentoRestEndpointCommandHandler(RestEndpointRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateMagentoRestEndpointCommand(endpoint.ToMagentoRestEndpoint()));

                    if (result.IsSuccess)
                    {
                        await RestEndpointRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoRestEndpoint>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoRestEndpoint>(result, endpoint);
            }
        }

        /// <summary>
        /// Deletes an existing store.
        /// </summary>
        /// <param name="endpoint"><see cref="IMagentoRestEndpoint"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoRestEndpoint> DeleteMagentoRestEndpoint(IMagentoRestEndpoint endpoint)
        {
            return Task<WhippetResultContainer<IMagentoRestEndpoint>>.Run(() => DeleteMagentoRestEndpointAsync(endpoint)).Result;
        }

        /// <summary>
        /// Deletes an existing store.
        /// </summary>
        /// <param name="endpoint"><see cref="IMagentoRestEndpoint"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoRestEndpoint>> DeleteMagentoRestEndpointAsync(IMagentoRestEndpoint endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteMagentoRestEndpointCommand> handler = new DeleteMagentoRestEndpointCommandHandler(RestEndpointRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteMagentoRestEndpointCommand(endpoint.ToMagentoRestEndpoint()));

                    if (result.IsSuccess)
                    {
                        await RestEndpointRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoRestEndpoint>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoRestEndpoint>(result, endpoint);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (RestEndpointRepository != null)
            {
                RestEndpointRepository.Dispose();
                RestEndpointRepository = null;
            }

            base.Dispose();
        }
    }
}
