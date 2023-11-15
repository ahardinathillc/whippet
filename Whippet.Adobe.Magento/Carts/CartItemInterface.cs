using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Catalog.Product;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a Magento customer's product information for an order.
    /// </summary>
    public class CartItemInterface : IExtensionInterface, IExtensionAttributes<CartItemExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        [JsonProperty("item_id")]
        public int? ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the product SKU.
        /// </summary>
        [JsonProperty("sku")]
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        [JsonProperty("qty")]
        public decimal ProductQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the product type.
        /// </summary>
        [JsonProperty("product_type")]
        public string ProductType
        { get; set; }

        /// <summary>
        /// Gets or sets the quote ID.
        /// </summary>
        [JsonProperty("quote_id")]
        public string QuoteID
        { get; set; }

        /// <summary>
        /// Gets or sets the product option to apply to the item.
        /// </summary>
        [JsonProperty("product_option")]
        public ProductOptionInterface ProductOption
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartItemExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartItemInterface"/> class with no arguments.
        /// </summary>
        public CartItemInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartItemInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="itemId">Item ID.</param>
        /// <param name="sku">Item SKU.</param>
        /// <param name="productQuantity">Item quantity listed on the order.</param>
        /// <param name="name">Name of the item.</param>
        /// <param name="price">Item price.</param>
        /// <param name="productType">Product type of the item.</param>
        /// <param name="quoteId">Quote ID (if any).</param>
        /// <param name="productOption">Product option(s).</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CartItemInterface(int? itemId, string sku, decimal productQuantity, string name, decimal price, string productType, string quoteId, ProductOptionInterface productOption, CartItemExtensionInterface extensionAttributes)
            : this()
        {
            ItemID = itemId;
            SKU = sku;
            ProductQuantity = productQuantity;
            Name = name;
            Price = price;
            ProductType = productType;
            QuoteID = quoteId;
            ProductOption = productOption;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
