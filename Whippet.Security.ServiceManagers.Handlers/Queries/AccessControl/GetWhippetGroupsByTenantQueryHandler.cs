using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Queries;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetGroupsByTenantQuery"/> objects.
    /// </summary>
    public class GetWhippetGroupsByTenantQueryHandler : WhippetGroupQueryHandlerBase<GetWhippetGroupsByTenantQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetGroupsByTenantQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetGroupsByTenantQueryHandler(IWhippetQueryRepository<WhippetGroup> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetGroup>>> HandleAsync(GetWhippetGroupsByTenantQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetGroup>> result = await Repository.GetByTenantAsync(query.Tenant);
                return new WhippetResultContainer<IEnumerable<WhippetGroup>>(result.Result, result.Item);
            }
        }
    }
}
