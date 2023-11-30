using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Interface that provides a key/value pair for a Magento attribute validation rule.
    /// </summary>
    public class AttributeValidationRuleInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the object key.
        /// </summary>
        [JsonProperty("key")]
        public string Key
        { get; set; }

        /// <summary>
        /// Gets or sets the object value.
        /// </summary>
        [JsonProperty("value")]
        public string Value
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeValidationRuleInterface"/> class with no arguments.
        /// </summary>
        public AttributeValidationRuleInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeValidationRuleInterface"/> class with the specified key and value.
        /// </summary>
        /// <param name="key">Object key.</param>
        /// <param name="value">Object value.</param>
        public AttributeValidationRuleInterface(string key, string value)
            : this()
        {
            Key = key;
            Value = value;
        }
    }
}
