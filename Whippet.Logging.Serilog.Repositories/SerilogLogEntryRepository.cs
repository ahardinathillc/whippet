using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;

namespace Athi.Whippet.Logging.Serilog.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SerilogLogEntry"/> entity objects.
    /// </summary>
    public class SerilogLogEntryRepository : WhippetEntityRepository<SerilogLogEntry>, ISerilogLogEntryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLogEntryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public SerilogLogEntryRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLogEntryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public SerilogLogEntryRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual WhippetResultContainer<SerilogLogEntry> Get(int key)
        {
            WhippetResultContainer<SerilogLogEntry> result = null;

            try
            {
                result = new WhippetResultContainer<SerilogLogEntry>(WhippetResult.Success, Context.Get<SerilogLogEntry>(key));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SerilogLogEntry>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<SerilogLogEntry>> GetAsync(int key, CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SerilogLogEntry> result = null;

            try
            {
                result = new WhippetResultContainer<SerilogLogEntry>(WhippetResult.Success, await Context.GetAsync<SerilogLogEntry>(key));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SerilogLogEntry>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all items of <see cref="SerilogLogEntry"/> type in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<SerilogLogEntry>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<SerilogLogEntry>> result = null;
            IEnumerable<SerilogLogEntry> items = null;

            try
            {
                items = await Context.QueryOver<SerilogLogEntry>()
                    .OrderBy(l => l.TimeStamp)
                    .Desc
                    .ListAsync(cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<SerilogLogEntry>>(WhippetResult.Success, items);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<SerilogLogEntry>>(e);
            }

            return result;
        }

        /// <summary>
        /// Gets all <see cref="SerilogLogEntry"/> objects for the specified date range.
        /// </summary>
        /// <param name="startRange">Starting date range.</param>
        /// <param name="endRange">Ending date range.</param>
        /// <param name="levels"><see cref="SerilogLevel"/> values to filter by (if any).</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<SerilogLogEntry>> GetEntriesForDateRange(DateTime startRange, DateTime endRange, IEnumerable<SerilogLevel> levels = null)
        {
            return Task.Run(() => GetEntriesForDateRangeAsync(startRange, endRange, levels)).Result;
        }

        /// <summary>
        /// Gets all <see cref="SerilogLogEntry"/> objects for the specified date range.
        /// </summary>
        /// <param name="startRange">Starting date range.</param>
        /// <param name="endRange">Ending date range.</param>
        /// <param name="levels"><see cref="SerilogLevel"/> values to filter by (if any).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<SerilogLogEntry>>> GetEntriesForDateRangeAsync(DateTime startRange, DateTime endRange, IEnumerable<SerilogLevel> levels = null, CancellationToken? cancellationToken = null)
        {
            SerilogLevel[] levelArray = null;

            IList<SerilogLogEntry> queryResults = await Context.QueryOver<SerilogLogEntry>()
                .Where(l => (l.TimeStamp >= startRange) && (l.TimeStamp <= endRange))
                .ListAsync();

            if (queryResults.Any() && (levels != null && levels.Any()))
            {
                levelArray = levels.Distinct().ToArray();

                queryResults = queryResults.Where(l => l.Level.HasValue && levelArray.Contains(l.Level.GetValueOrDefault())).ToList();
            }

            return new WhippetResultContainer<IEnumerable<SerilogLogEntry>>(WhippetResult.Success, queryResults);
        }

        /// <summary>
        /// Gets the earliest <see cref="SerilogLogEntry"/> available in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<SerilogLogEntry> GetEarliestEntry()
        {
            return Task.Run(() => GetEarliestEntryAsync()).Result;
        }

        /// <summary>
        /// Gets the earliest <see cref="SerilogLogEntry"/> available in the system.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<SerilogLogEntry>> GetEarliestEntryAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SerilogLogEntry> result = null;
            SerilogLogEntry item;

            try
            {
                item = await Context.QueryOver<SerilogLogEntry>()
                    .OrderBy(l => l.TimeStamp)
                    .Asc
                    .Take(1)
                    .SingleOrDefaultAsync();

                result = new WhippetResultContainer<SerilogLogEntry>(WhippetResult.Success, item);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SerilogLogEntry>(e);
            }

            return result;
        }

        /// <summary>
        /// Gets the latest <see cref="SerilogLogEntry"/> available in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<SerilogLogEntry> GetLatestEntry()
        {
            return Task.Run(() => GetLatestEntryAsync()).Result;
        }

        /// <summary>
        /// Gets the latest <see cref="SerilogLogEntry"/> available in the system.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<SerilogLogEntry>> GetLatestEntryAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<SerilogLogEntry> result = null;
            SerilogLogEntry item;

            try
            {
                item = await Context.QueryOver<SerilogLogEntry>()
                    .OrderBy(l => l.TimeStamp)
                    .Desc
                    .Take(1)
                    .SingleOrDefaultAsync();

                result = new WhippetResultContainer<SerilogLogEntry>(WhippetResult.Success, item);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<SerilogLogEntry>(e);
            }

            return result;
        }
    }
}
