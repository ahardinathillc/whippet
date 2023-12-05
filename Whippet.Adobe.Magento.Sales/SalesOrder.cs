using System;
using System.Net;
using NodaTime;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.SalesRule;
using Athi.Whippet.Adobe.Magento.Customer.Addressing;
using Athi.Whippet.Adobe.Magento.Customer.Addressing.Extensions;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Athi.Whippet.Adobe.Magento.Payment;
using Athi.Whippet.Adobe.Magento.Sales.Addressing;
using Athi.Whippet.Adobe.Magento.Sales.Taxes;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;
using MagentoStore = Athi.Whippet.Adobe.Magento.Store.Store;
using MagentoGiftCard = Athi.Whippet.Adobe.Magento.GiftCard.GiftCard;
using MagentoGiftMessage = Athi.Whippet.Adobe.Magento.GiftMessage.GiftMessage;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a sales order in Magento.
    /// </summary>
    public class SalesOrder : MagentoRestEntity<SalesOrderInterface>, IMagentoEntity, ISalesOrder, IEqualityComparer<ISalesOrder>, IMagentoAuditableEntity, IMagentoRestEntity, IMagentoRestEntity<SalesOrderInterface>
    {
        private SalesOrderAddress _billingAddress;
        private SalesOrderAddress _quoteAddress;
        private SalesOrderPayment _payment;
        private CustomerGroup _group;
        private MagentoCustomer _customer;
        private MagentoStore _store;
        
        /// <summary>
        /// Gets or sets the negative adjustment value.
        /// </summary>
        public virtual decimal NegativeAdjustment
        { get; set; }

        /// <summary>
        /// Gets or sets the positive adjustment value.
        /// </summary>
        public virtual decimal PositiveAdjustment
        { get; set; }

        /// <summary>
        /// Gets or sets the applied rule IDs.
        /// </summary>
        public virtual IEnumerable<ISalesRule> AppliedRuleIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the negative adjustment value in base currency.
        /// </summary>
        public virtual decimal NegativeAdjustmentBase
        { get; set; }

        /// <summary>
        /// Gets or sets the positive adjustment value in base currency.
        /// </summary>
        public virtual decimal PositiveAdjustmentBase
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code.
        /// </summary>
        public virtual string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount in base currency.
        /// </summary>
        public virtual decimal DiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount canceled in base currency.
        /// </summary>
        public virtual decimal DiscountCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount invoiced in base currency.
        /// </summary>
        public virtual decimal DiscountInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount refunded in base currency.
        /// </summary>
        public virtual decimal DiscountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total amount in base currency.
        /// </summary>
        public virtual decimal GrandTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax compensation amount in base currency.
        /// </summary>
        public virtual decimal DiscountTaxCompensationAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax compensation invoiced amount in base currency.
        /// </summary>
        public virtual decimal DiscountTaxCompensationInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax compensation refunded amount in base currency.
        /// </summary>
        public virtual decimal DiscountTaxCompensationRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in base currency.
        /// </summary>
        public virtual decimal ShippingAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount canceled in base currency.
        /// </summary>
        public virtual decimal ShippingCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount in base currency.
        /// </summary>
        public virtual decimal ShippingDiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount in base currency.
        /// </summary>
        public virtual decimal ShippingDiscountTaxCompensationAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount including tax in base currency.
        /// </summary>
        public virtual decimal ShippingWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount invoiced in base currency.
        /// </summary>
        public virtual decimal ShippingInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded in base currency.
        /// </summary>
        public virtual decimal ShippingRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount in base currency.
        /// </summary>
        public virtual decimal ShippingTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax refunded amount in base currency.
        /// </summary>
        public virtual decimal ShippingTaxRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount in base currency.
        /// </summary>
        public virtual decimal SubtotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount canceled in base currency.
        /// </summary>
        public virtual decimal SubtotalCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount including tax in base currency.
        /// </summary>
        public virtual decimal SubtotalWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount invoiced in base currency.
        /// </summary>
        public virtual decimal SubtotalInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount refunded in base currency.
        /// </summary>
        public virtual decimal SubtotalRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in base currency.
        /// </summary>
        public virtual decimal TaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount canceled in base currency.
        /// </summary>
        public virtual decimal TaxCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount invoiced in base currency.
        /// </summary>
        public virtual decimal TaxInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount refunded in base currency.
        /// </summary>
        public virtual decimal TaxRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount canceled in base currency.
        /// </summary>
        public virtual decimal TaxCanceledTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount due in base currency.
        /// </summary>
        public virtual decimal TotalDueBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount invoiced in base currency.
        /// </summary>
        public virtual decimal TotalInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total invoiced cost amount in base currency.
        /// </summary>
        public virtual decimal TotalInvoicedCostBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total refunded amount (offline) in base currency.
        /// </summary>
        public virtual decimal TotalOfflineRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total refunded amount (online) in base currency.
        /// </summary>
        public virtual decimal TotalOnlineRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount paid in base currency.
        /// </summary>
        public virtual decimal TotalPaidBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity ordered in base currency.
        /// </summary>
        public virtual decimal TotalQuantityOrderedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded in base currency.
        /// </summary>
        public virtual decimal TotalRefundBase
        { get; set; }

        /// <summary>
        /// Gets or sets the base-to-global rate.
        /// </summary>
        public virtual decimal BaseToGlobalRate
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the order can be shipped partially. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual int CanShipPartially
        { get; set; }

        /// <summary>
        /// Flag that indicates whether an item can be shipped partially. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual int CanShipItemPartially
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code associated with the order.
        /// </summary>
        public virtual string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was created.
        /// </summary>
        public virtual Instant CreatedTimestamp
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group.
        /// </summary>
        public virtual CustomerGroup CustomerGroup
        {
            get
            {
                if (_group == null)
                {
                    _group = new CustomerGroup();
                }

                return _group;
            }
            set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer associated with the order.
        /// </summary>
        public virtual MagentoCustomer Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new MagentoCustomer();
                }

                return _customer;
            }
            set
            {
                _customer = value;
            }
        }
        
        /// <summary>
        /// Flag that indicates whether the customer is a guest and not registered. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual int CustomerIsGuest
        { get; set; }

        /// <summary>
        /// Gets or sets the notice text.
        /// </summary>
        public virtual string Notice
        { get; set; }

        /// <summary>
        /// Gets or sets the customer notification flag.
        /// </summary>
        public virtual bool NotifyNotice
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        public virtual decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount canceled amount.
        /// </summary>
        public virtual decimal DiscountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the discount description.
        /// </summary>
        public virtual decimal DiscountDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount invoiced.
        /// </summary>
        public virtual decimal DiscountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount refunded amount.
        /// </summary>
        public virtual decimal DiscountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the edit increment value.
        /// </summary>
        public virtual int EditIncrement
        { get; set; }

        /// <summary>
        /// Indicates whether an e-mail was sent to the customer.
        /// </summary>
        public virtual bool EmailSent
        { get; set; }
        
        /// <summary>
        /// Gets or sets the external customer ID.
        /// </summary>
        public virtual string ExternalCustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the external order ID.
        /// </summary>
        public virtual string ExternalOrderID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the order is shipped regardless of the status of the invoice. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        public virtual int ForcedShipmentWithInvoice
        { get; set; }

        /// <summary>
        /// Gets or sets the global currency code.
        /// </summary>
        public virtual string GlobalCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total of the invoice.
        /// </summary>
        public virtual decimal GrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount.
        /// </summary>
        public virtual decimal DiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation invoiced.
        /// </summary>
        public virtual decimal DiscountTaxCompensationInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation refunded.
        /// </summary>
        public virtual decimal DiscountTaxCompensationRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the hold before state.
        /// </summary>
        public virtual string HoldBeforeState
        { get; set; }

        /// <summary>
        /// Gets or sets the hold before status.
        /// </summary>
        public virtual string HoldBeforeStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the increment ID.
        /// </summary>
        public virtual string IncrementID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the order is virtual. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>. 
        /// </summary>
        public virtual int IsVirtual
        { get; set; }

        /// <summary>
        /// Gets or sets the order currency code.
        /// </summary>
        public virtual string OrderCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the original order increment ID.
        /// </summary>
        public virtual string OriginalIncrementID
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization amount.
        /// </summary>
        public virtual decimal PaymentAuthorizationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization expiration date.
        /// </summary>
        public virtual int PaymentAuthorizationExpirationDate
        { get; set; }

        /// <summary>
        /// Gets or sets the protect code of the order.
        /// </summary>
        public virtual string ProtectCode
        { get; set; }

        /// <summary>
        /// Gets or sets the quote address.
        /// </summary>
        public virtual SalesOrderAddress QuoteAddress
        {
            get
            {
                if (_quoteAddress == null)
                {
                    _quoteAddress = new SalesOrderAddress();
                }

                return _quoteAddress;
            }
            set
            {
                _quoteAddress = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the quote ID.
        /// </summary>
        public virtual int QuoteID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation child's ID.
        /// </summary>
        public virtual string RelationChildID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation child's real ID.
        /// </summary>
        public virtual string RelationChildRealID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation parent's ID.
        /// </summary>
        public virtual string RelationParentID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation parent's real ID.
        /// </summary>
        public virtual string RelationParentRealID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's remote IP address.
        /// </summary>
        public virtual IPAddress? RemoteIP
        { get; set; }
        
        /// <summary>
        /// Gets or sets the shipping amount.
        /// </summary>
        public virtual decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping canceled amount.
        /// </summary>
        public virtual decimal ShippingCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping description.
        /// </summary>
        public virtual string ShippingDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount. 
        /// </summary>
        public virtual decimal ShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount.
        /// </summary>
        public virtual decimal ShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping including tax amount.
        /// </summary>
        public virtual decimal ShippingWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping including tax refund amount.
        /// </summary>
        public virtual decimal ShippingTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        public virtual string Status
        { get; set; }

        /// <summary>
        /// Gets or sets the store currency code.
        /// </summary>
        public virtual string StoreCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the store the order is associated with.
        /// </summary>
        public virtual MagentoStore Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new MagentoStore();
                }

                return _store;
            }
            set
            {
                _store = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the store-to-base rate.
        /// </summary>
        public virtual decimal StoreToBaseRate
        { get; set; }

        /// <summary>
        /// Gets or sets the store-to-order rate.
        /// </summary>
        public virtual decimal StoreToOrderRate
        { get; set; }

        /// <summary>
        /// Gets or sets the order subtotal.
        /// </summary>
        public virtual decimal Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal canceled amount.
        /// </summary>
        public virtual decimal SubtotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including tax amount.
        /// </summary>
        public virtual decimal SubtotalWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal invoiced amount.
        /// </summary>
        public virtual decimal SubtotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount refunded.
        /// </summary>
        public virtual decimal SubtotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        public virtual decimal TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the amount of tax canceled.
        /// </summary>
        public virtual decimal TaxCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount invoiced.
        /// </summary>
        public virtual decimal TaxInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount refunded.
        /// </summary>
        public virtual decimal TaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total canceled amount.
        /// </summary>
        public virtual decimal TotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount due. 
        /// </summary>
        public virtual decimal TotalDue
        { get; set; }

        /// <summary>
        /// Gets or sets the total invoiced amount.
        /// </summary>
        public virtual decimal TotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items on the order.
        /// </summary>
        public virtual int TotalItemCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded offline.
        /// </summary>
        public virtual decimal TotalOfflineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded online.
        /// </summary>
        public virtual decimal TotalOnlineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount paid on the order.
        /// </summary>
        public virtual decimal TotalPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity ordered.
        /// </summary>
        public virtual decimal TotalQuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded.
        /// </summary>
        public virtual decimal TotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the entity was last updated (if any).
        /// </summary>
        public virtual Instant? UpdatedTimestamp
        { get; set; }
        
        /// <summary>
        /// Gets or sets the order weight.
        /// </summary>
        public virtual decimal Weight
        { get; set; }

        /// <summary>
        /// Gets or sets the transaction forwarded for (X-Forwarded-For) field.
        /// </summary>
        public virtual string TransactionForwardedFor
        { get; set; }

        /// <summary>
        /// Gets or sets the items associated with the order.
        /// </summary>
        public virtual IEnumerable<SalesOrderItem> Items
        { get; set; }

        /// <summary>
        /// Gets or sets the billing address associated with the order.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        public virtual SalesOrderAddress BillingAddress
        {
            get
            {
                if (_billingAddress == null)
                {
                    _billingAddress = new SalesOrderAddress();
                }

                return _billingAddress;
            }
            set
            {
                _billingAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the payment information for the order.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        public virtual SalesOrderPayment Payment
        {
            get
            {
                if (_payment == null)
                {
                    _payment = new SalesOrderPayment();
                }

                return _payment;
            }
            set
            {
                _payment = value;
            }
        }

        /// <summary>
        /// Gets or sets the status histories of the current order.
        /// </summary>
        public virtual IEnumerable<SalesOrderStatusHistory> StatusHistories
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping assignments for the order.
        /// </summary>
        public virtual IEnumerable<SalesOrderShippingAssignment> ShippingAssignments
        { get; set; }
        
        /// <summary>
        /// Gets or sets additional information concerning the payment of the order.
        /// </summary>
        public virtual IEnumerable<PaymentAdditionalInfo> PaymentAdditionalInformation
        { get; set; }
        
        /// <summary>
        /// Gets or sets the order's applied taxes.
        /// </summary>
        public virtual IEnumerable<SalesOrderItemTaxDetails> Taxes
        { get; set; }
        
        /// <summary>
        /// Gets or sets the order's individual taxes applied to each line item.
        /// </summary>
        public virtual IEnumerable<SalesOrderItemTaxDetails> ItemTaxes
        { get; set; }

        /// <summary>
        /// Specifies whether the sales order is a conversion from an existing quote.
        /// </summary>
        public virtual bool ConvertingFromQuote
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance amount in the base currency.
        /// </summary>
        public virtual decimal BaseCustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance amount.
        /// </summary>
        public virtual decimal CustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer amount that was invoiced in the base currency.
        /// </summary>
        public virtual decimal BaseCustomerBalanceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the customer amount that was invoiced.
        /// </summary>
        public virtual decimal CustomerBalanceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance that was refunded in the base currency.
        /// </summary>
        public virtual decimal BaseCustomerBalanceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance that was refunded.
        /// </summary>
        public virtual decimal CustomerBalanceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total customer balance that was refunded in base currency.
        /// </summary>
        public virtual decimal BaseCustomerBalanceTotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total customer balance that was refunded.
        /// </summary>
        public virtual decimal CustomerBalanceTotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards associated with the order.
        /// </summary>
        public virtual IEnumerable<MagentoGiftCard> GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards total amount in base currency.
        /// </summary>
        public virtual decimal BaseGiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards total amount.
        /// </summary>
        public virtual decimal GiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount invoiced for gift cards in base currency.
        /// </summary>
        public virtual decimal BaseGiftCardsInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount invoiced for gift cards.
        /// </summary>
        public virtual decimal GiftCardsInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded for gift cards in base currency.
        /// </summary>
        public virtual decimal BaseGiftCardsRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded for gift cards.
        /// </summary>
        public virtual decimal GiftCardsRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift message applied to the order.
        /// </summary>
        public virtual MagentoGiftMessage GiftMessage
        { get; set; }

                /// <summary>
        /// Gets or sets the gift wrap ID.
        /// </summary>
        public virtual string _GiftWrapID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap price in base currency.
        /// </summary>
        public virtual string _GiftWrapPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price.
        /// </summary>
        public virtual string _GiftWrapPrice
        { get; set; }
                
        /// <summary>
        /// Gets or sets the gift wrap tax amount in base currency.
        /// </summary>
        public virtual string _GiftWrapTaxAmountBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap tax amount.
        /// </summary>
        public virtual string _GiftWrapTaxAmount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap price invoiced in base currency.
        /// </summary>
        public virtual string _GiftWrapPriceInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price invoiced.
        /// </summary>
        public virtual string _GiftWrapPriceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced in base currency.
        /// </summary>
        public virtual string _GiftWrapTaxAmountInvoicedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced.
        /// </summary>
        public virtual string _GiftWrapTaxAmountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded in base currency.
        /// </summary>
        public virtual string _GiftWrapPriceRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded.
        /// </summary>
        public virtual string _GiftWrapPriceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded in base currency.
        /// </summary>
        public virtual string _GiftWrapTaxAmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded.
        /// </summary>
        public virtual string _GiftWrapTaxAmountRefunded
        { get; set; }       
        
        /// <summary>
        /// Specifies whether the customer should be notified of any order status changes or updates.
        /// </summary>
        public virtual bool SendNotification
        { get; set; }

        /// <summary>
        /// Gets or sets the rewards points balance.
        /// </summary>
        public virtual int RewardPointsBalance
        { get; set; }        

        /// <summary>
        /// Gets or sets the reward currency amount.
        /// </summary>
        public virtual decimal RewardCurrencyAmount
        { get; set; }        

        /// <summary>
        /// Gets or sets the reward currency amount in base currency.
        /// </summary>
        public virtual decimal RewardCurrencyAmountBase
        { get; set; }        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrder"/> class with no arguments.
        /// </summary>
        public SalesOrder()
            : base()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrder"/> class with the specified ID.
        /// </summary>
        /// <param name="entityId">ID to assign the <see cref="MagentoEntity"/> object.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesOrder(uint entityId, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(entityId, server, restEndpoint)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrder"/> class with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to initialize a new instance of the class with.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        /// <param name="restEndpoint"><see cref="MagentoRestEndpoint"/> the entity resides on.</param>
        public SalesOrder(SalesOrderInterface model, MagentoServer server = null, MagentoRestEndpoint restEndpoint = null)
            : base(model, server, restEndpoint)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj == null) || !(obj is ISalesOrder)) ? false : Equals((ISalesOrder)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrder obj)
        {
            return (obj == null) ? false : Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals(ISalesOrder x, ISalesOrder y)
        {
            bool equals = (x == null) && (y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = x.ID == y.ID
                            && String.Equals(x.Code?.Trim(), y.Code?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                            && x.Amount == y.Amount
                            && x.BaseAmount == y.BaseAmount
                            && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                            && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="GiftCardInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="GiftCardInterface"/>.</returns>
        public override SalesOrderInterface ToInterface()
        {
            GiftCardInterface gcInterface = new GiftCardInterface();

            gcInterface.ID = ID;
            gcInterface.Code = Code;
            gcInterface.Amount = Amount;
            gcInterface.AmountBase = BaseAmount;
            
            return gcInterface;
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public override object Clone()
        {
            SalesOrder order = new SalesOrder();
            
            return order;
        }

        /// <summary>
        /// Gets the hash code of the current instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            return hash.ToHashCode();
        }

        /// <summary>
        /// Gets the hash code of the specified object.
        /// </summary>
        /// <param name="order"><see cref="ISalesOrder"/> object to get hash code for.</param>
        /// <returns>Hash code.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesOrder order)
        {
            ArgumentNullException.ThrowIfNull(order);
            return order.GetHashCode();
        }
        
        /// <summary>
        /// Constructs the current instance with the specified <see cref="IExtensionInterface"/> object.
        /// </summary>
        /// <param name="model"><see cref="IExtensionInterface"/> object to construct the current instance from.</param>
        protected override void ImportFromModel(SalesOrderInterface model)
        {
            if (model != null)
            {
                ID = model.ID;
            }
        }

    }
}
