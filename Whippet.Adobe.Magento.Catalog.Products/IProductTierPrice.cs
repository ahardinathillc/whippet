using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Store;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a tier price for an <see cref="IProduct"/> in Magento.
    /// </summary>
    public interface IProductTierPrice : IMagentoEntity, IEqualityComparer<IProductTierPrice>, IMagentoRestEntity, IMagentoRestEntity<ProductTierPriceInterface>, IMagentoCustomAttributesEntity
    {
        /// <summary>
        /// Gets or sets the customer group the tier price applies to.
        /// </summary>
        ICustomerGroup CustomerGroup
        { get; set; }
        
        /// <summary>
        /// Gets or sets the tier quantity.
        /// </summary>
        decimal Quantity
        { get; set; }
        
        /// <summary>
        /// Gets or sets the price value.
        /// </summary>
        decimal Value
        { get; set; }

        /// <summary>
        /// Gets or sets the tier price percentage.
        /// </summary>
        decimal Percentage
        { get; set; }

        /// <summary>
        /// Gets or sets the store website that the tier price applies to.
        /// </summary>
        IStoreWebsite Website
        { get; set; }
    }
}
