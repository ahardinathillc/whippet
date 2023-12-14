using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="LegacyDigitalLibraryServer"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetLegacyDigitalLibraryServerByIdQuery : WhippetQuery<LegacyDigitalLibraryServer>, IWhippetQuery<LegacyDigitalLibraryServer>
    {
        private readonly Guid _ID;

        /// <summary>
        /// Gets the ID of the <see cref="LegacyDigitalLibraryServer"/> to retrieve. This property is read-only.
        /// </summary>
        public Guid ID
        {
            get
            {
                return _ID;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacyDigitalLibraryServerByIdQuery"/> class with no arguments.
        /// </summary>
        private GetLegacyDigitalLibraryServerByIdQuery()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacyDigitalLibraryServerByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID to filter by.</param>
        public GetLegacyDigitalLibraryServerByIdQuery(Guid id)
            : base()
        {
            _ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(ID), ID);

            return parameters;
        }
    }
}
