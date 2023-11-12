using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> object to handle.</typeparam>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand
    { }
}