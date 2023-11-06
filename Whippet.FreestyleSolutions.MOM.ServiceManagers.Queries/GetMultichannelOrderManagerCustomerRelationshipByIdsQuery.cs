using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Returns multiple <see cref="IMultichannelOrderManagerCustomerRelationship"/> objects based on a range of <see cref="IMultichannelOrderManagerCustomerRelationship.CustomerRelationshipId"/> values.
    /// </summary>
    public class GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery : WhippetQuery<MultichannelOrderManagerCustomerRelationship>, IWhippetQuery<MultichannelOrderManagerCustomerRelationship>
    {
        /// <summary>
        /// Gets or sets the collection of IDs to query by.
        /// </summary>
        public IEnumerable<long> IDs
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery"/> class with the specified collection of <see cref="IMultichannelOrderManagerCustomerRelationship.CustomerRelationshipId"/> values.
        /// </summary>
        /// <param name="ids"><see cref="IMultichannelOrderManagerCustomerRelationship.CustomerRelationshipId"/> values to filter by.</param>
        public GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery(IEnumerable<long> ids)
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
