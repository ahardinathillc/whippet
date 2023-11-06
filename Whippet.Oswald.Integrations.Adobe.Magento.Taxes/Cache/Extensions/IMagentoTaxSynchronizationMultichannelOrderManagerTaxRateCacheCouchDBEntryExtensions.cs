using System;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance to a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.
        /// </summary>
        /// <param name="obj"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.</param>
        /// <returns><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.</returns>
        public static MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry(this IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry obj)
        {
            MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry = null;

            if (obj != null)
            {
                if (obj is MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry)
                {
                    entry = ((MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry)(obj));
                }
                else
                {
                    entry = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry(obj);
                }
            }

            return entry;
        }
    }
}
