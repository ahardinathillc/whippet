using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using NodaTime;

namespace Athi.Whippet.Adobe.Magento.Sales.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SalesOrder"/> entity objects.
    /// </summary>
    public interface ISalesOrderRepository : IWhippetRestRepository<SalesOrder, uint>, IWhippetExternalQueryRepository<SalesOrder, uint>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date (and time) interval.</param>
        /// <param name="toDate">Ending date (and time) interval.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesOrder>> Get(Instant fromDate, Instant toDate);

        /// <summary>
        /// Retrieves all <see cref="SalesOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date (and time) interval.</param>
        /// <param name="toDate">Ending date (and time) interval.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesOrder>>> GetAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null);
    }
}

