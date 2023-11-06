using System;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ITaxRate"/> objects.
    /// </summary>
    public static class ITaxRateExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ITaxRate"/> object to a <see cref="TaxRate"/> object.
        /// </summary>
        /// <param name="taxRate"><see cref="ITaxRate"/> object to convert.</param>
        /// <returns><see cref="TaxRate"/> object.</returns>
        public static TaxRate ToTaxRate(this ITaxRate taxRate)
        {
            TaxRate tc = null;

            if (taxRate != null)
            {
                if (taxRate is TaxRate)
                {
                    tc = (TaxRate)(taxRate);
                }
                else
                {
                    tc = new TaxRate();
                    tc.ID = taxRate.ID;
                    tc.Code = taxRate.Code;
                    tc.Country = taxRate.Country.ToCountry();
                    tc.PostalCode = taxRate.PostalCode;
                    tc.Rate = taxRate.Rate;
                    tc.Region = taxRate.Region.ToRegion();
                    tc.Server = taxRate.Server.ToMagentoServer();
                    tc.ZipFrom = taxRate.ZipFrom;
                    tc.ZipTo = taxRate.ZipTo;
                }
            }

            return tc;
        }
    }
}

