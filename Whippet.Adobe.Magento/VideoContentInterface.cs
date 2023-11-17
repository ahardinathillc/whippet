using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Interface that provides information about video content in Magento.
    /// </summary>
    public class VideoContentInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the MIME type of the video.
        /// </summary>
        [JsonProperty("media_type")]
        public string MediaType
        { get; set; }

        /// <summary>
        /// Gets or sets the video provider.
        /// </summary>
        [JsonProperty("video_provider")]
        public string Provider
        { get; set; }

        /// <summary>
        /// Gets or sets the video URL.
        /// </summary>
        [JsonProperty("video_url")]
        public string URL
        { get; set; }

        /// <summary>
        /// Gets or sets the video title.
        /// </summary>
        [JsonProperty("video_title")]
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the video description.
        /// </summary>
        [JsonProperty("video_description")]
        public string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the video metadata.
        /// </summary>
        [JsonProperty("video_metadata")]
        public string Metadata
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoContentInterface"/> class with no arguments.
        /// </summary>
        public VideoContentInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoContentInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="mediaType">Media type.</param>
        /// <param name="provider">Provider type.</param>
        /// <param name="url">Video URL.</param>
        /// <param name="title">Video title.</param>
        /// <param name="description">Video description.</param>
        /// <param name="metadata">Video metadata.</param>
        public VideoContentInterface(string mediaType, string provider, string url, string title, string description, string metadata)
            : this()
        {
            MediaType = mediaType;
            Provider = provider;
            URL = url;
            Title = title;
            Description = description;
            Metadata = metadata;
        }
    }
}
