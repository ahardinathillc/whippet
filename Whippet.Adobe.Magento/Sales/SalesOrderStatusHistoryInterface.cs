using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides information about a Magento sales order status.
    /// </summary>
    public class SalesOrderStatusHistoryInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the entry comment.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entry was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the order status history ID.
        /// </summary>
        [JsonProperty("entity_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the entity name.
        /// </summary>
        [JsonProperty("entity_name")]
        public string EntityName
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the customer has been notified. Values greater than zero (0) are <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("is_customer_notified")]
        public int CustomerNotified
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the history entry is visible on the storefront. Values greater than zero (0) are <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("is_visible_on_front")]
        public int VisibleOnStorefront
        { get; set; }

        /// <summary>
        /// Gets or sets the parent ID.
        /// </summary>
        [JsonProperty("parent_id")]
        public int ParentID
        { get; set; }

        /// <summary>
        /// Gets or sets the history item status.
        /// </summary>
        [JsonProperty("status")]
        public string Status
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderStatusHistoryExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderStatusHistoryInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderStatusHistoryInterface()
        { }
    }
}
