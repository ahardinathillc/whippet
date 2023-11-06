using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Geography
{
    /// <summary>
    /// Represents a compass direction between a north and south pole.
    /// </summary>
    [Flags]
    public enum CompassDirection : byte
    {
        North = 0,
        Northeast = 1,
        East = 2,
        Southeast = 4,
        South = 8,
        SouthWest = 16,
        West = 32,
        NorthWest = 64
    }
}
