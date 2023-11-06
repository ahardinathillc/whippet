using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Logging.Serilog.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="SerilogLogEntry"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface ISerilogLogEntryQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, SerilogLogEntry> where TQuery : IWhippetQuery<SerilogLogEntry>
    { }
}
