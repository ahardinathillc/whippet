using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Data;

namespace Athi.Whippet.SuperDuper.Legacy.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="LegacySuperDuperAccount"/> entity objects.
    /// </summary>
    public interface ILegacySuperDuperAccountRepository : ISuperDuperLegacyEntityRepository<LegacySuperDuperAccount>, IWhippetQueryRepository<LegacySuperDuperAccount>
    {
        /// <summary>
        /// Gets the <see cref="LegacySuperDuperAccount"/> object with the specified customer number.
        /// </summary>
        /// <param name="customerNumber">Customer number.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<LegacySuperDuperAccount> GetByCustomerNumber(int customerNumber);
        
        /// <summary>
        /// Gets the <see cref="LegacySuperDuperAccount"/> object with the specified customer number.
        /// </summary>
        /// <param name="customerNumber">Customer number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<LegacySuperDuperAccount>> GetByCustomerNumberAsync(int customerNumber, CancellationToken? cancellationToken = null);
    }
}
