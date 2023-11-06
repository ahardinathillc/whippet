using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Web.Mvc.Security;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="WhippetViewPermissionEntry"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IWhippetViewPermissionEntryQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, WhippetViewPermissionEntry> where TQuery : IWhippetQuery<WhippetViewPermissionEntry>
    { }
}
