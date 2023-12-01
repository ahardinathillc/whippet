using System;
using Athi.Whippet.Adobe.Magento;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents a frontend label for a Magento attribute.
    /// </summary>
    public struct AttributeFrontendLabel : IExtensionInterfaceMap<AttributeFrontendLabelInterface>, IEqualityComparer<AttributeFrontendLabel>
    {
        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        public int StoreID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the option label.
        /// </summary>
        public string Label
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeFrontendLabel"/> class with no arguments.
        /// </summary>
        static AttributeFrontendLabel()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeFrontendLabel"/> class with no arguments.
        /// </summary>
        public AttributeFrontendLabel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeFrontendLabel"/> class from the specified <see cref="AttributeFrontendLabelInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="AttributeFrontendLabelInterface"/> object.</param>
        public AttributeFrontendLabel(AttributeFrontendLabelInterface model)
            : this()
        {
            FromModel(model);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeFrontendLabel"/> class with the specified parameters.
        /// </summary>
        /// <param name="storeId">Store ID.</param>
        /// <param name="label">Attribute label.</param>
        public AttributeFrontendLabel(int storeId, string label)
            : this()
        {
            StoreID = storeId;
            Label = label;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is AttributeFrontendLabel)) ? false : Equals((AttributeFrontendLabel)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(AttributeFrontendLabel obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(AttributeFrontendLabel x, AttributeFrontendLabel y)
        {
            return String.Equals(x.Label?.Trim(), y.Label?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.StoreID == y.StoreID;
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(StoreID, Label);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="AttributeFrontendLabel"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(AttributeFrontendLabel obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="AttributeFrontendLabelInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="AttributeFrontendLabelInterface"/>.</returns>
        public AttributeFrontendLabelInterface ToInterface()
        {
            return new AttributeFrontendLabelInterface(StoreID, Label);
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="AttributeFrontendLabelInterface"/> object used to populate the object.</param>
        public void FromModel(AttributeFrontendLabelInterface model)
        {
            if (model != null)
            {
                StoreID = model.StoreID;
                Label = model.Label;
            }
        }
        
        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return Label;
        }
    }
}
