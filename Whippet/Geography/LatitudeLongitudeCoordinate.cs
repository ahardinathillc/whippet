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
    public struct LatitudeLongitudeCoordinate
    {
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
        public decimal? Latitude
        { get; set; }

        /// <summary>
        /// Longitude value of the coordinate.
        /// </summary>
        public decimal? Longitude
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
        public LatitudeLongitudeCoordinate(decimal? latitude, decimal? longitude)
            : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
