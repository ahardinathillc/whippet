using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Queries;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetViewPermissionEntriesByPermissionQuery"/> objects.
    /// </summary>
    public class GetWhippetViewPermissionEntriesByPermissionQueryHandler : WhippetViewPermissionEntryQueryHandlerBase<GetWhippetViewPermissionEntriesByPermissionQuery>, IWhippetViewPermissionEntryQueryHandler<GetWhippetViewPermissionEntriesByPermissionQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetViewPermissionEntriesByPermissionQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetViewPermissionEntriesByPermissionQueryHandler(IWhippetQueryRepository<WhippetViewPermissionEntry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> HandleAsync(GetWhippetViewPermissionEntriesByPermissionQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> queryResult = await Repository.GetByPermissionAsync(query.Permission, query.Tenant);
                return new WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
