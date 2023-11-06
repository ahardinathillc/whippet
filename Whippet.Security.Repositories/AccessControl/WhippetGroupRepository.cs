using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.AccessControl.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetGroup"/> objects.
    /// </summary>
    public class WhippetGroupRepository : WhippetEntityRepository<WhippetGroup>, IWhippetGroupRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetGroupRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetGroupRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetGroupRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the specified group based on its name.
        /// </summary>
        /// <param name="groupName">Name of the group to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to search for the group in.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<WhippetGroup> GetByName(string groupName, IWhippetTenant tenant)
        {
            if (String.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetByNameAsync(groupName, tenant)).Result;
            }
        }

        /// <summary>
        /// Asynchronously gets the specified group based on its name.
        /// </summary>
        /// <param name="groupName">Name of the group to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to search for the group in.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<WhippetGroup>> GetByNameAsync(string groupName, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<WhippetGroup> queryResults = await Context.QueryOver<WhippetGroup>()
                    .Where(wg => wg.Name == groupName && !wg.Deleted)
                    .JoinQueryOver<WhippetTenant>(wg => wg.Tenant)
                    .Where(t => t.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<WhippetGroup>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets all groups for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the groups for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetGroup>> GetByTenant(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetByTenantAsync(tenant)).Result;
            }
        }

        /// <summary>
        /// Asynchronously gets all groups for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the groups for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetGroup>>> GetByTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<WhippetGroup> queryResults = await Context.QueryOver<WhippetGroup>()
                    .Where(wg => !wg.Deleted)
                    .JoinQueryOver<WhippetTenant>(wg => wg.Tenant)
                    .Where(t => t.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetGroup>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
