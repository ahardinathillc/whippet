using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Geography
{
    /// <summary>
    /// Represents a coordinate unit for geographic positions defined in degrees, minutes, and seconds.
    /// </summary>
    public struct DegreeMinuteSecondCoordinate
    {
        /// <summary>
        /// Degrees unit.
        /// </summary>
        public int Degrees
        { get; set; }

        /// <summary>
        /// Minutes unit.
        /// </summary>
        public int Minutes
        { get; set; }

        /// <summary>
        /// Seconds unit.
        /// </summary>
        public int Seconds
        { get; set; }

        /// <summary>
        /// Direction with respect to the pole.
        /// </summary>
        public CompassDirection Direction
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DegreeMinuteSecondCoordinate"/> class with no arguments.
        /// </summary>
        static DegreeMinuteSecondCoordinate()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DegreeMinuteSecondCoordinate"/> class with the specified values.
        /// </summary>
        /// <param name="degrees">Degrees unit.</param>
        /// <param name="minutes">Minutes unit.</param>
        /// <param name="seconds">Seconds unit.</param>
        /// <param name="direction">Direction with respect to the pole.</param>
        public DegreeMinuteSecondCoordinate(int degrees, int minutes, int seconds, CompassDirection direction)
            : this()
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
            Direction = direction;
        }
    }
}
