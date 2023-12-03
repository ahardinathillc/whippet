using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Downloads
{
    /// <summary>
    /// Represents a downloadable Magento link.
    /// </summary>
    public interface IDownloadableLink : IMagentoEntity, IEqualityComparer<IDownloadableLink>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the link title.
        /// </summary>
        string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the link sort order.
        /// </summary>
        int SortOrder
        { get; set; }

        /// <summary>
        /// Specifies whether the link is shareable.
        /// </summary>
        bool Shareable
        { get; set; }

        /// <summary>
        /// Gets or sets the price of the download link.
        /// </summary>
        decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the number of downloads allowed per user.
        /// </summary>
        int PerUserLimit
        { get; set; }

        /// <summary>
        /// Gets or sets the link type.
        /// </summary>
        string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the relative file path the link points to.
        /// </summary>
        string File
        { get; set; }

        /// <summary>
        /// Gets or sets the contents of the downloadable link.
        /// </summary>
        DownloadableFileContent FileContents
        { get; set; }

        /// <summary>
        /// Gets or sets the link URL or <see langword="null"/> when <see cref="Type"/> is &quot;file&quot;.
        /// </summary>
        Uri LinkURL
        { get; set; }

        /// <summary>
        /// Gets or sets the sample type.
        /// </summary>
        string SampleType
        { get; set; }

        /// <summary>
        /// Gets or sets the relative file path of the sample file.
        /// </summary>
        string SampleFile
        { get; set; }

        /// <summary>
        /// Gets or sets the sample file content.
        /// </summary>
        DownloadableFileContent SampleFileContent
        { get; set; }

        /// <summary>
        /// Gets or sets the file URL.
        /// </summary>
        Uri FileURL
        { get; set; }
    }
}
