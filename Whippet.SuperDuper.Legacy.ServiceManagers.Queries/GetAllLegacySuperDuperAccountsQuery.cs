using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Queries
{
    /// <summary>
    /// Query that retrieves a <see cref="LegacySuperDuperAccount"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllLegacySuperDuperAccountsQuery : WhippetQuery<LegacySuperDuperAccount>, IWhippetQuery<LegacySuperDuperAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLegacySuperDuperAccountsQuery"/> class with no arguments.
        /// </summary>
        public GetAllLegacySuperDuperAccountsQuery()
            : base()
        { }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return NoParameters;
        }
    }
}
