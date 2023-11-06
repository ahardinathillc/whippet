using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="InvariantAddress"/> objects in the system filtered by <see cref="ICity"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetInvariantAddressesForCityQuery : WhippetQuery<InvariantAddress>, IWhippetQuery<InvariantAddress>
    {
        /// <summary>
        /// Gets the <see cref="ICity"/> to filter by. This property is read-only.
        /// </summary>
        public ICity City
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvariantAddressesForCityQuery"/> class with no arguments.
        /// </summary>
        private GetInvariantAddressesForCityQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvariantAddressesForCityQuery"/> class with the specified <see cref="ICity"/>.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> to filter by.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetInvariantAddressesForCityQuery(ICity city)
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
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(City), City);

            return parameters;
        }
    }
}
