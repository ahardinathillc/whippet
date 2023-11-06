using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="StoreWebsite"/> objects in the system. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllStoreWebsitesQuery : WhippetQuery<StoreWebsite>, IWhippetQuery<StoreWebsite>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllStoreWebsitesQuery"/> class with no arguments.
        /// </summary>
        public GetAllStoreWebsitesQuery()
            : base()
        { }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return NoParameters;
        }
    }
}
