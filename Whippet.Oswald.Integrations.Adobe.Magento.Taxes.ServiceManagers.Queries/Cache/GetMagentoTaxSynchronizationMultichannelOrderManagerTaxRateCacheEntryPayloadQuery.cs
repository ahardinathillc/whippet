using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a set number of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects starting a particular index to be sent back to the caller. This class cannot be inherited. 
    /// </summary>
    public sealed class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQuery : WhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>
    {
        /// <summary>
        /// Gets the starting index at which the payload is populated. This property is read-only.
        /// </summary>
        public int StartingIndex
        { get; private set; }
        
        /// <summary>
        /// Gets the total number of items to return for the payload. This property is read-only.
        /// </summary>
        public int Count
        { get; private set; }
        
        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that the payload should be created from. This property is read-only.
        /// </summary>
        public IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQuery"/> class with no arguments.
        /// </summary>
        private GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQuery"/> class with the specified starting index.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to draw the payload from.</param>
        /// <param name="startingIndex">Starting index of the payload.</param>
        /// <param name="count">Number of items to consume for the payload.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQuery(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int startingIndex, int count)
            : this()
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else if (startingIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startingIndex));
            }
            else if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            else
            {
                Cache = cache;
                StartingIndex = startingIndex;
                Count = count;
            }
        }
        
        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(Cache), Cache),
                new KeyValuePair<string, object>(nameof(StartingIndex), StartingIndex),
                new KeyValuePair<string, object>(nameof(Count), Count)
            });
        }
    }
}
