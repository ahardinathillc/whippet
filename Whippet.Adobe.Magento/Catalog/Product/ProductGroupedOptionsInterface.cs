using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Product
{
    /// <summary>
    /// Interface that provides information about grouped Magento products.
    /// </summary>
    public class ProductGroupedOptionsInterface : IExtensionInterface, IExtensionAttributes<ProductGroupedOptionsExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the associated product ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the associated product quantity.
        /// </summary>
        [JsonProperty("qty")]
        public int Quantity
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current object.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ProductGroupedOptionsExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGroupedOptionsInterface"/> class with no arguments.
        /// </summary>
        public ProductGroupedOptionsInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductGroupedOptionsInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Associated product ID.</param>
        /// <param name="quantity">Associated product quantity.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public ProductGroupedOptionsInterface(int id, int quantity, ProductGroupedOptionsExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            Quantity = quantity;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
