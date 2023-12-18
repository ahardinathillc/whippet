using System;
using System.Text;
using Athi.Whippet.Extensions.Text;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents an address for a Multichannel Order Manager object.
    /// </summary>
    public struct MultichannelOrderManagerObjectPhone : IEqualityComparer<MultichannelOrderManagerObjectPhone>
    {
        /// <summary>
        /// Gets or sets the primary phone number.
        /// </summary>
        public string Primary
        { get; set; }
        
        /// <summary>
        /// Gets or sets the secondary phone number.
        /// </summary>
        public string Secondary
        { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Primary"/> phone extension.
        /// </summary>
        public string PrimaryExtension
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Secondary"/> phone extension.
        /// </summary>
        public string SecondaryExtension
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerObjectPhone"/> struct with no arguments.
        /// </summary>
        static MultichannelOrderManagerObjectPhone()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerObjectPhone"/> struct with no arguments.
        /// </summary>
        public MultichannelOrderManagerObjectPhone()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerObjectPhone"/> struct with the specified parameters.
        /// </summary>
        /// <param name="primary">Primary phone number.</param>
        /// <param name="primaryExtension">Primary phone number extension.</param>
        /// <param name="secondary">Secondary phone number.</param>
        /// <param name="secondaryExtension">Secondary phone number extension.</param>
        public MultichannelOrderManagerObjectPhone(string primary, string primaryExtension, string secondary, string secondaryExtension)
            : this()
        {
            Primary = primary;
            Secondary = secondary;
            PrimaryExtension = primaryExtension;
            SecondaryExtension = secondaryExtension;
        }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is MultichannelOrderManagerObjectPhone) ? false : Equals((MultichannelOrderManagerObjectPhone)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MultichannelOrderManagerObjectPhone obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the specified two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MultichannelOrderManagerObjectPhone x, MultichannelOrderManagerObjectPhone y)
        {
            return
                String.Equals(x.Primary?.Trim(), y.Primary?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(x.PrimaryExtension?.Trim(), y.PrimaryExtension?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(x.Secondary?.Trim(), y.Secondary?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(x.SecondaryExtension?.Trim(), y.SecondaryExtension?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Primary, Secondary);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public int GetHashCode(MultichannelOrderManagerObjectPhone obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(Primary))
            {
                builder.Append("Primary: ");
                builder.Append(Primary);
            }

            if (!String.IsNullOrWhiteSpace(Secondary))
            {
                if (!String.IsNullOrWhiteSpace(builder.ToString()))
                {
                    builder.AppendSpace();
                    builder.Append('|');
                    builder.AppendSpace();
                }

                builder.Append(Secondary);
            }
            
            if (!String.IsNullOrWhiteSpace(builder.ToString()))
            {
                builder.Insert(0, "[");
                builder.Append(']');
            }
            else
            {
                builder.Append(base.ToString());
            }

            return builder.ToString();
        }
    }
}
