using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security.AccessControl.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetRoleUserAssignment"/> objects.
    /// </summary>
    public class WhippetRoleUserAssignmentRepository : WhippetEntityRepository<WhippetRoleUserAssignment>, IWhippetRoleUserAssignmentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignmentRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetRoleUserAssignmentRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignmentRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetRoleUserAssignmentRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets all <see cref="WhippetRoleUserAssignment"/> objects based on the specified <see cref="IWhippetRole"/>.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRole"/> to retrieve <see cref="WhippetRoleUserAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>> GetByRole(IWhippetRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                return Task.Run(() => GetByRoleAsync(role)).Result;
            }
        }

        /// <summary>
        /// Asynchronously gets all <see cref="WhippetRoleUserAssignment"/> objects based on the specified <see cref="IWhippetRole"/>.
        /// </summary>
        /// <param name="role"><see cref="IWhippetRole"/> to retrieve <see cref="WhippetRoleUserAssignment"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public async virtual Task<WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>>> GetByRoleAsync(IWhippetRole role, CancellationToken? cancellationToken = null)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            else
            {
                WhippetUser userAlias = null;
                WhippetRole roleAlias = null;
                WhippetRoleUserAssignment assignmentAlias = null;

                IList<WhippetRoleUserAssignment> queryResults = await Context.QueryOver<WhippetRoleUserAssignment>(() => assignmentAlias)
                    .JoinEntityAlias(() => userAlias, () => userAlias.ID == assignmentAlias.UserID)
                    .JoinEntityAlias(() => roleAlias, () => roleAlias.ID == assignmentAlias.RoleID)
                    .Where(() => assignmentAlias.RoleID == role.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Gets all <see cref="WhippetRoleUserAssignment"/> objects based on the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to retrieve <see cref="WhippetRoleUserAssignment"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>> GetByUser(IWhippetUser user)
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
        /// Asynchronously all <see cref="WhippetRoleUserAssignment"/> objects based on the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> to retrieve <see cref="WhippetRoleUserAssignment"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public async virtual Task<WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>>> GetByUserAsync(IWhippetUser user, CancellationToken? cancellationToken = null)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetUser userAlias = null;
                WhippetRole roleAlias = null;
                WhippetRoleUserAssignment assignmentAlias = null;

                IList<WhippetRoleUserAssignment> queryResults = await Context.QueryOver<WhippetRoleUserAssignment>(() => assignmentAlias)
                    .JoinEntityAlias(() => userAlias, () => userAlias.ID == assignmentAlias.UserID)
                    .JoinEntityAlias(() => roleAlias, () => roleAlias.ID == assignmentAlias.RoleID)
                    .Where(() => assignmentAlias.UserID == user.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
