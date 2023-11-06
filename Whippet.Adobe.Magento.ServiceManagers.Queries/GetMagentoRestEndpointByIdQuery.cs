using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="MagentoRestEndpoint"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMagentoRestEndpointByIdQuery : WhippetQuery<MagentoRestEndpoint>, IWhippetQuery<MagentoRestEndpoint>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoRestEndpointByIdQuery"/> class with no arguments.
        /// </summary>
        private GetMagentoRestEndpointByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoRestEndpointByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="MagentoRestEndpoint"/> object to retrieve.</param>
        public GetMagentoRestEndpointByIdQuery(Guid id)
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
