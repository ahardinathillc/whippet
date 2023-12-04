using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Athi.Whippet.Adobe.Magento.Downloads;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Provides information about a <see cref="Product"/> object's numerous customization options for a sales order.
    /// </summary>
    public struct ProductOption : IEqualityComparer<ProductOption>, IExtensionInterfaceMap<ProductOptionInterface>
    {
        /// <summary>
        /// Gets or sets the option values.
        /// </summary>
        public IEnumerable<ProductCustomOptionValue> Values
        { get; set; }
        
        /// <summary>
        /// Gets or sets the custom options for the product.
        /// </summary>
        public IEnumerable<CatalogCustomOption> CustomOptions
        { get; set; }
        
        /// <summary>
        /// Gets or sets the bundle options for the product.
        /// </summary>
        public IEnumerable<BundleOption> BundleOptions
        { get; set; }
        
        /// <summary>
        /// Gets or sets the downloadable option for the product.
        /// </summary>
        public DownloadableOption DownloadableOption
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift card options to apply to the product option.
        /// </summary>
        public GiftCardOption GiftCardOption
        { get; set; }
        
        /// <summary>
        /// Gets or sets the configurable item options for the cart product.
        /// </summary>
        public IEnumerable<ConfigurableItemOptionValue> ConfigurableItemOptions
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOption"/> class with no arguments.
        /// </summary>
        static ProductOption()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOption"/> class with no arguments.
        /// </summary>
        public ProductOption()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOption"/> class with the specified <see cref="ProductOptionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ProductOptionInterface"/> object.</param>
        public ProductOption(ProductOptionInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOption"/> class with the specified parameters.
        /// </summary>
        /// <param name="values">Option values.</param>
        /// <param name="customOptions">Custom options.</param>
        /// <param name="bundleOptions">Bundle options.</param>
        /// <param name="downloadableOption">Downloadable option.</param>
        /// <param name="giftCardOption">Gift card option.</param>
        /// <param name="configurableOptions">Configurable options.</param>
        public ProductOption(IEnumerable<ProductCustomOptionValue> values, IEnumerable<CatalogCustomOption> customOptions, IEnumerable<BundleOption> bundleOptions, DownloadableOption downloadableOption, GiftCardOption giftCardOption, IEnumerable<ConfigurableItemOptionValue> configurableOptions)
            : this()
        {
            Values = values;
            CustomOptions = customOptions;
            BundleOptions = bundleOptions;
            DownloadableOption = downloadableOption;
            GiftCardOption = giftCardOption;
            ConfigurableItemOptions = configurableOptions;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ProductOption)) ? false : Equals((ProductOption)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductOption obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductOption x, ProductOption y)
        {
            return (((x.Values == null) && (y.Values == null)) || ((x.Values != null) && x.Values.SequenceEqual(y.Values)))
                   && (((x.BundleOptions == null) && (y.BundleOptions == null)) || ((x.BundleOptions != null) && x.BundleOptions.SequenceEqual(y.BundleOptions)))
                   && (((x.CustomOptions == null) && (y.CustomOptions == null)) || ((x.CustomOptions != null) && x.CustomOptions.SequenceEqual(y.CustomOptions)))
                   && (((x.ConfigurableItemOptions == null) && (y.ConfigurableItemOptions == null)) || ((x.ConfigurableItemOptions != null) && x.ConfigurableItemOptions.SequenceEqual(y.ConfigurableItemOptions)))
                   && x.DownloadableOption.Equals(y.DownloadableOption)
                   && x.GiftCardOption.Equals(y.GiftCardOption);
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductOptionInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductOptionInterface"/>.</returns>
        public ProductOptionInterface ToInterface()
        {
            ProductOptionInterface poInterface = new ProductOptionInterface();
            poInterface.ExtensionAttributes = new ProductOptionExtensionInterface();
            poInterface.ExtensionAttributes.BundleOptions = (BundleOptions == null) ? null : BundleOptions.Select(bo => bo.ToInterface()).ToArray();
            poInterface.ExtensionAttributes.CustomOptions = (CustomOptions == null) ? null : CustomOptions.Select(co => co.ToInterface()).ToArray();
            poInterface.ExtensionAttributes.ConfigurableItemOptions = (ConfigurableItemOptions == null) ? null : ConfigurableItemOptions.Select(co => co.ToInterface()).ToArray();
            poInterface.ExtensionAttributes.DownloadableOption = DownloadableOption.ToInterface();
            poInterface.ExtensionAttributes.GiftCardOption = GiftCardOption.ToInterface();

            return poInterface;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(BundleOptions, CustomOptions, ConfigurableItemOptions, DownloadableOption, GiftCardOption);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="option"><see cref="ProductOption"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ProductOption option)
        {
            ArgumentNullException.ThrowIfNull(option);
            return option.GetHashCode();
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        public void FromModel(ProductOptionInterface model)
        {
            if (model != null && model.ExtensionAttributes != null)
            {
                BundleOptions = (model.ExtensionAttributes.BundleOptions == null) ? null : model.ExtensionAttributes.BundleOptions.Select(m => new BundleOption(m));
                CustomOptions = (model.ExtensionAttributes.CustomOptions == null) ? null : model.ExtensionAttributes.CustomOptions.Select(m => new CatalogCustomOption(m));
                ConfigurableItemOptions = (model.ExtensionAttributes.ConfigurableItemOptions == null) ? null : model.ExtensionAttributes.ConfigurableItemOptions.Select(m => new ConfigurableItemOptionValue(m));

                if (model.ExtensionAttributes.DownloadableOption != null)
                {
                    DownloadableOption = new DownloadableOption(model.ExtensionAttributes.DownloadableOption);
                }

                if (model.ExtensionAttributes.GiftCardOption != null)
                {
                    GiftCardOption = new GiftCardOption(model.ExtensionAttributes.GiftCardOption);
                }
            }
        }
    }
}
