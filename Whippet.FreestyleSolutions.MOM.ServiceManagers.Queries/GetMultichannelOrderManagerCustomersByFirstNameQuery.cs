using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerCustomer"/> object in the data store based on a customer's first name. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerCustomersByFirstNameQuery : WhippetQuery<MultichannelOrderManagerCustomer>, IWhippetQuery<MultichannelOrderManagerCustomer>
    {
        /// <summary>
        /// Gets or sets the first name to filter by.
        /// </summary>
        public string FirstName
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomersByFirstNameQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerCustomersByFirstNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomersByFirstNameQuery"/> class with the specified first name.
        /// </summary>
        /// <param name="firstName">First name to filter results by.</param>
        public GetMultichannelOrderManagerCustomersByFirstNameQuery(string firstName)
            : this()
        {
            FirstName = firstName;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(FirstName), FirstName) });
        }
    }
}
