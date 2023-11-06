using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerRestEndpoint"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerRestEndpointRepository : WhippetEntityRepository<MultichannelOrderManagerRestEndpoint>, IMultichannelOrderManagerRestEndpointRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerRestEndpointRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerRestEndpointRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerRestEndpointRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public MultichannelOrderManagerRestEndpointRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MultichannelOrderManagerRestEndpoint"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerRestEndpoint>> GetForTenant(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);
            return Task.Run(() => GetForTenantAsync(tenant)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MultichannelOrderManagerRestEndpoint"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerRestEndpoint>>> GetForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IList<MultichannelOrderManagerRestEndpoint> queryResults = await Context.QueryOver<MultichannelOrderManagerRestEndpoint>()
                .JoinQueryOver<WhippetTenant>(sp => sp.Tenant)
                .Where(tn => tn.ID == tenant.ID)
                .ListAsync();

            return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerRestEndpoint>>(WhippetResult.Success, queryResults);
        }
    }
}
