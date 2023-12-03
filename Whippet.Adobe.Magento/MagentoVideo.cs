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
        /// Initializes a new instance of the <see cref="MagentoVideo"/> struct with the specified <see cref="VideoContentInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="VideoContentInterface"/> object.</param>
        public MagentoVideo(VideoContentInterface model)
            : this()
        {
            FromModel(model);
        }

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
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is MagentoVideo)) ? false : Equals((MagentoVideo)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MagentoVideo obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MagentoVideo x, MagentoVideo y)
        {
            return String.Equals(x.Metadata?.Trim(), y.Metadata?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.MIME?.Trim(), y.MIME?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Title?.Trim(), y.Title?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Description?.Trim(), y.Description?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Provider?.Trim(), y.Provider?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && (((x.URL == null) && (y.URL == null)) || ((x.URL != null) && x.URL.Equals(y.URL)));

        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Metadata, MIME, Title, Description, Provider, URL);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="MagentoVideo"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(MagentoVideo obj)
        {
            return obj.GetHashCode();
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
