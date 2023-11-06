using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Logging.Serilog.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the earliest available <see cref="SerilogLogEntry"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetEarliestSerilogLogEntryQuery : WhippetQuery<SerilogLogEntry>, IWhippetQuery<SerilogLogEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetEarliestSerilogLogEntryQuery"/> class with no arguments.
        /// </summary>
        public GetEarliestSerilogLogEntryQuery()
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
