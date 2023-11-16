using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.GiftCard
{
    /// <summary>
    /// Interface that provides information about Magento gift card amounts.
    /// </summary>
    public class GiftCardAmountInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the attribute ID.
        /// </summary>
        [JsonProperty("attribute_id")]
        public int AttributeID
        { get; set; }

        /// <summary>
        /// Gets or sets the website ID.
        /// </summary>
        [JsonProperty("website_id")]
        public int WebsiteID
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amount.
        /// </summary>
        [JsonProperty("value")]
        public decimal Value
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amount as shown on the specified website.
        /// </summary>
        [JsonProperty("website_value")]
        public decimal WebsiteValue
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public GiftCardAmountExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardAmountInterface"/> class with no arguments.
        /// </summary>
        public GiftCardAmountInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardAmountInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="attributeId">Attribute ID.</param>
        /// <param name="websiteId">Website ID.</param>
        /// <param name="value">Gift card value.</param>
        /// <param name="websiteValue">Gift card value as it appears on the website.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public GiftCardAmountInterface(int attributeId, int websiteId, decimal value, decimal websiteValue, GiftCardAmountExtensionInterface extensionAttributes)
            : this()
        {
            AttributeID = attributeId;
            WebsiteID = websiteId;
            Value = value;
            WebsiteValue = websiteValue;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
