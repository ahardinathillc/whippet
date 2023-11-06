using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="City"/> objects for a specified <see cref="IStateProvince"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetCitiesForStateProvinceQuery : WhippetQuery<City>, IWhippetQuery<City>
    {
        /// <summary>
        /// Gets the <see cref="IStateProvince"/> to retrieve the cities for. This property is read-only.
        /// </summary>
        public IStateProvince StateProvince
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCitiesForStateProvinceQuery" /> with no arguments.
        /// </summary>
        private GetCitiesForStateProvinceQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCitiesForStateProvinceQuery" /> with the specified <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IStateProvince"/> to get cities for.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetCitiesForStateProvinceQuery(IStateProvince stateProvince)
            : this()
        {
            if (stateProvince == null)
            {
                throw new ArgumentNullException(nameof(stateProvince));
            }
            else
            {
                StateProvince = stateProvince;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(StateProvince), StateProvince) });
        }
    }
}
