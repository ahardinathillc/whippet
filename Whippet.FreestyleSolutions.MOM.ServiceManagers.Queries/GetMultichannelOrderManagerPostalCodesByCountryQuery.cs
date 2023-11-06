using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="GetMultichannelOrderManagerPostalCodesByCountryQuery"/> objects in the system that belong to a specific <see cref="MultichannelOrderManagerCountry"/>. This class cannot be inherited.
    /// </summary>
    public class GetMultichannelOrderManagerPostalCodesByCountryQuery : WhippetQuery<MultichannelOrderManagerPostalCode>, IWhippetQuery<MultichannelOrderManagerPostalCode>
    {
        /// <summary>
        /// Gets or sets the state/province to filter by.
        /// </summary>
        public IMultichannelOrderManagerCountry Country
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerPostalCodesByCountryQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerPostalCodesByCountryQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerPostalCodesByCountryQuery"/> class with the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> object.</param>
        public GetMultichannelOrderManagerPostalCodesByCountryQuery(IMultichannelOrderManagerCountry country)
            : this()
        {
            Country = country;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Country), Country) });
        }
    }
}
