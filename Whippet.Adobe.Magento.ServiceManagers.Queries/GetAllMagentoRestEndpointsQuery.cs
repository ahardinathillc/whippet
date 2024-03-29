﻿using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="MagentoRestEndpoint"/> objects in the system. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllMagentoRestEndpointsQuery : WhippetQuery<MagentoRestEndpoint>, IWhippetQuery<MagentoRestEndpoint>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMagentoRestEndpointsQuery"/> class with no arguments.
        /// </summary>
        public GetAllMagentoRestEndpointsQuery()
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
