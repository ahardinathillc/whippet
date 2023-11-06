using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="StateProvince"/> object by its <see cref="StateProvince.Name"/> value and parent <see cref="ICountry"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetStateProvinceByNameQuery : GetAllStateProvincesForCountryQuery, IWhippetQuery<StateProvince>
    {
        /// <summary>
        /// Gets the <see cref="StateProvince.Name"/> value to filter by. This property is read-only.
        /// </summary>
        public string Name
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStateProvinceByNameQuery"/> with no arguments.
        /// </summary>
        private GetStateProvinceByNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllStateProvincesForCountryQuery"/> class with the specified name and <see cref="ICountry"/>.
        /// </summary>
        /// <param name="name">Name of the <see cref="StateProvince"/> to retrieve.</param>
        /// <param name="country"><see cref="ICountry"/> to filter by.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetStateProvinceByNameQuery(string name, ICountry country)
            : base(country)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                Name = name;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>(base.GetQueryParametersAndValues());

            parameters.Add(nameof(Name), Name);

            return parameters;
        }
    }
}
