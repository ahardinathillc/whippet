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
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.AccessControl.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetRole"/> objects.
    /// </summary>
    public class WhippetRoleRepository : WhippetEntityRepository<WhippetRole>, IWhippetRoleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetRoleRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetRoleRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the specified role based on its name.
        /// </summary>
        /// <param name="roleName">Name of the role to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to search for the role in.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<WhippetRole> GetByName(string roleName, IWhippetTenant tenant)
        {
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetByNameAsync(roleName, tenant)).Result;
            }
        }

        /// <summary>
        /// Asynchronously gets the specified role based on its name.
        /// </summary>
        /// <param name="roleName">Name of the role to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to search for the role in.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<WhippetRole>> GetByNameAsync(string roleName, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<WhippetRole> queryResults = await Context.QueryOver<WhippetRole>()
                    .Where(wr => wr.Name == roleName && !wr.Deleted)
                    .JoinQueryOver<WhippetTenant>(wr => wr.Tenant)
                    .Where(t => t.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<WhippetRole>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets all roles for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the roles for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetRole>> GetByTenant(IWhippetTenant tenant)
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
        /// Asynchronously gets all roles for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the roles for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetRole>>> GetByTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<WhippetRole> queryResults = await Context.QueryOver<WhippetRole>()
                    .Where(wr => !wr.Deleted)
                    .JoinQueryOver<WhippetTenant>(wr => wr.Tenant)
                    .Where(t => t.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetRole>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
