using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Repositories;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Provides support for all <see cref="IWhippetQuery{TEntity}"/> handlers.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public interface ILegacyDigitalLibraryServerQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, LegacyDigitalLibraryServer>
        where TQuery : IWhippetQuery<LegacyDigitalLibraryServer>
    { }
}
