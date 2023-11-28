using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IRegion"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IRegionExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IRegion"/> object to a <see cref="Region"/> object.
        /// </summary>
        /// <param name="region"><see cref="IRegion"/> object to convert.</param>
        /// <returns><see cref="Region"/> object.</returns>
        public static Region ToRegion(this IRegion region)
        {
            Region r = null;

            if (region is Region)
            {
                r = (Region)(region);
            }
            else if (region != null)
            {
                r = new Region();
                r.ID = region.ID;
                r.Code = region.Code;
                r.Name = region.Name;
                r.RestEndpoint = region.RestEndpoint.ToMagentoRestEndpoint();
                r.Server = region.Server.ToMagentoServer();
            }

            return r;
        }
    }
}
