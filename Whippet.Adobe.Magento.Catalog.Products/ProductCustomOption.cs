using System;
using System.Linq;
using Newtonsoft.Json;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Extensions;
using Microsoft.IdentityModel.Abstractions;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a <see cref="Product"/> configuration or customization option that can be applied.
    /// </summary>
    public class ProductCustomOption : MagentoRestEntity<ProductCustomOptionInterface>, IMagentoEntity, IProductCustomOption, IEqualityComparer<IProductCustomOption>, IMagentoRestEntity<ProductCustomOptionInterface>, IMagentoRestEntity
    {   
        /// <summary>
        /// Gets or sets the product SKU that the option applies to.
        /// </summary>
        public virtual string ProductSKU
        { get; set; }
        
        /// <summary>
        /// Gets or sets the option title.
        /// </summary>
        public virtual string Title
        { get; set; }
        
        /// <summary>
        /// Gets or sets the custom option type.
        /// </summary>
        public virtual ProductCustomOptionType Type
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order of the option.
        /// </summary>
        public virtual int SortOrder
        { get; set; }

        /// <summary>
        /// Specifies whether the option is required.
        /// </summary>
        public virtual bool Required
        { get; set; }

        /// <summary>
        /// Gets or sets the option SKU.
        /// </summary>
        public virtual string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the option price.
        /// </summary>
        public virtual decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the option price type.
        /// </summary>
        public virtual string PriceType
        { get; set; }

        /// <summary>
        /// Gets or sets the option image file name.
        /// </summary>
        public virtual string FileExtension
        { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of characters that the file name can be.
        /// </summary>
        public virtual int MaxCharacters
        { get; set; }

        /// <summary>
        /// Gets or sets the horizontal image size (in pixels).
        /// </summary>
        public virtual int ImageWidth
        { get; set; }

        /// <summary>
        /// Gets or sets the vertical image size (in pixels).
        /// </summary>
        public virtual int ImageHeight
        { get; set; }

        /// <summary>
        /// Gets or sets the custom option values. 
        /// </summary>
        public virtual IEnumerable<ProductCustomOptionValue> Values
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOption"/> class with no arguments.
        /// </summary>
        public ProductCustomOption()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOption"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ProductCustomOption(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOption"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public ProductCustomOption(ProductCustomOptionInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is IProductCustomOption)) ? false : Equals((IProductCustomOption)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProductCustomOption obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IProductCustomOption x, IProductCustomOption y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.Title?.Trim(), y.Title?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.SortOrder == y.SortOrder
                         && x.Price == y.Price
                         && String.Equals(x.PriceType?.Trim(), y.PriceType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.SKU?.Trim(), y.SKU?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ProductSKU?.Trim(), y.ProductSKU?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.MaxCharacters == y.MaxCharacters
                         && x.ImageHeight == y.ImageHeight
                         && x.ImageWidth == y.ImageWidth
                         && x.Required == y.Required
                         && x.Type.Equals(y.Type)
                         && (((x.Values == null) && (y.Values == null)) || ((x.Values != null) && x.Values.SequenceEqual(y.Values)))
                         && String.Equals(x.FileExtension?.Trim(), y.FileExtension?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)))
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductCustomOptionInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductCustomOptionInterface"/>.</returns>
        public override ProductCustomOptionInterface ToInterface()
        {
            ProductCustomOptionInterface optionInterface = new ProductCustomOptionInterface();

            optionInterface.PriceType = PriceType;
            optionInterface.ID = ID;
            optionInterface.Title = Title;
            optionInterface.Price = Price;
            optionInterface.Required = Required;
            optionInterface.Values = (Values == null) ? null : Values.Select(v => v.ToInterface()).ToArray();
            optionInterface.FileExtension = FileExtension;
            optionInterface.ImageHeight = ImageHeight;
            optionInterface.ImageWidth = ImageWidth;
            optionInterface.MaximumCharacters = MaxCharacters;
            optionInterface.SortOrder = SortOrder;
            optionInterface.SKU = SKU;
            optionInterface.ProductSKU = ProductSKU;
            optionInterface.ExtensionAttributes = new ProductCustomOptionExtensionInterface();
            
            return optionInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            ProductCustomOption option = new ProductCustomOption();

            option.ID = ID;
            option.Price = Price;
            option.PriceType = PriceType;
            option.Required = Required;
            option.Title = Title;
            option.Type = Type;
            option.Values = (Values == null) ? null : Values.Select(v => v);
            option.FileExtension = FileExtension;
            option.MaxCharacters = MaxCharacters;
            option.SKU = SKU;
            option.ImageWidth = ImageWidth;
            option.ImageHeight = ImageHeight;
            option.ProductSKU = ProductSKU;
            option.SKU = SKU;
            option.SortOrder = SortOrder;
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
            hash.Add(Price);
            hash.Add(PriceType);
            hash.Add(Required);
            hash.Add(Title);
            hash.Add(Type);
            hash.Add(Values);
            hash.Add(FileExtension);
            hash.Add(MaxCharacters);
            hash.Add(SKU);
            hash.Add(ImageWidth);
            hash.Add(ImageHeight);
            hash.Add(ProductSKU);
            hash.Add(SortOrder);
            
            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IProductCustomOption"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(IProductCustomOption obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(ProductCustomOptionInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
                Price = model.Price;
                PriceType = model.PriceType;
                Required = model.Required;
                Title = model.Title;
                Type = new ProductCustomOptionType(null, model.Type, null);
                Values = (model.Values == null) ? null : model.Values.Select(v => new ProductCustomOptionValue(v));
                FileExtension = model.FileExtension;
                MaxCharacters = model.MaximumCharacters;
                SKU = model.SKU;
                ImageWidth = model.ImageWidth;
                ImageHeight = model.ImageWidth;
                SortOrder = model.SortOrder;
                ProductSKU = model.ProductSKU;
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[SKU: {0} | Title: {1}]", SKU, Title);
        }

    }
}
