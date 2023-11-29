using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Interface that provides information about a sales rule condition in Magento.
    /// </summary>
    public class SalesRuleConditionInterface : IExtensionInterface, IExtensionAttributes<SalesRuleConditionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the condition type.
        /// </summary>
        [JsonProperty("condition_type")]
        public string ConditionType
        { get; set; }
        
        /// <summary>
        /// Gets or sets the list of conditions.
        /// </summary>
        [JsonProperty("conditions")]
        public SalesRuleConditionInterface[] Conditions
        { get; set; }

        /// <summary>
        /// Gets or sets the aggregator type.
        /// </summary>
        [JsonProperty("aggregator_type")]
        public string AggregatorType
        { get; set; }

        /// <summary>
        /// Gets or sets the operator of the condition.
        /// </summary>
        [JsonProperty("operator")]
        public string Operator
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute name of the condition.
        /// </summary>
        [JsonProperty("attribute_name")]
        public string AttributeName
        { get; set; }

        /// <summary>
        /// Gets or sets the value of the condition.
        /// </summary>
        [JsonProperty("value")]
        public string Value
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesRuleConditionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleConditionInterface"/> class with no arguments.
        /// </summary>
        public SalesRuleConditionInterface()
        { }
    }
}
