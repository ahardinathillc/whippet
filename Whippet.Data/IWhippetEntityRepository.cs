using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using NHibernate;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="IWhippetEntity"/> objects.
    /// </summary>
    /// <typeparam name="TEntity">Type of object to store in the repository.</typeparam>
    /// <typeparam name="TKey">Non-nullable type of key that <typeparamref name="TEntity"/> uses.</typeparam>
    public interface IWhippetEntityRepository<TEntity, TKey> : IWhippetRepository<TEntity, TKey>, IDisposable
        where TEntity : class
        where TKey : struct
    {
        /// <summary>
        /// Begins a transaction scope for the database event.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        ITransaction BeginTransaction();

        /// <summary>
        /// Begins a transaction scope for database event.
        /// </summary>
        /// <param name="isolationLevel">Isolation level to apply to the transaction.</param>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        ITransaction BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Begins a transaction scope for database event.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        ITransaction BeginStatelessTransaction();

        /// <summary>
        /// Begins a transaction scope for database event.
        /// </summary>
        /// <param name="isolationLevel">Isolation level to apply to the transaction.</param>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        ITransaction BeginStatelessTransaction(IsolationLevel isolationLevel);
    }
}
