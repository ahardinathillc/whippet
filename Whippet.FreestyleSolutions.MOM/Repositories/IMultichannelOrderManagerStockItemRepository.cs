using System;
using FluentNHibernate.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerStockItem"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerStockItemRepository : IWhippetEntityRepository<MultichannelOrderManagerStockItem, long>, IWhippetQueryRepository<MultichannelOrderManagerStockItem>, IWhippetExternalQueryRepository<MultichannelOrderManagerStockItem, long>
    {
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerStockItem"/> objects.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object that specifies where the M.O.M. instance is hosted.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerStockItem>> GetItemsForServer(IMultichannelOrderManagerServer server);

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        new WhippetResultContainer<IEnumerable<MultichannelOrderManagerStockItem>> GetAll();
    }
}
