using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog
{
    /// <summary>
    /// Represents a custom option that is applied to all items in a Magento catalog.
    /// </summary>
    public class CatalogCustomOption : IExtensionInterfaceMap<CatalogCustomOptionInterface>, IEqualityComparer<CatalogCustomOption>
    {
        /// <summary>
        /// Gets or sets the option ID.
        /// </summary>
        public string ID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the option value.
        /// </summary>
        public string Value
        { get; set; }
        
        /// <summary>
        /// Gets or sets the associated option image.
        /// </summary>
        public MagentoImage? Image
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomOption"/> class with no arguments.
        /// </summary>
        static CatalogCustomOption()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomOption"/> class with no arguments.
        /// </summary>
        public CatalogCustomOption()
            : base()
        { }

        public CatalogCustomOption

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ICatalogCustomOption)) ? false : Equals((ICatalogCustomOption)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ICatalogCustomOption obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ICatalogCustomOption x, ICatalogCustomOption y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.SKU?.Trim(), y.SKU?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                            && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="CatalogCustomOptionInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="CatalogCustomOptionInterface"/>.</returns>
        public override CatalogCustomOptionInterface ToInterface()
        {
            CatalogCustomOptionInterface product = new CatalogCustomOptionInterface();

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
            product.ExtensionAttributes = new CatalogCustomOptionExtensionInterface();
            product.ExtensionAttributes.Discounts = Discounts.Select(d => d.ToInterface()).ToArray();
            product.ExtensionAttributes.BundleCatalogCustomOptionOptions = (BundleOptions == null) ? null : BundleOptions.Select(b => b.ToInterface()).ToArray();
            product.ExtensionAttributes.StockItem = (StockItem == null) ? null : StockItem.ToInterface();
            product.ExtensionAttributes.DownloadableCatalogCustomOptionLinks = (CatalogCustomOptionLinks == null) ? null : CatalogCustomOptionLinks.Select(pl => pl.ToInterface()).ToArray();
            product.ExtensionAttributes.DownloadableCatalogCustomOptionSamples = (Samples == null) ? null : Samples.Select(s => s.ToInterface()).ToArray();
            product.ExtensionAttributes.GiftCardAmounts = (GiftCardAmounts == null) ? null : GiftCardAmounts.Select(g => g.ToInterface()).ToArray();
            product.ExtensionAttributes.ConfigurableCatalogCustomOptionOptions = (ConfigurableOptions == null) ? null : ConfigurableOptions.Select(o => o.ToInterface()).ToArray();
            product.ExtensionAttributes.ConfigurableCatalogCustomOptionLinks = (ConfigurableOptionLinks == null) ? null : ConfigurableOptionLinks.ToArray();
            product.CatalogCustomOptionLinks = (Links == null) ? null : Links.Select(l => l.ToInterface()).ToArray();
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
            CatalogCustomOption product = new CatalogCustomOption();

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
            product.CatalogCustomOptionLinks = (CatalogCustomOptionLinks == null) ? null : CatalogCustomOptionLinks.Select(p => p);
            product.Samples = (Samples == null) ? null : Samples.Select(s => s);
            product.GiftCardAmounts = (GiftCardAmounts == null) ? null : GiftCardAmounts.Select(g => g);
            product.ConfigurableOptions = (ConfigurableOptions == null) ? null : ConfigurableOptions.Select(c => c.Clone<ConfigurableCatalogCustomOptionOption>());
            product.ConfigurableOptionLinks = (ConfigurableOptionLinks == null) ? null : ConfigurableOptionLinks.Select(c => c);
            product.Options = (Options == null) ? null : Options.Select(o => o.Clone<CatalogCustomOptionCustomOption>());
            product.MediaGalleryEntries = (MediaGalleryEntries == null) ? null : MediaGalleryEntries.Select(m => m.Clone<CatalogCustomOptionMediaGalleryEntry>());
            product.TierPrices = (TierPrices == null) ? null : TierPrices.Select(t => t.Clone<CatalogCustomOptionTierPrice>());
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
            hash.Add(CatalogCustomOptionLinks);
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
        /// <param name="product"><see cref="ICatalogCustomOption"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ICatalogCustomOption product)
        {
            ArgumentNullException.ThrowIfNull(product);
            return product.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(CatalogCustomOptionInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                SKU = model.SKU;
                AttributeSet = new AttributeSet(Convert.ToUInt32(model.AttributeSetID));
                Price = model.Price;
                Status = model.Status;
                Visibility = model.Visibility;
                Type = new CatalogCustomOptionType(model.TypeID, String.Empty);

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
                    BundleOptions = (model.ExtensionAttributes.BundleCatalogCustomOptionOptions == null) ? null : model.ExtensionAttributes.BundleCatalogCustomOptionOptions.Select(b => new BundleOption(b));
                    StockItem = (model.ExtensionAttributes.StockItem == null) ? null : new StockItem(model.ExtensionAttributes.StockItem);
                }
                
                CatalogCustomOptionLinks = (model.ExtensionAttributes.DownloadableCatalogCustomOptionLinks == null) ? null : model.ExtensionAttributes.DownloadableCatalogCustomOptionLinks.Select(l => new DownloadableLink((l)));
                Samples = (model.ExtensionAttributes.DownloadableCatalogCustomOptionSamples == null) ? null : model.ExtensionAttributes.DownloadableCatalogCustomOptionSamples.Select(s => new DownloadableSample(s));
                GiftCardAmounts = (model.ExtensionAttributes.GiftCardAmounts == null) ? null : model.ExtensionAttributes.GiftCardAmounts.Select(g => new GiftCardAmount(g));
                ConfigurableOptions = (model.ExtensionAttributes.ConfigurableCatalogCustomOptionOptions == null) ? null : model.ExtensionAttributes.ConfigurableCatalogCustomOptionOptions.Select(c => new ConfigurableCatalogCustomOptionOption(c));
                ConfigurableOptionLinks = (model.ExtensionAttributes.ConfigurableCatalogCustomOptionLinks == null) ? null : model.ExtensionAttributes.ConfigurableCatalogCustomOptionLinks;
                Links = (model.CatalogCustomOptionLinks == null) ? null : model.CatalogCustomOptionLinks.Select(p => new CatalogCustomOptionLink(p));
                Options = (model.Options == null) ? null : model.Options.Select(o => new CatalogCustomOptionCustomOption(o));
                MediaGalleryEntries = (model.MediaGalleryEntries == null) ? null : model.MediaGalleryEntries.Select(m => new CatalogCustomOptionMediaGalleryEntry(m));
                TierPrices = (model.TierPrices == null) ? null : model.TierPrices.Select(t => new CatalogCustomOptionTierPrice(t));
                CustomAttributes = (model.CustomAttributes == null) ? null : new MagentoCustomAttributeCollection(model.CustomAttributes);
            }
        }
    }
}
