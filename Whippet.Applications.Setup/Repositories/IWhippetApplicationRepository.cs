using System;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Applications.Setup.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="WhippetApplication"/> entity objects.
    /// </summary>
    public interface IWhippetApplicationRepository : IWhippetEntityRepository<WhippetApplication, Guid>, IWhippetRepository<WhippetApplication, Guid>, IWhippetQueryRepository<WhippetApplication>
    {
        /// <summary>
        /// Retrieves all <see cref="WhippetApplication"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="WhippetApplication"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetApplication>> GetApplicationsForTenant(IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="WhippetApplication"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="WhippetApplication"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetApplication>>> GetApplicationsForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves the <see cref="WhippetApplication"/> object for the specified <see cref="IWhippetTenant"/> based on a given <see cref="WhippetApplication.ApplicationID"/>.
        /// </summary>
        /// <param name="applicationId"><see cref="WhippetApplication.ApplicationID"/> value.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="WhippetApplication"/> object for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<WhippetApplication> Get(Guid applicationId, IWhippetTenant tenant);

        /// <summary>
        /// Retrieves the <see cref="WhippetApplication"/> object for the specified <see cref="IWhippetTenant"/> based on a given <see cref="WhippetApplication.ApplicationID"/>.
        /// </summary>
        /// <param name="applicationId"><see cref="WhippetApplication.ApplicationID"/> value.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to retrieve the <see cref="WhippetApplication"/> object for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<WhippetApplication>> GetAsync(Guid applicationId, IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
