using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Extension interface for Magento sales rule objects that provide discount data for a <see cref="SalesRuleDiscountInterface"/>.
    /// </summary>
    public class SalesRuleDiscountDataInterface : IExtensionInterface
    {   
        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the base amount.
        /// </summary>
        [JsonProperty("base_amount")]
        public decimal BaseAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the original amount before the discount was applied.
        /// </summary>
        [JsonProperty("original_amount")]
        public decimal OriginalAmount
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleDiscountDataInterface"/> class with no arguments.
        /// </summary>
        public SalesRuleDiscountDataInterface()
        { }
    }
}
