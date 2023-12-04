using System;
using Athi.Whippet.Adobe.Magento.Customer.Addressing.Extensions;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales.Addressing.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesOrderAddress"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesOrderAddressExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesOrderAddress"/> object to a <see cref="SalesOrderAddress"/> object.
        /// </summary>
        /// <param name="addr"><see cref="ISalesOrderAddress"/> object.</param>
        /// <returns><see cref="SalesOrderAddress"/> object.</returns>
        public static SalesOrderAddress ToSalesOrderAddress(this ISalesOrderAddress addr)
        {
            SalesOrderAddress sa = null;

            if (addr is SalesOrderAddress)
            {
                sa = (SalesOrderAddress)(addr);
            }
            else if (addr != null)
            {
                sa = new SalesOrderAddress();
                sa.Parent = addr.Parent.ToSalesOrder();
                sa.Email = addr.Email;
                sa.CustomerAddress = addr.CustomerAddress.ToCustomerAddress();
                sa.Region = addr.Region.ToRegion();
                sa.Country = addr.Country.ToCountry();
                sa.Street = (addr.Street == null) ? null : addr.Street.Select(s => s);
                sa.Company = addr.Company;
                sa.Telephone = addr.Telephone;
                sa.Fax = addr.Fax;
                sa.PostalCode = addr.PostalCode;
                sa.City = addr.City;
                sa.FirstName = addr.FirstName;
                sa.LastName = addr.LastName;
                sa.MiddleName = addr.MiddleName;
                sa.Prefix = addr.Prefix;
                sa.Suffix = addr.Suffix;
                sa.VAT = addr.VAT;
                sa.ValueAddedTaxIsValid = addr.ValueAddedTaxIsValid;
                sa.ValueAddedTaxRequestDate = addr.ValueAddedTaxRequestDate;
                sa.ValueAddedTaxRequestID = addr.ValueAddedTaxRequestID;
                sa.ValueAddedTaxSuccessfullyRequested = addr.ValueAddedTaxSuccessfullyRequested;
            }

            return sa;
        }
    }
}
