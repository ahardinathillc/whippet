using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Provides information about an order's shipping information and totals in Magento.
    /// </summary>
    public class CartShippingInformationInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the payment methods used on the order.
        /// </summary>
        [JsonProperty("payment_methods")]
        public CartPaymentMethodInterface[] PaymentMethods
        { get; set; }
        
        
    }
}
