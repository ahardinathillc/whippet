using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves the total number of <see cref="WhippetUser"/> objects in the system. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetUserCountQuery : WhippetQuery<WhippetUser>, IWhippetQuery<WhippetUser>
    {
        /// <summary>
        /// Specifies whether the query should include active users.
        /// </summary>
        public bool Active
        { get; set; }

        /// <summary>
        /// Specifies whether the query should include deleted users.
        /// </summary>
        public bool Deleted
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserCountQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetUserCountQuery()
            : this(true, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserCountQuery"/> class with the specified user ID.
        /// </summary>
        /// <param name="userId"><see cref="WhippetEntity.ID"/> to filter by.</param>
        public GetWhippetUserCountQuery(bool active, bool deleted)
            : base()
        {
            Active = active;
            Deleted = deleted;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Active), Active);
            parameters.Add(nameof(Deleted), Deleted);

            return parameters;
        }
    }
}
