using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides extra information to a Magento cart's gift message.
    /// </summary>
    public class CartGiftMessageExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the entity ID.
        /// </summary>
        [JsonProperty("entity_id")]
        public string EntityID
        { get; set; }

        /// <summary>
        /// Gets or sets the entity type.
        /// </summary>
        [JsonProperty("entity_type")]
        public string EntityType
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrapping ID.
        /// </summary>
        [JsonProperty("wrapping_id")]
        public string WrappingID
        { get; set; }

        /// <summary>
        /// Indicates whether a gift receipt is allowed with the gift message.
        /// </summary>
        [JsonProperty("wrapping_allow_gift_receipt")]
        public bool AllowGiftReceipt
        { get; set; }

        /// <summary>
        /// Specifies whether a printed card is to be included with the gift message.
        /// </summary>
        [JsonProperty("wrapping_add_printed_card")]
        public bool AddPrintedCard
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartGiftMessageExtensionInterface"/> class with no arguments.
        /// </summary>
        public CartGiftMessageExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartGiftMessageExtensionInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="entityId">Entity ID.</param>
        /// <param name="entityType">Entity type.</param>
        /// <param name="wrappingId">Wrapping option ID.</param>
        /// <param name="allowGiftReceipt">Specifies whether a gift receipt is allowed with the order.</param>
        /// <param name="addPrintedCard">Specifies whether a printed card is allowed with the order.</param>
        public CartGiftMessageExtensionInterface(string entityId, string entityType, string wrappingId, bool allowGiftReceipt, bool addPrintedCard)
            : this()
        {
            EntityID = entityId;
            EntityType = entityType;
            WrappingID = wrappingId;
            AllowGiftReceipt = allowGiftReceipt;
            AddPrintedCard = addPrintedCard;
        }
    }
}
