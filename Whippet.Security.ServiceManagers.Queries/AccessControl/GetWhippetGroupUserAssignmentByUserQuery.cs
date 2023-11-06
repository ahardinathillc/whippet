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
    /// Query that retrieves a <see cref="WhippetGroupUserAssignment"/> by the associated <see cref="WhippetUser"/> ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetGroupUserAssignmentByUserQuery : WhippetQuery<WhippetGroupUserAssignment>, IWhippetQuery<WhippetGroupUserAssignment>
    {
        /// <summary>
        /// Gets or sets the <see cref="IWhippetUser"/> to filter by.
        /// </summary>
        public IWhippetUser User
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetGroupUserAssignmentByUserQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetGroupUserAssignmentByUserQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetGroupByIdQuery"/> class with the specified user.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to filter by.</param>
        public GetWhippetGroupUserAssignmentByUserQuery(IWhippetUser user)
            : base()
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

