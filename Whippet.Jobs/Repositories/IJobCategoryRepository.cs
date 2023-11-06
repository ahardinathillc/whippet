using System;
using FluentNHibernate.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="JobCategory"/> entity objects.
    /// </summary>
    public interface IJobCategoryRepository : IWhippetEntityRepository<JobCategory, Guid>, IWhippetQueryRepository<JobCategory>
    {
        /// <summary>
        /// Retrieves all child <see cref="JobCategory"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="parent">Parent <see cref="IJobCategory"/> to retrieve children for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<JobCategory>> GetChildren(IJobCategory parent);

        /// <summary>
        /// Retrieves all child <see cref="JobCategory"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="parent">Parent <see cref="IJobCategory"/> to retrieve children for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<JobCategory>>> GetChildrenAsync(IJobCategory parent, CancellationToken? cancellationToken = null);
    }
}
