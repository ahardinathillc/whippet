using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IProductMediaGalleryEntry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IProductMediaGalleryEntryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IProductMediaGalleryEntry"/> object to a <see cref="ProductMediaGalleryEntry"/> object.
        /// </summary>
        /// <param name="entry"><see cref="IProductMediaGalleryEntry"/> object to convert.</param>
        /// <returns><see cref="ProductMediaGalleryEntry"/> object.</returns>
        public static ProductMediaGalleryEntry ToProductMediaGalleryEntry(this IProductMediaGalleryEntry entry)
        {
            ProductMediaGalleryEntry galleryEntry = null;

            if (entry is ProductMediaGalleryEntry)
            {
                galleryEntry = (ProductMediaGalleryEntry)(entry);
            }
            else if (entry != null)
            {
                galleryEntry = new ProductMediaGalleryEntry();

                galleryEntry.MediaType = entry.MediaType;
                galleryEntry.Label = entry.Label;
                galleryEntry.Position = entry.Position;
                galleryEntry.Disabled = entry.Disabled;
                galleryEntry.Types = (entry.Types == null) ? null : entry.Types.Select(t => t);
                galleryEntry.File = entry.File;
                galleryEntry.Content = entry.Content;
                galleryEntry.Video = entry.Video;
                galleryEntry.RestEndpoint = (entry.RestEndpoint == null) ? null : entry.RestEndpoint.ToMagentoRestEndpoint();
                galleryEntry.Server = (entry.Server == null) ? null : entry.Server.ToMagentoServer();
            }

            return galleryEntry;
        }        
    }
}
