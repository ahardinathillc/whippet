using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ISalesOrderAddress"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ISalesOrderAddressExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ISalesOrderAddress"/> object to a <see cref="SalesOrderAddress"/> object.
        /// </summary>
        /// <param name="salesOrder"><see cref="ISalesOrderAddress"/> object to convert.</param>
        /// <returns><see cref="SalesOrderAddress"/> object.</returns>
        public static SalesOrderAddress ToSalesOrderAddress(this ISalesOrderAddress salesOrder)
        {
            SalesOrderAddress sa = null;

            if (salesOrder != null)
            {
                if (salesOrder is SalesOrderAddress)
                {
                    sa = (SalesOrderAddress)(salesOrder);
                }
                else
                {
                    sa = new SalesOrderAddress();
                    sa.AddressType = salesOrder.AddressType;
                    sa.City = salesOrder.City;
                    sa.Company = salesOrder.Company;
                    sa.CountryID = salesOrder.CountryID;
                    sa.Customer = salesOrder.Customer.ToCustomer();
                    sa.CustomerAddress = salesOrder.CustomerAddress.ToCustomerAddress();
                    sa.Email = salesOrder.Email;
                    sa.EntityID = salesOrder.EntityID;
                    sa.Fax = salesOrder.Fax;
                    sa.FirstName = salesOrder.FirstName;
                    sa.GiftRegistryItemID = salesOrder.GiftRegistryItemID;
                    sa.LastName = salesOrder.LastName;
                    sa.MiddleName = salesOrder.MiddleName;
                    sa.Order = salesOrder.Order.ToSalesOrder();
                    sa.PostalCode = salesOrder.PostalCode;
                    sa.Prefix = salesOrder.Prefix;
                    sa.QuoteAddress = salesOrder.QuoteAddress.ToQuoteAddress();
                    sa.Region = salesOrder.Region;
                    sa.RegionID = salesOrder.RegionID;
                    sa.Server = salesOrder.Server.ToMagentoServer();
                    sa.Street = salesOrder.Street;
                    sa.Suffix = salesOrder.Suffix;
                    sa.Telephone = salesOrder.Telephone;
                    sa.ValidatedValueAddedTaxNumber = salesOrder.ValidatedValueAddedTaxNumber;
                    sa.ValueAddedTaxID = salesOrder.ValueAddedTaxID;
                    sa.ValueAddedTaxIsValid = salesOrder.ValueAddedTaxIsValid;
                    sa.ValueAddedTaxRequestDate = salesOrder.ValueAddedTaxRequestDate;
                    sa.ValueAddedTaxRequestID = salesOrder.ValueAddedTaxRequestID;
                    sa.ValueAddedTaxRequestSuccess = salesOrder.ValueAddedTaxRequestSuccess;
                }
            }

            return sa;
        }
    }
}