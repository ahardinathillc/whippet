using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="WhippetUserRegistrationVerificationRecord"/> entity objects.
    /// </summary>
    public interface IWhippetUserRegistrationVerificationRecordRepository : IWhippetEntityRepository<WhippetUserRegistrationVerificationRecord, Guid>, IWhippetRepository<WhippetUserRegistrationVerificationRecord, Guid>, IWhippetQueryRepository<WhippetUserRegistrationVerificationRecord>
    {
        /// <summary>
        /// Retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>> Get(IWhippetTenant tenant);

        /// <summary>
        /// Retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>> GetAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetUser"/> ID.
        /// </summary>
        /// <param name="userId">ID of the <see cref="IWhippetUser"/> to filter by or <see langword="null"/> to list all records that have not yet been activated.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>> GetByUserId(Guid? userId);

        /// <summary>
        /// Retrieves all <see cref="WhippetUserRegistrationVerificationRecord"/> objects for the specified <see cref="IWhippetUser"/> ID.
        /// </summary>
        /// <param name="userId">ID of the <see cref="IWhippetUser"/> to filter by or <see langword="null"/> to list all records that have not yet been activated.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetUserRegistrationVerificationRecord>>> GetByUserIdAsync(Guid? userId, CancellationToken? cancellationToken = null);
    }
}
