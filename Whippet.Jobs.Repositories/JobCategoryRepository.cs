using System;
using NHibernate;
using Athi.Whippet.Data;

namespace Athi.Whippet.Jobs.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="JobCategory"/> entity objects.
    /// </summary>
    public class JobCategoryRepository : WhippetEntityRepository<JobCategory>, IJobCategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public JobCategoryRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCategoryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public JobCategoryRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all child <see cref="JobCategory"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="parent">Parent <see cref="IJobCategory"/> to retrieve children for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<JobCategory>> GetChildren(IJobCategory parent)
        {
            ArgumentNullException.ThrowIfNull(parent);
            return Task.Run(() => GetChildrenAsync(parent)).Result;
        }

        /// <summary>
        /// Retrieves all child <see cref="JobCategory"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="parent">Parent <see cref="IJobCategory"/> to retrieve children for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<JobCategory>>> GetChildrenAsync(IJobCategory parent, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(parent);

            IList<JobCategory> queryResults = await Context.QueryOver<JobCategory>()
                .JoinQueryOver<JobCategory>(jc => jc.Parent)
                .Where(jcp => (jcp != null) && (jcp.ID == parent.ID))
                .ListAsync();

            return new WhippetResultContainer<IEnumerable<JobCategory>>(WhippetResult.Success, queryResults);
        }
    }
}

