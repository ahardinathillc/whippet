using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Downloads
{
    /// <summary>
    /// Interface that provides information on downloading a product sample from a Magento storefront.
    /// </summary>
    public class DownloadableSampleInterface : IExtensionInterface, IExtensionAttributes<DownloadableSampleExtensionInterface>
    {
        /// <summary>
        /// Sample (or link) ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the sample title.
        /// </summary>
        [JsonProperty("title")]
        public string Title
        { get; set; }

        /// <summary>
        /// Order index for sample.
        /// </summary>
        [JsonProperty("sort_order")]
        public int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the sample type.
        /// </summary>
        [JsonProperty("sample_type")]
        public string SampleType
        { get; set; }

        /// <summary>
        /// Gets or sets the relative file path.
        /// </summary>
        [JsonProperty("sample_file")]
        public string SampleFile
        { get; set; }
        
        /// <summary>
        /// Gets or sets the sample file content.
        /// </summary>
        [JsonProperty("sample_file_content")]
        public DownloadableFileContentInterface SampleFileContents
        { get; set; }

        /// <summary>
        /// Gets or sets the sample URL.
        /// </summary>
        [JsonProperty("sample_url")]
        public string SampleURL
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public DownloadableSampleExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableSampleInterface"/> class with no arguments.
        /// </summary>
        public DownloadableSampleInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableSampleInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">Sample (or link) ID.</param>
        /// <param name="sortOrder">Order index for the sample.</param>
        /// <param name="sampleType">Sample type.</param>
        /// <param name="sampleFileContent">Sample file content.</param>
        /// <param name="sampleUrl">Sample URL.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public DownloadableSampleInterface(int id, int sortOrder, string sampleType, DownloadableFileContentInterface sampleFileContent, string sampleUrl, DownloadableSampleExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            SortOrder = sortOrder;
            SampleType = sampleType;
            SampleFileContents = sampleFileContent;
            SampleURL = sampleUrl;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
