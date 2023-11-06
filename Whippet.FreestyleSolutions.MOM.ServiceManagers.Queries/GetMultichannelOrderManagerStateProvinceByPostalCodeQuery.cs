using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="MultichannelOrderManagerStateProvince"/> object by its postal code. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerStateProvinceByPostalCodeQuery : WhippetQuery<MultichannelOrderManagerStateProvince>, IWhippetQuery<MultichannelOrderManagerStateProvince>
    {
        /// <summary>
        /// Gets or sets the <see cref="IMultichannelOrderManagerPostalCode"/> to filter by.
        /// </summary>
        public IMultichannelOrderManagerPostalCode PostalCode
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerStateProvinceByPostalCodeQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerStateProvinceByPostalCodeQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerStateProvinceByPostalCodeQuery"/> class with the specified <see cref="IMultichannelOrderManagerPostalCode"/> object.
        /// </summary>
        /// <param name="postalCode"><see cref="IMultichannelOrderManagerPostalCode"/> object to filter by.</param>
        public GetMultichannelOrderManagerStateProvinceByPostalCodeQuery(IMultichannelOrderManagerPostalCode postalCode)
            : this()
        {
            PostalCode = postalCode;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(PostalCode), PostalCode) });
        }
    }
}
