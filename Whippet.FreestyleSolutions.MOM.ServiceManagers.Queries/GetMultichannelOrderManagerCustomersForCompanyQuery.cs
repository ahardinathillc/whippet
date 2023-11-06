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
    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerCustomer"/> object in the data store for a specific company. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerCustomersForCompanyQuery : WhippetQuery<MultichannelOrderManagerCustomer>, IWhippetQuery<MultichannelOrderManagerCustomer>
    {
        /// <summary>
        /// Gets or sets the company name to filter by.
        /// </summary>
        public string CompanyName
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomersForCompanyQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerCustomersForCompanyQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomersForCompanyQuery"/> class with the specified company name.
        /// </summary>
        /// <param name="companyName">Company name to filter results by.</param>
        public GetMultichannelOrderManagerCustomersForCompanyQuery(string companyName)
            : this()
        {
            CompanyName = companyName;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(CompanyName), CompanyName) });
        }
    }
}
