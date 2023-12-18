using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Taxes;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Inventory;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Inventory.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.CRM
{
    /// <summary>
    /// Represents a customer in Multichannel Order Manager.
    /// </summary>
    public class Customer : MultichannelOrderManagerAuditableEntity, IMultichannelOrderManagerAuditableEntity, IMultichannelOrderManagerEntity, IWhippetEntity, ICustomer, IEqualityComparer<ICustomer>
    {
        private Warehouse _warehouse;

        private CustomerType _type1;
        private CustomerType _type2;
        private CustomerType _type3;
        
        /// <summary>
        /// Gets or sets the alternate customer identification number.
        /// </summary>
        public virtual string AlternateCustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public virtual string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public virtual string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's company.
        /// </summary>
        public virtual string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's address.
        /// </summary>
        public virtual MultichannelOrderManagerObjectAddress Address
        { get; set; }

        public virtual MultichannelOrderManagerObjectPhone Phone
        { get; set; }
        
        /// <summary>
        /// Gets or sets the originating advertisement campaign that led to the customer contact creation.
        /// </summary>
        public virtual string OriginAdCampaign
        { get; set; }

        /// <summary>
        /// Gets or sets the last advertisement campaign that captured the customer contact information.
        /// </summary>
        public virtual string LastAdCampaign
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual int CatCount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the customer type.
        /// </summary>
        public virtual string CustomerType
        { get; set; }

        /// <summary>
        /// Gets or sets the first customer categorization type.
        /// </summary>
        public virtual CustomerType CustomerType_1
        {
            get
            {
                if (_type1 == null)
                {
                    _type1 = new CustomerType();
                }

                _type1.CodeLength = 1;
                
                return _type1;
            }
            set
            {
                _type1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the second customer categorization type.
        /// </summary>
        public virtual CustomerType CustomerType_2
        {
            get
            {
                if (_type2 == null)
                {
                    _type2 = new CustomerType();
                }

                _type2.CodeLength = 2;
                
                return _type2;
            }
            set
            {
                _type2 = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the third customer categorization type.
        /// </summary>
        public virtual CustomerType CustomerType_3
        {
            get
            {
                if (_type3 == null)
                {
                    _type3 = new CustomerType();
                }

                _type3.CodeLength = 4;
                
                return _type3;
            }
            set
            {
                _type3 = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the date/time of the last order (if any).
        /// </summary>
        public virtual Instant? OrderDate
        { get; set; }

        /// <summary>
        /// Specifies the default payment method used by the customer.
        /// </summary>
        public virtual string PaymentMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card number that serves as the default payment method.
        /// </summary>
        public virtual string CardNumber
        { get; set; }

        /// <summary>
        /// Specifies the credit card type that serves as the default payment method.
        /// </summary>
        public virtual string CardType
        { get; set; }

        /// <summary>
        /// Specifies the credit card expiration date.
        /// </summary>
        public virtual string CardExpiration
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping list name.
        /// </summary>
        public virtual string ShippingList
        { get; set; }

        /// <summary>
        /// Indicates whether the payment method is expired.
        /// </summary>
        public virtual bool Expired
        { get; set; }

        /// <summary>
        /// Indicates whether the customer has ever presented a bad check.
        /// </summary>
        public virtual bool BadCheck
        { get; set; }

        /// <summary>
        /// Gets or sets the order record number.
        /// </summary>
        public virtual long OrderRecord
        { get; set; }

        /// <summary>
        /// Gets or sets the net total of sales for the customer.
        /// </summary>
        public virtual decimal NetTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the gross total of sales for the customer.
        /// </summary>
        public virtual decimal GrossTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the order frequency of the customer.
        /// </summary>
        public virtual int OrderFrequency
        { get; set; }

        /// <summary>
        /// Specifies a comment entry for the customer.
        /// </summary>
        public virtual string Comment
        { get; set; }

        /// <summary>
        /// Gets or sets the current customer's balance.
        /// </summary>
        public virtual decimal Balance
        { get; set; }

        /// <summary>
        /// Gets or sets the current discount to apply to the customer.
        /// </summary>
        public virtual decimal Discount
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is tax-exempt.
        /// </summary>
        public virtual bool Exempt
        { get; set; }

        /// <summary>
        /// Specifies the customer's accounts receivable (A/R) balance.
        /// </summary>
        public virtual decimal AccountsReceivableBalance
        { get; set; }

        /// <summary>
        /// Specifies the customer's credit limit.
        /// </summary>
        public virtual decimal CreditLimit
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of days the discount is valid for.
        /// </summary>
        public virtual int DiscountDays
        { get; set; }

        /// <summary>
        /// Gets or sets the number of days payment of the invoice is due.
        /// </summary>
        public virtual int DueDays
        { get; set; }

        /// <summary>
        /// Gets or sets the discount percentage to apply to the customer's invoice.
        /// </summary>
        public virtual decimal DiscountPercent
        { get; set; }

        /// <summary>
        /// Specifies the customer's balance for a promotional invoice.
        /// </summary>
        public virtual decimal PromotionalBalance
        { get; set; }

        /// <summary>
        /// Second comment line to apply to the customer.
        /// </summary>
        public virtual string OtherComment
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the assigned sales account manager.
        /// </summary>
        public virtual string SalesID
        { get; set; }

        /// <summary>
        /// Indicates whether the customer declines receiving postal mail advertisements.
        /// </summary>
        public virtual bool NoMail
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual int BelongNumber
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual string CarrierRoute
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual string DeliveryPoint
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual char NCOACHANGE
        { get; set; }

        /// <summary>
        /// Specifies the date/time the customer account was created.
        /// </summary>
        public virtual Instant? EntryDate
        { get; set; }

        /// <summary>
        /// Specifies the company search term for the customer.
        /// </summary>
        public virtual string Company_Search
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's e-mail address.
        /// </summary>
        public virtual string Email
        { get; set; }

        /// <summary>
        /// Specifies whether the customer is tax-exempt.
        /// </summary>
        public virtual bool TaxExempt
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's tax ID.
        /// </summary>
        public virtual string TaxID
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is limited to cash-only transactions.
        /// </summary>
        public virtual bool CashOnly
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's salutation.
        /// </summary>
        public virtual string Salutation
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's honorable title.
        /// </summary>
        public virtual string Honor
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's title.
        /// </summary>
        public virtual string Title
        { get; set; }

        /// <summary>
        /// Indicates whether the customer declines e-mail advertisement communication.
        /// </summary>
        public virtual bool NoEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's password.
        /// </summary>
        public virtual string Password
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual int RFM
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual int Points
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is allowed to rent products.
        /// </summary>
        public virtual bool NoRenting
        { get; set; }

        /// <summary>
        /// Specifies the customer's address type.
        /// </summary>
        public virtual char AddressType
        { get; set; }

        /// <summary>
        /// Specifies the customer's web address URL.
        /// </summary>
        public virtual string WebAddress
        { get; set; }

        /// <summary>
        /// Specifies the date limit type for the customer.
        /// </summary>
        public virtual char DateLimit
        { get; set; }

        /// <summary>
        /// Gets the starting date for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        public virtual Instant? StartDate
        { get; set; }

        /// <summary>
        /// Gets the ending date for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        public virtual Instant? EndDate
        { get; set; }

        /// <summary>
        /// Gets the starting month for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        public virtual int StartMonth
        { get; set; }

        /// <summary>
        /// Gets the starting day for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        public virtual int StartDay
        { get; set; }

        /// <summary>
        /// Gets the ending month for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        public virtual int EndMonth
        { get; set; }

        /// <summary>
        /// Gets the ending day for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        public virtual int EndDay
        { get; set; }

        /// <summary>
        /// Indicates whether the shipping address is the same as the billing address.
        /// </summary>
        public virtual bool ShippingAddressMatchesBillingAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the last user to access the customer's record.
        /// </summary>
        public virtual string LastUser
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool NoPoints
        { get; set; }

        /// <summary>
        /// Indicates whether the shipping address is classified as a UPS commercial delivery point.
        /// </summary>
        public virtual bool UPSCommercialDelivery
        { get; set; }

        /// <summary>
        /// Specifies the customer's preferred shipping method.
        /// </summary>
        public virtual string PreferredShippingMethod
        { get; set; }

        /// <summary>
        /// Specifies the customer's preferred payment method.
        /// </summary>
        public virtual string PreferredPaymentMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the validated address code.
        /// </summary>
        public virtual string ValidatedAddressCode
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer information was validated.
        /// </summary>
        public virtual Instant? ValidatedDate
        { get; set; }

        /// <summary>
        /// Specifies a name that sounds like the customer's name. 
        /// </summary>
        public virtual string SoundsLikeName
        { get; set; }

        /// <summary>
        /// Specifies the date the customer's address expires.
        /// </summary>
        public virtual Instant? AddressExpirationDate
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual Instant? ACVMEDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer account was opened.
        /// </summary>
        public virtual Instant? AccountDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time discounts are applied to the customer's account.
        /// </summary>
        public virtual Instant? DiscountStartDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time discounts are no longer applied to the customer's account.
        /// </summary>
        public virtual Instant? DiscountEndDate
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's preferred warehouse.
        /// </summary>
        public virtual Warehouse PreferredWarehouse
        {
            get
            {
                if (_warehouse == null)
                {
                    _warehouse = new Warehouse();
                }

                return _warehouse;
            }
            set
            {
                _warehouse = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's preferred warehouse.
        /// </summary>
        IWarehouse ICustomer.PreferredWarehouse
        {
            get
            {
                return PreferredWarehouse;
            }
            set
            {
                PreferredWarehouse = value.ToWarehouse();
            }
        }
        
        /// <summary>
        /// Gets or sets the best time to call the customer.
        /// </summary>
        public virtual string BestTimeToCall
        { get; set; }

        /// <summary>
        /// Indicates whether the customer has been marked as a fraudulent account.
        /// </summary>
        public virtual bool Fraud
        { get; set; }

        /// <summary>
        /// Indicates whether the customer does not wish to receive phone solicitation.
        /// </summary>
        public virtual bool NoCalling
        { get; set; }

        /// <summary>
        /// Indicates whether the customer does not wish to receive facsimile solicitation.
        /// </summary>
        public virtual bool NoFax
        { get; set; }

        /// <summary>
        /// Gets or sets the secondary tax ID code for the customer.
        /// </summary>
        public virtual string SecondTaxID
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual string EMAILDEF
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual string EmailPreference
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual string Server
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual string Root
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual string Stores
        { get; set; }

        /// <summary>
        /// Specifies the customer's tax exempt status.
        /// </summary>
        public virtual MultichannelOrderManagerTaxExemptCategory TaxExemptions
        { get; set; }
        
        /// <summary>
        /// Specifies whether the customer has an account service agreement.
        /// </summary>
        public virtual bool CustomerTerms
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool AutoSupport
        { get; set; }

        /// <summary>
        /// Specifies whether the customer is exempt for tariffs.
        /// </summary>
        public virtual bool TariffExempt
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual int CustomerReference
        { get; set; }
    }
}
