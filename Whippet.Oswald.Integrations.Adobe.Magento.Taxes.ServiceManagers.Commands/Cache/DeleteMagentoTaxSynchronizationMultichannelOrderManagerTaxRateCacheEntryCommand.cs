using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand"/> class with no arguments.
        /// </summary>
        private DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/>.
        /// </summary>
        /// <param name="entry"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry entry)
            : base(entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
        }
    }
}
