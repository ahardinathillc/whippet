using System;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IProductCustomOption"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IProductCustomOptionExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IProductCustomOption"/> object to a <see cref="ProductCustomOption"/> object.
        /// </summary>
        /// <param name="option"><see cref="IProductCustomOption"/> object to convert.</param>
        /// <returns><see cref="ProductCustomOption"/> object.</returns>
        public static ProductCustomOption ToProductCustomOption(this IProductCustomOption option)
        {
            ProductCustomOption custOpt = null;

            if (option is ProductCustomOption)
            {
                custOpt = (ProductCustomOption)(option);
            }
            else if (option != null)
            {
                custOpt = new ProductCustomOption();
                custOpt.ProductSKU = option.ProductSKU;
                custOpt.Title = option.Title;
                custOpt.Type = option.Type;
                custOpt.SortOrder = option.SortOrder;
                custOpt.Required = option.Required;
                custOpt.SKU = option.SKU;
                custOpt.Price = option.Price;
                custOpt.PriceType = option.PriceType;
                custOpt.FileExtension = option.FileExtension;
                custOpt.MaxCharacters = option.MaxCharacters;
                custOpt.ImageWidth = option.ImageWidth;
                custOpt.ImageHeight = option.ImageHeight;
                custOpt.Values = (option.Values == null) ? null : option.Values.Select(v => v);
                custOpt.RestEndpoint = (option.RestEndpoint == null) ? null : option.RestEndpoint.ToMagentoRestEndpoint();
                custOpt.Server = (option.Server == null) ? null : option.Server.ToMagentoServer();
            }

            return custOpt;
        }        
    }
}
