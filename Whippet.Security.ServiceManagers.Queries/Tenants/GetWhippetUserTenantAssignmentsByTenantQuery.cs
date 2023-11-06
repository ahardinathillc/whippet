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
    /// Query that retrieves all <see cref="WhippetUserTenantAssignment"/> objects in the system for a specific <see cref="IWhippetTenant"/>.
    /// </summary>
    public class GetWhippetUserTenantAssignmentsByTenantQuery : WhippetQuery<WhippetUserTenantAssignment>, IWhippetQuery<WhippetUserTenantAssignment>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> to retrieve the <see cref="WhippetUserTenantAssignment"/> objects for.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserTenantAssignmentsByTenantQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetUserTenantAssignmentsByTenantQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserTenantAssignmentsByTenantQuery"/> class with no arguments.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        public GetWhippetUserTenantAssignmentsByTenantQuery(IWhippetTenant tenant)
            : this()
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
