using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="StoreGroup"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public class GetStoreGroupByIdQuery : WhippetQuery<StoreGroup>, IWhippetQuery<StoreGroup>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public uint GroupID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStoreGroupByIdQuery"/> class with no arguments.
        /// </summary>
        private GetStoreGroupByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStoreGroupByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="groupId">ID of the <see cref="StoreGroup"/> object to retrieve.</param>
        public GetStoreGroupByIdQuery(uint groupId)
            : this()
        {
            GroupID = groupId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(GroupID), GroupID)
            });
        }
    }
}
