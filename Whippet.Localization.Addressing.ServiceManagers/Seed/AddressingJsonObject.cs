using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Seed
{
    /// <summary>
    /// Represents a lightweight data object for serializing/deserializing addressing JSON objects.
    /// </summary>
    internal class AddressingJsonObject : IEqualityComparer<AddressingJsonObject>
    {
        /// <summary>
        /// Represents the postal code portion of the address.
        /// </summary>
        [JsonProperty(nameof(postal_code))]
        public string postal_code
        { get; set; }

        /// <summary>
        /// Latitude of the postal code.
        /// </summary>
        [JsonProperty(nameof(latitude))]
        public double? latitude
        { get; set; }

        /// <summary>
        /// Longitude of the postal code.
        /// </summary>
        [JsonProperty(nameof(longitude))]
        public double? longitude
        { get; set; }

        /// <summary>
        /// City portion of the postal code.
        /// </summary>
        [JsonProperty(nameof(city))]
        public string city
        { get; set; }

        /// <summary>
        /// State, province, or administrative region of the address.
        /// </summary>
        [JsonProperty(nameof(state))]
        public string state
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressingJsonObject"/> class with no arguments.
        /// </summary>
        public AddressingJsonObject()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressingJsonObject"/> class with the specified parameters.
        /// </summary>
        /// <param name="postalCode">Postal code portion of the address.</param>
        /// <param name="latitude">Latitude of the postal code.</param>
        /// <param name="longitude">Longitude of the postal code.</param>
        /// <param name="city">City portion of the postal code.</param>
        /// <param name="state">State, province, or administrative region of the address.</param>
        public AddressingJsonObject(string postalCode, double? latitude, double? longitude, string city, string state)
            : this()
        {
            postal_code = postalCode;
            this.latitude = latitude.GetValueOrDefault();
            this.longitude = longitude.GetValueOrDefault();
            this.city = city;
            this.state = state;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as AddressingJsonObject);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(AddressingJsonObject obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(AddressingJsonObject x, AddressingJsonObject y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null && y != null))
            {
                equals = String.Equals(x.city, y.city, StringComparison.InvariantCultureIgnoreCase) &&
                    String.Equals(x.postal_code, y.postal_code, StringComparison.InvariantCultureIgnoreCase) &&
                    String.Equals(x.state, y.state, StringComparison.InvariantCultureIgnoreCase) &&
                    x.latitude == y.latitude &&
                    x.longitude == y.longitude;
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(AddressingJsonObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }
    }
}
