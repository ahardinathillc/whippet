using System;
using Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems.Extensions;
using Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable.Extensions;
using Athi.Whippet.Adobe.Magento.Downloads.Extensions;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Adobe.Magento.SalesRule.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="Product"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IProductExtensions
    {
        /// <summary>
        /// Converts the specified 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Product ToProduct(this IProduct product)
        {
            Product p = null;

            if (product is Product)
            {
                p = (Product)(product);
            }
            else if (p != null)
            {
                p = new Product();
                p.SKU = product.SKU;
                p.Name = product.Name;
                p.AttributeSet = (product.AttributeSet == null) ? null : product.AttributeSet.ToAttributeSet();
                p.Price = product.Price;
                p.Status = product.Status;
                p.Visibility = product.Visibility;
                p.Type = product.Type;
                p.Weight = product.Weight;
                p.Websites = (product.Websites == null) ? null : product.Websites.Select(w => w.ToStoreWebsite());
                p.CategoryLinks = (product.CategoryLinks == null) ? null : product.CategoryLinks.Select(cl => cl);
                p.Discounts = (product.Discounts == null) ? null : product.Discounts.Select(d => d.ToSalesRuleDiscount());
                p.BundleOptions = (product.BundleOptions == null) ? null : product.BundleOptions.Select(b => b);
                p.StockItem = product.StockItem.ToStockItem();
                p.ProductLinks = (product.ProductLinks == null) ? null : product.ProductLinks.Select(pl => pl.ToDownloadableLink());
                p.Samples = (product.Samples == null) ? null : product.Samples.Select(s => s.ToDownloadableSample());
                p.GiftCardAmounts = (product.GiftCardAmounts == null) ? null : product.GiftCardAmounts.Select(g => g);
                p.ConfigurableOptions = (product.ConfigurableOptions == null) ? null : product.ConfigurableOptions.Select(c => c.ToConfigurableProductOption());
                p.ConfigurableOptionLinks = (product.ConfigurableOptionLinks == null) ? null : product.ConfigurableOptionLinks.Select(l => l);
                p.Links = (product.Links == null) ? null : product.Links.Select(l => l);
                p.Options = (product.Options == null) ? null : product.Options.Select(o => o.ToProductCustomOption());
                p.MediaGalleryEntries = (product.MediaGalleryEntries == null) ? null : product.MediaGalleryEntries.Select(e => e.ToProductMediaGalleryEntry());
                p.TierPrices = (product.TierPrices == null) ? null : product.TierPrices.Select(tp => tp.ToProductTierPrice());
            }

            return p;
        }
    }
}
