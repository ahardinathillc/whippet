using System;
using Athi.Whippet.Data;
using System.Data;
using System.Reflection;
using Athi.Whippet.Security.Tenants.Extensions;
using MySqlX.XDevAPI.Relational;
using System.Linq;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerCountry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerCountryExtensions
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> of <see cref="IMultichannelOrderManagerCountry"/> codes that support <see cref="IMultichannelOrderManagerCounty"/> objects. This property is read-only.
        /// </summary>
        private static IEnumerable<string> SupportedCountyCountries
        {
            get
            {
                return new[] { "001" };
            }
        }

        /// <summary>
        /// Determines if the specified <see cref="IMultichannelOrderManagerCountry"/> supports counties.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> object to check.</param>
        /// <returns><see langword="true"/> if counties are supported; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException" />
        public static bool SupportsCounties(this IMultichannelOrderManagerCountry country)
        {
            ArgumentNullException.ThrowIfNull(country);

            bool supportsCounties = false;

            if (!((country == null || String.IsNullOrWhiteSpace(country.CountryCode?.Trim()))))
            {
                foreach (string code in SupportedCountyCountries)
                {
                    if (String.Equals(country.CountryCode?.Trim(), code, StringComparison.InvariantCultureIgnoreCase))
                    {
                        supportsCounties = true;
                        break;
                    }
                }
            }

            return supportsCounties;
        }

        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerCountry"/> object to a <see cref="MultichannelOrderManagerCountry"/> object.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerServer"/> object.</returns>
        public static MultichannelOrderManagerCountry ToMultichannelOrderManagerCountry(this IMultichannelOrderManagerCountry country)
        {
            MultichannelOrderManagerCountry ct = null;

            if (country != null)
            {
                if (country is MultichannelOrderManagerCountry)
                {
                    ct = (MultichannelOrderManagerCountry)(country);
                }
                else
                {
                    ct.CountryCode = country.CountryCode;
                    ct.CountryId = country.CountryId;
                    ct.ISO2 = country.ISO2;
                    ct.ISO3 = country.ISO3;
                    ct.ISONumber = country.ISONumber;
                    ct.LCAP_A = country.LCAP_A;
                    ct.LCAP_B = country.LCAP_B;
                    ct.LCAP_C = country.LCAP_C;
                    ct.LCAP_D = country.LCAP_D;
                    ct.LCAP_E = country.LCAP_E;
                    ct.LookupBy = country.LookupBy;
                    ct.LookupOn = country.LookupOn;
                    ct.LTAXIT_A = country.LTAXIT_A;
                    ct.LTAXIT_B = country.LTAXIT_B;
                    ct.LTAXIT_C = country.LTAXIT_C;
                    ct.LTAXIT_D = country.LTAXIT_D;
                    ct.LTAXIT_E = country.LTAXIT_E;
                    ct.Name = country.Name;
                    ct.NationalTaxRate = country.NationalTaxRate;
                    ct.NCAP_A = country.NCAP_A;
                    ct.NCAP_B = country.NCAP_B;
                    ct.NCAP_C = country.NCAP_C;
                    ct.NCAP_D = country.NCAP_D;
                    ct.NCAP_E = country.NCAP_E;
                    ct.NONTAXBOX = country.NONTAXBOX;
                    ct.NTAXIT_A = country.NTAXIT_A;
                    ct.NTAXIT_B = country.NTAXIT_B;
                    ct.NTAXIT_C = country.NTAXIT_C;
                    ct.NTAXIT_D = country.NTAXIT_D;
                    ct.NTAXIT_E = country.NTAXIT_E;
                    ct.NTAXTHRES_A = country.NTAXTHRES_A;
                    ct.NTAXTHRES_B = country.NTAXTHRES_B;
                    ct.NTAXTHRES_C = country.NTAXTHRES_C;
                    ct.NTAXTHRES_D = country.NTAXTHRES_D;
                    ct.NTAXTHRES_E = country.NTAXTHRES_E;
                    ct.PhoneMask = country.PhoneMask;
                    ct.RateClass_A = country.RateClass_A;
                    ct.RateClass_B = country.RateClass_B;
                    ct.RateClass_C = country.RateClass_C;
                    ct.RateClass_D = country.RateClass_D;
                    ct.RateClass_E = country.RateClass_E;
                    ct.Server = country.Server.ToMultichannelOrderManagerServer();
                    ct.TaxHandling = country.TaxHandling;
                    ct.TaxShipping = country.TaxShipping;
                    ct.Tax_ClassA = country.Tax_ClassA;
                    ct.Tax_ClassB = country.Tax_ClassB;
                    ct.Tax_ClassC = country.Tax_ClassC;
                    ct.Tax_ClassD = country.Tax_ClassD;
                    ct.Tax_ClassE = country.Tax_ClassE;
                    ct.Warehouse = country.Warehouse.ToMultichannelOrderManagerWarehouse();
                }
            }

            return ct;
        }

    }
}

