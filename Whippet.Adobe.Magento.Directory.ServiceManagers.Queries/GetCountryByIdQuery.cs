using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="Country"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public class GetCountryByIdQuery : WhippetQuery<Country>, IWhippetQuery<Country>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public WhippetNonNullableString ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCountryByIdQuery"/> class with no arguments.
        /// </summary>
        private GetCountryByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCountryByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="countryId">ID of the <see cref="Country"/> object to retrieve.</param>
        public GetCountryByIdQuery(WhippetNonNullableString countryId)
            : this()
        {
            ID = countryId;
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
