using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Downloads
{
    /// <summary>
    /// Represents a downloadable Magento sample.
    /// </summary>
    public interface IDownloadableSample : IMagentoEntity, IEqualityComparer<IDownloadableSample>, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the sample title.
        /// </summary>
        string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the sample sort order.
        /// </summary>
        int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the sample type.
        /// </summary>
        string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the relative file path the sample points to.
        /// </summary>
        string File
        { get; set; }

        /// <summary>
        /// Gets or sets the contents of the downloadable sample.
        /// </summary>
        DownloadableFileContent FileContents
        { get; set; }

        /// <summary>
        /// Gets or sets the sample URL or <see langword="null"/> when <see cref="Type"/> is &quot;file&quot;.
        /// </summary>
        Uri URL
        { get; set; }
    }
}
