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
    public abstract class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandBase : WhippetCommand, IWhippetCommand, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand
    {
        /// <summary>
        /// Gets the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance to act upon in the data store. This property is read-only.
        /// </summary>
        IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommand.Cache
        {
            get
            {
                return Cache;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandBase"/> class with no arguments.
        /// </summary>
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandBase()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandBase"/> class with the specified <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance to create or act upon in the data store.</param>
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCommandBase(MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
            : base()
        {
            Cache = cache;
        }
    }
}
