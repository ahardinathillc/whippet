using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IMultichannelOrderManagerServerCommand"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMultichannelOrderManagerServerCommand"/> object to handle.</typeparam>
    public interface IMultichannelOrderManagerServerCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IMultichannelOrderManagerServerCommand
    { }
}
