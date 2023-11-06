using System;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Salesforce.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesforcePriceBookEntry"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesforcePriceBookEntryExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesforcePriceBookEntry"/> object to a <see cref="SalesforcePriceBookEntry"/> object.
        /// </summary>
        /// <param name="entry"><see cref="ISalesforcePriceBookEntry"/> object to convert.</param>
        /// <returns><see cref="SalesforcePriceBookEntry"/> object.</returns>
        public static SalesforcePriceBookEntry ToSalesforcePriceBookEntry(this ISalesforcePriceBookEntry entry)
        {
            SalesforcePriceBookEntry sfPriceBookEntry = null;

            if (entry != null)
            {
                if (entry is SalesforcePriceBookEntry)
                {
                    sfPriceBookEntry = (SalesforcePriceBookEntry)(entry);
                }
                else
                {
                    sfPriceBookEntry = new SalesforcePriceBookEntry();
                    sfPriceBookEntry.ImportDataRow(entry.CreateDataRow__Internal());
                }
            }

            return sfPriceBookEntry;
        }
    }
}

