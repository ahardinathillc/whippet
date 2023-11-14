using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a Magento gift message on an order.
    /// </summary>
    public class CartGiftMessageInterface : IExtensionInterface, IExtensionAttributes<CartGiftMessageExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the gift message ID.
        /// </summary>
        [JsonProperty("gift_message_id")]
        public int? GiftMessageID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        [JsonProperty("customer_id")]
        public int? CustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the sender name.
        /// </summary>
        [JsonProperty("sender")]
        public string Sender
        { get; set; }

        /// <summary>
        /// Gets or sets the recipient name.
        /// </summary>
        [JsonProperty("recipient")]
        public string Recipient
        { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        [JsonProperty("message")]
        public string Message
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartGiftMessageExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartGiftMessageInterface"/> class with no arguments.
        /// </summary>
        public CartGiftMessageInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartGiftMessageInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="giftMessageId">Gift message ID.</param>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="sender">Sender name.</param>
        /// <param name="recipient">Recipient name.</param>
        /// <param name="message">Gift card message.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CartGiftMessageInterface(int? giftMessageId, int? customerId, string sender, string recipient, string message, CartGiftMessageExtensionInterface extensionAttributes)
            : this()
        {
            GiftMessageID = giftMessageId;
            CustomerID = customerId;
            Sender = sender;
            Recipient = recipient;
            Message = message;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
