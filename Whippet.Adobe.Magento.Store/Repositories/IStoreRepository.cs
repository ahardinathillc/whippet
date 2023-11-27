using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="Store"/> objects.
    /// </summary>
    public interface IStoreRepository : IMagentoEntityRepository<Store>, IWhippetExternalQueryRepository<Store, uint>
    {
        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Store"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<Store> Get(string name);
        
        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Store"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<Store>> GetAsync(string name, CancellationToken? cancellationToken = null);
        
        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Store"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<Store> GetByCode(string code);
        
        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Store"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<Store>> GetByCodeAsync(string code, CancellationToken? cancellationToken = null);
    }
}
