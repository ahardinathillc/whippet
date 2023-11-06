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

namespace Athi.Whippet.Salesforce.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="SalesforceClientProfile"/> entity objects.
    /// </summary>
    public interface ISalesforceClientProfileRepository : IWhippetEntityRepository<SalesforceClientProfile, Guid>, IWhippetRepository<SalesforceClientProfile, Guid>, IWhippetQueryRepository<SalesforceClientProfile>
    {
        /// <summary>
        /// Retrieves the <see cref="SalesforceClientProfile"/> with the specified profile name.
        /// </summary>
        /// <param name="profileName">Profile name of the <see cref="SalesforceClientProfile"/>.</param>
        /// <param name="tenant">Tenant that the profile is associated with.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<SalesforceClientProfile> Get(string profileName, IWhippetTenant tenant);

        /// <summary>
        /// Retrieves the <see cref="SalesforceClientProfile"/> with the specified profile name.
        /// </summary>
        /// <param name="profileName">Profile name of the <see cref="SalesforceClientProfile"/>.</param>
        /// <param name="tenant">Tenant that the profile is associated with.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<SalesforceClientProfile>> GetAsync(string profileName, IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="SalesforceClientProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve <see cref="SalesforceClientProfile"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceClientProfile>> GetSalesforceProfilesForTenant(IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="SalesforceClientProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve <see cref="SalesforceClientProfile"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceClientProfile>>> GetSalesforceProfilesForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
