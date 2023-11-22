using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Store.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="StoreWebsite"/> objects.
    /// </summary>
    public interface IStoreWebsiteRepository : IMagentoEntityRepository<StoreWebsite>, IWhippetExternalQueryRepository<StoreWebsite, uint>
    {
        /// <summary>
        /// Retrieves the <see cref="StoreWebsite"/> object with the specified <see cref="Store"/> code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Store"/> to retrieve the group information for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<StoreConfiguration> Get(string code);
        
        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified code.
        /// </summary>
        /// <param name="code">Code of the <see cref="Store"/> to retrieve the group information for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<StoreConfiguration>> Get(string code, CancellationToken? cancellationToken = null);
    }
}
