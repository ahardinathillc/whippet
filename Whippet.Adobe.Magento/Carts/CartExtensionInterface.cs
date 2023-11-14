using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Extension attribute interface for providing extra data for Magento carts.
    /// </summary>
    public class CartExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the shipping data for the order.
        /// </summary>
        [JsonProperty("shipping_assignments")]
        public CartShippingAssignmentInterface[] ShippingAssignments
        { get; set; }
        
        /// <summary>
        /// Gets or sets the negotiable quote associated with the cart.
        /// </summary>
        [JsonProperty("negotiable_quote")]
        public CartNegotiableCartInterface NegotiableQuote
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartExtensionInterface"/> class with no arguments.
        /// </summary>
        public CartExtensionInterface()
            : base()
        { }
    }
}
