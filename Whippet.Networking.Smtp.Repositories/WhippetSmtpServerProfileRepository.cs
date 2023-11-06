using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Networking.Smtp.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="WhippetSmtpServerProfile"/> entity objects.
    /// </summary>
    public class WhippetSmtpServerProfileRepository : WhippetEntityRepository<WhippetSmtpServerProfile>, IWhippetSmtpServerProfileRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfileRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSmtpServerProfileRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSmtpServerProfileRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetSmtpServerProfileRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the default <see cref="WhippetSmtpServerProfile"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<WhippetSmtpServerProfile> GetDefaultProfile(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);
            return Task.Run(() => GetDefaultProfileAsync(tenant)).Result;
        }

        /// <summary>
        /// Gets the default <see cref="WhippetSmtpServerProfile"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<WhippetSmtpServerProfile>> GetDefaultProfileAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IList<WhippetSmtpServerProfile> queryResults = await Context.QueryOver<WhippetSmtpServerProfile>()
                .Where(sp => sp.IsDefault && sp.Active && !sp.Deleted)
                .JoinQueryOver<WhippetTenant>(sp => sp.Tenant)
                .Where(tn => tn.ID == tenant.ID)
                .ListAsync();

            if (!queryResults.Any())
            {
                queryResults = await Context.QueryOver<WhippetSmtpServerProfile>()
                                .Where(sp => sp.Active && !sp.Deleted)
                                .JoinQueryOver<WhippetTenant>(sp => sp.Tenant)
                                .Where(tn => tn.ID == tenant.ID)
                                .ListAsync();
            }

            return new WhippetResultContainer<WhippetSmtpServerProfile>(WhippetResult.Success, queryResults.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetSmtpServerProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="WhippetSmtpServerProfile"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>> GetForTenant(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);
            return Task.Run(() => GetForTenantAsync(tenant)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetSmtpServerProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="WhippetSmtpServerProfile"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>>> GetForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            ArgumentNullException.ThrowIfNull(tenant);

            IList<WhippetSmtpServerProfile> queryResults = await Context.QueryOver<WhippetSmtpServerProfile>()
                .JoinQueryOver<WhippetTenant>(sp => sp.Tenant)
                .Where(tn => tn.ID == tenant.ID)
                .ListAsync();

            return new WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>>(WhippetResult.Success, queryResults);
        }

    }
}
