using System;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Inventory.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.CRM.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ICustomer"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ICustomerExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="ICustomer"/> object to a <see cref="Customer"/> object.
        /// </summary>
        /// <param name="customer"><see cref="ICustomer"/> object to convert.</param>
        /// <returns><see cref="Customer"/> object.</returns>
        public static Customer ToCustomer(this ICustomer customer)
        {
            Customer c = null;

            if (customer is Customer)
            {
                c = (Customer)(customer);
            }
            else if (customer != null)
            {
                c = new Customer(customer.ID.ToValue<int>(), customer.LastAccessed, customer.LastAccessedBy, customer.LastModified, customer.LastModifiedBy);
                c.AlternateCustomerNumber = customer.AlternateCustomerNumber;
                c.LastName = customer.LastName;
                c.FirstName = customer.FirstName;
                c.Company = customer.Company;
                c.Address = customer.Address;
                c.Phone = customer.Phone;
                c.OriginAdCampaign = customer.OriginAdCampaign;
                c.LastAdCampaign = customer.LastAdCampaign;
                c.CatCount = customer.CatCount;
                c.CustomerType = customer.CustomerType;
                c.CustomerType_1 = new CustomerType_1(customer.CustomerType_1.ID, customer.CustomerType_1.Description, Convert.ToString(customer.CustomerType_1.Code));
                c.CustomerType_2 = new CustomerType_2(customer.CustomerType_2.ID, customer.CustomerType_2.Description, customer.CustomerType_2.Code);
                c.CustomerType_3 = new CustomerType_3(customer.CustomerType_3.ID, customer.CustomerType_3.Description, customer.CustomerType_3.Code);
                c.OrderDate = customer.OrderDate;
                c.PaymentMethod = customer.PaymentMethod;
                c.CardNumber = customer.CardNumber;
                c.CardType = customer.CardType;
                c.CardExpiration = customer.CardExpiration;
                c.ShippingList = customer.ShippingList;
                c.Expired = customer.Expired;
                c.BadCheck = customer.BadCheck;
                c.OrderRecord = customer.OrderRecord;
                c.NetTotal = customer.NetTotal;
                c.GrossTotal = customer.GrossTotal;
                c.OrderFrequency = customer.OrderFrequency;
                c.Comment = customer.Comment;
                c.Balance = customer.Balance;
                c.Discount = customer.Discount;
                c.Exempt = customer.Exempt;
                c.AccountsReceivableBalance = customer.AccountsReceivableBalance;
                c.CreditLimit = customer.CreditLimit;
                c.DiscountDays = customer.DiscountDays;
                c.DueDays = customer.DueDays;
                c.DiscountPercent = customer.DiscountPercent;
                c.PromotionalBalance = customer.PromotionalBalance;
                c.OtherComment = customer.OtherComment;
                c.SalesID = customer.SalesID;
                c.NoMail = customer.NoMail;
                c.BelongNumber = customer.BelongNumber;
                c.CarrierRoute = customer.CarrierRoute;
                c.DeliveryPoint = customer.DeliveryPoint;
                c.NCOACHANGE = customer.NCOACHANGE;
                c.EntryDate = customer.EntryDate;
                c.Company_Search = customer.Company_Search;
                c.Email = customer.Email;
                c.TaxExempt = customer.TaxExempt;
                c.TaxID = customer.TaxID;
                c.CashOnly = customer.CashOnly;
                c.Salutation = customer.Salutation;
                c.Honor = customer.Honor;
                c.Title = customer.Title;
                c.NoEmail = customer.NoEmail;
                c.Password = customer.Password;
                c.RFM = customer.RFM;
                c.Points = customer.Points;
                c.NoRenting = customer.NoRenting;
                c.AddressType = customer.AddressType;
                c.WebAddress = customer.WebAddress;
                c.DateLimit = customer.DateLimit;
                c.StartDate = customer.StartDate;
                c.EndDate = customer.EndDate;
                c.StartMonth = customer.StartMonth;
                c.StartDay = customer.StartDay;
                c.EndMonth = customer.EndMonth;
                c.EndDay = customer.EndDay;
                c.ShippingAddressMatchesBillingAddress = customer.ShippingAddressMatchesBillingAddress;
                c.NoPoints = customer.NoPoints;
                c.UPSCommercialDelivery = customer.UPSCommercialDelivery;
                c.PreferredShippingMethod = customer.PreferredShippingMethod;
                c.PreferredPaymentMethod = customer.PreferredPaymentMethod;
                c.ValidatedAddressCode = customer.ValidatedAddressCode;
                c.ValidatedDate = customer.ValidatedDate;
                c.SoundsLikeName = customer.SoundsLikeName;
                c.AddressExpirationDate = customer.AddressExpirationDate;
                c.ACVMEDate = customer.ACVMEDate;
                c.AccountDate = customer.AccountDate;
                c.DiscountStartDate = customer.DiscountStartDate;
                c.DiscountEndDate = customer.DiscountEndDate;
                c.PreferredWarehouse = customer.PreferredWarehouse.ToWarehouse();
                c.BestTimeToCall = customer.BestTimeToCall;
                c.Fraud = customer.Fraud;
                c.NoCalling = customer.NoCalling;
                c.NoFax = customer.NoFax;
                c.SecondTaxID = customer.SecondTaxID;
                c.EMAILDEF = customer.EMAILDEF;
                c.EmailPreference = customer.EmailPreference;
                c.Server = customer.Server;
                c.Root = customer.Root;
                c.Stores = customer.Stores;
                c.TaxExemptions = customer.TaxExemptions;
                c.CustomerTerms = customer.CustomerTerms;
                c.AutoSupport = customer.AutoSupport;
                c.TariffExempt = customer.TariffExempt;
                c.CustomerReference = customer.CustomerReference;
            }

            return c;
        }
    }
}
