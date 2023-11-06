using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="Country"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetCountryByIdQuery : WhippetQuery<Country>, IWhippetQuery<Country>
    {
        /// <summary>
        /// Gets the ID of the <see cref="Country"/> to retrieve. This property is read-only.
        /// </summary>
        public Guid ID
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCountryByIdQuery"/> class with no arguments.
        /// </summary>
        private GetCountryByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCountryByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="Country"/> to retrieve.</param>
        public GetCountryByIdQuery(Guid id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ID), ID) });
        }
    }
}
