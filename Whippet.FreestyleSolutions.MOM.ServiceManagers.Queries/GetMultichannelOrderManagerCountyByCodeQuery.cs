using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="GetMultichannelOrderManagerCountyByCodeQuery"/> object by its three-digit code. This class cannot be inherited.
    /// </summary>
    public class GetMultichannelOrderManagerCountyByCodeQuery : WhippetQuery<MultichannelOrderManagerCounty>, IWhippetQuery<MultichannelOrderManagerCounty>
    {
        /// <summary>
        /// Gets or sets the code to query by.
        /// </summary>
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the state abbreviation.
        /// </summary>
        public string StateAbbreviation
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCountyByCodeQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerCountyByCodeQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCountyByCodeQuery"/> class with the specified code.
        /// </summary>
        /// <param name="code">Three digit code of the <see cref="GetMultichannelOrderManagerCountyByCodeQuery"/> object to retrieve.</param>
        /// <param name="stateAbbreviation">State abbreviation.</param>
        public GetMultichannelOrderManagerCountyByCodeQuery(string code, string stateAbbreviation)
            : this()
        {
            Code = code;
            StateAbbreviation = stateAbbreviation;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(Code), Code),
                new KeyValuePair<string, object>(nameof(StateAbbreviation), StateAbbreviation)
            });
        }
    }
}
