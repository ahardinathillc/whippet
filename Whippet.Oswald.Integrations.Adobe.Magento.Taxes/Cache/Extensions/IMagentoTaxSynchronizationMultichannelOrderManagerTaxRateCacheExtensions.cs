using System;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> instance to a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.
        /// </summary>
        /// <param name="obj"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <returns><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</returns>
        public static MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache(this IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache obj)
        {
            MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache = null;

            if (obj != null)
            {
                if (obj is MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache)
                {
                    cache = (MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache)(obj);
                }
                else
                {
                    cache = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache(obj.ID, obj.Tenant.ToWhippetTenant(), obj.SourceServer.ToMultichannelOrderManagerServer(), obj.LastRefreshDate, obj.ExpirationDate);
                }
            }

            return cache;
        }
    }
}

