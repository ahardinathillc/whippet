using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.GiftWrapping
{
    /// <summary>
    /// Interface that provides information about a Magento gift wrapping on an order.
    /// </summary>
    public class GiftWrapInterface : IExtensionInterface, IExtensionAttributes<GiftWrapExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the gift wrapping ID
        /// </summary>
        [JsonProperty("wrapping_id")]
        public int WrappingID
        { get; set; }

        /// <summary>
        /// Gets or sets the wrapping design option.
        /// </summary>
        [JsonProperty("design")]
        public string Design
        { get; set; }

        /// <summary>
        /// Gets or sets the wrapping status.
        /// </summary>
        [JsonProperty("status")]
        public int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the wrapping's base price.
        /// </summary>
        [JsonProperty("base_price")]
        public decimal BasePrice
        { get; set; }

        /// <summary>
        /// Gets or sets the image name.
        /// </summary>
        [JsonProperty("image_name")] 
        public string ImageName
        { get; set; }

        /// <summary>
        /// Gets or sets the base64-encoded image content.
        /// </summary>
        [JsonProperty("image_base64_content")]
        public string ImageContent
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code.
        /// </summary>
        [JsonProperty("base_currency_code")]
        public string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the website IDs that the wrapping is available in.
        /// </summary>
        [JsonProperty("website_ids")]
        public int[] WebsiteIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the wrapping image URL.
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageURL
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public GiftWrapExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftWrapInterface"/> class with no arguments.
        /// </summary>
        public GiftWrapInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GiftWrapInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Gift wrapping ID.</param>
        /// <param name="design">Gift wrap design.</param>
        /// <param name="status">Gift wrap status.</param>
        /// <param name="basePrice">Base price.</param>
        /// <param name="imageName">Gift wrap image name.</param>
        /// <param name="imageContent">Gift wrap image content that is base64-encoded.</param>
        /// <param name="baseCurrencyCode">Base currency code.</param>
        /// <param name="websiteIds">Website IDs that the wrapping is available in.</param>
        /// <param name="imageUrl">Gift wrap image URL.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public GiftWrapInterface(int id, string design, int status, decimal basePrice, string imageName, string imageContent, string baseCurrencyCode, IEnumerable<int> websiteIds, string imageUrl, GiftWrapExtensionInterface extensionAttributes)
            : this()
        {
            WrappingID = id;
            Design = design;
            Status = status;
            BasePrice = basePrice;
            ImageName = imageName;
            ImageContent = imageContent;
            BaseCurrencyCode = baseCurrencyCode;
            WebsiteIDs = (websiteIds == null) ? null : websiteIds.ToArray();
            ImageURL = imageUrl;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
