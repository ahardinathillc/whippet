using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository : WhippetEntityRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the cache for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> GetCacheForTenant(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetCacheForTenantAsync(tenant)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the cache for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> GetCacheForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> queryResults = await Context.QueryOver<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>()
                    .JoinQueryOver<MultichannelOrderManagerServer>(c => c.SourceServer)
                    .JoinQueryOver<WhippetTenant>(s => s.Tenant)
                    .Where(t => t.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
        }

        /// <summary>
        /// Retrieves all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects for the specified <see cref="IMultichannelOrderManagerServer"/>.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> GetCachesForMultichannelOrderManagerServer(IMultichannelOrderManagerServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                return Task.Run(() => GetCachesForMultichannelOrderManagerServerAsync(server)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> objects for the specified <see cref="IMultichannelOrderManagerServer"/>.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>> GetCachesForMultichannelOrderManagerServerAsync(IMultichannelOrderManagerServer server, CancellationToken? cancellationToken = null)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }
            else
            {
                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> queryResults = await Context.QueryOver<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>()
                    .JoinQueryOver<MultichannelOrderManagerServer>(c => c.SourceServer)
                    .Where(ss => ss.ID == server.ID)
                    .JoinQueryOver<WhippetTenant>(s => s.Tenant)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>(WhippetResult.Success, queryResults.AsReadOnly());

            }
        }
    }
}
