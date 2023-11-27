using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ITaxRate"/> objects. This class cannot be inherited.
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
            TaxRate rate = null;

            if (taxRate != null)
            {
                rate = new TaxRate();
                rate.ID = taxRate.ID;
                rate.Server = taxRate.Server.ToMagentoServer();
                rate.RestEndpoint = taxRate.RestEndpoint.ToMagentoRestEndpoint();
                rate.Rate = taxRate.Rate;
                rate.Code = taxRate.Code;
                rate.Country = taxRate.Country.ToCountry();
                rate.Region = taxRate.Region.ToRegion();
                rate.Titles = (taxRate.Titles == null) ? null : taxRate.Titles.Select(t => t.ToTaxRateTitle());
                rate.PostalCode = taxRate.PostalCode;
                rate.PostalCodeIsRange = taxRate.PostalCodeIsRange;
                rate.PostalCodeLowerBound = taxRate.PostalCodeLowerBound;
                rate.PostalCodeUpperBound = taxRate.PostalCodeUpperBound;
            }

            return rate;
        }
    }
}
