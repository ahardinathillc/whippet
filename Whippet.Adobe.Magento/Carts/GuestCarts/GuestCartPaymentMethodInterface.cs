using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts.GuestCarts
{
    /// <summary>
    /// Interface that provides information about an available payment method for a Magento shopping cart.
    /// </summary>
    public class GuestCartPaymentMethodInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the payment method code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the payment method title.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestCartPaymentMethodInterface"/> class with no arguments.
        /// </summary>
        public GuestCartPaymentMethodInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestCartPaymentMethodInterface"/> class with the specified payment method code and title.
        /// </summary>
        /// <param name="code">Payment method code.</param>
        /// <param name="title">Payment method title.</param>
        public GuestCartPaymentMethodInterface(string code, string title)
            : this()
        {
            Code = code;
            Title = title;
        }
    }
}
