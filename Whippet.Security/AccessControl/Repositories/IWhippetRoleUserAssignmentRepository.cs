using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Security.AccessControl;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.AccessControl.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetRoleUserAssignment"/> objects.
    /// </summary>
    public interface IWhippetRoleUserAssignmentRepository : IWhippetEntityRepository<WhippetRoleUserAssignment, Guid>, IWhippetQueryRepository<WhippetRoleUserAssignment>
    {
        /// <summary>
        /// Gets all <see cref="WhippetRoleUserAssignment"/> objects based on the specified <see cref="IWhippetRole"/>.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRole"/> to retrieve <see cref="WhippetRoleUserAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>> GetByRole(IWhippetRole role);

        /// <summary>
        /// Asynchronously gets all <see cref="WhippetRoleUserAssignment"/> objects based on the specified <see cref="IWhippetRole"/>.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRole"/> to retrieve <see cref="WhippetRoleUserAssignment"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>>> GetByRoleAsync(IWhippetRole role, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="WhippetRoleUserAssignment"/> objects based on the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to retrieve <see cref="WhippetRoleUserAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>> GetByUser(IWhippetUser user);

        /// <summary>
        /// Asynchronously all <see cref="WhippetRoleUserAssignment"/> objects based on the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to retrieve <see cref="WhippetRoleUserAssignment"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>>> GetByUserAsync(IWhippetUser user, CancellationToken? cancellationToken = null);
    }
}
