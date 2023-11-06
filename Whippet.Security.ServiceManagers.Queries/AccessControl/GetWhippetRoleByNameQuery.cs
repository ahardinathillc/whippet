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
    /// Query that retrieves a <see cref="WhippetRole"/> by its name and tenant. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetRoleByNameQuery : WhippetQuery<WhippetRole>, IWhippetQuery<WhippetRole>
    {
        private IWhippetTenant _tenant;

        /// <summary>
        /// Gets or sets the role name to query by.
        /// </summary>
        public string Name
        { get; set; }

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
        /// Initializes a new instance of the <see cref="GetWhippetRoleByNameQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetRoleByNameQuery()
            : this(String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetRoleByNameQuery"/> class with the specified role name and <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="name">Name of the role to search for.</param>
        /// <param name="tenant">Tenant that the role is registered with. If <see langword="null"/>, <see cref="WhippetTenant.Root"/> will be used.</param>
        public GetWhippetRoleByNameQuery(string name, IWhippetTenant tenant = null)
            : base()
        {
            Name = name;
            Tenant = tenant;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Name), Name);
            parameters.Add(nameof(Tenant), Tenant);

            return parameters;
        }
    }
}

