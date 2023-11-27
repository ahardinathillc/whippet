using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Taxes.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ITaxRateTitle"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ITaxRateTitleExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ITaxRateTitle"/> object to a <see cref="TaxRateTitle"/> object.
        /// </summary>
        /// <param name="taxTitle"><see cref="ITaxRateTitle"/> object to convert.</param>
        /// <returns><see cref="TaxRateTitle"/> object.</returns>
        public static TaxRateTitle ToTaxRateTitle(this ITaxRateTitle taxTitle)
        {
            TaxRateTitle title = null;

            if (taxTitle != null)
            {
                title = new TaxRateTitle();
                title.ID = taxTitle.ID;
                title.Store = taxTitle.Store.ToStore();
                title.Value = taxTitle.Value;
                title.Server = taxTitle.Server.ToMagentoServer();
                title.RestEndpoint = taxTitle.RestEndpoint.ToMagentoRestEndpoint();
            }

            return title;
        }
    }
}
