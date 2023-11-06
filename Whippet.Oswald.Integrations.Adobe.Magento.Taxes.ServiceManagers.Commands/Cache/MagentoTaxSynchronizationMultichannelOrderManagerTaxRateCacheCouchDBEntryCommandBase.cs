using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects. This class must be inherited.
    /// </summary>
    public abstract class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandBase : WhippetCommand, IWhippetCommand, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand
    {
        /// <summary>
        /// Gets the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry Entry
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand.Entry
        {
            get
            {
                return Entry;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandBase"/> class with no arguments.
        /// </summary>
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandBase"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/>.
        /// </summary>
        /// <param name="entry"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> instance to create or act upon in the data store.</param>
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandBase(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
            : base()
        {
            Entry = entry;
        }
    }
}
