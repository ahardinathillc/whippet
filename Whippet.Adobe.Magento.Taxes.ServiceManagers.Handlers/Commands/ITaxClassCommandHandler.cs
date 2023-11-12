using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="ITaxClass"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxClass"/> object to handle.</typeparam>
    public interface ITaxClassCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : ITaxClassCommand
    { }
}