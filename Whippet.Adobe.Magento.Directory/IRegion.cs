using System;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a country region in Magento.
    /// </summary>
    public interface IRegion : IMagentoEntity, IEqualityComparer<IRegion>, ICloneable, IWhippetCloneable, IJsonObject
    {
        /// <summary>
        /// Gets or sets the unique region ID.
        /// </summary>
        string RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICountry"/> that the <see cref="IRegion"/> belongs to.
        /// </summary>
        ICountry Country
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="ICountry"/> that the <see cref="IRegion"/> belongs to.
        /// </summary>
        string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the region code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Name
        { get; set; }
    }
}

