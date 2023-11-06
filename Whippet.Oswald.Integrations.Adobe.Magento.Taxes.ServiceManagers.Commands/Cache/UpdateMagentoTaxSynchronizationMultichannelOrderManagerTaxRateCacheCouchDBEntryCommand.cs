using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Command that updates an existing <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> class with no arguments.
        /// </summary>
        private UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/>.
        /// </summary>
        /// <param name="entry"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
            : base(entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
        }
    }
}
