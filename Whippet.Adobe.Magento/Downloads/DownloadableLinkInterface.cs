using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Downloads
{
    /// <summary>
    /// Interface that provides information about a Magento downloadable link.
    /// </summary>
    public class DownloadableLinkInterface : IExtensionInterface, IExtensionAttributes<DownloadableLinkExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the sample (or link) ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the link title.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the link sort order.
        /// </summary>
        [JsonProperty("sort_order")]
        public int SortOrder
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the link is shareable. Values greater than zero (0) are <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("is_shareable")]
        public int Shareable
        { get; set; }

        /// <summary>
        /// Gets or sets the price of the download link.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the number of downloads allowed per user.
        /// </summary>
        [JsonProperty("number_of_downloads")]
        public int PerUserLimit
        { get; set; }

        /// <summary>
        /// Gets or sets the link type.
        /// </summary>
        [JsonProperty("link_type")]
        public string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the relative file path the link points to.
        /// </summary>
        [JsonProperty("link_file")]
        public string File
        { get; set; }

        /// <summary>
        /// Gets or sets the contents of the downloadable link.
        /// </summary>
        [JsonProperty("link_file_content")]
        public DownloadableFileContentInterface FileContents
        { get; set; }

        /// <summary>
        /// Gets or sets the link URL or <see langword="null"/> when <see cref="Type"/> is &quot;file&quot;.
        /// </summary>
        [JsonProperty("link_url")]
        public string Link_URL
        { get; set; }

        /// <summary>
        /// Gets or sets the sample type.
        /// </summary>
        [JsonProperty("sample_type")]
        public string SampleType
        { get; set; }

        /// <summary>
        /// Gets or sets the relative file path of the sample file.
        /// </summary>
        [JsonProperty("sample_file")]
        public string SampleFile
        { get; set; }

        /// <summary>
        /// Gets or sets the sample file content.
        /// </summary>
        [JsonProperty("sample_file_content")]
        public DownloadableFileContentInterface SampleFileContent
        { get; set; }

        /// <summary>
        /// Gets or sets the file URL.
        /// </summary>
        [JsonProperty("sample_url")]
        public string File_URL
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public DownloadableLinkExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableLinkInterface"/> class with no arguments.
        /// </summary>
        public DownloadableLinkInterface()
        { }
    }
}
