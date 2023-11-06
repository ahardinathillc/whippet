using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Logging.Serilog.ServiceManagers.Queries;
using Athi.Whippet.Logging.Serilog.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Logging.Serilog.Repositories;
using UnitsNet;

namespace Athi.Whippet.Logging.Serilog.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ISerilogLogEntry"/> domain objects.
    /// </summary>
    public class SerilogLogEntryServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISerilogLogEntryRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISerilogLogEntryRepository LogRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLogEntryServiceManager"/> class with the specified <see cref="ISerilogLogEntryRepository"/> object.
        /// </summary>
        /// <param name="logRepository"><see cref="ISerilogLogEntryRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SerilogLogEntryServiceManager(ISerilogLogEntryRepository logRepository)
            : base()
        {
            if (logRepository == null)
            {
                throw new ArgumentNullException(nameof(logRepository));
            }
            else
            {
                LogRepository = logRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLogEntryServiceManager"/> class with the specified <see cref="ISerilogLogEntryRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="logRepository"><see cref="ISerilogLogEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SerilogLogEntryServiceManager(IWhippetServiceContext serviceLocator, ISerilogLogEntryRepository logRepository)
            : base(serviceLocator)
        {
            if (logRepository == null)
            {
                throw new ArgumentNullException(nameof(logRepository));
            }
            else
            {
                LogRepository = logRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISerilogLogEntry"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISerilogLogEntry"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISerilogLogEntry>> GetLog(int id)
        {
            ISerilogLogEntryQueryHandler<GetSerilogLogEntryByIdQuery> handler = new GetSerilogLogEntryByIdQueryHandler(LogRepository);
            WhippetResultContainer<IEnumerable<SerilogLogEntry>> result = await handler.HandleAsync(new GetSerilogLogEntryByIdQuery(id));
            return new WhippetResultContainer<ISerilogLogEntry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ISerilogLogEntry"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISerilogLogEntry>>> GetLogs()
        {
            ISerilogLogEntryQueryHandler<GetAllSerilogLogEntriesQuery> handler = new GetAllSerilogLogEntriesQueryHandler(LogRepository);
            WhippetResultContainer<IEnumerable<SerilogLogEntry>> result = await handler.HandleAsync(new GetAllSerilogLogEntriesQuery());
            return new WhippetResultContainer<IEnumerable<ISerilogLogEntry>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISerilogLogEntry"/> objects that occur within the specified date range.
        /// </summary>
        /// <param name="range">Date range to filter by.</param>
        /// <param name="levels"><see cref="SerilogLevel"/> values to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISerilogLogEntry>>> GetLogs(DateRange range, IEnumerable<SerilogLevel> levels = null)
        {
            ISerilogLogEntryQueryHandler<GetSerilogLogEntriesByDateRangeQuery> handler = new GetSerilogLogEntriesByDateRangeQueryHandler(LogRepository);
            WhippetResultContainer<IEnumerable<SerilogLogEntry>> result = await handler.HandleAsync(new GetSerilogLogEntriesByDateRangeQuery(range.Start.ToDateTimeUtc(), range.End.ToDateTimeUtc(), levels));
            return new WhippetResultContainer<IEnumerable<ISerilogLogEntry>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISerilogLogEntry"/> objects that occur within the specified date range.
        /// </summary>
        /// <param name="startDate">Starting date/time to filter by.</param>
        /// <param name="endDate">Ending date/time to filter by.</param>
        /// <param name="levels"><see cref="SerilogLevel"/> values to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISerilogLogEntry>>> GetLogs(DateTime startDate, DateTime endDate, IEnumerable<SerilogLevel> levels = null)
        {
            ISerilogLogEntryQueryHandler<GetSerilogLogEntriesByDateRangeQuery> handler = new GetSerilogLogEntriesByDateRangeQueryHandler(LogRepository);
            WhippetResultContainer<IEnumerable<SerilogLogEntry>> result = await handler.HandleAsync(new GetSerilogLogEntriesByDateRangeQuery(startDate, endDate, levels));
            return new WhippetResultContainer<IEnumerable<ISerilogLogEntry>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets the earliest <see cref="ISerilogLogEntry"/> object available in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISerilogLogEntry>> GetEarliestLogEntry()
        {
            ISerilogLogEntryQueryHandler<GetEarliestSerilogLogEntryQuery> handler = new GetEarliestSerilogLogEntryQueryHandler(LogRepository);
            WhippetResultContainer<IEnumerable<SerilogLogEntry>> result = await handler.HandleAsync(new GetEarliestSerilogLogEntryQuery());
            return new WhippetResultContainer<ISerilogLogEntry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets the newest <see cref="ISerilogLogEntry"/> object available in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISerilogLogEntry>> GetNewestLogEntry()
        {
            ISerilogLogEntryQueryHandler<GetLatestSerilogLogEntryQuery> handler = new GetLatestSerilogLogEntryQueryHandler(LogRepository);
            WhippetResultContainer<IEnumerable<SerilogLogEntry>> result = await handler.HandleAsync(new GetLatestSerilogLogEntryQuery());
            return new WhippetResultContainer<ISerilogLogEntry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (LogRepository != null)
            {
                LogRepository.Dispose();
                LogRepository = null;
            }

            base.Dispose();
        }
    }
}
