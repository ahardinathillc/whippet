using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides information about a Magento product's links.
    /// </summary>
    public class ProductLinkInterface : IExtensionInterface, IExtensionAttributes<ProductLinkExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the product SKU.
        /// </summary>
        [JsonProperty("sku")]
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the link type.
        /// </summary>
        [JsonProperty("link_type")]
        public string LinkType
        { get; set; }

        /// <summary>
        /// Gets or sets the linked product SKU.
        /// </summary>
        [JsonProperty("linked_product_sku")]
        public string LinkedProductSKU
        { get; set; }

        /// <summary>
        /// Gets or sets the linked product type.
        /// </summary>
        [JsonProperty("linked_product_type")]
        public string LinkedProductType
        { get; set; }

        /// <summary>
        /// Gets or sets the link position as displayed in the storefront.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        public ProductLinkExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLinkInterface"/> class with no arguments.
        /// </summary>
        public ProductLinkInterface()
        { }
    }
}
