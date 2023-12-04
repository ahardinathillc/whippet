using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Catalog.Products.Configurable
{
    /// <summary>
    /// Represents a configurable item option for a product.
    /// </summary>
    public struct ConfigurableItemOptionValue : IExtensionInterfaceMap<ConfigurableItemOptionValueInterface>, IEqualityComparer<ConfigurableItemOptionValue>
    {
        /// <summary>
        /// Gets or sets the option SKU.
        /// </summary>
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        public int Value
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableItemOptionValue"/> struct with no arguments.
        /// </summary>
        static ConfigurableItemOptionValue()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableItemOptionValue"/> struct with no arguments.
        /// </summary>
        public ConfigurableItemOptionValue()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableItemOptionValue"/> struct with the specified <see cref="ConfigurableItemOptionValueInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ConfigurableItemOptionValueInterface"/> object to initialize with.</param>
        public ConfigurableItemOptionValue(ConfigurableItemOptionValueInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurableItemOptionValue"/> struct with the specified parameters.
        /// </summary>
        /// <param name="sku">Option SKU.</param>
        /// <param name="value">Item ID.</param>
        public ConfigurableItemOptionValue(string sku, int value)
            : this()
        {
            SKU = sku;
            Value = value;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ConfigurableItemOptionValue)) ? false : Equals((ConfigurableItemOptionValue)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ConfigurableItemOptionValue obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(ConfigurableItemOptionValue x, ConfigurableItemOptionValue y)
        {
            return x.Value == y.Value
                   && String.Equals(x.SKU?.Trim(), y.SKU?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(SKU, Value);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ConfigurableItemOptionValue"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ConfigurableItemOptionValue obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="ConfigurableItemOptionValueInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="ConfigurableItemOptionValueInterface"/>.</returns>
        public ConfigurableItemOptionValueInterface ToInterface()
        {
            return new ConfigurableItemOptionValueInterface(SKU, Value, new ConfigurableItemOptionValueExtensionInterface());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="ConfigurableItemOptionValueInterface"/> object used to populate the object.</param>
        public void FromModel(ConfigurableItemOptionValueInterface model)
        {
            if (model != null)
            {
                SKU = model.OptionID;
                Value = model.Value;
            }
        }
    }
}
