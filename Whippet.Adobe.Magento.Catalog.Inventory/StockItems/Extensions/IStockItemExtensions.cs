using System;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IStockItem"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IStockItemExtensions
    {
        public static StockItem ToStockItem(this IStockItem item)
        {
            StockItem stock = null;

            if (item is StockItem)
            {
                stock = (StockItem)(item);
            }
            else
            {
                stock = new StockItem();
                stock.ItemID = item.ItemID;
                stock.ProductID = item.ProductID;
                stock.Quantity = item.Quantity;
                stock.InStock = item.InStock;
                stock.IsQuantityDecimal = item.IsQuantityDecimal;
                stock.ShowDefaultNotificationMessage = item.ShowDefaultNotificationMessage;
                stock.UseConfigurationMinimumQuantity = item.UseConfigurationMinimumQuantity;
                stock.MinimumQuantity = item.MinimumQuantity;
                stock.UseConfigurationMinimumSaleQuantity = item.UseConfigurationMinimumSaleQuantity;
                stock.MinimumSaleQuantity = item.MinimumSaleQuantity;
                stock.UseConfigurationMaximumSaleQuantity = item.UseConfigurationMaximumSaleQuantity;
                stock.MaximumSaleQuantity = item.MaximumSaleQuantity;
                stock.UseConfigurationBackorder = item.UseConfigurationBackorder;
                stock.Backorders = item.Backorders;
                stock.UseConfigurationNotifyStockBelowQuantity = item.UseConfigurationNotifyStockBelowQuantity;
                stock.NotifyStockBelowQuantity = item.NotifyStockBelowQuantity;
                stock.UseConfigurationQuantityIncrements = item.UseConfigurationQuantityIncrements;
                stock.QuantityIncrement = item.QuantityIncrement;
                stock.UseConfigurationEnableQuantityIncrement = item.UseConfigurationEnableQuantityIncrement;
                stock.EnableQuantityIncrement = item.EnableQuantityIncrement;
                stock.UseConfigurationManageStock = item.UseConfigurationManageStock;
                stock.ManageStock = item.ManageStock;
                stock.LowStockDate = item.LowStockDate;
                stock.IsDecimalDivided = item.IsDecimalDivided;
                stock.AutoStockStatusChanged = item.AutoStockStatusChanged;
            }

            return stock;
        }
    }
}
