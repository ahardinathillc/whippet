using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="GetMultichannelOrderManagerPostalCodesByStateProvinceQuery"/> objects in the system that belong to a specific <see cref="MultichannelOrderManagerStateProvince"/>. This class cannot be inherited.
    /// </summary>
    public class GetMultichannelOrderManagerPostalCodesByStateProvinceQuery : WhippetQuery<MultichannelOrderManagerPostalCode>, IWhippetQuery<MultichannelOrderManagerPostalCode>
    {
        /// <summary>
        /// Gets or sets the state/province to filter by.
        /// </summary>
        public IMultichannelOrderManagerStateProvince StateProvince
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerPostalCodesByStateProvinceQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerPostalCodesByStateProvinceQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerPostalCodesByStateProvinceQuery"/> class with the specified <see cref="IMultichannelOrderManagerStateProvince"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> object.</param>
        public GetMultichannelOrderManagerPostalCodesByStateProvinceQuery(IMultichannelOrderManagerStateProvince stateProvince)
            : this()
        {
            StateProvince = stateProvince;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(StateProvince), StateProvince) });
        }
    }
}
