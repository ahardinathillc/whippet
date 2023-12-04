using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Customer;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents a sales rule in Magento.
    /// </summary>
    public interface ISalesRule: IMagentoEntity, IEqualityComparer<ISalesRule>, IMagentoRestEntity, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the rule name.
        /// </summary>
        string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the display labels for the sales rule.
        /// </summary>
        IEnumerable<SalesRuleLabel> StoreLabels
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule description.
        /// </summary>
        string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the websites the rule applies to.
        /// </summary>
        IEnumerable<IStoreWebsite> Websites
        { get; set; }

        /// <summary>
        /// Gets or sets the customer groups that the rule applies to.
        /// </summary>
        IEnumerable<ICustomerGroup> CustomerGroups
        { get; set; }
        
        /// <summary>
        /// Gets or sets the effective date of the coupon.
        /// </summary>
        Instant? EffectiveDate
        { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the coupon.
        /// </summary>
        Instant? ExpirationDate
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of uses per customer.
        /// </summary>
        int UsesPerCustomer
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule condition.
        /// </summary>
        SalesRuleCondition Condition
        { get; set; }

        /// <summary>
        /// Gets or sets the action rule condition.
        /// </summary>
        SalesRuleCondition ActionCondition
        { get; set; }
        
        /// <summary>
        /// Specifies whether rule processing should stop once the current rule has been processed.
        /// </summary>
        bool StopRulesProcessing
        { get; set; }

        /// <summary>
        /// Specifies whether the sales rule is an advanced rule.
        /// </summary>
        bool IsAdvanced
        { get; set; }
        
        /// <summary>
        /// Gets or sets the associated product IDs.
        /// </summary>
        IEnumerable<int> ProductIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order flag.
        /// </summary>
        int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the simple action of the rule.
        /// </summary>
        string SimpleAction
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount applied.
        /// </summary>
        decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum quantity discount that can be applied.
        /// </summary>
        decimal DiscountQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the discount step.
        /// </summary>
        int Step
        { get; set; }

        /// <summary>
        /// Specifies whether the discount is applied to shipping.
        /// </summary>
        bool AppliesToShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of times the rule has been used.
        /// </summary>
        int TimesUsed
        { get; set; }

        /// <summary>
        /// Specifies whether the rule is in the RSS feed.
        /// </summary>
        bool IsRSS
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon type.
        /// </summary>
        string CouponType
        { get; set; }

        /// <summary>
        /// Specifies whether to automatically generate a coupon.
        /// </summary>
        bool AutoGenerateCoupon
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of uses per coupon.
        /// </summary>
        int UsesPerCoupon
        { get; set; }

        /// <summary>
        /// Gets or sets whether to grant free shipping.
        /// </summary>
        string SimpleFreeShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the number of rewards points to add or subtract from the customer's balance.
        /// </summary>
        int RewardPointsDelta
        { get; set; }
    }
}
