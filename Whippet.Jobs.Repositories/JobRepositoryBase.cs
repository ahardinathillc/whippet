using System;
using System.Collections.ObjectModel;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Jobs.Repositories
{
    /// <summary>
    /// Base class for data repositories that map <typeparamref name="TJob"/> entity objects. This class must be inherited.
    /// </summary>
    public abstract class JobRepositoryBase<TJob> : WhippetEntityRepository<TJob>, IJobRepository<TJob>
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobRepositoryBase{TJob}"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        protected JobRepositoryBase(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobRepositoryBase{TJob}"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        protected JobRepositoryBase(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <typeparamref name="TJob"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<TJob>> Get(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);
            return Task.Run(() => GetAsync(tenant)).Result;
        }

        /// <summary>
        /// Retrieves all <typeparamref name="TJob"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<TJob>>> GetAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IList<TJob> queryResults = await Context.QueryOver<TJob>()
                .JoinQueryOver<JobCategory>(jc => jc.Category)
                .ListAsync();

            if (queryResults != null && queryResults.Any())
            {
                queryResults = new ReadOnlyCollection<TJob>(queryResults.Where(j => j.Tenant.ID == tenant.ID).ToList());
            }

            return new WhippetResultContainer<IEnumerable<TJob>>(WhippetResult.Success, queryResults);
        }

        /// <summary>
        /// Retrieves all <typeparamref name="TJob"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<TJob>> Get(IJobCategory category, IWhippetTenant tenant = null)
        {
            ArgumentNullException.ThrowIfNull(category);
            return Task.Run(() => GetAsync(category, tenant)).Result;
        }

        /// <summary>
        /// Retrieves all <typeparamref name="TJob"/> objects for the specified <see cref="IJobCategory"/>.
        /// </summary>
        /// <param name="category"><see cref="IJobCategory"/> object to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by (if any).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<TJob>>> GetAsync(IJobCategory category, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(category);

            IList<TJob> queryResults = await Context.QueryOver<TJob>()
                .JoinQueryOver<JobCategory>(jc => jc.Category)
                .Where(jc => jc.ID == category.ID)
                .ListAsync();

            if (queryResults != null && queryResults.Any() && (tenant != null))
            {
                queryResults = new ReadOnlyCollection<TJob>(queryResults.Where(j => j.Tenant.ID == tenant.ID).ToList());
            }

            return new WhippetResultContainer<IEnumerable<TJob>>(WhippetResult.Success, queryResults);
        }
    }
}
