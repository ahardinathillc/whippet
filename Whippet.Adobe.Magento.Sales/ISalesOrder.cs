using System;
using System.Net;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.SalesRule;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Athi.Whippet.Adobe.Magento.Payment;
using Athi.Whippet.Adobe.Magento.Sales.Addressing;
using Athi.Whippet.Adobe.Magento.Sales.Taxes;
using Athi.Whippet.Adobe.Magento.Store;
using MagentoGiftMessage = Athi.Whippet.Adobe.Magento.GiftMessage.GiftMessage;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    public interface ISalesOrder : IMagentoEntity, IEqualityComparer<ISalesOrder>, IMagentoAuditableEntity, IMagentoRestEntity, IMagentoRestEntity<SalesOrderInterface>
    {
        /// <summary>
        /// Gets or sets the negative adjustment value.
        /// </summary>
        decimal NegativeAdjustment
        { get; set; }

        /// <summary>
        /// Gets or sets the positive adjustment value.
        /// </summary>
        decimal PositiveAdjustment
        { get; set; }

        /// <summary>
        /// Gets or sets the applied rules.
        /// </summary>
        IEnumerable<ISalesRule> AppliedRules
        { get; set; }

        /// <summary>
        /// Gets or sets the negative adjustment value in base currency.
        /// </summary>
        decimal NegativeAdjustmentBase
        { get; set; }

        /// <summary>
        /// Gets or sets the positive adjustment value in base currency.
        /// </summary>
        decimal PositiveAdjustmentBase
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code.
        /// </summary>
        string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount in base currency.
        /// </summary>
        decimal DiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount canceled in base currency.
        /// </summary>
        decimal DiscountCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount invoiced in base currency.
        /// </summary>
        decimal DiscountInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount refunded in base currency.
        /// </summary>
        decimal DiscountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total amount in base currency.
        /// </summary>
        decimal GrandTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax compensation amount in base currency.
        /// </summary>
        decimal DiscountTaxCompensationAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax compensation invoiced amount in base currency.
        /// </summary>
        decimal DiscountTaxCompensationInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax compensation refunded amount in base currency.
        /// </summary>
        decimal DiscountTaxCompensationRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in base currency.
        /// </summary>
        decimal ShippingAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount canceled in base currency.
        /// </summary>
        decimal ShippingCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount in base currency.
        /// </summary>
        decimal ShippingDiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount in base currency.
        /// </summary>
        decimal ShippingDiscountTaxCompensationAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount including tax in base currency.
        /// </summary>
        decimal ShippingWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount invoiced in base currency.
        /// </summary>
        decimal ShippingInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded in base currency.
        /// </summary>
        decimal ShippingRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount in base currency.
        /// </summary>
        decimal ShippingTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax refunded amount in base currency.
        /// </summary>
        decimal ShippingTaxRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount in base currency.
        /// </summary>
        decimal SubtotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount canceled in base currency.
        /// </summary>
        decimal SubtotalCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount including tax in base currency.
        /// </summary>
        decimal SubtotalWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount invoiced in base currency.
        /// </summary>
        decimal SubtotalInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount refunded in base currency.
        /// </summary>
        decimal SubtotalRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in base currency.
        /// </summary>
        decimal TaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount canceled in base currency.
        /// </summary>
        decimal TaxCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount invoiced in base currency.
        /// </summary>
        decimal TaxInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount refunded in base currency.
        /// </summary>
        decimal TaxRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount canceled in base currency.
        /// </summary>
        decimal TaxCanceledTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount due in base currency.
        /// </summary>
        decimal TotalDueBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount invoiced in base currency.
        /// </summary>
        decimal TotalInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total invoiced cost amount in base currency.
        /// </summary>
        decimal TotalInvoicedCostBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total refunded amount (offline) in base currency.
        /// </summary>
        decimal TotalOfflineRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total refunded amount (online) in base currency.
        /// </summary>
        decimal TotalOnlineRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount paid in base currency.
        /// </summary>
        decimal TotalPaidBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity ordered in base currency.
        /// </summary>
        decimal TotalQuantityOrderedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded in base currency.
        /// </summary>
        decimal TotalRefundBase
        { get; set; }

        /// <summary>
        /// Gets or sets the base-to-global rate.
        /// </summary>
        decimal BaseToGlobalRate
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the order can be shipped partially. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        int CanShipPartially
        { get; set; }

        /// <summary>
        /// Flag that indicates whether an item can be shipped partially. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        int CanShipItemPartially
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code associated with the order.
        /// </summary>
        string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was created.
        /// </summary>
        Instant CreatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group.
        /// </summary>
        ICustomerGroup CustomerGroup
        { get; set; }

        /// <summary>
        /// Gets or sets the customer associated with the order.
        /// </summary>
        ICustomer Customer
        { get; set; }
        
        /// <summary>
        /// Specifies whether the customer is a guest and not registered.
        /// </summary>
        bool CustomerIsGuest
        { get; set; }

        /// <summary>
        /// Gets or sets the notice text.
        /// </summary>
        string Notice
        { get; set; }

        /// <summary>
        /// Gets or sets the customer notification flag.
        /// </summary>
        bool NotifyNotice
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount canceled amount.
        /// </summary>
        decimal DiscountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the discount description.
        /// </summary>
        string DiscountDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount invoiced.
        /// </summary>
        decimal DiscountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount refunded amount.
        /// </summary>
        decimal DiscountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the edit increment value.
        /// </summary>
        int EditIncrement
        { get; set; }

        /// <summary>
        /// Indicates whether an e-mail was sent to the customer.
        /// </summary>
        bool EmailSent
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
        /// Specifies whether the order is shipped regardless of the status of the invoice.
        /// </summary>
        bool ForcedShipmentWithInvoice
        { get; set; }

        /// <summary>
        /// Gets or sets the global currency code.
        /// </summary>
        string GlobalCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total of the invoice.
        /// </summary>
        decimal GrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount.
        /// </summary>
        decimal DiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation invoiced.
        /// </summary>
        decimal DiscountTaxCompensationInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation refunded.
        /// </summary>
        decimal DiscountTaxCompensationRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the hold before state.
        /// </summary>
        string HoldBeforeState
        { get; set; }

        /// <summary>
        /// Gets or sets the hold before status.
        /// </summary>
        string HoldBeforeStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the increment ID.
        /// </summary>
        string IncrementID
        { get; set; }

        /// <summary>
        /// Specifies whether the order is virtual. 
        /// </summary>
        bool IsVirtual
        { get; set; }

        /// <summary>
        /// Gets or sets the order currency code.
        /// </summary>
        string OrderCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the original order increment ID.
        /// </summary>
        string OriginalIncrementID
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization amount.
        /// </summary>
        decimal PaymentAuthorizationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization expiration date.
        /// </summary>
        int PaymentAuthorizationExpirationDate
        { get; set; }

        /// <summary>
        /// Gets or sets the protect code of the order.
        /// </summary>
        string ProtectCode
        { get; set; }

        /// <summary>
        /// Gets or sets the quote address.
        /// </summary>
        ISalesOrderAddress QuoteAddress
        { get; set; }
        
        /// <summary>
        /// Gets or sets the quote ID.
        /// </summary>
        int QuoteID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation child's ID.
        /// </summary>
        string RelationChildID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation child's real ID.
        /// </summary>
        string RelationChildRealID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation parent's ID.
        /// </summary>
        string RelationParentID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation parent's real ID.
        /// </summary>
        string RelationParentRealID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's remote IP address.
        /// </summary>
        IPAddress RemoteIP
        { get; set; }
        
        /// <summary>
        /// Gets or sets the shipping amount.
        /// </summary>
        decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping canceled amount.
        /// </summary>
        decimal ShippingCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping description.
        /// </summary>
        string ShippingDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount. 
        /// </summary>
        decimal ShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount.
        /// </summary>
        decimal ShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping including tax amount.
        /// </summary>
        decimal ShippingWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping including tax refund amount.
        /// </summary>
        decimal ShippingTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        string Status
        { get; set; }

        /// <summary>
        /// Gets or sets the store currency code.
        /// </summary>
        string StoreCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the store the order is associated with.
        /// </summary>
        IStore Store
        { get; set; }
        
        /// <summary>
        /// Gets or sets the store-to-base rate.
        /// </summary>
        decimal StoreToBaseRate
        { get; set; }

        /// <summary>
        /// Gets or sets the store-to-order rate.
        /// </summary>
        decimal StoreToOrderRate
        { get; set; }

        /// <summary>
        /// Gets or sets the order subtotal.
        /// </summary>
        decimal Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal canceled amount.
        /// </summary>
        decimal SubtotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including tax amount.
        /// </summary>
        decimal SubtotalWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal invoiced amount.
        /// </summary>
        decimal SubtotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount refunded.
        /// </summary>
        decimal SubtotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        decimal TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the amount of tax canceled.
        /// </summary>
        decimal TaxCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount invoiced.
        /// </summary>
        decimal TaxInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount refunded.
        /// </summary>
        decimal TaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total canceled amount.
        /// </summary>
        decimal TotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount due. 
        /// </summary>
        decimal TotalDue
        { get; set; }

        /// <summary>
        /// Gets or sets the total invoiced amount.
        /// </summary>
        decimal TotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items on the order.
        /// </summary>
        int TotalItemCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded offline.
        /// </summary>
        decimal TotalOfflineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded online.
        /// </summary>
        decimal TotalOnlineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount paid on the order.
        /// </summary>
        decimal TotalPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity ordered.
        /// </summary>
        decimal TotalQuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded.
        /// </summary>
        decimal TotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was last updated (if any).
        /// </summary>
        Instant? UpdatedTimestamp
        { get; set; }
        
        /// <summary>
        /// Gets or sets the order weight.
        /// </summary>
        decimal Weight
        { get; set; }

        /// <summary>
        /// Gets or sets the transaction forwarded for (X-Forwarded-For) field.
        /// </summary>
        string TransactionForwardedFor
        { get; set; }

        /// <summary>
        /// Gets or sets the items associated with the order.
        /// </summary>
        IEnumerable<ISalesOrderItem> Items
        { get; set; }

        /// <summary>
        /// Gets or sets the billing address associated with the order.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        ISalesOrderAddress BillingAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the payment information for the order.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        ISalesOrderPayment Payment
        { get; set; }

        /// <summary>
        /// Gets or sets the status histories of the current order.
        /// </summary>
        IEnumerable<SalesOrderStatusHistory> StatusHistories
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping assignments for the order.
        /// </summary>
        IEnumerable<SalesOrderShippingAssignment> ShippingAssignments
        { get; set; }
        
        /// <summary>
        /// Gets or sets additional information concerning the payment of the order.
        /// </summary>
        IEnumerable<PaymentAdditionalInfo> PaymentAdditionalInformation
        { get; set; }
        
        /// <summary>
        /// Gets or sets the order's applied taxes.
        /// </summary>
        IEnumerable<SalesOrderItemTaxDetails> Taxes
        { get; set; }
        
        /// <summary>
        /// Gets or sets the order's individual taxes applied to each line item.
        /// </summary>
        IEnumerable<SalesOrderItemTaxDetails> ItemTaxes
        { get; set; }

        /// <summary>
        /// Specifies whether the sales order is a conversion from an existing quote.
        /// </summary>
        bool ConvertingFromQuote
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance amount in the base currency.
        /// </summary>
        decimal BaseCustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance amount.
        /// </summary>
        decimal CustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer amount that was invoiced in the base currency.
        /// </summary>
        decimal BaseCustomerBalanceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the customer amount that was invoiced.
        /// </summary>
        decimal CustomerBalanceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance that was refunded in the base currency.
        /// </summary>
        decimal BaseCustomerBalanceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance that was refunded.
        /// </summary>
        decimal CustomerBalanceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total customer balance that was refunded in base currency.
        /// </summary>
        decimal BaseCustomerBalanceTotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total customer balance that was refunded.
        /// </summary>
        decimal CustomerBalanceTotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards associated with the order.
        /// </summary>
        IEnumerable<IGiftCard> GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards total amount in base currency.
        /// </summary>
        decimal BaseGiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards total amount.
        /// </summary>
        decimal GiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount invoiced for gift cards in base currency.
        /// </summary>
        decimal BaseGiftCardsInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount invoiced for gift cards.
        /// </summary>
        decimal GiftCardsInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded for gift cards in base currency.
        /// </summary>
        decimal BaseGiftCardsRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded for gift cards.
        /// </summary>
        decimal GiftCardsRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift message applied to the order.
        /// </summary>
        MagentoGiftMessage GiftMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap ID.
        /// </summary>
        string _GiftWrapID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap price in base currency.
        /// </summary>
        string _GiftWrapPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price.
        /// </summary>
        string _GiftWrapPrice
        { get; set; }
                
        /// <summary>
        /// Gets or sets the gift wrap tax amount in base currency.
        /// </summary>
        string _GiftWrapTaxAmountBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap tax amount.
        /// </summary>
        string _GiftWrapTaxAmount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap price invoiced in base currency.
        /// </summary>
        string _GiftWrapPriceInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price invoiced.
        /// </summary>
        string _GiftWrapPriceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced in base currency.
        /// </summary>
        string _GiftWrapTaxAmountInvoicedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced.
        /// </summary>
        string _GiftWrapTaxAmountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded in base currency.
        /// </summary>
        string _GiftWrapPriceRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded.
        /// </summary>
        string _GiftWrapPriceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded in base currency.
        /// </summary>
        string _GiftWrapTaxAmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded.
        /// </summary>
        string _GiftWrapTaxAmountRefunded
        { get; set; }       
        
        /// <summary>
        /// Specifies whether the customer should be notified of any order status changes or updates.
        /// </summary>
        bool SendNotification
        { get; set; }

        /// <summary>
        /// Gets or sets the rewards points balance.
        /// </summary>
        int RewardPointsBalance
        { get; set; }        

        /// <summary>
        /// Gets or sets the reward currency amount.
        /// </summary>
        decimal RewardCurrencyAmount
        { get; set; }        

        /// <summary>
        /// Gets or sets the reward currency amount in base currency.
        /// </summary>
        decimal RewardCurrencyAmountBase
        { get; set; }
    }
}
