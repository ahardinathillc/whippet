using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Identifies the geographical region of a continent or country.
    /// </summary>
    public enum GeographicalRegion : byte
    {
        [Description(description: "Asia")]
        ASIA = 0,
        [Description(description: "Middle East")]
        MIDDLE_EAST = 1,
        [Description(description: "North Africa")]
        NORTH_AFRICA = 1,
        [Description(description: "Greater Arabia")]
        GREATER_ARABIA = 1,
        [Description(description: "Europe")]
        EUROPE = 2,
        [Description(description: "North America")]
        NORTH_AMERICA = 3,
        [Description(description: "Central America")]
        CENTRAL_AMERICA = 4,
        [Description(description: "Caribbean")]
        CARIBBEAN = 4,
        [Description(description: "South America")]
        SOUTH_AMERICA = 5,
        [Description(description: "Sub-Saharan Africa")]
        SUB_SAHARAN_AFRICA = 6,
        [Description(description: "Australia")]
        AUSTRALIA = 7,
        [Description(description: "Oceania")]
        OCEANIA = 7,
        [Description(description: "Unknown")]
        UNKNOWN = 8
    }
}
