using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerServer"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerServerRepository : WhippetEntityRepository<MultichannelOrderManagerServer>, IMultichannelOrderManagerServerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServerRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerServerRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerServerRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerServerRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerServer"/> object with the specified server name.
        /// </summary>
        /// <param name="serverName">Server name of the <see cref="MultichannelOrderManagerServer"/>.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the server is registered with.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MultichannelOrderManagerServer> Get(string serverName, IWhippetTenant tenant)
        {
            if (String.IsNullOrWhiteSpace(serverName))
            {
                throw new ArgumentNullException(nameof(serverName));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetAsync(serverName, tenant)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerServer"/> object with the specified server name.
        /// </summary>
        /// <param name="serverName">Server name of the <see cref="MultichannelOrderManagerServer"/>.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> that the server is registered with.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MultichannelOrderManagerServer>> GetAsync(string serverName, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(serverName))
            {
                throw new ArgumentNullException(nameof(serverName));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<MultichannelOrderManagerServer> queryResults = await Context.QueryOver<MultichannelOrderManagerServer>()
                    .Where(s => s.Name == serverName)
                    .JoinQueryOver(t => t.Tenant)
                    .Where(t => t.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<MultichannelOrderManagerServer>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerServer"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="MultichannelOrderManagerServer"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerServer>> GetServersForTenant(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetServersForTenantAsync(tenant)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerServer"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="MultichannelOrderManagerServer"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerServer>>> GetServersForTenantAsync(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<MultichannelOrderManagerServer> queryResults = await Context.QueryOver<MultichannelOrderManagerServer>()
                    .JoinQueryOver(t => t.Tenant)
                    .Where(t => t.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerServer>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
