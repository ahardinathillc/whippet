using System;

namespace Athi.Whippet.Adobe.Magento.Downloads
{
    /// <summary>
    /// Represents a downloadable option for a Magento product. 
    /// </summary>
    public struct DownloadableOption : IEqualityComparer<DownloadableOption>, IExtensionInterfaceMap<DownloadableOptionInterface>
    {
        /// <summary>
        /// Gets or sets the links for the option.
        /// </summary>
        public IEnumerable<IDownloadableLink> Links
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableOption"/> class with no arguments.
        /// </summary>
        public DownloadableOption()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableOption"/> class with the specified <see cref="DownloadableOptionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="DownloadableOptionInterface"/> object.</param>
        public DownloadableOption(DownloadableOptionInterface model)
            : this()
        {
            FromModel(model);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableOption"/> class with the specified <see cref="IEnumerable{T}"/> collection of <see cref="IDownloadableLink"/> objects.
        /// </summary>
        /// <param name="links"><see cref="IEnumerable{T}"/> collection of <see cref="IDownloadableLink"/> objects.</param>
        public DownloadableOption(IEnumerable<IDownloadableLink> links)
            : this()
        {
            Links = links;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is DownloadableOption)) ? false : Equals((DownloadableOption)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(DownloadableOption obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(DownloadableOption x, DownloadableOption y)
        {
            return (((x.Links == null) && (y.Links == null)) || ((x.Links != null) && x.Links.SequenceEqual(y.Links)));
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Links);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="DownloadableOption"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(DownloadableOption obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="DownloadableOptionInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="DownloadableOptionInterface"/>.</returns>
        public DownloadableOptionInterface ToInterface()
        {
            return new DownloadableOptionInterface((Links == null) ? null : Links.Select(l => l.ID).ToArray());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="DownloadableOptionInterface"/> object used to populate the object.</param>
        public void FromModel(DownloadableOptionInterface model)
        {
            if (model != null)
            {
                if (model.DownloadableLinks != null)
                {
                    Links = model.DownloadableLinks.Select(l => new DownloadableLink(Convert.ToUInt32(l)));
                }
            }
        }
    }
}
