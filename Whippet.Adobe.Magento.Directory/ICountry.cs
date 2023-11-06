using System;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a country in Magento.
    /// </summary>
    public interface ICountry : IMagentoEntity, IEqualityComparer<ICountry>, ICloneable, IWhippetCloneable, IJsonObject
    {
        /// <summary>
        /// Gets or sets the unique ID of the <see cref="MagentoEntity"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        new string ID
        { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the <see cref="ICountry"/>.
        /// </summary>
        string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the ISO-2 country code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string ISO2
        { get; set; }

        /// <summary>
        /// Gets or sets the ISO-3 country code.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string ISO3
        { get; set; }

        /// <summary>
        /// Gets or sets the locale-specific name of the <see cref="ICountry"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string LocaleName
        { get; set; }

        /// <summary>
        /// Gets or sets the English name of the <see cref="ICountry"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        string EnglishName
        { get; set; }

        /// <summary>
        /// Gets or sets the available regions for the store.
        /// </summary>
        IEnumerable<IRegion> AvailableRegions
        { get; set; }
    }
}

