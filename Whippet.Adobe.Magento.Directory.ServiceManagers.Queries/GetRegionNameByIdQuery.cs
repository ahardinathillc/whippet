using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="RegionName"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public class GetRegionNameByIdQuery : WhippetQuery<RegionName>, IWhippetQuery<RegionName>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public RegionNameKey ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRegionNameByIdQuery"/> class with no arguments.
        /// </summary>
        private GetRegionNameByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRegionNameByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="regionId">ID of the <see cref="RegionName"/> object to retrieve.</param>
        public GetRegionNameByIdQuery(RegionNameKey regionId)
            : this()
        {
            ID = regionId;
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
