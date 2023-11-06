using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="Store"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public class GetStoreByIdQuery : WhippetQuery<Store>, IWhippetQuery<Store>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public uint ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStoreByIdQuery"/> class with no arguments.
        /// </summary>
        private GetStoreByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStoreByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="storeId">ID of the <see cref="Store"/> object to retrieve.</param>
        public GetStoreByIdQuery(uint storeId)
            : this()
        {
            ID = storeId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(ID), ID)
            });
        }
    }
}
