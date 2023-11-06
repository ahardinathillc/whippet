using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Localization.Addressing.Extensions
{
    /// <summary>
    /// Provides extensions for <see cref="Country"/> and <see cref="ICountry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class CountryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ICountry"/> object to a <see cref="Country"/> object.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to convert.</param>
        /// <returns><see cref="Country"/> object.</returns>
        public static Country ToCountry(this ICountry country)
        {
            Country cnt = null;

            if (country != null)
            {
                if (cnt is Country)
                {
                    cnt = ((Country)(country));
                }
                else
                {
                    cnt = new Country(country.ID, country.Name, country.Abbreviation, country.CallingCode, country.Region);
                }
            }

            return cnt;
        }
    }
}
