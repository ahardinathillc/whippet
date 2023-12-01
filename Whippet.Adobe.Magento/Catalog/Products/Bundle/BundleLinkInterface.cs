using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle
{
    /// <summary>
    /// Interface that provides information about a Magento product bundle link. 
    /// </summary>
    public class BundleLinkInterface : IExtensionInterface, IExtensionAttributes<BundleLinkExtensionInterface> 
    {
        /// <summary>
        /// Gets or sets the link identifier.
        /// </summary>
        [JsonProperty("id")]
        public string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the linked product SKU.
        /// </summary>
        [JsonProperty("sku")]
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the option ID.
        /// </summary>
        [JsonProperty("option_id")]
        public int OptionID
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity
        { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        { get; set; }

        /// <summary>
        /// Specifies whether the link is the default option.
        /// </summary>
        [JsonProperty("is_default")]
        public bool IsDefault
        { get; set; }

        /// <summary>
        /// Gets or sets the price of the linked bundle.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        [JsonProperty("price_type")]
        public int PriceType
        { get; set; }
        
        /// <summary>
        /// Gets or sets the flag that indicates whether the quantity can be changed.
        /// </summary>
        [JsonProperty("can_change_quantity")]
        public int CanChangeQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public BundleLinkExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BundleLinkInterface"/> class with no arguments.
        /// </summary>
        public BundleLinkInterface()
        { }
    }
}
