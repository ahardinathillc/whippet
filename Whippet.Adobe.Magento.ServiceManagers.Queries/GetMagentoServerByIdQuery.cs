using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="MagentoServer"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMagentoServerByIdQuery : WhippetQuery<MagentoServer>, IWhippetQuery<MagentoServer>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public Guid ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoServerByIdQuery"/> class with no arguments.
        /// </summary>
        private GetMagentoServerByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoServerByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="MagentoServer"/> object to retrieve.</param>
        public GetMagentoServerByIdQuery(Guid id)
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
