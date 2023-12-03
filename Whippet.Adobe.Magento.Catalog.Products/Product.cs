﻿using System;
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
    public class Product : MagentoRestEntity<ProductInterface>, IMagentoEntity, IProduct, IEqualityComparer<IProduct>, IMagentoAuditableEntity, IMagentoCustomAttributesEntity, IMagentoRestEntity, IMagentoRestEntity<ProductInterface
    {
        private MagentoCustomAttributeCollection _collection;
        private AttributeSet _attribSet;
        private StockItem _stockItem;
        
        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        public virtual string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public virtual string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute set of the product.
        /// </summary>
        public virtual AttributeSet AttributeSet
        {
            get
            {
                if (_attribSet == null)
                {
                    _attribSet = new AttributeSet();
                }

                return _attribSet;
            }
            set
            {
                _attribSet = value;
            }
        }

        IAttributeSet IProduct.AttributeSet
        {
            get
            {
                return AttributeSet;
            }
            set
            {
                AttributeSet = value.ToAttributeSet();
            }
        }
        
        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public virtual decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the product status flag.
        /// </summary>
        public virtual int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the visibility option flag.
        /// </summary>
        public virtual int Visibility
        { get; set; }

        /// <summary>
        /// Gets or sets the product type.
        /// </summary>
        public virtual ProductType Type
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the product was created.
        /// </summary>
        public virtual Instant CreatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the product was last updated.
        /// </summary>
        public virtual Instant? UpdatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the product weight.
        /// </summary>
        public virtual decimal Weight
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="StoreWebsite"/> objects associated with the product.
        /// </summary>
        public virtual IEnumerable<StoreWebsite> Websites
        { get; set; }

        /// <summary>
        /// Gets or sets the category links associated with the product.
        /// </summary>
        public virtual IEnumerable<CategoryLink> CategoryLinks
        { get; set; }
        
        /// <summary>
        /// Gets or sets the discounts associated with the product.
        /// </summary>
        public virtual IEnumerable<SalesRuleDiscountData> Discounts
        { get; set; }

        /// <summary>
        /// Gets or sets the product's bundle options.
        /// </summary>
        public virtual IEnumerable<BundleOption> BundleOptions
        { get; set; }
        
        /// <summary>
        /// Gets or sets the associated stock item for the product.
        /// </summary>
        public virtual StockItem StockItem
        {
            get
            {
                if (_stockItem == null)
                {
                    _stockItem = new StockItem();
                }

                return _stockItem;
            }
            set
            {
                _stockItem = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the downloadable product links.
        /// </summary>
        public virtual IEnumerable<DownloadableLink> ProductLinks
        { get; set; }

        /// <summary>
        /// Gets or sets the downloadable product samples.
        /// </summary>
        public virtual IEnumerable<DownloadableSample> Samples
        { get; set; }

        /// <summary>
        /// Gets or sets the gift card amounts associated with the product.
        /// </summary>
        public virtual IEnumerable<GiftCardAmount> GiftCardAmounts
        { get; set; }

        /// <summary>
        /// Gets or sets the product options if the product is configurable.
        /// </summary>
        public virtual IEnumerable<ConfigurableProductOption> ConfigurableOptions
        { get; set; }

        /// <summary>
        /// Gets or sets the (configurable) product links.
        /// </summary>
        public virtual IEnumerable<ProductLink> ConfigurableOptionLinks
        { get; set; }

        /// <summary>
        /// Gets or sets the product links for the current instance.
        /// </summary>
        public virtual IEnumerable<ProductLink> Links
        { get; set; }

        /// <summary>
        /// Gets or sets the product options.
        /// </summary>
        public virtual IEnumerable<ProductCustomOption> Options
        { get; set; }

        /// <summary>
        /// Gets or sets the product's media gallery entries.
        /// </summary>
        public virtual IEnumerable<ProductMediaGalleryEntry> MediaGalleryEntries
        { get; set; }

        /// <summary>
        /// Gets or sets the product's tier prices.
        /// </summary>
        public virtual IEnumerable<ProductTierPrice> TierPrices
        { get; set; }

        /// <summary>
        /// Gets the entity's <see cref="MagentoCustomAttributeCollection"/> that contains all <see cref="MagentoCustomAttribute"/> entries. This property is read-only.
        /// </summary>
        public virtual MagentoCustomAttributeCollection CustomAttributes
        {
            get
            {
                if (_collection == null)
                {
                    _collection = new MagentoCustomAttributeCollection();
                }

                return _collection;
            }
        }

    }
}
