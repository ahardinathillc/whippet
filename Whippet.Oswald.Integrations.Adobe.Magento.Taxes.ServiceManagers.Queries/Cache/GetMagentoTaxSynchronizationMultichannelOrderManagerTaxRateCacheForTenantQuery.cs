using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieve a <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheForTenantQuery : WhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>, IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> to filter by.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheForTenantQuery"/> class with no arguments.
        /// </summary>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheForTenantQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheForTenantQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        public GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheForTenantQuery(IWhippetTenant tenant)
            : this()
        {
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Tenant), Tenant) });
        }
    }
}
