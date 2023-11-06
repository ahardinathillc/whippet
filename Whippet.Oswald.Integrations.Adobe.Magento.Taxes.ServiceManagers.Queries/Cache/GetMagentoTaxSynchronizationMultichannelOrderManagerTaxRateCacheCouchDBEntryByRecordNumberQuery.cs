using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieve a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object by its record number. This class cannot be inherited.
    /// </summary>
    public sealed class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByRecordNumberQuery : WhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>, IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>
    {
        /// <summary>
        /// Gets the record number of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> to retrieve. This property is read-only.
        /// </summary>
        public int RecordNumber
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to filter by. This property is read-only.
        /// </summary>
        public IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache Cache
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByRecordNumberQuery"/> class with no arguments.
        /// </summary>
        private GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByRecordNumberQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByRecordNumberQuery"/> class with the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to filter by.</param>
        /// <param name="recordNumber">Record number of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to retrieve.</param>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByRecordNumberQuery(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber)
            : this()
        {
            Cache = cache;
            RecordNumber = recordNumber;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(RecordNumber), RecordNumber),
                new KeyValuePair<string, object>(nameof(Cache), Cache)
            });
        }
    }
}
