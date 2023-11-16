using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.StockItem
{
    /// <summary>
    /// Interface that provides information about a Magento stock item.
    /// </summary>
    public class StockItemInterface : IExtensionInterface
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
        /// Specifies whether the configuration's minimum quantity value should be used for determinin
        /// </summary>
        public bool UseConfigurationMinimumQuantity
        { get; set; }

        //TODO: view https://adobe-commerce.redoc.ly/2.4.6-admin/tag/productssku/#operation/GetV1ProductsSku
    }
}
