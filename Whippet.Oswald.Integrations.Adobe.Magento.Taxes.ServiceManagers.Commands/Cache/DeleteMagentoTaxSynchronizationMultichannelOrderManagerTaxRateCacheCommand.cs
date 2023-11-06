using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Command that deletes an existing <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> class with no arguments.
        /// </summary>
        private DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
            : base(cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
        }
    }
}
