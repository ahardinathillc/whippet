using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Provides support for all <see cref="IWhippetQuery{TEntity}"/> handlers.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public interface ILegacySuperDuperAccountQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, LegacySuperDuperAccount>
        where TQuery : IWhippetQuery<LegacySuperDuperAccount>
    { }
}
