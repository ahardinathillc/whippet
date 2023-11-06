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
    public class GetCitiesByNameQuery : WhippetQuery<City>, IWhippetQuery<City>
    {
        /// <summary>
        /// Gets the name of the <see cref="City"/> to retrieve. This property is read-only.
        /// </summary>
        public string Name
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCitiesByNameQuery"/> class with no arguments.
        /// </summary>
        protected GetCitiesByNameQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCitiesByNameQuery"/> class with the specified name.
        /// </summary>
        /// <param name="name"><see cref="City.Name"/> value to search for.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetCitiesByNameQuery(string name)
            : this()
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            else
            {
                Name = name;
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(Name), Name) });
        }
    }
}
