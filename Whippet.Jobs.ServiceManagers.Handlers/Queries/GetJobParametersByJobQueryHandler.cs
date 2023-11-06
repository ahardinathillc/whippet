using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Jobs.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetJobParametersByJobQuery{TJobParameter, TJob}"/> objects.
    /// </summary>
    /// <typeparam name="TJobParameter"><see cref="IJobParameter"/> type that is returned by the query.</typeparam>
    /// <typeparam name="TJob"><see cref="IJob"/> type that <typeparamref name="TJobParameter"/> applies to.</typeparam>
    public class GetJobParametersByJobQueryHandler<TJobParameter, TJob> : JobParameterQueryHandlerBase<GetJobParametersByJobQuery<TJobParameter, TJob>, TJobParameter, TJob>, IJobParameterQueryHandler<GetJobParametersByJobQuery<TJobParameter, TJob>, TJobParameter, TJob>
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobParametersByJobQueryHandler{TJobParameter, TJob}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetJobParametersByJobQueryHandler(IWhippetQueryRepository<TJobParameter> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<TJobParameter>>> HandleAsync(GetJobParametersByJobQuery<TJobParameter, TJob> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<TJobParameter>> queryResult = await Repository.GetAsync(query.Job);
                return queryResult;
            }
        }
    }
}
