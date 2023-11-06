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
    /// Represents a query that retrieves the total number of <see cref="MultichannelOrderManagerOrder"/> objects in the data store. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerOrderCountQuery : WhippetQuery<MultichannelOrderManagerOrder>, IWhippetQuery<MultichannelOrderManagerOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerOrderCountQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerOrderCountQuery()
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
