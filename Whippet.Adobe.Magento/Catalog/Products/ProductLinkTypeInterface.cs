using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides information about a Magento product link.
    /// </summary>
    public class ProductLinkTypeInterface : IExtensionInterface, IExtensionAttributes<ProductLinkTypeExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the product link code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }
        
        /// <summary>
        /// Gets or sets the product link type name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ProductLinkTypeExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLinkTypeInterface"/> class with no arguments.
        /// </summary>
        public ProductLinkTypeInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLinkTypeInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="code">Link type code.</param>
        /// <param name="name">Link type name.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public ProductLinkTypeInterface(string code, string name, ProductLinkTypeExtensionInterface extensionAttributes)
            : this()
        {
            Code = code;
            Name = name;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
