using System;
using NodaTime;
using Athi.Whippet.Json;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache
{
    /// <summary>
    /// Represents an entry in an <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
    /// </summary>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry : IWhippetEntity, IMultichannelOrderManagerTaxRateExport, IEqualityComparer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IJsonObject
    {
        /// <summary>
        /// Gets or sets the row number of the entry.
        /// </summary>
        int RowNumber
        { get; set; }
        
        /// <summary>
        /// Gets or sets the parent <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object that the entry belongs to.
        /// </summary>
        IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        { get; set; }

        /// <summary>
        /// Gets or sets the date the entry was created.
        /// </summary>
        Instant EntryDate
        { get; set; }

        /// <summary>
        /// Gets or sets the source <see cref="IMultichannelOrderManagerServer"/> where the tax data for MOM came from.
        /// </summary>
        IMultichannelOrderManagerServer MultichannelOrderManagerSourceServer
        { get; set; }

        /// <summary>
        /// Converts the current instance to a <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> object.
        /// </summary>
        /// <returns><see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> object.</returns>
        MultichannelOrderManagerFlattenedTaxRateExport ToTaxRateExport();
    }
}
