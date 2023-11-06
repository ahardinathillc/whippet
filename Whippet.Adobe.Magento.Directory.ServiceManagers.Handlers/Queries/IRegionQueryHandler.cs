using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="Region"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IRegionQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, Region> where TQuery : IWhippetQuery<Region>
    { }
}
