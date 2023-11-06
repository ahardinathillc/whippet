using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Represents a country that is registered in Whippet with a backing data entity.
    /// </summary>
    public interface ICountry : IEqualityComparer<ICountry>, IWhippetEntity, IWhippetReadOnlyEntity
    {
        /// <summary>
        /// Indicates the name of the country. This property is read-only.
        /// </summary>
        string Name
        { get; }

        /// <summary>
        /// Country abbreviation. This property is read-only.
        /// </summary>
        string Abbreviation
        { get; }

        /// <summary>
        /// Country calling code. This property is read-only.
        /// </summary>
        string CallingCode
        { get; }

        /// <summary>
        /// Provides a list of all the various time zones that the country has. This property is read-only.
        /// </summary>
        /// <remarks>Time zones are loaded via <see cref="NodaTime"/> objects.</remarks>
        IEnumerable<TimeZoneInfo> TimeZones
        { get; }

        /// <summary>
        /// Indicates the geographical region of the country. This property is read-only.
        /// </summary>
        GeographicalRegion Region
        { get; }
    }
}
