using Newtonsoft.Json;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers
{
    /// <summary>
    /// Represents a lightweight data object for serializing/deserializing addressing JSON objects.
    /// </summary>
    internal class _AddressingJsonModel : IEqualityComparer<_AddressingJsonModel>
    {
        /// <summary>
        /// Country code of the address.
        /// </summary>
        [JsonProperty("country_code")]
        public string country_code
        { get; set; }
        
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
        /// State, province, or administrative region code.
        /// </summary>
        [JsonProperty("state_code")]
        public string state_code
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="_AddressingJsonModel"/> class with no arguments.
        /// </summary>
        public _AddressingJsonModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="_AddressingJsonModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="postalCode">Postal code portion of the address.</param>
        /// <param name="latitude">Latitude of the postal code.</param>
        /// <param name="longitude">Longitude of the postal code.</param>
        /// <param name="city">City portion of the postal code.</param>
        /// <param name="state">State, province, or administrative region of the address.</param>
        public _AddressingJsonModel(string postalCode, double? latitude, double? longitude, string city, string state)
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
            return Equals(obj as _AddressingJsonModel);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(_AddressingJsonModel obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(_AddressingJsonModel x, _AddressingJsonModel y)
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
            return HashCode.Combine(city, postal_code, state, latitude, longitude);
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(_AddressingJsonModel obj)
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
