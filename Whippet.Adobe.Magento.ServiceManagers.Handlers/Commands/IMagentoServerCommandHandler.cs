using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IMagentoServer"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoServerCommand"/> object to handle.</typeparam>
    public interface IMagentoServerCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IMagentoServerCommand
    { }
}
