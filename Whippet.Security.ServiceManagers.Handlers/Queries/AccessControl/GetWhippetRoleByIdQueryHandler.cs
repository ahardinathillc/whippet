using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Queries;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetRoleByIdQuery"/> objects.
    /// </summary>
    public class GetWhippetRoleByIdQueryHandler : WhippetRoleQueryHandlerBase<GetWhippetRoleByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetRoleByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetRoleByIdQueryHandler(IWhippetQueryRepository<WhippetRole> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetRole>>> HandleAsync(GetWhippetRoleByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetRole> result = await Repository.GetAsync(query.RoleId);
                return new WhippetResultContainer<IEnumerable<WhippetRole>>(result.Result, new[] { result.Item });
            }
        }
    }
}
