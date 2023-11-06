using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Localization.Addressing
{
    /// <summary>
    /// Provides an index of available resources for the <see cref="Athi.Whippet.Localization.Addressing"/> namespace. This class cannot be inherited.
    /// </summary>
    internal static class AddressingResourceIndex
    {
        //5a2da7c2-4338-4e17-98f5-49b54f13f6d3,Afghanistan,AF,AFG,4
        // Country entires are ID, NAME, 2-LETTER ISO ABBR, 3-LETTER ISO ABBR, ISO-3166 NUMERIC CODE

        /// <summary>
        /// Loads the raw listing of all countries in Whippet. All country entries are semicolon delimited with individual pieces comma delimited.
        /// </summary>
        /// <param name="index_guid">Index of the GUID ID of the country.</param>
        /// <param name="index_name">Index of the country name.</param>
        /// <param name="index_twoLetterISOAbbreviation">Index of the country's two letter ISO abbreviation.</param>
        /// <param name="index_threeLetterISOAbbreviation">Index of the country's three letter ISO abbreviation.</param>
        /// <param name="index_iso3166NumericCode">Index of the country's ISO 3166 numeric code.</param>
        /// <returns>Raw country list.</returns>
        public static string LoadRawCountryList(out int index_guid, out int index_name, out int index_twoLetterISOAbbreviation, out int index_threeLetterISOAbbreviation, out int index_iso3166NumericCode)
        {
            index_guid = 0;
            index_name = 1;
            index_twoLetterISOAbbreviation = 2;
            index_threeLetterISOAbbreviation = 3;
            index_iso3166NumericCode = 4;

            return LocalizedStringResourceLoader.GetResource("Countries", "countries");
        }
    }
}
