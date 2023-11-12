using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a Magento customer's shipping information for an order.
    /// </summary>
    public class CartShippingAssignmentInterface : IExtensionInterface
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
        /// 
        /// </summary>
        public CartShippingExtensionInterface ExtensionAttributes
        { get; set; }
    }
}
