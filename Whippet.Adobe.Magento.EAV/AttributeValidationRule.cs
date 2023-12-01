using System;
using Athi.Whippet.Adobe.Magento;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents a validation rule for a Magento attribute.
    /// </summary>
    public struct AttributeValidationRule : IExtensionInterfaceMap<AttributeValidationRuleInterface>, IEqualityComparer<AttributeValidationRule>
    {
        /// <summary>
        /// Gets or sets the object key.
        /// </summary>
        public string Key
        { get; set; }
        
        /// <summary>
        /// Gets or sets the object value.
        /// </summary>
        public string Value
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeValidationRule"/> class with no arguments.
        /// </summary>
        static AttributeValidationRule()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeValidationRule"/> class with no arguments.
        /// </summary>
        public AttributeValidationRule()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeValidationRule"/> class with the specified <see cref="AttributeValidationRuleInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="AttributeValidationRuleInterface"/> object.</param>
        public AttributeValidationRule(AttributeValidationRuleInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeValidationRule"/> class with the specified parameters.
        /// </summary>
        /// <param name="key">Object key.</param>
        /// <param name="value">Attribute value.</param>
        public AttributeValidationRule(string key, string value)
            : this()
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is AttributeValidationRule)) ? false : Equals((AttributeValidationRule)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(AttributeValidationRule obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(AttributeValidationRule x, AttributeValidationRule y)
        {
            return String.Equals(x.Value?.Trim(), y.Value?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Key?.Trim(), y.Key?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Key, Value);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="AttributeValidationRule"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(AttributeValidationRule obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="AttributeValidationRuleInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="AttributeValidationRuleInterface"/>.</returns>
        public AttributeValidationRuleInterface ToInterface()
        {
            return new AttributeValidationRuleInterface(Key, Value);
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="AttributeValidationRuleInterface"/> object used to populate the object.</param>
        public void FromModel(AttributeValidationRuleInterface model)
        {
            if (model != null)
            {
                Key = model.Key;
                Value = model.Value;
            }
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return "[" + Key?.Trim() + " : " + Value?.Trim() + "]";
        }
    }
}
