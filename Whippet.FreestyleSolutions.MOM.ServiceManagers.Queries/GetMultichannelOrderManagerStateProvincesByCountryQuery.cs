using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="GetMultichannelOrderManagerStateProvincesByCountryQuery"/> objects in the system that belong to a specific <see cref="MultichannelOrderManagerCountry"/>. This class cannot be inherited.
    /// </summary>
    public class GetMultichannelOrderManagerStateProvincesByCountryQuery : WhippetQuery<MultichannelOrderManagerStateProvince>, IWhippetQuery<MultichannelOrderManagerStateProvince>
    {
        /// <summary>
        /// Gets or sets the state/province to filter by.
        /// </summary>
        public IMultichannelOrderManagerCountry Country
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerStateProvincesByCountryQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerStateProvincesByCountryQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerStateProvincesByCountryQuery"/> class with the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> object.</param>
        public GetMultichannelOrderManagerStateProvincesByCountryQuery(IMultichannelOrderManagerCountry country)
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
