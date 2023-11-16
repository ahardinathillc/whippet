using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Product.Configurable
{
    /// <summary>
    /// Interface that represents a configurable product's options in Magento.
    /// </summary>
    public class ConfigurableProductOptionValueInterface : IExtensionInterface, IExtensionAttributes<ConfigurableProductOptionValueExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the index of the option.
        /// </summary>
        [JsonProperty("value_index")]
        public int ValueIndex
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        public ConfigurableProductOptionValueExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOptionValueInterface"/> class with no arguments. 
        /// </summary>
        public ConfigurableProductOptionValueInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOptionValueInterface"/> class with no arguments. 
        /// </summary>
        /// <param name="valueIndex">Index of the option.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public ConfigurableProductOptionValueInterface(int valueIndex, ConfigurableProductOptionValueExtensionInterface extensionAttributes)
            : this()
        {
            ValueIndex = valueIndex;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
