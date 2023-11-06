using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.Tenants.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves all <see cref="WhippetTenant"/> objects in the system.
    /// </summary>
    public class GetWhippetTenantsQuery : WhippetQuery<WhippetTenant>, IWhippetQuery<WhippetTenant>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetTenantsQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetTenantsQuery()
            : base()
        { }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            return parameters;
        }
    }
}
