using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> class with no arguments.
        /// </summary>
        private CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
            : base(cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
        }
    }
}
