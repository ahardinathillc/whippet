using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Checkout;

namespace Athi.Whippet.Adobe.Magento.Carts.GuestCarts
{
    public class GuestCartPaymentInformationInterface : IExtensionInterface, IExtensionAttributes<CheckoutPaymentDetailsInterface>
    {
        /// <summary>
        /// Gets or sets the payment methods available for the cart.
        /// </summary>
        [JsonProperty("payment_methods")]
        public CartPaymentMethodInterface[] PaymentMethods
        { get; set; }

        /// <summary>
        /// Gets or sets the cart totals.
        /// </summary>
        [JsonProperty("totals")]
        public CartTotalsInterface[] Totals
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CheckoutPaymentDetailsInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestCartPaymentInformationInterface"/> class with no arguments.
        /// </summary>
        public GuestCartPaymentInformationInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestCartPaymentInformationInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="paymentMethods">Payment methods available to the cart.</param>
        /// <param name="totals">Cart totals.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public GuestCartPaymentInformationInterface(IEnumerable<CartPaymentMethodInterface> paymentMethods, IEnumerable<CartTotalsInterface> totals, CheckoutPaymentDetailsInterface extensionAttributes)
            : this()
        {
            PaymentMethods = (paymentMethods == null) ? null : paymentMethods.ToArray();
            Totals = (totals == null) ? null : totals.ToArray();
            ExtensionAttributes = extensionAttributes;
        }
    }
}
