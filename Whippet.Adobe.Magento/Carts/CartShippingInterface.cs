using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a Magento customer's shipping information for an order.
    /// </summary>
    public class CartShippingInterface : IExtensionInterface, IExtensionAttributes<CartShippingExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the shipping address of the order.
        /// </summary>
        [JsonProperty("address")]
        public CartAddressInterface Address
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method.
        /// </summary>
        [JsonProperty("method")]
        public string Method
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes that are applied to the Magento object.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartShippingExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartShippingInterface"/> class with no arguments.
        /// </summary>
        public CartShippingInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartShippingInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="address">Shipping address of the order.</param>
        /// <param name="method">Shipping method.</param>
        /// <param name="extensionAttributes">Extension attributes that provide extra information about the shipping assignment.</param>
        public CartShippingInterface(CartAddressInterface address, string method, CartShippingExtensionInterface extensionAttributes)
            : this()
        {
            Address = address;
            Method = method;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
