using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesCommand : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Gets the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to delete all entries from. This property is read-only.
        /// </summary>
        public IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesCommand"/> class with no arguments.
        /// </summary>
        private DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesCommand"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to remove all entries from.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesCommand(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
            : base()
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                Cache = cache;
            }
        }
    }
}
