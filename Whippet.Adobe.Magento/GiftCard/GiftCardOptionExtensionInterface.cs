using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.GiftCard
{
    /// <summary>
    /// Interface that provides extra information to Magento gift card options.
    /// </summary>
    public class GiftCardOptionExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the generated codes for the gift card.
        /// </summary>
        [JsonProperty("giftcard_created_codes")]
        public string[] CreatedCodes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardOptionExtensionInterface"/> class with no arguments.
        /// </summary>
        public GiftCardOptionExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardOptionExtensionInterface"/> class with the specified collection of generated codes.
        /// </summary>
        /// <param name="createdCodes">Generated codes for the gift card.</param>
        public GiftCardOptionExtensionInterface(IEnumerable<string> createdCodes)
            : this()
        {
            CreatedCodes = (createdCodes == null) ? null : createdCodes.ToArray();
        }
    }
}
