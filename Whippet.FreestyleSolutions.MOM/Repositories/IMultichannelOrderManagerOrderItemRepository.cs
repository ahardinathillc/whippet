using System;
using FluentNHibernate.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerOrderItem"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerOrderItemRepository : IWhippetEntityRepository<MultichannelOrderManagerOrderItem, long>, IWhippetQueryRepository<MultichannelOrderManagerOrderItem>, IWhippetExternalQueryRepository<MultichannelOrderManagerOrderItem, long>
    {
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrderItem"/> objects that are associated with the specified order number.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object that specifies where the M.O.M. instance is hosted.</param>
        /// <param name="orderNumber">Order number to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrderItem>> GetItemsForOrder(IMultichannelOrderManagerServer server, int orderNumber);
        
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrderItem"/> objects.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object that specifies where the M.O.M. instance is hosted.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrderItem>> GetItemsForServer(IMultichannelOrderManagerServer server);

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrderItem>> GetAll();
    }
}
