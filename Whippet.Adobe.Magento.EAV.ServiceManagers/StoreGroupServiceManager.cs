using System;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.EAV.Repositories;
using Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IStoreGroup"/> domain objects.
    /// </summary>
    public class StoreGroupServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IStoreGroupRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IStoreGroupRepository GroupRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroupServiceManager"/> class with the specified <see cref="IStoreGroupRepository"/> object.
        /// </summary>
        /// <param name="groupRepository"><see cref="IStoreGroupRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StoreGroupServiceManager(IStoreGroupRepository groupRepository)
            : base()
        {
            if (groupRepository == null)
            {
                throw new ArgumentNullException(nameof(groupRepository));
            }
            else
            {
                GroupRepository = groupRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroupServiceManager"/> class with the specified <see cref="IStoreGroupRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="groupRepository"><see cref="IStoreGroupRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public StoreGroupServiceManager(IWhippetServiceContext serviceLocator, IStoreGroupRepository groupRepository)
            : base(serviceLocator)
        {
            if (groupRepository == null)
            {
                throw new ArgumentNullException(nameof(groupRepository));
            }
            else
            {
                GroupRepository = groupRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IStoreGroup"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IStoreGroup"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IStoreGroup>> GetGroup(ushort id)
        {
            IStoreGroupQueryHandler<GetStoreGroupByIdQuery> handler = new GetStoreGroupByIdQueryHandler(GroupRepository);
            WhippetResultContainer<IEnumerable<StoreGroup>> result = await handler.HandleAsync(new GetStoreGroupByIdQuery(id));
            return new WhippetResultContainer<IStoreGroup>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IStoreGroup"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IStoreGroup>>> GetGroups()
        {
            IStoreGroupQueryHandler<GetAllStoreGroupsQuery> handler = new GetAllStoreGroupsQueryHandler(GroupRepository);
            WhippetResultContainer<IEnumerable<StoreGroup>> result = await handler.HandleAsync(new GetAllStoreGroupsQuery());
            return new WhippetResultContainer<IEnumerable<IStoreGroup>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (GroupRepository != null)
            {
                GroupRepository.Dispose();
                GroupRepository = null;
            }

            base.Dispose();
        }
    }
}
