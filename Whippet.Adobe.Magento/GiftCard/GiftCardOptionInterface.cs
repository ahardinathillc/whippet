using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.GiftCard
{
    /// <summary>
    /// Interface that provides information about a Magento gift card.
    /// </summary>
    public class GiftCardOptionInterface : IExtensionInterface, IExtensionAttributes<GiftCardOptionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the gift card amount.
        /// </summary>
        [JsonProperty("giftcard_amount")]
        public string Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card open amount value.
        /// </summary>
        [JsonProperty("custom_giftcard_amount")]
        public decimal CustomGiftCardAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card sender's name.
        /// </summary>
        [JsonProperty("giftcard_sender_name")]
        public string SenderName
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card recipient's name.
        /// </summary>
        [JsonProperty("giftcard_recipient_name")]
        public string RecipientName
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card sender's e-mail.
        /// </summary>
        [JsonProperty("giftcard_sender_email")]
        public string SenderEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the recipient e-mail.
        /// </summary>
        [JsonProperty("giftcard_recipient_email")]
        public string RecipientEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card message.
        /// </summary>
        [JsonProperty("giftcard_message")]
        public string Message
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extra options for the gift card.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public GiftCardOptionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardOptionInterface"/> class with no arguments.
        /// </summary>
        public GiftCardOptionInterface()
        { }
    }
}
