using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.GiftCard
{
    /// <summary>
    /// Interface that represents a gift card in Magento.
    /// </summary>
    public class GiftCardInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the gift card ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card code.
        /// </summary>
        [JsonProperty("code")]
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amount.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amount in base currency.
        /// </summary>
        [JsonProperty("base_amount")]
        public decimal AmountBase
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardInterface"/> class with no arguments.
        /// </summary>
        public GiftCardInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Gift card ID.</param>
        /// <param name="code">Gift card code.</param>
        /// <param name="amount">Gift card amount.</param>
        /// <param name="baseAmount">Gift card amount in base currency.</param>
        public GiftCardInterface(int id, string code, decimal amount, decimal baseAmount)
            : this()
        {
            ID = id;
            Code = code;
            Amount = amount;
            AmountBase = baseAmount;
        }
    }
}
