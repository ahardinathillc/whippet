using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for a particular <see cref="ISalesRuleCoupon.Code"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetSalesRuleCouponAggregatedReportsByCouponCodeQuery : WhippetQuery<SalesRuleCouponAggregatedReport>, IWhippetQuery<SalesRuleCouponAggregatedReport>
    {
        /// <summary>
        /// Gets or sets the coupon code to query by.
        /// </summary>
        public string Code
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedReportsByCouponCodeQuery"/> class with no arguments.
        /// </summary>
        public GetSalesRuleCouponAggregatedReportsByCouponCodeQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedReportsByCouponCodeQuery"/> class with the specified Code.
        /// </summary>
        /// <param name="couponCode">Coupon code to filter by.</param>
        public GetSalesRuleCouponAggregatedReportsByCouponCodeQuery(string couponCode)
            : this()
        {
            Code = couponCode;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(Code), Code)
            });
        }
    }
}
