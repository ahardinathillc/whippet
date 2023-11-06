using System;
using Athi.Whippet.Repositories;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Jobs.Repositories;

namespace Athi.Whippet.Jobs.ServiceManagers
{
    /// <summary>
    /// Base class for all service managers for <see cref="IJobParameter"/> domain objects. This class must be inherited.
    /// </summary>
    public abstract class JobParameterServiceManager<TJobParameter, TJob> : ServiceManager, IDisposable, IJobParameterServiceManager, IJobInternalRepositoryAccessor, IInternalRepositoryAccessor
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        /// <summary>
        /// Gets the <see cref="IJobParameterRepository{TJobParameter, TJob}"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IJobParameterRepository<TJobParameter, TJob> JobParameterRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterServiceManager{TJobParameter, TJob}"/> class with no arguments.
        /// </summary>
        protected JobParameterServiceManager()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterServiceManager{TJobParameter, TJob}"/> class with the specified <see cref="IJobParameterRepository{TJobParameter, TJob}"/> object.
        /// </summary>
        /// <param name="parameterRepository"><see cref="IJobParameterRepository{TJobParameter, TJob}"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected JobParameterServiceManager(IJobParameterRepository<TJobParameter, TJob> parameterRepository)
            : base()
        {
            if (parameterRepository == null)
            {
                throw new ArgumentNullException(nameof(parameterRepository));
            }
            else
            {
                JobParameterRepository = parameterRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IJobParameterRepository{TJobParameter, TJob}"/> class with the specified <see cref="IJobParameterRepository{TJobParameter, TJob}"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="parameterRepository"><see cref="IJobParameterRepository{TJobParameter, TJob}"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected JobParameterServiceManager(IWhippetServiceContext serviceLocator, IJobParameterRepository<TJobParameter, TJob> parameterRepository)
            : base(serviceLocator)
        {
            if (parameterRepository == null)
            {
                throw new ArgumentNullException(nameof(parameterRepository));
            }
            else
            {
                JobParameterRepository = parameterRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IJobParameter"/> object with the specified ID. This method must be overridden.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJobParameter"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public abstract Task<WhippetResultContainer<TJobParameter>> GetJobParameter(Guid id);

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system. This method must be overridden.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public abstract Task<WhippetResultContainer<IEnumerable<TJobParameter>>> GetJobParameters();

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system for the specified <see cref="IJob"/>. This method must be overridden.
        /// </summary>
        /// <param name="parameter"><see cref="IJob"/> to get parameters for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<TJobParameter>>> GetJobParameters(TJob job);

        /// <summary>
        /// Creates a new Whippet job parameter. This method must be overridden.
        /// </summary>
        /// <param name="parameter">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResultContainer<TJobParameter> CreateJobParameter(TJobParameter parameter);

        /// <summary>
        /// Creates a new Whippet job parameter. This method must be overridden.
        /// </summary>
        /// <param name="parameter">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<TJobParameter>> CreateJobAsync(TJobParameter parameter);

        /// <summary>
        /// Updates an existing Whippet job parameter. This method must be overridden.
        /// </summary>
        /// <param name="parameter">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResultContainer<TJobParameter> UpdateJobParameter(TJobParameter parameter);

        /// <summary>
        /// Updates an existing Whippet job parameter. This method must be overridden.
        /// </summary>
        /// <param name="parameter">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<TJobParameter>> UpdateJobAsync(TJobParameter parameter);

        /// <summary>
        /// Deletes an existing Whippet job parameter. This method must be overridden.
        /// </summary>
        /// <param name="parameter">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResultContainer<TJobParameter> DeleteJobParameter(TJobParameter parameter);

        /// <summary>
        /// Deletes an existing Whippet job parameter. This method must be overridden.
        /// </summary>
        /// <param name="parameter">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<TJobParameter>> DeleteJobParameterAsync(TJobParameter parameter);

        /// <summary>
        /// Retrieves the <see cref="IJobParameter"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJobParameter"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        async Task<WhippetResultContainer<IJobParameter>> IJobParameterServiceManager.GetJobParameter(Guid id)
        {
            WhippetResultContainer<TJobParameter> result = await GetJobParameter(id);
            return new WhippetResultContainer<IJobParameter>(result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        async Task<WhippetResultContainer<IEnumerable<IJobParameter>>> IJobParameterServiceManager.GetJobParameters()
        {
            WhippetResultContainer<IEnumerable<TJobParameter>> result = await GetJobParameters();
            return new WhippetResultContainer<IEnumerable<IJobParameter>>(result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system for the specified <see cref="IJob"/>.
        /// </summary>
        /// <param name="job"><see cref="IJob"/> to get parameters for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        async Task<WhippetResultContainer<IEnumerable<IJobParameter>>> IJobParameterServiceManager.GetJobParameters(IJob job)
        {
            WhippetResultContainer<IEnumerable<TJobParameter>> result = await GetJobParameters((TJob)(job));
            return new WhippetResultContainer<IEnumerable<IJobParameter>>(result, result.Item);
        }

        /// <summary>
        /// Creates a new Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IJobParameter> IJobParameterServiceManager.CreateJobParameter(IJobParameter parameter)
        {
            WhippetResultContainer<TJobParameter> result = CreateJobParameter((TJobParameter)(parameter));
            return new WhippetResultContainer<IJobParameter>(result, result.Item);
        }

        /// <summary>
        /// Creates a new Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        async Task<WhippetResultContainer<IJobParameter>> IJobParameterServiceManager.CreateJobAsync(IJobParameter parameter)
        {
            WhippetResultContainer<TJobParameter> result = await CreateJobAsync((TJobParameter)(parameter));
            return new WhippetResultContainer<IJobParameter>(result, result.Item);
        }

        /// <summary>
        /// Updates an existing Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IJobParameter> IJobParameterServiceManager.UpdateJobParameter(IJobParameter parameter)
        {
            WhippetResultContainer<TJobParameter> result = UpdateJobParameter((TJobParameter)(parameter));
            return new WhippetResultContainer<IJobParameter>(result, result.Item);
        }

        /// <summary>
        /// Updates an existing Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        async Task<WhippetResultContainer<IJobParameter>> IJobParameterServiceManager.UpdateJobAsync(IJobParameter parameter)
        {
            WhippetResultContainer<TJobParameter> result = await UpdateJobAsync((TJobParameter)(parameter));
            return new WhippetResultContainer<IJobParameter>(result, result.Item);
        }

        /// <summary>
        /// Deletes an existing Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IJobParameter> IJobParameterServiceManager.DeleteJobParameter(IJobParameter parameter)
        {
            WhippetResultContainer<TJobParameter> result = DeleteJobParameter((TJobParameter)(parameter));
            return new WhippetResultContainer<IJobParameter>(result, result.Item);
        }

        /// <summary>
        /// Deletes an existing Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        async Task<WhippetResultContainer<IJobParameter>> IJobParameterServiceManager.DeleteJobParameterAsync(IJobParameter parameter)
        {
            WhippetResultContainer<TJobParameter> result = await DeleteJobParameterAsync((TJobParameter)(parameter));
            return new WhippetResultContainer<IJobParameter>(result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (JobParameterRepository != null)
            {
                JobParameterRepository.Dispose();
                JobParameterRepository = null;
            }

            base.Dispose();
        }

        /// <summary>
        /// Retrieves the internal repository that the current <see cref="IJobParameterRepository"/> is wrapping.
        /// </summary>
        /// <returns><see langword="dynamic"/> object that represents the repository being wrapped.</returns>
        dynamic IInternalRepositoryAccessor.GetInternalRepository()
        {
            return JobParameterRepository;
        }
    }
}
