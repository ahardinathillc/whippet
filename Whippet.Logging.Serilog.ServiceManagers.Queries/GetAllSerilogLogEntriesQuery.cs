using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Logging.Serilog.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="SerilogLogEntry"/> objects in the system. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllSerilogLogEntriesQuery : WhippetQuery<SerilogLogEntry>, IWhippetQuery<SerilogLogEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSerilogLogEntriesQuery"/> class with no arguments.
        /// </summary>
        public GetAllSerilogLogEntriesQuery()
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
