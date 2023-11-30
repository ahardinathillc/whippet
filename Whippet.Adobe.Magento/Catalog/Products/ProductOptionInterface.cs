using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides information about a Magento cart's product options.
    /// </summary>
    public class ProductOptionInterface : IExtensionInterface, IExtensionAttributes<ProductOptionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ProductOptionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionInterface"/> class with no arguments.
        /// </summary>
        public ProductOptionInterface()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionInterface"/> class with no arguments.
        /// </summary>
        /// <param name="extensionAttributes">Extension attributes of the object.</param>
        public ProductOptionInterface(ProductOptionExtensionInterface extensionAttributes)
            : this()
        { }
    }
}
