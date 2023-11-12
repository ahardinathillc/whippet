using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MagentoRestEndpoint"/> entity objects.
    /// </summary>
    public interface IMagentoRestEndpointRepository : IWhippetEntityRepository<MagentoRestEndpoint, Guid>, IWhippetQueryRepository<MagentoRestEndpoint>
    {
        /// <summary>
        /// Retrieves all <see cref="MagentoRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MagentoRestEndpoint"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MagentoRestEndpoint>> GetForTenant(IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="MagentoRestEndpoint"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to get <see cref="MagentoRestEndpoint"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MagentoRestEndpoint>>> GetForTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}