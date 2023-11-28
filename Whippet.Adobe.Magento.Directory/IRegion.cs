using System;
using Athi.Whippet.Json;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a country region in Magento.
    /// </summary>
    public interface IRegion : IMagentoEntity, IEqualityComparer<IRegion>, ICloneable, IWhippetCloneable, IJsonObject, IMagentoRestEntity
    {
        /// <summary>
        /// Gets or sets the region code.
        /// </summary>
        string Code
        { get; set; }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        string Name
        { get; set; }    
    }
}
