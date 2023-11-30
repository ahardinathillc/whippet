using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides extra information about a Magento product's tier price.
    /// </summary>
    public class ProductTierPriceExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the tier price percentage value.
        /// </summary>
        [JsonProperty("percentage_value")]
        public decimal Percentage
        { get; set; }

        /// <summary>
        /// Gets or sets the website ID.
        /// </summary>
        [JsonProperty("website_id")]
        public int WebsiteID
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTierPriceExtensionInterface"/> class with no arguments.
        /// </summary>
        public ProductTierPriceExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTierPriceExtensionInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="percentage">Tier price percentage.</param>
        /// <param name="websiteId">Website ID.</param>
        public ProductTierPriceExtensionInterface(decimal percentage, int websiteId)
            : this()
        {
            Percentage = percentage;
            WebsiteID = websiteId;
        }
    }
}
