using System;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a country in Magento.
    /// </summary>
    public interface ICountry : IMagentoEntity, IEqualityComparer<ICountry>, ICloneable, IWhippetCloneable, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the country ID. The country ID is the country's ISO-2 code.
        /// </summary>
        new string ID
        { get; set; }
                
        /// <summary>
        /// Gets or sets the ISO-2 country code.
        /// </summary>
        string ISO2
        { get; set; }
        
        /// <summary>
        /// Gets or sets the ISO-3 country code.
        /// </summary>
        string ISO3
        { get; set; }
        
        /// <summary>
        /// Gets or sets the country name with respect to its locale.
        /// </summary>
        string LocaleName
        { get; set; }
        
        /// <summary>
        /// Gets or sets the country name in English.
        /// </summary>
        string Name
        { get; set; }
        
        /// <summary>
        /// Gets or sets the available regions for the country.
        /// </summary>
        IEnumerable<IRegion> AvailableRegions
        { get; set; }    
    }
}
