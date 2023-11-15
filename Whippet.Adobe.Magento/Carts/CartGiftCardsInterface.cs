using System;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a Magento cart's gift carts.
    /// </summary>
    public class CartGiftCardsInterface : IExtensionInterface, IExtensionAttributes<GiftCardAccountExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the gift card codes.
        /// </summary>
        [JsonProperty("gift_cards")]
        public string[] Codes
        { get; set; }

        /// <summary>
        /// Gets or sets the cards' amount in cart currency.
        /// </summary>
        [JsonProperty("gift_cards_amount")]
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the cards' amount in base currency.
        /// </summary>
        [JsonProperty("base_gift_cards_amount")]
        public decimal AmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the cards' amount used in cart currency.
        /// </summary>
        [JsonProperty("gift_cards_amount_used")]
        public decimal AmountUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the cards' amount used in base currency.
        /// </summary>
        [JsonProperty("base_gift_cards_amount_used")]
        public decimal AmountUsedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public GiftCardAccountExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartGiftCardsInterface"/> class with no arguments.
        /// </summary>
        public CartGiftCardsInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartGiftCardsInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="codes">Gift card codes.</param>
        /// <param name="amount">Cards' amount in cart currency.</param>
        /// <param name="amountBase">Cards' amount in base currency.</param>
        /// <param name="amountUsed">Cards' amount used in cart currency.</param>
        /// <param name="amountUsedBase">Cards' amount used in base currency.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CartGiftCardsInterface(IEnumerable<string> codes, decimal amount, decimal amountBase, decimal amountUsed, decimal amountUsedBase, GiftCardAccountExtensionInterface extensionAttributes)
            : this()
        {
            Codes = (codes == null) ? null : codes.ToArray();
            Amount = amount;
            AmountBase = amountBase;
            AmountUsed = amountUsed;
            AmountUsedBase = amountUsedBase;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
