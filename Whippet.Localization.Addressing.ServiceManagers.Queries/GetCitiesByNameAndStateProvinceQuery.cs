using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="City"/> object by its name. This class cannot be inherited.
    /// </summary>
    public sealed class GetCitiesByNameAndStateProvinceQuery : GetCitiesByNameQuery, IWhippetQuery<City>
    {
        /// <summary>
        /// Gets the <see cref="IStateProvince"/> to filter by. This property is read-only.
        /// </summary>
        public IStateProvince StateProvince
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCitiesByNameAndStateProvinceQuery"/> class with no arguments.
        /// </summary>
        private GetCitiesByNameAndStateProvinceQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCitiesByNameAndStateProvinceQuery"/> class with the specified name and <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="name"><see cref="City.Name"/> value to search for.</param>
        /// <param name="stateProvince"><see cref="IStateProvince"/> to filter by.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetCitiesByNameAndStateProvinceQuery(string name, IStateProvince stateProvince)
            : base(name)
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
            Dictionary<string, object> parameters = new Dictionary<string, object>(base.GetQueryParametersAndValues());
            parameters.Add(nameof(StateProvince), StateProvince);

            return parameters;
        }
    }
}
