using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects.
    /// </summary>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        { get; }
    }
}
