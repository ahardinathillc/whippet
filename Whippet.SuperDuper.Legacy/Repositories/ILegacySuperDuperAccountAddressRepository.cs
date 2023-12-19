using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="LegacySuperDuperAccountAddress"/> entity objects.
    /// </summary>
    public interface ILegacySuperDuperAccountAddressRepository : ISuperDuperLegacyEntityRepository<LegacySuperDuperAccountAddress>, IWhippetQueryRepository<LegacySuperDuperAccountAddress>
    {
        /// <summary>
        /// Gets all <see cref="LegacySuperDuperAccount"/> objects for the specified account.
        /// </summary>
        /// <param name="account"><see cref="ILegacySuperDuperAccount"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<IEnumerable<LegacySuperDuperAccountAddress>> GetByAccount(ILegacySuperDuperAccount account);
        
        /// <summary>
        /// Gets all <see cref="LegacySuperDuperAccount"/> objects for the specified account.
        /// </summary>
        /// <param name="account"><see cref="ILegacySuperDuperAccount"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<IEnumerable<LegacySuperDuperAccountAddress>>> GetByAccountAsync(ILegacySuperDuperAccount account, CancellationToken? cancellationToken = null);
    }
}
