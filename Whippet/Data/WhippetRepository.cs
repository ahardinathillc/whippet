using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of object to store in the repository.</typeparam>
    public abstract class WhippetRepository<TEntity, TKey> : IWhippetRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRepository{TEntity, TKey}"/> class with no arguments.
        /// </summary>
        protected WhippetRepository()
        { }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public abstract WhippetResult Create(TEntity item);

        /// <summary>
        /// Asynchronously creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <param name="cancellationToken">Flag to signal to the <see cref="Task{TResult}"/> to stop at the next earliest convenience.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        public abstract Task<WhippetResult> CreateAsync(TEntity item, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public abstract WhippetResult Update(TEntity item);

        /// <summary>
        /// Asynchronously updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        public abstract Task<WhippetResult> UpdateAsync(TEntity item, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public abstract WhippetResult Delete(TEntity item);

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="T"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public virtual WhippetResult Delete(TEntity item, bool hardDelete)
        {
            WhippetResult wResult = null;

            if (typeof(TEntity).GetInterfaces().Contains(typeof(IWhippetSoftDeleteEntity)) && !hardDelete)
            {
                ((IWhippetSoftDeleteEntity)(item)).Deleted = true;
                wResult = Update(item);
            }
            else
            {
                wResult = Delete(item);
            }

            return wResult;
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        public abstract Task<WhippetResult> DeleteAsync(TEntity item, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="T"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public virtual Task<WhippetResult> DeleteAsync(TEntity item, bool hardDelete, CancellationToken? cancellationToken = null)
        {
            Task<WhippetResult> wResult = null;

            if (typeof(TEntity).GetInterfaces().Contains(typeof(IWhippetSoftDeleteEntity)) && !hardDelete)
            {
                ((IWhippetSoftDeleteEntity)(item)).Deleted = true;
                wResult = UpdateAsync(item, cancellationToken);
            }
            else
            {
                wResult = DeleteAsync(item, cancellationToken);
            }

            return wResult;
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public abstract WhippetResultContainer<TEntity> Get(TKey key);

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <typeparam name="TDetachedKey">Type of key the entity uses.</typeparam>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        WhippetResultContainer<TEntity> IWhippetDetachedRepository<TEntity>.Get<TDetachedKey>(TDetachedKey key)
        {
            return Get((TKey)((object)(key)));
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <typeparam name="TDetachedKey">Type of key the entity uses.</typeparam>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        async Task<WhippetResultContainer<TEntity>> IWhippetDetachedRepository<TEntity>.GetAsync<TDetachedKey>(TDetachedKey key, CancellationToken? cancellationToken)
        {
            return await GetAsync((TKey)((object)(key)), cancellationToken);
        }

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        public abstract WhippetResultContainer<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Asynchronously retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public abstract Task<WhippetResultContainer<IEnumerable<TEntity>>> GetAllAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public abstract Task<WhippetResultContainer<TEntity>> GetAsync(TKey key, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        public virtual void Commit()
        { }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public virtual async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                return;
            });
        }

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance. This method must be overridden.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        public abstract void RefreshEntityContext(TEntity entity);

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance. This method must be overridden.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public abstract Task RefreshEntityContextAsync(TEntity entity, CancellationToken? cancellationToken = null);
    }
}
