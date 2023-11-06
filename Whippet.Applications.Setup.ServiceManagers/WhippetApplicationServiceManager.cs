using System;
using System.Collections.Generic;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Services;
using Athi.Whippet.Applications.Setup.Repositories;
using Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Applications.Setup.ServiceManagers.Queries;
using Athi.Whippet.Applications.Setup.ServiceManagers.Commands;
using Athi.Whippet.Applications.Setup.Extensions;

namespace Athi.Whippet.Applications.Setup.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IWhippetApplication"/> domain objects.
    /// </summary>
    public class WhippetApplicationServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetApplicationRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetApplicationRepository ApplicationRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplicationServiceManager"/> class with the specified <see cref="IWhippetApplicationRepository"/>.
        /// </summary>
        /// <param name="applicationRepository"><see cref="IWhippetApplicationRepository"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetApplicationServiceManager(IWhippetApplicationRepository applicationRepository)
            : base()
        {
            if (applicationRepository == null)
            {
                throw new ArgumentNullException(nameof(applicationRepository));
            }
            else
            {
                ApplicationRepository = applicationRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplicationServiceManager"/> class with the specified <see cref="IWhippetApplicationRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="applicationRepository"><see cref="IWhippetApplicationRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetApplicationServiceManager(IWhippetServiceContext serviceLocator, IWhippetApplicationRepository applicationRepository)
            : base(serviceLocator)
        {
            if (applicationRepository == null)
            {
                throw new ArgumentNullException(nameof(applicationRepository));
            }
            else
            {
                ApplicationRepository = applicationRepository;
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetApplication"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetApplication>>> GetWhippetApplications()
        {
            GetAllWhippetApplicationsQueryHandler handler = new GetAllWhippetApplicationsQueryHandler(ApplicationRepository);
            WhippetResultContainer<IEnumerable<WhippetApplication>> result = await handler.HandleAsync(new GetAllWhippetApplicationsQuery());
            return new WhippetResultContainer<IEnumerable<IWhippetApplication>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets all <see cref="IWhippetApplication"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetApplication>>> GetWhippetApplications(IWhippetTenant tenant)
        {
            GetWhippetApplicationsByTenantQueryHandler handler = new GetWhippetApplicationsByTenantQueryHandler(ApplicationRepository);
            WhippetResultContainer<IEnumerable<WhippetApplication>> result = await handler.HandleAsync(new GetWhippetApplicationsByTenantQuery(tenant));
            return new WhippetResultContainer<IEnumerable<IWhippetApplication>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets the <see cref="IWhippetApplication"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IWhippetApplication"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetApplication>> GetWhippetApplication(Guid id)
        {
            GetWhippetApplicationByIdQueryHandler handler = new GetWhippetApplicationByIdQueryHandler(ApplicationRepository);
            WhippetResultContainer<IEnumerable<WhippetApplication>> result = await handler.HandleAsync(new GetWhippetApplicationByIdQuery(id));
            return new WhippetResultContainer<IWhippetApplication>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets the <see cref="IWhippetApplication"/> object with the specified <see cref="IWhippetApplication.ApplicationID"/> for a given <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="applicationId"><see cref="IWhippetApplication.ApplicationID"/> value.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetApplication>> GetWhippetApplicationByApplicationID(Guid applicationId, IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                GetWhippetApplicationByApplicationIdQueryHandler handler = new GetWhippetApplicationByApplicationIdQueryHandler(ApplicationRepository);
                WhippetResultContainer<IEnumerable<WhippetApplication>> result = await handler.HandleAsync(new GetWhippetApplicationByApplicationIdQuery(applicationId, tenant));
                return new WhippetResultContainer<IWhippetApplication>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Creates a new Whippet application entry.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetApplication"/> object.</returns>
        public virtual WhippetResultContainer<IWhippetApplication> CreateWhippetApplication(IWhippetApplication application)
        {
            return Task<WhippetResultContainer<IWhippetApplication>>.Run(() => CreateWhippetApplicationAsync(application)).Result;
        }

        /// <summary>
        /// Creates a new Whippet application entry.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetApplication"/> object.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetApplication>> CreateWhippetApplicationAsync(IWhippetApplication application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateWhippetApplicationCommand> handler = new CreateWhippetApplicationCommandHandler(ApplicationRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateWhippetApplicationCommand(application.ToWhippetApplication()));

                    if (result.IsSuccess)
                    {
                        await ApplicationRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetApplication>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetApplication>(result, application);
            }
        }

        /// <summary>
        /// Updates an existing Whippet application entry.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetApplication"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetApplication> UpdateWhippetApplication(IWhippetApplication application)
        {
            return Task<WhippetResultContainer<IWhippetApplication>>.Run(() => UpdateWhippetApplicationAsync(application)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet application entry.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetApplication"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetApplication>> UpdateWhippetApplicationAsync(IWhippetApplication application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateWhippetApplicationCommand> handler = new UpdateWhippetApplicationCommandHandler(ApplicationRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateWhippetApplicationCommand(application.ToWhippetApplication()));

                    if (result.IsSuccess)
                    {
                        await ApplicationRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetApplication>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetApplication>(result, application);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet application entry.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetApplication"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetApplication> DeleteWhippetApplication(IWhippetApplication application)
        {
            return Task.Run(() => DeleteWhippetApplicationAsync(application)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet application entry.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetApplication"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetApplication>> DeleteWhippetApplicationAsync(IWhippetApplication application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteWhippetApplicationCommand> handler = new DeleteWhippetApplicationCommandHandler(ApplicationRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteWhippetApplicationCommand(application.ToWhippetApplication()));

                    if (result.IsSuccess)
                    {
                        await ApplicationRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetApplication>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetApplication>(result, application);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (ApplicationRepository != null)
            {
                ApplicationRepository.Dispose();
                ApplicationRepository = null;
            }

            base.Dispose();
        }
    }
}

