using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Services;
using Athi.Whippet.Jobs;
using Athi.Whippet.Jobs.ServiceManagers;
using Athi.Whippet.Jobs.Extensions;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Commands;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Handlers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager : JobServiceManager<MultichannelOrderManagerMagentoTaxSynchronizationJob>, IJobServiceManager
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected new virtual IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository JobRepository
        {
            get
            {
                return base.JobRepository as IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager"/> class with no arguments.
        /// </summary>
        private MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager(IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerMagentoTaxSynchronizationJobServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository repository)
            : base(serviceLocator, repository)
        { }

        /// <summary>
        /// Retrieves the <see cref="IJob"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJob"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public override async Task<WhippetResultContainer<IJob>> GetJob(Guid id)
        {
            GetMultichannelOrderManagerMagentoTaxSynchronizationJobByIdQueryHandler handler = new GetMultichannelOrderManagerMagentoTaxSynchronizationJobByIdQueryHandler(JobRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationJob>> result = await handler.HandleAsync(new GetMultichannelOrderManagerMagentoTaxSynchronizationJobByIdQuery(id));
            return new WhippetResultContainer<IJob>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IJob"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<IJob>>> GetJobs()
        {
            GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQueryHandler handler = new GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQueryHandler(JobRepository);
            WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationJob>> result = await handler.HandleAsync(new GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQuery());
            return new WhippetResultContainer<IEnumerable<IJob>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="IJob"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<IJob>>> GetJobs(IJobCategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IJob>> filteredResult = null;
                WhippetResultContainer<IEnumerable<IJob>> jobsResult = await GetJobs();

                if (jobsResult.IsSuccess)
                {
                    filteredResult = new WhippetResultContainer<IEnumerable<IJob>>(jobsResult.Result, jobsResult.HasItem ? jobsResult.Item.Where(j => j.Category.Equals(category)) : Enumerable.Empty<IJob>());
                }
                else
                {
                    filteredResult = jobsResult;
                }

                return filteredResult;
            }
        }

        /// <summary>
        /// Creates a new Whippet job.
        /// </summary>
        /// <param name="job">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<IJob> CreateJob(IJob job)
        {
            return Task<WhippetResultContainer<IJob>>.Run(() => CreateJobAsync(job)).Result;
        }

        /// <summary>
        /// Creates a new Whippet job.
        /// </summary>
        /// <param name="job">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IJob>> CreateJobAsync(IJob job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetCommandHandler<CreateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand> handler = new CreateMultichannelOrderManagerMagentoTaxSynchronizationJobCommandHandler(JobRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand(job.ToJob<MultichannelOrderManagerMagentoTaxSynchronizationJob>()));

                    if (createResult.IsSuccess)
                    {
                        await JobRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IJob>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IJob>(createResult, job);
            }
        }

        /// <summary>
        /// Updates an existing Whippet job.
        /// </summary>
        /// <param name="job">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<IJob> UpdateJob(IJob job)
        {
            return Task<WhippetResultContainer<IJob>>.Run(() => UpdateJobAsync(job)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet job.
        /// </summary>
        /// <param name="job">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IJob>> UpdateJobAsync(IJob job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand> handler = new UpdateMultichannelOrderManagerMagentoTaxSynchronizationJobCommandHandler(JobRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateMultichannelOrderManagerMagentoTaxSynchronizationJobCommand(job.ToJob<MultichannelOrderManagerMagentoTaxSynchronizationJob>()));

                    if (updateResult.IsSuccess)
                    {
                        await JobRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IJob>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IJob>(updateResult, job);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet job.
        /// </summary>
        /// <param name="job">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        public override WhippetResultContainer<IJob> DeleteJob(IJob job)
        {
            return Task<WhippetResultContainer<IJob>>.Run(() => DeleteJobAsync(job)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet job.
        /// </summary>
        /// <param name="job">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IJob>> DeleteJobAsync(IJob job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<DeleteMultichannelOrderManagerMagentoTaxSynchronizationJobCommand> handler = new DeleteMultichannelOrderManagerMagentoTaxSynchronizationJobCommandHandler(JobRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteMultichannelOrderManagerMagentoTaxSynchronizationJobCommand(job.ToJob<MultichannelOrderManagerMagentoTaxSynchronizationJob>()));

                    if (updateResult.IsSuccess)
                    {
                        await JobRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IJob>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IJob>(updateResult, job);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}

