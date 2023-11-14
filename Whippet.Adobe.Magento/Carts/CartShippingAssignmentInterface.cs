using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a Magento customer's shipping information for an order.
    /// </summary>
    public class CartShippingAssignmentInterface : IExtensionInterface, IExtensionAttributes<CartShippingAssignmentExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the shipping address associated with the order.
        /// </summary>
        [JsonProperty("shipping")]
        public CartShippingInterface Shipping
        { get; set; }
        
        /// <summary>
        /// Gets or sets the items to be shipped in the order.
        /// </summary>
        [JsonProperty("items")]
        public CartItemInterface[] Items
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartShippingAssignmentExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartShippingAssignmentInterface"/> class with no arguments.
        /// </summary>
        public CartShippingAssignmentInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartShippingAssignmentInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="shipping">Shipping address information associated with the order.</param>
        /// <param name="items">Items placed on order.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CartShippingAssignmentInterface(CartShippingInterface shipping, IEnumerable<CartItemInterface> items, CartShippingAssignmentExtensionInterface extensionAttributes)
            : this()
        {
            Shipping = shipping;
            Items = (items == null) ? null : items.ToArray();
            ExtensionAttributes = extensionAttributes;
        }
    }
}
