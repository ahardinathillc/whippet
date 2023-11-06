using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using NHibernate;

namespace Athi.Whippet.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="WhippetEntity"/> objects. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of <see cref="WhippetEntity"/> object to store in the repository.</typeparam>
    public abstract class WhippetEntityRepository<TEntity> : WhippetRepository<TEntity, Guid>, IWhippetEntityRepository<TEntity, Guid>, IWhippetRepository<TEntity, Guid>, IDisposable
        where TEntity : WhippetEntity
    {
        /// <summary>
        /// Gets the <see cref="ISession"/> instance that provides access to the current application NHibernate connection. This property is read-only.
        /// </summary>
        public ISession Context
        { get; private set; }

        /// <summary>
        /// Gets the <see cref="IStatelessSession"/> instance that provides a cacheless level of override to the current application NHibernate connection. This property is read-only.
        /// </summary>
        public IStatelessSession StatelessContext
        { get; private set; }

        /// <summary>
        /// Indicates whether <see cref="StatelessContext"/> has been configured for this instance. This property is read-only.
        /// </summary>
        public bool StatelessContextConfigured
        {
            get
            {
                return StatelessContext != null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityRepository{T}"/> class with no arguments.
        /// </summary>
        private WhippetEntityRepository()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityRepository{T}"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetEntityRepository(ISession context)
            : this(context, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityRepository{T}"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetEntityRepository(ISession context, IStatelessSession statelessContext)
            : this()
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                Context = context;
                StatelessContext = statelessContext;
            }
        }

        /// <summary>
        /// Begins a transaction scope for NHibernate.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        public virtual ITransaction BeginTransaction()
        {
            return Context.BeginTransaction();
        }

        /// <summary>
        /// Begins a transaction scope for NHibernate.
        /// </summary>
        /// <param name="isolationLevel">Isolation level to apply to the transaction.</param>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        public virtual ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return Context.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Begins a transaction scope for NHibernate.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        public virtual ITransaction BeginStatelessTransaction()
        {
            return StatelessContext.BeginTransaction();
        }

        /// <summary>
        /// Begins a transaction scope for NHibernate.
        /// </summary>
        /// <param name="isolationLevel">Isolation level to apply to the transaction.</param>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        public virtual ITransaction BeginStatelessTransaction(IsolationLevel isolationLevel)
        {
            return StatelessContext.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Performs a synchronous repository operation.
        /// </summary>
        /// <param name="op">Repository operation to perform.</param>
        /// <param name="item">Entity to perform the operation on.</param>
        /// <returns><see cref="WhippetResult"/> object that contains the outcome of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidEnumArgumentException" />
        private WhippetResult PerformOperation(RepositoryOperation op, TEntity item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                try
                {
                    switch(op)
                    {
                        case RepositoryOperation.Create:
                            Context.Save(item);
                            break;
                        case RepositoryOperation.Delete:
                            Context.Delete(item);
                            break;
                        case RepositoryOperation.Update:
                            Context.Update(item);
                            break;
                        default:
                            throw new InvalidEnumArgumentException(nameof(op), Convert.ToInt32(op), typeof(RepositoryOperation));
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Performs an asynchronous repository operation.
        /// </summary>
        /// <param name="op">Repository operation to perform.</param>
        /// <param name="item">Entity to perform the operation on.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidEnumArgumentException" />
        private async Task<WhippetResult> PerformOperationAsync(RepositoryOperation op, TEntity item, CancellationToken? cancellationToken)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                try
                {
                    switch (op)
                    {
                        case RepositoryOperation.Create:
                            item.ID = (Guid)(await (cancellationToken.HasValue ? Context.SaveAsync(item, cancellationToken.Value) : Context.SaveAsync(item)));
                            break;
                        case RepositoryOperation.Update:
                            await (cancellationToken.HasValue ? Context.UpdateAsync(item, cancellationToken.Value) : Context.UpdateAsync(item));
                            break;
                        case RepositoryOperation.Delete:
                            await (cancellationToken.HasValue ? Context.DeleteAsync(item, cancellationToken.Value) : Context.DeleteAsync(item));
                            break;
                        default:
                            throw new InvalidEnumArgumentException(nameof(op), Convert.ToInt32(op), typeof(RepositoryOperation));
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="T"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public override WhippetResult Create(TEntity item)
        {
            return PerformOperation(RepositoryOperation.Create, item);
        }

        /// <summary>
        /// Asynchronously creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="T"/> to save in the data store.</param>
        /// <param name="cancellationToken">Flag to signal to the <see cref="Task{TResult}"/> to stop at the next earliest convenience.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        public override Task<WhippetResult> CreateAsync(TEntity item, CancellationToken? cancellationToken = null)
        {
            return PerformOperationAsync(RepositoryOperation.Create, item, cancellationToken);
        }

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="T"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public override WhippetResult Update(TEntity item)
        {
            return PerformOperation(RepositoryOperation.Update, item);
        }

        /// <summary>
        /// Asynchronously updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="T"/> to update in the data store.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        public override Task<WhippetResult> UpdateAsync(TEntity item, CancellationToken? cancellationToken = null)
        {
            return PerformOperationAsync(RepositoryOperation.Update, item, cancellationToken);
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="T"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public override WhippetResult Delete(TEntity item)
        {
            return PerformOperation(RepositoryOperation.Delete, item);
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="T"/> to delete in the data store.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public override Task<WhippetResult> DeleteAsync(TEntity item, CancellationToken? cancellationToken = null)
        {
            return PerformOperationAsync(RepositoryOperation.Delete, item, cancellationToken);
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override WhippetResultContainer<TEntity> Get(Guid key)
        {
            WhippetResult result = WhippetResult.Success;
            TEntity item = null;

            try
            {
                item = Context.Get<TEntity>(key);
            }
            catch(Exception e)
            {
                result = new WhippetResult(e);
            }

            return new WhippetResultContainer<TEntity>(result, item);
        }

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        public override WhippetResultContainer<IEnumerable<TEntity>> GetAll()
        {
            WhippetResult result = WhippetResult.Success;
            IEnumerable<TEntity> items = null;

            try
            {
                items = Context.QueryOver<TEntity>().List();
            }
            catch (Exception e)
            {
                result = new WhippetResult(e);
            }

            return new WhippetResultContainer<IEnumerable<TEntity>>(result, items);
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override Task<WhippetResultContainer<TEntity>> GetAsync(Guid key, CancellationToken? cancellationToken = null)
        {
            Func<Task<WhippetResultContainer<TEntity>>> opAsync = new Func<Task<WhippetResultContainer<TEntity>>>(async () =>
            {
                WhippetResult result = WhippetResult.Success;
                TEntity item = null;

                try
                {
                    item = await (cancellationToken.HasValue ? Context.GetAsync<TEntity>(key, cancellationToken.Value) : Context.GetAsync<TEntity>(key));
                }
                catch (Exception e)
                {
                    result = new WhippetResult(e);
                }

                return new WhippetResultContainer<TEntity>(result, item);
            });

            return Task.Run<WhippetResultContainer<TEntity>>(opAsync);
        }

        /// <summary>
        /// Asynchronously retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<TEntity>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            WhippetResultContainer<IEnumerable<TEntity>> result = null;
            IEnumerable<TEntity> items = null;

            try
            {
                items = await Context.QueryOver<TEntity>().ListAsync(cancellationToken.GetValueOrDefault());
                result = new WhippetResultContainer<IEnumerable<TEntity>>(WhippetResult.Success, items);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<TEntity>>(e);
            }

            return result;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if(Context != null)
            {
                Context.Dispose();
            }
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches.
        /// </summary>
        public override void Commit()
        {
            Context.Flush();
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public override async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await Context.FlushAsync(cancellationToken);
        }

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance. This method must be overridden.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        /// <remarks>See <a href="https://stackoverflow.com/questions/9676486/nhibernate-a-different-object-with-the-same-identifier-value-was-already-associ">NHibernate, a different object with the same identifier value was already associated with the session</a> for more information.</remarks>
        public override void RefreshEntityContext(TEntity entity)
        {
            Context.Evict(entity);
        }

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance. This method must be overridden.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <remarks>See <a href="https://stackoverflow.com/questions/9676486/nhibernate-a-different-object-with-the-same-identifier-value-was-already-associ">NHibernate, a different object with the same identifier value was already associated with the session</a> for more information.</remarks>
        public async override Task RefreshEntityContextAsync(TEntity entity, CancellationToken? cancellationToken = null)
        {
            await Context.EvictAsync(entity, cancellationToken.GetValueOrDefault());
        }

        /// <summary>
        /// Indicates the operation to perform.
        /// </summary>
        private enum RepositoryOperation : byte
        {
            Create = 0,
            Update = 1,
            Delete = 2
        }
    }
}
