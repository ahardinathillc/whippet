using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Logging.Serilog.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="SerilogLogEntry"/> objects for a specific date range. This class cannot be inherited.
    /// </summary>
    public sealed class GetSerilogLogEntriesByDateRangeQuery : WhippetQuery<SerilogLogEntry>, IWhippetQuery<SerilogLogEntry>
    {
        /// <summary>
        /// Gets the starting date range. This property is read-only.
        /// </summary>
        public DateTime StartDate
        { get; private set; }

        /// <summary>
        /// Gets the ending date range. This property is read-only.
        /// </summary>
        public DateTime EndDate
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="SerilogLevel"/> values to filter by (if any). This property is read-only.
        /// </summary>
        public IEnumerable<SerilogLevel> Levels
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSerilogLogEntriesByDateRangeQuery"/> class with no arguments.
        /// </summary>
        private GetSerilogLogEntriesByDateRangeQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSerilogLogEntriesByDateRangeQuery"/> class with the specified parameters.
        /// </summary>
        /// <param name="startDate">Starting date range.</param>
        /// <param name="endDate">Ending date range.</param>
        /// <param name="levels"><see cref="SerilogLevel"/> values to filter by (if any).</param>
        public GetSerilogLogEntriesByDateRangeQuery(DateTime startDate, DateTime endDate, IEnumerable<SerilogLevel> levels = null)
            : this()
        {
            StartDate = startDate;
            EndDate = endDate;
            Levels = levels;
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
                    new KeyValuePair<string, object>(nameof(StartDate), StartDate),
                    new KeyValuePair<string, object>(nameof(EndDate), EndDate),
                    new KeyValuePair<string, object>(nameof(Levels), Levels)
                });
        }
    }
}
