using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Geography
{
    /// <summary>
    /// Represents a latitude (vertical) and longitude (horizontal) coordinate on a geographical plane.
    /// </summary>
    public struct LatitudeLongitudeCoordinate : IEqualityComparer<LatitudeLongitudeCoordinate>
    {
        private const byte ROUNDING_VALUE = 4;
        
        /// <summary>
        /// Gets a <see langword="null"/> instance of the <see cref="LatitudeLongitudeCoordinate"/> object. This property is read-only.
        /// </summary>
        public static LatitudeLongitudeCoordinate Null
        {
            get
            {
                return new LatitudeLongitudeCoordinate();
            }
        }

        /// <summary>
        /// Latitude value of the coordinate.
        /// </summary>
        public double? Latitude
        { get; set; }

        /// <summary>
        /// Longitude value of the coordinate.
        /// </summary>
        public double? Longitude
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LatitudeLongitudeCoordinate"/> class with no arguments.
        /// </summary>
        static LatitudeLongitudeCoordinate()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LatitudeLongitudeCoordinate"/> class with the specified values.
        /// </summary>
        /// <param name="latitude">Latitude of the coordinate.</param>
        /// <param name="longitude">Longitude of the coordinate.</param>
        public LatitudeLongitudeCoordinate(double? latitude, double? longitude)
            : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || !(obj is LatitudeLongitudeCoordinate) ? false : Equals((LatitudeLongitudeCoordinate)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(LatitudeLongitudeCoordinate obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(LatitudeLongitudeCoordinate x, LatitudeLongitudeCoordinate y)
        {
            return x.Latitude.GetValueOrDefault().Equals(y.Latitude.GetValueOrDefault()) &&
                   x.Longitude.GetValueOrDefault().Equals(y.Longitude.GetValueOrDefault());
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code of the current instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Latitude, Longitude);
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="obj">Object to get hash code for.</param>
        /// <returns>Hash code of the specified object.</returns>
        public int GetHashCode(LatitudeLongitudeCoordinate obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return "(" + Latitude + ", " + Longitude + ")";
        }
    }
}
