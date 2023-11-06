using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves all <see cref="WhippetViewPermissionEntry"/> objects based on the specified <see cref="IWhippetTenant"/>.
    /// </summary>
    public class GetWhippetViewPermissionEntriesByTenantQuery : WhippetQuery<WhippetViewPermissionEntry>, IWhippetQuery<WhippetViewPermissionEntry>
    {
        /// <summary>
        /// Tenant to filter by.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetViewPermissionEntriesByTenantQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetViewPermissionEntriesByTenantQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetViewPermissionEntriesByTenantQuery"/> class with the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        public GetWhippetViewPermissionEntriesByTenantQuery(IWhippetTenant tenant)
            : base()
        {
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Tenant), Tenant);

            return parameters;
        }
    }
}
