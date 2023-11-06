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
    /// Provides extension methods to <see cref="IMultichannelOrderManagerPostalCode"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerPostalCodeExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerPostalCode"/> object to a <see cref="MultichannelOrderManagerPostalCode"/> object.
        /// </summary>
        /// <param name="postalCode"><see cref="IMultichannelOrderManagerPostalCode"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerServer"/> object.</returns>
        public static MultichannelOrderManagerPostalCode ToMultichannelOrderManagerPostalCode(this IMultichannelOrderManagerPostalCode postalCode)
        {
            MultichannelOrderManagerPostalCode pc = null;

            if (postalCode != null)
            {
                if (postalCode is MultichannelOrderManagerPostalCode)
                {
                    pc = (MultichannelOrderManagerPostalCode)(postalCode);
                }
                else
                {
                    pc.City = postalCode.City;
                    pc.Code1 = postalCode.Code1;
                    pc.Country = postalCode.Country.Clone<IMultichannelOrderManagerCountry>().ToMultichannelOrderManagerCountry();
                    pc.County = postalCode.County.Clone<IMultichannelOrderManagerCounty>().ToMultichannelOrderManagerCounty();
                    pc.DoNotTaxExceedAmountTaxClass_A = postalCode.DoNotTaxExceedAmountTaxClass_A;
                    pc.DoNotTaxExceedAmountTaxClass_B = postalCode.DoNotTaxExceedAmountTaxClass_B;
                    pc.DoNotTaxExceedAmountTaxClass_C = postalCode.DoNotTaxExceedAmountTaxClass_C;
                    pc.DoNotTaxExceedAmountTaxClass_D = postalCode.DoNotTaxExceedAmountTaxClass_D;
                    pc.DoNotTaxExceedAmountTaxClass_E = postalCode.DoNotTaxExceedAmountTaxClass_E;
                    pc.DoNotTaxShippingOnBoxesWithAllNonTaxableItems = postalCode.DoNotTaxShippingOnBoxesWithAllNonTaxableItems;
                    pc.ExceedAmountTaxClass_A = postalCode.ExceedAmountTaxClass_A;
                    pc.ExceedAmountTaxClass_B = postalCode.ExceedAmountTaxClass_B;
                    pc.ExceedAmountTaxClass_C = postalCode.ExceedAmountTaxClass_C;
                    pc.ExceedAmountTaxClass_D = postalCode.ExceedAmountTaxClass_D;
                    pc.ExceedAmountTaxClass_E = postalCode.ExceedAmountTaxClass_E;
                    pc.FlagCapTaxClass_A = postalCode.FlagCapTaxClass_A;
                    pc.FlagCapTaxClass_B = postalCode.FlagCapTaxClass_B;
                    pc.FlagCapTaxClass_C = postalCode.FlagCapTaxClass_C;
                    pc.FlagCapTaxClass_D = postalCode.FlagCapTaxClass_D;
                    pc.FlagCapTaxClass_E = postalCode.FlagCapTaxClass_E;
                    pc.Logic1 = postalCode.Logic1;
                    pc.ID = postalCode.ID;
                    pc.LookupBy = postalCode.LookupBy;
                    pc.LookupOn = postalCode.LookupOn;
                    pc.PostalCode = postalCode.PostalCode;
                    pc.Presence = postalCode.Presence;
                    pc.RateClass_A = postalCode.RateClass_A;
                    pc.RateClass_B = postalCode.RateClass_B;
                    pc.RateClass_C = postalCode.RateClass_C;
                    pc.RateClass_D = postalCode.RateClass_D;
                    pc.RateClass_E = postalCode.RateClass_E;
                    pc.RTDTax = postalCode.RTDTax;
                    pc.Server = postalCode.Server.Clone<IMultichannelOrderManagerServer>().ToMultichannelOrderManagerServer();
                    pc.StateProvince = postalCode.StateProvince.Clone<IMultichannelOrderManagerStateProvince>().ToMultichannelOrderManagerStateProvince();
                    pc.TaxClass_A = postalCode.TaxClass_A;
                    pc.TaxClass_B = postalCode.TaxClass_B;
                    pc.TaxClass_C = postalCode.TaxClass_C;
                    pc.TaxClass_D = postalCode.TaxClass_D;
                    pc.TaxClass_E = postalCode.TaxClass_E;
                    pc.TaxHandlingFeesPostalCodeTaxRateOnly = postalCode.TaxHandlingFeesPostalCodeTaxRateOnly;
                    pc.TaxRate = postalCode.TaxRate;
                    pc.TaxShipping = postalCode.TaxShipping;
                    pc.TaxUpdate = postalCode.TaxUpdate;
                    pc.TotalCapTaxClass_A = postalCode.TotalCapTaxClass_A;
                    pc.TotalCapTaxClass_B = postalCode.TotalCapTaxClass_B;
                    pc.TotalCapTaxClass_C = postalCode.TotalCapTaxClass_C;
                    pc.TotalCapTaxClass_D = postalCode.TotalCapTaxClass_D;
                    pc.TotalCapTaxClass_E = postalCode.TotalCapTaxClass_E;
                    pc.Type = postalCode.Type;
                    pc.Warehouse = postalCode.Warehouse.Clone<IMultichannelOrderManagerWarehouse>().ToMultichannelOrderManagerWarehouse();
                }
            }

            return pc;
        }

    }
}

