using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Taxes;

namespace Athi.Whippet.Adobe.Magento.Sales.Taxes
{
    /// <summary>
    /// Interface that provides tax information about an item on a Magento sales order.
    /// </summary>
    public class SalesOrderTaxItemDetailsInterface : IExtensionInterface, IExtensionAttributes<SalesOrderTaxItemDetailsExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the type of item being taxed.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the associated item ID.
        /// </summary>
        [JsonProperty("associated_item_id")]
        public int AssociatedItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the taxes that are applied to the item.
        /// </summary>
        [JsonProperty("applied_taxes")]
        public TaxRateAppliedRateInterface[] AppliedTaxes
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderTaxItemDetailsExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderTaxItemDetailsInterface"/> with no arguments.
        /// </summary>
        public SalesOrderTaxItemDetailsInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderTaxItemDetailsInterface"/> with the specified parameters.
        /// </summary>
        /// <param name="type">Tpe of item being taxed.</param>
        /// <param name="itemId">Item ID.</param>
        /// <param name="associatedItemId">Associated item ID.</param>
        /// <param name="appliedTaxes">Taxes that were applied to the item.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public SalesOrderTaxItemDetailsInterface(string type, int itemId, int associatedItemId, IEnumerable<TaxRateAppliedRateInterface> appliedTaxes, SalesOrderTaxItemDetailsExtensionInterface extensionAttributes)
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
