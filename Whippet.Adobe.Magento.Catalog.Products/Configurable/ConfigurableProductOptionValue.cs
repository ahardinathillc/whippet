using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable
{
    /// <summary>
    /// Represents a Magento gift card amount.
    /// </summary>
    public struct ConfigurableProductOptionValue : IExtensionInterfaceMap<ConfigurableProductOptionValueInterface>, IEqualityComparer<ConfigurableProductOptionValue>
    {
        /// <summary>
        /// Gets or sets the index of the option.
        /// </summary>
        public int Index
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOptionValue"/> struct with no arguments.
        /// </summary>
        static ConfigurableProductOptionValue()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOptionValue"/> struct with no arguments.
        /// </summary>
        public ConfigurableProductOptionValue()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOptionValue"/> struct with the specified <see cref="ConfigurableProductOptionValueInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ConfigurableProductOptionValueInterface"/> object to initialize with.</param>
        public ConfigurableProductOptionValue(ConfigurableProductOptionValueInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableProductOptionValue"/> struct with the specified value.
        /// </summary>
        /// <param name="index">Value index.</param>
        public ConfigurableProductOptionValue(int index)
            : this()
        {
            Index = index;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ConfigurableProductOptionValue)) ? false : Equals((ConfigurableProductOptionValue)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ConfigurableProductOptionValue obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ConfigurableProductOptionValue x, ConfigurableProductOptionValue y)
        {
            return x.Index == y.Index;
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Index);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ConfigurableProductOptionValue"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ConfigurableProductOptionValue obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ConfigurableProductOptionValueInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ConfigurableProductOptionValueInterface"/>.</returns>
        public ConfigurableProductOptionValueInterface ToInterface()
        {
            return new ConfigurableProductOptionValueInterface(Index, new ConfigurableProductOptionValueExtensionInterface());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ConfigurableProductOptionValueInterface"/> object used to populate the object.</param>
        public void FromModel(ConfigurableProductOptionValueInterface model)
        {
            if (model != null)
            {
                Index = model.ValueIndex;
            }
        }
    }
}
