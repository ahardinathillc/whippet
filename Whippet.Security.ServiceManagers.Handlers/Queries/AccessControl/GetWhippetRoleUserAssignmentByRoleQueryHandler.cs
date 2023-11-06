using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Queries;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetRoleUserAssignmentByRoleQuery"/> objects.
    /// </summary>
    public class GetWhippetRoleUserAssignmentByRoleQueryHandler : WhippetRoleUserAssignmentQueryHandlerBase<GetWhippetRoleUserAssignmentByRoleQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetRoleUserAssignmentByRoleQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetRoleUserAssignmentByRoleQueryHandler(IWhippetQueryRepository<WhippetRoleUserAssignment> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>>> HandleAsync(GetWhippetRoleUserAssignmentByRoleQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>> result = await Repository.GetByRoleAsync(query.Role);
                return new WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>>(result.Result, result.Item);
            }
        }
    }
}
