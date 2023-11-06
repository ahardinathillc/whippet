using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Represents a command that acts upon <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects.
    /// </summary>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand : IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry Entry
        { get; }
    }
}
