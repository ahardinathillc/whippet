using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts.GuestCarts
{
    /// <summary>
    /// Interface that provides information about an available shipping method in Magento.
    /// </summary>
    public class GuestCartShippingMethodInterface : IExtensionInterface, IExtensionAttributes<CartShippingMethodExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the carrier code.
        /// </summary>
        [JsonProperty("carrier_code")]
        public string CarrierCode
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method code.
        /// </summary>
        [JsonProperty("method_code")]
        public string MethodCode
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping carrier title.
        /// </summary>
        [JsonProperty("carrier_title")]
        public string Carrier
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method title.
        /// </summary>
        [JsonProperty("method_title")]
        public string Method
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in store currency.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in base currency.
        /// </summary>
        [JsonProperty("base_amount")]
        public decimal AmountBase
        { get; set; }

        /// <summary>
        /// Specifies whether the shipping method is available.
        /// </summary>
        [JsonProperty("available")]
        public bool Available
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartShippingMethodExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping error message.
        /// </summary>
        [JsonProperty("error_message")]
        public string ErrorMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the price excluding tax.
        /// </summary>
        [JsonProperty("price_excl_tax")]
        public decimal PriceExcludingTax
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestCartShippingMethodInterface"/> class with no arguments.
        /// </summary>
        public GuestCartShippingMethodInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestCartShippingMethodInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="carrierCode">Carrier code.</param>
        /// <param name="methodCode">Method code.</param>
        /// <param name="carrier">Carrier name.</param>
        /// <param name="method">Method name.</param>
        /// <param name="amount">Shipping amount in store currency.</param>
        /// <param name="amountBase">Shipping amount in base currency.</param>
        /// <param name="available">Specifies whether the shipping method is available.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="priceExcludingTax">Shipping price excluding tax.</param>
        public GuestCartShippingMethodInterface(string carrierCode, string methodCode, string carrier, string method, decimal amount, decimal amountBase, bool available, CartShippingMethodExtensionInterface extensionAttributes, string errorMessage, decimal priceExcludingTax)
            : this()
        {
            CarrierCode = carrierCode;
            MethodCode = methodCode;
            Carrier = carrier;
            Method = method;
            Amount = amount;
            AmountBase = amountBase;
            Available = available;
            ExtensionAttributes = extensionAttributes;
            ErrorMessage = errorMessage;
            PriceExcludingTax = priceExcludingTax;
        }
    }
}
