using System;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Payment
{
    /// <summary>
    /// Provides extra information about a payment in Magento.
    /// </summary>
    public struct PaymentAdditionalInfo : IEqualityComparer<PaymentAdditionalInfo>, IExtensionInterfaceMap<PaymentAdditionalInfoInterface>
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
        /// Initializes a new instance of the <see cref="PaymentAdditionalInfo"/> class with no arguments.
        /// </summary>
        static PaymentAdditionalInfo()
        { }
          
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentAdditionalInfo"/> struct with no arguments.
        /// </summary>
        public PaymentAdditionalInfo()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentAdditionalInfo"/> struct with the specified <see cref="PaymentAdditionalInfoInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="PaymentAdditionalInfoInterface"/> object.</param>
        public PaymentAdditionalInfo(PaymentAdditionalInfoInterface model)
            : this()
        {
            FromModel(model);
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="PaymentAdditionalInfoInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="PaymentAdditionalInfoInterface"/>.</returns>
        public PaymentAdditionalInfoInterface ToInterface()
        {
            PaymentAdditionalInfoInterface piInterface = new PaymentAdditionalInfoInterface();
            piInterface.Key = Key;
            piInterface.Value = Value;
            
            return piInterface;
        }

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><see cref="PaymentAdditionalInfoInterface"/> object used to populate the object.</param>
        public void FromModel(PaymentAdditionalInfoInterface model)
        {
            if (model != null)
            {
                Key = model.Key;
                Value = model.Value;
            }
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null) || !(obj is PaymentAdditionalInfo) ? false : Equals((PaymentAdditionalInfo)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(PaymentAdditionalInfo obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(PaymentAdditionalInfo x, PaymentAdditionalInfo y)
        {
            return String.Equals(x.Key?.Trim(), y.Key?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Value?.Trim(), y.Value?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Key, Value);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public int GetHashCode(PaymentAdditionalInfo obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[Key: {0} | Value: {1}]", Key, Value);
        }
    }
}
