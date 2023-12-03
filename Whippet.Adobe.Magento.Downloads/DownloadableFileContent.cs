using System;
using System.Text;

namespace Athi.Whippet.Adobe.Magento.Downloads
{
    /// <summary>
    /// Represents downloadable file data in Magento.
    /// </summary>
    public struct DownloadableFileContent : IExtensionInterfaceMap<DownloadableFileContentInterface>, IEqualityComparer<DownloadableFileContent>
    {
        /// <summary>
        /// Gets or sets the file data.
        /// </summary>
        public byte[] Data
        { get; set; }
        
        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string Name
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableFileContent"/> struct with no arguments.
        /// </summary>
        static DownloadableFileContent()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableFileContent"/> struct with no arguments.
        /// </summary>
        public DownloadableFileContent()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableFileContent"/> struct with the specified model.
        /// </summary>
        /// <param name="model"><see cref="DownloadableFileContentInterface"/> object to initialize with.</param>
        public DownloadableFileContent(DownloadableFileContentInterface model)
            : this()
        {
            FromModel(model);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableFileContent"/> struct with the specified parameters.
        /// </summary>
        /// <param name="data">Base64-encoded data.</param>
        /// <param name="name">File name.</param>
        public DownloadableFileContent(byte[] data, string name)
            : this()
        {
            Data = data;
            Name = name;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableFileContent"/> struct with the specified parameters.
        /// </summary>
        /// <param name="data">Base64-encoded string.</param>
        /// <param name="name">File name.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public DownloadableFileContent(string data, string name)
            : this(Convert.FromBase64String(data), name)
        { }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="DownloadableFileContent"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="DownloadableFileContent"/>.</returns>
        public DownloadableFileContentInterface ToInterface()
        {
            return new DownloadableFileContentInterface(Data == null ? null : Convert.ToBase64String(Data), Name, new DownloadableFileContentExtensionInterface());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="DownloadableFileContentInterface"/> object used to populate the object.</param>
        public void FromModel(DownloadableFileContentInterface model)
        {
            if (model != null)
            {
                if (!String.IsNullOrWhiteSpace(model.FileData))
                {
                    Data = Convert.FromBase64String(model.FileData);
                }

                Name = model.FileName;
            }
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is DownloadableFileContent)) ? false : Equals((DownloadableFileContent)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(DownloadableFileContent obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(DownloadableFileContent x, DownloadableFileContent y)
        {
            return String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && (((x.Data == null) && (y.Data == null)) || ((x.Data != null) && x.Data.SequenceEqual(y.Data)));
        }

        /// <summary>
        /// Gets the hash code for the current instance.
        /// </summary>
        /// <returns>Hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Data);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public int GetHashCode(DownloadableFileContent obj)
        {
            return obj.GetHashCode();
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
