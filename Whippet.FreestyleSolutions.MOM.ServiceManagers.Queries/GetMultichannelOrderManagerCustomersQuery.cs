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
    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerCustomersQuery : WhippetQuery<MultichannelOrderManagerCustomer>, IWhippetQuery<MultichannelOrderManagerCustomer>
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
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomersQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerCustomersQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomersQuery"/> class with the specified first and last names.
        /// </summary>
        /// <param name="firstName">First name to filter by.</param>
        /// <param name="lastName">Last name to filter by.</param>
        public GetMultichannelOrderManagerCustomersQuery(string firstName, string lastName)
            : this()
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
            return new Dictionary<string, object>(
                new[]
                {
                    new KeyValuePair<string, object>(nameof(FirstName), FirstName),
                    new KeyValuePair<string, object>(nameof(LastName), LastName)
                });
        }
    }
}
