using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Queries;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetGroupByNameQuery"/> objects.
    /// </summary>
    public class GetWhippetGroupByNameQueryHandler : WhippetGroupQueryHandlerBase<GetWhippetGroupByNameQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetGroupByNameQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetGroupByNameQueryHandler(IWhippetQueryRepository<WhippetGroup> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetGroup>>> HandleAsync(GetWhippetGroupByNameQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetGroup> result = await Repository.GetByNameAsync(query.Name, query.Tenant);
                return new WhippetResultContainer<IEnumerable<WhippetGroup>>(result.Result, new[] { result.Item });
            }
        }
    }
}
