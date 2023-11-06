using System;
using Athi.Whippet.Jobs.Repositories;
using Athi.Whippet.ServiceManagers;

namespace Athi.Whippet.Jobs.ServiceManagers
{
    /// <summary>
    /// Provides support for service managers for <see cref="IJob"/> domain objects.
    /// </summary>
    public interface IJobServiceManager : IDisposable, IServiceManager, IJobInternalRepositoryAccessor
    {
        /// <summary>
        /// Retrieves the <see cref="IJob"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJob"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        Task<WhippetResultContainer<IJob>> GetJob(Guid id);

        /// <summary>
        /// Retrieves all <see cref="IJob"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        Task<WhippetResultContainer<IEnumerable<IJob>>> GetJobs();

        /// <summary>
        /// Retrieves all <see cref="IJob"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        Task<WhippetResultContainer<IEnumerable<IJob>>> GetJobs(IJobCategory category);

        /// <summary>
        /// Creates a new Whippet job.
        /// </summary>
        /// <param name="job">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IJob> CreateJob(IJob job);

        /// <summary>
        /// Creates a new Whippet job.
        /// </summary>
        /// <param name="job">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IJob>> CreateJobAsync(IJob job);

        /// <summary>
        /// Updates an existing Whippet job.
        /// </summary>
        /// <param name="job">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IJob> UpdateJob(IJob job);

        /// <summary>
        /// Updates an existing Whippet job.
        /// </summary>
        /// <param name="job">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IJob>> UpdateJobAsync(IJob job);

        /// <summary>
        /// Deletes an existing Whippet job.
        /// </summary>
        /// <param name="job">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IJob> DeleteJob(IJob job);

        /// <summary>
        /// Deletes an existing Whippet job.
        /// </summary>
        /// <param name="job">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IJob>> DeleteJobAsync(IJob job);
    }
}

