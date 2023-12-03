using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Categories;
using Athi.Whippet.Adobe.Magento.SalesRule;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable;
using Athi.Whippet.Adobe.Magento.Downloads;
using Athi.Whippet.Adobe.Magento.GiftCard;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a product in Magento.
    /// </summary>
    public interface IProduct : IMagentoEntity, IEqualityComparer<IProduct>, IMagentoAuditableEntity, IMagentoCustomAttributesEntity, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute set of the product.
        /// </summary>
        IAttributeSet AttributeSet
        { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the product status flag.
        /// </summary>
        int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the visibility option flag.
        /// </summary>
        int Visibility
        { get; set; }

        /// <summary>
        /// Gets or sets the product type.
        /// </summary>
        ProductType Type
        { get; set; }

        /// <summary>
        /// Gets or sets the product weight.
        /// </summary>
        decimal Weight
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="StoreWebsite"/> objects associated with the product.
        /// </summary>
        IEnumerable<IStoreWebsite> Websites
        { get; set; }

        /// <summary>
        /// Gets or sets the category links associated with the product.
        /// </summary>
        IEnumerable<CategoryLink> CategoryLinks
        { get; set; }
        
        /// <summary>
        /// Gets or sets the discounts associated with the product.
        /// </summary>
        IEnumerable<SalesRuleDiscountData> Discounts
        { get; set; }

        /// <summary>
        /// Gets or sets the product's bundle options.
        /// </summary>
        IEnumerable<BundleOption> BundleOptions
        { get; set; }
        
        /// <summary>
        /// Gets or sets the associated stock item for the product.
        /// </summary>
        IStockItem StockItem
        { get; set; }
        
        /// <summary>
        /// Gets or sets the downloadable product links.
        /// </summary>
        IEnumerable<IDownloadableLink> ProductLinks
        { get; set; }

        /// <summary>
        /// Gets or sets the downloadable product samples.
        /// </summary>
        IEnumerable<IDownloadableSample> Samples
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amounts associated with the product.
        /// </summary>
        IEnumerable<GiftCardAmount> GiftCardAmounts
        { get; set; }

        /// <summary>
        /// Gets or sets the product options if the product is configurable.
        /// </summary>
        IEnumerable<IConfigurableProductOption> ConfigurableOptions
        { get; set; }

        /// <summary>
        /// Gets or sets the (configurable) product links.
        /// </summary>
        IEnumerable<ProductLink> ConfigurableOptionLinks
        { get; set; }

        /// <summary>
        /// Gets or sets the product links for the current instance.
        /// </summary>
        IEnumerable<ProductLink> Links
        { get; set; }

        /// <summary>
        /// Gets or sets the product options.
        /// </summary>
        IEnumerable<IProductCustomOption> Options
        { get; set; }

        /// <summary>
        /// Gets or sets the product's media gallery entries.
        /// </summary>
        IEnumerable<IProductMediaGalleryEntry> MediaGalleryEntries
        { get; set; }

        /// <summary>
        /// Gets or sets the product's tier prices.
        /// </summary>
        IEnumerable<IProductTierPrice> TierPrices
        { get; set; }

    }
}
