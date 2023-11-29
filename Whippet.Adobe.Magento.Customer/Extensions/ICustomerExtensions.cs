using System;
using Athi.Whippet.Adobe.Magento.Customer.Addressing.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ICustomer"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICustomerExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ICustomer"/> object to a <see cref="Customer"/> object.
        /// </summary>
        /// <param name="cust"><see cref="ICustomer"/> object to convert.</param>
        /// <returns><see cref="Customer"/> object.</returns>
        public static Customer ToCustomer(this ICustomer cust)
        {
            Customer customer = null;

            if (cust != null)
            {
                if (cust is Customer)
                {
                    customer = (Customer)(cust);
                }
                else
                {
                    customer = new Customer(Convert.ToUInt32(cust.ID), cust.Server.ToMagentoServer(), cust.RestEndpoint.ToMagentoRestEndpoint());

                    customer.CustomAttributes = new MagentoCustomAttributeCollection(cust.CustomAttributes);
                    customer.Email = cust.Email;
                    customer.Gender = cust.Gender;
                    customer.Addresses = (cust.Addresses == null) ? null : cust.Addresses.Select(a => a.ToCustomerAddress());
                    customer.Group = cust.Group.ToCustomerGroup();
                    customer.Prefix = cust.Prefix;
                    customer.Store = cust.Store.ToStore();
                    customer.Suffix = cust.Suffix;
                    customer.Website = cust.Website.ToStoreWebsite();
                    customer.AssistanceAllowed = cust.AssistanceAllowed;
                    customer.CompanyProfile = cust.CompanyProfile;
                    customer.ConfirmationNumber = cust.ConfirmationNumber;
                    customer.CreatedArea = cust.CreatedArea;
                    customer.CreatedTimestamp = cust.CreatedTimestamp;
                    customer.DefaultBilling = cust.DefaultBilling.ToCustomerAddress();
                    customer.DefaultShipping = cust.DefaultBilling.ToCustomerAddress();
                    customer.FirstName = cust.FirstName;
                    customer.IsSubscribed = cust.IsSubscribed;
                    customer.LastName = cust.LastName;
                    customer.MiddleName = cust.MiddleName;
                    customer.UpdatedTimestamp = cust.UpdatedTimestamp;
                    customer.DateOfBirth = cust.DateOfBirth;
                    customer.VAT = cust.VAT;
                    customer.DisableAutoGroupChange = cust.DisableAutoGroupChange;
                }
            }

            return customer;
        }
    }
}
