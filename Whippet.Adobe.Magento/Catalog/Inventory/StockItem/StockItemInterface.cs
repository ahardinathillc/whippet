using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Inventory.StockItems
{
    /// <summary>
    /// Interface that provides information about a Magento stock item.
    /// </summary>
    public class StockItemInterface : IExtensionInterface, IExtensionAttributes<StockItemExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        [JsonProperty("product_id")]
        public int ProductID
        { get; set; }

        /// <summary>
        /// Gets or sets the stock ID.
        /// </summary>
        [JsonProperty("stock_id")]
        public int StockID
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the stock item.
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity
        { get; set; }

        /// <summary>
        /// Specifies whether the stock item is available.
        /// </summary>
        [JsonProperty("is_in_stock")]
        public bool InStock
        { get; set; }

        /// <summary>
        /// Specifies whether <see cref="Quantity"/> is a <see cref="Decimal"/> value or an <see cref="Int32"/> value.
        /// </summary>
        [JsonProperty("is_qty_decimal")]
        public bool IsQuantityDecimal
        { get; set; }

        /// <summary>
        /// Specifies whether notification messages should be dispatched when the quantity reaches a certain level. 
        /// </summary>
        [JsonProperty("show_default_notification_message")]
        public bool ShowDefaultNotificationMessage
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's minimum quantity value should be used for determining whether the item is in stock.
        /// </summary>
        [JsonProperty("use_config_min_qty")]
        public bool UseConfigurationMinimumQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the minimum quantity available for item status in stock.
        /// </summary>
        [JsonProperty("min_qty")]
        public decimal MinimumQuantity
        { get; set; }

        /// <summary>
        /// Flag that specifies whether to use the configuration's minimum sale quantity value. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("use_config_min_sale_qty")]
        public int UseConfigurationMinimumSaleQuantity
        { get; set; }
        
        /// <summary>
        /// Specifies the minimal quantity allowed in the shopping cart or <see langword="null"/> if there is no limitation.
        /// </summary>
        [JsonProperty("min_sale_qty")]
        public decimal? MinimumSaleQuantity
        { get; set; }

        /// <summary>
        /// Flag that specifies whether to use the configuration's maximum sale quantity value. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("max_config_max_sale_qty")]
        public bool UseConfigurationMaximumSaleQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum quantity allowed in a Magento shopping cart or <see langword="null"/> if there is no limit.
        /// </summary>
        [JsonProperty("max_sale_qty")]
        public decimal? MaximumSaleQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's backorder status level should be used for determining when a stock item is on backorder.
        /// </summary>
        [JsonProperty("use_config_backorders")]
        public bool UseConfigurationBackorder
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity of the current stock item that is on backorder.
        /// </summary>
        [JsonProperty("backorders")]
        public int Backorders
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's minimum quantity level notification should be used to notify when a stock item's on-hand quantity is below a particular threshold.
        /// </summary>
        [JsonProperty("use_config_notify_stock_qty")]
        public bool UseConfigurationNotifyStockBelowQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the stock item on-hand quantity level that is the minimum threshold for availability before notifying Magento users.
        /// </summary>
        [JsonProperty("notify_stock_qty")]
        public decimal NotifyStockBelowQuantity
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration's quantity increments value should be used.
        /// </summary>
        [JsonProperty("use_config_qty_increments")]
        public bool UseConfigurationQuantityIncrements
        { get; set; }

        /// <summary>
        /// Gets or sets the value to increment the <see cref="Quantity"/> by when new stock is added.
        /// </summary>
        [JsonProperty("qty_increments")]
        public decimal QuantityIncrement
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration should control whether quantity increments are enabled.
        /// </summary>
        [JsonProperty("use_config_enable_qty_inc")]
        public bool UseConfigurationEnableQuantityIncrement
        { get; set; }

        /// <summary>
        /// Specifies whether quantity increments are enabled.
        /// </summary>
        [JsonProperty("enable_qty_increments")]
        public bool EnableQuantityIncrement
        { get; set; }

        /// <summary>
        /// Specifies whether the configuration should manage stock.
        /// </summary>
        [JsonProperty("use_config_manage_stock")]
        public bool UseConfigurationManageStock
        { get; set; }

        /// <summary>
        /// Specifies whether stock can be managed.
        /// </summary>
        [JsonProperty("manage_stock")]
        public bool ManageStock
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the stock was at a low level.
        /// </summary>
        [JsonProperty("low_stock_date")]
        public string LowStockDate
        { get; set; }

        /// <summary>
        /// Specifies whether the quantity is in fractional units or whole units.
        /// </summary>
        [JsonProperty("is_decimal_divided")]
        public bool IsDecimalDivided
        { get; set; }

        /// <summary>
        /// Flag that specifies whether the stock status is automatically updated based on quantity values. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("stock_status_changed_auto")]
        public int AutoStockStatusChanged
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public StockItemExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StockItemInterface"/> class with no arguments.
        /// </summary>
        public StockItemInterface()
        { }
    }
}
