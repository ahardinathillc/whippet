using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides information about a Magento product custom option type.
    /// </summary>
    public class ProductCustomOptionTypeInterface : IExtensionInterface, IExtensionAttributes<ProductCustomOptionTypeExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the option type label.
        /// </summary>
        [JsonProperty("label")]
        public string Label
        { get; set; }
        
        /// <summary>
        /// Gets or sets the option type code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the option type group.
        /// </summary>
        [JsonProperty("group")]
        public string Group
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ProductCustomOptionTypeExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionTypeInterface"/> class with no arguments. 
        /// </summary>
        public ProductCustomOptionTypeInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionTypeInterface"/> class with the specified parameters. 
        /// </summary>
        /// <param name="label">Option type label.</param>
        /// <param name="code">Option type code.</param>
        /// <param name="group">Option type group.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public ProductCustomOptionTypeInterface(string label, string code, string group, ProductCustomOptionTypeExtensionInterface extensionAttributes)
            : this()
        {
            Label = label;
            Code = code;
            Group = group;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
