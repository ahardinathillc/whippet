using System;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products
{
    /// <summary>
    /// Provides information about a custom <see cref="IProduct"/> option type.
    /// </summary>
    public struct ProductCustomOptionType : IEqualityComparer<ProductCustomOptionType>, IExtensionInterfaceMap<ProductCustomOptionTypeInterface>
    {
        /// <summary>
        /// Gets or sets the option type label.
        /// </summary>
        public string Label
        { get; set; }
        
        /// <summary>
        /// Gets or sets the option type code.
        /// </summary>
        public string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the option type group.
        /// </summary>
        public string Group
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionType"/> struct with no arguments.
        /// </summary>
        static ProductCustomOptionType()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionType"/> struct with no arguments. 
        /// </summary>
        public ProductCustomOptionType()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCustomOptionType"/> struct with the specified parameters.
        /// </summary>
        /// <param name="label">Option type label.</param>
        /// <param name="code">Option type code.</param>
        /// <param name="group">Option type group.</param>
        public ProductCustomOptionType(string label, string code, string group)
            : this()
        {
            Label = label;
            Code = code;
            Group = group;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ProductCustomOptionType)) ? false : Equals((ProductCustomOptionType)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductCustomOptionType obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ProductCustomOptionType x, ProductCustomOptionType y)
        {
            return String.Equals(x.Label?.Trim(), y.Label?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Group?.Trim(), y.Group?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Label, Code, Group);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ProductCustomOptionType"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ProductCustomOptionType obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ProductCustomOptionTypeInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ProductCustomOptionTypeInterface"/>.</returns>
        public ProductCustomOptionTypeInterface ToInterface()
        {
            return new ProductCustomOptionTypeInterface(Label, Code, Group, new ProductCustomOptionTypeExtensionInterface());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ProductCustomOptionTypeInterface"/> object used to populate the object.</param>
        public void FromModel(ProductCustomOptionTypeInterface model)
        {
            if (model != null)
            {
                Label = model.Label;
                Code = model.Code;
                Group = model.Group;
            }
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Label) ? base.ToString() : Label;
        }
        
    }
}
