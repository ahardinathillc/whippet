using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IMultichannelOrderManagerRestEndpoint"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMultichannelOrderManagerRestEndpointCommand"/> object to handle.</typeparam>
    public interface IMultichannelOrderManagerRestEndpointCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IMultichannelOrderManagerRestEndpointCommand
    { }
}
