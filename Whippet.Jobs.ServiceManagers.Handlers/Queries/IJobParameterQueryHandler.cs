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
    /// <typeparam name="TJobParameter"><see cref="IJobParameter"/> type.</typeparam>
    /// <typeparam name="TJob"><see cref="IJob"/> type that the parameter is for.</typeparam>
    public interface IJobParameterQueryHandler<TQuery, TJobParameter, TJob> : IWhippetQueryHandler<TQuery, TJobParameter>
        where TQuery : IWhippetQuery<TJobParameter>
        where TJob : JobBase, IJob, new()
        where TJobParameter : JobParameterBase<TJob>, IJobParameter, new()
    { }
}
