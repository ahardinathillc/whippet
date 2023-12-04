using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Interface that provides information about a sales rule in Magento.
    /// </summary>
    public class SalesRuleInterface : IExtensionInterface, IExtensionAttributes<SalesRuleExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the rule ID.
        /// </summary>
        [JsonProperty("rule_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the rule name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the display label(s) for the sales rule.
        /// </summary>
        [JsonProperty("store_labels")]
        public SalesRuleLabelInterface[] StoreLabels
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule description.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the website IDs of the sites the rule applies to.
        /// </summary>
        [JsonProperty("website_ids")]
        public int[] WebsiteIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group IDs of the groups the rule applies to.
        /// </summary>
        [JsonProperty("customer_group_ids")]
        public int[] CustomerGroupIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the start date when the coupon is active.
        /// </summary>
        [JsonProperty("from_date")]
        public string EffectiveDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date the coupon is no longer active.
        /// </summary>
        [JsonProperty("to_date")]
        public string ExpirationDate
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of times a customer can use the coupon.
        /// </summary>
        [JsonProperty("uses_per_customer")]
        public int UsesPerCustomer
        { get; set; }

        /// <summary>
        /// Specifies whether the sales rule is active.
        /// </summary>
        [JsonProperty("is_active")]
        public bool Active
        { get; set; }

        /// <summary>
        /// Gets or sets the condition for the sales rule.
        /// </summary>
        [JsonProperty("condition")]
        public SalesRuleConditionInterface Condition
        { get; set; }

        /// <summary>
        /// Gets or sets the action condition for the sales rule.
        /// </summary>
        [JsonProperty("action_condition")]
        public SalesRuleConditionInterface ActionCondition
        { get; set; }

        /// <summary>
        /// Specifies whether rules processing should stop once this rule is processed.
        /// </summary>
        [JsonProperty("stop_rule_processing")]
        public bool StopRulesProcessing
        { get; set; }

        /// <summary>
        /// Specifies whether the sales rule is an advanced rule.
        /// </summary>
        [JsonProperty("is_advanced")]
        public bool IsAdvanced
        { get; set; }

        /// <summary>
        /// Gets or sets the product IDs that the sales rule applies to.
        /// </summary>
        [JsonProperty("product_ids")]
        public int[] ProductIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order of the sales rule.
        /// </summary>
        [JsonProperty("sort_order")]
        public int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the simple action of the rule.
        /// </summary>
        [JsonProperty("simple_action")]
        public string SimpleAction
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount of the rule.
        /// </summary>
        [JsonProperty("discount_amount")]
        public decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the minimum quantity needed to have the discount applied.
        /// </summary>
        [JsonProperty("discount_qty")]
        public decimal DiscountQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the discount step.
        /// </summary>
        [JsonProperty("discount_step")]
        public int DiscountStep
        { get; set; }

        /// <summary>
        /// Specifies whether the rule should be applied to shipping and handling.
        /// </summary>
        [JsonProperty("apply_to_shipping")]
        public bool ApplyToShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the number of times the rule has been used.
        /// </summary>
        [JsonProperty("times_used")]
        public int TimesUsed
        { get; set; }

        /// <summary>
        /// Specifies whether the rule is in the RSS feed.
        /// </summary>
        [JsonProperty("is_rss")]
        public bool IsRSS
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon type.
        /// </summary>
        [JsonProperty("coupon_type")]
        public string CouponType
        { get; set; }

        /// <summary>
        /// Specifies whether the coupon should be auto-generated.
        /// </summary>
        [JsonProperty("use_auto_generation")]
        public bool UseAutoGeneration
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of uses the coupon can be used.
        /// </summary>
        [JsonProperty("uses_per_coupon")]
        public int UsesPerCoupon
        { get; set; }

        /// <summary>
        /// Gets or sets a value that grants free shipping.
        /// </summary>
        [JsonProperty("simple_free_shipping")]
        public string SimpleFreeShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        public SalesRuleExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleInterface"/> class with no arguments.
        /// </summary>
        public SalesRuleInterface()
        { }
    }
}
