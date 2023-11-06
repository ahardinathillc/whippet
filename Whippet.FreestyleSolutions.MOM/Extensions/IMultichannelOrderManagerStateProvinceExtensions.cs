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
    /// Provides extension methods to <see cref="IMultichannelOrderManagerStateProvince"/> objects. This class cannot be inherited.
    /// </summary>
    public static class IMultichannelOrderManagerStateProvinceExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="IMultichannelOrderManagerStateProvince"/> object to a <see cref="MultichannelOrderManagerStateProvince"/> object.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> object to convert.</param>
        /// <returns><see cref="MultichannelOrderManagerServer"/> object.</returns>
        public static MultichannelOrderManagerStateProvince ToMultichannelOrderManagerStateProvince(this IMultichannelOrderManagerStateProvince stateProvince)
        {
            MultichannelOrderManagerStateProvince sp = null;

            if (stateProvince != null)
            {
                if (stateProvince is MultichannelOrderManagerStateProvince)
                {
                    sp = (MultichannelOrderManagerStateProvince)(stateProvince);
                }
                else
                {
                    sp.Abbreviation = stateProvince.Abbreviation;
                    sp.Country = stateProvince.Country.Clone<IMultichannelOrderManagerCountry>().ToMultichannelOrderManagerCountry();
                    sp.DoNotTaxExceedAmountTaxClass_A = stateProvince.DoNotTaxExceedAmountTaxClass_A;
                    sp.DoNotTaxExceedAmountTaxClass_B = stateProvince.DoNotTaxExceedAmountTaxClass_B;
                    sp.DoNotTaxExceedAmountTaxClass_C = stateProvince.DoNotTaxExceedAmountTaxClass_C;
                    sp.DoNotTaxExceedAmountTaxClass_D = stateProvince.DoNotTaxExceedAmountTaxClass_D;
                    sp.DoNotTaxExceedAmountTaxClass_E = stateProvince.DoNotTaxExceedAmountTaxClass_E;
                    sp.DoNotTaxShippingOnBoxesWithAllNonTaxableItems = stateProvince.DoNotTaxShippingOnBoxesWithAllNonTaxableItems;
                    sp.ExceedAmountTaxClass_A = stateProvince.ExceedAmountTaxClass_A;
                    sp.ExceedAmountTaxClass_B = stateProvince.ExceedAmountTaxClass_B;
                    sp.ExceedAmountTaxClass_C = stateProvince.ExceedAmountTaxClass_C;
                    sp.ExceedAmountTaxClass_D = stateProvince.ExceedAmountTaxClass_D;
                    sp.ExceedAmountTaxClass_E = stateProvince.ExceedAmountTaxClass_E;
                    sp.FinanceChargesRate = stateProvince.FinanceChargesRate;
                    sp.FlagCapTaxClass_A = stateProvince.FlagCapTaxClass_A;
                    sp.FlagCapTaxClass_B = stateProvince.FlagCapTaxClass_B;
                    sp.FlagCapTaxClass_C = stateProvince.FlagCapTaxClass_C;
                    sp.FlagCapTaxClass_D = stateProvince.FlagCapTaxClass_D;
                    sp.FlagCapTaxClass_E = stateProvince.FlagCapTaxClass_E;
                    sp.High = stateProvince.High;
                    sp.ID = stateProvince.ID;
                    sp.LookupBy = stateProvince.LookupBy;
                    sp.LookupOn = stateProvince.LookupOn;
                    sp.Low = stateProvince.Low;
                    sp.Name = stateProvince.Name;
                    sp.Presence = stateProvince.Presence;
                    sp.RateClass_A = stateProvince.RateClass_A;
                    sp.RateClass_B = stateProvince.RateClass_B;
                    sp.RateClass_C = stateProvince.RateClass_C;
                    sp.RateClass_D = stateProvince.RateClass_D;
                    sp.RateClass_E = stateProvince.RateClass_E;
                    sp.Server = stateProvince.Server.Clone<IMultichannelOrderManagerServer>().ToMultichannelOrderManagerServer();
                    sp.TaxClass_A = stateProvince.TaxClass_A;
                    sp.TaxClass_B = stateProvince.TaxClass_B;
                    sp.TaxClass_C = stateProvince.TaxClass_C;
                    sp.TaxClass_D = stateProvince.TaxClass_D;
                    sp.TaxClass_E = stateProvince.TaxClass_E;
                    sp.TaxHandlingFeesNationalTaxRateOnly = stateProvince.TaxHandlingFeesNationalTaxRateOnly;
                    sp.TaxRate = stateProvince.TaxRate;
                    sp.TaxShipping = stateProvince.TaxShipping;
                    sp.TaxUpdate = stateProvince.TaxUpdate;
                    sp.TotalCapTaxClass_A = stateProvince.TotalCapTaxClass_A;
                    sp.TotalCapTaxClass_B = stateProvince.TotalCapTaxClass_B;
                    sp.TotalCapTaxClass_C = stateProvince.TotalCapTaxClass_C;
                    sp.TotalCapTaxClass_D = stateProvince.TotalCapTaxClass_D;
                    sp.TotalCapTaxClass_E = stateProvince.TotalCapTaxClass_E;
                    sp.Warehouse = stateProvince.Warehouse.Clone<IMultichannelOrderManagerWarehouse>().ToMultichannelOrderManagerWarehouse();
                }
            }

            return sp;
        }

    }
}

