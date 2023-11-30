using System;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Represents a link type for an <see cref="IProduct"/>. 
    /// </summary>
    public struct ProductLinkType : IEqualityComparer<ProductLinkType>, IExtensionInterfaceMap<ProductLinkTypeInterface>
    {
        /// <summary>
        /// Gets or sets the product link code.
        /// </summary>
        public string Code
        { get; set; }
        
        /// <summary>
        /// Gets or sets the product link type name.
        /// </summary>
        public string Name
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLinkType"/> struct with no arguments.
        /// </summary>
        static ProductLinkType()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLinkType"/> struct with no arguments.
        /// </summary>
        public ProductLinkType()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLinkType"/> struct with the specified code and name.
        /// </summary>
        /// <param name="code">Link code.</param>
        /// <param name="name">Link type.</param>
        public ProductLinkType(string code, string name)
            : this()
        {
            Code = code;
            Name = name;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ProductLinkType)) ? false : Equals((ProductLinkType)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductLinkType obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductLinkType x, ProductLinkType y)
        {
            return String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Name?.Trim(), y.Name?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Name);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ProductLinkType"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ProductLinkType obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductLinkTypeInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductLinkTypeInterface"/>.</returns>
        public ProductLinkTypeInterface ToInterface()
        {
            return new ProductLinkTypeInterface(Code, Name, new ProductLinkTypeExtensionInterface());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ProductLinkTypeInterface"/> object used to populate the object.</param>
        public void FromModel(ProductLinkTypeInterface model)
        {
            if (model != null)
            {
                Code = model.Code;
                Name = model.Name;
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
