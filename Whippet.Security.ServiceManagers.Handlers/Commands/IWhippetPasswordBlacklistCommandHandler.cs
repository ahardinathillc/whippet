using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Commands;

namespace Athi.Whippet.Security.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IWhippetPasswordBlacklistCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetPasswordBlacklistCommand"/> object to handle.</typeparam>
    public interface IWhippetPasswordBlacklistCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IWhippetPasswordBlacklistCommand
    { }
}
