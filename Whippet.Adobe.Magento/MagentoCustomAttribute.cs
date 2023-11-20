using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Represents a custom attribute in Magento that is applied to a Magento entity.
    /// </summary>
    public struct MagentoCustomAttribute : IEqualityComparer<MagentoCustomAttribute>
    {
        /// <summary>
        /// Gets or sets the attribute code.
        /// </summary>
        [JsonProperty("attribute_code")]
        public string Code
        { get; set; }
        
        /// <summary>
        /// Gets or sets the attribute value.
        /// </summary>
        [JsonProperty("value")]
        public string Value
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoCustomAttribute"/> structure with no arguments.
        /// </summary>
        static MagentoCustomAttribute()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoCustomAttribute"/> structure with no arguments.
        /// </summary>
        public MagentoCustomAttribute()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoCustomAttribute"/> structure with the specified code and value.
        /// </summary>
        /// <param name="code">Attribute code.</param>
        /// <param name="value">Attribute value.</param>
        public MagentoCustomAttribute(string code, string value)
            : this()
        {
            Code = code;
            Value = value;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is MagentoCustomAttribute) ? false : Equals((MagentoCustomAttribute)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MagentoCustomAttribute obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MagentoCustomAttribute x, MagentoCustomAttribute y)
        {
            return String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                   && String.Equals(x.Value?.Trim(), y.Value?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Gets the hash code for the current instance.
        /// </summary>
        /// <returns>Hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Value);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public int GetHashCode(MagentoCustomAttribute obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return String.Format("[Code: {0} | Value: {1}]", Code?.Trim(), Value?.Trim());
        }

        public static implicit operator KeyValuePair<string, string>(MagentoCustomAttribute obj)
        {
            return new KeyValuePair<string, string>(obj.Code, obj.Value);
        }

        public static implicit operator MagentoCustomAttribute(KeyValuePair<string, string> obj)
        {
            return new MagentoCustomAttribute(obj.Key, obj.Value);
        }
    }
}
