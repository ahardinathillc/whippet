using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieve a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryByIdQuery : WhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>
    {
        /// <summary>
        /// Gets the ID of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> to retrieve. This property is read-only.
        /// </summary>
        public Guid ID
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryByIdQuery"/> class with no arguments.
        /// </summary>
        private GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to retrieve.</param>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryByIdQuery(Guid id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ID), ID) });
        }
    }
}