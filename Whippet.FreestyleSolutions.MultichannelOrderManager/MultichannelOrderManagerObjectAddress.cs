using System;
using System.Text;
using Athi.Whippet.Extensions.Text;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents an address for a Multichannel Order Manager object.
    /// </summary>
    public struct MultichannelOrderManagerObjectAddress : IEqualityComparer<MultichannelOrderManagerObjectAddress>
    {
        /// <summary>
        /// Gets or sets the first line of the address.
        /// </summary>
        public string LineOne
        { get; set; }
        
        /// <summary>
        /// Gets or sets the second line of the address.
        /// </summary>
        public string LineTwo
        { get; set; }
        
        /// <summary>
        /// Gets or sets the third line of the address.
        /// </summary>
        public string LineThree
        { get; set; }
        
        /// <summary>
        /// Gets or sets the city of the address.
        /// </summary>
        public string City
        { get; set; }
        
        /// <summary>
        /// Gets or sets the state of the address.
        /// </summary>
        public string State
        { get; set; }
        
        /// <summary>
        /// Gets or sets the postal code of the address.
        /// </summary>
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the three digit database key for the country record in Multichannel Order Manager.
        /// </summary>
        public MultichannelOrderManagerEntityKey<WhippetNonNullableString> CountryCode
        { get; set; } = WhippetNonNullableString.Empty;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerObjectAddress"/> struct with no arguments.
        /// </summary>
        static MultichannelOrderManagerObjectAddress()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerObjectAddress"/> struct with no arguments.
        /// </summary>
        public MultichannelOrderManagerObjectAddress()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerObjectAddress"/> struct with the specified parameters.
        /// </summary>
        /// <param name="lineOne">First line of the address.</param>
        /// <param name="lineTwo">Second line of the address.</param>
        /// <param name="lineThree">Third line of the address.</param>
        /// <param name="city">City of the address.</param>
        /// <param name="state">State of the address.</param>
        /// <param name="postalCode">Postal code of the address.</param>
        /// <param name="countryCode">Three digit database key for the country record in Multichannel Order Manager.</param>
        public MultichannelOrderManagerObjectAddress(string lineOne, string lineTwo, string lineThree, string city, string state, string postalCode, MultichannelOrderManagerEntityKey<WhippetNonNullableString> countryCode)
            : this()
        {
            LineOne = lineOne;
            LineTwo = lineTwo;
            LineThree = lineThree;
            City = city;
            State = state;
            PostalCode = postalCode;
            CountryCode = countryCode;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is MultichannelOrderManagerObjectAddress) ? false : Equals((MultichannelOrderManagerObjectAddress)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MultichannelOrderManagerObjectAddress obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the specified two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(MultichannelOrderManagerObjectAddress x, MultichannelOrderManagerObjectAddress y)
        {
            return
                String.Equals(x.LineOne?.Trim(), y.LineOne?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(x.LineTwo?.Trim(), y.LineTwo?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(x.LineThree?.Trim(), y.LineThree?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(x.City?.Trim(), y.City?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(x.State?.Trim(), y.State?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(x.PostalCode?.Trim(), y.PostalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                && String.Equals(x.CountryCode.ToValue().Trim(), y.CountryCode.ToValue().Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(LineOne, LineTwo, LineThree, City, State, PostalCode, CountryCode.ToValue());
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public int GetHashCode(MultichannelOrderManagerObjectAddress obj)
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

            if (!String.IsNullOrWhiteSpace(LineOne))
            {
                builder.Append(LineOne);
            }

            if (!String.IsNullOrWhiteSpace(LineTwo))
            {
                if (!String.IsNullOrWhiteSpace(builder.ToString()))
                {
                    builder.AppendSpace();
                    builder.Append('|');
                    builder.AppendSpace();
                }

                builder.Append(LineTwo);
            }
            
            if (!String.IsNullOrWhiteSpace(LineThree))
            {
                if (!String.IsNullOrWhiteSpace(builder.ToString()))
                {
                    builder.AppendSpace();
                    builder.Append('|');
                    builder.AppendSpace();
                }

                builder.Append(LineThree);
            }
            
            if (!String.IsNullOrWhiteSpace(City))
            {
                if (!String.IsNullOrWhiteSpace(builder.ToString()))
                {
                    builder.AppendSpace();
                    builder.Append('|');
                    builder.AppendSpace();
                }

                builder.Append(City);
            }
            
            if (!String.IsNullOrWhiteSpace(State))
            {
                if (!String.IsNullOrWhiteSpace(builder.ToString()))
                {
                    builder.AppendSpace();
                    builder.Append('|');
                    builder.AppendSpace();
                }

                builder.Append(State);
            }
            
            if (!String.IsNullOrWhiteSpace(PostalCode))
            {
                if (!String.IsNullOrWhiteSpace(builder.ToString()))
                {
                    builder.AppendSpace();
                    builder.Append('|');
                    builder.AppendSpace();
                }

                builder.Append(PostalCode);
            }

            if (!String.IsNullOrWhiteSpace(builder.ToString()))
            {
                builder.Insert(0, "[");
                builder.Append("]");
            }
            else
            {
                builder.Append(base.ToString());
            }

            return builder.ToString();
        }
    }
}
