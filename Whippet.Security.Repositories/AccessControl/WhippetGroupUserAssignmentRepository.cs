using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security.AccessControl.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetGroupUserAssignment"/> objects.
    /// </summary>
    public class WhippetGroupUserAssignmentRepository : WhippetEntityRepository<WhippetGroupUserAssignment>, IWhippetGroupUserAssignmentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignmentRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetGroupUserAssignmentRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupUserAssignmentRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetGroupUserAssignmentRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets all <see cref="WhippetGroupUserAssignment"/> objects based on the specified <see cref="IWhippetGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroup"/> to retrieve <see cref="WhippetGroupUserAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>> GetByGroup(IWhippetGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                return Task.Run(() => GetByGroupAsync(group)).Result;
            }
        }

        /// <summary>
        /// Asynchronously gets all <see cref="WhippetGroupUserAssignment"/> objects based on the specified <see cref="IWhippetGroup"/>.
        /// </summary>
        /// <param name="group"><see cref="IWhippetGroup"/> to retrieve <see cref="WhippetGroupUserAssignment"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public async virtual Task<WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>>> GetByGroupAsync(IWhippetGroup group, CancellationToken? cancellationToken = null)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            else
            {
                WhippetUser userAlias = null;
                WhippetGroup groupAlias = null;
                WhippetGroupUserAssignment assignmentAlias = null;

                IList<WhippetGroupUserAssignment> queryResults = await Context.QueryOver<WhippetGroupUserAssignment>(() => assignmentAlias)
                    .JoinEntityAlias(() => userAlias, () => userAlias.ID == assignmentAlias.UserID)
                    .JoinEntityAlias(() => groupAlias, () => groupAlias.ID == assignmentAlias.GroupID)
                    .Where(() => assignmentAlias.GroupID == group.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Gets all <see cref="WhippetGroupUserAssignment"/> objects based on the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to retrieve <see cref="WhippetGroupUserAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>> GetByUser(IWhippetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                return Task.Run(() => GetByUserAsync(user)).Result;
            }
        }

        /// <summary>
        /// Asynchronously all <see cref="WhippetGroupUserAssignment"/> objects based on the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to retrieve <see cref="WhippetGroupUserAssignment"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public async virtual Task<WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>>> GetByUserAsync(IWhippetUser user, CancellationToken? cancellationToken = null)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetUser userAlias = null;
                WhippetGroup groupAlias = null;
                WhippetGroupUserAssignment assignmentAlias = null;

                IList<WhippetGroupUserAssignment> queryResults = await Context.QueryOver<WhippetGroupUserAssignment>(() => assignmentAlias)
                    .JoinEntityAlias(() => userAlias, () => userAlias.ID == assignmentAlias.UserID)
                    .JoinEntityAlias(() => groupAlias, () => groupAlias.ID == assignmentAlias.GroupID)
                    .Where(() => assignmentAlias.UserID == user.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetGroupUserAssignment>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
