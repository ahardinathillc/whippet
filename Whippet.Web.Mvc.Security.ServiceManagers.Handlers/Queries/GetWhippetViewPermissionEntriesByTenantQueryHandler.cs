using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Queries;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetViewPermissionEntriesByTenantQuery"/> objects.
    /// </summary>
    public class GetWhippetViewPermissionEntriesByTenantQueryHandler : WhippetViewPermissionEntryQueryHandlerBase<GetWhippetViewPermissionEntriesByTenantQuery>, IWhippetViewPermissionEntryQueryHandler<GetWhippetViewPermissionEntriesByTenantQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetViewPermissionEntriesByTenantQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetViewPermissionEntriesByTenantQueryHandler(IWhippetQueryRepository<WhippetViewPermissionEntry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> HandleAsync(GetWhippetViewPermissionEntriesByTenantQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> queryResult = await Repository.GetByTenantAsync(query.Tenant);
                return new WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
