using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="SalesRuleCoupon"/> objects based on a specific <see cref="ISalesRule"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetSalesRuleCouponBySalesRuleQuery : WhippetQuery<SalesRuleCoupon>, IWhippetQuery<SalesRuleCoupon>
    {
        /// <summary>
        /// Gets or sets the <see cref="ISalesRule"/> to query by.
        /// </summary>
        public ISalesRule SalesRule
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponBySalesRuleQuery"/> class with no arguments.
        /// </summary>
        public GetSalesRuleCouponBySalesRuleQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponBySalesRuleQuery"/> class with the specified <see cref="ISalesRule"/>.
        /// </summary>
        /// <param name="salesRule"><see cref="ISalesRule"/> object to filter by.</param>
        public GetSalesRuleCouponBySalesRuleQuery(ISalesRule salesRule)
            : this()
        {
            SalesRule = salesRule;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(SalesRule), SalesRule)
            });
        }
    }
}
