using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="GetMultichannelOrderManagerCountryByAbbreviationQuery"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public class GetMultichannelOrderManagerCountryByAbbreviationQuery : WhippetQuery<MultichannelOrderManagerCountry>, IWhippetQuery<MultichannelOrderManagerCountry>
    {
        /// <summary>
        /// Gets the ISO-2/ISO-3 abbreviation to query by.
        /// </summary>
        public string Abbreviation
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCountryByAbbreviationQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerCountryByAbbreviationQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCountryByAbbreviationQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="abbreviation">ISO-2/ISO-3 abbreviation to query by.</param>
        public GetMultichannelOrderManagerCountryByAbbreviationQuery(string abbreviation)
            : this()
        {
            Abbreviation = abbreviation;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Abbreviation), Abbreviation) });
        }
    }
}
