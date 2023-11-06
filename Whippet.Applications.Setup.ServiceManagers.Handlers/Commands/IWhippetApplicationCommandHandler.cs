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
    /// Handles commands for <see cref="IWhippetApplicationCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IWhippetApplicationCommand"/> object to handle.</typeparam>
    public interface IWhippetApplicationCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IWhippetApplicationCommand
    { }
}
