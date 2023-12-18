using System;
using System.Text;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Extensions.Text;
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

        private CustomerType_1 _type1;
        private CustomerType_2 _type2;
        private CustomerType_3 _type3;
        
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        public new virtual MultichannelOrderManagerEntityKey<int> ID
        {
            get
            {
                return base.ID.ToValue<int>();
            }
            set
            {
                base.ID = value;
            }
        }

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
        public virtual CustomerType_1 CustomerType_1
        {
            get
            {
                if (_type1 == null)
                {
                    _type1 = new CustomerType_1();
                }

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
        public virtual CustomerType_2 CustomerType_2
        {
            get
            {
                if (_type2 == null)
                {
                    _type2 = new CustomerType_2();
                }

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
        public virtual CustomerType_3 CustomerType_3
        {
            get
            {
                if (_type3 == null)
                {
                    _type3 = new CustomerType_3();
                }

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
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with no arguments.
        /// </summary>
        public Customer()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique identifier of the entity.</param>
        /// <param name="lastAccessed">Date and time the entity was last accessed.</param>
        /// <param name="lastAccessedBy">Username who last accessed the entity.</param>
        public Customer(int id, Instant? lastAccessed = null, string lastAccessedBy = null)
            : base(new MultichannelOrderManagerEntityKey<int>(id), lastAccessed, lastAccessedBy)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with the specified ID.
        /// </summary>
        /// <param name="id">Unique identifier of the entity.</param>
        /// <param name="lastAccessed">Date and time the entity was last accessed.</param>
        /// <param name="lastAccessedBy">Username who last accessed the entity.</param>
        /// <param name="lastModified">Date and time the entity was last modified.</param>
        /// <param name="lastModifiedBy">Username who last modified the entity.</param>
        public Customer(int id, Instant? lastAccessed, string lastAccessedBy, Instant? lastModified, string lastModifiedBy)
            : base(new MultichannelOrderManagerEntityKey<int>(id), lastAccessed, lastAccessedBy, lastModified, lastModifiedBy)
        { }
        
        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ICustomer);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomer obj)
        {
            return (obj != null) && Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ICustomer x, ICustomer y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null) && base.Equals(x, y))
            {
                equals =
                    String.Equals(x.AlternateCustomerNumber?.Trim(), y.AlternateCustomerNumber?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.LastName?.Trim(), y.LastName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.FirstName?.Trim(), y.FirstName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Company?.Trim(), y.Company?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.Address.Equals(y.Address)
                    && x.Phone.Equals(y.Phone)
                    && String.Equals(x.OriginAdCampaign?.Trim(), y.OriginAdCampaign?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.LastAdCampaign?.Trim(), y.LastAdCampaign?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.CatCount == y.CatCount
                    && String.Equals(x.CustomerType?.Trim(), y.CustomerType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && (((x.CustomerType_1 == null) && (y.CustomerType_1 == null)) || ((x.CustomerType_1 != null) && x.CustomerType_1.Equals(y.CustomerType_1)))
                    && (((x.CustomerType_2 == null) && (y.CustomerType_2 == null)) || ((x.CustomerType_2 != null) && x.CustomerType_2.Equals(y.CustomerType_2)))
                    && (((x.CustomerType_3 == null) && (y.CustomerType_3 == null)) || ((x.CustomerType_3 != null) && x.CustomerType_3.Equals(y.CustomerType_3)))
                    && x.OrderDate.GetValueOrDefault().Equals(y.OrderDate.GetValueOrDefault())
                    && String.Equals(x.PaymentMethod?.Trim(), y.PaymentMethod?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CardNumber?.Trim(), y.CardNumber?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CardType?.Trim(), y.CardType?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CardExpiration?.Trim(), y.CardExpiration?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ShippingList?.Trim(), y.ShippingList?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.Expired == y.Expired
                    && x.BadCheck == y.BadCheck
                    && x.OrderRecord == y.OrderRecord
                    && x.NetTotal == y.NetTotal
                    && x.GrossTotal == y.GrossTotal
                    && x.OrderFrequency == y.OrderFrequency
                    && String.Equals(x.Comment?.Trim(), y.Comment?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.Balance == y.Balance
                    && x.Discount == y.Discount
                    && x.Exempt == y.Exempt
                    && x.AccountsReceivableBalance == y.AccountsReceivableBalance
                    && x.CreditLimit == y.CreditLimit
                    && x.DiscountDays == y.DiscountDays
                    && x.DueDays == y.DueDays
                    && x.DiscountPercent == y.DiscountPercent
                    && x.PromotionalBalance == y.PromotionalBalance
                    && String.Equals(x.OtherComment?.Trim(), y.OtherComment?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.SalesID?.Trim(), y.SalesID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.NoMail == y.NoMail
                    && x.BelongNumber == y.BelongNumber
                    && String.Equals(x.CarrierRoute?.Trim(), y.CarrierRoute?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.DeliveryPoint?.Trim(), y.DeliveryPoint?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.NCOACHANGE == y.NCOACHANGE
                    && x.EntryDate.GetValueOrDefault().Equals(y.EntryDate.GetValueOrDefault())
                    && String.Equals(x.Company_Search?.Trim(), y.Company_Search?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Email?.Trim(), y.Email?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.TaxExempt == y.TaxExempt
                    && String.Equals(x.TaxID?.Trim(), y.TaxID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.CashOnly == y.CashOnly
                    && String.Equals(x.Salutation?.Trim(), y.Salutation?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Honor?.Trim(), y.Honor?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Title?.Trim(), y.Title?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.NoEmail == y.NoEmail
                    && String.Equals(x.Password?.Trim(), y.Password?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.RFM == y.RFM
                    && x.Points == y.Points
                    && x.NoRenting == y.NoRenting
                    && x.AddressType == y.AddressType
                    && x.WebAddress == y.WebAddress
                    && x.DateLimit == y.DateLimit
                    && x.StartDate.GetValueOrDefault().Equals(y.StartDate.GetValueOrDefault())
                    && x.EndDate.GetValueOrDefault().Equals(y.EndDate.GetValueOrDefault())
                    && x.StartMonth == y.StartMonth
                    && x.StartDay == y.StartDay
                    && x.EndMonth == y.EndMonth
                    && x.EndDay == y.EndDay
                    && x.ShippingAddressMatchesBillingAddress == y.ShippingAddressMatchesBillingAddress
                    && x.NoPoints == y.NoPoints
                    && x.UPSCommercialDelivery == y.UPSCommercialDelivery
                    && String.Equals(x.PreferredShippingMethod?.Trim(), y.PreferredShippingMethod?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.PreferredPaymentMethod?.Trim(), y.PreferredPaymentMethod?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ValidatedAddressCode?.Trim(), y.ValidatedAddressCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.ValidatedDate.GetValueOrDefault().Equals(y.ValidatedDate.GetValueOrDefault())
                    && String.Equals(x.SoundsLikeName?.Trim(), y.SoundsLikeName?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.AddressExpirationDate.GetValueOrDefault().Equals(y.AddressExpirationDate.GetValueOrDefault())
                    && x.ACVMEDate.GetValueOrDefault().Equals(y.ACVMEDate.GetValueOrDefault())
                    && x.AccountDate.GetValueOrDefault().Equals(y.AccountDate.GetValueOrDefault())
                    && x.DiscountStartDate.GetValueOrDefault().Equals(y.DiscountStartDate.GetValueOrDefault())
                    && x.DiscountEndDate.GetValueOrDefault().Equals(y.DiscountEndDate.GetValueOrDefault())
                    && (((x.PreferredWarehouse == null) && (y.PreferredWarehouse == null)) || ((x.PreferredWarehouse != null) && x.PreferredWarehouse.Equals(y.PreferredWarehouse)))
                    && String.Equals(x.BestTimeToCall?.Trim(), y.BestTimeToCall?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.Fraud == y.Fraud
                    && x.NoCalling == y.NoCalling
                    && x.NoFax == y.NoFax
                    && String.Equals(x.SecondTaxID?.Trim(), y.SecondTaxID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.EMAILDEF?.Trim(), y.EMAILDEF?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.EmailPreference?.Trim(), y.EmailPreference?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Server?.Trim(), y.Server?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Root?.Trim(), y.Root?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Stores?.Trim(), y.Stores?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    && x.TaxExemptions.Equals(y.TaxExemptions)
                    && x.CustomerTerms == y.CustomerTerms
                    && x.AutoSupport == y.AutoSupport
                    && x.TariffExempt == y.TariffExempt
                    && x.CustomerReference == y.CustomerReference;
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(AlternateCustomerNumber);
            hash.Add(LastName);
            hash.Add(FirstName);
            hash.Add(Company);
            hash.Add(Address);
            hash.Add(Phone);
            hash.Add(OriginAdCampaign);
            hash.Add(LastAdCampaign);
            hash.Add(CatCount);
            hash.Add(CustomerType);
            hash.Add(CustomerType_1);
            hash.Add(CustomerType_2);
            hash.Add(CustomerType_3);
            hash.Add(OrderDate);
            hash.Add(PaymentMethod);
            hash.Add(CardNumber);
            hash.Add(CardType);
            hash.Add(CardExpiration);
            hash.Add(ShippingList);
            hash.Add(Expired);
            hash.Add(BadCheck);
            hash.Add(OrderRecord);
            hash.Add(NetTotal);
            hash.Add(GrossTotal);
            hash.Add(OrderFrequency);
            hash.Add(Comment);
            hash.Add(Balance);
            hash.Add(Discount);
            hash.Add(Exempt);
            hash.Add(AccountsReceivableBalance);
            hash.Add(CreditLimit);
            hash.Add(DiscountDays);
            hash.Add(DueDays);
            hash.Add(DiscountPercent);
            hash.Add(PromotionalBalance);
            hash.Add(OtherComment);
            hash.Add(SalesID);
            hash.Add(NoMail);
            hash.Add(BelongNumber);
            hash.Add(CarrierRoute);
            hash.Add(DeliveryPoint);
            hash.Add(NCOACHANGE);
            hash.Add(EntryDate);
            hash.Add(Company_Search);
            hash.Add(Email);
            hash.Add(TaxExempt);
            hash.Add(TaxID);
            hash.Add(CashOnly);
            hash.Add(Salutation);
            hash.Add(Honor);
            hash.Add(Title);
            hash.Add(NoEmail);
            hash.Add(Password);
            hash.Add(RFM);
            hash.Add(Points);
            hash.Add(NoRenting);
            hash.Add(AddressType);
            hash.Add(WebAddress);
            hash.Add(DateLimit);
            hash.Add(StartDate);
            hash.Add(EndDate);
            hash.Add(StartMonth);
            hash.Add(StartDay);
            hash.Add(EndMonth);
            hash.Add(EndDay);
            hash.Add(ShippingAddressMatchesBillingAddress);
            hash.Add(NoPoints);
            hash.Add(UPSCommercialDelivery);
            hash.Add(PreferredShippingMethod);
            hash.Add(PreferredPaymentMethod);
            hash.Add(ValidatedAddressCode);
            hash.Add(ValidatedDate);
            hash.Add(SoundsLikeName);
            hash.Add(AddressExpirationDate);
            hash.Add(ACVMEDate);
            hash.Add(AccountDate);
            hash.Add(DiscountStartDate);
            hash.Add(DiscountEndDate);
            hash.Add(PreferredWarehouse);
            hash.Add(BestTimeToCall);
            hash.Add(Fraud);
            hash.Add(NoCalling);
            hash.Add(NoFax);
            hash.Add(SecondTaxID);
            hash.Add(EMAILDEF);
            hash.Add(EmailPreference);
            hash.Add(Server);
            hash.Add(Root);
            hash.Add(Stores);
            hash.Add(TaxExemptions);
            hash.Add(CustomerTerms);
            hash.Add(AutoSupport);
            hash.Add(TariffExempt);
            hash.Add(CustomerReference);

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="ICustomer"/> object ot get hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetHashCode(ICustomer obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (!String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName))
            {
                builder.Append('[');
                builder.Append(FirstName.Trim());
                builder.AppendSpace();
                builder.Append(LastName.Trim());

                if (!String.IsNullOrWhiteSpace(Email))
                {
                    builder.Append(" | ");
                    builder.Append(Email.Trim());
                }

                builder.Append(']');
            }
            else
            {
                builder.Append(base.ToString());
            }

            return builder.ToString();
        }
    }
}
