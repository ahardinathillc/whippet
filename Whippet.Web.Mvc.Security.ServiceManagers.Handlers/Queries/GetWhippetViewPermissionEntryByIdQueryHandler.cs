using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Queries;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetViewPermissionEntryByIdQuery"/> objects.
    /// </summary>
    public class GetWhippetViewPermissionEntryByIdQueryHandler : WhippetViewPermissionEntryQueryHandlerBase<GetWhippetViewPermissionEntryByIdQuery>, IWhippetViewPermissionEntryQueryHandler<GetWhippetViewPermissionEntryByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetViewPermissionEntryByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetViewPermissionEntryByIdQueryHandler(IWhippetQueryRepository<WhippetViewPermissionEntry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> HandleAsync(GetWhippetViewPermissionEntryByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetViewPermissionEntry> queryResult = await Repository.GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}
