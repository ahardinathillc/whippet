using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Geography;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Represents an individual city of a particular <see cref="IStateProvince"/>.
    /// </summary>
    public interface ICity : IWhippetReadOnlyEntity, IWhippetEntity, IEqualityComparer<ICity>
    {
        /// <summary>
        /// Gets the name of the city. This property is read-only.
        /// </summary>
        string Name
        { get; }

        /// <summary>
        /// Getse the latitude and longitude of a city. This property is read-only.
        /// </summary>
        LatitudeLongitudeCoordinate Coordinates
        { get; }

        /// <summary>
        /// Gets the <see cref="IStateProvince"/> of the city. This property is read-only.
        /// </summary>
        IStateProvince StateProvince
        { get; }
    }
}
