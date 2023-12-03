using System;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems
{
    /// <summary>
    /// Represents an inventory stock unit of a Magento product.
    /// </summary>
    public interface IStockItem : IMagentoEntity, IEqualityComparer<IStockItem>
    {
        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        int ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        int ProductID
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the stock item.
        /// </summary>
        decimal Quantity
        { get; set; }

        /// <summary>
        /// Specifies whether the stock item is available.
        /// </summary>
        bool InStock
        { get; set; }

        /// <summary>
        /// Specifies whether <see cref="Quantity"/> is a <see cref="Decimal"/> value or an <see cref="Int32"/> value.
        /// </summary>
        bool IsQuantityDecimal
        { get; set; }

        /// <summary>
        /// Specifies whether notification messages should be dispatched when the quantity reaches a certain level. 
        /// </summary>
        bool ShowDefaultNotificationMessage
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's minimum quantity value should be used for determining whether the item is in stock.
        /// </summary>
        bool UseConfigurationMinimumQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the minimum quantity available for item status in stock.
        /// </summary>
        decimal MinimumQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether to use the configuration's minimum sale quantity value.
        /// </summary>
        bool UseConfigurationMinimumSaleQuantity
        { get; set; }
        
        /// <summary>
        /// Specifies the minimal quantity allowed in the shopping cart or <see langword="null"/> if there is no limitation.
        /// </summary>
        decimal? MinimumSaleQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether to use the configuration's maximum sale quantity value.
        /// </summary>
        bool UseConfigurationMaximumSaleQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum quantity allowed in a Magento shopping cart or <see langword="null"/> if there is no limit.
        /// </summary>
        decimal? MaximumSaleQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's backorder status level should be used for determining when a stock item is on backorder.
        /// </summary>
        bool UseConfigurationBackorder
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity of the current stock item that is on backorder.
        /// </summary>
        int Backorders
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's minimum quantity level notification should be used to notify when a stock item's on-hand quantity is below a particular threshold.
        /// </summary>
        bool UseConfigurationNotifyStockBelowQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the stock item on-hand quantity level that is the minimum threshold for availability before notifying Magento users.
        /// </summary>
        decimal NotifyStockBelowQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's quantity increments value should be used.
        /// </summary>
        bool UseConfigurationQuantityIncrements
        { get; set; }

        /// <summary>
        /// Gets or sets the value to increment the <see cref="Quantity"/> by when new stock is added.
        /// </summary>
        decimal QuantityIncrement
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration should control whether quantity increments are enabled.
        /// </summary>
        bool UseConfigurationEnableQuantityIncrement
        { get; set; }

        /// <summary>
        /// Specifies whether quantity increments are enabled.
        /// </summary>
        bool EnableQuantityIncrement
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration should manage stock.
        /// </summary>
        bool UseConfigurationManageStock
        { get; set; }

        /// <summary>
        /// Specifies whether stock can be managed.
        /// </summary>
        bool ManageStock
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the stock was at a low level.
        /// </summary>
        Instant? LowStockDate
        { get; set; }

        /// <summary>
        /// Specifies whether the quantity is in fractional units or whole units.
        /// </summary>
        bool IsDecimalDivided
        { get; set; }

        /// <summary>
        /// Specifies whether the stock status is automatically updated based on quantity values.
        /// </summary>
        bool AutoStockStatusChanged
        { get; set; }
    }
}
