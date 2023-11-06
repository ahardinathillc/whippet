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
    /// Query that retrieves a <see cref="WhippetPasswordBlacklist"/> entry that matches an password and an optional <see cref="IWhippetTenant"/>.
    /// </summary>
    public class GetWhippetPasswordBlacklistQuery : WhippetQuery<WhippetPasswordBlacklist>, IWhippetQuery<WhippetPasswordBlacklist>
    {
        /// <summary>
        /// Gets or sets the password to query by.
        /// </summary>
        public string Password
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> to query by, if any.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetPasswordBlacklistQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetPasswordBlacklistQuery()
            : this(null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetPasswordBlacklistQuery"/> class with the specified password and optional tenant.
        /// </summary>
        /// <param name="ipAddress">Password to search for.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by (if any).</param>
        public GetWhippetPasswordBlacklistQuery(string ipAddress, IWhippetTenant tenant)
            : base()
        {
            Password = ipAddress;
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Password), Password);
            parameters.Add(nameof(Tenant), Tenant);

            return parameters;
        }
    }
}
