using System;
using Athi.Whippet.Data;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Provides support to repositories in Magento that utilize a row number for versioning purposes. The row number serves as the entity's key as opposed to the entity ID.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="MagentoEntity"/> type stored in the repository.</typeparam>
    public interface IMagentoRowNumberEntityRepository<TEntity> : IWhippetEntityRepository<TEntity, uint>, IWhippetRepository<TEntity, uint>, IDisposable
        where TEntity : MagentoEntity
    {
        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="rowNumber">Row number of the entity.</param>
        /// <param name="entityId">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        WhippetResultContainer<TEntity> Get(uint rowNumber, uint entityId);

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="rowNumber">Row number of the entity.</param>
        /// <param name="entityId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        Task<WhippetResultContainer<TEntity>> GetAsync(uint rowNumber, uint entityId, CancellationToken? cancellationToken = null);
    }
}

