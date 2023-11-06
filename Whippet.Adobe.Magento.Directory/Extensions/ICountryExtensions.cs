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

            if (country != null)
            {
                if (country is Country)
                {
                    c = (Country)(country);
                }
                else 
                {
                    c = new Country(country.ID, country.ISO2, country.ISO3, country.Server.ToMagentoServer());
                }
            }

            return c;
        }

        /// <summary>
        /// Creates an <see cref="IRegion"/> object for the current <see cref="ICountry"/>.
        /// </summary>
        /// <typeparam name="TRegion">Type of <see cref="IRegion"/> to create.</typeparam>
        /// <param name="country"></param>
        /// <returns><see cref="IRegion"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IRegion CreateDefaultRegion<TRegion>(this ICountry country) where TRegion : IRegion, new()
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                IRegion region = new TRegion();

                region.Code = "*";
                region.Country = country;
                region.ID = 0;
                region.Name = "*";
                region.Server = country.Server;

                return region;
            }
        }
    }
}

