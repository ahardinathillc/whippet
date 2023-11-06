using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Security.Repositories;
using Athi.Whippet.Security.Extensions;
using Athi.Whippet.Security.EntityMappings;
using Athi.Whippet.Security.EntityMappings.Extensions;

namespace Athi.Whippet.Security.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetUser"/> objects.
    /// </summary>
    public class WhippetUserRepository : WhippetEntityRepository<WhippetUser>, IWhippetUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetUserRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetUserRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves the <see cref="WhippetUser"/> with the specified username and (encrypted) password.
        /// </summary>
        /// <param name="username">Username of the <see cref="WhippetUser"/>.</param>
        /// <param name="password">Encrypted password of the <see cref="WhippetUser"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<WhippetUser> Get(string username, string password)
        {
            return this.RunSync<WhippetResultContainer<WhippetUser>>(() => GetAsync(username, password));
        }

        /// <summary>
        /// Retrieves the <see cref="WhippetUser"/> with the specified username and (encrypted) password.
        /// </summary>
        /// <param name="username">Username of the <see cref="WhippetUser"/>.</param>
        /// <param name="password">Encrypted password of the <see cref="WhippetUser"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<WhippetUser>> GetAsync(string username, string password, CancellationToken? cancellationToken = null)
        {
            IList<WhippetUser> queryResults = await Context.QueryOver<WhippetUser>()
                .Where(wu => wu.UserName == username)
                .And(wu => wu.Password == password)
                .ListAsync();

            return new WhippetResultContainer<WhippetUser>(WhippetResult.Success, queryResults.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the <see cref="WhippetUser"/> with the specified username.
        /// </summary>
        /// <param name="username">Username of the <see cref="WhippetUser"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<WhippetUser> Get(string username)
        {
            return this.RunSync<WhippetResultContainer<WhippetUser>>(() => GetAsync(username));
        }

        /// <summary>
        /// Retrieves the <see cref="WhippetUser"/> with the specified username.
        /// </summary>
        /// <param name="username">Username of the <see cref="WhippetUser"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<WhippetUser>> GetAsync(string username, CancellationToken? cancellationToken = null)
        {
            IList<WhippetUser> queryResults = await Context.QueryOver<WhippetUser>()
                .Where(wu => wu.UserName == username)
                .ListAsync();

            return new WhippetResultContainer<WhippetUser>(WhippetResult.Success, queryResults.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the total number of <see cref="WhippetUser"/> instances that match the specified parameters.
        /// </summary>
        /// <param name="active">Specifies whether active users should be included in the query.</param>
        /// <param name="deleted">Specifies whether deleted users should be included in the query.</param>
        /// <returns>Total number of users that match the specified parameters.</returns>
        public virtual WhippetResultContainer<long> GetUserCount(bool active, bool deleted)
        {
            return Task.Run(() => GetUserCount(active, deleted)).Result;
        }

        /// <summary>
        /// Retrieves the total number of <see cref="WhippetUser"/> instances that match the specified parameters.
        /// </summary>
        /// <param name="active">Specifies whether active users should be included in the query.</param>
        /// <param name="deleted">Specifies whether deleted users should be included in the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Total number of users that match the specified parameters.</returns>
        public virtual async Task<WhippetResultContainer<long>> GetUserCountAsync(bool active, bool deleted, CancellationToken? cancellationToken = null)
        {
            IWhippetUser user = null;
            long count = 0;

            user = user.CreateNonInteractiveSystemUser();

            count = await Context.QueryOver<WhippetUser>()
                .Where(u => (u.Active == active) && (u.Deleted == deleted) && (u.UserName != user.UserName))
                .RowCountInt64Async();

            return new WhippetResultContainer<long>(WhippetResult.Success, count);
        }

        /// <summary>
        /// Creates a non-interactive system user.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<WhippetUser> CreateNonInteractiveSystemUser()
        {
            return Task.Run(() => CreateNonInteractiveSystemUserAsync()).Result;
        }

        /// <summary>
        /// Creates a non-interactive system user.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<WhippetUser>> CreateNonInteractiveSystemUserAsync(CancellationToken? cancellationToken = null)
        {
            WhippetUser systemUser = null;

            WhippetResultContainer<WhippetUser> result = null;
            WhippetResult queryResult = WhippetResult.Success;

            WhippetUserMap userMap = null;

            Guid systemUserId = Guid.Empty;

            int updatedRows = 0;

            systemUser = systemUser.CreateNonInteractiveSystemUser().ToWhippetUser();
            systemUserId = systemUser.ID;

            // check to see if one exists already

            result = await GetAsync(systemUser.UserName);

            if (result.IsSuccess)
            {
                if (!result.HasItem)
                {
                    // create the initial record
                    queryResult = await CreateAsync(systemUser);

                    if (queryResult.IsSuccess)
                    {
                        try
                        {
                            await CommitAsync();

                            userMap = new WhippetUserMap();
                            updatedRows = await userMap.CreateUpdateNonInteractiveUserQuery(Context, systemUser.ID, systemUserId).ExecuteUpdateAsync();
                            
                            systemUser.ID = systemUserId;

                            result = new WhippetResultContainer<WhippetUser>(queryResult, systemUser);
                        }
                        catch (Exception e)
                        {
                            result = new WhippetResultContainer<WhippetUser>(new WhippetResult(e), systemUser);
                        }
                    }
                    else
                    {
                        result = new WhippetResultContainer<WhippetUser>(queryResult, systemUser);
                    }
                }
            }

            return result;
        }
    }
}
