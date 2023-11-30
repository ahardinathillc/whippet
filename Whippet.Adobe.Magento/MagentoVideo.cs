using System;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a raw image in Magento.
    /// </summary>
    public struct MagentoVideo : IExtensionInterfaceMap<VideoContentInterface>
    {
        /// <summary>
        /// Gets or sets the MIME type.
        /// </summary>
        public string MIME
        { get; set; }

        /// <summary>
        /// Gets or sets the video title.
        /// </summary>
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the video provider.
        /// </summary>
        public string Provider
        { get; set; }

        /// <summary>
        /// Gets or sets the video URL.
        /// </summary>
        public Uri URL
        { get; set; }

        /// <summary>
        /// Gets or sets the video description.
        /// </summary>
        public string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the video metadata.
        /// </summary>
        public string Metadata
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoVideo"/> struct with no arguments.
        /// </summary>
        static MagentoVideo()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoVideo"/> struct with no arguments.
        /// </summary>
        public MagentoVideo()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoVideo"/> struct with the specified parameters.
        /// </summary>
        /// <param name="title">Video title.</param>
        /// <param name="provider">Video provider.</param>
        /// <param name="description">Video description.</param>
        /// <param name="mime">Video MIME type.</param>
        /// <param name="metadata">Video metadata.</param>
        /// <param name="url">Video URL.</param>
        public MagentoVideo(string title, string provider, string description, string mime, string metadata, string url)
            : this(title, provider, description, mime, metadata, String.IsNullOrWhiteSpace(url) ? null : new Uri(url))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoVideo"/> struct with the specified parameters.
        /// </summary>
        /// <param name="title">Video title.</param>
        /// <param name="provider">Video provider.</param>
        /// <param name="description">Video description.</param>
        /// <param name="mime">Video MIME type.</param>
        /// <param name="metadata">Video metadata.</param>
        /// <param name="url">Video URL.</param>
        public MagentoVideo(string title, string provider, string description, string mime, string metadata, Uri url)
            : this()
        {
            Title = title;
            Provider = provider;
            Description = description;
            MIME = mime;
            Metadata = metadata;
            URL = url;
        }
        
        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="VideoContentInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="VideoContentInterface"/>.</returns>
        public VideoContentInterface ToInterface()
        {
            return new VideoContentInterface(MIME, Provider, URL?.ToString(), Title, Description, Metadata);
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="VideoContentInterface"/> object used to populate the object.</param>
        public void FromModel(VideoContentInterface model)
        {
            if (model != null)
            {
                Title = model.Title;
                Provider = model.Provider;
                Description = model.Description;
                MIME = model.MediaType;
                Metadata = model.Metadata;
                URL = String.IsNullOrWhiteSpace(model.URL) ? null : new Uri(model.URL);
            }
        }
    }
}
