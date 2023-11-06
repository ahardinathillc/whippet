using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="StateProvince"/> objects in the system filtered by <see cref="ICountry"/>.
    /// </summary>
    public class GetAllStateProvincesForCountryQuery : WhippetQuery<StateProvince>, IWhippetQuery<StateProvince>
    {
        /// <summary>
        /// Gets the <see cref="ICountry"/> to filter by. This property is read-only.
        /// </summary>
        public virtual ICountry Country
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllStateProvincesForCountryQuery"/> class with no arguments.
        /// </summary>
        protected GetAllStateProvincesForCountryQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllStateProvincesForCountryQuery"/> class with the specified <see cref="ICountry"/>.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> to filter by.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetAllStateProvincesForCountryQuery(ICountry country)
            : this()
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                Country = country;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add(nameof(Country), Country);

            return parameters;
        }
    }
}
