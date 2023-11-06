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
    /// Query that retrieves a <see cref="WhippetUserTenantAssignment"/> object based on a given ID.
    /// </summary>
    public class GetWhippetUserTenantAssignmentByIdQuery : WhippetQuery<WhippetUserTenantAssignment>, IWhippetQuery<WhippetUserTenantAssignment>
    {
        /// <summary>
        /// Gets or sets the ID to filter the <see cref="WhippetUserTenantAssignment"/> by.
        /// </summary>
        public Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserTenantAssignmentByIdQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetUserTenantAssignmentByIdQuery()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserTenantAssignmentByIdQuery"/> class with the specified username.
        /// </summary>
        /// <param name="id">ID to filter the <see cref="WhippetUserTenantAssignment"/> by.</param>
        public GetWhippetUserTenantAssignmentByIdQuery(Guid id)
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
