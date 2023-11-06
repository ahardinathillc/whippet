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
    /// Query that retrieves a <see cref="WhippetUserRegistrationVerificationRecord"/> object based on a given ID.
    /// </summary>
    public class GetWhippetUserRegistrationVerificationRecordByIdQuery : WhippetQuery<WhippetUserRegistrationVerificationRecord>, IWhippetQuery<WhippetUserRegistrationVerificationRecord>
    {
        /// <summary>
        /// ID to filter by.
        /// </summary>
        public Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserRegistrationVerificationRecordByIdQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetUserRegistrationVerificationRecordByIdQuery()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserRegistrationVerificationRecordByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID to filter by.</param>
        public GetWhippetUserRegistrationVerificationRecordByIdQuery(Guid id)
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
