using System;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IProductTierPrice"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IProductTierPriceExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IProductTierPrice"/> object to a <see cref="ProductTierPrice"/> object.
        /// </summary>
        /// <param name="price"><see cref="IProductTierPrice"/> object to convert.</param>
        /// <returns><see cref="ProductTierPrice"/> object.</returns>
        public static ProductTierPrice ToProductTierPrice(this IProductTierPrice price)
        {
            ProductTierPrice tierPrice = null;

            if (price is ProductTierPrice)
            {
                tierPrice = (ProductTierPrice)(price);
            }
            else if (price != null)
            {
                tierPrice = new ProductTierPrice();

                tierPrice.Percentage = price.Percentage;
                tierPrice.CustomAttributes = new MagentoCustomAttributeCollection(price.CustomAttributes);
                tierPrice.Quantity = price.Quantity;
                tierPrice.Value = price.Value;
                tierPrice.Website = price.Website.ToStoreWebsite();
                tierPrice.CustomerGroup = price.CustomerGroup.ToCustomerGroup();
                tierPrice.RestEndpoint = (price.RestEndpoint == null) ? null : price.RestEndpoint.ToMagentoRestEndpoint();
                tierPrice.Server = (price.Server == null) ? null : price.Server.ToMagentoServer();
            }

            return tierPrice;
        }        
    }
}
