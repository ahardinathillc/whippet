using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="WhippetGroup"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IWhippetGroupQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, WhippetGroup> where TQuery : IWhippetQuery<WhippetGroup>
    { }
}
