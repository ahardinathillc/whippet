using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Provides information about a <see cref="Product"/> object's numerous customization options for a sales order.
    /// </summary>
    public class ProductOption : MagentoRestEntity<ProductOptionInterface>, IMagentoEntity, IProductOption, IEqualityComparer<IProductOption>, IMagentoAuditableEntity, IMagentoRestEntity, IMagentoRestEntity<ProductOptionInterface>
    {
        public virtual CatalogCustom
        
        /// <summary>
        /// Gets or sets the custom options for the product.
        /// </summary>
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
        public ProductGroupedOptionsInterface[] GroupedOptions
        { get; set; }

    }
}
