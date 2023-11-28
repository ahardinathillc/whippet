using System;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Directory.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer.Addressing.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ICustomerAddress"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICustomerAddressExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ICustomerAddress"/> object to a <see cref="CustomerAddress"/> object.
        /// </summary>
        /// <param name="address"><see cref="ICustomerAddress"/> object.</param>
        /// <returns><see cref="CustomerAddress"/> object.</returns>
        public static CustomerAddress ToCustomerAddress(this ICustomerAddress address)
        {
            CustomerAddress custAddr = null;

            if (address is CustomerAddress)
            {
                custAddr = (CustomerAddress)(address);
            }
            else if (address != null)
            {
                custAddr = new CustomerAddress();
                custAddr.ID = address.ID;
                custAddr.City = address.City;
                custAddr.RestEndpoint = address.RestEndpoint.ToMagentoRestEndpoint();
                custAddr.Company = address.Company;
                custAddr.Country = address.Country.ToCountry();
                custAddr.Fax = address.Fax;
                custAddr.Parent = address.Parent.ToCustomer();
                custAddr.Prefix = address.Prefix;
                custAddr.Region = address.Region.ToRegion();
                custAddr.Street = (address.Street == null) ? null : address.Street.Select(a => a);
                custAddr.Suffix = address.Suffix;
                custAddr.Telephone = address.Telephone;
                custAddr.CustomAttributes = (address.CustomAttributes == null) ? null : new MagentoCustomAttributeCollection(address.CustomAttributes);
                custAddr.FirstName = address.FirstName;
                custAddr.MiddleName = address.MiddleName;
                custAddr.LastName = address.LastName;
                custAddr.PostalCode = address.PostalCode;
                custAddr.IsDefaultBilling = address.IsDefaultBilling;
                custAddr.IsDefaultShipping = address.IsDefaultShipping;
                custAddr.VAT = address.VAT;
                custAddr.Server = address.Server.ToMagentoServer();
            }

            return custAddr;
        }
    }
}
