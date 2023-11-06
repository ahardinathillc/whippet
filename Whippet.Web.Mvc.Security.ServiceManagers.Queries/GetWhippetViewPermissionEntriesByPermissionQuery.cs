using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves all <see cref="WhippetViewPermissionEntry"/> objects based on the specified <see cref="WhippetMvcSecurityPermission"/>.
    /// </summary>
    public class GetWhippetViewPermissionEntriesByPermissionQuery : WhippetQuery<WhippetViewPermissionEntry>, IWhippetQuery<WhippetViewPermissionEntry>
    {
        /// <summary>
        /// Permission to filter by.
        /// </summary>
        public WhippetMvcSecurityPermission Permission
        { get; set; }

        /// <summary>
        /// Tenant to filter by.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetViewPermissionEntriesByPermissionQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetViewPermissionEntriesByPermissionQuery()
            : this(null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetViewPermissionEntriesByPermissionQuery"/> class with the specified permission and tenant.
        /// </summary>
        /// <param name="permission"><see cref="WhippetMvcSecurityPermission"/> object.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        public GetWhippetViewPermissionEntriesByPermissionQuery(WhippetMvcSecurityPermission permission, IWhippetTenant tenant)
            : base()
        {
            Permission = permission;
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Permission), Permission);
            parameters.Add(nameof(Tenant), Tenant);

            return parameters;
        }
    }
}
