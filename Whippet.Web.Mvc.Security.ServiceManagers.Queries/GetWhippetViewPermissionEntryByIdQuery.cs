using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="WhippetViewPermissionEntry"/> based on its ID.
    /// </summary>
    public class GetWhippetViewPermissionEntryByIdQuery : WhippetQuery<WhippetViewPermissionEntry>, IWhippetQuery<WhippetViewPermissionEntry>
    {
        /// <summary>
        /// ID to filter by.
        /// </summary>
        public Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetViewPermissionEntryByIdQuery"/> class with no arguments.
        /// </summary>
        public GetWhippetViewPermissionEntryByIdQuery()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetViewPermissionEntryByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID to filter by.</param>
        public GetWhippetViewPermissionEntryByIdQuery(Guid id)
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
