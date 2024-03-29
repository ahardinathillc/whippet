﻿using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Athi.Whippet.Adobe.Magento.Downloads;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
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
        public BundleOptionInterface[] BundleOptions
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

        // This didn't show up in the API? Don't know where it came from...
        // ATH 12/4/23
        
        // /// <summary>
        // /// Gets or sets the grouped products options.
        // /// </summary>
        // [JsonProperty("grouped_options")]
        // public ProductGroupedOptionsInterface[] GroupedOptions
        // { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionExtensionInterface"/> class with no arguments.
        /// </summary>
        public ProductOptionExtensionInterface()
        { }
    }
}
