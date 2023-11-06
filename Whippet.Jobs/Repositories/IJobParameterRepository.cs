using System;
using FluentNHibernate.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <typeparamref name="TJobParameter"/> entity objects.
    /// </summary>
    public interface IJobParameterRepository<TJobParameter, TJob> : IWhippetEntityRepository<TJobParameter, Guid>, IWhippetQueryRepository<TJobParameter>
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        /// <summary>
        /// Gets the parameter of type <typeparamref name="TJobParameter"/> for the specified <typeparamref name="TJob"/>.
        /// </summary>
        /// <param name="job"><typeparamref name="TJob"/> object to retrieve the <typeparamref name="TJobParameter"/> for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<TJobParameter>> Get(TJob job);

        /// <summary>
        /// Gets the parameter of type <typeparamref name="TJobParameter"/> for the specified <typeparamref name="TJob"/>.
        /// </summary>
        /// <param name="job"><typeparamref name="TJob"/> object to retrieve the <typeparamref name="TJobParameter"/> for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<TJobParameter>>> GetAsync(TJob job, CancellationToken? cancellationToken = null);
    }

    /// <summary>
    /// Represents a detached repository (independent of a backing context) that serves as a wrapper to <see cref="IJobParameterRepository{TJobParameter, TJob}"/> objects.
    /// </summary>
    public interface IJobParameterRepository : IWhippetDetachedRepository<JobParameter>, IJobParameterInternalRepositoryAccessor
    {
        /// <summary>
        /// Gets the parameter of type <see cref="JobParameter"/> for the specified <see cref="Job"/>.
        /// </summary>
        /// <param name="job"><see cref="Job"/> object to retrieve the <see cref="JobParameter"/> for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<JobParameter>> Get(Job job);

        /// <summary>
        /// Gets the parameter of type <see cref="JobParameter"/> for the specified <see cref="Job"/>.
        /// </summary>
        /// <param name="job"><see cref="Job"/> object to retrieve the <see cref="JobParameter"/> for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<JobParameter>>> GetAsync(Job job, CancellationToken? cancellationToken = null);
    }
}
