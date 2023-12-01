using System;
using Athi.Whippet.Adobe.Magento;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.EAV
{
    /// <summary>
    /// Represents an attribute option in Magento.
    /// </summary>
    public struct AttributeOption : IExtensionInterfaceMap<AttributeOptionInterface>, IEqualityComparer<AttributeOption>
    {
        /// <summary>
        /// Gets or sets the option label.
        /// </summary>
        public string Label
        { get; set; }

        /// <summary>
        /// Gets or sets the option value.
        /// </summary>
        public string Value
        { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public int SortOrder
        { get; set; }

        /// <summary>
        /// Specifies whether the option is the default.
        /// </summary>
        public bool IsDefault
        { get; set; }

        /// <summary>
        /// Gets or sets the option label(s) for store scopes.
        /// </summary>
        public IEnumerable<AttributeOptionLabel> StoreLabels
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeOption"/> class with no argument.
        /// </summary>
        static AttributeOption()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeOption"/> class with no argument.
        /// </summary>
        public AttributeOption()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeOption"/> class with the specified <see cref="AttributeOptionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="AttributeOptionInterface"/> object.</param>
        public AttributeOption(AttributeOptionInterface model)
            : this()
        {
            FromModel(model);
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeOption"/> class with no arguments.
        /// </summary>
        /// <param name="label">Option label.</param>
        /// <param name="value">Option value.</param>
        /// <param name="sortOrder">Sort order.</param>
        /// <param name="isDefault">Specifies whether the option is the default selection.</param>
        /// <param name="storeLabels">Option label(s) for store scopes.</param>
        public AttributeOption(string label, string value, int sortOrder, bool isDefault, IEnumerable<AttributeOptionLabel> storeLabels)
            : this()
        {
            Label = label;
            Value = value;
            SortOrder = sortOrder;
            IsDefault = isDefault;
            StoreLabels = storeLabels;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is AttributeOption)) ? false : Equals((AttributeOption)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(AttributeOption obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(AttributeOption x, AttributeOption y)
        {
            return String.Equals(x.Label?.Trim(), y.Label?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.IsDefault == y.IsDefault
                   && String.Equals(x.Value?.Trim(), y.Value?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && x.SortOrder == y.SortOrder
                   && (((x.StoreLabels == null) && (y.StoreLabels == null)) || ((x.StoreLabels != null) && x.StoreLabels.SequenceEqual(y.StoreLabels)));
        }
        
        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Label, IsDefault, Value, SortOrder, StoreLabels);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj"><see cref="AttributeOption"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(AttributeOption obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="AttributeOption"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="AttributeOptionInterface"/>.</returns>
        public AttributeOptionInterface ToInterface()
        {
            return new AttributeOptionInterface(Label, Value, SortOrder, IsDefault, (StoreLabels == null) ? null : StoreLabels.Select(s => s.ToInterface()));
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="AttributeOptionInterface"/> object used to populate the object.</param>
        public void FromModel(AttributeOptionInterface model)
        {
            if (model != null)
            {
                Label = model.Label;
                IsDefault = model.IsDefault;
                Value = model.Value;
                SortOrder = model.SortOrder;
                StoreLabels = (model.StoreLabels == null) ? null : model.StoreLabels.Select(s => new AttributeOptionLabel(s.StoreID, s.Label));
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
