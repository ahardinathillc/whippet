using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Downloads
{
    /// <summary>
    /// Represents a downloadable Magento link.
    /// </summary>
    public class DownloadableLink : MagentoRestEntity<DownloadableLinkInterface>, IMagentoEntity, IDownloadableLink, IEqualityComparer<IDownloadableLink>, IMagentoRestEntity<DownloadableLinkInterface>
    {
        /// <summary>
        /// Gets or sets the link title.
        /// </summary>
        public virtual string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the link sort order.
        /// </summary>
        public virtual int SortOrder
        { get; set; }

        /// <summary>
        /// Specifies whether the link is shareable.
        /// </summary>
        public virtual bool Shareable
        { get; set; }

        /// <summary>
        /// Gets or sets the price of the download link.
        /// </summary>
        public virtual decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the number of downloads allowed per user.
        /// </summary>
        public virtual int PerUserLimit
        { get; set; }

        /// <summary>
        /// Gets or sets the link type.
        /// </summary>
        public virtual string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the relative file path the link points to.
        /// </summary>
        public virtual string File
        { get; set; }

        /// <summary>
        /// Gets or sets the contents of the downloadable link.
        /// </summary>
        public virtual DownloadableFileContent FileContents
        { get; set; }

        /// <summary>
        /// Gets or sets the link URL or <see langword="null"/> when <see cref="Type"/> is &quot;file&quot;.
        /// </summary>
        public virtual Uri LinkURL
        { get; set; }

        /// <summary>
        /// Gets or sets the sample type.
        /// </summary>
        public virtual string SampleType
        { get; set; }

        /// <summary>
        /// Gets or sets the relative file path of the sample file.
        /// </summary>
        public virtual string SampleFile
        { get; set; }

        /// <summary>
        /// Gets or sets the sample file content.
        /// </summary>
        public virtual DownloadableFileContent SampleFileContent
        { get; set; }

        /// <summary>
        /// Gets or sets the file URL.
        /// </summary>
        public virtual Uri FileURL
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableLink"/> class with no arguments.
        /// </summary>
        public DownloadableLink()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableLink"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public DownloadableLink(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableLink"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public DownloadableLink(DownloadableLinkInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IDownloadableLink)) ? false : Equals((IDownloadableLink)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IDownloadableLink obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IDownloadableLink x, IDownloadableLink y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Title?.Trim(), y.Title?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.SortOrder == y.SortOrder
                         && x.Shareable == y.Shareable
                         && x.Price == y.Price
                         && x.PerUserLimit == y.PerUserLimit
                         && String.Equals(x.Type?.Trim(), y.Type?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.File?.Trim(), y.File?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.FileContents.Equals(y.FileContents)
                         && (((x.LinkURL == null) && (y.LinkURL == null)) || ((x.LinkURL != null) && x.LinkURL.Equals(y.LinkURL)))
                         && String.Equals(x.SampleType?.Trim(), y.SampleType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.SampleFile?.Trim(), y.SampleFile?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.SampleFileContent.Equals(y.SampleFileContent)
                         && (((x.FileURL == null) && (y.FileURL == null)) || ((x.FileURL != null) && x.FileURL.Equals(y.FileURL)))
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)))
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="DownloadableLinkInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="DownloadableLinkInterface"/>.</returns>
        public override DownloadableLinkInterface ToInterface()
        {
            DownloadableLinkInterface optionInterface = new DownloadableLinkInterface();

            optionInterface.ID = ID;
            optionInterface.Title = Title;
            optionInterface.SortOrder = SortOrder;
            optionInterface.Shareable = Shareable.ToMagentoBoolean();
            optionInterface.Price = Price;
            optionInterface.PerUserLimit = PerUserLimit;
            optionInterface.Type = Type;
            optionInterface.File = File;
            optionInterface.FileContents = FileContents.ToInterface();
            optionInterface.Link_URL = LinkURL?.ToString();
            optionInterface.SampleType = SampleType;
            optionInterface.SampleFile = SampleFile;
            optionInterface.SampleFileContent = SampleFileContent.ToInterface();
            optionInterface.File_URL = FileURL?.ToString();
            optionInterface.ExtensionAttributes = new DownloadableLinkExtensionInterface();

            return optionInterface;
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(DownloadableLinkInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Title = model.Title;
                SortOrder = model.SortOrder;
                Shareable = model.Shareable.FromMagentoBoolean();
                Price = model.Price;
                PerUserLimit = model.PerUserLimit;
                Type = model.Type;
                File = model.File;
                FileContents = new DownloadableFileContent(model.FileContents);
                LinkURL = String.IsNullOrWhiteSpace(model.Link_URL) ? null : new Uri(model.Link_URL);
                SampleType = model.SampleType;
                SampleFile = model.SampleFile;
                SampleFileContent = new DownloadableFileContent(model.SampleFileContent);
                FileURL = String.IsNullOrWhiteSpace(model.File_URL) ? null : new Uri(model.File_URL);
            }
        }
        
        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            DownloadableLink option = new DownloadableLink();

            option.ID = ID;
            option.Title = Title;
            option.SortOrder = SortOrder;
            option.Shareable = Shareable;
            option.Price = Price;
            option.PerUserLimit = PerUserLimit;
            option.Type = Type;
            option.File = File;
            option.FileContents = FileContents;
            option.LinkURL = (LinkURL == null) ? null : new Uri(LinkURL.ToString(), UriKind.RelativeOrAbsolute);
            option.SampleType = SampleType;
            option.SampleFile = SampleFile;
            option.SampleFileContent = SampleFileContent;
            option.FileURL = (FileURL == null) ? null : new Uri(FileURL.ToString(), UriKind.RelativeOrAbsolute);
            option.Server = (Server == null) ? null : Server.Clone<MagentoServer>();
            option.RestEndpoint = (RestEndpoint == null) ? null : RestEndpoint.Clone<MagentoRestEndpoint>();

            return option;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(ID);
            hash.Add(Title);
            hash.Add(SortOrder);
            hash.Add(Shareable);
            hash.Add(Price);
            hash.Add(PerUserLimit);
            hash.Add(Type);
            hash.Add(File);
            hash.Add(FileContents);
            hash.Add(LinkURL);
            hash.Add(SampleType);
            hash.Add(SampleFile);
            hash.Add(SampleFileContent);
            hash.Add(FileURL);
            hash.Add(Server);
            hash.Add(RestEndpoint);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IDownloadableLink"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IDownloadableLink obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[Title: {0} | Price: {1}]", Title, Price);
        }
        
    }
}
