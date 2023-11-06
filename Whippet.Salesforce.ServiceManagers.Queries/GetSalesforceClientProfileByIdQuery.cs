using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Salesforce.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="SalesforceClientProfile"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetSalesforceClientProfileByIdQuery : WhippetQuery<SalesforceClientProfile>, IWhippetQuery<SalesforceClientProfile>
    {
        /// <summary>
        /// Gets or sets the ID to filter by.
        /// </summary>
        public Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceClientProfileByIdQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforceClientProfileByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceClientProfileByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID to filter by.</param>
        public GetSalesforceClientProfileByIdQuery(Guid id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ID), ID) });
        }
    }
}
