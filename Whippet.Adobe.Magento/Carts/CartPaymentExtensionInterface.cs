using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides extra information to payment information in Magento.
    /// </summary>
    public class CartPaymentExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the agreement IDs of the payment.
        /// </summary>
        [JsonProperty("agreement_ids")]
        public string[] Agreements
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartPaymentExtensionInterface"/> class with no arguments.
        /// </summary>
        public CartPaymentExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartPaymentExtensionInterface"/> class with the specified agreement IDs.
        /// </summary>
        /// <param name="agreements">Agreement IDs to assign to the payment information.</param>
        public CartPaymentExtensionInterface(IEnumerable<string> agreements)
            : this()
        {
            Agreements = (agreements == null) ? null : agreements.ToArray();
        }
    }
}
