using System;
using Athi.Whippet.Repositories;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Jobs.Repositories;
using Athi.Whippet.Jobs.Extensions;
using Dynamitey;

namespace Athi.Whippet.Jobs.ServiceManagers
{
    /// <summary>
    /// Base class for all service managers for <see cref="IJob"/> domain objects. This class must be inherited.
    /// </summary>
    public abstract class JobServiceManager<TJob> : ServiceManager, IDisposable, IJobServiceManager, IJobInternalRepositoryAccessor, IInternalRepositoryAccessor
        where TJob: JobBase, IJob, new()
    {
        /// <summary>
        /// Gets the <see cref="IJobRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IJobRepository<TJob> JobRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobServiceManager{TJob}"/> class with no arguments.
        /// </summary>
        protected JobServiceManager()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobServiceManager{TJob}"/> class with the specified <see cref="IJobRepository{TJob}"/> object.
        /// </summary>
        /// <param name="jobRepository"><see cref="IJobRepository{TJob}"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected JobServiceManager(IJobRepository<TJob> jobRepository)
            : base()
        {
            if (jobRepository == null)
            {
                throw new ArgumentNullException(nameof(jobRepository));
            }
            else
            {
                JobRepository = jobRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobServiceManager{TJob}"/> class with the specified <see cref="IJobRepository{TJob}"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="jobRepository"><see cref="IJobRepository{TJob}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected JobServiceManager(IWhippetServiceContext serviceLocator, IJobRepository<TJob> jobRepository)
            : base(serviceLocator)
        {
            if (jobRepository == null)
            {
                throw new ArgumentNullException(nameof(jobRepository));
            }
            else
            {
                JobRepository = jobRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IJob"/> object with the specified ID. This method must be overridden.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJob"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public abstract Task<WhippetResultContainer<IJob>> GetJob(Guid id);

        /// <summary>
        /// Retrieves all <see cref="IJob"/> objects in the system. This method must be overridden.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public abstract Task<WhippetResultContainer<IEnumerable<IJob>>> GetJobs();

        /// <summary>
        /// Retrieves all <see cref="IJob"/> objects for the specified <see cref="IJobCategory"/>. This method must be overridden.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public abstract Task<WhippetResultContainer<IEnumerable<IJob>>> GetJobs(IJobCategory category);

        /// <summary>
        /// Creates a new Whippet job. This method must be overridden.
        /// </summary>
        /// <param name="job">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResultContainer<IJob> CreateJob(IJob job);

        /// <summary>
        /// Creates a new Whippet job. This method must be overridden.
        /// </summary>
        /// <param name="job">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IJob>> CreateJobAsync(IJob job);

        /// <summary>
        /// Updates an existing Whippet job. This method must be overridden.
        /// </summary>
        /// <param name="job">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResultContainer<IJob> UpdateJob(IJob job);

        /// <summary>
        /// Updates an existing Whippet job. This method must be overridden.
        /// </summary>
        /// <param name="job">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IJob>> UpdateJobAsync(IJob job);

        /// <summary>
        /// Deletes an existing Whippet job. This method must be overridden.
        /// </summary>
        /// <param name="job">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResultContainer<IJob> DeleteJob(IJob job);

        /// <summary>
        /// Deletes an existing Whippet job. This method must be overridden.
        /// </summary>
        /// <param name="job">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IJob>> DeleteJobAsync(IJob job);

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (JobRepository != null)
            {
                JobRepository.Dispose();
                JobRepository = null;
            }

            base.Dispose();
        }

        /// <summary>
        /// Retrieves the internal repository that the current <see cref="IJobRepository"/> is wrapping.
        /// </summary>
        /// <returns><see langword="dynamic"/> object that represents the repository being wrapped.</returns>
        dynamic IInternalRepositoryAccessor.GetInternalRepository()
        {
            return JobRepository;
        }
    }

    /// <summary>
    /// Serves as a wrapper class around <see cref="JobServiceManager{TJob}"/> objects to provide an abstraction through reflection. This class cannot be inherited.
    /// </summary>
    public sealed class JobServiceManager : JobServiceManager<Job>, IJobServiceManager, IJobInternalRepositoryAccessor, IInternalRepositoryAccessor
    {
        /// <summary>
        /// Gets the <see cref="IJobRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        private new dynamic JobRepository
        {
            get
            {
                return ((IJobInternalRepositoryAccessor)(InternalServiceManager)).GetInternalRepository();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private dynamic InternalServiceManager
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobServiceManager"/> class with no arguments.
        /// </summary>
        private JobServiceManager()
            : base()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public JobServiceManager(IJobRepository repository, Type serviceManagerType)
            : this()
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else if (serviceManagerType == null)
            {
                throw new ArgumentNullException(nameof(serviceManagerType));
            }
            else
            {
                InternalServiceManager = Dynamic.InvokeConstructor(serviceManagerType, repository.GetInternalRepository());

            }
        }

        public override Task<WhippetResultContainer<IJob>> GetJob(Guid id)
        {
            throw new NotImplementedException();
        }

        public override async Task<WhippetResultContainer<IEnumerable<IJob>>> GetJobs()
        {
            WhippetResultContainer<IEnumerable<Job>> result = await InternalServiceManager.GetAllAsync();
            return null;
        }

        public override Task<WhippetResultContainer<IEnumerable<IJob>>> GetJobs(IJobCategory category)
        {
            throw new NotImplementedException();
        }

        public override WhippetResultContainer<IJob> CreateJob(IJob job)
        {
            throw new NotImplementedException();
        }

        public override Task<WhippetResultContainer<IJob>> CreateJobAsync(IJob job)
        {
            throw new NotImplementedException();
        }

        public override WhippetResultContainer<IJob> UpdateJob(IJob job)
        {
            throw new NotImplementedException();
        }

        public override Task<WhippetResultContainer<IJob>> UpdateJobAsync(IJob job)
        {
            throw new NotImplementedException();
        }

        public override WhippetResultContainer<IJob> DeleteJob(IJob job)
        {
            throw new NotImplementedException();
        }

        public override Task<WhippetResultContainer<IJob>> DeleteJobAsync(IJob job)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the internal repository that the current <see cref="IJobRepository"/> is wrapping.
        /// </summary>
        /// <returns><see langword="dynamic"/> object that represents the repository being wrapped.</returns>
        dynamic IInternalRepositoryAccessor.GetInternalRepository()
        {
            return JobRepository;
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (InternalServiceManager is IDisposable)
            {
                InternalServiceManager.Dispose();
            }
        }
    }
}
