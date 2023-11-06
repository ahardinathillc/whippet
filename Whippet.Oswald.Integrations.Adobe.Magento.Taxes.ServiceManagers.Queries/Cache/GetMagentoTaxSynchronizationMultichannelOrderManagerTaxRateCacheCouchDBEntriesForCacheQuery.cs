using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieve a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery : WhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>, IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>
    {
        /// <summary>
        /// Gets or sets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to filter by.
        /// </summary>
        public IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        { get; set; }

        /// <summary>
        /// Gets or sets the starting record number for a particular range.
        /// </summary>
        public int? StartingRecordNumber
        { get; set; }
        
        /// <summary>
        /// Gets or sets the number of records to return. Used in conjunction with <see cref="StartingRecordNumber"/>.
        /// </summary>
        public int? Count
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery"/> class with no arguments.
        /// </summary>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to filter by.</param>
        /// <param name="startingRecordNumber">Starting record number for a particular range.</param>
        /// <param name="count">Number of records to return. Used in conjunction with a range of record numbers.</param>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int? startingRecordNumber = null, int? count = null)
            : this()
        {
            Cache = cache;
            StartingRecordNumber = startingRecordNumber;
            Count = count;
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
                new KeyValuePair<string, object>(nameof(StartingRecordNumber), StartingRecordNumber),
                new KeyValuePair<string, object>(nameof(Count), Count)
            });
        }
    }
}
