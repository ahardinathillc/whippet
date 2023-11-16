using System;
using Newtonsoft.Json;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Adobe.Magento.Downloads
{
    /// <summary>
    /// Interface that provides information about a downloadable file in Magento.
    /// </summary>
    public class DownloadableFileContentInterface : IExtensionInterface, IExtensionAttributes<DownloadableFileContentExtensionInterface>
    {
        private string _data;

        /// <summary>
        /// Gets or sets the file data in base64 encoding.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        [JsonProperty("file_data")]
        public string FileData
        {
            get
            {
                return _data;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) && !value.IsBase64())
                {
                    throw new FormatException();
                }

                _data = value;
            }
        }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        [JsonProperty("file_name")]
        public string FileName
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public DownloadableFileContentExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableFileContentInterface"/> class with no arguments.
        /// </summary>
        public DownloadableFileContentInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableFileContentInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="fileData">File data in base64 encoding.</param>
        /// <param name="fileName">File name.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        /// <exception cref="FormatException"></exception>
        public DownloadableFileContentInterface(string fileData, string fileName, DownloadableFileContentExtensionInterface extensionAttributes)
            : this()
        {
            FileData = fileData;
            FileName = fileName;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
