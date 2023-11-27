using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="StoreGroup"/> objects.
    /// </summary>
    public interface IStoreGroupRepository : IMagentoEntityRepository<StoreGroup>, IWhippetExternalQueryRepository<StoreGroup, uint>
    {
        /// <summary>
        /// Retrieves the <see cref="StoreGroup"/> object with the specified <see cref="StoreGroup"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="StoreGroup"/> to retrieve the group information for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<StoreGroup> Get(string code);
        
        /// <summary>
        /// Retrieves the <see cref="StoreGroup"/> object with the specified <see cref="StoreGroup"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="StoreGroup"/> to retrieve the group information for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<StoreGroup>> GetAsync(string code, CancellationToken? cancellationToken = null);
    }
}
