using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="WhippetUser"/> by their username and password, irrespective of account activation status or tenant.
    /// </summary>
    public class GetWhippetUserByUserNameQuery : WhippetQuery<WhippetUser>, IWhippetQuery<WhippetUser>
    {
        /// <summary>
        /// Gets or sets the username to query by.
        /// </summary>
        public string Username
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserByUserNameQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetUserByUserNameQuery()
            : this(String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserByUserNameQuery"/> class with the specified username.
        /// </summary>
        /// <param name="username">Username to query.</param>
        public GetWhippetUserByUserNameQuery(string username)
            : base()
        {
            Username = username;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Username), Username);

            return parameters;
        }
    }
}
