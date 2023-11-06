using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Provides support for repositories that are independent of the backing data store.
    /// </summary>
    /// <typeparam name="TEntity">Type of object to store in the repository.</typeparam>
    /// <typeparam name="TKey">Non-nullable type of key that <typeparamref name="TEntity"/> uses.</typeparam>
    /// <remarks>Added <see langword="new"/> keyword to existing implementations for backwards compatibility reasons.</remarks>
    public interface IWhippetRepository<TEntity, TKey> : IWhippetDetachedRepository<TEntity>
        where TEntity : class
        where TKey : struct
    {
        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        new WhippetResult Create(TEntity item);

        /// <summary>
        /// Asynchronously creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <param name="cancellationToken">Flag to signal to the <see cref="Task{TResult}"/> to stop at the next earliest convenience.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        new Task<WhippetResult> CreateAsync(TEntity item, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        new WhippetResult Update(TEntity item);

        /// <summary>
        /// Asynchronously updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        new Task<WhippetResult> UpdateAsync(TEntity item, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        new WhippetResult Delete(TEntity item);

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        new WhippetResult Delete(TEntity item, bool hardDelete);

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        new Task<WhippetResult> DeleteAsync(TEntity item, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        new Task<WhippetResult> DeleteAsync(TEntity item, bool hardDelete, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        WhippetResultContainer<TEntity> Get(TKey key);

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        new WhippetResultContainer<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        Task<WhippetResultContainer<TEntity>> GetAsync(TKey key, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Asynchronously retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        new Task<WhippetResultContainer<IEnumerable<TEntity>>> GetAllAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        new void Commit();

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        new Task CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        void RefreshEntityContext(TEntity entity);

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        Task RefreshEntityContextAsync(TEntity entity, CancellationToken? cancellationToken = null);
    }
}
