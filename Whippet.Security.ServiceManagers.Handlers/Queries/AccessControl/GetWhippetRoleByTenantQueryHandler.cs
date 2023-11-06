using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Queries;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetRolesByTenantQuery"/> objects.
    /// </summary>
    public class GetWhippetRolesByTenantQueryHandler : WhippetRoleQueryHandlerBase<GetWhippetRolesByTenantQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetRolesByTenantQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetRolesByTenantQueryHandler(IWhippetQueryRepository<WhippetRole> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetRole>>> HandleAsync(GetWhippetRolesByTenantQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetRole>> result = await Repository.GetByTenantAsync(query.Tenant);
                return new WhippetResultContainer<IEnumerable<WhippetRole>>(result.Result, result.Item);
            }
        }
    }
}
