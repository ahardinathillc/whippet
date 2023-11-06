using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="GetMultichannelOrderManagerCountryByCodeQuery"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public class GetMultichannelOrderManagerCountryByCodeQuery : WhippetQuery<MultichannelOrderManagerCountry>, IWhippetQuery<MultichannelOrderManagerCountry>
    {
        /// <summary>
        /// Gets or sets the code to query by.
        /// </summary>
        public string Code
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCountryByCodeQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerCountryByCodeQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCountryByCodeQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="code">Three digit code of the <see cref="GetMultichannelOrderManagerCountryByCodeQuery"/> object to retrieve.</param>
        public GetMultichannelOrderManagerCountryByCodeQuery(string code)
            : this()
        {
            Code = code;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Code), Code) });
        }
    }
}
