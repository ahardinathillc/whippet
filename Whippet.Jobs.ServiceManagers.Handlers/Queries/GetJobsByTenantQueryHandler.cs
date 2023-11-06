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
    /// Query handler for <see cref="GetJobsByTenantQuery{TJob}"/> objects.
    /// </summary>
    public class GetJobsByTenantQueryHandler<TJob> : JobQueryHandlerBase<GetJobsByTenantQuery<TJob>, TJob>, IJobQueryHandler<GetJobsByTenantQuery<TJob>, TJob>
        where TJob : JobBase, IJob, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetJobsByTenantQueryHandler{TJob}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetJobsByTenantQueryHandler(IWhippetQueryRepository<TJob> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<TJob>>> HandleAsync(GetJobsByTenantQuery<TJob> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<TJob>> queryResult = await Repository.GetAsync(query.Tenant);
                return new WhippetResultContainer<IEnumerable<TJob>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
