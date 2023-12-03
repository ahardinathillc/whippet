using System;
using Athi.Whippet.Adobe.Magento.Data;
using Terminal.Gui;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Bundle
{
    /// <summary>
    /// Represents a bundle option for an <see cref="IProduct"/>. 
    /// </summary>
    public struct BundleOption : IEqualityComparer<BundleOption>, IExtensionInterfaceMap<BundleOptionInterface>
    {
        /// <summary>
        /// Gets or sets the bundle option ID.
        /// </summary>
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the option title.
        /// </summary>
        public string Title
        { get; set; }

        /// <summary>
        /// Specifies whether the option is required.
        /// </summary>
        public bool Required
        { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        public string Type
        { get; set; }

        /// <summary>
        /// Gets or sets the option position.
        /// </summary>
        public int Position
        { get; set; }

        /// <summary>
        /// Gets or sets the product SKU.
        /// </summary>
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the product links associated with the bundle option.
        /// </summary>
        public IEnumerable<BundleLink> ProductLinks
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleOption"/> class with no arguments.
        /// </summary>
        public BundleOption()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleOption"/> class with the specified <see cref="BundleOptionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="BundleOptionInterface"/> object.</param>
        public BundleOption(BundleOptionInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BundleOption"/> class with the specified parameters.
        /// </summary>
        /// <param name="optionId">Option ID.</param>
        /// <param name="title">Option title.</param>
        /// <param name="isRequired">Specifies whether the option is required.</param>
        /// <param name="type">Input type.</param>
        /// <param name="position">Option position.</param>
        /// <param name="sku">Product SKU.</param>
        /// <param name="productLinks">Product links associated with the bundle option.l</param>
        public BundleOption(int optionId, string title, bool isRequired, string type, int position, string sku, IEnumerable<BundleLink> productLinks)
            : this()
        {
            ID = optionId;
            Title = title;
            Required = isRequired;
            Type = type;
            Position = position;
            SKU = sku;
            ProductLinks = productLinks;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is BundleOption)) ? false : Equals((BundleOption)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(BundleOption obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(BundleOption x, BundleOption y)
        {
            return x.ID == y.ID
                   && String.Equals(x.Title?.Trim(), y.Title?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.Required == y.Required
                   && String.Equals(x.Type?.Trim(), y.Type?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.Position == y.Position
                   && String.Equals(x.SKU?.Trim(), y.SKU?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && (((x.ProductLinks == null) && (y.ProductLinks == null)) || ((x.ProductLinks != null) && x.ProductLinks.SequenceEqual(y.ProductLinks)));
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode code = new HashCode();

            code.Add(ID);
            code.Add(Title);
            code.Add(Required);
            code.Add(Type);
            code.Add(Position);
            code.Add(SKU);
            code.Add(ProductLinks);

            return code.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="BundleOption"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(BundleOption obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="BundleOptionInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="BundleOptionInterface"/>.</returns>
        public BundleOptionInterface ToInterface()
        {
            BundleOptionInterface bInterface = new BundleOptionInterface();

            bInterface.Position = Position;
            bInterface.OptionID = ID;
            bInterface.ProductLinks = (ProductLinks == null) ? null : ProductLinks.Select(pl => pl.ToInterface()).ToArray();
            bInterface.Required = Required;
            bInterface.Title = Title;
            bInterface.Type = Type;
            bInterface.SKU = SKU;
            bInterface.ExtensionAttributes = new BundleOptionExtensionInterface();
            
            return bInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="BundleOptionInterface"/> object used to populate the object.</param>
        public void FromModel(BundleOptionInterface model)
        {
            if (model != null)
            {
                ID = model.OptionID;
                Position = model.Position;
                ProductLinks = (model.ProductLinks == null) ? null : model.ProductLinks.Select(pl => new BundleLink(pl));
                Required = model.Required;
                Title = model.Title;
                Type = model.Type;
                SKU = model.SKU;
            }
        }
    }
}
