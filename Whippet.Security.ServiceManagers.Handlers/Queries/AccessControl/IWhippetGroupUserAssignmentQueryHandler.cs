using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="WhippetGroupUserAssignment"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IWhippetGroupUserAssignmentQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, WhippetGroupUserAssignment> where TQuery : IWhippetQuery<WhippetGroupUserAssignment>
    { }
}
