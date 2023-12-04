using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Athi.Whippet.Adobe.Magento.SalesRule
{
    /// <summary>
    /// Represents a sales rule label for a Magento store.
    /// </summary>
    public class SalesRuleLabel : IEqualityComparer<SalesRuleLabel>, IExtensionInterfaceMap<SalesRuleLabelInterface>
    {
        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        public int StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the label value.
        /// </summary>
        public string Label
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleLabel"/> class with no arguments.
        /// </summary>
        static SalesRuleLabel()
        { }
          
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleLabel"/> struct with no arguments.
        /// </summary>
        public SalesRuleLabel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleLabel"/> struct with the specified <see cref="SalesRuleLabelInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesRuleLabelInterface"/> object.</param>
        public SalesRuleLabel(SalesRuleLabelInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesRuleLabel"/> struct with the specified store ID and label value.
        /// </summary>
        /// <param name="storeId">Store ID.</param>
        /// <param name="label">Label value.</param>
        public SalesRuleLabel(int storeId, string label)
            : this()
        {
            StoreID = storeId;
            Label = label;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesRuleLabelInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesRuleLabelInterface"/>.</returns>
        public SalesRuleLabelInterface ToInterface()
        {
            return new SalesRuleLabelInterface(StoreID, Label, new SalesRuleLabelExtensionInterface());
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="SalesRuleLabelInterface"/> object used to populate the object.</param>
        public void FromModel(SalesRuleLabelInterface model)
        {
            if (model != null)
            {
                StoreID = model.StoreID;
                Label = model.Label;
            }
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null) || !(obj is SalesRuleLabel) ? false : Equals((SalesRuleLabel)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesRuleLabel obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(SalesRuleLabel x, SalesRuleLabel y)
        {
            return (x.StoreID == y.StoreID) && String.Equals(x.Label?.Trim(), y.Label?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(StoreID, Label);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public int GetHashCode(SalesRuleLabel obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.IsNullOrWhiteSpace(Label) ? base.ToString() : Label.Trim();
        }
    }
}
