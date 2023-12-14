using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves all <see cref="LegacyDigitalLibraryServer"/> objects for a specific <see cref="IWhippetTenant"/> object. This class cannot be inherited.
    /// </summary>
    public sealed class GetLegacyDigitalLibraryServersForTenantQuery : WhippetQuery<LegacyDigitalLibraryServer>, IWhippetQuery<LegacyDigitalLibraryServer>
    {
        private readonly IWhippetTenant _Tenant;

        /// <summary>
        /// Gets the <see cref="IWhippetTenant"/> to retrieve all <see cref="LegacyDigitalLibraryServer"/> objects for. This property is read-only.
        /// </summary>
        public IWhippetTenant Tenant
        {
            get
            {
                return _Tenant;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacyDigitalLibraryServersForTenantQuery"/> class with no arguments. This will use the default root tenant as its filter.
        /// </summary>
        public GetLegacyDigitalLibraryServersForTenantQuery()
            : this(WhippetTenant.Root)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacyDigitalLibraryServersForTenantQuery"/> class with the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="LegacyDigitalLibraryServer"/> objects for.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetLegacyDigitalLibraryServersForTenantQuery(IWhippetTenant tenant)
            : base()
        {
            _Tenant = tenant;
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
