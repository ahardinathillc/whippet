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
    /// Represents a query that retrieves a <see cref="SalesforceClientProfile"/> object by its name for a specific <see cref="IWhippetTenant"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetSalesforceClientProfileByNameQuery : GetAllSalesforceClientProfilesForTenantQuery, IWhippetQuery<SalesforceClientProfile>
    {
        /// <summary>
        /// Specifies the name of the <see cref="SalesforceClientProfile"/> to retrieve.
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceClientProfileByNameQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceClientProfileByNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceClientProfileByNameQuery"/> class with the specified <see cref="IWhippetTenant"/> and name.
        /// </summary>
        /// <param name="profileName">Profile name to filter by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        public GetSalesforceClientProfileByNameQuery(string profileName, IWhippetTenant tenant)
            : base(tenant)
        {
            Name = profileName;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>(base.GetQueryParametersAndValues());

            parameters.Add(nameof(Name), Name);

            return parameters;
        }
    }
}
