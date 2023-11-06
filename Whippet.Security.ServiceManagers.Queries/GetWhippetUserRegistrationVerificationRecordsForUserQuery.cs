using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for a particular tenant.
    /// </summary>
    public class GetWhippetUserRegistrationVerificationRecordsForUserQuery : WhippetQuery<WhippetUserRegistrationVerificationRecord>, IWhippetQuery<WhippetUserRegistrationVerificationRecord>
    {
        /// <summary>
        /// ID of the <see cref="IWhippetUser"/> to filter by or <see langword="null"/> to list all records that have not yet been activated.
        /// </summary>
        public Guid? UserId
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserRegistrationVerificationRecordsForUserQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetUserRegistrationVerificationRecordsForUserQuery()
            : this((Guid?)(null))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserRegistrationVerificationRecordsForUserQuery"/> class with the specified user ID.
        /// </summary>
        /// <param name="userId">ID of the <see cref="IWhippetUser"/> to filter by or <see langword="null"/> to list all records that have not yet been activated.</param>
        public GetWhippetUserRegistrationVerificationRecordsForUserQuery(Guid? userId)
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
