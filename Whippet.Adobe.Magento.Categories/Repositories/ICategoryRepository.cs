using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Categories.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="Category"/> objects.
    /// </summary>
    public interface ICategoryRepository: IMagentoEntityRepository<Category>, IWhippetExternalQueryRepository<Category, uint>
    {
        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified code.
        /// </summary>
        /// <param name="name">Name of the <see cref="Store"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<Category> Get(string name);
        
        /// <summary>
        /// Retrieves the <see cref="Store"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Store"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<Category>> GetAsync(string name, CancellationToken? cancellationToken = null);
    }
}
