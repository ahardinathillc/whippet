using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="ITaxRate"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxRate"/> object to handle.</typeparam>
    public interface ITaxRateCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : ITaxRateCommand
    { }
}