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
using Athi.Whippet.Security.Repositories;

namespace Athi.Whippet.Security.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetIpAddressBlacklist"/> objects.
    /// </summary>
    public class WhippetIpAddressBlacklistRepository : WhippetEntityRepository<WhippetIpAddressBlacklist>, IWhippetIpAddressBlacklistRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklistRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetIpAddressBlacklistRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetIpAddressBlacklistRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetIpAddressBlacklistRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves the <see cref="WhippetIpAddressBlacklist"/> with the specified IP address.
        /// </summary>
        /// <param name="ipAddress">IP address to search for.</param>
        /// <param name="tenant">Tenant to filter by, if any.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>> Get(string ipAddress, IWhippetTenant tenant)
        {
            return this.RunSync<WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>>>(() => GetAsync(ipAddress, tenant));
        }

        /// <summary>
        /// Retrieves the <see cref="WhippetIpAddressBlacklist"/> with the specified IP address.
        /// </summary>
        /// <param name="ipAddress">IP address to search for.</param>
        /// <param name="tenant">Tenant to filter by, if any.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>>> GetAsync(string ipAddress, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            IList<WhippetIpAddressBlacklist> queryResults = null;

            if (String.IsNullOrWhiteSpace(ipAddress) && tenant != null)
            {
                queryResults = await Context.QueryOver<WhippetIpAddressBlacklist>()
                       .Where(ipbl => ipbl.Tenant.ID == tenant.ID)
                       .ListAsync();
            }
            else
            {
                if (tenant == null)
                {
                    queryResults = await Context.QueryOver<WhippetIpAddressBlacklist>()
                           .Where(ipbl => ipbl.IPAddress == ipAddress)
                           .ListAsync();
                }
                else
                {
                    queryResults = await Context.QueryOver<WhippetIpAddressBlacklist>()
                        .Where(ipbl => ipbl.IPAddress == ipAddress)
                        .And(ipbl => ipbl.Tenant.ID == tenant.ID)
                        .ListAsync();
                }
            }

            return new WhippetResultContainer<IEnumerable<WhippetIpAddressBlacklist>>(WhippetResult.Success, queryResults);
        }
    }
}
