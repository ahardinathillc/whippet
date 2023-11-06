using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="SalesRuleCoupon"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetSalesRuleCouponByIdQuery : WhippetQuery<SalesRuleCoupon>, IWhippetQuery<SalesRuleCoupon>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public uint CouponID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponByIdQuery"/> class with no arguments.
        /// </summary>
        private GetSalesRuleCouponByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="couponId">ID of the <see cref="SalesRuleCoupon"/> object to retrieve.</param>
        public GetSalesRuleCouponByIdQuery(uint couponId)
            : this()
        {
            CouponID = couponId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(CouponID), CouponID)
            });
        }
    }
}
