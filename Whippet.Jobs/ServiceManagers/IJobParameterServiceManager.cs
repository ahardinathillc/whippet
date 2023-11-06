using System;
using Athi.Whippet.Jobs.Repositories;
using Athi.Whippet.ServiceManagers;

namespace Athi.Whippet.Jobs.ServiceManagers
{
    /// <summary>
    /// Provides support for service managers for <see cref="IJobParameter"/> domain objects.
    /// </summary>
    public interface IJobParameterServiceManager : IDisposable, IServiceManager, IJobParameterInternalRepositoryAccessor
    {
        /// <summary>
        /// Retrieves the <see cref="IJobParameter"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IJobParameter"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        Task<WhippetResultContainer<IJobParameter>> GetJobParameter(Guid id);

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        Task<WhippetResultContainer<IEnumerable<IJobParameter>>> GetJobParameters();

        /// <summary>
        /// Retrieves all <see cref="IJobParameter"/> objects in the system for the specified <see cref="IJob"/>.
        /// </summary>
        /// <param name="job"><see cref="IJob"/> to get parameters for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<IJobParameter>>> GetJobParameters(IJob job);

        /// <summary>
        /// Creates a new Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IJobParameter> CreateJobParameter(IJobParameter parameter);

        /// <summary>
        /// Creates a new Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created job.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IJobParameter>> CreateJobAsync(IJobParameter parameter);

        /// <summary>
        /// Updates an existing Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IJobParameter> UpdateJobParameter(IJobParameter parameter);

        /// <summary>
        /// Updates an existing Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated job.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IJobParameter>> UpdateJobAsync(IJobParameter parameter);

        /// <summary>
        /// Deletes an existing Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IJobParameter> DeleteJobParameter(IJobParameter parameter);

        /// <summary>
        /// Deletes an existing Whippet job parameter.
        /// </summary>
        /// <param name="parameter">Job to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted job.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IJobParameter>> DeleteJobParameterAsync(IJobParameter parameter);
    }
}

