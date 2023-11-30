using System;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a raw image in Magento.
    /// </summary>
    public struct MagentoImage : IExtensionInterfaceMap<ImageContentInterface>
    {
        /// <summary>
        /// Gets or sets the base-64 encoded data.
        /// </summary>
        public byte[] Data
        { get; set; }
        
        /// <summary>
        /// Gets or sets the MIME type.
        /// </summary>
        public string MIME
        { get; set; }

        /// <summary>
        /// Gets or sets the image name.
        /// </summary>
        public string Name
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoImage"/> struct with no arguments.
        /// </summary>
        static MagentoImage()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoImage"/> struct with no arguments.
        /// </summary>
        public MagentoImage()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoImage"/> struct with the specified parameters.
        /// </summary>
        /// <param name="base64Image">Base-64 image data as a <see cref="String"/>.</param>
        /// <param name="mime">MIME type.</param>
        /// <param name="name">Image name.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public MagentoImage(string base64Image, string mime, string name)
            : this(Convert.FromBase64String(base64Image), mime, name)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoImage"/> struct with the specified parameters.
        /// </summary>
        /// <param name="base64Image">Base-64 image data as a <see cref="String"/>.</param>
        /// <param name="mime">MIME type.</param>
        /// <param name="name">Image name.</param>
        public MagentoImage(byte[] base64Image, string mime, string name)
            : this()
        {
            Data = base64Image;
            MIME = mime;
            Name = name;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ImageContentInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ImageContentInterface"/>.</returns>
        public ImageContentInterface ToInterface()
        {
            return new ImageContentInterface((Data == null) ? String.Empty : Convert.ToBase64String(Data), MIME, Name);
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ImageContentInterface"/> object used to populate the object.</param>
        public void FromModel(ImageContentInterface model)
        {
            if (model != null)
            {
                Data = !String.IsNullOrWhiteSpace(model.EncodedData) ? Convert.FromBase64String(model.EncodedData) : null;
                MIME = model.Type;
                Name = model.Name;
            }
        }
    }
}
