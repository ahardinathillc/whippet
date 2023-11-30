using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides information about a Magento product's custom option value.
    /// </summary>
    public class ProductCustomOptionValueInterface : IExtensionInterface
    {
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
        /// Gets or sets the price of the option.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the price type of the option.
        /// </summary>
        [JsonProperty("price_type")]
        public string PriceType
        { get; set; }

        /// <summary>
        /// Gets or sets the SKU of the parent option.
        /// </summary>
        [JsonProperty("sku")]
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the option type. 
        /// </summary>
        [JsonProperty("option_tpe_id")]
        public int OptionTypeID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionValueInterface"/> class with no arguments.
        /// </summary>
        public ProductCustomOptionValueInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionValueInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="title">Value title.</param>
        /// <param name="sortOrder">Value sort order.</param>
        /// <param name="price">Value price.</param>
        /// <param name="priceType">Value price type.</param>
        /// <param name="sku">Value SKU.</param>
        /// <param name="optionTypeId">Option type ID.</param>
        public ProductCustomOptionValueInterface(string title, int sortOrder, decimal price, string priceType, string sku, int optionTypeId)
            : this()
        {
            Title = title;
            SortOrder = sortOrder;
            Price = price;
            PriceType = priceType;
            SKU = sku;
            OptionTypeID = optionTypeId;
        }
    }
}
