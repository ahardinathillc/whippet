using System;
using Newtonsoft.Json;

// working on https://adobe-commerce.redoc.ly/2.4.6-admin/tag/cartscartId
namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a Magento customer's shipping information for an order.
    /// </summary>
    public class CartShippingAssignmentInterface : IExtensionInterface, IExtensionAttributes<CartShippingExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the shipping address associated with the order.
        /// </summary>
        [JsonProperty("shipping")]
        public CartShippingInterface Shipping
        { get; set; }
        
        
        
    }
}
