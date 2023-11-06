using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="PostalCode"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllPostalCodesQuery : WhippetQuery<PostalCode>, IWhippetQuery<PostalCode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPostalCodesQuery"/> class with no arguments.
        /// </summary>
        public GetAllPostalCodesQuery()
            : base()
        { }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return NoParameters;
        }
    }
}
