using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands
{
    /// <summary>
    /// Handles commands for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects.
    /// </summary>
    /// <typeparam name="TCommand"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> object to handle.</typeparam>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandHandler<TCommand> : IWhippetCommandHandler<TCommand> where TCommand : IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand
    { }
}