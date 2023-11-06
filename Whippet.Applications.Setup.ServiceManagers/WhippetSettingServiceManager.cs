using System;
using System.Collections.Generic;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Services;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Applications.Setup.Repositories;
using Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Applications.Setup.ServiceManagers.Queries;
using Athi.Whippet.Applications.Setup.ServiceManagers.Commands;
using Athi.Whippet.Applications.Setup.Extensions;

namespace Athi.Whippet.Applications.Setup.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IWhippetSetting"/> domain objects.
    /// </summary>
    public class WhippetSettingServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetSettingRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetSettingRepository SettingRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingServiceManager"/> class with the specified <see cref="IWhippetSettingRepository"/>.
        /// </summary>
        /// <param name="settingRepository"><see cref="IWhippetSettingRepository"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSettingServiceManager(IWhippetSettingRepository settingRepository)
            : base()
        {
            if (settingRepository == null)
            {
                throw new ArgumentNullException(nameof(settingRepository));
            }
            else
            {
                SettingRepository = settingRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingServiceManager"/> class with the specified <see cref="IWhippetSettingRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="settingRepository"><see cref="IWhippetSettingRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSettingServiceManager(IWhippetServiceContext serviceLocator, IWhippetSettingRepository settingRepository)
            : base(serviceLocator)
        {
            if (settingRepository == null)
            {
                throw new ArgumentNullException(nameof(settingRepository));
            }
            else
            {
                SettingRepository = settingRepository;
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetSetting"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetSetting>>> GetWhippetSettings()
        {
            GetAllWhippetSettingsQueryHandler handler = new GetAllWhippetSettingsQueryHandler(SettingRepository);
            WhippetResultContainer<IEnumerable<WhippetSetting>> result = await handler.HandleAsync(new GetAllWhippetSettingsQuery());
            return new WhippetResultContainer<IEnumerable<IWhippetSetting>>(result.Result, result.Item);
        }

        /// <summary>
        /// Gets the <see cref="IWhippetSetting"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IWhippetSetting"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetSetting>> GetWhippetSetting(Guid id)
        {
            GetWhippetSettingByIdQueryHandler handler = new GetWhippetSettingByIdQueryHandler(SettingRepository);
            WhippetResultContainer<IEnumerable<WhippetSetting>> result = await handler.HandleAsync(new GetWhippetSettingByIdQuery(id));
            return new WhippetResultContainer<IWhippetSetting>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets the <see cref="IWhippetSetting"/> object with the specified <see cref="IWhippetSetting.SettingID"/> for a particular <see cref="IWhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> object.</param>
        /// <param name="settingId"><see cref="IWhippetSetting.SettingID"/> value.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSetting>> GetWhippetSetting(IWhippetSettingGroup group, Guid settingId)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetResultContainer<IWhippetSetting> settingResult = null;
                WhippetResultContainer<IEnumerable<IWhippetSetting>> settingsResult = null;

                try
                {
                    settingsResult = await GetWhippetSettingsByGroup(group);
                    settingsResult.ThrowIfFailed();

                    if (settingsResult.HasItem)
                    {
                        settingResult = new WhippetResultContainer<IWhippetSetting>(settingsResult.Result, settingsResult.Item.Where(s => s.SettingID == settingId).FirstOrDefault());
                    }
                    else
                    {
                        settingResult = new WhippetResultContainer<IWhippetSetting>(settingsResult.Result, null);
                    }
                }
                catch (Exception e)
                {
                    settingResult = new WhippetResultContainer<IWhippetSetting>(e);
                }

                return settingResult;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="IWhippetSetting"/> objects that are associated with the specified <see cref="IWhippetSettingGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetSettingGroup"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetSetting>>> GetWhippetSettingsByGroup(IWhippetSettingGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                GetWhippetSettingsByGroupQueryHandler handler = new GetWhippetSettingsByGroupQueryHandler(SettingRepository);
                WhippetResultContainer<IEnumerable<WhippetSetting>> result = await handler.HandleAsync(new GetWhippetSettingsByGroupQuery(group));
                return new WhippetResultContainer<IEnumerable<IWhippetSetting>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a new Whippet setting entry.
        /// </summary>
        /// <param name="setting"><see cref="IWhippetSetting"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSetting"/> object.</returns>
        public virtual WhippetResultContainer<IWhippetSetting> CreateWhippetSetting(IWhippetSetting setting)
        {
            return Task<WhippetResultContainer<IWhippetSetting>>.Run(() => CreateWhippetSettingAsync(setting)).Result;
        }

        /// <summary>
        /// Creates a new Whippet setting entry.
        /// </summary>
        /// <param name="setting"><see cref="IWhippetSetting"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSetting"/> object.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetSetting>> CreateWhippetSettingAsync(IWhippetSetting setting)
        {
            if (setting == null)
            {
                throw new ArgumentNullException(nameof(setting));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateWhippetSettingCommand> handler = new CreateWhippetSettingCommandHandler(SettingRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateWhippetSettingCommand(setting.ToWhippetSetting()));

                    if (result.IsSuccess)
                    {
                        await SettingRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetSetting>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetSetting>(result, setting);
            }
        }

        /// <summary>
        /// Updates an existing Whippet setting entry.
        /// </summary>
        /// <param name="setting"><see cref="IWhippetSetting"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSetting"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetSetting> UpdateWhippetSetting(IWhippetSetting setting)
        {
            return Task<WhippetResultContainer<IWhippetSetting>>.Run(() => UpdateWhippetSettingAsync(setting)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet setting entry.
        /// </summary>
        /// <param name="setting"><see cref="IWhippetSetting"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSetting"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSetting>> UpdateWhippetSettingAsync(IWhippetSetting setting)
        {
            if (setting == null)
            {
                throw new ArgumentNullException(nameof(setting));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateWhippetSettingCommand> handler = new UpdateWhippetSettingCommandHandler(SettingRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateWhippetSettingCommand(setting.ToWhippetSetting()));

                    if (result.IsSuccess)
                    {
                        await SettingRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetSetting>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetSetting>(result, setting);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet setting entry.
        /// </summary>
        /// <param name="setting"><see cref="IWhippetSetting"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetSetting"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetSetting> DeleteWhippetSetting(IWhippetSetting setting)
        {
            return Task.Run(() => DeleteWhippetSettingAsync(setting)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet setting entry.
        /// </summary>
        /// <param name="setting"><see cref="IWhippetSetting"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetSetting"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSetting>> DeleteWhippetSettingAsync(IWhippetSetting setting)
        {
            if (setting == null)
            {
                throw new ArgumentNullException(nameof(setting));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteWhippetSettingCommand> handler = new DeleteWhippetSettingCommandHandler(SettingRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteWhippetSettingCommand(setting.ToWhippetSetting()));

                    if (result.IsSuccess)
                    {
                        await SettingRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetSetting>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetSetting>(result, setting);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (SettingRepository != null)
            {
                SettingRepository.Dispose();
                SettingRepository = null;
            }

            base.Dispose();
        }
    }
}

