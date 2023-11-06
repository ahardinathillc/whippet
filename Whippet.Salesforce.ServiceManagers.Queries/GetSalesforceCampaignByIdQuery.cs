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
    /// Represents a query that retrieves all <see cref="SalesforceCampaign"/> objects based on a specific name.
    /// </summary>
    public class GetSalesforceCampaignByIdQuery : WhippetQuery<SalesforceCampaign>, IWhippetQuery<SalesforceCampaign>
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="SalesforceCampaign"/> to query by.
        /// </summary>
        public string ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceCampaignByIdQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceCampaignByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceCampaignByIdQuery"/> class with the specified campaign ID.
        /// </summary>
        /// <param name="id"><see cref="SalesforceCampaign"/> ID to query by.</param>
        public GetSalesforceCampaignByIdQuery(string id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ID), ID) });
        }
    }
}
