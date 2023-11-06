using System;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance to a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.
        /// </summary>
        /// <param name="obj"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.</param>
        /// <returns><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.</returns>
        public static MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(this IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry obj)
        {
            MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry cache = null;

            if (obj != null)
            {
                cache = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(obj.ID, obj.Cache.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache(), obj, obj.EntryDate);
                ((IMultichannelOrderManagerTaxRateExport)(cache)).Server = obj.Server;
                cache.RowNumber = obj.RowNumber;
            }

            return cache;
        }
    }
}
