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
    /// Query that retrieves a <see cref="WhippetUser"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetWhippetUserByIdQuery : WhippetQuery<WhippetUser>, IWhippetQuery<WhippetUser>
    {
        /// <summary>
        /// Gets or sets the <see cref="WhippetEntity.ID"/> to filter by.
        /// </summary>
        public Guid UserId
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserByIdQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetUserByIdQuery()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserByIdQuery"/> class with the specified user ID.
        /// </summary>
        /// <param name="userId"><see cref="WhippetEntity.ID"/> to filter by.</param>
        public GetWhippetUserByIdQuery(Guid userId)
            : base()
        {
            UserId = userId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(UserId), UserId);

            return parameters;
        }
    }
}
