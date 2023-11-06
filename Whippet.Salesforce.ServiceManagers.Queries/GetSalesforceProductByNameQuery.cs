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
    /// Represents a query that retrieves all <see cref="SalesforceProduct"/> objects based on a specific name.
    /// </summary>
    public class GetSalesforceProductByNameQuery : WhippetQuery<SalesforceProduct>, IWhippetQuery<SalesforceProduct>
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="SalesforceProduct"/> to query by.
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceProductByNameQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceProductByNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceProductByNameQuery"/> class with the specified opportunity name.
        /// </summary>
        /// <param name="name"><see cref="SalesforceProduct"/> name to query by.</param>
        public GetSalesforceProductByNameQuery(string name)
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
