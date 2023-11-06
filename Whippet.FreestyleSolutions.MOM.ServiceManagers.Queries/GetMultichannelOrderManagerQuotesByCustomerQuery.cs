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
    /// Represents a query that retrieves <see cref="MultichannelOrderManagerOrder"/> objects based on a specific <see cref="MultichannelOrderManagerCustomer"/>.
    /// </summary>
    public class GetMultichannelOrderManagerQuotesByCustomerQuery : WhippetQuery<MultichannelOrderManagerOrder>, IWhippetQuery<MultichannelOrderManagerOrder>
    {
        /// <summary>
        /// Gets or sets the <see cref="MultichannelOrderManagerCustomer"/> to filter by.
        /// </summary>
        public MultichannelOrderManagerCustomer Customer
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerQuotesByCustomerQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerQuotesByCustomerQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerQuotesByCustomerQuery"/> class with the specified <see cref="MultichannelOrderManagerCustomer"/>.
        /// </summary>
        /// <param name="customer"><see cref="MultichannelOrderManagerCustomer"/> to filter by.</param>
        public GetMultichannelOrderManagerQuotesByCustomerQuery(MultichannelOrderManagerCustomer customer)
            : this()
        {
            Customer = customer;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(Customer), Customer),
            });
        }
    }
}
