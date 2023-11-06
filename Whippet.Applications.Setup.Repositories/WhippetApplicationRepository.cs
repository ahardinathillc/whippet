using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Applications.Setup.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="WhippetApplication"/> entity objects.
    /// </summary>
    public class WhippetApplicationRepository : WhippetEntityRepository<WhippetApplication>, IWhippetApplicationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplicationRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetApplicationRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetApplicationRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetApplicationRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <see cref="WhippetApplication"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="WhippetApplication"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetApplication>> GetApplicationsForTenant(IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => GetApplicationsForTenantAsync(tenant)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="WhippetApplication"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="WhippetApplication"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<WhippetApplication>>> GetApplicationsForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<WhippetApplication> queryResults = await Context.QueryOver<WhippetApplication>()
                    .JoinQueryOver(app => app.Tenant)
                    .Where(t => t.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<WhippetApplication>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Retrieves the <see cref="WhippetApplication"/> object for the specified <see cref="IWhippetTenant"/> based on a given <see cref="WhippetApplication.ApplicationID"/>.
        /// </summary>
        /// <param name="applicationId"><see cref="WhippetApplication.ApplicationID"/> value.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="WhippetApplication"/> object for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<WhippetApplication> Get(Guid applicationId, IWhippetTenant tenant)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                return Task.Run(() => Get(applicationId, tenant)).Result;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="WhippetApplication"/> object for the specified <see cref="IWhippetTenant"/> based on a given <see cref="WhippetApplication.ApplicationID"/>.
        /// </summary>
        /// <param name="applicationId"><see cref="WhippetApplication.ApplicationID"/> value.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="WhippetApplication"/> object for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<WhippetApplication>> GetAsync(Guid applicationId, IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                IList<WhippetApplication> queryResults = await Context.QueryOver<WhippetApplication>()
                    .Where(wa => wa.ApplicationID == applicationId)
                    .JoinQueryOver(app => app.Tenant)
                    .Where(t => t.ID == tenant.ID)
                    .ListAsync();

                return new WhippetResultContainer<WhippetApplication>(WhippetResult.Success, queryResults.FirstOrDefault());
            }
        }
    }
}
