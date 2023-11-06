using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands
{
    /// <summary>
    /// Base class for all commands that act upon <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects. This class must be inherited.
    /// </summary>
    public abstract class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandBase : WhippetCommand, IWhippetCommand, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand
    {
        /// <summary>
        /// Gets the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry Entry
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand.Entry
        {
            get
            {
                return Entry;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandBase"/> class with no arguments.
        /// </summary>
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandBase"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="entry"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance to create or act upon in the data store.</param>
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandBase(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry entry)
            : base()
        {
            Entry = entry;
        }
    }
}
