using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Extension interface for sales rule objects that comprise a discount code.
    /// </summary>
    public class SalesRuleDiscountInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the discounts that are applied based on the sales rule definition.
        /// </summary>
        [JsonProperty("discount_data")]
        public SalesRuleDiscountDataInterface[] Discounts
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule label.
        /// </summary>
        [JsonProperty("rule_label")]
        public string RuleLabel
        { get; set; }

        /// <summary>
        /// Gets or sets the sales rule ID.
        /// </summary>
        public string RuleID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscountInterface"/> class with no arguments.
        /// </summary>
        public SalesRuleDiscountInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscountInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="discount"><see cref="SalesRuleDiscountInterface"/> object that specifies the discounts applied.</param>
        /// <param name="ruleLabel">Sales rule label that the discounts are associated with.</param>
        /// <param name="ruleId">Sales rule ID.</param>
        public SalesRuleDiscountInterface(SalesRuleDiscountDataInterface discount, string ruleLabel, string ruleId)
            : this(discount == null ? null : new[] { discount }, ruleLabel, ruleId)
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscountInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="discounts"><see cref="SalesRuleDiscountInterface"/> objects that specify the discounts applied.</param>
        /// <param name="ruleLabel">Sales rule label that the discounts are associated with.</param>
        /// <param name="ruleId">Sales rule ID.</param>
        public SalesRuleDiscountInterface(IEnumerable<SalesRuleDiscountDataInterface> discounts, string ruleLabel, string ruleId)
            : this()
        {
            Discounts = (discounts == null) ? null : discounts.ToArray();
            RuleLabel = ruleLabel;
            RuleID = ruleId;
        }
    }
}
