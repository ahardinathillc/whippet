using System;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ITaxRateTitle"/> objects.
    /// </summary>
    public static class ITaxRateTitleExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ITaxRateTitle"/> object to a <see cref="TaxRateTitle"/> object.
        /// </summary>
        /// <param name="taxRateTitle"><see cref="ITaxRateTitle"/> object to convert.</param>
        /// <returns><see cref="TaxRateTitle"/> object.</returns>
        public static TaxRateTitle ToTaxRateTitle(this ITaxRateTitle taxRateTitle)
        {
            TaxRateTitle tc = null;

            if (taxRateTitle != null)
            {
                if (taxRateTitle is TaxRateTitle)
                {
                    tc = (TaxRateTitle)(taxRateTitle);
                }
                else
                {
                    tc = new TaxRateTitle();
                    tc.ID = taxRateTitle.ID;
                    tc.Rate = taxRateTitle.Rate.ToTaxRate();
                    tc.Server = taxRateTitle.Server.ToMagentoServer();
                    tc.Store = taxRateTitle.Store.ToStore();
                    tc.Value = taxRateTitle.Value;
                }
            }

            return tc;
        }
    }
}

