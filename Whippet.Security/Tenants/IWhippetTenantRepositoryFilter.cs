using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security.Tenants
{
    /// <summary>
    /// Provides support to <see cref="IWhippetRepository{TEntity,TKey}"/> objects that can filter results based on an <see cref="IWhippetTenant"/> instance.
    /// </summary>
    /// <typeparam name="TEntity">Type of object to store in the repository.</typeparam>
    /// <typeparam name="TKey">Non-nullable type of key that <typeparamref name="TEntity"/> uses.</typeparam>
    public interface IWhippetTenantRepositoryFilter<TEntity, TKey> : IWhippetRepository<TEntity, TKey>, IDisposable
        where TEntity : class
        where TKey : struct
    {
        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<IEnumerable<TEntity>> GetAll(IWhippetTenant tenant);

        /// <summary>
        /// Asynchronously retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        new Task<WhippetResultContainer<IEnumerable<TEntity>>> GetAllAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
