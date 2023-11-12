using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand"/> object to handle.</typeparam>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand
    { }
}