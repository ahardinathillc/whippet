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
    /// Represents a query that retrieves all <see cref="SalesforceLead"/> objects based on a specific name.
    /// </summary>
    public class GetSalesforceLeadByNameQuery : WhippetQuery<SalesforceLead>, IWhippetQuery<SalesforceLead>
    {
        /// <summary>
        /// Gets or sets the first name to filter by.
        /// </summary>
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the last name to filter by.
        /// </summary>
        public string LastName
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceLeadByNameQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceLeadByNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceLeadByNameQuery"/> class with the specified first ane last name.
        /// </summary>
        /// <param name="firstName">First name to filter results by.</param>
        /// <param name="lastName">Last name to filter results by.</param>
        public GetSalesforceLeadByNameQuery(string firstName, string lastName)
            : base()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>(nameof(FirstName), FirstName),
                new KeyValuePair<string, object>(nameof(LastName), LastName)
            });
        }
    }
}
