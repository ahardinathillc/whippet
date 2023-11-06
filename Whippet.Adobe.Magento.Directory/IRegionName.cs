using System;
using System.Drawing;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory
{
    /// <summary>
    /// Represents a localized region name in Magento.
    /// </summary>
    public interface IRegionName : IMagentoEntity, IEqualityComparer<IRegionName>
    {
        /// <summary>
        /// Gets or sets the composite ID of the <see cref="IRegionName"/>.
        /// </summary>
        new RegionNameKey ID
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="RegionName"/> locale.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        string Locale
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IRegion"/> that the <see cref="IRegionName"/> is for.
        /// </summary>
        IRegion Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region name.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string Name
        { get; set; }
    }
}
