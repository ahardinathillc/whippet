using System;
using System.Collections.Generic;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Services;
using Athi.Whippet.Applications.Setup.Repositories;
using Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Applications.Setup.ServiceManagers.Queries;
using Athi.Whippet.Applications.Setup.ServiceManagers.Commands;
using Athi.Whippet.Applications.Setup.Extensions;

namespace Athi.Whippet.Applications.Setup.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IWhippetSettingGroup"/> domain objects.
    /// </summary>
    public class WhippetSettingGroupServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetSettingGroupRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetSettingGroupRepository GroupRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroupServiceManager"/> class with the specified <see cref="IWhippetSettingGroupRepository"/>.
        /// </summary>
        /// <param name="groupRepository"><see cref="IWhippetSettingGroupRepository"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSettingGroupServiceManager(IWhippetSettingGroupRepository groupRepository)
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
        /// Initializes a new instance of the <see cref="WhippetSettingGroupServiceManager"/> class with the specified <see cref="IWhippetSettingGroupRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="groupRepository"><see cref="IWhippetSettingGroupRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSettingGroupServiceManager(IWhippetServiceContext serviceLocator, IWhippetSettingGroupRepository groupRepository)
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
        /// Gets all <see cref="IWhippetSettingGroup"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetSettingGroup>>> GetWhippetSettingGroups()
        {
            GetAllWhippetSettingGroupsQueryHandler handler = new GetAllWhippetSettingGroupsQueryHandler(GroupRepository);
            WhippetResultContainer<IEnumerable<WhippetSettingGroup>> result = await handler.HandleAsync(new GetAllWhippetSettingGroupsQuery());
            return new WhippetResultContainer<IEnumerable<IWhippetSettingGroup>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets the <see cref="IWhippetSettingGroup"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IWhippetSettingGroup"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetSettingGroup>> GetWhippetSettingGroup(Guid id)
        {
            GetWhippetSettingGroupByIdQueryHandler handler = new GetWhippetSettingGroupByIdQueryHandler(GroupRepository);
            WhippetResultContainer<IEnumerable<WhippetSettingGroup>> result = await handler.HandleAsync(new GetWhippetSettingGroupByIdQuery(id));
            return new WhippetResultContainer<IWhippetSettingGroup>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets the <see cref="IWhippetSettingGroup"/> object with the specified <see cref="IWhippetSettingGroup.SettingGroupID"/> for a particular <see cref="IWhippetApplication"/>.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> object.</param>
        /// <param name="groupId"><see cref="IWhippetSettingGroup.SettingGroupID"/> value.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSettingGroup>> GetWhippetSettingGroup(IWhippetApplication application, Guid groupId)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }
            else
            {
                WhippetResultContainer<IWhippetSettingGroup> settingResult = null;
                WhippetResultContainer<IEnumerable<IWhippetSettingGroup>> settingsResult = null;

                try
                {
                    settingsResult = await GetWhippetSettingGroupsByApplication(application);
                    settingsResult.ThrowIfFailed();

                    settingResult = new WhippetResultContainer<IWhippetSettingGroup>(settingsResult.Result, settingsResult.HasItem ? settingsResult.Item.Where(s => s.SettingGroupID == groupId).FirstOrDefault() : null);
                }
                catch (Exception e)
                {
                    settingResult = new WhippetResultContainer<IWhippetSettingGroup>(e);
                }

                return settingResult;
            }

        }

        /// <summary>
        /// Retrieves all <see cref="IWhippetSettingGroup"/> objects that are associated with the specified <see cref="IWhippetApplication"/>.
        /// </summary>
        /// <param name="application"><see cref="IWhippetApplication"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetSettingGroup>>> GetWhippetSettingGroupsByApplication(IWhippetApplication application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }
            else
            {
                GetWhippetSettingGroupsByApplicationQueryHandler handler = new GetWhippetSettingGroupsByApplicationQueryHandler(GroupRepository);
                WhippetResultContainer<IEnumerable<WhippetSettingGroup>> result = await handler.HandleAsync(new GetWhippetSettingGroupsByApplicationQuery(application));
                return new WhippetResultContainer<IEnumerable<IWhippetSettingGroup>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new Whippet group entry.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSettingGroup"/> object.</returns>
        public virtual WhippetResultContainer<IWhippetSettingGroup> CreateWhippetSettingGroup(IWhippetSettingGroup group)
        {
            return Task<WhippetResultContainer<IWhippetSettingGroup>>.Run(() => CreateWhippetSettingGroupAsync(group)).Result;
        }

        /// <summary>
        /// Creates a new Whippet group entry.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSettingGroup"/> object.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetSettingGroup>> CreateWhippetSettingGroupAsync(IWhippetSettingGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateWhippetSettingGroupCommand> handler = new CreateWhippetSettingGroupCommandHandler(GroupRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateWhippetSettingGroupCommand(group.ToWhippetSettingGroup()));

                    if (result.IsSuccess)
                    {
                        await GroupRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetSettingGroup>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetSettingGroup>(result, group);
            }
        }

        /// <summary>
        /// Updates an existing Whippet group entry.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSettingGroup"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetSettingGroup> UpdateWhippetSettingGroup(IWhippetSettingGroup group)
        {
            return Task<WhippetResultContainer<IWhippetSettingGroup>>.Run(() => UpdateWhippetSettingGroupAsync(group)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet group entry.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSettingGroup"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSettingGroup>> UpdateWhippetSettingGroupAsync(IWhippetSettingGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateWhippetSettingGroupCommand> handler = new UpdateWhippetSettingGroupCommandHandler(GroupRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateWhippetSettingGroupCommand(group.ToWhippetSettingGroup()));

                    if (result.IsSuccess)
                    {
                        await GroupRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetSettingGroup>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetSettingGroup>(result, group);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet group entry.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetSettingGroup"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetSettingGroup> DeleteWhippetSettingGroup(IWhippetSettingGroup group)
        {
            return Task.Run(() => DeleteWhippetSettingGroupAsync(group)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet group entry.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetSettingGroup"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSettingGroup>> DeleteWhippetSettingGroupAsync(IWhippetSettingGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteWhippetSettingGroupCommand> handler = new DeleteWhippetSettingGroupCommandHandler(GroupRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteWhippetSettingGroupCommand(group.ToWhippetSettingGroup()));

                    if (result.IsSuccess)
                    {
                        await GroupRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetSettingGroup>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetSettingGroup>(result, group);
            }
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

