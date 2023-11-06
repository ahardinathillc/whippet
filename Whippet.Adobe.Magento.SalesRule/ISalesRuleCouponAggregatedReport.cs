using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents an aggregated report line item for an <see cref="ISalesRuleCoupon"/> usage report.
    /// </summary>
    public interface ISalesRuleCouponAggregatedReport : IMagentoEntity, IEqualityComparer<ISalesRuleCouponAggregatedReport>
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="ISalesRuleCouponAggregatedReport"/>.
        /// </summary>
        uint ReportEntryID
        { get; set; }

        /// <summary>
        /// Gets or sets the date for which the coupon was used.
        /// </summary>
        Instant Period
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IStore"/> that the coupon was applied at.
        /// </summary>
        IStore Store
        { get; set; }

        /// <summary>
        /// Gets or sets the status of the order the coupon was used on.
        /// </summary>
        string OrderStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code that was used.
        /// </summary>
        string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of uses for the period that the coupon was used.
        /// </summary>
        int CouponUses
        { get; set; }

        /// <summary>
        /// Gets or sets the order subtotal.
        /// </summary>
        decimal Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount that was applied.
        /// </summary>
        decimal Discount
        { get; set; }

        /// <summary>
        /// Gets or sets the order total.
        /// </summary>
        decimal Total
        { get; set; }

        /// <summary>
        /// Gets or sets the actual subtotal amount.
        /// </summary>
        decimal Subtotal_Actual
        { get; set; }

        /// <summary>
        /// Gets or sets the actual discount amount that was applied.
        /// </summary>
        decimal Discount_Actual
        { get; set; }

        /// <summary>
        /// Gets or sets the actual total amount that was applied.
        /// </summary>
        decimal Total_Actual
        { get; set; }

        /// <summary>
        /// Gets or sets the rule name.
        /// </summary>
        string RuleName
        { get; set; }
    }
}
