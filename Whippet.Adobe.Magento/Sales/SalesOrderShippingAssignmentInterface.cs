using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides information about shipping on a Magento order.
    /// </summary>
    public class SalesOrderShippingAssignmentInterface : IExtensionInterface, IExtensionAttributes<SalesOrderShippingAssignmentExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the shipping details for the order.
        /// </summary>
        [JsonProperty("shipping")]
        public SalesOrderShippingInterface Shipping
        { get; set; }

        /// <summary>
        /// Gets or sets the order items of the shipping assignment.
        /// </summary>
        [JsonProperty("items")]
        public SalesOrderItemInterface[] Items
        { get; set; }

        /// <summary>
        /// Gets or sets the stock ID.
        /// </summary>
        [JsonProperty("stock_id")]
        public int StockID
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderShippingAssignmentExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignmentInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderShippingAssignmentInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderShippingAssignmentInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="shipping">Shipping details for the order.</param>
        /// <param name="items">Order items of the shipping assignment.</param>
        /// <param name="stockId">Stock ID.</param>
        /// <param name="extensionAttributes">Extension attributes for the current instance.</param>
        public SalesOrderShippingAssignmentInterface(SalesOrderShippingInterface shipping, IEnumerable<SalesOrderItemInterface> items, int stockId, SalesOrderShippingAssignmentExtensionInterface extensionAttributes)
            : this()
        {
            Shipping = shipping;
            Items = (items == null) ? null : items.ToArray();
            StockID = stockId;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
