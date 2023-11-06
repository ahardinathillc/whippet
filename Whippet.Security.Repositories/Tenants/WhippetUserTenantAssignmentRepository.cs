using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;

namespace Athi.Whippet.Security.Tenants.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetUserTenantAssignment"/> objects.
    /// </summary>
    public class WhippetUserTenantAssignmentRepository : WhippetEntityRepository<WhippetUserTenantAssignment>, IWhippetUserTenantAssignmentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignmentRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an abstraction of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetUserTenantAssignmentRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetUserTenantAssignmentRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an abstraction of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless abstraction of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetUserTenantAssignmentRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets all <see cref="WhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>> Get(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetAsync(tenant)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="WhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>>> GetAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetUserTenantAssignment assignmentAlias = null;
                WhippetUser userAlias = null;
                WhippetTenant tenantAlias = null;

                IList<WhippetUserTenantAssignment> queryResults = await Context.QueryOver<WhippetUserTenantAssignment>(() => assignmentAlias)
                    .JoinAlias(() => assignmentAlias.Tenant, () => tenantAlias)
                    .JoinAlias(() => assignmentAlias.User, () => userAlias)
                    .Where(() => tenantAlias.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Gets all <see cref="WhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>> Get(IWhippetUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                return Task.Run(() => GetAsync(user)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="WhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>>> GetAsync(IWhippetUser user, CancellationToken? cancellationToken = null)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                WhippetUserTenantAssignment assignmentAlias = null;
                WhippetUser userAlias = null;
                WhippetTenant tenantAlias = null;

                IList<WhippetUserTenantAssignment> queryResults = await Context.QueryOver<WhippetUserTenantAssignment>(() => assignmentAlias)
                    .JoinAlias(() => assignmentAlias.Tenant, () => tenantAlias)
                    .JoinAlias(() => assignmentAlias.User, () => userAlias)
                    .Where(() => userAlias.ID == user.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
