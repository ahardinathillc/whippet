using System;
using FluentNHibernate.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Jobs.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <typeparamref name="TJob"/> entity objects.
    /// </summary>
    public interface IJobRepository<TJob> : IWhippetEntityRepository<TJob, Guid>, IWhippetQueryRepository<TJob>
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Retrieves all <typeparamref name="TJob"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<TJob>> Get(IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <typeparamref name="TJob"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<TJob>>> GetAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <typeparamref name="TJob"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<TJob>> Get(IJobCategory category, IWhippetTenant tenant = null);

        /// <summary>
        /// Retrieves all <typeparamref name="TJob"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by (if any).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<TJob>>> GetAsync(IJobCategory category, IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }

    /// <summary>
    /// Represents a detached repository (independent of a backing context) that serves as a wrapper to <see cref="IJobRepository{TJob}"/> objects.
    /// </summary>
    public interface IJobRepository : IWhippetDetachedRepository<Job>, IJobInternalRepositoryAccessor
    {
        /// <summary>
        /// Retrieves all <see cref="Job"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<Job>> Get(IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="Job"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<Job>>> GetAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="Job"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<Job>> Get(IJobCategory category, IWhippetTenant tenant = null);

        /// <summary>
        /// Retrieves all <see cref="Job"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by (if any).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<Job>>> GetAsync(IJobCategory category, IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
