using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Queries;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetGroupUserAssignmentByUserQuery"/> objects.
    /// </summary>
    public class GetWhippetGroupUserAssignmentByUserQueryHandler : WhippetGroupUserAssignmentQueryHandlerBase<GetWhippetGroupUserAssignmentByUserQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetGroupUserAssignmentByUserQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetGroupUserAssignmentByUserQueryHandler(IWhippetQueryRepository<WhippetGroupUserAssignment> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>>> HandleAsync(GetWhippetGroupUserAssignmentByUserQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>> result = await Repository.GetByUserAsync(query.User);
                return new WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>>(result.Result, result.Item);
            }
        }
    }
}
