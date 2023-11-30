using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides information about a Magento product's tier price.
    /// </summary>
    public class ProductTierPriceInterface : IExtensionInterface, IExtensionAttributes<ProductTierPriceExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the customer group ID.
        /// </summary>
        [JsonProperty("customer_group_id")]
        public int CustomerGroupID
        { get; set; }

        /// <summary>
        /// Gets or sets the tier quantity.
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity
        { get; set; }

        /// <summary>
        /// Gets or sets the price value.
        /// </summary>
        [JsonProperty("value")]
        public decimal Value
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ProductTierPriceExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTierPriceInterface"/> class with no arguments.
        /// </summary>
        public ProductTierPriceInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTierPriceInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="customerGroupId">Customer group ID.</param>
        /// <param name="quantity">Tier quantity.</param>
        /// <param name="value">Price value.</param>
        public ProductTierPriceInterface(int customerGroupId, decimal quantity, decimal value)
            : this()
        {
            CustomerGroupID = customerGroupId;
            Quantity = quantity;
            Value = value;
        }
    }
}
