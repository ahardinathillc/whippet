using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MagentoRestEndpoint"/> entity objects.
    /// </summary>
    public class MagentoRestEndpointRepository : WhippetEntityRepository<MagentoRestEndpoint>, IMagentoRestEndpointRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpointRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoRestEndpointRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoRestEndpointRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoRestEndpointRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <see cref="MagentoRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MagentoRestEndpoint"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MagentoRestEndpoint>> GetForTenant(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);
            return Task.Run(() => GetForTenantAsync(tenant)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="MagentoRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MagentoRestEndpoint"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoRestEndpoint>>> GetForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IList<MagentoRestEndpoint> queryResults = await Context.QueryOver<MagentoRestEndpoint>()
                .JoinQueryOver<WhippetTenant>(sp => sp.Tenant)
                .Where(tn => tn.ID == tenant.ID)
                .ListAsync();

            return new WhippetResultContainer<IEnumerable<MagentoRestEndpoint>>(WhippetResult.Success, queryResults);
        }
    }
}
