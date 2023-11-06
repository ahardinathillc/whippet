using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IRegionName"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IRegionNameExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IRegionName"/> object to a <see cref="RegionName"/> object.
        /// </summary>
        /// <param name="region"><see cref="IRegionName"/> object to convert.</param>
        /// <returns><see cref="RegionName"/> object.</returns>
        public static RegionName ToRegionName(this IRegionName region)
        {
            RegionName r = null;

            if (region != null)
            {
                if (region is RegionName)
                {
                    r = (RegionName)(region);
                }
                else
                {
                    r = new RegionName(region.Locale, region.Region.ToRegion(), region.Name, region.Server.ToMagentoServer());
                }
            }

            return r;
        }
    }
}

