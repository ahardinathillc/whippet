using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="Store"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IStoreQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, Store> where TQuery : IWhippetQuery<Store>
    { }
}
