using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.Repositories;

namespace Athi.Whippet.Jobs.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class JobParameterQueryHandlerBase<TQuery, TJobParameter, TJob> : WhippetQueryHandler<TJobParameter>, IWhippetQueryHandler<TQuery, TJobParameter>, IJobParameterQueryHandler<TQuery, TJobParameter, TJob>
        where TQuery : IWhippetQuery<TJobParameter>
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        /// <summary>
        /// Gets the <see cref="IJobParameterRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IJobParameterRepository<TJobParameter, TJob> Repository
        {
            get
            {
                return base.Repository as IJobParameterRepository<TJobParameter, TJob>;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobParameterQueryHandlerBase{TQuery, TJobParameter, TJob}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected JobParameterQueryHandlerBase(IWhippetQueryRepository<TJobParameter> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<TJobParameter>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<TJobParameter>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
