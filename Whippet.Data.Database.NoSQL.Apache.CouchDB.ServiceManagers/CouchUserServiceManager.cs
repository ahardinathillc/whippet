using System;
using CouchDB.Driver;
using CouchDB.Driver.Types;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB.Extensions;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB.ServiceManagers
{
    /// <summary>
    /// Represents the service manager for managing <see cref="CouchUser"/> and <see cref="IWhippetCouchUser"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class CouchUserServiceManager : ServiceManager
    {
        private readonly ICouchDatabase<CouchUser> _Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouchUserServiceManager"/> class with no arguments.
        /// </summary>
        private CouchUserServiceManager()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CouchUserServiceManager"/> class with the specified <see cref="ICouchClient"/> object that loads the context.
        /// </summary>
        /// <param name="client"><see cref="ICouchClient"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CouchUserServiceManager(ICouchClient client)
            : this()
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            else
            {
                _Context = client.GetUsersDatabase();
            }
        }

        /// <summary>
        /// Creates a new <see cref="CouchUser"/>.
        /// </summary>
        /// <param name="user"><see cref="CouchUser"/> to create.</param>
        /// <param name="batch">Indicates whether the operation is part of a transaction.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IWhippetCouchUser>> CreateUser(CouchUser user, bool batch = false, CancellationToken cancellationToken = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetResultContainer<IWhippetCouchUser> result = null;

                try
                {
                    user = await _Context.AddAsync(user, batch, cancellationToken);
                    result = new WhippetResultContainer<IWhippetCouchUser>(WhippetResult.Success, new WhippetCouchUser(user));

                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetCouchUser>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new <see cref="IWhippetCouchUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetCouchUser"/> to create.</param>
        /// <param name="batch">Indicates whether the operation is part of a transaction.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IWhippetCouchUser>> CreateUser(IWhippetCouchUser user, bool batch = false, CancellationToken cancellationToken = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                return await CreateUser(user.ToCouchUser(), batch, cancellationToken);
            }
        }

        /// <summary>
        /// Creates one or more <see cref="CouchUser"/> objects.
        /// </summary>
        /// <param name="users"><see cref="CouchUser"/> objects to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IEnumerable<IWhippetCouchUser>>> CreateUsers(IEnumerable<CouchUser> users, CancellationToken cancellationToken = default)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IWhippetCouchUser>> result = null;

                try
                {
                    users = await _Context.AddOrUpdateRangeAsync((users is IList<CouchUser>) ? (IList<CouchUser>)(users) : new List<CouchUser>(users));
                    result = new WhippetResultContainer<IEnumerable<IWhippetCouchUser>>(WhippetResult.Success, (users == null) ? null : users.Select(u => new WhippetCouchUser(u)));

                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<IWhippetCouchUser>>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates one or more <see cref="IWhippetCouchUser"/> objects.
        /// </summary>
        /// <param name="users"><see cref="IWhippetCouchUser"/> objects to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IEnumerable<IWhippetCouchUser>>> CreateUsers(IEnumerable<IWhippetCouchUser> users, CancellationToken cancellationToken = default)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            else
            {
                return await CreateUsers(users.Select(u => u.ToCouchUser()), cancellationToken);
            }
        }

        /// <summary>
        /// Updates an existing <see cref="CouchUser"/>.
        /// </summary>
        /// <param name="user"><see cref="CouchUser"/> to update.</param>
        /// <param name="batch">Indicates whether the operation is part of a transaction.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IWhippetCouchUser>> UpdateUser(CouchUser user, bool batch = false, CancellationToken cancellationToken = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetResultContainer<IWhippetCouchUser> result = null;

                try
                {
                    user = await _Context.AddOrUpdateAsync(user, batch, cancellationToken);
                    result = new WhippetResultContainer<IWhippetCouchUser>(WhippetResult.Success, new WhippetCouchUser(user));

                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetCouchUser>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="IWhippetCouchUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetCouchUser"/> to update.</param>
        /// <param name="batch">Indicates whether the operation is part of a transaction.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IWhippetCouchUser>> UpdateUser(IWhippetCouchUser user, bool batch = false, CancellationToken cancellationToken = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                return await UpdateUser(user.ToCouchUser(), batch, cancellationToken);
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="CouchUser"/>.
        /// </summary>
        /// <param name="user"><see cref="CouchUser"/> to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IWhippetCouchUser>> DeleteUser(CouchUser user, CancellationToken cancellationToken = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetResultContainer<IWhippetCouchUser> result = null;

                try
                {
                    await _Context.DeleteRangeAsync(new[] { user }, cancellationToken);
                    result = new WhippetResultContainer<IWhippetCouchUser>(WhippetResult.Success, new WhippetCouchUser(user));

                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetCouchUser>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="IWhippetCouchUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetCouchUser"/> to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IWhippetCouchUser>> DeleteUser(IWhippetCouchUser user, CancellationToken cancellationToken = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetResultContainer<IWhippetCouchUser> result = null;

                try
                {
                    await _Context.DeleteRangeAsync(new[] { user.ToCouchUser() }, cancellationToken);
                    result = new WhippetResultContainer<IWhippetCouchUser>(WhippetResult.Success, user);

                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IWhippetCouchUser>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Deletes one or more existing <see cref="CouchUser"/> objects.
        /// </summary>
        /// <param name="users"><see cref="IWhippetCouchUser"/> users to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IEnumerable<IWhippetCouchUser>>> DeleteUsers(IEnumerable<CouchUser> users, CancellationToken cancellationToken = default)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IWhippetCouchUser>> result = null;

                try
                {
                    await _Context.DeleteRangeAsync(users, cancellationToken);
                    result = new WhippetResultContainer<IEnumerable<IWhippetCouchUser>>(WhippetResult.Success, users.Select(u => new WhippetCouchUser(u)));

                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<IWhippetCouchUser>>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Deletes one or more existing <see cref="IWhippetCouchUser"/> objects.
        /// </summary>
        /// <param name="users"><see cref="IWhippetCouchUser"/> users to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<WhippetResultContainer<IEnumerable<IWhippetCouchUser>>> DeleteUsers(IEnumerable<IWhippetCouchUser> users, CancellationToken cancellationToken = default)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            else
            {
                WhippetResultContainer<IEnumerable<IWhippetCouchUser>> result = null;

                try
                {
                    await _Context.DeleteRangeAsync(users.Select(u => u.ToCouchUser()), cancellationToken);
                    result = new WhippetResultContainer<IEnumerable<IWhippetCouchUser>>(WhippetResult.Success, users);

                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<IWhippetCouchUser>>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IWhippetCouchUser"/> object with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="IWhippetCouchUser"/>.</param>
        /// <param name="withConflicts">If <see langword="true"/>, will return the document even if it has conflicts.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        public async Task<WhippetResultContainer<IWhippetCouchUser>> GetUser(Guid id, bool withConflicts = false, CancellationToken cancellationToken = default)
        {
            return await GetUser(id.ToString(), withConflicts, cancellationToken);
        }

        /// <summary>
        /// Retrieves the <see cref="IWhippetCouchUser"/> object with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the <see cref="IWhippetCouchUser"/>.</param>
        /// <param name="withConflicts">If <see langword="true"/>, will return the document even if it has conflicts.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        public async Task<WhippetResultContainer<IWhippetCouchUser>> GetUser(string id, bool withConflicts = false, CancellationToken cancellationToken = default)
        {
            WhippetResultContainer<IWhippetCouchUser> result = null;
            CouchUser couchUser = null;

            try
            {
                couchUser = await _Context.FindAsync(id, withConflicts, cancellationToken);
                result = new WhippetResultContainer<IWhippetCouchUser>(WhippetResult.Success, (couchUser == null) ? null : new WhippetCouchUser(couchUser));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IWhippetCouchUser>(e);
            }

            return result;
        }

    }
}

