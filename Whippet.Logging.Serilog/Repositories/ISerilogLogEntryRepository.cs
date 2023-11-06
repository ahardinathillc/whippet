using System;
using FluentNHibernate.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Logging.Serilog.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SerilogLogEntry"/> entity objects.
    /// </summary>
    public interface ISerilogLogEntryRepository : IWhippetEntityRepository<SerilogLogEntry, int>, IWhippetQueryRepository<SerilogLogEntry>
    {
        /// <summary>
        /// Gets all <see cref="SerilogLogEntry"/> objects for the specified date range.
        /// </summary>
        /// <param name="startRange">Starting date range.</param>
        /// <param name="endRange">Ending date range.</param>
        /// <param name="levels"><see cref="SerilogLevel"/> values to filter by (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<IEnumerable<SerilogLogEntry>> GetEntriesForDateRange(DateTime startRange, DateTime endRange, IEnumerable<SerilogLevel> levels = null);

        /// <summary>
        /// Gets all <see cref="SerilogLogEntry"/> objects for the specified date range.
        /// </summary>
        /// <param name="startRange">Starting date range.</param>
        /// <param name="endRange">Ending date range.</param>
        /// <param name="levels"><see cref="SerilogLevel"/> values to filter by (if any).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<SerilogLogEntry>>> GetEntriesForDateRangeAsync(DateTime startRange, DateTime endRange, IEnumerable<SerilogLevel> levels = null, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the earliest <see cref="SerilogLogEntry"/> available in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<SerilogLogEntry> GetEarliestEntry();

        /// <summary>
        /// Gets the earliest <see cref="SerilogLogEntry"/> available in the system.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<SerilogLogEntry>> GetEarliestEntryAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the latest <see cref="SerilogLogEntry"/> available in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<SerilogLogEntry> GetLatestEntry();

        /// <summary>
        /// Gets the latest <see cref="SerilogLogEntry"/> available in the system.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<SerilogLogEntry>> GetLatestEntryAsync(CancellationToken? cancellationToken = null);
    }
}
