using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a negotiable Magento cart item.
    /// </summary>
    public class CartNegotiableItemInterface : IExtensionInterface, IExtensionAttributes<CartNegotiableItemExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the cart item ID.
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the original price of the item.
        /// </summary>
        [JsonProperty("original_price")]
        public decimal OriginalPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the original tax amount.
        /// </summary>
        [JsonProperty("original_tax_amount")]
        public decimal OriginalTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the original discount amount.
        /// </summary>
        [JsonProperty("original_discount_amount")]
        public decimal OriginalDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartNegotiableItemExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartNegotiableItemInterface"/> class with no arguments.
        /// </summary>
        public CartNegotiableItemInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartNegotiableItemInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="itemId">Cart item ID.</param>
        /// <param name="originalPrice">Original price of the item.</param>
        /// <param name="originalTaxAmount">Original tax amount.</param>
        /// <param name="originalDiscountAmount">Original discount amount.</param>
        /// <param name="extensionAttributes">Extension attributes of the object.</param>
        public CartNegotiableItemInterface(int itemId, decimal originalPrice, decimal originalTaxAmount, decimal originalDiscountAmount, CartNegotiableItemExtensionInterface extensionAttributes)
            : this()
        {
            ItemID = itemId;
            OriginalPrice = originalPrice;
            OriginalTaxAmount = originalTaxAmount;
            OriginalDiscountAmount = originalDiscountAmount;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
