using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="WhippetRole"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IWhippetRoleQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, WhippetRole> where TQuery : IWhippetQuery<WhippetRole>
    { }
}
