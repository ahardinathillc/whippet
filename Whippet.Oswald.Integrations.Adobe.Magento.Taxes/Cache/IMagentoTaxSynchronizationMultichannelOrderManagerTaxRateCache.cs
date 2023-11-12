using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache
{
    /// <summary>
    /// Represents a database cache for storing Magento tax rate information.
    /// </summary>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache : IWhippetEntity, IEqualityComparer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> belongs to.
        /// </summary>
        IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Gets or sets the last date and time (in UTC format) the cache was refreshed.
        /// </summary>
        Instant LastRefreshDate
        { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        Instant ExpirationDate
        { get; set; }

        /// <summary>
        /// Gets or sets the Multichannel Order Manager server where the tax rates are loaded from.
        /// </summary>
        MultichannelOrderManagerServer SourceServer
        { get; set; }
    }
}