using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="WhippetApplication"/> objects for a specified <see cref="IWhippetTenant"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetApplicationsByTenantQuery : WhippetQuery<WhippetApplication>, IWhippetQuery<WhippetApplication>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetTenant"/> to query by.
        /// </summary>
        public IWhippetTenant Tenant
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetApplicationsByTenantQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetApplicationsByTenantQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetApplicationsByTenantQuery"/> class with the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        public GetWhippetApplicationsByTenantQuery(IWhippetTenant tenant)
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
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Tenant), Tenant) });
        }
    }
}
