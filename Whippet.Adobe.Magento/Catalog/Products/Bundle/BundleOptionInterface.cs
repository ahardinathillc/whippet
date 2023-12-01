using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle
{
    /// <summary>
    /// Interface that provides information about a Magento bundle option.
    /// </summary>
    public class BundleOptionInterface : IExtensionInterface, IExtensionAttributes<BundleOptionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the bundle option ID.
        /// </summary>
        [JsonProperty("option_id")]
        public int OptionID
        { get; set; }

        /// <summary>
        /// Gets or sets the option title.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        { get; set; }

        /// <summary>
        /// Specifies whether the option is required.
        /// </summary>
        [JsonProperty("required")]
        public bool Required
        { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the option position.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the product SKU.
        /// </summary>
        [JsonProperty("sku")]
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the product links associated with the bundle option.
        /// </summary>
        [JsonProperty("product_links")]
        public BundleLinkInterface[] ProductLinks
        { get; set; }

        /// <summary>
        /// Gets or sets extra data about the bundle option.
        /// </summary>
        public BundleOptionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BundleOptionInterface"/>.
        /// </summary>
        public BundleOptionInterface()
        { }
    }
}
