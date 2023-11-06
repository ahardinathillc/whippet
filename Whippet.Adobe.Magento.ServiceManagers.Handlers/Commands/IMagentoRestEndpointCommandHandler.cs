using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IMagentoRestEndpoint"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoRestEndpointCommand"/> object to handle.</typeparam>
    public interface IMagentoRestEndpointCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IMagentoRestEndpointCommand
    { }
}
