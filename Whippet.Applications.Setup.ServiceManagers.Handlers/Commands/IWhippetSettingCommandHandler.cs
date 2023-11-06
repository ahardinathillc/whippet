using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Applications.Setup.ServiceManagers.Commands;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IWhippetSettingCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetSettingCommand"/> object to handle.</typeparam>
    public interface IWhippetSettingCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IWhippetSettingCommand
    { }
}
