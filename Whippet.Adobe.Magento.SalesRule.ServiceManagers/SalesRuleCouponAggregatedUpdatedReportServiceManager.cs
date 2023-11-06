using System;
using NodaTime;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.SalesRule.Repositories;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ISalesRuleCouponAggregatedUpdatedReport"/> domain objects.
    /// </summary>
    public class SalesRuleCouponAggregatedUpdatedReportServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesRuleCouponAggregatedUpdatedReportRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesRuleCouponAggregatedUpdatedReportRepository CouponAggregatedUpdatedReportRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponAggregatedUpdatedReportServiceManager"/> class with the specified <see cref="ISalesRuleCouponAggregatedUpdatedReportRepository"/> object.
        /// </summary>
        /// <param name="couponRepository"><see cref="ISalesRuleCouponAggregatedUpdatedReportRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesRuleCouponAggregatedUpdatedReportServiceManager(ISalesRuleCouponAggregatedUpdatedReportRepository couponRepository)
            : base()
        {
            if (couponRepository == null)
            {
                throw new ArgumentNullException(nameof(couponRepository));
            }
            else
            {
                CouponAggregatedUpdatedReportRepository = couponRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponAggregatedUpdatedReportServiceManager"/> class with the specified <see cref="ISalesRuleCouponAggregatedUpdatedReportRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="couponRepository"><see cref="ISalesRuleCouponAggregatedUpdatedReportRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesRuleCouponAggregatedUpdatedReportServiceManager(IWhippetServiceContext serviceLocator, ISalesRuleCouponAggregatedUpdatedReportRepository couponRepository)
            : base(serviceLocator)
        {
            if (couponRepository == null)
            {
                throw new ArgumentNullException(nameof(couponRepository));
            }
            else
            {
                CouponAggregatedUpdatedReportRepository = couponRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesRuleCouponAggregatedUpdatedReport"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesRuleCouponAggregatedUpdatedReport"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesRuleCouponAggregatedUpdatedReport>> GetCouponAggregatedUpdatedReport(uint id)
        {
            ISalesRuleCouponAggregatedUpdatedReportQueryHandler<GetSalesRuleCouponAggregatedUpdatedReportByIdQuery> handler = new GetSalesRuleCouponAggregatedUpdatedReportByIdQueryHandler(CouponAggregatedUpdatedReportRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedUpdatedReport>> result = await handler.HandleAsync(new GetSalesRuleCouponAggregatedUpdatedReportByIdQuery(id));
            return new WhippetResultContainer<ISalesRuleCouponAggregatedUpdatedReport>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCouponAggregatedUpdatedReport"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedUpdatedReport>>> GetCouponAggregatedUpdatedReports()
        {
            ISalesRuleCouponAggregatedUpdatedReportQueryHandler<GetAllSalesRuleCouponAggregatedUpdatedReportsQuery> handler = new GetAllSalesRuleCouponAggregatedUpdatedReportsQueryHandler(CouponAggregatedUpdatedReportRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedUpdatedReport>> result = await handler.HandleAsync(new GetAllSalesRuleCouponAggregatedUpdatedReportsQuery());
            return new WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedUpdatedReport>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCouponAggregatedUpdatedReport"/> objects in the system based on the specified <see cref="ISalesRuleCoupon"/>.
        /// </summary>
        /// <param name="coupon"><see cref="ISalesRuleCoupon"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedUpdatedReport>>> GetCouponAggregatedUpdatedReports(ISalesRuleCoupon coupon)
        {
            if (coupon == null)
            {
                throw new ArgumentNullException(nameof(coupon));
            }
            else
            {
                return await GetCouponAggregatedUpdatedReports(coupon.Code);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCouponAggregatedUpdatedReport"/> objects in the system based on the specified <see cref="ISalesRuleCoupon.Code"/>.
        /// </summary>
        /// <param name="couponCode"><see cref="ISalesRuleCoupon.Code"/> value to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedUpdatedReport>>> GetCouponAggregatedUpdatedReports(string couponCode)
        {
            ISalesRuleCouponAggregatedUpdatedReportQueryHandler<GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQuery> handler = new GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQueryHandler(CouponAggregatedUpdatedReportRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedUpdatedReport>> result = await handler.HandleAsync(new GetSalesRuleCouponAggregatedUpdatedReportsByCouponCodeQuery(couponCode));
            return new WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedUpdatedReport>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCouponAggregatedUpdatedReport"/> objects in the system based on a given period.
        /// </summary>
        /// <param name="fromDate">Starting period to filter by.</param>
        /// <param name="toDate">Ending period to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedUpdatedReport>>> GetCouponAggregatedUpdatedReports(Instant fromDate, Instant toDate)
        {
            ISalesRuleCouponAggregatedUpdatedReportQueryHandler<GetSalesRuleCouponAggregatedUpdatedReportsForPeriodQuery> handler = new GetSalesRuleCouponAggregatedUpdatedReportsForPeriodQueryHandler(CouponAggregatedUpdatedReportRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedUpdatedReport>> result = await handler.HandleAsync(new GetSalesRuleCouponAggregatedUpdatedReportsForPeriodQuery(fromDate, toDate));
            return new WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedUpdatedReport>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CouponAggregatedUpdatedReportRepository != null)
            {
                CouponAggregatedUpdatedReportRepository.Dispose();
                CouponAggregatedUpdatedReportRepository = null;
            }

            base.Dispose();
        }
    }
}
