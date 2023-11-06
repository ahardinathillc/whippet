using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Athi.Whippet.Data;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides support to repositories that are used in CQRS query handlers. This interface allows access to external data sources that may not be indexed by Whippet's standard <see cref="Guid"/> foreign key data type.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IWhippetEntity"/> type that the repository manages.</typeparam>
    /// <typeparam name="TKey">Non-nullable type of key that <typeparamref name="TEntity"/> uses.</typeparam>
    public interface IWhippetExternalQueryRepository<TEntity, TKey> : IWhippetQueryRepository<TEntity>
        where TEntity : class, IWhippetEntity
        where TKey : struct
    {
        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        WhippetResultContainer<TEntity> Get(TKey key);

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        Task<WhippetResultContainer<TEntity>> GetAsync(TKey key, CancellationToken? cancellationToken = null);
    }
}

