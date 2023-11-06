using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Services;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.ServiceManagers.Queries;
using Athi.Whippet.Security.ServiceManagers.Commands;
using Athi.Whippet.Security.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Security.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Security.Cryptography;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.Repositories;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IWhippetUser"/> domain objects.
    /// </summary>
    public class WhippetUserServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IWhippetUserRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IWhippetUserRepository UserRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserServiceManager"/> class with the specified <see cref="IWhippetUserRepository"/> object.
        /// </summary>
        /// <param name="userRepository"><see cref="IWhippetUserRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetUserServiceManager(IWhippetUserRepository userRepository)
            : base()
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }
            else
            {
                UserRepository = userRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserServiceManager"/> class with the specified <see cref="IWhippetUserRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="userRepository"><see cref="IWhippetUserRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetUserServiceManager(IWhippetServiceContext serviceLocator, IWhippetUserRepository userRepository)
            : base(serviceLocator)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }
            else
            {
                UserRepository = userRepository;
            }
        }

        /// <summary>
        /// Gets an available <see cref="IWhippetUser"/> based on the specified username and password.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="password">Password of the user. This value can be encrypted or plain text.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetUser>> GetWhippetUser(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }
            else if (String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            else
            {
                IWhippetUserQueryHandler<GetWhippetUserByUserNameQuery> handler = new GetWhippetUserByUserNameQueryHandler(UserRepository);
                WhippetResultContainer<IEnumerable<WhippetUser>> result = await handler.HandleAsync(new GetWhippetUserByUserNameAndPasswordQuery(username, password));

                return new WhippetResultContainer<IWhippetUser>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets an available <see cref="IWhippetUser"/> based on the specified username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetUser>> GetWhippetUser(string username)
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }
            else
            {
                GetWhippetUserByUserNameQueryHandler handler = new GetWhippetUserByUserNameQueryHandler(UserRepository);
                WhippetResultContainer<IEnumerable<WhippetUser>> result = await handler.HandleAsync(new GetWhippetUserByUserNameQuery(username));
                return new WhippetResultContainer<IWhippetUser>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets an available <see cref="IWhippetUser"/> based on the user ID.
        /// </summary>
        /// <param name="id">User ID of the user to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetUser>> GetWhippetUser(Guid id)
        {
            GetWhippetUserByIdQueryHandler handler = new GetWhippetUserByIdQueryHandler(UserRepository);
            WhippetResultContainer<IEnumerable<WhippetUser>> result = await handler.HandleAsync(new GetWhippetUserByIdQuery(id));
            return new WhippetResultContainer<IWhippetUser>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Creates a new Whippet user.
        /// </summary>
        /// <param name="user">User to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created user.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetUser> CreateWhippetUser(IWhippetUser user)
        {
            return Task<WhippetResultContainer<IWhippetUser>>.Run(() => CreateWhippetUserAsync(user)).Result;
        }

        /// <summary>
        /// Creates a new Whippet user.
        /// </summary>
        /// <param name="user">User to create.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the newly created user.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetUser>> CreateWhippetUserAsync(IWhippetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetResult createResult = null;
                IWhippetCommandHandler<CreateWhippetUserCommand> handler = new CreateWhippetUserCommandHandler(UserRepository);

                try
                {
                    createResult = await handler.HandleAsync(new CreateWhippetUserCommand(user.ToWhippetUser()));

                    if (createResult.IsSuccess)
                    {
                        await UserRepository.CommitAsync();
                        createResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    createResult = new WhippetResultContainer<IWhippetUser>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetUser>(createResult, user);
            }
        }

        /// <summary>
        /// Updates an existing Whippet user.
        /// </summary>
        /// <param name="user">User to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated user.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetUser> UpdateWhippetUser(IWhippetUser user)
        {
            return Task<WhippetResultContainer<IWhippetUser>>.Run(() => UpdateWhippetUserAsync(user)).Result;
        }

        /// <summary>
        /// Updates an existing Whippet user.
        /// </summary>
        /// <param name="user">User to update.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the updated user.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetUser>> UpdateWhippetUserAsync(IWhippetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<UpdateWhippetUserCommand> handler = new UpdateWhippetUserCommandHandler(UserRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new UpdateWhippetUserCommand(user.ToWhippetUser()));

                    if (updateResult.IsSuccess)
                    {
                        await UserRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetUser>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetUser>(updateResult, user);
            }
        }

        /// <summary>
        /// Deletes an existing Whippet user.
        /// </summary>
        /// <param name="user">User to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted user.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IWhippetUser> DeleteWhippetUser(IWhippetUser user)
        {
            return Task<WhippetResultContainer<IWhippetUser>>.Run(() => DeleteWhippetUserAsync(user)).Result;
        }

        /// <summary>
        /// Deletes an existing Whippet user.
        /// </summary>
        /// <param name="user">User to delete.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the deleted user.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IWhippetUser>> DeleteWhippetUserAsync(IWhippetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetResult updateResult = null;
                IWhippetCommandHandler<DeleteWhippetUserCommand> handler = new DeleteWhippetUserCommandHandler(UserRepository);

                try
                {
                    updateResult = await handler.HandleAsync(new DeleteWhippetUserCommand(user.ToWhippetUser()));

                    if (updateResult.IsSuccess)
                    {
                        await UserRepository.CommitAsync();
                        updateResult = WhippetResult.Success;
                    }
                }
                catch (Exception e)
                {
                    updateResult = new WhippetResultContainer<IWhippetUser>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IWhippetUser>(updateResult, user);
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (UserRepository != null)
            {
                UserRepository.Dispose();
                UserRepository = null;
            }

            base.Dispose();
        }

        /// <summary>
        /// Authenticates the <see cref="IWhippetUser"/> based on a supplied encrypted password.
        /// </summary>
        /// <param name="suppliedPassword"><see cref="SaltValuePair"/> that contains the encrypted password supplied from the user and the master key used to decrypt the values.</param>
        /// <param name="user"><see cref="IWhippetUser"/> retrieved from the data store to compare the values with and to check other flags on the account for authentication.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that is used for IP address blacklist checking. If <see langword="null"/>, then the IP blacklist check will check all entries.</param>
        /// <param name="ipBlacklistCheckFunction"><see cref="Func{T1, T2, TResult}"/> that checks to see if the user's IP address is blacklisted.</param>
        /// <returns><see cref="WhippetUserAuthenticationResponse"/> value.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetUserAuthenticationResponse> Authenticate(SaltValuePair suppliedPassword, IWhippetUser user, IWhippetTenant tenant = null, Func<Task<WhippetResultContainer<IEnumerable<IWhippetIpAddressBlacklist>>>> ipBlacklistCheckFunction = null)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetUserAuthenticationResponseStatus response = WhippetUserAuthenticationResponseStatus.Success;

                IEnumerable<IWhippetIpAddressBlacklist> filteredResults = null;

                WhippetResultContainer<IEnumerable<IWhippetIpAddressBlacklist>> blacklistResult = null;

                WhippetSecureArray<byte> secureSuppliedValue = null;
                WhippetSecureArray<byte> secureUserValue = null;

                // we need to get rid of these values as soon as possible so they don't linger in memory

                byte[] suppliedValue = WhippetCryptography.Decrypt(suppliedPassword.MasterKey, suppliedPassword.Value, suppliedPassword.Salt);
                byte[] userValue = WhippetCryptography.Decrypt(suppliedPassword.MasterKey, Convert.FromHexString(user.Password), suppliedPassword.Salt);

                try
                {
                    if (suppliedValue == null || userValue == null || suppliedValue.Length == 0 || userValue.Length == 0)
                    {
                        response = WhippetUserAuthenticationResponseStatus.Fail_InvalidPassword;
                    }
                    else
                    {
                        secureSuppliedValue = WhippetSecureArray<byte>.CreateBestAttempt(suppliedValue.Length, null);
                        secureUserValue = WhippetSecureArray<byte>.CreateBestAttempt(userValue.Length, null);

                        secureSuppliedValue.CopyFromArray(suppliedValue);
                        secureUserValue.CopyFromArray(userValue);

                        Array.Clear(suppliedValue);
                        Array.Clear(userValue);

                        suppliedValue = null;
                        userValue = null;

                        if (!secureSuppliedValue.Equals(secureUserValue))
                        {
                            response = WhippetUserAuthenticationResponseStatus.Fail_InvalidPassword;
                        }
                        else
                        {
                            // check other flags

                            if (user.Deleted)
                            {
                                response = WhippetUserAuthenticationResponseStatus.Fail_AccountDeleted;
                            }
                            else if (!user.Active)
                            {
                                response = WhippetUserAuthenticationResponseStatus.Fail_AccountLockedOrInactive;
                            }
                            else
                            {
                                if (ipBlacklistCheckFunction != null && !String.IsNullOrWhiteSpace(user.IPAddress))
                                {
                                    blacklistResult = await ipBlacklistCheckFunction();

                                    if (blacklistResult.IsSuccess)
                                    {
                                        if (blacklistResult.HasItem)
                                        {
                                            // check to see if any IP addresses match
                                            filteredResults = blacklistResult.Item.Where(ip => IPAddress.Parse(ip.IPAddress).Equals(IPAddress.Parse(user.IPAddress)));

                                            if (filteredResults != null && filteredResults.Any())
                                            {
                                                if ((tenant != null && filteredResults.Where(ip => ip.Tenant.ID.Equals(tenant.ID)).Any()) || (tenant == null))
                                                {
                                                    response = WhippetUserAuthenticationResponseStatus.Fail_IPBlacklisted;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw blacklistResult.Exception;
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (secureSuppliedValue != null)
                    {
                        secureSuppliedValue.Dispose();
                        secureSuppliedValue = null;
                    }

                    if (secureUserValue != null)
                    {
                        secureUserValue.Dispose();
                        secureUserValue = null;
                    }
                }

                return new WhippetUserAuthenticationResponse(user.ID, Instant.FromDateTimeUtc(DateTime.UtcNow), response);
            }
        }

        /// <summary>
        /// Creates a new non-interactive system user record.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the new user record.</returns>
        public virtual WhippetResultContainer<IWhippetUser> CreateNonInteractiveSystemUser()
        {
            return Task.Run(() => CreateNonInteractiveSystemUserAsync()).Result;
        }

        /// <summary>
        /// Creates a new non-interactive system user record.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the new user record.</returns>
        public virtual async Task<WhippetResultContainer<IWhippetUser>> CreateNonInteractiveSystemUserAsync()
        {
            WhippetResultContainer<WhippetUser> systemUser = await UserRepository.CreateNonInteractiveSystemUserAsync();
            return WhippetResultContainer<IWhippetUser>.CastTo<IWhippetUser, WhippetUser>(systemUser);
        }

        /// <summary>
        /// Determines if the user exists based on the given user name.
        /// </summary>
        /// <param name="userName">User name to search for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing a value indicating whether a user was found with the matching <paramref name="userName"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<bool> UserExists(string userName)
        {
            return Task.Run(() => UserExistsAsync(userName)).Result;
        }

        /// <summary>
        /// Determines if the user exists based on the specified user ID.
        /// </summary>
        /// <param name="userId">User ID to search for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing a value indicating whether a user was found with the matching <paramref name="userId"/>.</returns>
        public virtual WhippetResultContainer<bool> UserExists(Guid userId)
        {
            return Task.Run(() => UserExistsAsync(userId)).Result;
        }

        /// <summary>
        /// Determines if the user exists based on the given user name.
        /// </summary>
        /// <param name="userName">User name to search for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing a value indicating whether a user was found with the matching <paramref name="userName"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<bool>> UserExistsAsync(string userName)
        {
            if (String.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            else
            {
                WhippetResultContainer<IWhippetUser> result = await GetWhippetUser(userName);
                return new WhippetResultContainer<bool>(result.Result, result.HasItem && !result.Item.Deleted);
            }
        }

        /// <summary>
        /// Determines if the user exists based on the specified user ID.
        /// </summary>
        /// <param name="userId">User ID to search for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing a value indicating whether a user was found with the matching <paramref name="userId"/>.</returns>
        public virtual async Task<WhippetResultContainer<bool>> UserExistsAsync(Guid userId)
        {
            WhippetResultContainer<IWhippetUser> result = await GetWhippetUser(userId);
            return new WhippetResultContainer<bool>(result.Result, result.HasItem && !result.Item.Deleted);
        }

        /// <summary>
        /// Gets the total number of users registered in the system, independent of tenant assignments.
        /// </summary>
        /// <param name="active">Specifies whether to get active or inactive users.</param>
        /// <param name="deleted">Specifies whether to get deleted users.</param>
        /// <returns>Total number of users in the system.</returns>
        public virtual WhippetResultContainer<long> GetUserCount(bool active, bool deleted)
        {
            return Task.Run(() => GetUserCountAsync(active, deleted)).Result;
        }

        /// <summary>
        /// Gets the total number of users registered in the system, independent of tenant assignments.
        /// </summary>
        /// <param name="active">Specifies whether to get active or inactive users.</param>
        /// <param name="deleted">Specifies whether to get deleted users.</param>
        /// <returns>Total number of users in the system.</returns>
        public virtual async Task<WhippetResultContainer<long>> GetUserCountAsync(bool active, bool deleted)
        {
            GetWhippetUserCountQueryHandler handler = new GetWhippetUserCountQueryHandler(UserRepository);
            WhippetResultContainer<IEnumerable<WhippetUser>> result = await handler.HandleAsync(new GetWhippetUserCountQuery(active, deleted));
            return new WhippetResultContainer<long>(result.Result, result.Item.LongCount());
        }
    }
}
