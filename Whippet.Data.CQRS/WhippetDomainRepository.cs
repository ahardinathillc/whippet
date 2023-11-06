using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.EventManagement;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Repository for all <see cref="WhippetAggregateRoot"/> objects.
    /// </summary>
    public class WhippetDomainRepository : IWhippetDomainRepository
    {
        /// <summary>
        /// Gets or sets the event bus.
        /// </summary>
        protected IWhippetEventBus EventBus
        { get; private set; }

        /// <summary>
        /// Gets or sets the event store.
        /// </summary>
        protected IWhippetDomainEventStore EventStore
        { get; private set; }

        /// <summary>
        /// Gets or sets the snapshot store.
        /// </summary>
        protected IWhippetDomainEventSnapshotStore SnapshotStore
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainRepository"/> class with no arguments.
        /// </summary>
        protected WhippetDomainRepository()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetDomainRepository"/> class with the specified parameters.
        /// </summary>
        /// <param name="eventStore">Event store.</param>
        /// <param name="snapshotStore">Snapshot store.</param>
        /// <param name="eventBus">Event bus.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetDomainRepository(IWhippetDomainEventStore eventStore, IWhippetDomainEventSnapshotStore snapshotStore, IWhippetEventBus eventBus)
            : this()
        {
            if(eventStore == null)
            {
                throw new ArgumentNullException(nameof(eventStore));
            }
            else if(snapshotStore == null)
            {
                throw new ArgumentNullException(nameof(snapshotStore));
            }
            else if(eventBus == null)
            {
                throw new ArgumentNullException(nameof(eventBus));
            }
            else
            {
                EventStore = eventStore;
                SnapshotStore = snapshotStore;
                EventBus = eventBus;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="WhippetAggregateRoot"/> with the specified ID.
        /// </summary>
        /// <typeparam name="TAggregateRoot">Type of <see cref="WhippetAggregateRoot"/> to return.</typeparam>
        /// <param name="aggregateRootId">Aggregate root ID.</param>
        /// <param name="throwOnNotFound">Throws an exception if the <typeparamref name="TAggregateRoot"/> object could not be loaded based on the specified ID.</param>
        /// <returns><see cref="WhippetAggregateRoot"/> object.</returns>
        /// <exception cref="AggregateNotFoundException" />
        public virtual TAggregateRoot Get<TAggregateRoot>(Guid aggregateRootId, bool throwOnNotFound = false) where TAggregateRoot : WhippetAggregateRoot, new()
        {
            TAggregateRoot aggregateRoot = new TAggregateRoot();
            IWhippetDomainEventSnapshotOriginator snapOrigin = null;

            WhippetDomainEventSnapshot snapshot = SnapshotStore.GetSnapshot(aggregateRootId);

            int lastEventSequence = (snapshot == null || !(aggregateRoot is IWhippetDomainEventSnapshotOriginator)) ? 0 : snapshot.LastEventSequence;

            IEnumerable<WhippetDomainEvent> domainEvents = EventStore.GetEvents(aggregateRootId, lastEventSequence);

            if(lastEventSequence != 0 && (domainEvents != null && domainEvents.Any()))
            {
                if (snapshot != null)
                {
                    snapOrigin = aggregateRoot as IWhippetDomainEventSnapshotOriginator;

                    if (snapOrigin != null)
                    {
                        snapOrigin.LoadSnapshot(snapshot);
                        aggregateRoot.ID = snapshot.AggregateRootID;
                        snapshot.LastEventSequence = aggregateRoot.LastEventSequence;

                        SnapshotStore.SaveSnapshot(snapshot);
                    }
                }

                aggregateRoot.ApplyHistorical(domainEvents);
            }
            else
            {
                if (throwOnNotFound)
                {
                    throw new AggregateNotFoundException(aggregateRootId);
                }
                else
                {
                    aggregateRoot = null;
                }
            }

            return aggregateRoot;
        }

        /// <summary>
        /// Saves the specified <see cref="WhippetAggregateRoot"/> to the data store.
        /// </summary>
        /// <param name="aggregateRoot"><see cref="WhippetAggregateRoot"/> object to save.</param>
        /// <exception cref="ArgumentNullException" />
        public virtual void Save(WhippetAggregateRoot aggregateRoot)
        {
            if(aggregateRoot == null)
            {
                throw new ArgumentNullException(nameof(aggregateRoot));
            }
            else
            {
                IWhippetDomainEventSnapshotOriginator snapOrigin = null;
                
                WhippetDomainEventSnapshot previousSnap = null;
                WhippetDomainEventSnapshot snap = null;

                if(aggregateRoot.UncommittedEvents.Any())
                {
                    EventStore.Append(aggregateRoot.UncommittedEvents);
                    EventBus.PublishEvents(aggregateRoot.UncommittedEvents);

                    aggregateRoot.CommitEvents();

                    snapOrigin = aggregateRoot as IWhippetDomainEventSnapshotOriginator;
                    
                    if(snapOrigin != null)
                    {
                        previousSnap = SnapshotStore.GetSnapshot(aggregateRoot.ID);

                        if(snapOrigin.ShouldTakeSnapshot(previousSnap))
                        {
                            snap = snapOrigin.GetSnapshot();
                            snap.AggregateRootID = aggregateRoot.ID;
                            snap.LastEventSequence = aggregateRoot.LastEventSequence;

                            SnapshotStore.SaveSnapshot(snap);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<WhippetAggregateRoot, Guid>.Create(WhippetAggregateRoot item)
        {
            WhippetResult result = WhippetResult.Success;

            try
            {
                Save(item);
            }
            catch(Exception e)
            {
                result = new WhippetResult(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to save in the data store.</param>
        /// <param name="cancellationToken">Flag to signal to the <see cref="Task{TResult}"/> to stop at the next earliest convenience.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        Task<WhippetResult> IWhippetRepository<WhippetAggregateRoot, Guid>.CreateAsync(WhippetAggregateRoot item, CancellationToken? cancellationToken)
        {
            return new Task<WhippetResult>(() =>
            {
                return ((IWhippetRepository<WhippetAggregateRoot, Guid>)(this)).Create(item);
            });
        }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetDetachedRepository<WhippetAggregateRoot>.Create(WhippetAggregateRoot item)
        {
            return ((IWhippetRepository<WhippetAggregateRoot, Guid>)(this)).Create(item);
        }

        /// <summary>
        /// Asynchronously creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to save in the data store.</param>
        /// <param name="cancellationToken">Flag to signal to the <see cref="Task{TResult}"/> to stop at the next earliest convenience.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        async Task<WhippetResult> IWhippetDetachedRepository<WhippetAggregateRoot>.CreateAsync(WhippetAggregateRoot item, CancellationToken? cancellationToken)
        {
            return await ((IWhippetRepository<WhippetAggregateRoot, Guid>)(this)).CreateAsync(item, cancellationToken);
        }

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        /// <exception cref="NotSupportedException" />
        WhippetResult IWhippetRepository<WhippetAggregateRoot, Guid>.Update(WhippetAggregateRoot item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Asynchronously updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to update in the data store.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="NotSupportedException" />
        Task<WhippetResult> IWhippetRepository<WhippetAggregateRoot, Guid>.UpdateAsync(WhippetAggregateRoot item, CancellationToken? cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        /// <exception cref="NotSupportedException" />
        WhippetResult IWhippetRepository<WhippetAggregateRoot, Guid>.Delete(WhippetAggregateRoot item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        /// <exception cref="NotSupportedException" />
        WhippetResult IWhippetRepository<WhippetAggregateRoot, Guid>.Delete(WhippetAggregateRoot item, bool hardDelete)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to delete in the data store.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="NotSupportedException" />
        Task<WhippetResult> IWhippetRepository<WhippetAggregateRoot, Guid>.DeleteAsync(WhippetAggregateRoot item, CancellationToken? cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <see cref="WhippetAggregateRoot"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="NotSupportedException" />
        Task<WhippetResult> IWhippetRepository<WhippetAggregateRoot, Guid>.DeleteAsync(WhippetAggregateRoot item, bool hardDelete, CancellationToken? cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <typeparam name="TDetachedKey">Type of key the entity uses.</typeparam>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        WhippetResultContainer<WhippetAggregateRoot> IWhippetDetachedRepository<WhippetAggregateRoot>.Get<TDetachedKey>(TDetachedKey key)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <typeparam name="TDetachedKey">Type of key the entity uses.</typeparam>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        Task<WhippetResultContainer<WhippetAggregateRoot>> IWhippetDetachedRepository<WhippetAggregateRoot>.GetAsync<TDetachedKey>(TDetachedKey key, CancellationToken? cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{WhippetAggregateRoot}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="NotSupportedException" />
        WhippetResultContainer<WhippetAggregateRoot> IWhippetRepository<WhippetAggregateRoot, Guid>.Get(Guid key)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Retrieves all items of <see cref="WhippetAggregateRoot"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{WhippetAggregateRoot}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        /// <exception cref="NotSupportedException" />
        WhippetResultContainer<IEnumerable<WhippetAggregateRoot>> IWhippetRepository<WhippetAggregateRoot, Guid>.GetAll()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{WhippetAggregateRoot}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="NotSupportedException" />
        Task<WhippetResultContainer<WhippetAggregateRoot>> IWhippetRepository<WhippetAggregateRoot, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Asynchronously retrieves all items of <see cref="WhippetAggregateRoot"/> type in the data store.
        /// </summary>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{WhippetAggregateRoot}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="NotSupportedException" />
        Task<WhippetResultContainer<IEnumerable<WhippetAggregateRoot>>> IWhippetRepository<WhippetAggregateRoot, Guid>.GetAllAsync(CancellationToken? cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        void IWhippetRepository<WhippetAggregateRoot, Guid>.Commit()
        { }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetRepository<WhippetAggregateRoot, Guid>.CommitAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                return;
            });
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        void IWhippetRepository<WhippetAggregateRoot, Guid>.RefreshEntityContext(WhippetAggregateRoot entity)
        { }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetRepository<WhippetAggregateRoot, Guid>.RefreshEntityContextAsync(WhippetAggregateRoot entity, CancellationToken? cancellationToken)
        {
            await Task.Run(() =>
            {
                return;
            });
        }

        WhippetResult IWhippetDetachedRepository<WhippetAggregateRoot>.Update(WhippetAggregateRoot item)
        {
            throw new NotImplementedException();
        }

        Task<WhippetResult> IWhippetDetachedRepository<WhippetAggregateRoot>.UpdateAsync(WhippetAggregateRoot item, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        WhippetResult IWhippetDetachedRepository<WhippetAggregateRoot>.Delete(WhippetAggregateRoot item)
        {
            throw new NotImplementedException();
        }

        WhippetResult IWhippetDetachedRepository<WhippetAggregateRoot>.Delete(WhippetAggregateRoot item, bool hardDelete)
        {
            throw new NotImplementedException();
        }

        Task<WhippetResult> IWhippetDetachedRepository<WhippetAggregateRoot>.DeleteAsync(WhippetAggregateRoot item, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<WhippetResult> IWhippetDetachedRepository<WhippetAggregateRoot>.DeleteAsync(WhippetAggregateRoot item, bool hardDelete, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        WhippetResultContainer<IEnumerable<WhippetAggregateRoot>> IWhippetDetachedRepository<WhippetAggregateRoot>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<WhippetResultContainer<IEnumerable<WhippetAggregateRoot>>> IWhippetDetachedRepository<WhippetAggregateRoot>.GetAllAsync(CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        void IWhippetDetachedRepository<WhippetAggregateRoot>.Commit()
        {
            throw new NotImplementedException();
        }

        Task IWhippetDetachedRepository<WhippetAggregateRoot>.CommitAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
