using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Localization.Addressing.Extensions
{
    /// <summary>
    /// Provides extensions for <see cref="StateProvince"/> and <see cref="IStateProvince"/> objects. This class cannot be inherited.
    /// </summary>
    public static class StateProvinceExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IStateProvince"/> object to a <see cref="StateProvince"/> object.
        /// </summary>
        /// <param name="stateProvince"><see cref="IStateProvince"/> object to convert.</param>
        /// <returns><see cref="StateProvince"/> object.</returns>
        public static StateProvince ToStateProvince(this IStateProvince stateProvince)
        {
            StateProvince sp = null;

            if (stateProvince != null)
            {
                if (stateProvince is StateProvince)
                {
                    sp = ((StateProvince)(stateProvince));
                }
                else
                {
                    sp = new StateProvince(stateProvince.ID, stateProvince.Name, stateProvince.Abbreviation, stateProvince.Country?.ToCountry());
                }
            }

            return sp;
        }

        /// <summary>
        /// Builds a <see cref="Country"/> object based on the specified <see cref="Guid"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="StateProvince"/> object.</param>
        /// <param name="countryId"><see cref="Guid"/> of the <see cref="Country"/> to load.</param>
        /// <returns><see cref="Country"/> object or <see langword="null"/> if no match was found.</returns>
        public static Country LookupCountryByGuid(this IStateProvince stateProvince, Guid countryId)
        {
            int index_guid;
            int index_name;
            int index_twoLetterISOAbbreviation;
            int index_threeLetterISOAbbreviation;
            int index_iso3166NumericCode;

            string rawCountryList = AddressingResourceIndex.LoadRawCountryList(out index_guid, out index_name, out index_twoLetterISOAbbreviation, out index_threeLetterISOAbbreviation, out index_iso3166NumericCode);

            string[] countryEntries = null;
            string[] countryPieces = null;

            Country country = null;

            if(!String.IsNullOrWhiteSpace(rawCountryList))
            {
                countryEntries = rawCountryList.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if (countryEntries != null && countryEntries.Any())
                {
                    foreach (string entry in countryEntries)
                    {
                        countryPieces = entry.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                        if (countryId.Equals(new Guid(countryPieces[index_guid])))
                        {
                            country = new Country(new Guid(countryPieces[index_guid]), countryPieces[index_name], countryPieces[index_twoLetterISOAbbreviation]);
                            break;
                        }
                    }
                }

            }

            return country;
        }
    }
}
