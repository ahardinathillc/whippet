using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Interface that provides information about a coupon in Magento.
    /// </summary>
    public class SalesRuleCouponInterface : IExtensionInterface, IExtensionAttributes<SalesRuleCouponExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the coupon ID.
        /// </summary>
        [JsonProperty("coupon_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule ID associated with the coupon.
        /// </summary>
        [JsonProperty("rule_id")]
        public int RuleID
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon usage limit.
        /// </summary>
        [JsonProperty("usage_limit")]
        public int UsageLimit
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon usage limit per customer.
        /// </summary>
        [JsonProperty("usage_per_customer")]
        public int UsageLimitPerCustomer
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of times the coupon has been used.
        /// </summary>
        [JsonProperty("times_used")]
        public int TimesUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the date the coupon expires.
        /// </summary>
        [JsonProperty("expiration_date")]
        public string ExpirationDate
        { get; set; }

        /// <summary>
        /// Specifies whether the coupon is the primary coupon for the rule that it's associated with.
        /// </summary>
        [JsonProperty("is_primary")]
        public bool IsPrimary
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the coupon was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the type of coupon.
        /// </summary>
        [JsonProperty("type")]
        public int Type
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        public SalesRuleCouponExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleCouponInterface"/> class with no arguments.
        /// </summary>
        public SalesRuleCouponInterface()
        { }
    }
}
