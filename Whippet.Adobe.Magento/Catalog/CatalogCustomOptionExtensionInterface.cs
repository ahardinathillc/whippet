using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog
{
    /// <summary>
    /// Interface that provides extra data about a Magento catalog's product option.
    /// </summary>
    public class CatalogCustomOptionExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the image content data for the custom option.
        /// </summary>
        [JsonProperty("file_info")]
        public ImageContentInterface ImageInformation
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomOptionExtensionInterface"/> class with no arguments.
        /// </summary>
        public CatalogCustomOptionExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomOptionExtensionInterface"/> class with the specified <see cref="ImageContentInterface"/> object.
        /// </summary>
        /// <param name="image"><see cref="ImageContentInterface"/> object.</param>
        public CatalogCustomOptionExtensionInterface(ImageContentInterface image)
            : this()
        {
            ImageInformation = image;
        }
    }
}
