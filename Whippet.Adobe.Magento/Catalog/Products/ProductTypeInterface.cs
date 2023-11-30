using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides information about a product type in Magento.
    /// </summary>
    public class ProductTypeInterface : IExtensionInterface, IExtensionAttributes<ProductTypeExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the product type code.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the product type label.
        /// </summary>
        [JsonProperty("label")]
        public string Label
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ProductTypeExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeInterface"/> class with no arguments.
        /// </summary>
        public ProductTypeInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">Product type code.</param>
        /// <param name="label">Product type label.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public ProductTypeInterface(string name, string label, ProductTypeExtensionInterface extensionAttributes)
            : this()
        {
            Name = name;
            Label = label;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
