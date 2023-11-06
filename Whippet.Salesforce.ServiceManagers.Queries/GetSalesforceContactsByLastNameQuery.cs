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
    /// Represents a query that retrieves all <see cref="SalesforceContact"/> objects based on a specific name.
    /// </summary>
    public class GetSalesforceContactsByLastNameQuery : GetAllSalesforceContactsForAccountQuery, IWhippetQuery<SalesforceContact>
    {
        /// <summary>
        /// Gets or sets the last name to filter by.
        /// </summary>
        public string LastName
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceContactsByLastNameQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceContactsByLastNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceContactsByLastNameQuery"/> class with the specified <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        /// <param name="lastName">Last name to filter results by.</param>
        public GetSalesforceContactsByLastNameQuery(ISalesforceAccount account, string lastName)
            : base(account)
        {
            LastName = lastName;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> pv = new Dictionary<string, object>(base.GetQueryParametersAndValues());
            pv.Add(nameof(LastName), LastName);

            return pv;
        }
    }
}
