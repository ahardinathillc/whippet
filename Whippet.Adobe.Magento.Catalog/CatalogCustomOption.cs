using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog
{
    /// <summary>
    /// Represents a custom option that is applied to all items in a Magento catalog.
    /// </summary>
    public struct CatalogCustomOption : IExtensionInterfaceMap<CatalogCustomOptionInterface>, IEqualityComparer<CatalogCustomOption>
    {
        /// <summary>
        /// Gets or sets the option ID.
        /// </summary>
        public string ID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the option value.
        /// </summary>
        public string Value
        { get; set; }
        
        /// <summary>
        /// Gets or sets the associated option image.
        /// </summary>
        public MagentoImage? Image
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomOption"/> class with no arguments.
        /// </summary>
        static CatalogCustomOption()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomOption"/> class with no arguments.
        /// </summary>
        public CatalogCustomOption()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomOption"/> class with the specified <see cref="CatalogCustomOptionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="CatalogCustomOptionInterface"/> object.</param>
        public CatalogCustomOption(CatalogCustomOptionInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is CatalogCustomOption)) ? false : Equals((CatalogCustomOption)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CatalogCustomOption obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CatalogCustomOption x, CatalogCustomOption y)
        {
            return String.Equals(x.ID?.Trim(), y.ID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Value?.Trim(), y.Value?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.Image.GetValueOrDefault().Equals(y.Image.GetValueOrDefault());
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="CatalogCustomOptionInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="CatalogCustomOptionInterface"/>.</returns>
        public CatalogCustomOptionInterface ToInterface()
        {
            CatalogCustomOptionInterface option = new CatalogCustomOptionInterface();
            option.OptionID = ID;
            option.OptionValue = Value;
            option.ExtensionAttributes = new CatalogCustomOptionExtensionInterface();

            if (Image.HasValue)
            {
                option.ExtensionAttributes.ImageInformation = Image.Value.ToInterface();
            }

            return option;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Value, Image);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="option"><see cref="CatalogCustomOption"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(CatalogCustomOption option)
        {
            ArgumentNullException.ThrowIfNull(option);
            return option.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        public void FromModel(CatalogCustomOptionInterface model)
        {
            if (model != null)
            {
                ID = model.OptionID;
                Value = model.OptionValue;

                if (model.ExtensionAttributes != null && model.ExtensionAttributes.ImageInformation != null)
                {
                    Image = new MagentoImage(model.ExtensionAttributes.ImageInformation);
                }
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(ID) ? base.ToString() : String.Format("[ID: {0} | Value: {1}]", ID, Value);
        }
    }
}
