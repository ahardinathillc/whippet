using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="StoreWebsite"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public class GetStoreWebsiteByIdQuery : WhippetQuery<StoreWebsite>, IWhippetQuery<StoreWebsite>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public uint WebsiteID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStoreWebsiteByIdQuery"/> class with no arguments.
        /// </summary>
        private GetStoreWebsiteByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStoreWebsiteByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="websiteId">ID of the <see cref="StoreWebsite"/> object to retrieve.</param>
        public GetStoreWebsiteByIdQuery(uint websiteId)
            : this()
        {
            WebsiteID = websiteId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(WebsiteID), WebsiteID)
            });
        }
    }
}
