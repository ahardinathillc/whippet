using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using NHibernate;
using Terminal.Gui;

namespace Athi.Whippet.Salesforce.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="SalesforceClientProfile"/> entity objects.
    /// </summary>
    public class SalesforceClientProfileRepository : WhippetEntityRepository<SalesforceClientProfile>, IWhippetQueryRepository<SalesforceClientProfile>, ISalesforceClientProfileRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClientProfileRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceClientProfileRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceClientProfileRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesforceClientProfileRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the <see cref="SalesforceClientProfile"/> with the specified ID.
        /// </summary>
        /// <param name="key">ID of the <see cref="SalesforceClientProfile"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override WhippetResultContainer<SalesforceClientProfile> Get(Guid key)
        {
            return Task.Run(() => GetAsync(key)).Result;
        }

        /// <summary>
        /// Gets the <see cref="SalesforceClientProfile"/> with the specified ID.
        /// </summary>
        /// <param name="key">ID of the <see cref="SalesforceClientProfile"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<SalesforceClientProfile>> GetAsync(Guid key, CancellationToken? cancellationToken = null)
        {
            IList<SalesforceClientProfile> queryResults = await Context.QueryOver<SalesforceClientProfile>()
                .Where(sda => sda.ID == key)
                .JoinQueryOver(t => t.Tenant)
                .ListAsync();

            return new WhippetResultContainer<SalesforceClientProfile>(WhippetResult.Success, queryResults.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceClientProfile"/> with the specified profile name.
        /// </summary>
        /// <param name="profileName">Profile name of the <see cref="SalesforceClientProfile"/>.</param>
        /// <param name="tenant">Tenant that the profile is associated with.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<SalesforceClientProfile> Get(string profileName, IWhippetTenant tenant)
        {
            if (String.IsNullOrWhiteSpace(profileName))
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetAsync(profileName, tenant)).Result;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="SalesforceClientProfile"/> with the specified profile name.
        /// </summary>
        /// <param name="profileName">Profile name of the <see cref="SalesforceClientProfile"/>.</param>
        /// <param name="tenant">Tenant that the profile is associated with.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<SalesforceClientProfile>> GetAsync(string profileName, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(profileName))
            {
                throw new ArgumentNullException(nameof(profileName));
            }
            else if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<SalesforceClientProfile> queryResults = await Context.QueryOver<SalesforceClientProfile>()
                    .Where(sfc => sfc.Name == profileName)
                    .JoinQueryOver(t => t.Tenant)
                    .Where(sfc => sfc.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<SalesforceClientProfile>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceClientProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve <see cref="SalesforceClientProfile"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public WhippetResultContainer<IEnumerable<SalesforceClientProfile>> GetSalesforceProfilesForTenant(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetSalesforceProfilesForTenantAsync(tenant)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesforceClientProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve <see cref="SalesforceClientProfile"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public async Task<WhippetResultContainer<IEnumerable<SalesforceClientProfile>>> GetSalesforceProfilesForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<SalesforceClientProfile> queryResults = await Context.QueryOver<SalesforceClientProfile>()
                    .JoinQueryOver(t => t.Tenant)
                    .Where(sfc => sfc.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<SalesforceClientProfile>>(WhippetResult.Success, queryResults);
            }
        }
    }
}
