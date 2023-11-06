using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the default <see cref="WhippetSmtpServerProfile"/> for a particular tenant. This class cannot be inherited.
    /// </summary>
    public sealed class GetDefaultWhippetSmtpServerProfileQuery : WhippetQuery<WhippetSmtpServerProfile>, IWhippetQuery<WhippetSmtpServerProfile>
    {
        /// <summary>
        /// Gets or sets the tenant to retrieve the default <see cref="WhippetSmtpServerProfile"/> object for.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDefaultWhippetSmtpServerProfileQuery"/> class with no arguments.
        /// </summary>
        private GetDefaultWhippetSmtpServerProfileQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDefaultWhippetSmtpServerProfileQuery"/> class with the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        public GetDefaultWhippetSmtpServerProfileQuery(IWhippetTenant tenant)
            : this()
        {
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Tenant), Tenant) });
        }
    }
}
