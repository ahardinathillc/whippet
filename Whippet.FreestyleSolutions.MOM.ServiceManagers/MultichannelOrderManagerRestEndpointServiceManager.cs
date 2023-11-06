using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerRestEndpoint"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerRestEndpointServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerRestEndpointRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerRestEndpointRepository RestEndpointRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerRestEndpointServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerRestEndpointRepository"/> object.
        /// </summary>
        /// <param name="endpointRepository"><see cref="IMultichannelOrderManagerRestEndpointRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerRestEndpointServiceManager(IMultichannelOrderManagerRestEndpointRepository endpointRepository)
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
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerRestEndpointServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerRestEndpointRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="endpointRepository"><see cref="IMultichannelOrderManagerRestEndpointRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerRestEndpointServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerRestEndpointRepository endpointRepository)
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
        /// Retrieves the <see cref="IMultichannelOrderManagerRestEndpoint"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IMultichannelOrderManagerRestEndpoint"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>> GetRestEndpoint(Guid id)
        {
            IMultichannelOrderManagerRestEndpointQueryHandler<GetMultichannelOrderManagerRestEndpointByIdQuery> handler = new GetMultichannelOrderManagerRestEndpointByIdQueryHandler(RestEndpointRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerRestEndpoint>> result = await handler.HandleAsync(new GetMultichannelOrderManagerRestEndpointByIdQuery(id));
            return new WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IMultichannelOrderManagerRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerRestEndpoint>>> GetRestEndpointsForTenant(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IMultichannelOrderManagerRestEndpointQueryHandler<GetMultichannelOrderManagerRestEndpointsForTenantQuery> handler = new GetMultichannelOrderManagerRestEndpointsForTenantQueryHandler(RestEndpointRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerRestEndpoint>> result = await handler.HandleAsync(new GetMultichannelOrderManagerRestEndpointsForTenantQuery(tenant));
            return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerRestEndpoint>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new SMTP endpoint entry.
        /// </summary>
        /// <param name="endpoint"><see cref="IMultichannelOrderManagerRestEndpoint"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMultichannelOrderManagerRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMultichannelOrderManagerRestEndpoint> CreateMultichannelOrderManagerRestEndpoint(IMultichannelOrderManagerRestEndpoint endpoint)
        {
            return Task<WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>>.Run(() => CreateMultichannelOrderManagerRestEndpointAsync(endpoint)).Result;
        }

        /// <summary>
        /// Creates a new SMTP endpoint entry.
        /// </summary>
        /// <param name="endpoint"><see cref="IMultichannelOrderManagerRestEndpoint"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMultichannelOrderManagerRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>> CreateMultichannelOrderManagerRestEndpointAsync(IMultichannelOrderManagerRestEndpoint endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateMultichannelOrderManagerRestEndpointCommand> handler = new CreateMultichannelOrderManagerRestEndpointCommandHandler(RestEndpointRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateMultichannelOrderManagerRestEndpointCommand(endpoint.ToMultichannelOrderManagerRestEndpoint()));

                    if (result.IsSuccess)
                    {
                        await RestEndpointRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>(result, endpoint);
            }
        }

        /// <summary>
        /// Updates an existing store.
        /// </summary>
        /// <param name="endpoint"><see cref="IMultichannelOrderManagerRestEndpoint"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMultichannelOrderManagerRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMultichannelOrderManagerRestEndpoint> UpdateMultichannelOrderManagerRestEndpoint(IMultichannelOrderManagerRestEndpoint endpoint)
        {
            return Task<WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>>.Run(() => UpdateMultichannelOrderManagerRestEndpointAsync(endpoint)).Result;
        }

        /// <summary>
        /// Updates an existing store.
        /// </summary>
        /// <param name="endpoint"><see cref="IMultichannelOrderManagerRestEndpoint"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMultichannelOrderManagerRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>> UpdateMultichannelOrderManagerRestEndpointAsync(IMultichannelOrderManagerRestEndpoint endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateMultichannelOrderManagerRestEndpointCommand> handler = new UpdateMultichannelOrderManagerRestEndpointCommandHandler(RestEndpointRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateMultichannelOrderManagerRestEndpointCommand(endpoint.ToMultichannelOrderManagerRestEndpoint()));

                    if (result.IsSuccess)
                    {
                        await RestEndpointRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>(result, endpoint);
            }
        }

        /// <summary>
        /// Deletes an existing store.
        /// </summary>
        /// <param name="endpoint"><see cref="IMultichannelOrderManagerRestEndpoint"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMultichannelOrderManagerRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMultichannelOrderManagerRestEndpoint> DeleteMultichannelOrderManagerRestEndpoint(IMultichannelOrderManagerRestEndpoint endpoint)
        {
            return Task<WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>>.Run(() => DeleteMultichannelOrderManagerRestEndpointAsync(endpoint)).Result;
        }

        /// <summary>
        /// Deletes an existing store.
        /// </summary>
        /// <param name="endpoint"><see cref="IMultichannelOrderManagerRestEndpoint"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMultichannelOrderManagerRestEndpoint"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>> DeleteMultichannelOrderManagerRestEndpointAsync(IMultichannelOrderManagerRestEndpoint endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteMultichannelOrderManagerRestEndpointCommand> handler = new DeleteMultichannelOrderManagerRestEndpointCommandHandler(RestEndpointRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteMultichannelOrderManagerRestEndpointCommand(endpoint.ToMultichannelOrderManagerRestEndpoint()));

                    if (result.IsSuccess)
                    {
                        await RestEndpointRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMultichannelOrderManagerRestEndpoint>(result, endpoint);
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
