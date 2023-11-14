using System;
using Newtonsoft.Json;
using Athi.Whippet.Extensions.Primitives;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Provides information about an image in Magento.
    /// </summary>
    public class ImageContentInterface : IExtensionInterface
    {
        private string _data;

        /// <summary>
        /// Gets or sets the media data in base64 encoding.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        [JsonProperty("base64_encoded_data")]
        public string EncodedData
        {
            get
            {
                return _data;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    if (!value.IsBase64())
                    {
                        throw new FormatException();
                    }
                }

                _data = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the MIME type of the image.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        { get; set; }
        
        /// <summary>
        /// Gets or sets the image name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageContentInterface"/> class with no arguments.
        /// </summary>
        public ImageContentInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageContentInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="encodedDataBase64">Encoded image data in base64 encoding.</param>
        /// <param name="type">MIME type of the image.</param>
        /// <param name="name">Name of the image.</param>
        /// <exception cref="FormatException"></exception>
        public ImageContentInterface(string encodedDataBase64, string type, string name)
            : this()
        {
            EncodedData = encodedDataBase64;
            Type = type;
            Name = name;
        }
    }
}
