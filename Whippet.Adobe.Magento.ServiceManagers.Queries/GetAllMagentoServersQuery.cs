using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="MagentoServer"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllMagentoServersQuery : WhippetQuery<MagentoServer>, IWhippetQuery<MagentoServer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMagentoServersQuery"/> class with no arguments.
        /// </summary>
        public GetAllMagentoServersQuery()
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
