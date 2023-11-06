using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="IMultichannelOrderManagerCounty"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerCountyExtensions
    {
        /// <summary>
        /// Sets the <see cref="IMultichannelOrderManagerCounty"/> to "NO_COUNTY" and assigns the specified <see cref="IMultichannelOrderManagerCountry"/> (if any). Used for countries that do not use counties, such as Canada.
        /// </summary>
        /// <param name="county"><see cref="IMultichannelOrderManagerCounty"/> object.</param>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to assign to the object.</param>
        /// <exception cref="ArgumentNullException" />
        public static void NoCounty(this IMultichannelOrderManagerCounty county, IMultichannelOrderManagerCountry country = null)
        {
            ArgumentNullException.ThrowIfNull(county);

            county.CountyId = 0;
            county.CountyCode = "000";
            county.Name = "NO_COUNTY";
            county.FIPS = "00000";

            if (country != null)
            {
                county.Country = country;
            }
        }

        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerCounty"/> object to a <see cref="MultichannelOrderManagerCounty"/> object.
        /// </summary>
        /// <param name="county"><see cref="IMultichannelOrderManagerCounty"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerServer"/> object.</returns>
        public static MultichannelOrderManagerCounty ToMultichannelOrderManagerCounty(this IMultichannelOrderManagerCounty county)
        {
            MultichannelOrderManagerCounty ct = null;

            if (county != null)
            {
                if (county is MultichannelOrderManagerCounty)
                {
                    ct = (MultichannelOrderManagerCounty)(county);
                }
                else
                {
                    ct.Code = county.Code;
                    ct.CountyCode = county.CountyCode;
                    ct.CountyId = county.CountyId;
                    ct.FIPS = county.FIPS;
                    ct.LCAP_A = county.LCAP_A;
                    ct.LCAP_B = county.LCAP_B;
                    ct.LCAP_C = county.LCAP_C;
                    ct.LCAP_D = county.LCAP_D;
                    ct.LCAP_E = county.LCAP_E;
                    ct.LookupBy = county.LookupBy;
                    ct.LookupOn = county.LookupOn;
                    ct.LTAXIT_A = county.LTAXIT_A;
                    ct.LTAXIT_B = county.LTAXIT_B;
                    ct.LTAXIT_C = county.LTAXIT_C;
                    ct.LTAXIT_D = county.LTAXIT_D;
                    ct.LTAXIT_E = county.LTAXIT_E;
                    ct.MSA = county.MSA;
                    ct.Name = county.Name;
                    ct.NCAP_A = county.NCAP_A;
                    ct.NCAP_B = county.NCAP_B;
                    ct.NCAP_C = county.NCAP_C;
                    ct.NCAP_D = county.NCAP_D;
                    ct.NCAP_E = county.NCAP_E;
                    ct.NONTAXBOX = county.NONTAXBOX;
                    ct.NTAXIT_A = county.NTAXIT_A;
                    ct.NTAXIT_B = county.NTAXIT_B;
                    ct.NTAXIT_C = county.NTAXIT_C;
                    ct.NTAXIT_D = county.NTAXIT_D;
                    ct.NTAXIT_E = county.NTAXIT_E;
                    ct.NTAXTHRES_A = county.NTAXTHRES_A;
                    ct.NTAXTHRES_B = county.NTAXTHRES_B;
                    ct.NTAXTHRES_C = county.NTAXTHRES_C;
                    ct.NTAXTHRES_D = county.NTAXTHRES_D;
                    ct.NTAXTHRES_E = county.NTAXTHRES_E;
                    ct.RateClass_A = county.RateClass_A;
                    ct.RateClass_B = county.RateClass_B;
                    ct.RateClass_C = county.RateClass_C;
                    ct.RateClass_D = county.RateClass_D;
                    ct.RateClass_E = county.RateClass_E;
                    ct.Server = county.Server.Clone<IMultichannelOrderManagerServer>().ToMultichannelOrderManagerServer();
                    ct.StateProvince = county.StateProvince.Clone<IMultichannelOrderManagerStateProvince>().ToMultichannelOrderManagerStateProvince();
                    ct.TaxHandling = county.TaxHandling;
                    ct.TaxShipping = county.TaxShipping;
                    ct.Tax_ClassA = county.Tax_ClassA;
                    ct.Tax_ClassB = county.Tax_ClassB;
                    ct.Tax_ClassC = county.Tax_ClassC;
                    ct.Tax_ClassD = county.Tax_ClassD;
                    ct.Tax_ClassE = county.Tax_ClassE;
                    ct.TimezoneOffset = county.TimezoneOffset;
                    ct.Warehouse = county.Warehouse.Clone<IMultichannelOrderManagerWarehouse>().ToMultichannelOrderManagerWarehouse();
                    ct.Updated = county.Updated;
                }
            }

            return ct;
        }

    }
}

