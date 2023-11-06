using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="WhippetIpAddressBlacklist"/> entry that matches an IP address and an optional <see cref="IWhippetTenant"/>.
    /// </summary>
    public class GetWhippetIpAddressBlacklistQuery : WhippetQuery<WhippetIpAddressBlacklist>, IWhippetQuery<WhippetIpAddressBlacklist>
    {
        /// <summary>
        /// Gets or sets the IP address to query by.
        /// </summary>
        public string IPAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> to query by, if any.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetIpAddressBlacklistQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetIpAddressBlacklistQuery()
            : this(null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetIpAddressBlacklistQuery"/> class with the specified IP address and optional tenant.
        /// </summary>
        /// <param name="ipAddress">IP address to search for.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by (if any).</param>
        public GetWhippetIpAddressBlacklistQuery(string ipAddress, IWhippetTenant tenant)
            : base()
        {
            IPAddress = ipAddress;
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            
            parameters.Add(nameof(IPAddress), IPAddress);
            parameters.Add(nameof(Tenant), Tenant);

            return parameters;
        }
    }
}
