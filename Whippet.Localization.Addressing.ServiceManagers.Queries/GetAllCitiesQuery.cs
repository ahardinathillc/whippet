using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves all <see cref="City"/> objects in the system. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllCitiesQuery : WhippetQuery<City>, IWhippetQuery<City>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCitiesQuery"/> class with no arguments.
        /// </summary>
        public GetAllCitiesQuery()
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
