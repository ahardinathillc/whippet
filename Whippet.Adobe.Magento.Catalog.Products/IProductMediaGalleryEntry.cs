using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a Magento product gallery entry.
    /// </summary>
    public interface IProductMediaGalleryEntry :  IMagentoEntity, IEqualityComparer<IProductMediaGalleryEntry>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the media type.
        /// </summary>
        string MediaType
        { get; set; }

        /// <summary>
        /// Gets or sets the gallery entry alternative text.
        /// </summary>
        string Label
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order of the entry.
        /// </summary>
        int Position
        { get; set; }

        /// <summary>
        /// Specifies whether the gallery entry is hidden from the product page.
        /// </summary>
        bool Disabled
        { get; set; }

        /// <summary>
        /// Gets or sets the image types of the entry.
        /// </summary>
        IEnumerable<string> Types
        { get; set; }

        /// <summary>
        /// Gets or sets the file path of the entry.
        /// </summary>
        string File
        { get; set; }

        /// <summary>
        /// Gets or sets the image content data.
        /// </summary>
        MagentoImage Content
        { get; set; }
        
        /// <summary>
        /// Gets or sets the video content data.
        /// </summary>
        MagentoVideo Video
        { get; set; }        
    }
}
