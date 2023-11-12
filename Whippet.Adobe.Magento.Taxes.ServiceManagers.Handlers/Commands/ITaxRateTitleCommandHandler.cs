using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="ITaxRateTitle"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxRateTitle"/> object to handle.</typeparam>
    public interface ITaxRateTitleCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : ITaxRateTitleCommand
    { }
}