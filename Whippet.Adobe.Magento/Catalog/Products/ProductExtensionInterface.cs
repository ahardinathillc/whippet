using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable;
using Athi.Whippet.Adobe.Magento.Catalog.StockItem;
using Athi.Whippet.Adobe.Magento.Downloads;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Athi.Whippet.Adobe.Magento.SalesRule;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides extra information about a Magento product. 
    /// </summary>
    public class ProductExtensionInterface : IExtensionInterface 
    {
        /// <summary>
        /// Gets or sets the website IDs associated with the product.
        /// </summary>
        [JsonProperty("website_ids")]
        public int[] WebsiteIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the category links associated with the product.
        /// </summary>
        [JsonProperty("category_links")]
        public CatalogLinkInterface[] CategoryLinks
        { get; set; }
            
        /// <summary>
        /// Gets or sets discounts associated with the product.
        /// </summary>
        [JsonProperty("discounts")]
        public SalesRuleDiscountInterface[] Discounts
        { get; set; }

        /// <summary>
        /// Gets or sets the bundle options for a product.
        /// </summary>
        [JsonProperty("bundle_product_options")]
        public BundleOptionInterface[] BundleProductOptions
        { get; set; }

        /// <summary>
        /// Gets or sets the associated stock item for the product.
        /// </summary>
        [JsonProperty("stock_item")]
        public StockItemInterface StockItem
        { get; set; }

        /// <summary>
        /// Gets or sets the downloadable links associated with the product.
        /// </summary>
        [JsonProperty("downloadable_product_links")]
        public DownloadableLinkInterface[] DownloadableProductLinks
        { get; set; }

        /// <summary>
        /// Gets or sets the downloadable samples associated with the product.
        /// </summary>
        [JsonProperty("downloadable_product_samples")]
        public DownloadableSampleInterface[] DownloadableProductSamples
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amounts associated with the product.
        /// </summary>
        [JsonProperty("giftcard_amounts")]
        public GiftCardAmountInterface[] GiftCardAmounts
        { get; set; }

        /// <summary>
        /// Gets or sets the configurable options of the product.
        /// </summary>
        [JsonProperty("configurable_product_options")]
        public ConfigurableProductOptionInterface[] ConfigurableProductOptions
        { get; set; }

        /// <summary>
        /// Gets or sets the configurable product link IDs for the current product.
        /// </summary>
        [JsonProperty("configurable_product_links")]
        public int[] ConfigurableProductLinks
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductExtensionInterface"/> class with no arguments.
        /// </summary>
        public ProductExtensionInterface()
        { }
    }
}
