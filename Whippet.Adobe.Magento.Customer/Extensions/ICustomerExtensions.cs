using System;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;

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
                    customer = new Customer();
                    customer.Active = cust.Active;
                    customer.Confirmation = cust.Confirmation;
                    customer.CreatedAt = cust.CreatedAt;
                    customer.CreatedIn = cust.CreatedIn;
                    customer.DateOfBirth = cust.DateOfBirth;
                    customer.DefaultBillingAddress = cust.DefaultBillingAddress.ToCustomerAddress();
                    customer.DefaultShippingAddress = cust.DefaultShippingAddress.ToCustomerAddress();
                    customer.DisableAutoGroupChange = cust.DisableAutoGroupChange;
                    customer.Email = cust.Email;
                    customer.EntityID = cust.EntityID;
                    customer.FailedLoginAttempts = cust.FailedLoginAttempts;
                    customer.FirstFailedLoginAttempt = cust.FirstFailedLoginAttempt;
                    customer.FirstName = cust.FirstName;
                    customer.Gender = cust.Gender;
                    customer.Group = cust.Group.ToCustomerGroup();
                    customer.IncrementID = cust.IncrementID;
                    customer.LastName = cust.LastName;
                    customer.LegacyCustomerNumber = cust.LegacyCustomerNumber;
                    customer.LockExpiration = cust.LockExpiration;
                    customer.MiddleName = cust.MiddleName;
                    customer.PasswordHash = cust.PasswordHash;
                    customer.Prefix = cust.Prefix;
                    customer.ResetPasswordToken = cust.ResetPasswordToken;
                    customer.ResetPasswordTokenCreated = cust.ResetPasswordTokenCreated;
                    customer.Server = cust.Server.ToMagentoServer();
                    customer.SessionCutoff = cust.SessionCutoff;
                    customer.Store = cust.Store.ToStore();
                    customer.Suffix = cust.Suffix;
                    customer.UpdatedAt = cust.UpdatedAt;
                    customer.ValueAddedTax = cust.ValueAddedTax;
                    customer.Website = cust.Website.ToStoreWebsite();
                }
            }

            return customer;
        }
    }
}

