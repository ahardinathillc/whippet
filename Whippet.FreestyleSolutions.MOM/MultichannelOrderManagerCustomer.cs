using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Json;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents an individual customer entity in M.O.M.
    /// </summary>
    public class MultichannelOrderManagerCustomer : MultichannelOrderManagerEntity, IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerCustomer, IEqualityComparer<IMultichannelOrderManagerCustomer>, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper
    {
        private string _altNum;
        private string _lastName;
        private string _firstName;
        private string _company;
        private string _addr;
        private string _addr2;
        private string _addr3;
        private string _city;
        private string _county;
        private string _state;
        private string _zipCode;
        private string _country;
        private string _phone;
        private string _phone2;
        private string _origAd;
        private string _custType;
        private string _lastAd;
        private string _payMethod;
        private string _cardNum;
        private string _cardType;
        private string _exp;
        private string _shipList;
        private string _comment;
        private string _comment2;
        private string _salesId;
        private string _carRoute;
        private string _delPoint;
        private string _ncoaChange;
        private string _searchComp;
        private string _email;
        private string _taxId;
        private string _salu;
        private string _hono;
        private string _title;
        private string _password;
        private string _web;
        private string _extension;
        private string _extension2;
        private string _lastUser;
        private string _prefShip;
        private string _prefPay;
        private string _valAddr;
        private string _soundLName;
        private string _modiUser;
        private string _prefWare;
        private string _bestTc;
        private string _taxId2;
        private string _emailDef;
        private string _emailPref;
        private string _custServer;
        private string _root;
        private string _stores;
        private string _lookupBy;
        private string _custType1;
        private string _custType2;
        private string _custType3;

        /// <summary>
        /// Gets or sets the unique ID of the object.
        /// </summary>
        public new long ID
        {
            get
            {
                return MomObjectID;
            }
            set
            {
                MomObjectID = value;
            }
        }

        /// <summary>
        /// Gets the database table name that the entity is mapped to. This property is read-only.
        /// </summary>
        protected override string ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.CUST;
            }
        }

        /// <summary>
        /// Gets or sets the unique customer ID.
        /// </summary>
        public virtual long CustomerId
        {
            get
            {
                return MomObjectID;
            }
            set
            {
                MomObjectID = value;
            }
        }

        /// <summary>
        /// Gets or sets the alternate customer identification number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string AlternateCustomerNumber
        {
            get
            {
                return _altNum;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(AlternateCustomerNumber)].Column);
                _altNum = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(LastName)].Column);
                _lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(FirstName)].Column);
                _firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's company.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Company
        {
            get
            {
                return _company;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Company)].Column);
                _company = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's address (first line).
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Address
        {
            get
            {
                return _addr;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Address)].Column);
                _addr = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's address (second line).
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SecondAddress
        {
            get
            {
                return _addr2;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SecondAddress)].Column);
                _addr2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's address (third line).
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ThirdAddress
        {
            get
            {
                return _addr3;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ThirdAddress)].Column);
                _addr3 = value;
            }
        }

        /// <summary>
        /// Gets or sets the city portion of the customer's address.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string City
        {
            get
            {
                return _city;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(City)].Column);
                _city = value;
            }
        }

        /// <summary>
        /// Gets or sets the county portion of the customer's address (where applicable).
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string County
        {
            get
            {
                return _county;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(County)].Column);
                _county = value;
            }
        }

        /// <summary>
        /// Gets or sets the state portion of the customer's address.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string State
        {
            get
            {
                return _state;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(State)].Column);
                _state = value;
            }
        }

        /// <summary>
        /// Gets or sets the ZIP (or postal) code portion of the customer's address.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ZipCode)].Column);
                _zipCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the country portion of the customer's address.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Country
        {
            get
            {
                return _country;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Country)].Column);
                _country = value;
            }
        }

        /// <summary>
        /// Specifies the customer's primary phone number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PrimaryPhone
        {
            get
            {
                return _phone;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(PrimaryPhone)].Column);
                _phone = value;
            }
        }

        /// <summary>
        /// Specifies the customer's secondary phone number.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SecondaryPhone
        {
            get
            {
                return _phone2;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SecondaryPhone)].Column);
                _phone2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the originating advertisement campaign that led to the customer contact creation.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string OriginAdCampaign
        {
            get
            {
                return _origAd;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(OriginAdCampaign)].Column);
                _origAd = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CustomerType
        {
            get
            {
                return _custType;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CustomerType)].Column);
                _custType = value;
            }
        }

        /// <summary>
        /// Gets or sets the last advertisement campaign that captured the customer contact information.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string LastAdCampaign
        {
            get
            {
                return _lastAd;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(LastAdCampaign)].Column);
                _lastAd = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual int CatCount
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time of the last order (if any).
        /// </summary>
        public virtual DateTime? OrderDate
        { get; set; }

        /// <summary>
        /// Specifies the default payment method used by the customer.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PaymentMethod
        {
            get
            {
                return _payMethod;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(PaymentMethod)].Column);
                _payMethod = value;
            }
        }

        /// <summary>
        /// Gets or sets the credit card number that serves as the default payment method.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CardNumber
        {
            get
            {
                return _cardNum;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CardNumber)].Column);
                _cardNum = value;
            }
        }

        /// <summary>
        /// Specifies the credit card type that serves as the default payment method.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CardType
        {
            get
            {
                return _cardType;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CardType)].Column);
                _cardType = value;
            }
        }

        /// <summary>
        /// Specifies the credit card expiration date.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CardExpiration
        {
            get
            {
                return _exp;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CardExpiration)].Column);
                _exp = value;
            }
        }

        /// <summary>
        /// Gets or sets the shipping list name.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ShippingList
        {
            get
            {
                return _shipList;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ShippingList)].Column);
                _shipList = value;
            }
        }

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
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Comment)].Column);
                _comment = value;
            }
        }

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
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string OtherComment
        {
            get
            {
                return _comment2;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(OtherComment)].Column);
                _comment2 = value;
            }
        }

        /// <summary>
        /// Gets or sets the ID of the assigned sales account manager.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SalesID
        {
            get
            {
                return _salesId;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SalesID)].Column);
                _salesId = value;
            }
        }

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
        /// Specifies the first customer categorical type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CustomerType__One
        {
            get
            {
                return _custType1;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CustomerType__One)].Column);
                _custType1 = value;
            }
        }

        /// <summary>
        /// Specifies the second customer categorical type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CustomerType__Two
        {
            get
            {
                return _custType2;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CustomerType__Two)].Column);
                _custType2 = value;
            }
        }

        /// <summary>
        /// Specifies the third customer categorical type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CustomerType__Three
        {
            get
            {
                return _custType3;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CustomerType__Three)].Column);
                _custType3 = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string CarrierRoute
        {
            get
            {
                return _carRoute;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(CarrierRoute)].Column);
                _carRoute = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string DeliveryPoint
        {
            get
            {
                return _delPoint;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(DeliveryPoint)].Column);
                _delPoint = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual char NCOACHANGE
        { get;set; }

        /// <summary>
        /// Specifies the date/time the customer account was created.
        /// </summary>
        public virtual DateTime? EntryDate
        { get; set; }

        /// <summary>
        /// Specifies the company search term for the customer.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Company_Search
        {
            get
            {
                return _searchComp;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Company_Search)].Column);
                _searchComp = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's e-mail address.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Email
        {
            get
            {
                return _email;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Email)].Column);
                _email = value;
            }
        }

        /// <summary>
        /// Specifies whether the customer is tax-exempt.
        /// </summary>
        public virtual bool TaxExempt
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's tax ID.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string TaxID
        {
            get
            {
                return _taxId;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(TaxID)].Column);
                _taxId = value;
            }
        }

        /// <summary>
        /// Indicates whether the customer is limited to cash-only transactions.
        /// </summary>
        public virtual bool CashOnly
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's salutation.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Salutation
        {
            get
            {
                return _salu;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Salutation)].Column);
                _salu = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's honorable title.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Honor
        {
            get
            {
                return _hono;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Honor)].Column);
                _hono = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's title.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Title
        {
            get
            {
                return _title;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Title)].Column);
                _title = value;
            }
        }

        /// <summary>
        /// Indicates whether the customer declines e-mail advertisement communication.
        /// </summary>
        public virtual bool NoEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's password.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Password
        {
            get
            {
                return _password;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Password)].Column);
                _password = value;
            }
        }

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
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual bool NoRenting
        { get; set; }

        /// <summary>
        /// Specifies the customer's address type.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual char AddressType
        { get; set; }

        /// <summary>
        /// Specifies the customer's web address URL.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string WebAddress
        {
            get
            {
                return _web;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(WebAddress)].Column);
                _web = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's phone extension.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PhoneExtension
        {
            get
            {
                return _extension;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(PhoneExtension)].Column);
                _extension = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer's secondary phone extension.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string OtherPhoneExtension
        {
            get
            {
                return _extension2;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(OtherPhoneExtension)].Column);
                _extension2 = value;
            }
        }

        /// <summary>
        /// Specifies the date limit type for the customer.
        /// </summary>
        public virtual char DateLimit
        { get; set; }

        /// <summary>
        /// Gets the starting date for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        public virtual DateTime? StartDate
        { get; set; }

        /// <summary>
        /// Gets the ending date for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        public virtual DateTime? EndDate
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
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string LastUser
        {
            get
            {
                return _lastUser;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(LastUser)].Column);
                _lastUser = value;
            }
        }

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
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PreferredShippingMethod
        {
            get
            {
                return _prefShip;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(PreferredShippingMethod)].Column);
                _prefShip = value;
            }
        }

        /// <summary>
        /// Specifies the customer's preferred payment method.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PreferredPaymentMethod
        {
            get
            {
                return _prefPay;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(PreferredPaymentMethod)].Column);
                _prefPay = value;
            }
        }

        /// <summary>
        /// Gets or sets the validated address code.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ValidatedAddressCode
        {
            get
            {
                return _valAddr;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ValidatedAddressCode)].Column);
                _valAddr = value;
            }
        }

        /// <summary>
        /// Gets or sets the date/time the customer information was validated.
        /// </summary>
        public virtual DateTime? ValidatedDate
        { get; set; }

        /// <summary>
        /// Specifies a name that sounds like the customer's name. 
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SoundsLikeName
        {
            get
            {
                return _soundLName;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SoundsLikeName)].Column);
                _soundLName = value;
            }
        }

        /// <summary>
        /// Specifies the date the customer's address expires.
        /// </summary>
        public virtual DateTime? AddressExpirationDate
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual DateTime? ACVMEDate
        { get; set; }

        /// <summary>
        /// Gets or sets the user who last modified the customer record.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string ModifiedBy
        {
            get
            {
                return _modiUser;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(ModifiedBy)].Column);
                _modiUser = value;
            }
        }

        /// <summary>
        /// Gets or sets the date/time the customer record was last modified.
        /// </summary>
        public virtual DateTime? ModifiedDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer account was opened.
        /// </summary>
        public virtual DateTime? AccountDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time discounts are applied to the customer's account.
        /// </summary>
        public virtual DateTime? DiscountStartDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time discounts are no longer applied to the customer's account.
        /// </summary>
        public virtual DateTime? DiscountEndDate
        { get; set; }

        /// <summary>
        /// Specifies the customer's preferred warehouse.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string PreferredWarehouse
        {
            get
            {
                return _prefWare;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(PreferredWarehouse)].Column);
                _prefWare = value;
            }
        }

        /// <summary>
        /// Gets or sets the best time to call the customer.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string BestTimeToCall
        {
            get
            {
                return _bestTc;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(BestTimeToCall)].Column);
                _bestTc = value;
            }
        }

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
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string SecondTaxID
        {
            get
            {
                return _taxId2;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(SecondTaxID)].Column);
                _taxId2 = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string EMAILDEF
        {
            get
            {
                return _emailDef;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(EMAILDEF)].Column);
                _emailDef = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string EmailPreference
        {
            get
            {
                return _emailPref;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(EmailPreference)].Column);
                _emailPref = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string MOMServer
        {
            get
            {
                return _custServer;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(MOMServer)].Column);
                _custServer = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Root
        {
            get
            {
                return _root;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Root)].Column);
                _root = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string Stores
        {
            get
            {
                return _stores;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(Stores)].Column);
                _stores = value;
            }
        }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool C_Exempt
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool I_Exempt
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
        /// Gets or sets the username of the user who last accessed the record.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public virtual string LookupBy
        {
            get
            {
                return _lookupBy;
            }
            set
            {
                this.CheckLengthRequirement(value, CreateImportMap()[nameof(LookupBy)].Column);
                _lookupBy = value;
            }
        }

        /// <summary>
        /// Gets or sets the date/time the record was last accessed.
        /// </summary>
        public virtual DateTime? LookupOn
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
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public virtual bool N_Exempt
        { get; set; }


        /// <summary>
        /// Gets the external table name or <see langword="null"/> if the data source is not stored in a database. This property is read-only.
        /// </summary>
        string IWhippetEntityExternalDataRowImportMapper.ExternalTableName
        {
            get
            {
                return MultichannelOrderManagerDatabaseConstants.Tables.CUST;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomer"/> class with no arguments.
        /// </summary>
        public MultichannelOrderManagerCustomer()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomer"/> with the specified ID.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        public MultichannelOrderManagerCustomer(Guid id)
            : base(id)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomer"/> with the specified parameters.
        /// </summary>
        /// <param name="id">Unique ID of the entity.</param>
        /// <param name="customerNumber">Customer number.</param>
        public MultichannelOrderManagerCustomer(Guid id, long customerNumber)
            : this(id)
        {
            CustomerId = customerNumber;
        }

        /// <summary>
        /// Creates a <see cref="WhippetDataRowImportMap"/> object that contains a mapping for the current entity.
        /// </summary>
        /// <returns><see cref="WhippetDataRowImportMap"/> object.</returns>
        public override WhippetDataRowImportMap CreateImportMap()
        {
            return new WhippetDataRowImportMap(new[] {
                new WhippetDataRowImportMapEntry(nameof(AccountDate), MultichannelOrderManagerDatabaseConstants.Columns.ACT_DATE),
                new WhippetDataRowImportMapEntry(nameof(ACVMEDate), MultichannelOrderManagerDatabaseConstants.Columns.ACVMEDATE),
                new WhippetDataRowImportMapEntry(nameof(Address), MultichannelOrderManagerDatabaseConstants.Columns.ADDR),
                new WhippetDataRowImportMapEntry(nameof(AddressType), MultichannelOrderManagerDatabaseConstants.Columns.ADDR_TYPE),
                new WhippetDataRowImportMapEntry(nameof(SecondAddress), MultichannelOrderManagerDatabaseConstants.Columns.ADDR2),
                new WhippetDataRowImportMapEntry(nameof(ThirdAddress), MultichannelOrderManagerDatabaseConstants.Columns.ADDR3),
                new WhippetDataRowImportMapEntry(nameof(AddressExpirationDate), MultichannelOrderManagerDatabaseConstants.Columns.ADDREXPIRE),
                new WhippetDataRowImportMapEntry(nameof(ShippingAddressMatchesBillingAddress), MultichannelOrderManagerDatabaseConstants.Columns.ADDRISSAME),
                new WhippetDataRowImportMapEntry(nameof(AlternateCustomerNumber), MultichannelOrderManagerDatabaseConstants.Columns.ALTNUM),
                new WhippetDataRowImportMapEntry(nameof(AccountsReceivableBalance), MultichannelOrderManagerDatabaseConstants.Columns.AR_BALANCE),
                new WhippetDataRowImportMapEntry(nameof(AutoSupport), MultichannelOrderManagerDatabaseConstants.Columns.AUTOSUPPORT),
                new WhippetDataRowImportMapEntry(nameof(BadCheck), MultichannelOrderManagerDatabaseConstants.Columns.BADCHECK),
                new WhippetDataRowImportMapEntry(nameof(BelongNumber), MultichannelOrderManagerDatabaseConstants.Columns.BELONGNUM),
                new WhippetDataRowImportMapEntry(nameof(BestTimeToCall), MultichannelOrderManagerDatabaseConstants.Columns.BESTTTC),
                new WhippetDataRowImportMapEntry(nameof(C_Exempt), MultichannelOrderManagerDatabaseConstants.Columns.C_EXEMPT),
                new WhippetDataRowImportMapEntry(nameof(CardNumber), MultichannelOrderManagerDatabaseConstants.Columns.CARDNUM),
                new WhippetDataRowImportMapEntry(nameof(CardType), MultichannelOrderManagerDatabaseConstants.Columns.CARDTYPE),
                new WhippetDataRowImportMapEntry(nameof(CarrierRoute), MultichannelOrderManagerDatabaseConstants.Columns.CARROUTE),
                new WhippetDataRowImportMapEntry(nameof(CashOnly), MultichannelOrderManagerDatabaseConstants.Columns.CASHONLY),
                new WhippetDataRowImportMapEntry(nameof(CatCount), MultichannelOrderManagerDatabaseConstants.Columns.CATCOUNT),
                new WhippetDataRowImportMapEntry(nameof(City), MultichannelOrderManagerDatabaseConstants.Columns.CITY),
                new WhippetDataRowImportMapEntry(nameof(Comment), MultichannelOrderManagerDatabaseConstants.Columns.COMMENT),
                new WhippetDataRowImportMapEntry(nameof(OtherComment), MultichannelOrderManagerDatabaseConstants.Columns.COMMENT2),
                new WhippetDataRowImportMapEntry(nameof(Company), MultichannelOrderManagerDatabaseConstants.Columns.COMPANY),
                new WhippetDataRowImportMapEntry(nameof(Country), MultichannelOrderManagerDatabaseConstants.Columns.COUNTRY),
                new WhippetDataRowImportMapEntry(nameof(County), MultichannelOrderManagerDatabaseConstants.Columns.COUNTY),
                new WhippetDataRowImportMapEntry(nameof(CreditLimit), MultichannelOrderManagerDatabaseConstants.Columns.CREDIT_LIM),
                new WhippetDataRowImportMapEntry(nameof(CustomerType__One), MultichannelOrderManagerDatabaseConstants.Columns.CTYPE),
                new WhippetDataRowImportMapEntry(nameof(CustomerType__Two), MultichannelOrderManagerDatabaseConstants.Columns.CTYPE2),
                new WhippetDataRowImportMapEntry(nameof(CustomerType__Three), MultichannelOrderManagerDatabaseConstants.Columns.CTYPE3),
                new WhippetDataRowImportMapEntry(nameof(CustomerTerms), MultichannelOrderManagerDatabaseConstants.Columns.CUST_TERMS),
                new WhippetDataRowImportMapEntry(nameof(Balance), MultichannelOrderManagerDatabaseConstants.Columns.CUSTBAL),
                new WhippetDataRowImportMapEntry(nameof(CustomerId), MultichannelOrderManagerDatabaseConstants.Columns.CUSTNUM),
                new WhippetDataRowImportMapEntry(nameof(CustomerReference), MultichannelOrderManagerDatabaseConstants.Columns.CUSTREF),
                new WhippetDataRowImportMapEntry(nameof(CustomerType), MultichannelOrderManagerDatabaseConstants.Columns.CUSTTYPE),
                new WhippetDataRowImportMapEntry(nameof(DateLimit), MultichannelOrderManagerDatabaseConstants.Columns.DATE_LIMIT),
                new WhippetDataRowImportMapEntry(nameof(DeliveryPoint), MultichannelOrderManagerDatabaseConstants.Columns.DELPOINT),
                new WhippetDataRowImportMapEntry(nameof(Discount), MultichannelOrderManagerDatabaseConstants.Columns.DISCOUNT),
                new WhippetDataRowImportMapEntry(nameof(DiscountDays), MultichannelOrderManagerDatabaseConstants.Columns.DISCT_DAYS),
                new WhippetDataRowImportMapEntry(nameof(DiscountPercent), MultichannelOrderManagerDatabaseConstants.Columns.DISCT_PCT),
                new WhippetDataRowImportMapEntry(nameof(DiscountEndDate), MultichannelOrderManagerDatabaseConstants.Columns.DSCTENDATE),
                new WhippetDataRowImportMapEntry(nameof(DiscountStartDate), MultichannelOrderManagerDatabaseConstants.Columns.DSCTSTDATE),
                new WhippetDataRowImportMapEntry(nameof(DueDays), MultichannelOrderManagerDatabaseConstants.Columns.DUE_DAYS),
                new WhippetDataRowImportMapEntry(nameof(Email), MultichannelOrderManagerDatabaseConstants.Columns.EMAIL),
                new WhippetDataRowImportMapEntry(nameof(EMAILDEF), MultichannelOrderManagerDatabaseConstants.Columns.EMAILDEF),
                new WhippetDataRowImportMapEntry(nameof(EmailPreference), MultichannelOrderManagerDatabaseConstants.Columns.EMAILPREF),
                new WhippetDataRowImportMapEntry(nameof(EndDate), MultichannelOrderManagerDatabaseConstants.Columns.END_DATE),
                new WhippetDataRowImportMapEntry(nameof(EntryDate), MultichannelOrderManagerDatabaseConstants.Columns.ENTRYDATE),
                new WhippetDataRowImportMapEntry(nameof(TaxExempt), MultichannelOrderManagerDatabaseConstants.Columns.EXEMPT),
                new WhippetDataRowImportMapEntry(nameof(CardExpiration), MultichannelOrderManagerDatabaseConstants.Columns.EXP),
                new WhippetDataRowImportMapEntry(nameof(Expired), MultichannelOrderManagerDatabaseConstants.Columns.EXPIRED),
                new WhippetDataRowImportMapEntry(nameof(PhoneExtension), MultichannelOrderManagerDatabaseConstants.Columns.EXTENSION),
                new WhippetDataRowImportMapEntry(nameof(OtherPhoneExtension), MultichannelOrderManagerDatabaseConstants.Columns.EXTENSION2),
                new WhippetDataRowImportMapEntry(nameof(FirstName), MultichannelOrderManagerDatabaseConstants.Columns.FIRSTNAME),
                new WhippetDataRowImportMapEntry(nameof(Fraud), MultichannelOrderManagerDatabaseConstants.Columns.FRAUD),
                new WhippetDataRowImportMapEntry(nameof(StartDay), MultichannelOrderManagerDatabaseConstants.Columns.FROM_DAY),
                new WhippetDataRowImportMapEntry(nameof(StartMonth), MultichannelOrderManagerDatabaseConstants.Columns.FROM_MONTH),
                new WhippetDataRowImportMapEntry(nameof(GrossTotal), MultichannelOrderManagerDatabaseConstants.Columns.GROSS),
                new WhippetDataRowImportMapEntry(nameof(Honor), MultichannelOrderManagerDatabaseConstants.Columns.HONO),
                new WhippetDataRowImportMapEntry(nameof(I_Exempt), MultichannelOrderManagerDatabaseConstants.Columns.I_EXEMPT),
                new WhippetDataRowImportMapEntry(nameof(LastAdCampaign), MultichannelOrderManagerDatabaseConstants.Columns.LAST_AD),
                new WhippetDataRowImportMapEntry(nameof(LastName), MultichannelOrderManagerDatabaseConstants.Columns.LASTNAME),
                new WhippetDataRowImportMapEntry(nameof(LastUser), MultichannelOrderManagerDatabaseConstants.Columns.LASTUSER),
                new WhippetDataRowImportMapEntry(nameof(LookupBy), MultichannelOrderManagerDatabaseConstants.Columns.LU_BY),
                new WhippetDataRowImportMapEntry(nameof(LookupOn), MultichannelOrderManagerDatabaseConstants.Columns.LU_ON),
                new WhippetDataRowImportMapEntry(nameof(ModifiedDate), MultichannelOrderManagerDatabaseConstants.Columns.MODI_DATE),
                new WhippetDataRowImportMapEntry(nameof(ModifiedBy), MultichannelOrderManagerDatabaseConstants.Columns.MODI_USER),
                new WhippetDataRowImportMapEntry(nameof(N_Exempt), MultichannelOrderManagerDatabaseConstants.Columns.N_EXEMPT),
                new WhippetDataRowImportMapEntry(nameof(NCOACHANGE), MultichannelOrderManagerDatabaseConstants.Columns.NCOACHANGE),
                new WhippetDataRowImportMapEntry(nameof(NetTotal), MultichannelOrderManagerDatabaseConstants.Columns.NET),
                new WhippetDataRowImportMapEntry(nameof(NoCalling), MultichannelOrderManagerDatabaseConstants.Columns.NOCALL),
                new WhippetDataRowImportMapEntry(nameof(NoEmail), MultichannelOrderManagerDatabaseConstants.Columns.NOEMAIL),
                new WhippetDataRowImportMapEntry(nameof(NoFax), MultichannelOrderManagerDatabaseConstants.Columns.NOFAX),
                new WhippetDataRowImportMapEntry(nameof(NoMail), MultichannelOrderManagerDatabaseConstants.Columns.NOMAIL),
                new WhippetDataRowImportMapEntry(nameof(NoPoints), MultichannelOrderManagerDatabaseConstants.Columns.NOPOINTS),
                new WhippetDataRowImportMapEntry(nameof(NoRenting), MultichannelOrderManagerDatabaseConstants.Columns.NORENT),
                new WhippetDataRowImportMapEntry(nameof(OrderDate), MultichannelOrderManagerDatabaseConstants.Columns.ODR_DATE),
                new WhippetDataRowImportMapEntry(nameof(OrderFrequency), MultichannelOrderManagerDatabaseConstants.Columns.ORD_FREQ),
                new WhippetDataRowImportMapEntry(nameof(OrderRecord), MultichannelOrderManagerDatabaseConstants.Columns.ORDERREC),
                new WhippetDataRowImportMapEntry(nameof(OriginAdCampaign), MultichannelOrderManagerDatabaseConstants.Columns.ORIG_AD),
                new WhippetDataRowImportMapEntry(nameof(Password), MultichannelOrderManagerDatabaseConstants.Columns.PASSWORD),
                new WhippetDataRowImportMapEntry(nameof(PaymentMethod), MultichannelOrderManagerDatabaseConstants.Columns.PAYMETHOD),
                new WhippetDataRowImportMapEntry(nameof(PrimaryPhone), MultichannelOrderManagerDatabaseConstants.Columns.PHONE),
                new WhippetDataRowImportMapEntry(nameof(SecondaryPhone), MultichannelOrderManagerDatabaseConstants.Columns.PHONE2),
                new WhippetDataRowImportMapEntry(nameof(Points), MultichannelOrderManagerDatabaseConstants.Columns.POINTS),
                new WhippetDataRowImportMapEntry(nameof(PreferredPaymentMethod), MultichannelOrderManagerDatabaseConstants.Columns.PREF_PAY),
                new WhippetDataRowImportMapEntry(nameof(PreferredShippingMethod), MultichannelOrderManagerDatabaseConstants.Columns.PREF_SHIP),
                new WhippetDataRowImportMapEntry(nameof(PreferredWarehouse), MultichannelOrderManagerDatabaseConstants.Columns.PREFWARE),
                new WhippetDataRowImportMapEntry(nameof(PromotionalBalance), MultichannelOrderManagerDatabaseConstants.Columns.PROMO_BAL),
                new WhippetDataRowImportMapEntry(nameof(RFM), MultichannelOrderManagerDatabaseConstants.Columns.RFM),
                new WhippetDataRowImportMapEntry(nameof(Root), MultichannelOrderManagerDatabaseConstants.Columns.ROOT),
                new WhippetDataRowImportMapEntry(nameof(SalesID), MultichannelOrderManagerDatabaseConstants.Columns.SALES_ID),
                new WhippetDataRowImportMapEntry(nameof(Salutation), MultichannelOrderManagerDatabaseConstants.Columns.SALU),
                new WhippetDataRowImportMapEntry(nameof(Company_Search), MultichannelOrderManagerDatabaseConstants.Columns.SEARCHCOMP),
                new WhippetDataRowImportMapEntry(nameof(MOMServer), MultichannelOrderManagerDatabaseConstants.Columns.SERVER),
                new WhippetDataRowImportMapEntry(nameof(ShippingList), MultichannelOrderManagerDatabaseConstants.Columns.SHIPLIST),
                new WhippetDataRowImportMapEntry(nameof(SoundsLikeName), MultichannelOrderManagerDatabaseConstants.Columns.SOUNDLNAME),
                new WhippetDataRowImportMapEntry(nameof(StartDate), MultichannelOrderManagerDatabaseConstants.Columns.START_DATE),
                new WhippetDataRowImportMapEntry(nameof(State), MultichannelOrderManagerDatabaseConstants.Columns.STATE),
                new WhippetDataRowImportMapEntry(nameof(Stores), MultichannelOrderManagerDatabaseConstants.Columns.STORES),
                new WhippetDataRowImportMapEntry(nameof(TaxID), MultichannelOrderManagerDatabaseConstants.Columns.TAX_ID),
                new WhippetDataRowImportMapEntry(nameof(SecondTaxID), MultichannelOrderManagerDatabaseConstants.Columns.TAX_ID2),
                new WhippetDataRowImportMapEntry(nameof(TariffExempt), MultichannelOrderManagerDatabaseConstants.Columns.TFEXEMPT),
                new WhippetDataRowImportMapEntry(nameof(Title), MultichannelOrderManagerDatabaseConstants.Columns.TITLE),
                new WhippetDataRowImportMapEntry(nameof(EndDay), MultichannelOrderManagerDatabaseConstants.Columns.TO_DAY),
                new WhippetDataRowImportMapEntry(nameof(EndMonth), MultichannelOrderManagerDatabaseConstants.Columns.TO_MONTH),
                new WhippetDataRowImportMapEntry(nameof(UPSCommercialDelivery), MultichannelOrderManagerDatabaseConstants.Columns.UPSCOMDELV),
                new WhippetDataRowImportMapEntry(nameof(ValidatedAddressCode), MultichannelOrderManagerDatabaseConstants.Columns.VALADDR),
                new WhippetDataRowImportMapEntry(nameof(ValidatedDate), MultichannelOrderManagerDatabaseConstants.Columns.VALDATE),
                new WhippetDataRowImportMapEntry(nameof(WebAddress), MultichannelOrderManagerDatabaseConstants.Columns.WEB),
                new WhippetDataRowImportMapEntry(nameof(ZipCode), MultichannelOrderManagerDatabaseConstants.Columns.ZIPCODE)
            });
        }

        /// <summary>
        /// Imports the specified <see cref="DataRow"/> containing the information needed to populate the <see cref="IWhippetEntity"/>. This method must be overridden.
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> containing the data to import.</param>
        /// <param name="importMap">External <see cref="WhippetDataRowImportMap"/>. If <see langword="null"/>, then the one generated by <see cref="CreateImportMap"/> will be used.</param>
        /// <exception cref="ArgumentNullException" />
        public override void ImportDataRow(DataRow dataRow, WhippetDataRowImportMap importMap = null)
        {
            if (dataRow == null)
            {
                throw new ArgumentNullException(nameof(dataRow));
            }
            else
            {
                WhippetDataRowImportMap map = (importMap == null ? CreateImportMap() : importMap);

                AccountDate = dataRow.Field<DateTime?>(map[nameof(AccountDate)].Column);
                ACVMEDate = dataRow.Field<DateTime?>(map[nameof(ACVMEDate)].Column);
                Address = dataRow.Field<string>(map[nameof(Address)].Column);
                AddressType = dataRow.Field<char>(map[nameof(AddressType)].Column);
                SecondAddress = dataRow.Field<string>(map[nameof(SecondAddress)].Column);
                ThirdAddress = dataRow.Field<string>(map[nameof(ThirdAddress)].Column);
                AddressExpirationDate = dataRow.Field<DateTime?>(map[nameof(AddressExpirationDate)].Column);
                ShippingAddressMatchesBillingAddress = dataRow.Field<bool>(map[nameof(ShippingAddressMatchesBillingAddress)].Column);
                AlternateCustomerNumber = dataRow.Field<string>(map[nameof(AlternateCustomerNumber)].Column);
                AccountsReceivableBalance = dataRow.Field<decimal>(map[nameof(AccountsReceivableBalance)].Column);
                AutoSupport = dataRow.Field<bool>(map[nameof(AutoSupport)].Column);
                BadCheck = dataRow.Field<bool>(map[nameof(BadCheck)].Column);
                BelongNumber = dataRow.Field<int>(map[nameof(BelongNumber)].Column);
                BestTimeToCall = dataRow.Field<string>(map[nameof(BestTimeToCall)].Column);
                C_Exempt = dataRow.Field<bool>(map[nameof(C_Exempt)].Column);
                CardNumber = dataRow.Field<string>(map[nameof(CardNumber)].Column);
                CardType = dataRow.Field<string>(map[nameof(CardType)].Column);
                CarrierRoute = dataRow.Field<string>(map[nameof(CarrierRoute)].Column);
                CashOnly = dataRow.Field<bool>(map[nameof(CashOnly)].Column);
                CatCount = dataRow.Field<int>(map[nameof(CatCount)].Column);
                City = dataRow.Field<string>(map[nameof(City)].Column); 
                Comment = dataRow.Field<string>(map[nameof(Comment)].Column);
                OtherComment = dataRow.Field<string>(map[nameof(OtherComment)].Column);
                Company = dataRow.Field<string>(map[nameof(Company)].Column);
                Country = dataRow.Field<string>(map[nameof(Country)].Column);
                County = dataRow.Field<string>(map[nameof(County)].Column);
                CreditLimit = dataRow.Field<decimal>(map[nameof(CreditLimit)].Column);
                CustomerType__One = dataRow.Field<string>(map[nameof(CustomerType__One)].Column);
                CustomerType__Two = dataRow.Field<string>(map[nameof(CustomerType__Two)].Column);
                CustomerType__Three = dataRow.Field<string>(map[nameof(CustomerType__Three)].Column);
                CustomerTerms = dataRow.Field<bool>(map[nameof(CustomerTerms)].Column);
                Balance = dataRow.Field<decimal>(map[nameof(Balance)].Column);
                CustomerId = dataRow.Field<long>(map[nameof(CustomerId)].Column);
                CustomerReference = dataRow.Field<int>(map[nameof(CustomerReference)].Column);
                CustomerType = dataRow.Field<string>(map[nameof(CustomerType)].Column);
                DateLimit = dataRow.Field<char>(map[nameof(DateLimit)].Column);
                DeliveryPoint = dataRow.Field<string>(map[nameof(DeliveryPoint)].Column);
                Discount = dataRow.Field<decimal>(map[nameof(Discount)].Column);
                DiscountDays = dataRow.Field<int>(map[nameof(DiscountDays)].Column);
                DiscountPercent = dataRow.Field<decimal>(map[nameof(DiscountPercent)].Column);
                DiscountEndDate = dataRow.Field<DateTime?>(map[nameof(DiscountEndDate)].Column);
                DiscountStartDate = dataRow.Field<DateTime?>(map[nameof(DiscountStartDate)].Column);
                DueDays = dataRow.Field<int>(map[nameof(DueDays)].Column);
                Email = dataRow.Field<string>(map[nameof(Email)].Column);
                EMAILDEF = dataRow.Field<string>(map[nameof(EMAILDEF)].Column);
                EmailPreference = dataRow.Field<string>(map[nameof(EmailPreference)].Column);
                EndDate = dataRow.Field<DateTime?>(map[nameof(EndDate)].Column);
                EntryDate = dataRow.Field<DateTime?>(map[nameof(EntryDate)].Column);
                TaxExempt = dataRow.Field<bool>(map[nameof(TaxExempt)].Column);
                CardExpiration = dataRow.Field<string>(map[nameof(CardExpiration)].Column);
                Expired = dataRow.Field<bool>(map[nameof(Expired)].Column);
                PhoneExtension = dataRow.Field<string>(map[nameof(PhoneExtension)].Column);
                OtherPhoneExtension = dataRow.Field<string>(map[nameof(OtherPhoneExtension)].Column);
                FirstName = dataRow.Field<string>(map[nameof(FirstName)].Column);
                Fraud = dataRow.Field<bool>(map[nameof(Fraud)].Column);
                StartDay = dataRow.Field<int>(map[nameof(StartDay)].Column);
                StartMonth = dataRow.Field<int>(map[nameof(StartMonth)].Column);
                GrossTotal = dataRow.Field<decimal>(map[nameof(GrossTotal)].Column);
                Honor = dataRow.Field<string>(map[nameof(Honor)].Column);
                I_Exempt = dataRow.Field<bool>(map[nameof(I_Exempt)].Column);
                LastAdCampaign = dataRow.Field<string>(map[nameof(LastAdCampaign)].Column);
                LastName = dataRow.Field<string>(map[nameof(LastName)].Column);
                LastUser = dataRow.Field<string>(map[nameof(LastUser)].Column);
                LookupBy = dataRow.Field<string>(map[nameof(LookupBy)].Column);
                LookupOn = dataRow.Field<DateTime?>(map[nameof(LookupOn)].Column);
                ModifiedDate = dataRow.Field<DateTime?>(map[nameof(ModifiedDate)].Column);
                ModifiedBy = dataRow.Field<string>(map[nameof(ModifiedBy)].Column);
                N_Exempt = dataRow.Field<bool>(map[nameof(N_Exempt)].Column);
                NCOACHANGE = dataRow.Field<char>(map[nameof(NCOACHANGE)].Column);
                NetTotal = dataRow.Field<decimal>(map[nameof(NetTotal)].Column);
                NoCalling = dataRow.Field<bool>(map[nameof(NoCalling)].Column);
                NoEmail = dataRow.Field<bool>(map[nameof(NoEmail)].Column);
                NoFax = dataRow.Field<bool>(map[nameof(NoFax)].Column);
                NoMail = dataRow.Field<bool>(map[nameof(NoMail)].Column);
                NoPoints = dataRow.Field<bool>(map[nameof(NoPoints)].Column);
                NoRenting = dataRow.Field<bool>(map[nameof(NoRenting)].Column);
                OrderDate = dataRow.Field<DateTime?>(map[nameof(OrderDate)].Column);
                OrderFrequency = dataRow.Field<int>(map[nameof(OrderFrequency)].Column);
                OrderRecord = dataRow.Field<int>(map[nameof(OrderRecord)].Column);
                OriginAdCampaign = dataRow.Field<string>(map[nameof(OriginAdCampaign)].Column);
                Password = dataRow.Field<string>(map[nameof(Password)].Column);
                PaymentMethod = dataRow.Field<string>(map[nameof(PaymentMethod)].Column);
                PrimaryPhone = dataRow.Field<string>(map[nameof(PrimaryPhone)].Column);
                SecondaryPhone = dataRow.Field<string>(map[nameof(SecondaryPhone)].Column);
                Points = dataRow.Field<int>(map[nameof(Points)].Column);
                PreferredPaymentMethod = dataRow.Field<string>(map[nameof(PreferredPaymentMethod)].Column);
                PreferredShippingMethod = dataRow.Field<string>(map[nameof(PreferredShippingMethod)].Column);
                PreferredWarehouse = dataRow.Field<string>(map[nameof(PreferredWarehouse)].Column);
                PromotionalBalance = dataRow.Field<decimal>(map[nameof(PromotionalBalance)].Column);
                RFM = dataRow.Field<int>(map[nameof(RFM)].Column);
                Root = dataRow.Field<string>(map[nameof(Root)].Column);
                SalesID = dataRow.Field<string>(map[nameof(SalesID)].Column);
                Salutation = dataRow.Field<string>(map[nameof(Salutation)].Column);
                Company_Search = dataRow.Field<string>(map[nameof(Company_Search)].Column);
                MOMServer = dataRow.Field<string>(map[nameof(MOMServer)].Column);
                ShippingList = dataRow.Field<string>(map[nameof(ShippingList)].Column);
                SoundsLikeName = dataRow.Field<string>(map[nameof(SoundsLikeName)].Column);
                StartDate = dataRow.Field<DateTime?>(map[nameof(StartDate)].Column);
                State = dataRow.Field<string>(map[nameof(State)].Column);
                Stores = dataRow.Field<string>(map[nameof(Stores)].Column);
                TaxID = dataRow.Field<string>(map[nameof(TaxID)].Column);
                SecondTaxID = dataRow.Field<string>(map[nameof(SecondTaxID)].Column);
                TariffExempt = dataRow.Field<bool>(map[nameof(TariffExempt)].Column);
                Title = dataRow.Field<string>(map[nameof(Title)].Column);
                EndDay = dataRow.Field<int>(map[nameof(EndDay)].Column);
                EndMonth = dataRow.Field<int>(map[nameof(EndMonth)].Column);
                UPSCommercialDelivery = dataRow.Field<bool>(map[nameof(UPSCommercialDelivery)].Column);
                ValidatedAddressCode = dataRow.Field<string>(map[nameof(ValidatedAddressCode)].Column);
                ValidatedDate = dataRow.Field<DateTime?>(map[nameof(ValidatedDate)].Column);
                WebAddress = dataRow.Field<string>(map[nameof(WebAddress)].Column);
                ZipCode = dataRow.Field<string>(map[nameof(ZipCode)].Column);
            }
        }

        /// <summary>
        /// Creates a <see cref="DataTable"/> that represents the database table of the current entity.
        /// </summary>
        /// <returns><see cref="DataTable"/> containing the columns and respective definitions of the associated external database table for the current entity.</returns>
        public override DataTable CreateDataTable()
        {
            WhippetDataRowImportMap map = CreateImportMap();
            DataTable table = new DataTable();

            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(AccountDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ACVMEDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Address)].Column, false, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(AddressType)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SecondAddress)].Column, false, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ThirdAddress)].Column, false, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(AddressExpirationDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(ShippingAddressMatchesBillingAddress)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(AlternateCustomerNumber)].Column, false, 15));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(AccountsReceivableBalance)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(AutoSupport)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(BadCheck)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(BelongNumber)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(BestTimeToCall)].Column, false, 13));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(C_Exempt)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CardNumber)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CardType)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CarrierRoute)].Column, false, 4));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CashOnly)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(CatCount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(City)].Column, false, 30));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Comment)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherComment)].Column, false, 60));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Company)].Column, false, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Country)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(County)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(CreditLimit)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CustomerType__One)].Column, false, 1));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CustomerType__Two)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CustomerType__Three)].Column, false, 4));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(CustomerTerms)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Balance)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<long>(map[nameof(CustomerId)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(CustomerReference)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CustomerType)].Column, false, 1));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(DateLimit)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(DeliveryPoint)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(Discount)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(DiscountDays)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(DiscountPercent)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(DiscountEndDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(DiscountStartDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(DueDays)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Email)].Column, false, 75));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(EMAILDEF)].Column, false, 8));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(EmailPreference)].Column, false, 5));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(EndDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(EntryDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(TaxExempt)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(CardExpiration)].Column, false, 5));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Expired)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PhoneExtension)].Column, false, 5));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OtherPhoneExtension)].Column, false, 5));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(FirstName)].Column, false, 15));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(Fraud)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(StartDay)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(StartMonth)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(GrossTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Honor)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(I_Exempt)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LastAdCampaign)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LastName)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LastUser)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(LookupBy)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(LookupOn)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ModifiedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ModifiedBy)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(N_Exempt)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<char>(map[nameof(NCOACHANGE)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(NetTotal)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoCalling)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoEmail)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoFax)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoMail)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoPoints)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(NoRenting)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(OrderDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(OrderFrequency)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(OrderRecord)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(OriginAdCampaign)].Column, false, 9));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Password)].Column, false, 20));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PaymentMethod)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PrimaryPhone)].Column, false, 18));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SecondaryPhone)].Column, false, 18));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(Points)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PreferredPaymentMethod)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PreferredShippingMethod)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(PreferredWarehouse)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<decimal>(map[nameof(PromotionalBalance)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(RFM)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Root)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SalesID)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Salutation)].Column, false, 6));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Company_Search)].Column, false, 15));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(MOMServer)].Column, false, 10));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ShippingList)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SoundsLikeName)].Column, false, 4));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(StartDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(State)].Column, false, 3));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Stores)].Column, false, 100));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(TaxID)].Column, false, 15));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(SecondTaxID)].Column, false, 15));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(TariffExempt)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(Title)].Column, false, 40));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(EndDay)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<int>(map[nameof(EndMonth)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<bool>(map[nameof(UPSCommercialDelivery)].Column, false));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ValidatedAddressCode)].Column, false, 2));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<DateTime>(map[nameof(ValidatedDate)].Column, true));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(WebAddress)].Column, false, 50));
            table.Columns.Add(DataColumnFactory.CreateDataColumn<string>(map[nameof(ZipCode)].Column, false, 10));

            table.PrimaryKey = new[] { table.Columns[map[nameof(CustomerId)].Column] };
            
            return table;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IMultichannelOrderManagerCustomer);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerCustomer obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="a">The first object of type <see cref="IMultichannelOrderManagerCustomer"/> to compare.</param>
        /// <param name="b">The second object of type <see cref="IMultichannelOrderManagerCustomer"/> to compare.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(IMultichannelOrderManagerCustomer a, IMultichannelOrderManagerCustomer b)
        {
            bool equals = (a == null && b == null);

            if (!equals && (a != null) && (b != null))
            {
                equals =
                    a.Server.Equals(b.Server)
                        && a.AccountDate.GetValueOrDefault().Equals(b.AccountDate.GetValueOrDefault())
                        && a.AccountsReceivableBalance.Equals(b.AccountsReceivableBalance)
                        && a.ACVMEDate.GetValueOrDefault().Equals(b.ACVMEDate.GetValueOrDefault())
                        && String.Equals(a.Address, b.Address, StringComparison.InvariantCultureIgnoreCase)
                        && a.AddressExpirationDate.GetValueOrDefault().Equals(b.AddressExpirationDate.GetValueOrDefault())
                        && a.AddressType.Equals(b.AddressType)
                        && String.Equals(a.AlternateCustomerNumber, b.AlternateCustomerNumber, StringComparison.InvariantCultureIgnoreCase)
                        && a.AutoSupport.Equals(b.AutoSupport)
                        && a.BadCheck.Equals(b.BadCheck)
                        && a.Balance.Equals(b.Balance)
                        && a.BelongNumber.Equals(b.BelongNumber)
                        && String.Equals(a.BestTimeToCall, b.BestTimeToCall, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CardExpiration, b.CardExpiration, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CardNumber, b.CardNumber, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CardType, b.CardType, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CarrierRoute, b.CarrierRoute, StringComparison.InvariantCultureIgnoreCase)
                        && a.CashOnly.Equals(b.CashOnly)
                        && a.CatCount.Equals(b.CatCount)
                        && String.Equals(a.City, b.City, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Comment, b.Comment, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Company, b.Company, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Company_Search, b.Company_Search, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Country, b.Country, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.County, b.County, StringComparison.InvariantCultureIgnoreCase)
                        && a.CreditLimit.Equals(b.CreditLimit)
                        && a.CustomerId.Equals(b.CustomerId)
                        && a.CustomerReference.Equals(b.CustomerReference)
                        && a.CustomerTerms.Equals(b.CustomerTerms)
                        && String.Equals(a.CustomerType, b.CustomerType, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CustomerType__One, b.CustomerType__One, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CustomerType__Two, b.CustomerType__Two, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.CustomerType__Three, b.CustomerType__Three, StringComparison.InvariantCultureIgnoreCase)
                        && a.C_Exempt.Equals(b.C_Exempt)
                        && a.DateLimit.Equals(b.DateLimit)
                        && String.Equals(a.DeliveryPoint, b.DeliveryPoint, StringComparison.InvariantCultureIgnoreCase)
                        && a.Discount.Equals(b.Discount)
                        && a.DiscountDays.Equals(b.DiscountDays)
                        && a.DiscountEndDate.GetValueOrDefault().Equals(b.DiscountEndDate.GetValueOrDefault())
                        && a.DiscountPercent.Equals(b.DiscountPercent)
                        && a.DiscountStartDate.GetValueOrDefault().Equals(b.DiscountStartDate.GetValueOrDefault())
                        && a.DueDays.Equals(b.DueDays)
                        && String.Equals(a.Email, b.Email, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.EMAILDEF, b.EMAILDEF, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.EmailPreference, b.EmailPreference, StringComparison.InvariantCultureIgnoreCase)
                        && a.EndDate.GetValueOrDefault().Equals(b.EndDate.GetValueOrDefault())
                        && a.EndDay.Equals(b.EndDay)
                        && a.EndMonth.Equals(b.EndMonth)
                        && a.EntryDate.GetValueOrDefault().Equals(b.EntryDate.GetValueOrDefault())
                        && a.Exempt.Equals(b.Exempt)
                        && a.Expired.Equals(b.Expired)
                        && String.Equals(a.FirstName, b.FirstName, StringComparison.InvariantCultureIgnoreCase)
                        && a.Fraud.Equals(b.Fraud)
                        && a.GrossTotal.Equals(b.GrossTotal)
                        && String.Equals(a.Honor, b.Honor, StringComparison.InvariantCultureIgnoreCase)
                        && a.I_Exempt.Equals(b.I_Exempt)
                        && String.Equals(a.LastAdCampaign, b.LastAdCampaign, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.LastName, b.LastName, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.LastUser, b.LastUser, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.LookupBy, b.LookupBy, StringComparison.InvariantCultureIgnoreCase)
                        && a.LookupOn.GetValueOrDefault().Equals(b.LookupOn.GetValueOrDefault())
                        && String.Equals(a.ModifiedBy, b.ModifiedBy, StringComparison.InvariantCultureIgnoreCase)
                        && a.ModifiedDate.GetValueOrDefault().Equals(b.ModifiedDate.GetValueOrDefault())
                        && String.Equals(a.MOMServer, b.MOMServer, StringComparison.InvariantCultureIgnoreCase)
                        && a.NCOACHANGE.Equals(b.NCOACHANGE)
                        && a.NetTotal.Equals(b.NetTotal)
                        && a.NoCalling.Equals(b.NoCalling)
                        && a.NoEmail.Equals(b.NoEmail)
                        && a.NoFax.Equals(b.NoFax)
                        && a.NoMail.Equals(b.NoMail)
                        && a.NoPoints.Equals(b.NoPoints)
                        && a.NoRenting.Equals(b.NoRenting)
                        && a.N_Exempt.Equals(b.N_Exempt)
                        && a.OrderDate.GetValueOrDefault().Equals(b.OrderDate.GetValueOrDefault())
                        && a.OrderFrequency.Equals(b.OrderFrequency)
                        && a.OrderRecord.Equals(b.OrderRecord)
                        && String.Equals(a.OriginAdCampaign, b.OriginAdCampaign, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherComment, b.OtherComment, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.OtherPhoneExtension, b.OtherPhoneExtension, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Password, b.Password, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PaymentMethod, b.PaymentMethod, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PhoneExtension, b.PhoneExtension, StringComparison.InvariantCultureIgnoreCase)
                        && a.Points.Equals(b.Points)
                        && String.Equals(a.PreferredPaymentMethod, b.PreferredPaymentMethod, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PreferredShippingMethod, b.PreferredShippingMethod, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PreferredWarehouse, b.PreferredWarehouse, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.PrimaryPhone, b.PrimaryPhone, StringComparison.InvariantCultureIgnoreCase)
                        && a.PromotionalBalance.Equals(b.PromotionalBalance)
                        && a.RFM.Equals(b.RFM)
                        && String.Equals(a.Root, b.Root, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.SalesID, b.SalesID, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Salutation, b.Salutation, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.SecondAddress, b.SecondAddress, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.SecondaryPhone, b.SecondaryPhone, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.SecondTaxID, b.SecondTaxID, StringComparison.InvariantCultureIgnoreCase)
                        && a.ShippingAddressMatchesBillingAddress.Equals(b.ShippingAddressMatchesBillingAddress)
                        && String.Equals(a.ShippingList, b.ShippingList, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.SoundsLikeName, b.SoundsLikeName, StringComparison.InvariantCultureIgnoreCase)
                        && a.StartDate.GetValueOrDefault().Equals(b.StartDate.GetValueOrDefault())
                        && a.StartDay.Equals(b.StartDay)
                        && a.StartMonth.Equals(b.StartMonth)
                        && String.Equals(a.State, b.State, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Stores, b.Stores, StringComparison.InvariantCultureIgnoreCase)
                        && a.TariffExempt.Equals(b.TariffExempt)
                        && a.TaxExempt.Equals(b.TaxExempt)
                        && a.TaxID.Equals(b.TaxID)
                        && String.Equals(a.ThirdAddress, b.ThirdAddress, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.Title, b.Title, StringComparison.InvariantCultureIgnoreCase)
                        && a.UPSCommercialDelivery.Equals(b.UPSCommercialDelivery)
                        && String.Equals(a.ValidatedAddressCode, b.ValidatedAddressCode, StringComparison.InvariantCultureIgnoreCase)
                        && a.ValidatedDate.GetValueOrDefault().Equals(b.ValidatedDate.GetValueOrDefault())
                        && String.Equals(a.WebAddress, b.WebAddress, StringComparison.InvariantCultureIgnoreCase)
                        && String.Equals(a.ZipCode, b.ZipCode, StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual int GetHashCode(IMultichannelOrderManagerCustomer obj)
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

            builder.Append(FirstName);
            builder.Append(" ");
            builder.Append(LastName);

            if (String.IsNullOrWhiteSpace(builder.ToString()))
            {
                if (!String.IsNullOrWhiteSpace(Company))
                {
                    builder = new StringBuilder(Company);
                }
            }

            return String.IsNullOrWhiteSpace(builder.ToString()) ? base.ToString() : builder.ToString().Trim();
        }

    }
}
