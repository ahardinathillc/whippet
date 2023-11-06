using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Represents an individual state of a particular <see cref="ICountry"/>.
    /// </summary>
    public interface IStateProvince : IEqualityComparer<IStateProvince>, IWhippetEntity, IWhippetReadOnlyEntity
    {
        /// <summary>
        /// Gets the name of the state. This property is read-only.
        /// </summary>
        string Name
        { get; }

        /// <summary>
        /// Gets the abbreviation of the state. This property is read-only.
        /// </summary>
        string Abbreviation
        { get; }

        /// <summary>
        /// Gets the <see cref="ICountry"/> that the <see cref="IStateProvince"/> belongs to. This property is read-only.
        /// </summary>
        ICountry Country
        { get; }
    }
}
