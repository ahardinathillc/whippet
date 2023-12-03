using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Downloads
{
    /// <summary>
    /// Represents a downloadable Magento sample.
    /// </summary>
    public class DownloadableSample : MagentoRestEntity<DownloadableSampleInterface>, IMagentoEntity, IDownloadableSample, IEqualityComparer<IDownloadableSample>, IMagentoRestEntity<DownloadableSampleInterface>
    {
        /// <summary>
        /// Gets or sets the sample title.
        /// </summary>
        public virtual string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the sample sort order.
        /// </summary>
        public virtual int SortOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the sample type.
        /// </summary>
        public virtual string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the relative file path the sample points to.
        /// </summary>
        public virtual string File
        { get; set; }

        /// <summary>
        /// Gets or sets the contents of the downloadable sample.
        /// </summary>
        public virtual DownloadableFileContent FileContents
        { get; set; }

        /// <summary>
        /// Gets or sets the sample URL or <see langword="null"/> when <see cref="Type"/> is &quot;file&quot;.
        /// </summary>
        public virtual Uri URL
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableSample"/> class with no arguments.
        /// </summary>
        public DownloadableSample()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableSample"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public DownloadableSample(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadableSample"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public DownloadableSample(DownloadableSampleInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IDownloadableSample)) ? false : Equals((IDownloadableSample)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IDownloadableSample obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IDownloadableSample x, IDownloadableSample y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Title?.Trim(), y.Title?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.SortOrder == y.SortOrder
                         && String.Equals(x.Type?.Trim(), y.Type?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.File?.Trim(), y.File?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.FileContents.Equals(y.FileContents)
                         && (((x.URL == null) && (y.URL == null)) || ((x.URL != null) && x.URL.Equals(y.URL)))
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)))
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="DownloadableSampleInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="DownloadableSampleInterface"/>.</returns>
        public override DownloadableSampleInterface ToInterface()
        {
            DownloadableSampleInterface optionInterface = new DownloadableSampleInterface();

            optionInterface.ID = ID;
            optionInterface.Title = Title;
            optionInterface.SortOrder = SortOrder;
            optionInterface.SampleURL = URL?.ToString();
            optionInterface.SampleType = Type;
            optionInterface.SampleFileContents = FileContents.ToInterface();
            optionInterface.ExtensionAttributes = new DownloadableSampleExtensionInterface();

            return optionInterface;
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(DownloadableSampleInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Title = model.Title;
                SortOrder = model.SortOrder;
                Type = model.SampleType;
                File = model.SampleFile;
                FileContents = new DownloadableFileContent(model.SampleFileContents);
                URL = String.IsNullOrWhiteSpace(model.SampleURL) ? null : new Uri(model.SampleURL, UriKind.RelativeOrAbsolute);
            }
        }
        
        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            DownloadableSample option = new DownloadableSample();

            option.ID = ID;
            option.Title = Title;
            option.SortOrder = SortOrder;
            option.Type = Type;
            option.File = File;
            option.FileContents = FileContents;
            option.URL = (URL == null) ? null : new Uri(URL.ToString(), UriKind.RelativeOrAbsolute);
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
            hash.Add(Type);
            hash.Add(File);
            hash.Add(FileContents);
            hash.Add(URL);
            hash.Add(Server);
            hash.Add(RestEndpoint);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IDownloadableSample"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IDownloadableSample obj)
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
            return String.Format("[Title: {0}]", Title);
        }
        
    }
}
