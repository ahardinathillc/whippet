using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="MultichannelOrderManagerServer"/> object by its name. This class cannot be inherited.
    /// </summary>
    public class GetMultichannelOrderManagerServerByNameQuery : WhippetQuery<MultichannelOrderManagerServer>, IWhippetQuery<MultichannelOrderManagerServer>
    {
        /// <summary>
        /// Gets or sets the name to query by.
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> that the <see cref="MultichannelOrderManagerServer"/> is registered with.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerServerByNameQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerServerByNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerServerByNameQuery"/> class with the specified name and tenant.
        /// </summary>
        /// <param name="name">Server name to query by.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the server is registered with.</param>
        public GetMultichannelOrderManagerServerByNameQuery(string name, IWhippetTenant tenant)
            : this()
        {
            Name = name;
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(Name), Name),
                new KeyValuePair<string, object>(nameof(Tenant), Tenant)
            });
        }
    }
}
