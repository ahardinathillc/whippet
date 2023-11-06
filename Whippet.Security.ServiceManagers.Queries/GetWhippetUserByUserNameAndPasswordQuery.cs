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
    public class GetWhippetUserByUserNameAndPasswordQuery : GetWhippetUserByUserNameQuery
    {
        /// <summary>
        /// Gets or sets the password. This value may or may not be encrypted.
        /// </summary>
        public string Password
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserByUserNameAndPasswordQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetUserByUserNameAndPasswordQuery()
            : this(String.Empty, String.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserByUserNameAndPasswordQuery"/> class with the specified username and password.
        /// </summary>
        /// <param name="username">Username to query.</param>
        /// <param name="password">Password to query.</param>
        public GetWhippetUserByUserNameAndPasswordQuery(string username, string password)
            : base(username)
        {
            Password = password;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>(base.GetQueryParametersAndValues());

            parameters.Add(nameof(Password), Password);

            return parameters;
        }
    }
}
