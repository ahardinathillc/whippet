using System;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.Repositories
{
    /// <summary>
    /// Base class for data repositories that map <typeparamref name="TJobParameter"/> entity objects. This class must be inherited.
    /// </summary>
    /// <typeparam name="TJobParameter"><see cref="IJobParameter"/> type that the repository stores.</typeparam>
    /// <typeparam name="TJob"><see cref="IJob"/> type that <typeparamref name="TJobParameter"/> is for.</typeparam>
    public abstract class JobParameterRepositoryBase<TJobParameter, TJob> : WhippetEntityRepository<TJobParameter>, IJobParameterRepository<TJobParameter, TJob>, IWhippetEntityRepository<TJobParameter, Guid>, IWhippetQueryRepository<TJobParameter>
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterRepositoryBase{TJobParamter, TJob}"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        protected JobParameterRepositoryBase(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterRepositoryBase{TJobParamter, TJob}"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        protected JobParameterRepositoryBase(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Query that retrieves all <typeparamref name="TJobParameter"/> objects in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public override async Task<WhippetResultContainer<IEnumerable<TJobParameter>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            IList<TJobParameter> queryResults = await Context.QueryOver<TJobParameter>()
                .JoinQueryOver<TJob>(j => j.Job)
                .ListAsync();

            return new WhippetResultContainer<IEnumerable<TJobParameter>>(WhippetResult.Success, queryResults);
        }

        /// <summary>
        /// Gets the parameter of type <typeparamref name="TJobParameter"/> for the specified <typeparamref name="TJob"/>.
        /// </summary>
        /// <param name="job"><typeparamref name="TJob"/> object to retrieve the <typeparamref name="TJobParameter"/> for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<TJobParameter>> Get(TJob job)
        {
            ArgumentNullException.ThrowIfNull(job);
            return Task.Run(() => GetAsync(job)).Result;
        }

        /// <summary>
        /// Gets the parameter of type <typeparamref name="TJobParameter"/> for the specified <typeparamref name="TJob"/>.
        /// </summary>
        /// <param name="job"><typeparamref name="TJob"/> object to retrieve the <typeparamref name="TJobParameter"/> for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<TJobParameter>>> GetAsync(TJob job, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(job);

            IList<TJobParameter> queryResults = await Context.QueryOver<TJobParameter>()
                .JoinQueryOver<TJob>(j => j.Job)
                .Where(j => j.ID == job.ID)
                .ListAsync();

            return new WhippetResultContainer<IEnumerable<TJobParameter>>(WhippetResult.Success, queryResults);
        }
    }
}

