using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="StoreGroup"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IStoreGroupQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, StoreGroup> where TQuery : IWhippetQuery<StoreGroup>
    { }
}
