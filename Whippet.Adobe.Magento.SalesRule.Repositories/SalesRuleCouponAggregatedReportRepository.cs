using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.SalesRule.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="SalesRuleCouponAggregatedReport"/> entity objects.
    /// </summary>
    public class SalesRuleCouponAggregatedReportRepository : MagentoEntityRepository<SalesRuleCouponAggregatedReport>, ISalesRuleCouponAggregatedReportRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponAggregatedReportRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesRuleCouponAggregatedReportRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponAggregatedReportRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public SalesRuleCouponAggregatedReportRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for the specified <see cref="ISalesRuleCoupon.Code"/> value.
        /// </summary>
        /// <param name="couponCode"><see cref="ISalesRuleCoupon.Code"/> value to get associated <see cref="SalesRuleCouponAggregatedReport"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>> GetForCoupon(string couponCode)
        {
            if (String.IsNullOrWhiteSpace(couponCode))
            {
                throw new ArgumentNullException(nameof(couponCode));
            }
            else
            {
                return Task.Run(() => GetForCouponAsync(couponCode)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for the specified <see cref="ISalesRuleCoupon.Code"/> value.
        /// </summary>
        /// <param name="couponCode"><see cref="ISalesRuleCoupon.Code"/> value to get associated <see cref="SalesRuleCouponAggregatedReport"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>>> GetForCouponAsync(string couponCode, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(couponCode))
            {
                throw new ArgumentNullException(nameof(couponCode));
            }
            else
            {
                IList<SalesRuleCouponAggregatedReport> queryResults = await Context.QueryOver<SalesRuleCouponAggregatedReport>()
                    .WhereRestrictionOn(srca => srca.CouponCode).IsInsensitiveLike(couponCode)
                    .JoinQueryOver<Store>(srca => srca.Store)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for a specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range.</param>
        /// <param name="toDate">Ending date range.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>> GetForPeriod(Instant fromDate, Instant toDate)
        {
            return Task.Run(() => GetForPeriodAsync(fromDate, toDate)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for a specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range.</param>
        /// <param name="toDate">Ending date range.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>>> GetForPeriodAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null)
        {
            IList<SalesRuleCouponAggregatedReport> queryResults = await Context.QueryOver<SalesRuleCouponAggregatedReport>()
                .Where(srca => srca.Period >= fromDate && srca.Period <= toDate)
                .JoinQueryOver<Store>(srca => srca.Store)
                .ListAsync();

            return new WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>>(WhippetResult.Success, queryResults);
        }
    }
}
