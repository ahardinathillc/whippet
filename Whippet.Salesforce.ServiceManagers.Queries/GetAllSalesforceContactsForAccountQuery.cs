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
    public class GetAllSalesforceContactsForAccountQuery : WhippetQuery<SalesforceContact>, IWhippetQuery<SalesforceContact>
    {
        /// <summary>
        /// Specifies the <see cref="ISalesforceAccount"/> for which to get all <see cref="SalesforceContact"/> objects for.
        /// </summary>
        public ISalesforceAccount Account
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesforceContactsForAccountQuery"/> class with no arguments.
        /// </summary>
        public GetAllSalesforceContactsForAccountQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesforceContactsForAccountQuery"/> class with the specified <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        public GetAllSalesforceContactsForAccountQuery(ISalesforceAccount account)
            : this()
        {
            Account = account;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Account), Account) });
        }
    }
}
