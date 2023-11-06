using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.EAV;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents the address associated with an <see cref="IQuote"/>.
    /// </summary>
    public interface IQuoteAddress : IMagentoEntity, IEqualityComparer<IQuoteAddress>
    {
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        uint AddressID
        { get; set; }

        /// <summary>
        /// Gets or sets the address type.
        /// </summary>
        string AddressType
        { get; set; }

        /// <summary>
        /// Gets or sets the applied taxes.
        /// </summary>
        string AppliedTaxes
        { get; set; }

        /// <summary>
        /// Gets or sets the base customer balance.
        /// </summary>
        decimal? BaseCustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount amount.
        /// </summary>
        decimal BaseDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount tax compensation amount.
        /// </summary>
        decimal? BaseDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards amount.
        /// </summary>
        decimal? BaseGiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base grand total.
        /// </summary>
        decimal BaseGrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount.
        /// </summary>
        decimal? BaseRewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount.
        /// </summary>
        decimal BaseShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping discount amount.
        /// </summary>
        decimal? BaseShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping discount tax compensation amount.
        /// </summary>
        decimal? BaseShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount including tax.
        /// </summary>
        decimal? BaseShippingIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping tax amount.
        /// </summary>
        decimal? BaseShippingTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal amount.
        /// </summary>
        decimal BaseSubtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal including tax amount.
        /// </summary>
        decimal? BaseSubtotalIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal including discount amount.
        /// </summary>
        decimal BaseSubtotalWithDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax amount.
        /// </summary>
        decimal BaseTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the address.
        /// </summary>
        string City
        { get; set; }

        /// <summary>
        /// Indicates whether shipping rates should be collected for the quote.
        /// </summary>
        bool CollectShippingRates
        { get; set; }

        /// <summary>
        /// Gets or sets the company portion of the address.
        /// </summary>
        string Company
        { get; set; }

        /// <summary>
        /// Gets or sets the country ID. Countries are stored in Magento configuration.
        /// </summary>
        string CountryID
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the entity was created.
        /// </summary>
        Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the associated customer address for the quote.
        /// </summary>
        ICustomerAddress CustomerAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance amount.
        /// </summary>
        decimal? CustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer associated with the quote address.
        /// </summary>
        ICustomer Customer
        { get; set; }

        /// <summary>
        /// Gets or sets the customer notes.
        /// </summary>
        string CustomerNotes
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount description.
        /// </summary>
        string DiscountDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount.
        /// </summary>
        decimal? DiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the e-mail address associated with the quote address.
        /// </summary>
        string Email
        { get; set; }

        /// <summary>
        /// Gets or sets the fax phone number associated with the quote address.
        /// </summary>
        string Fax
        { get; set; }

        /// <summary>
        /// Gets or sets the first name portion of the address.
        /// </summary>
        string FirstName
        { get; set; }

        /// <summary>
        /// Indicates whether free shipping is applied to the address.
        /// </summary>
        bool FreeShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the list of gift cards applied to the quote.
        /// </summary>
        string GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards amount.
        /// </summary>
        decimal? GiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the associated gift message.
        /// </summary>
        IGiftMessage GiftMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the gift registry item ID.
        /// </summary>
        int? GiftRegistryItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total.
        /// </summary>
        decimal GrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the last name portion of the quote address.
        /// </summary>
        string LastName
        { get; set; }

        /// <summary>
        /// Gets or sets the middle name portion of the quote address.
        /// </summary>
        string MiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the postal code portion of the quote address.
        /// </summary>
        string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the customer.
        /// </summary>
        string Prefix
        { get; set; }

        /// <summary>
        /// Gets or sets the parent quote that the address is associated with.
        /// </summary>
        IQuote Quote
        { get; set; }

        /// <summary>
        /// Gets or sets the address region.
        /// </summary>
        string Region
        { get; set; }

        /// <summary>
        /// Gets or sets the region ID. The region ID is stored in Magento configuration.
        /// </summary>
        string RegionID
        { get; set; }

        /// <summary>
        /// Gets or sets the reward currency amount.
        /// </summary>
        decimal? RewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the reward points balance.
        /// </summary>
        int? RewardPointsBalance
        { get; set; }

        /// <summary>
        /// Indicates if the quote address is the same as the billing address.
        /// </summary>
        bool SameAsBilling
        { get; set; }

        /// <summary>
        /// Indicates whether the address should be saved in the customer's address book.
        /// </summary>
        bool? SaveInAddressBook
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping amount.
        /// </summary>
        decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping description.
        /// </summary>
        string ShippingDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount.
        /// </summary>
        decimal? ShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount.
        /// </summary>
        decimal? ShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping cost including tax.
        /// </summary>
        decimal? ShippingIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method.
        /// </summary>
        string ShippingMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount.
        /// </summary>
        decimal ShippingTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        string Street
        { get; set; }

        /// <summary>
        /// Gets or sets the quote subtotal.
        /// </summary>
        decimal Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including tax.
        /// </summary>
        decimal? SubtotalIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including applied discounts.
        /// </summary>
        decimal SubtotalWithDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer suffix.
        /// </summary>
        string Suffix
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        decimal TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the address telephone number.
        /// </summary>
        string Telephone
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the entity was last updated.
        /// </summary>
        Instant UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the list of used gift card codes.
        /// </summary>
        string UsedGiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the validated VAT number for the customer.
        /// </summary>
        string ValidatedValueAddedTaxNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the VAT ID.
        /// </summary>
        string ValueAddedTaxID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT supplied is valid.
        /// </summary>
        bool? ValueAddedTaxIsValid
        { get; set; }

        /// <summary>
        /// Gets or sets the date the VAT was requested.
        /// </summary>
        string ValueAddedTaxRequestDate
        { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the VAT request.
        /// </summary>
        string ValueAddedTaxRequestID
        { get; set; }

        /// <summary>
        /// Indicates whether the VAT request was successful.
        /// </summary>
        bool? ValueAddedTaxRequestSuccess
        { get; set; }

        /// <summary>
        /// Gets or sets the weight of the shipment.
        /// </summary>
        decimal Weight
        { get; set; }
    }
}

