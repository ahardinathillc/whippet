using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="GetMultichannelOrderManagerPostalCodesByPostalCodeQuery"/> objects based on a postal code value. This class cannot be inherited.
    /// </summary>
    public class GetMultichannelOrderManagerPostalCodesByPostalCodeQuery : WhippetQuery<MultichannelOrderManagerPostalCode>, IWhippetQuery<MultichannelOrderManagerPostalCode>
    {
        /// <summary>
        /// Gets or sets the postal code value to filter by.
        /// </summary>
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerPostalCodesByPostalCodeQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerPostalCodesByPostalCodeQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerPostalCodesByPostalCodeQuery"/> class with the specified postal code.
        /// </summary>
        /// <param name="postalCode">Postal code to filter by.</param>
        public GetMultichannelOrderManagerPostalCodesByPostalCodeQuery(string postalCode)
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
