using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Jobs.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Provides support for <see cref="IWhippetQuery{TEntity}"/> handlers.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    /// <typeparam name="TJob"><see cref="IJob"/> type.</typeparam>
    public interface IJobQueryHandler<TQuery, TJob> : IWhippetQueryHandler<TQuery, TJob>
        where TQuery : IWhippetQuery<TJob>
        where TJob : JobBase, IJob, new()
    { }
}
