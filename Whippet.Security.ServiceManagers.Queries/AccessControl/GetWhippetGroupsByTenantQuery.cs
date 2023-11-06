using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="WhippetGroup"/> by its tenant. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetGroupsByTenantQuery : WhippetQuery<WhippetGroup>, IWhippetQuery<WhippetGroup>
    {
        private IWhippetTenant _tenant;

        /// <summary>
        /// Gets or sets the tenant to query by. If <see langword="null"/>, <see cref="WhippetTenant.Root"/>
        /// </summary>
        public IWhippetTenant Tenant
        {
            get
            {
                if (_tenant == null)
                {
                    _tenant = WhippetTenant.Root;
                }

                return _tenant;
            }
            set
            {
                _tenant = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetGroupsByTenantQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetGroupsByTenantQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetGroupsByTenantQuery"/> class with the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant">Tenant that the groups are registered with. If <see langword="null"/>, <see cref="WhippetTenant.Root"/> will be used.</param>
        public GetWhippetGroupsByTenantQuery(IWhippetTenant tenant)
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

