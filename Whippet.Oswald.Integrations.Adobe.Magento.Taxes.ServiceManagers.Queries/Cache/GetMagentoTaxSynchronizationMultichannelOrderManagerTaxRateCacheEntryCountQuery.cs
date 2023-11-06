using System;
using System.Threading;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves the total number of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects in a specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery : WhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>
    {
        /// <summary>
        /// Gets the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to filter by. This property is read-only.
        /// </summary>
        public IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery"/> class with no arguments.
        /// </summary>
        private GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
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
