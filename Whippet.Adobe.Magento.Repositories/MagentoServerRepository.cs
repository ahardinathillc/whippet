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
    /// Represents a data repository for mapping <see cref="MagentoServer"/> entity objects.
    /// </summary>
    public class MagentoServerRepository : WhippetEntityRepository<MagentoServer>, IMagentoServerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoServerRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoServerRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoServerRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoServerRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <see cref="MagentoServer"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MagentoServer"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MagentoServer>> GetForTenant(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);
            return Task.Run(() => GetForTenantAsync(tenant)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="MagentoServer"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MagentoServer"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoServer>>> GetForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IList<MagentoServer> queryResults = await Context.QueryOver<MagentoServer>()
                .JoinQueryOver<WhippetTenant>(sp => sp.Tenant)
                .Where(tn => tn.ID == tenant.ID)
                .ListAsync();

            return new WhippetResultContainer<IEnumerable<MagentoServer>>(WhippetResult.Success, queryResults);
        }
    }
}
