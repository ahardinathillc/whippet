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
    /// Query that retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for a particular tenant.
    /// </summary>
    public class GetWhippetUserRegistrationVerificationRecordsForTenantQuery : WhippetQuery<WhippetUserRegistrationVerificationRecord>, IWhippetQuery<WhippetUserRegistrationVerificationRecord>
    {
        /// <summary>
        /// Tenant to filter by.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserRegistrationVerificationRecordsForTenantQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetUserRegistrationVerificationRecordsForTenantQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserRegistrationVerificationRecordsForTenantQuery"/> class with the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        public GetWhippetUserRegistrationVerificationRecordsForTenantQuery(IWhippetTenant tenant)
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
