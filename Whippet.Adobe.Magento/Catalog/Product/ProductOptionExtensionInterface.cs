using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Catalog;
using Athi.Whippet.Adobe.Magento.Catalog.Product;
using Athi.Whippet.Adobe.Magento.Catalog.Product.Bundle;
using Athi.Whippet.Adobe.Magento.Catalog.Product.Configurable;
using Athi.Whippet.Adobe.Magento.GiftCard;

namespace Athi.Whippet.Adobe.Magento.Catalog.Product
{
    /// <summary>
    /// Interface that provides information about a Magento customer's product options for their order.
    /// </summary>
    public class ProductOptionExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the custom options for the product.
        /// </summary>
        [JsonProperty("custom_options")]
        public CatalogCustomOptionInterface[] CustomOptions
        { get; set; }
        
        /// <summary>
        /// Gets or sets the bundle options for the product.
        /// </summary>
        [JsonProperty("bundle_option")]
        public BundleOptionExtensionInterface[] BundleOptions
        { get; set; }
        
        /// <summary>
        /// Gets or sets the downloadable option for the product.
        /// </summary>
        [JsonProperty("downloadable_option")]
        public DownloadableOptionInterface DownloadableOption
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift card options to apply to the product option.
        /// </summary>
        [JsonProperty("giftcard_item_option")]
        public GiftCardOptionInterface GiftCardOption
        { get; set; }
        
        /// <summary>
        /// Gets or sets the configurable item options for the cart product.
        /// </summary>
        [JsonProperty("configurable_item_options")]
        public ConfigurableItemOptionValueInterface[] ConfigurableItemOptions
        { get; set; }
        
        /// <summary>
        /// Gets or sets the grouped products options.
        /// </summary>
        [JsonProperty("grouped_options")]
        public GroupedOptionsInterface[] GroupedOptions
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionExtensionInterface"/> class with no arguments.
        /// </summary>
        public ProductOptionExtensionInterface()
        { }
    }
}
