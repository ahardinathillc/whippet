using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Command that creates a new <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand : MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandBase, IWhippetCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> class with no arguments.
        /// </summary>
        private CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/>.
        /// </summary>
        /// <param name="entry"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
            : base(entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
        }
    }
}
