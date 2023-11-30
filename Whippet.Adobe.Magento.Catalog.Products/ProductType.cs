using System;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Provides information about an <see cref="IProduct"/> type.
    /// </summary>
    public struct ProductType : IEqualityComparer<ProductType>, IExtensionInterfaceMap<ProductTypeInterface>
    {
        /// <summary>
        /// Gets or sets the product type code.
        /// </summary>
        public string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the product type label.
        /// </summary>
        public string Label
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductType"/> struct with no arguments.
        /// </summary>
        static ProductType()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductType"/> struct with no arguments. 
        /// </summary>
        public ProductType()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductType"/> struct with the specified name and label.
        /// </summary>
        /// <param name="name">Product type code.</param>
        /// <param name="label">Product type label.</param>
        public ProductType(string name, string label)
            : this()
        {
            Name = name;
            Label = label;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ProductType)) ? false : Equals((ProductType)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductType obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductType x, ProductType y)
        {
            return String.Equals(x.Label?.Trim(), y.Label?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Label, Name);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ProductType"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ProductType obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductTypeInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductTypeInterface"/>.</returns>
        public ProductTypeInterface ToInterface()
        {
            return new ProductTypeInterface(Name, Label, new ProductTypeExtensionInterface());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ProductTypeInterface"/> object used to populate the object.</param>
        public void FromModel(ProductTypeInterface model)
        {
            if (model != null)
            {
                Name = model.Name;
                Label = model.Label;
            }
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
        }
        
    }
}
