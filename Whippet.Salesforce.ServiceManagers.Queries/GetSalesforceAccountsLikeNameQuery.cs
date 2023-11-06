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
    /// Represents a query that retrieves all <see cref="SalesforceAccount"/> objects that contain a specific name or search pattern.
    /// </summary>
    public class GetSalesforceAccountLikeNameQuery : WhippetQuery<SalesforceAccount>, IWhippetQuery<SalesforceAccount>
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="SalesforceAccount"/> to query by.
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceAccountLikeNameQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceAccountLikeNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceAccountLikeNameQuery"/> class with the specified account name.
        /// </summary>
        /// <param name="name"><see cref="SalesforceAccount"/> name to query by.</param>
        public GetSalesforceAccountLikeNameQuery(string name)
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
