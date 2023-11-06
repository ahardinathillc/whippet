using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Logging.Serilog.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves an <see cref="SerilogLogEntry"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetSerilogLogEntryByIdQuery : WhippetQuery<SerilogLogEntry>, IWhippetQuery<SerilogLogEntry>
    {
        /// <summary>
        /// Gets the ID of the <see cref="SerilogLogEntry"/> to retrieve. This property is read-only.
        /// </summary>
        public int ID
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSerilogLogEntryByIdQuery"/> class with no arguments.
        /// </summary>
        private GetSerilogLogEntryByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSerilogLogEntryByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="SerilogLogEntry"/> to retrieve.</param>
        public GetSerilogLogEntryByIdQuery(int id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ID), ID) });
        }
    }
}
