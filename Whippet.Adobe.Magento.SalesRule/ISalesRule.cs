using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Allows for the managing of discounts and promotions that are applied to sales orders in Magento.
    /// </summary>
    public interface ISalesRule : IMagentoEntity, IEqualityComparer<ISalesRule>
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="ISalesRule"/>.
        /// </summary>
        uint RuleID
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the sales rule.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the description of the sales rule.
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// Gets the date from which the sales rule is in effect.
        /// </summary>
        Instant? FromDate
        { get; set; }

        /// <summary>
        /// Gets the date to which the sales rule is no longer in effect.
        /// </summary>
        Instant? ToDate
        { get; set; }

        /// <summary>
        /// Specifies the maximum number of times a customer can use the sales rule or zero (0) if there is no limit.
        /// </summary>
        int UsesPerCustomer
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is currently active.
        /// </summary>
        bool Active
        { get; set; }

        /// <summary>
        /// Gets a JSON serialization of the conditions needed for the sales rule to take effect.
        /// </summary>
        string SerializedConditions
        { get; set; }

        /// <summary>
        /// Gets a JSON serialization of the actions performed by the sales rule.
        /// </summary>
        string SerializedActions
        { get; set; }

        /// <summary>
        /// Indicates whether further rules should be processed after the current rule is encountered.
        /// </summary>
        bool StopProcessingRules
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is an advanced rule.
        /// </summary>
        bool IsAdvanced
        { get; set; }

        /// <summary>
        /// Gets or sets a delimited list of product IDs that the rule applies to specifically.
        /// </summary>
        string ProductIDs
        { get; set; }

        /// <summary>
        /// Specifies the sort order of the sales rule.
        /// </summary>
        uint SortOrder
        { get; set; }

        /// <summary>
        /// Provides a short description of what the sales rule does.
        /// </summary>
        string SimpleAction
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount to apply.
        /// </summary>
        decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the number of discounts to apply.
        /// </summary>
        decimal? DiscountQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the discount step.
        /// </summary>
        uint DiscountStep
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule can be applied to shipping costs.
        /// </summary>
        bool ApplyToShipping
        { get; set; }

        /// <summary>
        /// Represents the number of times the sales rule has been applied.
        /// </summary>
        uint TimesUsed
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is an RSS rule origin.
        /// </summary>
        bool IsRSS
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is a coupon.
        /// </summary>
        bool IsCouponType
        { get; set; }

        /// <summary>
        /// Specifies whether auto-generation should be used for the sales rule.
        /// </summary>
        bool UseAutoGeneration
        { get; set; }

        /// <summary>
        /// Specifies the maximum number of uses that can be applied per coupon.
        /// </summary>
        int UsesPerCoupon
        { get; set; }

        /// <summary>
        /// Indicates whether the sales rule is a simple free shipping rule.
        /// </summary>
        bool IsSimpleFreeShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the row identifier of the current record.
        /// </summary>
        uint RowID
        { get; set; }

        /// <summary>
        /// Gets or sets the update ID.
        /// </summary>
        ulong CreatedIn
        { get; set; }

        /// <summary>
        /// Gets or sets the next update ID.
        /// </summary>
        ulong UpdatedIn
        { get; set; }

        /// <summary>
        /// Specifies whether to use custom text on the coupon.
        /// </summary>
        bool UseCustomCouponText
        { get; set; }

        /// <summary>
        /// Specifies whether the coupon should be applied to the highest priced item.
        /// </summary>
        bool UseCouponOnHighestPricedItem
        { get; set; }

        /// <summary>
        /// Specifies whether the coupon should be applied to the highest priced item.
        /// </summary>
        bool UseCouponOnHighestPricedItem2
        { get; set; }
    }
}

