using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="WhippetSmtpServerProfile"/> objects for a particular tenant. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetSmtpServerProfilesForTenantQuery : WhippetQuery<WhippetSmtpServerProfile>, IWhippetQuery<WhippetSmtpServerProfile>
    {
        /// <summary>
        /// Gets or sets the tenant to retrieve the default <see cref="WhippetSmtpServerProfile"/> object for.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSmtpServerProfilesForTenantQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetSmtpServerProfilesForTenantQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSmtpServerProfilesForTenantQuery"/> class with the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        public GetWhippetSmtpServerProfilesForTenantQuery(IWhippetTenant tenant)
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
