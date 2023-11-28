using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ICountry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICountryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ICountry"/> object to a <see cref="Country"/> object.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to convert.</param>
        /// <returns><see cref="Country"/> object.</returns>
        public static Country ToCountry(this ICountry country)
        {
            Country c = null;

            if (country is Country)
            {
                c = (Country)(country);
            }
            else if (country != null)
            {
                c = new Country();
                c.ID = country.ID;
                c.Name = country.Name;
                c.AvailableRegions = (country.AvailableRegions == null) ? null : country.AvailableRegions.Select(r => r.ToRegion());
                c.LocaleName = country.LocaleName;
                c.ISO2 = country.ISO2;
                c.ISO3 = country.ISO3;
                c.Server = country.Server.ToMagentoServer();
                c.RestEndpoint = country.RestEndpoint.ToMagentoRestEndpoint();
            }

            return c;
        }
    }
}
