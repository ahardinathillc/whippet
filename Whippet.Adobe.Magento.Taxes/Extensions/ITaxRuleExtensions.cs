using System;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ITaxRule"/> objects.
    /// </summary>
    public static class ITaxRuleExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ITaxRule"/> object to a <see cref="TaxRule"/> object.
        /// </summary>
        /// <param name="taxRule"><see cref="ITaxRule"/> object to convert.</param>
        /// <returns><see cref="TaxRule"/> object.</returns>
        public static TaxRule ToTaxRule(this ITaxRule taxRule)
        {
            TaxRule tc = null;

            if (taxRule != null)
            {
                if (taxRule is TaxRule)
                {
                    tc = (TaxRule)(taxRule);
                }
                else
                {
                    tc = new TaxRule();
                    tc.CalculateSubtotal = taxRule.CalculateSubtotal;
                    tc.Code = taxRule.Code;
                    tc.CustomerTaxClassIDs = taxRule.CustomerTaxClassIDs;
                    tc.ID = taxRule.ID;
                    tc.Priority = taxRule.Priority;
                    tc.ProductTaxClassIDs = taxRule.ProductTaxClassIDs;
                    tc.SortOrder = taxRule.SortOrder;
                    tc.TaxRateIDs = taxRule.TaxRateIDs;
                }
            }

            return tc;
        }
    }
}

