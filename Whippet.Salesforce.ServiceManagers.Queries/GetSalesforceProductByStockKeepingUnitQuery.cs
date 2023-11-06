using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Salesforce.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="SalesforceProduct"/> objects based on a specific SKU.
    /// </summary>
    public class GetSalesforceProductByStockKeepingUnitQuery : WhippetQuery<SalesforceProduct>, IWhippetQuery<SalesforceProduct>
    {
        /// <summary>
        /// Gets or sets the SKU of the <see cref="SalesforceProduct"/> to query by.
        /// </summary>
        public string SKU
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceProductByStockKeepingUnitQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceProductByStockKeepingUnitQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceProductByStockKeepingUnitQuery"/> class with the specified SKU.
        /// </summary>
        /// <param name="sku"><see cref="SalesforceProduct"/> sku to query by.</param>
        public GetSalesforceProductByStockKeepingUnitQuery(string sku)
            : this()
        {
            SKU = sku;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(SKU), SKU) });
        }
    }
}
