using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Commands;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IWhippetViewPermissionEntryCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetViewPermissionEntryCommand"/> object to handle.</typeparam>
    public interface IWhippetViewPermissionEntryCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IWhippetViewPermissionEntryCommand
    { }
}
