using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieve a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesForCacheQuery : WhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>
    {
        /// <summary>
        /// Gets or sets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to filter by.
        /// </summary>
        public IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesForCacheQuery"/> class with no arguments.
        /// </summary>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesForCacheQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesForCacheQuery"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to filter by.</param>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesForCacheQuery(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
            : this()
        {
            Cache = cache;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Cache), Cache) });
        }
    }
}
