using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="StateProvince"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetStateProvinceByIdQuery : WhippetQuery<StateProvince>, IWhippetQuery<StateProvince>
    {
        /// <summary>
        /// Gets the ID of the <see cref="StateProvince"/> to retrieve. This property is read-only.
        /// </summary>
        public Guid ID
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStateProvinceByIdQuery"/> class with no arguments.
        /// </summary>
        private GetStateProvinceByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStateProvinceByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="StateProvince"/> to retrieve.</param>
        public GetStateProvinceByIdQuery(Guid id)
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
