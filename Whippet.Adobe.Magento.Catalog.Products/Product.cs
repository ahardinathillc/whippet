using System;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.EAV;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Store.Extensions;
using Athi.Whippet.Adobe.Magento.Categories;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable;
using Athi.Whippet.Adobe.Magento.SalesRule;
using Athi.Whippet.Adobe.Magento.Downloads;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems.Extensions;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable.Extensions;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Extensions;
using Athi.Whippet.Adobe.Magento.Downloads.Extensions;
using Athi.Whippet.Adobe.Magento.SalesRule.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a product in Magento.
    /// </summary>
    public class Product : MagentoRestEntity<ProductInterface>, IMagentoEntity, IProduct, IEqualityComparer<IProduct>, IMagentoAuditableEntity, IMagentoCustomAttributesEntity, IMagentoRestEntity, IMagentoRestEntity<ProductInterface>
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

        /// <summary>
        /// Gets or sets the attribute set of the product.
        /// </summary>
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
        /// Gets or sets the <see cref="IStoreWebsite"/> objects associated with the product.
        /// </summary>
        IEnumerable<IStoreWebsite> IProduct.Websites
        {
            get
            {
                return Websites;
            }
            set
            {
                Websites = (value == null) ? null : value.Select(w => w.ToStoreWebsite());
            }
        }

        /// <summary>
        /// Gets or sets the category links associated with the product.
        /// </summary>
        public virtual IEnumerable<CategoryLink> CategoryLinks
        { get; set; }
        
        /// <summary>
        /// Gets or sets the discounts associated with the product.
        /// </summary>
        public virtual IEnumerable<SalesRuleDiscount> Discounts
        { get; set; }

        /// <summary>
        /// Gets or sets the discounts associated with the product.
        /// </summary>
        IEnumerable<ISalesRuleDiscount> IProduct.Discounts
        {
            get
            {
                return Discounts;
            }
            set
            {
                Discounts = (value == null) ? null : Discounts.Select(d => d.ToSalesRuleDiscount());
            }
        }
        
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
        /// Gets or sets the associated stock item for the product.
        /// </summary>
        IStockItem IProduct.StockItem
        {
            get
            {
                return StockItem;
            }
            set
            {
                StockItem = value.ToStockItem();
            }
        }
        
        /// <summary>
        /// Gets or sets the downloadable product links.
        /// </summary>
        public virtual IEnumerable<DownloadableLink> ProductLinks
        { get; set; }

        /// <summary>
        /// Gets or sets the downloadable product links.
        /// </summary>
        IEnumerable<IDownloadableLink> IProduct.ProductLinks
        {
            get
            {
                return ProductLinks;
            }
            set
            {
                ProductLinks = (value == null) ? null : value.Select(v => v.ToDownloadableLink());
            }
        }
        
        /// <summary>
        /// Gets or sets the downloadable product samples.
        /// </summary>
        public virtual IEnumerable<DownloadableSample> Samples
        { get; set; }

        /// <summary>
        /// Gets or sets the downloadable product samples.
        /// </summary>
        IEnumerable<IDownloadableSample> IProduct.Samples
        {
            get
            {
                return Samples;
            }
            set
            {
                Samples = (value == null) ? null : value.Select(v => v.ToDownloadableSample());
            }
        }

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
        /// Gets or sets the product options if the product is configurable.
        /// </summary>
        IEnumerable<IConfigurableProductOption> IProduct.ConfigurableOptions
        {
            get
            {
                return ConfigurableOptions;
            }
            set
            {
                ConfigurableOptions = (value == null) ? null : value.Select(v => v.ToConfigurableProductOption());
            }
        }
        
        /// <summary>
        /// Gets or sets the (configurable) product links.
        /// </summary>
        public virtual IEnumerable<int> ConfigurableOptionLinks
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
        /// Gets or sets the product options.
        /// </summary>
        IEnumerable<IProductCustomOption> IProduct.Options
        {
            get
            {
                return Options;
            }
            set
            {
                Options = (value == null) ? null : value.Select(v => v.ToProductCustomOption());
            }
        }
        
        /// <summary>
        /// Gets or sets the product's media gallery entries.
        /// </summary>
        public virtual IEnumerable<ProductMediaGalleryEntry> MediaGalleryEntries
        { get; set; }

        /// <summary>
        /// Gets or sets the product's media gallery entries.
        /// </summary>
        IEnumerable<IProductMediaGalleryEntry> IProduct.MediaGalleryEntries
        {
            get
            {
                return MediaGalleryEntries;
            }
            set
            {
                MediaGalleryEntries = (value == null) ? null : value.Select(v => v.ToProductMediaGalleryEntry());
            }
        }
        
        /// <summary>
        /// Gets or sets the product's tier prices.
        /// </summary>
        public virtual IEnumerable<ProductTierPrice> TierPrices
        { get; set; }

        /// <summary>
        /// Gets or sets the product's tier prices.
        /// </summary>
        IEnumerable<IProductTierPrice> IProduct.TierPrices
        {
            get
            {
                return TierPrices;
            }
            set
            {
                TierPrices = (value == null) ? null : value.Select(v => v.ToProductTierPrice());
            }
        }

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
            protected internal set
            {
                _collection = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with no arguments.
        /// </summary>
        public Product()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Product(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public Product(ProductInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IProduct)) ? false : Equals((IProduct)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProduct obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProduct x, IProduct y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.SKU?.Trim(), y.SKU?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && (((x.AttributeSet == null) && (y.AttributeSet == null)) || ((x.AttributeSet != null) && x.AttributeSet.Equals(y.AttributeSet)))
                            && x.Price == y.Price
                            && x.Status == y.Status
                            && x.Visibility == y.Visibility
                            && x.Type.Equals(y.Type)
                            && x.Weight == y.Weight
                            && (((x.Websites == null) && (y.Websites == null)) || ((x.Websites != null) && x.Websites.SequenceEqual(y.Websites)))
                            && (((x.CategoryLinks == null) && (y.CategoryLinks == null)) || ((x.CategoryLinks != null) && x.CategoryLinks.SequenceEqual(y.CategoryLinks)))
                            && (((x.Discounts == null) && (y.Discounts == null)) || ((x.Discounts != null) && x.Discounts.SequenceEqual(y.Discounts)))
                            && (((x.BundleOptions == null) && (y.BundleOptions == null)) || ((x.BundleOptions != null) && x.BundleOptions.SequenceEqual(y.BundleOptions)))
                            && (((x.StockItem == null) && (y.StockItem == null)) || ((x.StockItem != null) && x.StockItem.Equals(y.StockItem)))
                            && (((x.ProductLinks == null) && (y.ProductLinks == null)) || ((x.ProductLinks != null) && x.ProductLinks.SequenceEqual(y.ProductLinks)))
                            && (((x.Samples == null) && (y.Samples == null)) || ((x.Samples != null) && x.Samples.SequenceEqual(y.Samples)))
                            && (((x.GiftCardAmounts == null) && (y.GiftCardAmounts == null)) || ((x.GiftCardAmounts != null) && x.GiftCardAmounts.SequenceEqual(y.GiftCardAmounts)))
                            && (((x.ConfigurableOptions == null) && (y.ConfigurableOptions == null)) || ((x.ConfigurableOptions != null) && x.ConfigurableOptions.SequenceEqual(y.ConfigurableOptions)))
                            && (((x.ConfigurableOptionLinks == null) && (y.ConfigurableOptionLinks == null)) || ((x.ConfigurableOptionLinks != null) && x.ConfigurableOptionLinks.SequenceEqual(y.ConfigurableOptionLinks)))
                            && (((x.Links == null) && (y.Links == null)) || ((x.Links != null) && x.Links.SequenceEqual(y.Links)))
                            && (((x.Options == null) && (y.Options == null)) || ((x.Options != null) && x.Options.SequenceEqual(y.Options)))
                            && (((x.MediaGalleryEntries == null) && (y.MediaGalleryEntries == null)) || ((x.MediaGalleryEntries != null) && x.MediaGalleryEntries.SequenceEqual(y.MediaGalleryEntries)))
                            && (((x.TierPrices == null) && (y.TierPrices == null)) || ((x.TierPrices != null) && x.TierPrices.SequenceEqual(y.TierPrices)))
                            && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                            && (((x.CustomAttributes == null) && (y.CustomAttributes == null)) || ((x.CustomAttributes != null) && x.CustomAttributes.Equals(y.CustomAttributes)))
                            && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductAttributeInterface"/>.</returns>
        public override ProductInterface ToInterface()
        {
            ProductInterface product = new ProductInterface();

            product.ID = ID;
            product.SKU = SKU;
            product.Name = Name;
            product.AttributeSetID = (AttributeSet == null) ? default(int) : AttributeSet.ID;
            product.Price = Price;
            product.Status = Status;
            product.Visibility = Visibility;
            product.TypeID = Type.Name;
            product.CreatedAt = CreatedTimestamp.ToDateTimeUtc().ToString();
            product.UpdatedAt = !UpdatedTimestamp.HasValue ? String.Empty : UpdatedTimestamp.Value.ToDateTimeUtc().ToString();
            product.Weight = Weight;
            product.ExtensionAttributes = new ProductExtensionInterface();
            product.ExtensionAttributes.Discounts = Discounts.Select(d => d.ToInterface()).ToArray();
            product.ExtensionAttributes.BundleProductOptions = (BundleOptions == null) ? null : BundleOptions.Select(b => b.ToInterface()).ToArray();
            product.ExtensionAttributes.StockItem = (StockItem == null) ? null : StockItem.ToInterface();
            product.ExtensionAttributes.DownloadableProductLinks = (ProductLinks == null) ? null : ProductLinks.Select(pl => pl.ToInterface()).ToArray();
            product.ExtensionAttributes.DownloadableProductSamples = (Samples == null) ? null : Samples.Select(s => s.ToInterface()).ToArray();
            product.ExtensionAttributes.GiftCardAmounts = (GiftCardAmounts == null) ? null : GiftCardAmounts.Select(g => g.ToInterface()).ToArray();
            product.ExtensionAttributes.ConfigurableProductOptions = (ConfigurableOptions == null) ? null : ConfigurableOptions.Select(o => o.ToInterface()).ToArray();
            product.ExtensionAttributes.ConfigurableProductLinks = (ConfigurableOptionLinks == null) ? null : ConfigurableOptionLinks.ToArray();
            product.ProductLinks = (Links == null) ? null : Links.Select(l => l.ToInterface()).ToArray();
            product.Options = (Options == null) ? null : Options.Select(o => o.ToInterface()).ToArray();
            product.MediaGalleryEntries = (MediaGalleryEntries == null) ? null : MediaGalleryEntries.Select(m => m.ToInterface()).ToArray();
            product.TierPrices = (TierPrices == null) ? null : TierPrices.Select(t => t.ToInterface()).ToArray();
            product.CustomAttributes = (CustomAttributes == null) ? null : CustomAttributes.ToInterface();
            
            return product;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            Product product = new Product();

            product.SKU = SKU;
            product.Name = Name;
            product.AttributeSet = (AttributeSet == null) ? null : AttributeSet.Clone<AttributeSet>();
            product.Price = Price;
            product.Status = Status;
            product.Visibility = Visibility;
            product.Type = Type;
            product.CreatedTimestamp = CreatedTimestamp;
            product.UpdatedTimestamp = UpdatedTimestamp;
            product.Weight = Weight;
            product.Websites = (Websites == null) ? null : Websites.Select(w => w.Clone<StoreWebsite>());
            product.CategoryLinks = (CategoryLinks == null) ? null : CategoryLinks.Select(c => c);
            product.Discounts = (Discounts == null) ? null : Discounts.Select(d => d);
            product.BundleOptions = (BundleOptions == null) ? null : BundleOptions.Select(b => b);
            product.StockItem = (StockItem == null) ? null : StockItem.Clone<StockItem>();
            product.ProductLinks = (ProductLinks == null) ? null : ProductLinks.Select(p => p);
            product.Samples = (Samples == null) ? null : Samples.Select(s => s);
            product.GiftCardAmounts = (GiftCardAmounts == null) ? null : GiftCardAmounts.Select(g => g);
            product.ConfigurableOptions = (ConfigurableOptions == null) ? null : ConfigurableOptions.Select(c => c.Clone<ConfigurableProductOption>());
            product.ConfigurableOptionLinks = (ConfigurableOptionLinks == null) ? null : ConfigurableOptionLinks.Select(c => c);
            product.Options = (Options == null) ? null : Options.Select(o => o.Clone<ProductCustomOption>());
            product.MediaGalleryEntries = (MediaGalleryEntries == null) ? null : MediaGalleryEntries.Select(m => m.Clone<ProductMediaGalleryEntry>());
            product.TierPrices = (TierPrices == null) ? null : TierPrices.Select(t => t.Clone<ProductTierPrice>());
            product.CustomAttributes = (CustomAttributes == null) ? null : new MagentoCustomAttributeCollection(CustomAttributes);
            
            return product;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(SKU);
            hash.Add(Name);
            hash.Add(AttributeSet);
            hash.Add(Price);
            hash.Add(Status);
            hash.Add(Visibility);
            hash.Add(Type);
            hash.Add(CreatedTimestamp);
            hash.Add(UpdatedTimestamp);
            hash.Add(Weight);
            hash.Add(Websites);
            hash.Add(CategoryLinks);
            hash.Add(Discounts);
            hash.Add(BundleOptions);
            hash.Add(StockItem);
            hash.Add(ProductLinks);
            hash.Add(Samples);
            hash.Add(GiftCardAmounts);
            hash.Add(ConfigurableOptions);
            hash.Add(ConfigurableOptionLinks);
            hash.Add(Options);
            hash.Add(MediaGalleryEntries);
            hash.Add(TierPrices);
            hash.Add(CustomAttributes);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="product"><see cref="IProduct"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IProduct product)
        {
            ArgumentNullException.ThrowIfNull(product);
            return product.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(ProductInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                SKU = model.SKU;
                AttributeSet = new AttributeSet(Convert.ToUInt32(model.AttributeSetID));
                Price = model.Price;
                Status = model.Status;
                Visibility = model.Visibility;
                Type = new ProductType(model.TypeID, String.Empty);

                if (!String.IsNullOrWhiteSpace(model.CreatedAt))
                {
                    CreatedTimestamp = Instant.FromDateTimeUtc(DateTime.Parse(model.CreatedAt).ToUniversalTime(true));
                }
                
                if (!String.IsNullOrWhiteSpace(model.UpdatedAt))
                {
                    UpdatedTimestamp = Instant.FromDateTimeUtc(DateTime.Parse(model.UpdatedAt).ToUniversalTime(true));
                }

                Weight = model.Weight;

                if (model.ExtensionAttributes != null)
                {
                    Websites = (model.ExtensionAttributes.WebsiteIDs == null) ? null : model.ExtensionAttributes.WebsiteIDs.Select(w => new StoreWebsite(Convert.ToUInt32(w)));
                    CategoryLinks = (model.ExtensionAttributes.CategoryLinks == null) ? null : model.ExtensionAttributes.CategoryLinks.Select(c => new CategoryLink(c));
                    Discounts = (model.ExtensionAttributes.Discounts == null) ? null : model.ExtensionAttributes.Discounts.Select(d => new SalesRuleDiscount(d));
                    BundleOptions = (model.ExtensionAttributes.BundleProductOptions == null) ? null : model.ExtensionAttributes.BundleProductOptions.Select(b => new BundleOption(b));
                    StockItem = (model.ExtensionAttributes.StockItem == null) ? null : new StockItem(model.ExtensionAttributes.StockItem);
                }
                
                ProductLinks = (model.ExtensionAttributes.DownloadableProductLinks == null) ? null : model.ExtensionAttributes.DownloadableProductLinks.Select(l => new DownloadableLink((l)));
                Samples = (model.ExtensionAttributes.DownloadableProductSamples == null) ? null : model.ExtensionAttributes.DownloadableProductSamples.Select(s => new DownloadableSample(s));
                GiftCardAmounts = (model.ExtensionAttributes.GiftCardAmounts == null) ? null : model.ExtensionAttributes.GiftCardAmounts.Select(g => new GiftCardAmount(g));
                ConfigurableOptions = (model.ExtensionAttributes.ConfigurableProductOptions == null) ? null : model.ExtensionAttributes.ConfigurableProductOptions.Select(c => new ConfigurableProductOption(c));
                ConfigurableOptionLinks = (model.ExtensionAttributes.ConfigurableProductLinks == null) ? null : model.ExtensionAttributes.ConfigurableProductLinks;
                Links = (model.ProductLinks == null) ? null : model.ProductLinks.Select(p => new ProductLink(p));
                Options = (model.Options == null) ? null : model.Options.Select(o => new ProductCustomOption(o));
                MediaGalleryEntries = (model.MediaGalleryEntries == null) ? null : model.MediaGalleryEntries.Select(m => new ProductMediaGalleryEntry(m));
                TierPrices = (model.TierPrices == null) ? null : model.TierPrices.Select(t => new ProductTierPrice(t));
                CustomAttributes = (model.CustomAttributes == null) ? null : new MagentoCustomAttributeCollection(model.CustomAttributes);
            }
        }
    }
}
