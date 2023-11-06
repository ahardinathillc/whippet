using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="PostalCode"/> object by its name. This class cannot be inherited.
    /// </summary>
    public sealed class GetPostalCodesQuery : WhippetQuery<PostalCode>, IWhippetQuery<PostalCode>
    {
        /// <summary>
        /// Gets the name of the <see cref="PostalCode"/> to retrieve. This property is read-only.
        /// </summary>
        public string Value
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="ICity"/> to filter by (if any). This property is read-only.
        /// </summary>
        public ICity City
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPostalCodesQuery"/> class with no arguments.
        /// </summary>
        private GetPostalCodesQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPostalCodesQuery"/> class with the specified name.
        /// </summary>
        /// <param name="value"><see cref="PostalCode.Value"/> to search for.</param>
        /// <param name="city"><see cref="ICity"/> to filter by.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetPostalCodesQuery(string value, ICity city = null)
            : this()
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else
            {
                Value = value;
                City = city;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(
                new[]
                {
                    new KeyValuePair<string, object>(nameof(Value), Value),
                    new KeyValuePair<string, object>(nameof(City), City)
                });
        }
    }
}
