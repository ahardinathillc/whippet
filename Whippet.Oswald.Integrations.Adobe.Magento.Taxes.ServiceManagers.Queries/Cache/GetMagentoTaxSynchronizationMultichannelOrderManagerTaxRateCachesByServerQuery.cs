using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieve a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCachesByServerQuery : WhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>, IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>
    {
        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerServer"/> to filter by.
        /// </summary>
        public IMultichannelOrderManagerServer Server
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCachesByServerQuery"/> class with no arguments.
        /// </summary>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCachesByServerQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCachesByServerQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> to filter by.</param>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCachesByServerQuery(IMultichannelOrderManagerServer server)
            : this()
        {
            Server = server;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Server), Server) });
        }
    }
}
