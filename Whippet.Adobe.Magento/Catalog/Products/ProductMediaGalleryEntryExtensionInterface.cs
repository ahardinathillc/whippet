using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Interface that provides extra information about a Magento product's media gallery entry.
    /// </summary>
    public class ProductMediaGalleryEntryExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the video content of the media gallery entry.
        /// </summary>
        [JsonProperty("video_content")]
        public VideoContentInterface VideoContent
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductMediaGalleryEntryExtensionInterface"/> class with no arguments. 
        /// </summary>
        public ProductMediaGalleryEntryExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductMediaGalleryEntryExtensionInterface"/> class with the specified <see cref="VideoContentInterface"/> object. 
        /// </summary>
        /// <param name="videoContent"><see cref="VideoContentInterface"/> object to initialize with.</param>
        public ProductMediaGalleryEntryExtensionInterface(VideoContentInterface videoContent)
            : this()
        {
            VideoContent = videoContent;
        }
    }
}
