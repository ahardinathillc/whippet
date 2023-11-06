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
    /// Represents a sales order in Magento.
    /// </summary>
    public interface ISalesOrder : IMagentoEntity, IEqualityComparer<ISalesOrder>
    {
        /// <summary>
        /// Gets or sets the unique ID of the sales order.
        /// </summary>
        uint EntityID
        { get; set; }

        /// <summary>
        /// Gets or sets the negative adjustment to the order total.
        /// </summary>
        decimal? AdjustmentNegative
        { get; set; }

        /// <summary>
        /// Gets or sets the positive adjustment to the order total.
        /// </summary>
        decimal? AdjustmentPositive
        { get; set; }

        /// <summary>
        /// Gets or sets a delimited list of applied sales rule IDs.
        /// </summary>
        string AppliedRuleIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the base negative adjustment amount.
        /// </summary>
        decimal? BaseAdjustmentNegative
        { get; set; }

        /// <summary>
        /// Gets or sets the base positive adjustment amount.
        /// </summary>
        decimal? BaseAdjustmentPositive
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code for the order total.
        /// </summary>
        string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the base customer balance.
        /// </summary>
        decimal? BaseCustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base customer balance that was invoiced.
        /// </summary>
        decimal? BaseCustomerBalanceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base customer balance that was refunded.
        /// </summary>
        decimal? BaseCustomerBalanceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount amount.
        /// </summary>
        decimal? BaseDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount that was canceled.
        /// </summary>
        decimal? BaseDiscountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount that was invoiced.
        /// </summary>
        decimal? BaseDiscountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount that was refunded.
        /// </summary>
        decimal? BaseDiscountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount tax compensation amount.
        /// </summary>
        decimal? BaseDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount tax compensation invoiced amount.
        /// </summary>
        decimal? BaseDiscountTaxCompensationInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount tax compensation refunded amount.
        /// </summary>
        decimal? BaseDiscountTaxCompensationRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards amount.
        /// </summary>
        decimal? BaseGiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards invoiced amount.
        /// </summary>
        decimal? BaseGiftCardsInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards refunded amount.
        /// </summary>
        decimal? BaseGiftCardsRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base grand total amount.
        /// </summary>
        decimal? BaseGrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount.
        /// </summary>
        decimal? BaseRewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount that was refunded.
        /// </summary>
        decimal? BaseRewardCurrencyAmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount that was invoiced.
        /// </summary>
        decimal? BaseRewardCurrencyAmountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount.
        /// </summary>
        decimal? BaseShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or setes the base shipping amount that was canceled.
        /// </summary>
        decimal? BaseShippingCanceled
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
        /// Gets or sets the base shipping amount invoiced.
        /// </summary>
        decimal? BaseShippingInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount that was refunded.
        /// </summary>
        decimal? BaseShippingRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping tax amount.
        /// </summary>
        decimal? BaseShippingTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping tax amount that was refunded.
        /// </summary>
        decimal? BaseShippingTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal amount. 
        /// </summary>
        decimal? BaseSubtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal canceled amount.
        /// </summary>
        decimal? BaseSubtotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal amount including tax.
        /// </summary>
        decimal? BaseSubtotalIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal invoiced amount.
        /// </summary>
        decimal? BaseSubtotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal amount that was refunded.
        /// </summary>
        decimal? BaseSubtotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax amount.
        /// </summary>
        decimal? BaseTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax amount that was canceled.
        /// </summary>
        decimal? BaseTaxCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax invoiced amount.
        /// </summary>
        decimal? BaseTaxInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax amount that was refunded.
        /// </summary>
        decimal? BaseTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base amount converted to the global rate.
        /// </summary>
        decimal? BaseToGlobalRate
        { get; set; }

        /// <summary>
        /// Gets or sets the base amount converted to the order rate.
        /// </summary>
        decimal? BaseToOrderRate
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount that was canceled.
        /// </summary>
        decimal? BaseTotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount due.
        /// </summary>
        decimal? BaseTotalDue
        { get; set; }

        /// <summary>
        /// Gets or sets the base total invoiced amount.
        /// </summary>
        decimal? BaseTotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base total invoiced amount cost.
        /// </summary>
        decimal? BaseTotalInvoicedCost
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount refunded offline.
        /// </summary>
        decimal? BaseTotalOfflineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount refunded online.
        /// </summary>
        decimal? BaseTotalOnlineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount paid.
        /// </summary>
        decimal? BaseTotalPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the base total quantity ordered.
        /// </summary>
        decimal? BaseTotalQuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the base total refunded amount.
        /// </summary>
        decimal? BaseTotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the associated billing address with the sales order.
        /// </summary>
        ISalesOrderAddress BillingAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the base total refunded customer balance.
        /// </summary>
        decimal? BaseCustomerBalanceTotalRefunded
        { get; set; }

        /// <summary>
        /// Indicates whether the order can be partially shipped.
        /// </summary>
        bool? CanShipPartially
        { get; set; }

        /// <summary>
        /// Indicates whether the order can be partially shipped.
        /// </summary>
        bool? CanShipItemPartially
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code that was applied to the order.
        /// </summary>
        string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon rule name.
        /// </summary>
        string CouponRuleName
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the entity was created.
        /// </summary>
        Instant CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the total refunded customer balance.
        /// </summary>
        decimal? CustomerBalanceTotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance amount.
        /// </summary>
        decimal? CustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance that was invoiced.
        /// </summary>
        decimal? CustomerBalanceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance that was refunded.
        /// </summary>
        decimal? CustomerBalanceRefunded
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
        /// Gets or sets the customer's gender. Genders are stored in Magento configuration.
        /// </summary>
        int? CustomerGender
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group.
        /// </summary>
        ICustomerGroup CustomerGroup
        { get; set; }

        /// <summary>
        /// Gets or sets the parent customer for the sales order.
        /// </summary>
        ICustomer Customer
        { get; set; }

        /// <summary>
        /// Indicates whether the customer is a guest and does not have an account.
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
        /// Gets or sets the customer note.
        /// </summary>
        string CustomerNote
        { get; set; }

        /// <summary>
        /// Specifies a flag whether the customer's note should be an alert.
        /// </summary>
        bool? CustomerNotifyNote
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's prefix.
        /// </summary>
        string CustomerPrefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's suffix.
        /// </summary>
        string CustomerSuffix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's VAT number.
        /// </summary>
        string CustomerValueAddedTax
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        decimal? DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the canceled discount amount.
        /// </summary>
        decimal? DiscountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the discount description.
        /// </summary>
        string DiscountDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the invoiced discount.
        /// </summary>
        decimal? DiscountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount that was refunded.
        /// </summary>
        decimal? DiscountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount.
        /// </summary>
        decimal? DiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation that was invoiced.
        /// </summary>
        decimal? DiscountTaxCompensationInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation that was refunded.
        /// </summary>
        decimal? DiscountTaxCompensationRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of edits made to the sales order.
        /// </summary>
        int? EditIncrement
        { get; set; }

        /// <summary>
        /// Indicates whether an e-mail has been dispatched for the sales order.
        /// </summary>
        bool? EmailSent
        { get; set; }

        /// <summary>
        /// Gets or sets the external customer ID.
        /// </summary>
        string ExternalCustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the external order ID.
        /// </summary>
        string ExternalOrderID
        { get; set; }

        /// <summary>
        /// Indicates whether the shipment was forced with an unsatisfied invoice.
        /// </summary>
        bool? ForcedShipmentWithInvoice
        { get; set; }

        /// <summary>
        /// Gets or sets all gift cards that were applied to the sales order.
        /// </summary>
        string GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards amount.
        /// </summary>
        decimal? GiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards amount that was invoiced.
        /// </summary>
        decimal? GiftCardsInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards that were refunded.
        /// </summary>
        decimal? GiftCardsRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the associated gift message with the sales order.
        /// </summary>
        IGiftMessage GiftMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the global currency code.
        /// </summary>
        string GlobalCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total of the sales order.
        /// </summary>
        decimal? GrandTotal
        { get; set; }

        /// <summary>
        /// Specifies the order state to hold the sales order before releasing it.
        /// </summary>
        string HoldBeforeState
        { get; set; }

        /// <summary>
        /// Specifies the order status to hold the sales order before releasing it.
        /// </summary>
        string HoldBeforeStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the increment ID.
        /// </summary>
        string IncrementID
        { get; set; }

        /// <summary>
        /// Indicates whether the sales order is a virtual order.
        /// </summary>
        bool? IsVirtual
        { get; set; }

        /// <summary>
        /// Specifies the currency code of the order.
        /// </summary>
        string OrderCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the original increment ID.
        /// </summary>
        string OriginalIncrementID
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization expiration.
        /// </summary>
        int? PaymentAuthorizationExpiration
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization amount.
        /// </summary>
        decimal? PaymentAuthorizationAmount
        { get; set; }

        /// <summary>
        /// Indicates whether the PayPal instant payment notification service has been notified.
        /// </summary>
        bool? PayPalCustomerNotified
        { get; set; }

        /// <summary>
        /// Gets or sets the protection code.
        /// </summary>
        string ProtectCode
        { get; set; }

        /// <summary>
        /// Gets or sets the associated quote address.
        /// </summary>
        IQuoteAddress QuoteAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the associated quote.
        /// </summary>
        IQuote Quote
        { get; set; }

        /// <summary>
        /// Gets the child ID for this entity.
        /// </summary>
        string ChildID
        { get; set; }

        /// <summary>
        /// Gets the child ID for this entity.
        /// </summary>
        string ChildRealID
        { get; set; }

        /// <summary>
        /// Gets the parent ID for this entity.
        /// </summary>
        string ParentID
        { get; set; }

        /// <summary>
        /// Gets the parent ID for this entity.
        /// </summary>
        string ParentRealID
        { get; set; }

        /// <summary>
        /// Gets or sets the remote IP address of the machine who created the sales order request.
        /// </summary>
        string RemoteIP
        { get; set; }

        /// <summary>
        /// Gets or sets the reward currency amount.
        /// </summary>
        decimal? RewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the reward points balance at the time of the sales order.
        /// </summary>
        int? RewardPointsBalance
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of reward points that were refunded.
        /// </summary>
        int? RewardPointsBalanceRefund
        { get; set; }

        /// <summary>
        /// Gets or sets the reward currency amount refunded total.
        /// </summary>
        decimal? RewardCurrencyAmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the reward currency amount invoiced.
        /// </summary>
        decimal? RewardCurrencyAmountInvoiced
        { get; set; }

        /// <summary>
        /// Indicates whether an e-mail should be dispatched about the sales order.
        /// </summary>
        bool? SendEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping address for the sales order.
        /// </summary>
        ISalesOrderAddress ShippingAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount.
        /// </summary>
        decimal? ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the canceled shipping amount.
        /// </summary>
        decimal? ShippingCanceled
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
        /// Gets or sets the total shipping amount including tax.
        /// </summary>
        decimal? ShippingIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping amount that was invoiced.
        /// </summary>
        decimal? ShippingInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method.
        /// </summary>
        string ShippingMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping refund amount.
        /// </summary>
        decimal? ShippingRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount.
        /// </summary>
        decimal? ShippingTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount that was refunded.
        /// </summary>
        decimal? ShippingTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the state of the sales order.
        /// </summary>
        string State
        { get; set; }

        /// <summary>
        /// Gets or sets the status of the sales order.
        /// </summary>
        string Status
        { get; set; }

        /// <summary>
        /// Gets or sets the store currency code.
        /// </summary>
        string StoreCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the store that generated the sales order.
        /// </summary>
        IStore Store
        { get; set; }

        /// <summary>
        /// Gets or sets the store name.
        /// </summary>
        string StoreName
        { get; set; }

        /// <summary>
        /// Gets or sets the store to base rate.
        /// </summary>
        decimal? StoreToBaseRate
        { get; set; }

        /// <summary>
        /// Gets or sets the store to order rate.
        /// </summary>
        decimal? StoreToOrderRate
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal.
        /// </summary>
        decimal? Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal that was canceled.
        /// </summary>
        decimal? SubtotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including tax.
        /// </summary>
        decimal? SubtotalIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal that was invoiced.
        /// </summary>
        decimal? SubtotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal that was refunded.
        /// </summary>
        decimal? SubtotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        decimal? TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount that was canceled.
        /// </summary>
        decimal? TaxCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount that was invoiced.
        /// </summary>
        decimal? TaxInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount that was refunded.
        /// </summary>
        decimal? TaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount that was canceled.
        /// </summary>
        decimal? TotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount due.
        /// </summary>
        decimal? TotalDue
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount invoiced.
        /// </summary>
        decimal? TotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items on the sales order.
        /// </summary>
        ushort TotalItemCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded offline.
        /// </summary>
        decimal? TotalRefundedOffline
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded online.
        /// </summary>
        decimal? TotalRefundedOnline
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount paid.
        /// </summary>
        decimal? TotalPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity ordered.
        /// </summary>
        decimal? TotalQuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded.
        /// </summary>
        decimal? TotalRefunded
        { get; set; }

        /// <summary>
        /// Gets the date/time the entity was updated.
        /// </summary>
        Instant UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the total weight of the items on the sales order.
        /// </summary>
        decimal? Weight
        { get; set; }

        /// <summary>
        /// Gets or sets who the transaction was forwarded for.
        /// </summary>
        string TransactionForwardedFor
        { get; set; }
    }
}

