using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Product
{
    /// <summary>
    /// Interface that provides custom option configuration to a Magento product.
    /// </summary>
    public class ProductCustomOptionInterface : IExtensionInterface, IExtensionAttributes<ProductCustomOptionExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the product SKU.
        /// </summary>
        [JsonProperty("product_sku")]
        public string ProductSKU
        { get; set; }

        /// <summary>
        /// Gets or sets the product option ID. 
        /// </summary>
        [JsonProperty("option_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the option title.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        [JsonProperty("sort_order")]
        public int SortOrder
        { get; set; }

        /// <summary>
        /// Specifies whether the option is a required option.
        /// </summary>
        [JsonProperty("is_require")]
        public bool Required
        { get; set; }

        /// <summary>
        /// Gets or sets the option price.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the price type.
        /// </summary>
        [JsonProperty("price_type")]
        public string PriceType
        { get; set; }

        /// <summary>
        /// Gets or sets the option SKU.
        /// </summary>
        [JsonProperty("sku")]
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the option file extension.
        /// </summary>
        [JsonProperty("file_extension")]
        public string FileExtension
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of characters for the option.
        /// </summary>
        [JsonProperty("max_characters")]
        public int MaximumCharacters
        { get; set; }

        /// <summary>
        /// Gets or sets the image width for the option.
        /// </summary>
        [JsonProperty("image_size_x")]
        public int ImageWidth
        { get; set; }

        /// <summary>
        /// Gets or sets the image height for the option.
        /// </summary>
        [JsonProperty("image_size_y")]
        public int ImageHeight
        { get; set; }

        /// <summary>
        /// Gets or sets the option values.
        /// </summary>
        [JsonProperty("values")]
        public ProductCustomOptionValueInterface[] Values
        { get; set; }

        /// <summary>
        /// Gets or sets the custom attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ProductCustomOptionExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionInterface"/> class with no arguments.
        /// </summary>
        public ProductCustomOptionInterface()
        { }
    }
}
