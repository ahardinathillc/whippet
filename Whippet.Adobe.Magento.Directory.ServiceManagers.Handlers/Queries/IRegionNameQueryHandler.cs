using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="RegionName"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IRegionNameQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, RegionName> where TQuery : IWhippetQuery<RegionName>
    { }
}
