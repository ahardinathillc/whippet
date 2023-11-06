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
    /// Repository for <see cref="WhippetPasswordBlacklist"/> objects.
    /// </summary>
    public class WhippetPasswordBlacklistRepository : WhippetEntityRepository<WhippetPasswordBlacklist>, IWhippetPasswordBlacklistRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklistRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetPasswordBlacklistRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPasswordBlacklistRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetPasswordBlacklistRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves the <see cref="WhippetPasswordBlacklist"/> with the specified password.
        /// </summary>
        /// <param name="password">Password to search for.</param>
        /// <param name="tenant">Tenant to filter by, if any.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<IEnumerable<WhippetPasswordBlacklist>> Get(string password, IWhippetTenant tenant)
        {
            return this.RunSync<WhippetResultContainer<IEnumerable<WhippetPasswordBlacklist>>>(() => GetAsync(password, tenant));
        }

        /// <summary>
        /// Retrieves the <see cref="WhippetPasswordBlacklist"/> with the specified password.
        /// </summary>
        /// <param name="password">Password to search for.</param>
        /// <param name="tenant">Tenant to filter by, if any.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetPasswordBlacklist>>> GetAsync(string password, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            IList<WhippetPasswordBlacklist> queryResults = null;

            if (String.IsNullOrWhiteSpace(password) && tenant != null)
            {
                queryResults = await Context.QueryOver<WhippetPasswordBlacklist>()
                       .Where(ipbl => ipbl.Tenant.ID == tenant.ID)
                       .ListAsync();
            }
            else
            {
                if (tenant == null)
                {
                    queryResults = await Context.QueryOver<WhippetPasswordBlacklist>()
                           .Where(ipbl => ipbl.Password == password)
                           .ListAsync();
                }
                else
                {
                    queryResults = await Context.QueryOver<WhippetPasswordBlacklist>()
                        .Where(ipbl => ipbl.Password == password)
                        .JoinQueryOver<WhippetTenant>(t => t.Tenant)
                        .Where(t => t.ID == tenant.ID)
                        .ListAsync();
                }
            }

            return new WhippetResultContainer<IEnumerable<WhippetPasswordBlacklist>>(WhippetResult.Success, queryResults);
        }
    }
}
