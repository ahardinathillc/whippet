using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforcePriceBook"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforcePriceBookExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesforcePriceBook"/> object to a <see cref="SalesforcePriceBook"/> object.
        /// </summary>
        /// <param name="priceBook"><see cref="ISalesforcePriceBook"/> object to convert.</param>
        /// <returns><see cref="SalesforcePriceBook"/> object.</returns>
        public static SalesforcePriceBook ToSalesforcePriceBook(this ISalesforcePriceBook priceBook)
        {
            SalesforcePriceBook sfPriceBook = null;

            if (priceBook != null)
            {
                if (priceBook is SalesforcePriceBook)
                {
                    sfPriceBook = (SalesforcePriceBook)(priceBook);
                }
                else
                {
                    sfPriceBook = new SalesforcePriceBook();
                    sfPriceBook.ImportDataRow(priceBook.CreateDataRow__Internal());
                }
            }

            return sfPriceBook;
        }
    }
}

