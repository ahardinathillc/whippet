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
    /// Service manager for <see cref="ISalesRuleCouponAggregatedReport"/> domain objects.
    /// </summary>
    public class SalesRuleCouponAggregatedReportServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesRuleCouponAggregatedReportRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesRuleCouponAggregatedReportRepository CouponAggregatedReportRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponAggregatedReportServiceManager"/> class with the specified <see cref="ISalesRuleCouponAggregatedReportRepository"/> object.
        /// </summary>
        /// <param name="couponRepository"><see cref="ISalesRuleCouponAggregatedReportRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesRuleCouponAggregatedReportServiceManager(ISalesRuleCouponAggregatedReportRepository couponRepository)
            : base()
        {
            if (couponRepository == null)
            {
                throw new ArgumentNullException(nameof(couponRepository));
            }
            else
            {
                CouponAggregatedReportRepository = couponRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponAggregatedReportServiceManager"/> class with the specified <see cref="ISalesRuleCouponAggregatedReportRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="couponRepository"><see cref="ISalesRuleCouponAggregatedReportRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesRuleCouponAggregatedReportServiceManager(IWhippetServiceContext serviceLocator, ISalesRuleCouponAggregatedReportRepository couponRepository)
            : base(serviceLocator)
        {
            if (couponRepository == null)
            {
                throw new ArgumentNullException(nameof(couponRepository));
            }
            else
            {
                CouponAggregatedReportRepository = couponRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesRuleCouponAggregatedReport"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesRuleCouponAggregatedReport"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesRuleCouponAggregatedReport>> GetCouponAggregatedReport(uint id)
        {
            ISalesRuleCouponAggregatedReportQueryHandler<GetSalesRuleCouponAggregatedReportByIdQuery> handler = new GetSalesRuleCouponAggregatedReportByIdQueryHandler(CouponAggregatedReportRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>> result = await handler.HandleAsync(new GetSalesRuleCouponAggregatedReportByIdQuery(id));
            return new WhippetResultContainer<ISalesRuleCouponAggregatedReport>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCouponAggregatedReport"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedReport>>> GetCouponAggregatedReports()
        {
            ISalesRuleCouponAggregatedReportQueryHandler<GetAllSalesRuleCouponAggregatedReportsQuery> handler = new GetAllSalesRuleCouponAggregatedReportsQueryHandler(CouponAggregatedReportRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>> result = await handler.HandleAsync(new GetAllSalesRuleCouponAggregatedReportsQuery());
            return new WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedReport>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCouponAggregatedReport"/> objects in the system based on the specified <see cref="ISalesRuleCoupon"/>.
        /// </summary>
        /// <param name="coupon"><see cref="ISalesRuleCoupon"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedReport>>> GetCouponAggregatedReports(ISalesRuleCoupon coupon)
        {
            if (coupon == null)
            {
                throw new ArgumentNullException(nameof(coupon));
            }
            else
            {
                return await GetCouponAggregatedReports(coupon.Code);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCouponAggregatedReport"/> objects in the system based on the specified <see cref="ISalesRuleCoupon.Code"/>.
        /// </summary>
        /// <param name="couponCode"><see cref="ISalesRuleCoupon.Code"/> value to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedReport>>> GetCouponAggregatedReports(string couponCode)
        {
            ISalesRuleCouponAggregatedReportQueryHandler<GetSalesRuleCouponAggregatedReportsByCouponCodeQuery> handler = new GetSalesRuleCouponAggregatedReportsByCouponCodeQueryHandler(CouponAggregatedReportRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>> result = await handler.HandleAsync(new GetSalesRuleCouponAggregatedReportsByCouponCodeQuery(couponCode));
            return new WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedReport>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCouponAggregatedReport"/> objects in the system based on a given period.
        /// </summary>
        /// <param name="fromDate">Starting period to filter by.</param>
        /// <param name="toDate">Ending period to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedReport>>> GetCouponAggregatedReports(Instant fromDate, Instant toDate)
        {
            ISalesRuleCouponAggregatedReportQueryHandler<GetSalesRuleCouponAggregatedReportsForPeriodQuery> handler = new GetSalesRuleCouponAggregatedReportsForPeriodQueryHandler(CouponAggregatedReportRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCouponAggregatedReport>> result = await handler.HandleAsync(new GetSalesRuleCouponAggregatedReportsForPeriodQuery(fromDate, toDate));
            return new WhippetResultContainer<IEnumerable<ISalesRuleCouponAggregatedReport>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CouponAggregatedReportRepository != null)
            {
                CouponAggregatedReportRepository.Dispose();
                CouponAggregatedReportRepository = null;
            }

            base.Dispose();
        }
    }
}
