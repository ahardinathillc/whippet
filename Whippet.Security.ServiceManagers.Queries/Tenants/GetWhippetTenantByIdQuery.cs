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
    /// Query that retrieves a <see cref="WhippetTenant"/> object based on a given ID.
    /// </summary>
    public class GetWhippetTenantByIdQuery : WhippetQuery<WhippetTenant>, IWhippetQuery<WhippetTenant>
    {
        /// <summary>
        /// Gets or sets the ID to filter the <see cref="WhippetTenant"/> by.
        /// </summary>
        public Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetTenantByIdQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetTenantByIdQuery()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetTenantByIdQuery"/> class with the specified username.
        /// </summary>
        /// <param name="id">ID to filter the <see cref="WhippetTenant"/> by.</param>
        public GetWhippetTenantByIdQuery(Guid id)
            : base()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(ID), ID);

            return parameters;
        }
    }
}
