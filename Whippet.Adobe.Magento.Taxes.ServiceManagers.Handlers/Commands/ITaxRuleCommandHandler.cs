using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Commands;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="ITaxRule"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxRule"/> object to handle.</typeparam>
    public interface ITaxRuleCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : ITaxRuleCommand
    { }
}
