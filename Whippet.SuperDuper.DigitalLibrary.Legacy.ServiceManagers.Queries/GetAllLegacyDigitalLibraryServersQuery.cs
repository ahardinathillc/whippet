using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves all <see cref="LegacyDigitalLibraryServer"/> objects in the system. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllLegacyDigitalLibraryServersQuery : WhippetQuery<LegacyDigitalLibraryServer>, IWhippetQuery<LegacyDigitalLibraryServer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLegacyDigitalLibraryServersQuery"/> class with no arguments.
        /// </summary>
        public GetAllLegacyDigitalLibraryServersQuery()
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
