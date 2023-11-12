using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Commands;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles bulk commands for <see cref="ITaxRate"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="ITaxRate"/> bulk command object to handle.</typeparam>
    public interface ITaxRateBulkCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IMagentoEntityBulkCommand<ITaxRate>
    { }
}
