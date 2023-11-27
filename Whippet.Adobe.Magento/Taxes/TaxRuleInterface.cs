using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Taxes
{
    /// <summary>
    /// Interface that provides information about a Magento tax rule.
    /// </summary>
    public class TaxRuleInterface : IExtensionInterface, IExtensionAttributes<TaxRuleExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the tax rule ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rule code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rule priority.
        /// </summary>
        [JsonProperty("priority")]
        public int Priority
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rule's sort order.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the customer tax class IDs.
        /// </summary>
        [JsonProperty("customer_tax_class_ids")]
        public int[] CustomerTaxClassIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the product tax class IDs.
        /// </summary>
        [JsonProperty("product_tax_class_ids")]
        public int[] ProductTaxClassIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the tax rate IDs.
        /// </summary>
        [JsonProperty("tax_rate_ids")]
        public int[] TaxRateIDs
        { get; set; }

        /// <summary>
        /// Specifies whether the subtotal should be calculated.
        /// </summary>
        [JsonProperty("calculate_subtotal")]
        public bool CalculateSubtotal
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance. 
        /// </summary>
        [JsonProperty("extension_attributes")]
        public TaxRuleExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRuleInterface"/> class with no arguments.
        /// </summary>
        public TaxRuleInterface()
        { }
    }
}
