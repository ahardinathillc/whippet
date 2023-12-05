using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales.Taxes
{
    /// <summary>
    /// Interface that provides information about taxes that are applied to individual sales order items in Magento.
    /// </summary>
    public class SalesOrderItemTaxDetailsInterface : IExtensionInterface, IExtensionAttributes<SalesOrderItemTaxDetailsExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the entity type the tax is applied to.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        { get; set; }
        
        /// <summary>
        /// Gets or sets the item ID if the entity is a product.
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the associated item ID if the item specified in <see cref="ItemID"/> is associated with another item.
        /// </summary>
        [JsonProperty("associated_item_id")]
        public int AssociatedItemID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the applied taxes to the entity.
        /// </summary>
        [JsonProperty("applied_taxes")]
        public SalesOrderAppliedTaxInterface[] AppliedTaxes
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderItemTaxDetailsExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItemTaxDetailsInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderItemTaxDetailsInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItemTaxDetailsInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="type">Type of entity.</param>
        /// <param name="itemId">Item ID (if the entity is an item).</param>
        /// <param name="associatedItemId">Associated item ID (if entity is an item).</param>
        /// <param name="appliedTaxes">Applied taxes to the entity.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public SalesOrderItemTaxDetailsInterface(string type, int itemId, int associatedItemId, IEnumerable<SalesOrderAppliedTaxInterface> appliedTaxes, SalesOrderItemTaxDetailsExtensionInterface extensionAttributes)
            : this()
        {
            Type = type;
            ItemID = itemId;
            AssociatedItemID = associatedItemId;
            AppliedTaxes = (appliedTaxes == null) ? null : appliedTaxes.ToArray();
            ExtensionAttributes = extensionAttributes;
        }
    }
}
