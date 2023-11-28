using System;
using Athi.Whippet.Adobe.Magento.Directory;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Interface that provides information about a country in Magento.
    /// </summary>
    public class CountryInterface : IExtensionInterface, IExtensionAttributes<CountryExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the country ID. The country ID is the country's ISO-2 code.
        /// </summary>
        [JsonProperty("id")]
        public string ID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the ISO-2 country code.
        /// </summary>
        [JsonProperty("two_letter_abbreviation")]
        public string ISO2
        { get; set; }

        /// <summary>
        /// Gets or setes the ISO-3 country code.
        /// </summary>
        [JsonProperty("three_letter_abbreviation")]
        public string ISO3
        { get; set; }

        /// <summary>
        /// Gets or sets the country name with respect to its locale.
        /// </summary>
        [JsonProperty("full_name_locale")]
        public string LocaleName
        { get; set; }

        /// <summary>
        /// Gets or sets the country name in English.
        /// </summary>
        [JsonProperty("full_name_english")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the available regions for the country.
        /// </summary>
        [JsonProperty("available_regions")]
        public RegionInterface[] AvailableRegions
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CountryExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryInterface"/> class with no arguments.
        /// </summary>
        public CountryInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">ID of the country.</param>
        /// <param name="iso2">ISO-2 code of the country.</param>
        /// <param name="iso3">ISO-3 code of the country.</param>
        /// <param name="localeName">Country name with respect to the country's locale.</param>
        /// <param name="name">English name of the country.</param>
        /// <param name="regions">Country regions listed in Magento.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CountryInterface(string id, string iso2, string iso3, string localeName, string name, IEnumerable<RegionInterface> regions, CountryExtensionInterface extensionAttributes)
            : this()
        {
            ID = id;
            ISO2 = iso2;
            ISO3 = iso3;
            LocaleName = localeName;
            Name = name;
            AvailableRegions = (regions == null) ? null : regions.ToArray();
            ExtensionAttributes = extensionAttributes;
        }
    }
}
