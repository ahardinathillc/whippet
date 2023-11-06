using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Logging.Serilog.ServiceManagers.Queries;

namespace Athi.Whippet.Logging.Serilog.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllSerilogLogEntriesQuery"/> objects.
    /// </summary>
    public class GetAllSerilogLogEntriesQueryHandler : SerilogLogEntryQueryHandlerBase<GetAllSerilogLogEntriesQuery>, ISerilogLogEntryQueryHandler<GetAllSerilogLogEntriesQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSerilogLogEntriesQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllSerilogLogEntriesQueryHandler(IWhippetQueryRepository<SerilogLogEntry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SerilogLogEntry>>> HandleAsync(GetAllSerilogLogEntriesQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SerilogLogEntry>> queryResult = await ((IWhippetQueryRepository<SerilogLogEntry>)(Repository)).GetAllAsync();
                return queryResult;
            }
        }
    }
}
