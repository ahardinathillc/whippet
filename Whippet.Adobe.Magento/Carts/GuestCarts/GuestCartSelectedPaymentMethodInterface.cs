using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts.GuestCarts
{
    /// <summary>
    /// Interface that provides payment information for a specified Magento shopping cart.
    /// </summary>
    public class GuestCartSelectedPaymentMethodInterface : IExtensionInterface, IExtensionAttributes<CartPaymentExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the purchase order number.
        /// </summary>
        [JsonProperty("po_number")]
        public string PurchaseOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the payment method code.
        /// </summary>
        [JsonProperty("method")]
        public string Method
        { get; set; }

        /// <summary>
        /// Gets or sets the additional details of the payment.
        /// </summary>
        [JsonProperty("additional_data")]
        public string[] AdditionalData
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartPaymentExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestCartSelectedPaymentMethodInterface"/> class with no arguments.
        /// </summary>
        public GuestCartSelectedPaymentMethodInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestCartSelectedPaymentMethodInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="purchaseOrder">Purchase order number.</param>
        /// <param name="method">Payment method code.</param>
        /// <param name="additionalData">Additional payment details.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public GuestCartSelectedPaymentMethodInterface(string purchaseOrder, string method, IEnumerable<string> additionalData, CartPaymentExtensionInterface extensionAttributes)
            : this()
        {
            PurchaseOrder = purchaseOrder;
            Method = method;
            AdditionalData = (additionalData == null) ? null : additionalData.ToArray();
            ExtensionAttributes = extensionAttributes;
        }
    }
}
