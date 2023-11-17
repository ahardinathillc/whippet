using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Product
{
    /// <summary>
    /// Interface that provides information about a Magento product's media gallery entry.
    /// </summary>
    public class ProductMediaGalleryEntryInterface : IExtensionInterface, IExtensionAttributes<ProductMediaGalleryEntryExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the media gallery entry ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the media type.
        /// </summary>
        [JsonProperty("media_type")]
        public string MediaType
        { get; set; }

        /// <summary>
        /// Gets or sets the gallery entry alternative text.
        /// </summary>
        [JsonProperty("label")]
        public string Label
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order of the entry.
        /// </summary>
        [JsonProperty("position")]
        public int Position
        { get; set; }

        /// <summary>
        /// Specifies whether the gallery entry is hidden from the product page.
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled
        { get; set; }

        /// <summary>
        /// Gets or sets the image types of the entry.
        /// </summary>
        [JsonProperty("types")]
        public string[] Types
        { get; set; }

        /// <summary>
        /// Gets or sets the file path of the entry.
        /// </summary>
        [JsonProperty("file")]
        public string File
        { get; set; }

        /// <summary>
        /// Gets or sets the image content data.
        /// </summary>
        [JsonProperty("content")]
        public ImageContentInterface Content
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public ProductMediaGalleryEntryExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductMediaGalleryEntryInterface"/> class with no arguments.
        /// </summary>
        public ProductMediaGalleryEntryInterface()
        { }
    }
}
