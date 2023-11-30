using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable
{
    /// <summary>
    /// Interface that provides configurable options for a Magento product.
    /// </summary>
    public class ConfigurableItemOptionValueInterface : IExtensionInterface, IExtensionAttributes<ConfigurableItemOptionValueExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the option SKU.
        /// </summary>
        [JsonProperty("option_id")]
        public string OptionID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        [JsonProperty("option_value")]
        public int Value
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ConfigurableItemOptionValueExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableItemOptionValueInterface"/> class with no arguments.
        /// </summary>
        public ConfigurableItemOptionValueInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableItemOptionValueInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="optionId">Option SKU.</param>
        /// <param name="value">Item ID.</param>
        /// <param name="extensionAttributes">Extension attributes for the current instance.</param>
        public ConfigurableItemOptionValueInterface(string optionId, int value, ConfigurableItemOptionValueExtensionInterface extensionAttributes)
            : this()
        {
            OptionID = optionId;
            Value = value;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
