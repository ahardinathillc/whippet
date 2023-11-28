using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ITaxRule"/> objects. This class cannot be inherited.
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
            TaxRule rule = null;

            if (taxRule is TaxRule)
            {
                rule = (TaxRule)(taxRule);
            }
            else if (taxRule != null)
            {
                rule = new TaxRule();
                rule.ID = taxRule.ID;
                rule.Code = taxRule.Code;
                rule.Position = taxRule.Position;
                rule.Priority = taxRule.Priority;
                rule.CalculateSubtotal = taxRule.CalculateSubtotal;
                rule.TaxRates = (taxRule.TaxRates == null) ? null : taxRule.TaxRates.Select(tr => tr.ToTaxRate());
                rule.CustomerTaxClasses = (taxRule.CustomerTaxClasses == null) ? null : taxRule.CustomerTaxClasses.Select(tr => tr.ToTaxClass());
                rule.ProductTaxClasses = (taxRule.ProductTaxClasses == null) ? null : taxRule.ProductTaxClasses.Select(tr => tr.ToTaxClass());
                rule.Server = taxRule.Server.ToMagentoServer();
                rule.RestEndpoint = taxRule.RestEndpoint.ToMagentoRestEndpoint();
            }

            return rule;
        }
    }
}
