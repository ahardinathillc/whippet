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
    public class GetSalesforceCampaignByNameQuery : WhippetQuery<SalesforceCampaign>, IWhippetQuery<SalesforceCampaign>
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="SalesforceCampaign"/> to query by.
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceCampaignByNameQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceCampaignByNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceCampaignByNameQuery"/> class with the specified campaign name.
        /// </summary>
        /// <param name="name"><see cref="SalesforceCampaign"/> name to query by.</param>
        public GetSalesforceCampaignByNameQuery(string name)
            : this()
        {
            Name = name;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Name), Name) });
        }
    }
}
