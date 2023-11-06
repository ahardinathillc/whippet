using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="WhippetRoleUserAssignment"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IWhippetRoleUserAssignmentQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, WhippetRoleUserAssignment> where TQuery : IWhippetQuery<WhippetRoleUserAssignment>
    { }
}
