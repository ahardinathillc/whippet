using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.Store.Extensions;
using Athi.Whippet.Adobe.Magento.Taxes.Extensions;

namespace Athi.Whippet.Adobe.Magento.Customer.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ICustomerGroup"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICustomerGroupExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ICustomerGroup"/> object to a <see cref="CustomerGroup"/> object.
        /// </summary>
        /// <param name="custGroup"><see cref="ICustomerGroup"/> object to convert.</param>
        /// <returns><see cref="CustomerGroup"/> object.</returns>
        public static CustomerGroup ToCustomerGroup(this ICustomerGroup custGroup)
        {
            CustomerGroup group = null;

            if (custGroup != null)
            {
                if (custGroup is CustomerGroup)
                {
                    group = (CustomerGroup)(custGroup);
                }
                else
                {
                    group = new CustomerGroup(Convert.ToUInt32(custGroup.ID), custGroup.Server.ToMagentoServer(), custGroup.RestEndpoint.ToMagentoRestEndpoint());
                    group.ExcludedWebsites = (custGroup.ExcludedWebsites == null) ? null : custGroup.ExcludedWebsites.Select(w => w.ToStoreWebsite());
                    group.TaxClass = custGroup.TaxClass.ToTaxClass();
                    group.Code = custGroup.Code;
                }
            }

            return group;
        }
    }
}
