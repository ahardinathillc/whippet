using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Provides custom attribute values to a Magento object.
    /// </summary>
    public class CustomAttributeInterface
    {
        /// <summary>
        /// Gets or sets the attribute code.
        /// </summary>
        [JsonProperty("attribute_code")]
        public string AttributeCode
        { get; set; }
        
        /// <summary>
        /// Gets or sets the attribute value.
        /// </summary>
        [JsonProperty("value")]
        public string Value
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAttributeInterface"/> class with no arguments.
        /// </summary>
        public CustomAttributeInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAttributeInterface"/> class with the specified attribute code and value.
        /// </summary>
        /// <param name="attributeCode">Attribute code.</param>
        /// <param name="value">Attribute value.</param>
        public CustomAttributeInterface(string attributeCode, string value)
            : this()
        {
            AttributeCode = attributeCode;
            Value = value;
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[Attribute Code: {0} | Value: {1}]", AttributeCode, Value);
        }
    }
}
