using System;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ICustomerAddress"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICustomerAddressExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ICustomerAddress"/> object to a <see cref="CustomerAddress"/> object.
        /// </summary>
        /// <param name="custAddr"><see cref="ICustomerAddress"/> object to convert.</param>
        /// <returns><see cref="CustomerAddress"/> object.</returns>
        public static CustomerAddress ToCustomerAddress(this ICustomerAddress custAddr)
        {
            CustomerAddress address = null;

            if (custAddr != null)
            {
                if (custAddr is CustomerAddress)
                {
                    address = (CustomerAddress)(custAddr);
                }
                else
                {
                    address = new CustomerAddress();
                    address.Active = custAddr.Active;
                    address.City = custAddr.City;
                    address.Company = custAddr.Company;
                    address.CountryID = custAddr.CountryID;
                    address.CreatedAt = custAddr.CreatedAt;
                    address.Customer = custAddr.Customer.ToCustomer();
                    address.EntityID = custAddr.EntityID;
                    address.Fax = custAddr.Fax;
                    address.FirstName = custAddr.FirstName;
                    address.IncrementID = custAddr.IncrementID;
                    address.LastName = custAddr.LastName;
                    address.MiddleName = custAddr.MiddleName;
                    address.PostalCode = custAddr.PostalCode;
                    address.Prefix = custAddr.Prefix;
                    address.Region = custAddr.Region;
                    address.RegionID = custAddr.RegionID;
                    address.Server = custAddr.Server.ToMagentoServer();
                    address.Street = custAddr.Street;
                    address.Suffix = custAddr.Suffix;
                    address.Telephone = custAddr.Telephone;
                    address.UpdatedAt = custAddr.UpdatedAt;
                    address.ValueAddedTaxID = custAddr.ValueAddedTaxID;
                    address.ValueAddedTaxRequestDate = custAddr.ValueAddedTaxRequestDate;
                    address.ValueAddedTaxRequestID = custAddr.ValueAddedTaxRequestID;
                    address.ValueAddedTaxRequestSuccess = custAddr.ValueAddedTaxRequestSuccess;
                    address.ValueAddedTaxValid = custAddr.ValueAddedTaxValid;
                }
            }

            return address;
        }
    }
}

