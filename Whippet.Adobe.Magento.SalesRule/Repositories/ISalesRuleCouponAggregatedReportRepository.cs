using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SalesRuleCouponAggregatedReport"/> entity objects.
    /// </summary>
    public interface ISalesRuleCouponAggregatedReportRepository : IWhippetEntityRepository<SalesRuleCouponAggregatedReport, uint>, IWhippetExternalQueryRepository<SalesRuleCouponAggregatedReport, uint>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for the specified <see cref="ISalesRuleCoupon.Code"/> value.
        /// </summary>
        /// <param name="couponCode"><see cref="ISalesRuleCoupon.Code"/> value to get associated <see cref="SalesRuleCouponAggregatedReport"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>> GetForCoupon(string couponCode);

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for the specified <see cref="ISalesRuleCoupon.Code"/> value.
        /// </summary>
        /// <param name="couponCode"><see cref="ISalesRuleCoupon.Code"/> value to get associated <see cref="SalesRuleCouponAggregatedReport"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>>> GetForCouponAsync(string couponCode, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for a specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range.</param>
        /// <param name="toDate">Ending date range.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>> GetForPeriod(Instant fromDate, Instant toDate);

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for a specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range.</param>
        /// <param name="toDate">Ending date range.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>>> GetForPeriodAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null);
    }
}
