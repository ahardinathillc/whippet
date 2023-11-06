using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="PostalCode"/> object by its name. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllPostalCodesForCityQuery : WhippetQuery<PostalCode>, IWhippetQuery<PostalCode>
    {
        /// <summary>
        /// Gets the <see cref="ICity"/> to filter by. This property is read-only.
        /// </summary>
        public ICity City
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPostalCodesForCityQuery"/> class with no arguments.
        /// </summary>
        private GetAllPostalCodesForCityQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPostalCodesForCityQuery"/> class with the <see cref="ICity"/>.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> to filter by.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetAllPostalCodesForCityQuery(ICity city)
            : this()
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }
            else
            {
                City = city;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(City), City) });
        }
    }
}
