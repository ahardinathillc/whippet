using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Networking.Smtp.Repositories;
using Athi.Whippet.Networking.Smtp.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Networking.Smtp.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Networking.Smtp.ServiceManagers.Queries;
using Athi.Whippet.Networking.Smtp.ServiceManagers.Commands;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Networking.Smtp.Extensions;

namespace Athi.Whippet.Networking.Smtp.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IWhippetSmtpServerProfile"/> domain objects.
    /// </summary>
    public class WhippetSmtpServerProfileServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetSmtpServerProfileRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetSmtpServerProfileRepository ServerProfileRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfileServiceManager"/> class with the specified <see cref="IWhippetSmtpServerProfileRepository"/> object.
        /// </summary>
        /// <param name="profileRepository"><see cref="IWhippetSmtpServerProfileRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSmtpServerProfileServiceManager(IWhippetSmtpServerProfileRepository profileRepository)
            : base()
        {
            if (profileRepository == null)
            {
                throw new ArgumentNullException(nameof(profileRepository));
            }
            else
            {
                ServerProfileRepository = profileRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfileServiceManager"/> class with the specified <see cref="IWhippetSmtpServerProfileRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="profileRepository"><see cref="IWhippetSmtpServerProfileRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetSmtpServerProfileServiceManager(IWhippetServiceContext serviceLocator, IWhippetSmtpServerProfileRepository profileRepository)
            : base(serviceLocator)
        {
            if (profileRepository == null)
            {
                throw new ArgumentNullException(nameof(profileRepository));
            }
            else
            {
                ServerProfileRepository = profileRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IWhippetSmtpServerProfile"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IWhippetSmtpServerProfile"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetSmtpServerProfile>> GetServerProfile(Guid id)
        {
            IWhippetSmtpServerProfileQueryHandler<GetWhippetSmtpServerProfileByIdQuery> handler = new GetWhippetSmtpServerProfileByIdQueryHandler(ServerProfileRepository);
            WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>> result = await handler.HandleAsync(new GetWhippetSmtpServerProfileByIdQuery(id));
            return new WhippetResultContainer<IWhippetSmtpServerProfile>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets the default <see cref="IWhippetSmtpServerProfile"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSmtpServerProfile>> GetDefaultServerProfile(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IWhippetSmtpServerProfileQueryHandler<GetDefaultWhippetSmtpServerProfileQuery> handler = new GetDefaultWhippetSmtpServerProfileQueryHandler(ServerProfileRepository);
            WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>> result = await handler.HandleAsync(new GetDefaultWhippetSmtpServerProfileQuery(tenant));
            return new WhippetResultContainer<IWhippetSmtpServerProfile>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="IWhippetSmtpServerProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetSmtpServerProfile>>> GetServerProfilesForTenant(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IWhippetSmtpServerProfileQueryHandler<GetWhippetSmtpServerProfilesForTenantQuery> handler = new GetWhippetSmtpServerProfilesForTenantQueryHandler(ServerProfileRepository);
            WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>> result = await handler.HandleAsync(new GetWhippetSmtpServerProfilesForTenantQuery(tenant));
            return new WhippetResultContainer<IEnumerable<IWhippetSmtpServerProfile>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new SMTP profile entry.
        /// </summary>
        /// <param name="profile"><see cref="IWhippetSmtpServerProfile"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSmtpServerProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetSmtpServerProfile> CreateWhippetSmtpServerProfile(IWhippetSmtpServerProfile profile)
        {
            return Task<WhippetResultContainer<IWhippetSmtpServerProfile>>.Run(() => CreateWhippetSmtpServerProfileAsync(profile)).Result;
        }

        /// <summary>
        /// Creates a new SMTP profile entry.
        /// </summary>
        /// <param name="profile"><see cref="IWhippetSmtpServerProfile"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IWhippetSmtpServerProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSmtpServerProfile>> CreateWhippetSmtpServerProfileAsync(IWhippetSmtpServerProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateWhippetSmtpServerProfileCommand> handler = new CreateWhippetSmtpServerProfileCommandHandler(ServerProfileRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateWhippetSmtpServerProfileCommand(profile.ToWhippetSmtpServerProfile()));

                    if (result.IsSuccess)
                    {
                        await ServerProfileRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetSmtpServerProfile>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetSmtpServerProfile>(result, profile);
            }
        }

        /// <summary>
        /// Updates an existing store.
        /// </summary>
        /// <param name="profile"><see cref="IWhippetSmtpServerProfile"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetSmtpServerProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetSmtpServerProfile> UpdateWhippetSmtpServerProfile(IWhippetSmtpServerProfile profile)
        {
            return Task<WhippetResultContainer<IWhippetSmtpServerProfile>>.Run(() => UpdateWhippetSmtpServerProfileAsync(profile)).Result;
        }

        /// <summary>
        /// Updates an existing store.
        /// </summary>
        /// <param name="profile"><see cref="IWhippetSmtpServerProfile"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetSmtpServerProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSmtpServerProfile>> UpdateWhippetSmtpServerProfileAsync(IWhippetSmtpServerProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateWhippetSmtpServerProfileCommand> handler = new UpdateWhippetSmtpServerProfileCommandHandler(ServerProfileRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateWhippetSmtpServerProfileCommand(profile.ToWhippetSmtpServerProfile()));

                    if (result.IsSuccess)
                    {
                        await ServerProfileRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetSmtpServerProfile>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetSmtpServerProfile>(result, profile);
            }
        }

        /// <summary>
        /// Deletes an existing store.
        /// </summary>
        /// <param name="profile"><see cref="IWhippetSmtpServerProfile"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetSmtpServerProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetSmtpServerProfile> DeleteWhippetSmtpServerProfile(IWhippetSmtpServerProfile profile)
        {
            return Task<WhippetResultContainer<IWhippetSmtpServerProfile>>.Run(() => DeleteWhippetSmtpServerProfileAsync(profile)).Result;
        }

        /// <summary>
        /// Deletes an existing store.
        /// </summary>
        /// <param name="profile"><see cref="IWhippetSmtpServerProfile"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IWhippetSmtpServerProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetSmtpServerProfile>> DeleteWhippetSmtpServerProfileAsync(IWhippetSmtpServerProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteWhippetSmtpServerProfileCommand> handler = new DeleteWhippetSmtpServerProfileCommandHandler(ServerProfileRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteWhippetSmtpServerProfileCommand(profile.ToWhippetSmtpServerProfile()));

                    if (result.IsSuccess)
                    {
                        await ServerProfileRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetSmtpServerProfile>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetSmtpServerProfile>(result, profile);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (ServerProfileRepository != null)
            {
                ServerProfileRepository.Dispose();
                ServerProfileRepository = null;
            }

            base.Dispose();
        }
    }
}
