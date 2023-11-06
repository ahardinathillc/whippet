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
    /// Represents an individual postal code of an <see cref="ICity"/>.
    /// </summary>
    public interface IPostalCode : IEqualityComparer<IPostalCode>, IWhippetEntity, IWhippetReadOnlyEntity
    {
        /// <summary>
        /// Gets the postal code value. This property is read-only.
        /// </summary>
        string Value
        { get; }

        /// <summary>
        /// Gets the <see cref="LatitudeLongitudeCoordinate"/> value, if any. This property is read-only.
        /// </summary>
        LatitudeLongitudeCoordinate Coordinates
        { get; }

        /// <summary>
        /// Gets the <see cref="ICity"/> that the postal code is associated with. This property is read-only.
        /// </summary>
        ICity City
        { get; }
    }
}
