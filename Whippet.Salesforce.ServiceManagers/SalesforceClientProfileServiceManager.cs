using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Salesforce.Common;
using Salesforce.Force;
using Athi.Whippet;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Salesforce.ServiceManagers.Queries;
using Athi.Whippet.Salesforce.ServiceManagers.Commands;
using Athi.Whippet.Salesforce.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Salesforce.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Salesforce.Repositories;
using Athi.Whippet.Salesforce.Extensions;

namespace Athi.Whippet.Salesforce.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ISalesforceClientProfile"/> domain objects.
    /// </summary>
    public class SalesforceClientProfileServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesforceClientProfileRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesforceClientProfileRepository ProfileRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClientProfileServiceManager"/> class with the specified <see cref="ISalesForceClientProfileRepository"/> object.
        /// </summary>
        /// <param name="profileRepository"><see cref="ISalesForceClientProfileRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceClientProfileServiceManager(ISalesforceClientProfileRepository profileRepository)
            : base()
        {
            if (profileRepository == null)
            {
                throw new ArgumentNullException(nameof(profileRepository));
            }
            else
            {
                ProfileRepository = profileRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClientProfileServiceManager"/> class with the specified <see cref="ISalesForceClientProfileRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="profileRepository"><see cref="ISalesForceClientProfileRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceClientProfileServiceManager(IWhippetServiceContext serviceLocator, ISalesforceClientProfileRepository profileRepository)
            : base(serviceLocator)
        {
            if (profileRepository == null)
            {
                throw new ArgumentNullException(nameof(profileRepository));
            }
            else
            {
                ProfileRepository = profileRepository;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesforceClientProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesforceClientProfile>>> GetSalesforceClientProfiles(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                ISalesforceClientProfileQueryHandler<GetAllSalesforceClientProfilesForTenantQuery> handler = new GetAllSalesforceClientProfilesForTenantQueryHandler(ProfileRepository);
                WhippetResultContainer<IEnumerable<SalesforceClientProfile>> result = await handler.HandleAsync(new GetAllSalesforceClientProfilesForTenantQuery(tenant));

                return new WhippetResultContainer<IEnumerable<ISalesforceClientProfile>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets the <see cref="ISalesforceClientProfile"/> object with the specified name.
        /// </summary>
        /// <param name="profileName">Name of the <see cref="ISalesforceClientProfile"/> to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the <see cref="ISalesforceClientProfile"/> is registered with.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<ISalesforceClientProfile>> GetSalesforceClientProfile(string profileName, IWhippetTenant tenant)
        {
            if (String.IsNullOrWhiteSpace(profileName))
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                ISalesforceClientProfileQueryHandler<GetSalesforceClientProfileByNameQuery> handler = new GetSalesforceClientProfileByNameQueryHandler(ProfileRepository);
                WhippetResultContainer<IEnumerable<SalesforceClientProfile>> result = await handler.HandleAsync(new GetSalesforceClientProfileByNameQuery(profileName, tenant));

                return new WhippetResultContainer<ISalesforceClientProfile>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets the <see cref="ISalesforceClientProfile"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesforceClientProfile"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesforceClientProfile>> GetSalesforceClientProfile(Guid id)
        {
            ISalesforceClientProfileQueryHandler<GetSalesforceClientProfileByIdQuery> handler = new GetSalesforceClientProfileByIdQueryHandler(ProfileRepository);
            WhippetResultContainer<IEnumerable<SalesforceClientProfile>> result = await handler.HandleAsync(new GetSalesforceClientProfileByIdQuery(id));

            return new WhippetResultContainer<ISalesforceClientProfile>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Creates a new Salesforce client profile entry.
        /// </summary>
        /// <param name="profile"><see cref="ISalesforceClientProfile"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceClientProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceClientProfile> CreateSalesforceClientProfile(ISalesforceClientProfile profile)
        {
            return Task<WhippetResultContainer<ISalesforceClientProfile>>.Run(() => CreateSalesforceClientProfileAsync(profile)).Result;
        }

        /// <summary>
        /// Creates a new Salesforce client profile entry.
        /// </summary>
        /// <param name="profile"><see cref="ISalesforceClientProfile"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="ISalesforceClientProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceClientProfile>> CreateSalesforceClientProfileAsync(ISalesforceClientProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateSalesforceClientProfileCommand> handler = new CreateSalesforceClientProfileCommandHandler(ProfileRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateSalesforceClientProfileCommand(profile.ToSalesforceClientProfile()));

                    if (result.IsSuccess)
                    {
                        await ProfileRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceClientProfile>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceClientProfile>(result, profile);
            }
        }

        /// <summary>
        /// Updates an existing Salesforce client profile entry.
        /// </summary>
        /// <param name="profile"><see cref="ISalesforceClientProfile"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceClientProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceClientProfile> UpdateSalesforceClientProfile(ISalesforceClientProfile profile)
        {
            return Task<WhippetResultContainer<ISalesforceClientProfile>>.Run(() => UpdateSalesforceClientProfileAsync(profile)).Result;
        }

        /// <summary>
        /// Updates an existing Salesforce client profile entry.
        /// </summary>
        /// <param name="profile"><see cref="ISalesforceClientProfile"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated <see cref="ISalesforceClientProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceClientProfile>> UpdateSalesforceClientProfileAsync(ISalesforceClientProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateSalesforceClientProfileCommand> handler = new UpdateSalesforceClientProfileCommandHandler(ProfileRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateSalesforceClientProfileCommand(profile.ToSalesforceClientProfile()));

                    if (result.IsSuccess)
                    {
                        await ProfileRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceClientProfile>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceClientProfile>(result, profile);
            }
        }

        /// <summary>
        /// Deletes an existing Salesforce client profile entry.
        /// </summary>
        /// <param name="profile"><see cref="ISalesforceClientProfile"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceClientProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<ISalesforceClientProfile> DeleteSalesforceClientProfile(ISalesforceClientProfile profile)
        {
            return Task<WhippetResultContainer<ISalesforceClientProfile>>.Run(() => DeleteSalesforceClientProfileAsync(profile)).Result;
        }

        /// <summary>
        /// Deletes an existing Salesforce client profile entry.
        /// </summary>
        /// <param name="profile"><see cref="ISalesforceClientProfile"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted <see cref="ISalesforceClientProfile"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<ISalesforceClientProfile>> DeleteSalesforceClientProfileAsync(ISalesforceClientProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteSalesforceClientProfileCommand> handler = new DeleteSalesforceClientProfileCommandHandler(ProfileRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteSalesforceClientProfileCommand(profile.ToSalesforceClientProfile()));

                    if (result.IsSuccess)
                    {
                        await ProfileRepository.CommitAsync();
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<ISalesforceClientProfile>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<ISalesforceClientProfile>(result, profile);
            }
        }

        /// <summary>
        /// Creates a new <see cref="AuthenticationClient"/> instance and connects to the Salesforce cloud with the <see cref="ISalesforceClientProfile"/> credentials.
        /// </summary>
        /// <param name="profile"><see cref="ISalesforceClientProfile"/> that contains the credentials needed to authenticate the application against the Salesforce API.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IAuthenticationClient>> CreateAuthenticationClient(ISalesforceClientProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            else
            {
                WhippetResultContainer<IAuthenticationClient> clientResult = null;

                AuthenticationClient client = null;

                try
                {
                    client = new AuthenticationClient();

                    if (String.IsNullOrWhiteSpace(profile.Url))
                    {
                        await client.UsernamePasswordAsync(profile.ConsumerKey, profile.ConsumerSecret, profile.Username, profile.Password);
                    }
                    else
                    {
                        await client.UsernamePasswordAsync(profile.ConsumerKey, profile.ConsumerSecret, profile.Username, profile.Password, profile.Url);
                    }

                    clientResult = new WhippetResultContainer<IAuthenticationClient>(WhippetResult.Success, client);
                }
                catch (Exception e)
                {
                    clientResult = new WhippetResultContainer<IAuthenticationClient>(new WhippetResult(e), client);
                }

                return clientResult;
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (ProfileRepository != null)
            {
                ProfileRepository.Dispose();
                ProfileRepository = null;
            }

            base.Dispose();
        }
    }
}
