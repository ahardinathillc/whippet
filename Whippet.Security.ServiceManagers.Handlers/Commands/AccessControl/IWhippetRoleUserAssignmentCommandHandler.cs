using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.ServiceManagers.Commands;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IWhippetRoleUserAssignmentCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetRoleUserAssignmentCommand"/> object to handle.</typeparam>
    public interface IWhippetRoleUserAssignmentCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IWhippetRoleUserAssignmentCommand
    { }
}

