using System;
using NodaTime;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Taxes;
using Athi.Whippet.Adobe.Magento.EAV;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a sales quote in Magento.
    /// </summary>
    public interface IQuote : IMagentoEntity, IEqualityComparer<IQuote>, IWhippetActiveEntity
    {
        /// <summary>
        /// Gets or sets the quote's unique entity ID.
        /// </summary>
        uint EntityID
        { get; set; }

        /// <summary>
        /// Gets or sets a delimited list of applied sales rules.
        /// </summary>
        string AppliedRuleIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code.
        /// </summary>
        string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Specifies the base customer amount balance used.
        /// </summary>
        decimal? BaseCustomerBalanceAmountUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards amount.
        /// </summary>
        decimal? BaseGiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards amount used.
        /// </summary>
        decimal? BaseGiftCardsAmountUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the base grand total.
        /// </summary>
        decimal? BaseGrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount.
        /// </summary>
        decimal? BaseRewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal.
        /// </summary>
        decimal? BaseSubtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal with discounts applied.
        /// </summary>
        decimal? BaseSubtotalWithDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the base amount converted to the global rate.
        /// </summary>
        decimal? BaseToGlobalRate
        { get; set; }

        /// <summary>
        /// Gets or sets the base amount converted to the quote rate.
        /// </summary>
        decimal? BaseToQuoteRate
        { get; set; }

        /// <summary>
        /// Gets or sets the checkout method.
        /// </summary>
        string CheckoutMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the quote was converted.
        /// </summary>
        Instant? ConvertedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code used on the quote.
        /// </summary>
        string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the quote was created.
        /// </summary>
        Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance amount used towards the quote.
        /// </summary>
        decimal? CustomerBalanceAmountUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's date of birth.
        /// </summary>
        Instant? CustomerDateOfBirth
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's e-mail address.
        /// </summary>
        string CustomerEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        string CustomerFirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's gender.
        /// </summary>
        string CustomerGender
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's group.
        /// </summary>
        ICustomerGroup CustomerGroup
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> that the quote is for.
        /// </summary>
        ICustomer Customer
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is a guest.
        /// </summary>
        bool? CustomerIsGuest
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        string CustomerLastName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's middle name.
        /// </summary>
        string CustomerMiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the note to apply to the customer's quote.
        /// </summary>
        string CustomerNote
        { get; set; }

        /// <summary>
        /// Indicates whether the customer's note should be flagged.
        /// </summary>
        bool? NotifyCustomerNote
        { get; set; }

        /// <summary>
        /// Gets or sets the customer prefix.
        /// </summary>
        string CustomerPrefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer suffix.
        /// </summary>
        string CustomerSuffix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's tax class.
        /// </summary>
        ITaxClass CustomerTaxClass
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's VAT number.
        /// </summary>
        string CustomerValueAddedTax
        { get; set; }

        /// <summary>
        /// Gets or sets external shipping information for the quote.
        /// </summary>
        string ExternalShippingInfo
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards that are applied to the quote.
        /// </summary>
        string GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the total gift cards amount.
        /// </summary>
        decimal? GiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the total gift cards amount that was applied to the quote.
        /// </summary>
        decimal? GiftCardsAmountUsed
        { get; set; }

        /// <summary>
        /// Gets or sets the gift message to apply to the quote.
        /// </summary>
        IGiftMessage GiftMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the global currency code for the quote.
        /// </summary>
        string GlobalCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total for the quote.
        /// </summary>
        decimal? GrandTotal
        { get; set; }

        /// <summary>
        /// Indicates whether the quote has been changed.
        /// </summary>
        bool? IsChanged
        { get; set; }

        /// <summary>
        /// Indicates whether the highest item price rule is in effect.
        /// </summary>
        bool IsHighestItemPriceRule
        { get; set; }

        /// <summary>
        /// Indicates whether the quote is for a multi-shipment order.
        /// </summary>
        bool? IsMultiShipping
        { get; set; }

        /// <summary>
        /// Indicates whether the quote is persistent.
        /// </summary>
        bool? IsPersistent
        { get; set; }

        /// <summary>
        /// Indicates whether the quote is virtual.
        /// </summary>
        bool? IsVirtual
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items on the quote.
        /// </summary>
        uint? ItemsCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity of items on the quote.
        /// </summary>
        decimal? ItemsQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the original sales order that the quote was for.
        /// </summary>
        ISalesOrder OriginalOrder
        { get; set; }

        /// <summary>
        /// Gets or sets the password hash for the quote.
        /// </summary>
        string PasswordHash
        { get; set; }

        /// <summary>
        /// Gets or sets the currency code for the quote.
        /// </summary>
        string QuoteCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the IP address of the machine that generated the quote.
        /// </summary>
        string RemoteIP
        { get; set; }

        /// <summary>
        /// Gets or sets the reserved order ID.
        /// </summary>
        string ReservedOrderID
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
        /// Gets or sets the store's currency code with respect to the quote.
        /// </summary>
        string StoreCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the parent store that the quote applies to.
        /// </summary>
        IStore Store
        { get; set; }

        /// <summary>
        /// Gets or sets the store-to-base conversion rate.
        /// </summary>
        decimal? StoreToBaseRate
        { get; set; }

        /// <summary>
        /// Gets or sets the store-to-quote conversion rate.
        /// </summary>
        decimal? StoreToQuoteRate
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal of the quote.
        /// </summary>
        decimal? Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal with applied discounts.
        /// </summary>
        decimal? SubtotalWithDiscount
        { get; set; }

        /// <summary>
        /// Indicates whether the quote triggers a recollection in Magento.
        /// </summary>
        bool TriggerRecollect
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the quote was updated.
        /// </summary>
        Instant UpdatedAt
        { get; set; }

        /// <summary>
        /// Indicates whether the customer's balance should be used.
        /// </summary>
        bool? UseCustomerBalance
        { get; set; }

        /// <summary>
        /// Indicates whether the customer's reward points should be used.
        /// </summary>
        bool? UseRewardPoints
        { get; set; }
    }
}