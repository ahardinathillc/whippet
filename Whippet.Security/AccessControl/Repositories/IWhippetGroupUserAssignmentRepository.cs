using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.AccessControl.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetGroupUserAssignment"/> objects.
    /// </summary>
    public interface IWhippetGroupUserAssignmentRepository : IWhippetEntityRepository<WhippetGroupUserAssignment, Guid>, IWhippetQueryRepository<WhippetGroupUserAssignment>
    {
        /// <summary>
        /// Gets all <see cref="WhippetGroupUserAssignment"/> objects based on the specified <see cref="IWhippetGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroup"/> to retrieve <see cref="WhippetGroupUserAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>> GetByGroup(IWhippetGroup group);

        /// <summary>
        /// Asynchronously gets all <see cref="WhippetGroupUserAssignment"/> objects based on the specified <see cref="IWhippetGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroup"/> to retrieve <see cref="WhippetGroupUserAssignment"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>>> GetByGroupAsync(IWhippetGroup group, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="WhippetGroupUserAssignment"/> objects based on the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to retrieve <see cref="WhippetGroupUserAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>> GetByUser(IWhippetUser user);

        /// <summary>
        /// Asynchronously all <see cref="WhippetGroupUserAssignment"/> objects based on the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to retrieve <see cref="WhippetGroupUserAssignment"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>>> GetByUserAsync(IWhippetUser user, CancellationToken? cancellationToken = null);
    }
}
