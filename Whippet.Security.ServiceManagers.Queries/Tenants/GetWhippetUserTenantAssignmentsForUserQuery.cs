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
    /// Query that retrieves all <see cref="WhippetUserTenantAssignment"/> objects in the system for a specific <see cref="IWhippetUser"/>.
    /// </summary>
    public class GetWhippetUserTenantAssignmentsForUserQuery : WhippetQuery<WhippetUserTenantAssignment>, IWhippetQuery<WhippetUserTenantAssignment>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetUser"/> to retrieve the <see cref="WhippetUserTenantAssignment"/> objects for.
        /// </summary>
        public IWhippetUser User
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserTenantAssignmentsForUserQuery"/> class with no arguments.
        /// </summary>
        private GetWhippetUserTenantAssignmentsForUserQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserTenantAssignmentsForUserQuery"/> class with no arguments.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to filter by.</param>
        public GetWhippetUserTenantAssignmentsForUserQuery(IWhippetUser user)
            : this()
        {
            User = user;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(User), User);

            return parameters;
        }
    }
}
