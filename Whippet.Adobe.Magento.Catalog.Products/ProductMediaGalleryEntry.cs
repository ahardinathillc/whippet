using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a Magento product gallery entry.
    /// </summary>
    public class ProductMediaGalleryEntry : MagentoRestEntity<ProductMediaGalleryEntryInterface>, IMagentoEntity, IProductMediaGalleryEntry, IEqualityComparer<IProductMediaGalleryEntry>, IMagentoRestEntity<ProductMediaGalleryEntryInterface>
    {
        /// <summary>
        /// Gets or sets the media type.
        /// </summary>
        public virtual string MediaType
        { get; set; }

        /// <summary>
        /// Gets or sets the gallery entry alternative text.
        /// </summary>
        public virtual string Label
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order of the entry.
        /// </summary>
        public virtual int Position
        { get; set; }

        /// <summary>
        /// Specifies whether the gallery entry is hidden from the product page.
        /// </summary>
        public virtual bool Disabled
        { get; set; }

        /// <summary>
        /// Gets or sets the image types of the entry.
        /// </summary>
        public virtual IEnumerable<string> Types
        { get; set; }

        /// <summary>
        /// Gets or sets the file path of the entry.
        /// </summary>
        public virtual string File
        { get; set; }

        /// <summary>
        /// Gets or sets the image content data.
        /// </summary>
        public virtual MagentoImage Content
        { get; set; }
        
        /// <summary>
        /// Gets or sets the video content data.
        /// </summary>
        public virtual MagentoVideo Video
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductMediaGalleryEntry"/> class with no arguments.
        /// </summary>
        public ProductMediaGalleryEntry()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductMediaGalleryEntry"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ProductMediaGalleryEntry(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductMediaGalleryEntry"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ProductMediaGalleryEntry(ProductMediaGalleryEntryInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IProductMediaGalleryEntry)) ? false : Equals((IProductMediaGalleryEntry)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProductMediaGalleryEntry obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProductMediaGalleryEntry x, IProductMediaGalleryEntry y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.MediaType?.Trim(), y.MediaType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.Label?.Trim(), y.Label?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.Position == y.Position
                         && x.Disabled == y.Disabled
                         && (((x.Types == null) && (y.Types == null)) || ((x.Types != null) && x.Types.SequenceEqual(y.Types)))
                         && String.Equals(x.File?.Trim(), y.File?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.Content.Equals(y.Content)
                         && x.Video.Equals(y.Video)
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)))
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductMediaGalleryEntryInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductMediaGalleryEntryInterface"/>.</returns>
        public override ProductMediaGalleryEntryInterface ToInterface()
        {
            ProductMediaGalleryEntryInterface optionInterface = new ProductMediaGalleryEntryInterface();

            optionInterface.ID = ID;
            optionInterface.MediaType = MediaType;
            optionInterface.Label = Label;
            optionInterface.Position = Position;
            optionInterface.Disabled = Disabled;
            optionInterface.Types = (Types == null) ? null : Types.ToArray();
            optionInterface.File = File;
            optionInterface.Content = Content.ToInterface();
            optionInterface.ExtensionAttributes = new ProductMediaGalleryEntryExtensionInterface();
            optionInterface.ExtensionAttributes.VideoContent = Video.ToInterface();

            return optionInterface;
        }

        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(ProductMediaGalleryEntryInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                MediaType = model.MediaType;
                Label = model.Label;
                Position = model.Position;
                Disabled = model.Disabled;
                Types = model.Types;
                File = model.File;
                Content = new MagentoImage(model.Content);

                if (model.ExtensionAttributes != null)
                {
                    Video = new MagentoVideo(model.ExtensionAttributes.VideoContent);
                }
            }
        }
        
        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            ProductMediaGalleryEntry option = new ProductMediaGalleryEntry();

            option.ID = ID;
            option.MediaType = MediaType;
            option.Label = Label;
            option.Position = Position;
            option.Disabled = Disabled;
            option.Types = (Types == null) ? null : Types.Select(t => t);
            option.File = File;
            option.Content = Content;
            option.Video = Video;
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
            hash.Add(MediaType);
            hash.Add(Label);
            hash.Add(Position);
            hash.Add(Disabled);
            hash.Add(Types);
            hash.Add(File);
            hash.Add(Content);
            hash.Add(Video);
            hash.Add(Server);
            hash.Add(RestEndpoint);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IProductMediaGalleryEntry"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IProductMediaGalleryEntry obj)
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
            return String.Format("[Title: {0} | Type: {1}]", Label, MediaType);
        }
        
    }
}
