using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Returns multiple <see cref="IMultichannelOrderManagerCustomer"/> objects based on a range of <see cref="IMultichannelOrderManagerCustomer.CustomerId"/> values.
    /// </summary>
    public class GetMultichannelOrderManagerCustomersByIdsQuery : WhippetQuery<MultichannelOrderManagerCustomer>, IWhippetQuery<MultichannelOrderManagerCustomer>
    {
        /// <summary>
        /// Gets or sets the collection of IDs to query by.
        /// </summary>
        public IEnumerable<long> IDs
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomersByIdsQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerCustomersByIdsQuery()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomersByIdsQuery"/> class with the specified collection of <see cref="IMultichannelOrderManagerCustomer.CustomerId"/> values.
        /// </summary>
        /// <param name="ids"><see cref="IMultichannelOrderManagerCustomer.CustomerId"/> values to filter by.</param>
        public GetMultichannelOrderManagerCustomersByIdsQuery(IEnumerable<long> ids)
            : this()
        {
            IDs = ids;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(IDs), IDs) });
        }
    }
}
