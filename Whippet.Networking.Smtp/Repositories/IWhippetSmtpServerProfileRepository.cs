using System;
using FluentNHibernate.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Networking.Smtp.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="WhippetSmtpServerProfile"/> entity objects.
    /// </summary>
    public interface IWhippetSmtpServerProfileRepository : IWhippetEntityRepository<WhippetSmtpServerProfile, Guid>, IWhippetQueryRepository<WhippetSmtpServerProfile>
    {
        /// <summary>
        /// Gets the default <see cref="WhippetSmtpServerProfile"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<WhippetSmtpServerProfile> GetDefaultProfile(IWhippetTenant tenant);

        /// <summary>
        /// Gets the default <see cref="WhippetSmtpServerProfile"/> for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<WhippetSmtpServerProfile>> GetDefaultProfileAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="WhippetSmtpServerProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="WhippetSmtpServerProfile"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>> GetForTenant(IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="WhippetSmtpServerProfile"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="WhippetSmtpServerProfile"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetSmtpServerProfile>>> GetForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
