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
    /// Represents a query that retrieves all <see cref="SalesforceProduct"/> objects based on a specific externalID.
    /// </summary>
    public class GetSalesforceProductByExternalIdQuery : WhippetQuery<SalesforceProduct>, IWhippetQuery<SalesforceProduct>
    {
        /// <summary>
        /// Gets or sets the externalID of the <see cref="SalesforceProduct"/> to query by.
        /// </summary>
        public string ExternalId
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceProductByExternalIdQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceProductByExternalIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceProductByExternalIdQuery"/> class with the specified opportunity externalID.
        /// </summary>
        /// <param externalID="externalID"><see cref="SalesforceProduct"/> externalID to query by.</param>
        public GetSalesforceProductByExternalIdQuery(string externalID)
            : this()
        {
            ExternalId = externalID;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ExternalId), ExternalId) });
        }
    }
}
