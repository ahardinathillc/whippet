using System;
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
    /// Service manager for <see cref="ISalesRuleCoupon"/> domain objects.
    /// </summary>
    public class SalesRuleCouponServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesRuleCouponRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesRuleCouponRepository CouponRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponServiceManager"/> class with the specified <see cref="ISalesRuleCouponRepository"/> object.
        /// </summary>
        /// <param name="couponRepository"><see cref="ISalesRuleCouponRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesRuleCouponServiceManager(ISalesRuleCouponRepository couponRepository)
            : base()
        {
            if (couponRepository == null)
            {
                throw new ArgumentNullException(nameof(couponRepository));
            }
            else
            {
                CouponRepository = couponRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponServiceManager"/> class with the specified <see cref="ISalesRuleCouponRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="couponRepository"><see cref="ISalesRuleCouponRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesRuleCouponServiceManager(IWhippetServiceContext serviceLocator, ISalesRuleCouponRepository couponRepository)
            : base(serviceLocator)
        {
            if (couponRepository == null)
            {
                throw new ArgumentNullException(nameof(couponRepository));
            }
            else
            {
                CouponRepository = couponRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesRuleCoupon"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesRuleCoupon"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesRuleCoupon>> GetCoupon(uint id)
        {
            ISalesRuleCouponQueryHandler<GetSalesRuleCouponByIdQuery> handler = new GetSalesRuleCouponByIdQueryHandler(CouponRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCoupon>> result = await handler.HandleAsync(new GetSalesRuleCouponByIdQuery(id));
            return new WhippetResultContainer<ISalesRuleCoupon>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCoupon"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCoupon>>> GetCoupons()
        {
            ISalesRuleCouponQueryHandler<GetAllSalesRuleCouponsQuery> handler = new GetAllSalesRuleCouponsQueryHandler(CouponRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCoupon>> result = await handler.HandleAsync(new GetAllSalesRuleCouponsQuery());
            return new WhippetResultContainer<IEnumerable<ISalesRuleCoupon>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesRuleCoupon"/> objects in the system for the specified <see cref="ISalesRule"/>.
        /// </summary>
        /// <param name="rule"><see cref="ISalesRule"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesRuleCoupon>>> GetCoupons(ISalesRule rule)
        {
            ISalesRuleCouponQueryHandler<GetSalesRuleCouponBySalesRuleQuery> handler = new GetSalesRuleCouponBySalesRuleQueryHandler(CouponRepository);
            WhippetResultContainer<IEnumerable<SalesRuleCoupon>> result = await handler.HandleAsync(new GetSalesRuleCouponBySalesRuleQuery(rule));
            return new WhippetResultContainer<IEnumerable<ISalesRuleCoupon>>(result.Result, result.Item);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CouponRepository != null)
            {
                CouponRepository.Dispose();
                CouponRepository = null;
            }

            base.Dispose();
        }
    }
}
