using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects in the data store that are companies. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerCustomerCompaniesOnlyQuery : WhippetQuery<MultichannelOrderManagerCustomer>, IWhippetQuery<MultichannelOrderManagerCustomer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomerCompaniesOnlyQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerCustomerCompaniesOnlyQuery()
            : base()
        { }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>();
        }
    }
}
