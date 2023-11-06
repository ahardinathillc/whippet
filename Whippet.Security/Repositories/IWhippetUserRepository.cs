using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="WhippetUser"/> entity objects.
    /// </summary>
    public interface IWhippetUserRepository : IWhippetEntityRepository<WhippetUser, Guid>, IWhippetRepository<WhippetUser, Guid>, IWhippetQueryRepository<WhippetUser>
    {
        /// <summary>
        /// Retrieves the <see cref="WhippetUser"/> with the specified username.
        /// </summary>
        /// <param name="username">Username of the <see cref="WhippetUser"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<WhippetUser> Get(string username);

        /// <summary>
        /// Retrieves the <see cref="WhippetUser"/> with the specified username.
        /// </summary>
        /// <param name="username">Username of the <see cref="WhippetUser"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<WhippetUser>> GetAsync(string username, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves the <see cref="WhippetUser"/> with the specified username and (encrypted) password.
        /// </summary>
        /// <param name="username">Username of the <see cref="WhippetUser"/>.</param>
        /// <param name="password">Encrypted password of the <see cref="WhippetUser"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<WhippetUser> Get(string username, string password);

        /// <summary>
        /// Retrieves the <see cref="WhippetUser"/> with the specified username and (encrypted) password.
        /// </summary>
        /// <param name="username">Username of the <see cref="WhippetUser"/>.</param>
        /// <param name="password">Encrypted password of the <see cref="WhippetUser"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<WhippetUser>> GetAsync(string username, string password, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves the total number of <see cref="WhippetUser"/> instances that match the specified parameters.
        /// </summary>
        /// <param name="active">Specifies whether active users should be included in the query.</param>
        /// <param name="deleted">Specifies whether deleted users should be included in the query.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<long> GetUserCount(bool active, bool deleted);

        /// <summary>
        /// Retrieves the total number of <see cref="WhippetUser"/> instances that match the specified parameters.
        /// </summary>
        /// <param name="active">Specifies whether active users should be included in the query.</param>
        /// <param name="deleted">Specifies whether deleted users should be included in the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<long>> GetUserCountAsync(bool active, bool deleted, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Creates a non-interactive system user.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<WhippetUser> CreateNonInteractiveSystemUser();

        /// <summary>
        /// Creates a non-interactive system user.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<WhippetUser>> CreateNonInteractiveSystemUserAsync(CancellationToken? cancellationToken = null);
    }
}
