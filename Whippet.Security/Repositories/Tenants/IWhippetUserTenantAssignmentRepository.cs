using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.Tenants.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetUserTenantAssignment"/> objects.
    /// </summary>
    public interface IWhippetUserTenantAssignmentRepository : IWhippetEntityRepository<WhippetUserTenantAssignment, Guid>, IWhippetQueryRepository<WhippetUserTenantAssignment>
    {
        /// <summary>
        /// Gets all <see cref="WhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>> Get(IWhippetTenant tenant);

        /// <summary>
        /// Gets all <see cref="WhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>>> GetAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="WhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>> Get(IWhippetUser user);

        /// <summary>
        /// Gets all <see cref="WhippetUserTenantAssignment"/> objects for the specified <see cref="IWhippetUser"/>.
        /// </summary>
        /// <param name="user"><see cref="IWhippetUser"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>>> GetAsync(IWhippetUser user, CancellationToken? cancellationToken = null);
    }
}
