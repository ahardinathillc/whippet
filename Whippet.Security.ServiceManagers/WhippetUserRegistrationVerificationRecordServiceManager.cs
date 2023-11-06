using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Configuration;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Queries;
using Athi.Whippet.Security.ServiceManagers.Commands;
using Athi.Whippet.Security.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Security.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Security.Cryptography;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Repositories;

namespace Athi.Whippet.Security.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="WhippetUserRegistrationVerificationRecord"/> domain objects.
    /// </summary>
    public class WhippetUserRegistrationVerificationRecordServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetUserRegistrationVerificationRecordRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetUserRegistrationVerificationRecordRepository UserRegistrationVerificationRecordRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRegistrationVerificationRecordServiceManager"/> class with the specified <see cref="IWhippetUserRegistrationVerificationRecordRepository"/> object.
        /// </summary>
        /// <param name="registrationRepository"><see cref="IWhippetUserRegistrationVerificationRecordRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetUserRegistrationVerificationRecordServiceManager(IWhippetUserRegistrationVerificationRecordRepository registrationRepository)
            : base()
        {
            if (registrationRepository == null)
            {
                throw new ArgumentNullException(nameof(registrationRepository));
            }
            else
            {
                UserRegistrationVerificationRecordRepository = registrationRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRegistrationVerificationRecordServiceManager"/> class with the specified <see cref="IWhippetUserRegistrationVerificationRecordRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="registrationRepository"><see cref="IWhippetUserRegistrationVerificationRecordRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetUserRegistrationVerificationRecordServiceManager(IWhippetServiceContext serviceLocator, IWhippetUserRegistrationVerificationRecordRepository registrationRepository)
            : base(serviceLocator)
        {
            if (registrationRepository == null)
            {
                throw new ArgumentNullException(nameof(registrationRepository));
            }
            else
            {
                UserRegistrationVerificationRecordRepository = registrationRepository;
            }
        }

        /// <summary>
        /// Gets the <see cref="IWhippetUserRegistrationVerificationRecord"/> that matches the specified ID.
        /// </summary>
        /// <param name="verificationRecordId">ID of the <see cref="IWhippetUserRegistrationVerificationRecord"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>> GetUserRegistrationVerificationRecord(Guid verificationRecordId)
        {
            IWhippetUserRegistrationVerificationRecordQueryHandler<GetWhippetUserRegistrationVerificationRecordByIdQuery> handler = new GetWhippetUserRegistrationVerificationRecordByIdQueryHandler(UserRegistrationVerificationRecordRepository);
            WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>> result = await handler.HandleAsync(new GetWhippetUserRegistrationVerificationRecordByIdQuery(verificationRecordId));

            return new WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>(result.Result, result.Item?.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IWhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get the <see cref="IWhippetUserRegistrationVerificationRecord"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetUserRegistrationVerificationRecord>>> GetUserRegistrationVerificationRecords(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IWhippetUserRegistrationVerificationRecordQueryHandler<GetWhippetUserRegistrationVerificationRecordsForTenantQuery> handler = new GetWhippetUserRegistrationVerificationRecordsForTenantQueryHandler(UserRegistrationVerificationRecordRepository);
                WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>> result = await handler.HandleAsync(new GetWhippetUserRegistrationVerificationRecordsForTenantQuery(tenant));

                return new WhippetResultContainer<IEnumerable<IWhippetUserRegistrationVerificationRecord>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IWhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetUser"/> ID.
        /// </summary>
        /// <param name="userId">ID of the <see cref="IWhippetUser"/> to filter by or <see langword="null"/> to list all records that have not yet been activated.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<IWhippetUserRegistrationVerificationRecord>>> GetUserRegistrationVerificationRecordsForUser(Guid? userId)
        {
            IWhippetUserRegistrationVerificationRecordQueryHandler<GetWhippetUserRegistrationVerificationRecordsForUserQuery> handler = new GetWhippetUserRegistrationVerificationRecordsForUserQueryHandler(UserRegistrationVerificationRecordRepository);
            WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>> result = await handler.HandleAsync(new GetWhippetUserRegistrationVerificationRecordsForUserQuery(userId));

            return new WhippetResultContainer<IEnumerable<IWhippetUserRegistrationVerificationRecord>>(result.Result, result.Item);
        }

        /// <summary>
        /// Creates a new <see cref="IWhippetUserRegistrationVerificationRecord"/> object in the data store.
        /// </summary>
        /// <param name="userVerificationRecord"><see cref="IWhippetUserRegistrationVerificationRecord"/> object to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>> CreateUserRegistrationVerificationRecord(IWhippetUserRegistrationVerificationRecord userVerificationRecord)
        {
            if (userVerificationRecord == null)
            {
                throw new ArgumentNullException(nameof(userVerificationRecord));
            }
            else
            {
                WhippetResult createResult = null;
                WhippetResultContainer<IWhippetUserRegistrationVerificationRecord> queryResult = null;
                IWhippetCommandHandler<CreateWhippetUserRegistrationVerificationRecordCommand> handler = new CreateWhippetUserRegistrationVerificationRecordCommandHandler(UserRegistrationVerificationRecordRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateWhippetUserRegistrationVerificationRecordCommand(userVerificationRecord.ToWhippetUserRegistrationVerificationRecord()));

                    if (createResult.IsSuccess)
                    {
                        await UserRegistrationVerificationRecordRepository.CommitAsync();
                        queryResult = await GetUserRegistrationVerificationRecord(userVerificationRecord.ID);
                    }
                    else
                    {
                        queryResult = new WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>(createResult, userVerificationRecord);
                    }
                }
                catch (Exception e)
                {
                    queryResult = new WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>(new WhippetResult(e), userVerificationRecord);
                }

                return queryResult;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="IWhippetUserRegistrationVerificationRecord"/> object in the data store.
        /// </summary>
        /// <param name="userVerificationRecord"><see cref="IWhippetUserRegistrationVerificationRecord"/> object to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>> DeleteUserRegistrationVerificationRecord(IWhippetUserRegistrationVerificationRecord userVerificationRecord)
        {
            if (userVerificationRecord == null)
            {
                throw new ArgumentNullException(nameof(userVerificationRecord));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<DeleteWhippetUserRegistrationVerificationRecordCommand> handler = new DeleteWhippetUserRegistrationVerificationRecordCommandHandler(UserRegistrationVerificationRecordRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteWhippetUserRegistrationVerificationRecordCommand(userVerificationRecord.ToWhippetUserRegistrationVerificationRecord()));

                    if (updateResult.IsSuccess)
                    {
                        await UserRegistrationVerificationRecordRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>(updateResult, userVerificationRecord);
            }
        }

        /// <summary>
        /// Updates an existing <see cref="IWhippetUserRegistrationVerificationRecord"/> object in the data store.
        /// </summary>
        /// <param name="userVerificationRecord"><see cref="IWhippetUserRegistrationVerificationRecord"/> object to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>> UpdateUserRegistrationVerificationRecord(IWhippetUserRegistrationVerificationRecord userVerificationRecord)
        {
            if (userVerificationRecord == null)
            {
                throw new ArgumentNullException(nameof(userVerificationRecord));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateWhippetUserRegistrationVerificationRecordCommand> handler = new UpdateWhippetUserRegistrationVerificationRecordCommandHandler(UserRegistrationVerificationRecordRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateWhippetUserRegistrationVerificationRecordCommand(userVerificationRecord.ToWhippetUserRegistrationVerificationRecord()));

                    if (updateResult.IsSuccess)
                    {
                        await UserRegistrationVerificationRecordRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetUserRegistrationVerificationRecord>(updateResult, userVerificationRecord);
            }
        }

        /// <summary>
        /// Gets the account registration server specified in the application's configuration file.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> object that represents the configuration file.</param>
        /// <returns>URL of the account registration server.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetAuthenticationServerUrl(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            else
            {
                return configuration.GetSecuritySettingsSection()["AccountRegistrationServer"];
            }
        }
    }
}
