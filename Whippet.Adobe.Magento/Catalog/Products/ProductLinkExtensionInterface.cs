using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides extra information about a Magento product.
    /// </summary>
    public class ProductLinkExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLinkExtensionInterface"/> class with no arguments.
        /// </summary>
        public ProductLinkExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLinkExtensionInterface"/> class with the specified quantity.
        /// </summary>
        /// <param name="quantity">Quantity of the product.</param>
        public ProductLinkExtensionInterface(decimal quantity)
            : this()
        {
            Quantity = quantity;
        }
    }
}
