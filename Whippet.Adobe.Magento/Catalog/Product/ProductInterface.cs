using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Catalog.Product.Configurable;
using Athi.Whippet.Adobe.Magento.GiftCard;

namespace Athi.Whippet.Adobe.Magento.Catalog.Product
{
    /// <summary>
    /// Interface for a Magento product.
    /// </summary>
    public class ProductInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the SKU of the product.
        /// </summary>
        [JsonProperty("sku")]
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the attribute set ID.
        /// </summary>
        [JsonProperty("attribute_set_id")]
        public int AttributeSetID
        { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the product status.
        /// </summary>
        [JsonProperty("status")]
        public int Status
        { get; set; }

        /// <summary>
        /// Gets or sets the product visibility.
        /// </summary>
        [JsonProperty("visibility")]
        public int Visibility
        { get; set; }

        /// <summary>
        /// Gets or sets the product type ID.
        /// </summary>
        [JsonProperty("type_id")]
        public string TypeID
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the product was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the product was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the product weight.
        /// </summary>
        [JsonProperty("weight")]
        public decimal Weight
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards associated with the product.
        /// </summary>
        [JsonProperty("giftcard_amounts")]
        public GiftCardAmountInterface[] GiftCardAmounts
        { get; set; }
        
        /// <summary>
        /// Gets or sets the configurable options for the product.
        /// </summary>
        [JsonProperty("configurable_product_options")]
        public ConfigurableProductOptionInterface[] ConfigurableProductOptions
        { get; set; }

        /// <summary>
        /// Gets or sets the link IDs of the configurable product.
        /// </summary>
        [JsonProperty("configurable_product_links")]
        public int[] ConfigurableProductLinks
        { get; set; }

    }
}
