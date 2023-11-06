using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="WhippetRoleUserAssignment"/> by the associated <see cref="WhippetRole"/> ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetRoleUserAssignmentByRoleQuery : WhippetQuery<WhippetRoleUserAssignment>, IWhippetQuery<WhippetRoleUserAssignment>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetRole"/> to filter by.
        /// </summary>
        public IWhippetRole Role
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetRoleUserAssignmentByRoleQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetRoleUserAssignmentByRoleQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetRoleByIdQuery"/> class with the specified role.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRole"/> to filter by.</param>
        public GetWhippetRoleUserAssignmentByRoleQuery(IWhippetRole role)
            : base()
        {
            Role = role;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Role), Role);

            return parameters;
        }
    }
}

