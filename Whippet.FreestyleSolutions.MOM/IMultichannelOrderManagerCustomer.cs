using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager
{
    /// <summary>
    /// Represents an individual customer entity in M.O.M.
    /// </summary>
    public interface IMultichannelOrderManagerCustomer : IWhippetEntity, IWhippetEntityExternalDataRowImportMapper, IEqualityComparer<IMultichannelOrderManagerCustomer>, IMultichannelOrderManagerEntity, IWhippetEntityDynamicImportMapper
    {
        /// <summary>
        /// Gets or sets the unique customer ID.
        /// </summary>
        long CustomerId
        { get; set; }

        /// <summary>
        /// Gets or sets the alternate customer identification number.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" />
        string AlternateCustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        string FirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's company.
        /// </summary>
        string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's address (first line).
        /// </summary>
        string Address
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's address (second line).
        /// </summary>
        string SecondAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's address (third line).
        /// </summary>
        string ThirdAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the customer's address.
        /// </summary>
        string City
        { get; set; }

        /// <summary>
        /// Gets or sets the county portion of the customer's address (where applicable).
        /// </summary>
        string County
        { get; set; }

        /// <summary>
        /// Gets or sets the state portion of the customer's address.
        /// </summary>
        string State
        { get; set; }

        /// <summary>
        /// Gets or sets the ZIP (or postal) code portion of the customer's address.
        /// </summary>
        string ZipCode
        { get; set; }

        /// <summary>
        /// Gets or sets the country portion of the customer's address.
        /// </summary>
        string Country
        { get; set; }

        /// <summary>
        /// Specifies the customer's primary phone number.
        /// </summary>
        string PrimaryPhone
        { get; set; }

        /// <summary>
        /// Specifies the customer's secondary phone number.
        /// </summary>
        string SecondaryPhone
        { get; set; }

        /// <summary>
        /// Gets or sets the originating advertisement campaign that led to the customer contact creation.
        /// </summary>
        string OriginAdCampaign
        { get; set; }

        /// <summary>
        /// Gets or sets the customer type.
        /// </summary>
        string CustomerType
        { get; set; }

        /// <summary>
        /// Gets or sets the last advertisement campaign that captured the customer contact information.
        /// </summary>
        string LastAdCampaign
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        int CatCount
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time of the last order (if any).
        /// </summary>
        DateTime? OrderDate
        { get; set; }

        /// <summary>
        /// Specifies the default payment method used by the customer.
        /// </summary>
        string PaymentMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the credit card number that serves as the default payment method.
        /// </summary>
        string CardNumber
        { get; set; }

        /// <summary>
        /// Specifies the credit card type that serves as the default payment method.
        /// </summary>
        string CardType
        { get; set; }

        /// <summary>
        /// Specifies the credit card expiration date.
        /// </summary>
        string CardExpiration
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping list name.
        /// </summary>
        string ShippingList
        { get; set; }

        /// <summary>
        /// Indicates whether the payment method is expired.
        /// </summary>
        bool Expired
        { get; set; }

        /// <summary>
        /// Indicates whether the customer has ever presented a bad check.
        /// </summary>
        bool BadCheck
        { get; set; }

        /// <summary>
        /// Gets or sets the order record number.
        /// </summary>
        long OrderRecord
        { get; set; }

        /// <summary>
        /// Gets or sets the net total of sales for the customer.
        /// </summary>
        decimal NetTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the gross total of sales for the customer.
        /// </summary>
        decimal GrossTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the order frequency of the customer.
        /// </summary>
        int OrderFrequency
        { get; set; }

        /// <summary>
        /// Specifies a comment entry for the customer.
        /// </summary>
        string Comment
        { get; set; }

        /// <summary>
        /// Gets or sets the current customer's balance.
        /// </summary>
        decimal Balance
        { get; set; }

        /// <summary>
        /// Gets or sets the current discount to apply to the customer.
        /// </summary>
        decimal Discount
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is tax-exempt.
        /// </summary>
        bool Exempt
        { get; set; }

        /// <summary>
        /// Specifies the customer's accounts receivable (A/R) balance.
        /// </summary>
        decimal AccountsReceivableBalance
        { get; set; }

        /// <summary>
        /// Specifies the customer's credit limit.
        /// </summary>
        decimal CreditLimit
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of days the discount is valid for.
        /// </summary>
        int DiscountDays
        { get; set; }

        /// <summary>
        /// Gets or sets the number of days payment of the invoice is due.
        /// </summary>
        int DueDays
        { get; set; }

        /// <summary>
        /// Gets or sets the discount percentage to apply to the customer's invoice.
        /// </summary>
        decimal DiscountPercent
        { get; set; }

        /// <summary>
        /// Specifies the customer's balance for a promotional invoice.
        /// </summary>
        decimal PromotionalBalance
        { get; set; }

        /// <summary>
        /// Second comment line to apply to the customer.
        /// </summary>
        string OtherComment
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the assigned sales account manager.
        /// </summary>
        string SalesID
        { get; set; }

        /// <summary>
        /// Indicates whether the customer declines receiving postal mail advertisements.
        /// </summary>
        bool NoMail
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        int BelongNumber
        { get; set; }

        /// <summary>
        /// Specifies the first customer categorical type.
        /// </summary>
        string CustomerType__One
        { get; set; }

        /// <summary>
        /// Specifies the second customer categorical type.
        /// </summary>
        string CustomerType__Two
        { get; set; }

        /// <summary>
        /// Specifies the third customer categorical type.
        /// </summary>
        string CustomerType__Three
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        string CarrierRoute
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        string DeliveryPoint
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        char NCOACHANGE
        { get; set; }

        /// <summary>
        /// Specifies the date/time the customer account was created.
        /// </summary>
        DateTime? EntryDate
        { get; set; }

        /// <summary>
        /// Specifies the company search term for the customer.
        /// </summary>
        string Company_Search
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's e-mail address.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// Specifies whether the customer is tax-exempt.
        /// </summary>
        bool TaxExempt
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's tax ID.
        /// </summary>
        string TaxID
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is limited to cash-only transactions.
        /// </summary>
        bool CashOnly
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's salutation.
        /// </summary>
        string Salutation
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's honorable title.
        /// </summary>
        string Honor
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's title.
        /// </summary>
        string Title
        { get; set; }

        /// <summary>
        /// Indicates whether the customer declines e-mail advertisement communication.
        /// </summary>
        bool NoEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's password.
        /// </summary>
        string Password
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        int RFM
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        int Points
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is allowed to rent products.
        /// </summary>
        bool NoRenting
        { get; set; }

        /// <summary>
        /// Specifies the customer's address type.
        /// </summary>
        char AddressType
        { get; set; }

        /// <summary>
        /// Specifies the customer's web address URL.
        /// </summary>
        string WebAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's phone extension.
        /// </summary>
        string PhoneExtension
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's secondary phone extension.
        /// </summary>
        string OtherPhoneExtension
        { get; set; }

        /// <summary>
        /// Specifies the date limit type for the customer.
        /// </summary>
        char DateLimit
        { get; set; }

        /// <summary>
        /// Gets the starting date for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        DateTime? StartDate
        { get; set; }

        /// <summary>
        /// Gets the ending date for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        DateTime? EndDate
        { get; set; }

        /// <summary>
        /// Gets the starting month for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        int StartMonth
        { get; set; }

        /// <summary>
        /// Gets the starting day for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        int StartDay
        { get; set; }

        /// <summary>
        /// Gets the ending month for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        int EndMonth
        { get; set; }

        /// <summary>
        /// Gets the ending day for the customer where purchases are allowed to be made, discounts are valid, etc.
        /// </summary>
        int EndDay
        { get; set; }

        /// <summary>
        /// Indicates whether the shipping address is the same as the billing address.
        /// </summary>
        bool ShippingAddressMatchesBillingAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the last user to access the customer's record.
        /// </summary>
        string LastUser
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool NoPoints
        { get; set; }

        /// <summary>
        /// Indicates whether the shipping address is classified as a UPS commercial delivery point.
        /// </summary>
        bool UPSCommercialDelivery
        { get; set; }

        /// <summary>
        /// Specifies the customer's preferred shipping method.
        /// </summary>
        string PreferredShippingMethod
        { get; set; }

        /// <summary>
        /// Specifies the customer's preferred payment method.
        /// </summary>
        string PreferredPaymentMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the validated address code.
        /// </summary>
        string ValidatedAddressCode
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer information was validated.
        /// </summary>
        DateTime? ValidatedDate
        { get; set; }

        /// <summary>
        /// Specifies a name that sounds like the customer's name. 
        /// </summary>
        string SoundsLikeName
        { get; set; }

        /// <summary>
        /// Specifies the date the customer's address expires.
        /// </summary>
        DateTime? AddressExpirationDate
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        DateTime? ACVMEDate
        { get; set; }

        /// <summary>
        /// Gets or sets the user who last modified the customer record.
        /// </summary>
        string ModifiedBy
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer record was last modified.
        /// </summary>
        DateTime? ModifiedDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the customer account was opened.
        /// </summary>
        DateTime? AccountDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time discounts are applied to the customer's account.
        /// </summary>
        DateTime? DiscountStartDate
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time discounts are no longer applied to the customer's account.
        /// </summary>
        DateTime? DiscountEndDate
        { get; set; }

        /// <summary>
        /// Specifies the customer's preferred warehouse.
        /// </summary>
        string PreferredWarehouse
        { get; set; }

        /// <summary>
        /// Gets or sets the best time to call the customer.
        /// </summary>
        string BestTimeToCall
        { get; set; }

        /// <summary>
        /// Indicates whether the customer has been marked as a fraudulent account.
        /// </summary>
        bool Fraud
        { get; set; }

        /// <summary>
        /// Indicates whether the customer does not wish to receive phone solicitation.
        /// </summary>
        bool NoCalling
        { get; set; }

        /// <summary>
        /// Indicates whether the customer does not wish to receive facsimile solicitation.
        /// </summary>
        bool NoFax
        { get; set; }

        /// <summary>
        /// Gets or sets the secondary tax ID code for the customer.
        /// </summary>
        string SecondTaxID
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        string EMAILDEF
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        string EmailPreference
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        string MOMServer
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        string Root
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        string Stores
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool C_Exempt
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool I_Exempt
        { get; set; }

        /// <summary>
        /// Specifies whether the customer has an account service agreement.
        /// </summary>
        bool CustomerTerms
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        public bool AutoSupport
        { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who last accessed the record.
        /// </summary>
        string LookupBy
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the record was last accessed.
        /// </summary>
        DateTime? LookupOn
        { get; set; }

        /// <summary>
        /// Specifies whether the customer is exempt for tariffs.
        /// </summary>
        bool TariffExempt
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        int CustomerReference
        { get; set; }

        /// <summary>
        /// Reserved for use by M.O.M. internally.
        /// </summary>
        bool N_Exempt
        { get; set; }
    }
}