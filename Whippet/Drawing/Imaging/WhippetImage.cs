using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Athi.Whippet.Drawing.Imaging
{
    /// <summary>
    /// Provides a domain-independent wrapper for <see cref="System.Drawing.Image"/> objects by allowing the storage of the raw image data into a byte array. This class cannot be inherited.
    /// </summary>
    public sealed class WhippetImage : IEqualityComparer<WhippetImage>, IWhippetCloneable
    {
        private static ImageConverter __SingletonConverter = new ImageConverter();

        /// <summary>
        /// Gets the raw image data used to construct the <see cref="Image"/> object. This property is read-only.
        /// </summary>
        public ReadOnlySpan<byte> RawImage
        {
            get
            {
                return RawImageData;
            }
        }

        /// <summary>
        /// Gets the raw image data used to construct the <see cref="Image"/> object. This property is read-only.
        /// </summary>
        private byte[] RawImageData
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetImage"/> class with no arguments.
        /// </summary>
        private WhippetImage()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetImage"/> class with the specified <see cref="byte"/> array containing the raw image.
        /// </summary>
        /// <param name="rawImage">Raw image data to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhippetImage(byte[] rawImage)
            : this()
        {
            if (rawImage == null)
            {
                throw new ArgumentNullException(nameof(rawImage));
            }
            else
            {
                RawImageData = rawImage;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetImage"/> class with the specified <see cref="Image"/>.
        /// </summary>
        /// <param name="image"><see cref="Image"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public WhippetImage(Image image)
            : this()
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            else
            {
                RawImageData = __SingletonConverter.ConvertTo(image, typeof(byte[])) as byte[];

                if (RawImageData == null)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Constructs a new <see cref="Image"/> object from the contents of <see cref="RawImage"/>.
        /// </summary>
        /// <returns><see cref="Image"/> object or <see langword="null"/> if <see cref="RawImage"/> is empty.</returns>
        public Image ConstructImage()
        {
            MemoryStream memoryStream = null;
            Image image = null;

            if (RawImageData != null && RawImageData.Length > 0)
            {
                try
                {
                    memoryStream = new MemoryStream(RawImageData);
                    image = __SingletonConverter.ConvertFrom(RawImageData) as Image;
                }
                finally
                {
                    if (memoryStream != null)
                    {
                        memoryStream.Dispose();
                        memoryStream = null;
                    }
                }
            }

            return image;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public object Clone()
        {
            return Clone<WhippetImage>();
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public TObject Clone<TObject>(Guid? createdBy = null)
        {
            WhippetImage image = null;
            byte[] newArray = new byte[RawImageData.Length];

            RawImageData.CopyTo(newArray, 0);

            image = new WhippetImage(newArray);

            return (TObject)((object)(image));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as WhippetImage);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetImage obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="a">First object to compare.</param>
        /// <param name="b">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(WhippetImage a, WhippetImage b)
        {
            bool equals = (a == null && b == null);

            if (!equals)
            {
                equals = a.RawImage.SequenceEqual(b.RawImage);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return RawImageData.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(WhippetImage obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        public static implicit operator Image(WhippetImage image)
        {
            return (image == null) ? null : image.ConstructImage();
        }

        public static implicit operator ReadOnlySpan<byte>(WhippetImage image)
        {
            return (image == null) ? null : image.RawImage;
        }
    }
}

