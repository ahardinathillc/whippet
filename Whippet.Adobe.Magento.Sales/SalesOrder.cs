using System;
using System.Net;
using NodaTime;
using Athi.Whippet.Extensions;
using Athi.Whippet.Extensions.Primitives;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.SalesRule;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Extensions;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Athi.Whippet.Adobe.Magento.GiftCard.Extensions;
using Athi.Whippet.Adobe.Magento.Payment;
using Athi.Whippet.Adobe.Magento.Sales.Addressing;
using Athi.Whippet.Adobe.Magento.Sales.Addressing.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Taxes;
using Athi.Whippet.Adobe.Magento.SalesRule.Extensions;
using Athi.Whippet.Adobe.Magento.Store;
using Athi.Whippet.Adobe.Magento.Store.Extensions;
using MagentoSalesRule = Athi.Whippet.Adobe.Magento.SalesRule.SalesRule;
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
        /// Gets or sets the applied rules.
        /// </summary>
        public virtual IEnumerable<MagentoSalesRule> AppliedRules
        { get; set; }

        /// <summary>
        /// Gets or sets the applied rules.
        /// </summary>
        IEnumerable<ISalesRule> ISalesOrder.AppliedRules
        {
            get
            {
                return AppliedRules;
            }
            set
            {
                AppliedRules = (value == null) ? null : AppliedRules.Select(ar => ar.ToSalesRule());
            }
        }

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
        /// Gets or sets the customer group.
        /// </summary>
        ICustomerGroup ISalesOrder.CustomerGroup
        {
            get
            {
                return CustomerGroup;
            }
            set
            {
                CustomerGroup = value.ToCustomerGroup();
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
        /// Gets or sets the customer associated with the order.
        /// </summary>
        ICustomer ISalesOrder.Customer
        {
            get
            {
                return Customer;
            }
            set
            {
                Customer = value.ToCustomer();
            }
        }
        
        /// <summary>
        /// Specifies whether the customer is a guest and not registered.
        /// </summary>
        public virtual bool CustomerIsGuest
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
        public virtual string DiscountDescription
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
        /// Specifies whether the order is shipped regardless of the status of the invoice.
        /// </summary>
        public virtual bool ForcedShipmentWithInvoice
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
        /// Specifies whether the order is virtual. 
        /// </summary>
        public virtual bool IsVirtual
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
        /// Gets or sets the quote address.
        /// </summary>
        ISalesOrderAddress ISalesOrder.QuoteAddress
        {
            get
            {
                return QuoteAddress;
            }
            set
            {
                QuoteAddress = value.ToSalesOrderAddress();
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
        /// Gets or sets the store the order is associated with.
        /// </summary>
        IStore ISalesOrder.Store
        {
            get
            {
                return Store;
            }
            set
            {
                Store = value.ToStore();
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
        /// Gets or sets the items associated with the order.
        /// </summary>
        IEnumerable<ISalesOrderItem> ISalesOrder.Items
        {
            get
            {
                return Items;
            }
            set
            {
                Items = (value == null) ? null : value.Select(i => i.ToSalesOrderItem());
            }
        }
        
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
        /// Gets or sets the billing address associated with the order.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        ISalesOrderAddress ISalesOrder.BillingAddress
        {
            get
            {
                return BillingAddress;
            }
            set
            {
                BillingAddress = value.ToSalesOrderAddress();
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
        /// Gets or sets the payment information for the order.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        ISalesOrderPayment ISalesOrder.Payment
        {
            get
            {
                return Payment;
            }
            set
            {
                Payment = value.ToSalesOrderPayment();
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
        public virtual IEnumerable<SalesOrderAppliedTax> Taxes
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
        /// Gets or sets the gift cards associated with the order.
        /// </summary>
        IEnumerable<IGiftCard> ISalesOrder.GiftCards
        {
            get
            {
                return GiftCards;
            }
            set
            {
                GiftCards = (value == null) ? null : value.Select(gc => gc.ToGiftCard());
            }
        }
        
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
                         && x.NegativeAdjustment == y.NegativeAdjustment
                         && x.PositiveAdjustment == y.PositiveAdjustment
                         && (((x.AppliedRules == null) && (y.AppliedRules == null)) || ((x.AppliedRules != null) && x.AppliedRules.SequenceEqual(y.AppliedRules)))
                         && x.NegativeAdjustmentBase == y.NegativeAdjustmentBase
                         && x.PositiveAdjustmentBase == y.PositiveAdjustmentBase
                         && x.BaseCurrencyCode == y.BaseCurrencyCode
                         && x.DiscountAmountBase == y.DiscountAmountBase
                         && x.DiscountCanceledBase == y.DiscountCanceledBase
                         && x.DiscountInvoicedBase == y.DiscountInvoicedBase
                         && x.DiscountRefundedBase == y.DiscountRefundedBase
                         && x.GrandTotalBase == y.GrandTotalBase
                         && x.DiscountTaxCompensationAmountBase == y.DiscountTaxCompensationAmountBase
                         && x.DiscountTaxCompensationInvoicedBase == y.DiscountTaxCompensationInvoicedBase
                         && x.DiscountTaxCompensationRefundedBase == y.DiscountTaxCompensationRefundedBase
                         && x.ShippingAmountBase == y.ShippingAmountBase
                         && x.ShippingCanceledBase == y.ShippingCanceledBase
                         && x.ShippingDiscountAmountBase == y.ShippingDiscountAmountBase
                         && x.ShippingDiscountTaxCompensationAmountBase == y.ShippingDiscountTaxCompensationAmountBase
                         && x.ShippingWithTaxBase == y.ShippingWithTaxBase
                         && x.ShippingInvoicedBase == y.ShippingInvoicedBase
                         && x.ShippingRefundedBase == y.ShippingRefundedBase
                         && x.ShippingTaxAmountBase == y.ShippingTaxAmountBase
                         && x.ShippingTaxRefundedBase == y.ShippingTaxRefundedBase
                         && x.SubtotalBase == y.SubtotalBase
                         && x.SubtotalCanceledBase == y.SubtotalCanceledBase
                         && x.SubtotalWithTaxBase == y.SubtotalWithTaxBase
                         && x.SubtotalInvoicedBase == y.SubtotalInvoicedBase
                         && x.SubtotalRefundedBase == y.SubtotalRefundedBase
                         && x.TaxAmountBase == y.TaxAmountBase
                         && x.TaxCanceledBase == y.TaxCanceledBase
                         && x.TaxInvoicedBase == y.TaxInvoicedBase
                         && x.TaxRefundedBase == y.TaxRefundedBase
                         && x.TaxCanceledTotalBase == y.TaxCanceledTotalBase
                         && x.TotalDueBase == y.TotalDueBase
                         && x.TotalInvoicedBase == y.TotalInvoicedBase
                         && x.TotalInvoicedCostBase == y.TotalInvoicedCostBase
                         && x.TotalOfflineRefundedBase == y.TotalOfflineRefundedBase
                         && x.TotalOnlineRefundedBase == y.TotalOnlineRefundedBase
                         && x.TotalPaidBase == y.TotalPaidBase
                         && x.TotalQuantityOrderedBase == y.TotalQuantityOrderedBase
                         && x.TotalRefundBase == y.TotalRefundBase
                         && x.BaseToGlobalRate == y.BaseToGlobalRate
                         && x.CanShipPartially == y.CanShipPartially
                         && x.CanShipItemPartially == y.CanShipItemPartially
                         && String.Equals(x.CouponCode?.Trim(), y.CouponCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.CreatedTimestamp.Equals(y.CreatedTimestamp)
                         && (((x.CustomerGroup == null) && (y.CustomerGroup == null)) || ((x.CustomerGroup != null) && x.CustomerGroup.Equals(y.CustomerGroup)))
                         && (((x.Customer == null) && (y.Customer == null)) || ((x.Customer != null) && x.Customer.Equals(y.Customer)))
                         && x.CustomerIsGuest == y.CustomerIsGuest
                         && String.Equals(x.Notice?.Trim(), y.Notice?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.NotifyNotice == y.NotifyNotice
                         && x.DiscountAmount == y.DiscountAmount
                         && x.DiscountCanceled == y.DiscountCanceled
                         && String.Equals(x.DiscountDescription?.Trim(), y.DiscountDescription?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.DiscountInvoiced == y.DiscountInvoiced
                         && x.DiscountRefunded == y.DiscountRefunded
                         && x.EditIncrement == y.EditIncrement
                         && x.EmailSent == y.EmailSent
                         && String.Equals(x.ExternalCustomerID?.Trim(), y.ExternalCustomerID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.ExternalOrderID?.Trim(), y.ExternalOrderID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.ForcedShipmentWithInvoice == y.ForcedShipmentWithInvoice
                         && String.Equals(x.GlobalCurrencyCode?.Trim(), y.GlobalCurrencyCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.GrandTotal == y.GrandTotal
                         && x.DiscountTaxCompensationAmount == y.DiscountTaxCompensationAmount
                         && x.DiscountTaxCompensationInvoiced == y.DiscountTaxCompensationInvoiced
                         && x.DiscountTaxCompensationRefunded == y.DiscountTaxCompensationRefunded
                         && String.Equals(x.HoldBeforeState?.Trim(), y.HoldBeforeState?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.HoldBeforeStatus?.Trim(), y.HoldBeforeStatus?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.IncrementID?.Trim(), y.IncrementID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.IsVirtual == y.IsVirtual
                         && String.Equals(x.OrderCurrencyCode?.Trim(), y.OrderCurrencyCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.OriginalIncrementID?.Trim(), y.OriginalIncrementID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.PaymentAuthorizationAmount == y.PaymentAuthorizationAmount
                         && x.PaymentAuthorizationExpirationDate == y.PaymentAuthorizationExpirationDate
                         && String.Equals(x.ProtectCode?.Trim(), y.ProtectCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.QuoteAddress == null) && (y.QuoteAddress == null)) || ((x.QuoteAddress != null) && x.QuoteAddress.Equals(y.QuoteAddress)))
                         && x.QuoteID == y.QuoteID
                         && String.Equals(x.RelationChildID?.Trim(), y.RelationChildID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.RelationChildRealID?.Trim(), y.RelationChildRealID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.RelationParentID?.Trim(), y.RelationParentID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.RelationParentRealID?.Trim(), y.RelationParentRealID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.RemoteIP == null) && (y.RemoteIP == null)) || ((x.RemoteIP != null) && x.RemoteIP.Equals(y.RemoteIP)))
                         && x.ShippingAmount == y.ShippingAmount
                         && x.ShippingCanceled == y.ShippingCanceled
                         && String.Equals(x.ShippingDescription?.Trim(), y.ShippingDescription?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.ShippingDiscountAmount == y.ShippingDiscountAmount
                         && x.ShippingDiscountTaxCompensationAmount == y.ShippingDiscountTaxCompensationAmount
                         && x.ShippingWithTax == y.ShippingWithTax
                         && x.ShippingTaxRefunded == y.ShippingTaxRefunded
                         && String.Equals(x.Status?.Trim(), y.Status?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x.StoreCurrencyCode?.Trim(), y.StoreCurrencyCode?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Store == null) && (y.Store == null)) || ((x.Store != null) && x.Store.Equals(y.Store)))
                         && x.StoreToBaseRate == y.StoreToBaseRate
                         && x.StoreToOrderRate == y.StoreToOrderRate
                         && x.Subtotal == y.Subtotal
                         && x.SubtotalCanceled == y.SubtotalCanceled
                         && x.SubtotalWithTax == y.SubtotalWithTax
                         && x.SubtotalInvoiced == y.SubtotalInvoiced
                         && x.SubtotalRefunded == y.SubtotalRefunded
                         && x.TaxAmount == y.TaxAmount
                         && x.TaxCanceled == y.TaxCanceled
                         && x.TaxInvoiced == y.TaxInvoiced
                         && x.TaxRefunded == y.TaxRefunded
                         && x.TotalCanceled == y.TotalCanceled
                         && x.TotalDue == y.TotalDue
                         && x.TotalInvoiced == y.TotalInvoiced
                         && x.TotalItemCount == y.TotalItemCount
                         && x.TotalOfflineRefunded == y.TotalOfflineRefunded
                         && x.TotalOnlineRefunded == y.TotalOnlineRefunded
                         && x.TotalPaid == y.TotalPaid
                         && x.TotalQuantityOrdered == y.TotalQuantityOrdered
                         && x.TotalRefunded == y.TotalRefunded
                         && x.UpdatedTimestamp.GetValueOrDefault().Equals(y.UpdatedTimestamp.GetValueOrDefault())
                         && x.Weight == y.Weight
                         && String.Equals(x.TransactionForwardedFor?.Trim(), y.TransactionForwardedFor?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && (((x.Items == null) && (y.Items == null)) || ((x.Items != null) && x.Items.SequenceEqual(y.Items)))
                         && (((x.BillingAddress == null) && (y.BillingAddress == null)) || ((x.BillingAddress != null) && x.BillingAddress.Equals(y.BillingAddress)))
                         && (((x.Payment == null) && (y.Payment == null)) || ((x.Payment != null) && x.Payment.Equals(y.Payment)))
                         && (((x.StatusHistories == null) && (y.StatusHistories == null)) || ((x.StatusHistories != null) && x.StatusHistories.SequenceEqual(y.StatusHistories)))
                         && (((x.ShippingAssignments == null) && (y.ShippingAssignments == null)) || ((x.ShippingAssignments != null) && x.ShippingAssignments.SequenceEqual(y.ShippingAssignments)))
                         && (((x.PaymentAdditionalInformation == null) && (y.PaymentAdditionalInformation == null)) || ((x.PaymentAdditionalInformation != null) && x.PaymentAdditionalInformation.SequenceEqual(y.PaymentAdditionalInformation)))
                         && (((x.Taxes == null) && (y.Taxes == null)) || ((x.Taxes != null) && x.Taxes.SequenceEqual(y.Taxes)))
                         && (((x.ItemTaxes == null) && (y.ItemTaxes == null)) || ((x.ItemTaxes != null) && x.ItemTaxes.SequenceEqual(y.ItemTaxes)))
                         && x.ConvertingFromQuote == y.ConvertingFromQuote
                         && x.BaseCustomerBalanceAmount == y.BaseCustomerBalanceAmount
                         && x.CustomerBalanceAmount == y.CustomerBalanceAmount
                         && x.CustomerBalanceInvoiced == y.CustomerBalanceInvoiced
                         && x.BaseCustomerBalanceInvoiced == y.BaseCustomerBalanceInvoiced
                         && x.BaseCustomerBalanceRefunded == y.BaseCustomerBalanceRefunded
                         && x.CustomerBalanceRefunded == y.CustomerBalanceRefunded
                         && x.BaseCustomerBalanceTotalRefunded == y.BaseCustomerBalanceTotalRefunded
                         && x.CustomerBalanceTotalRefunded == y.CustomerBalanceTotalRefunded
                         && (((x.GiftCards == null) && (y.GiftCards == null)) || ((x.GiftCards != null) && x.GiftCards.SequenceEqual(y.GiftCards)))
                         && x.BaseGiftCardsAmount == y.BaseGiftCardsAmount
                         && x.GiftCardsAmount == y.GiftCardsAmount
                         && x.BaseGiftCardsInvoiced == y.BaseGiftCardsInvoiced
                         && x.GiftCardsInvoiced == y.GiftCardsInvoiced
                         && x.BaseGiftCardsRefunded == y.BaseGiftCardsRefunded
                         && x.GiftCardsRefunded == y.GiftCardsRefunded
                         && x.GiftMessage.Equals(y.GiftMessage)
                         && String.Equals(x._GiftWrapID?.Trim(), y._GiftWrapID?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPriceBase?.Trim(), y._GiftWrapPriceBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPrice?.Trim(), y._GiftWrapPrice?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountBase?.Trim(), y._GiftWrapTaxAmountBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPriceInvoicedBase?.Trim(), y._GiftWrapPriceInvoicedBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPriceInvoiced?.Trim(), y._GiftWrapPriceInvoiced?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountInvoicedBase?.Trim(), y._GiftWrapTaxAmountInvoicedBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountInvoiced?.Trim(), y._GiftWrapTaxAmountInvoiced?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPriceRefundedBase?.Trim(), y._GiftWrapPriceRefundedBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapPriceRefunded?.Trim(), y._GiftWrapPriceRefunded?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountRefundedBase?.Trim(), y._GiftWrapTaxAmountRefundedBase?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && String.Equals(x._GiftWrapTaxAmountRefunded?.Trim(), y._GiftWrapTaxAmount?.Trim(), StringComparison.InvariantCultureIgnoreCase)
                         && x.SendNotification == y.SendNotification
                         && x.RewardCurrencyAmount == y.RewardCurrencyAmount
                         && x.RewardCurrencyAmountBase == y.RewardCurrencyAmountBase
                         && (((x.Server == null) && (y.Server == null)) || ((x.Server != null) && x.Server.Equals(y.Server)))
                         && (((x.RestEndpoint == null) && (y.RestEndpoint == null)) || ((x.RestEndpoint != null) && x.RestEndpoint.Equals(y.RestEndpoint)));
            }

            return equals;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <see cref="SalesOrderInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <see cref="SalesOrderInterface"/>.</returns>
        public override SalesOrderInterface ToInterface()
        {
            SalesOrderInterface soInterface = new SalesOrderInterface();

            soInterface.ID = ID;
            soInterface.NegativeAdjustment = NegativeAdjustment;
            soInterface.PositiveAdjustment = PositiveAdjustment;
            soInterface.AppliedRuleIDs = (AppliedRules == null) ? String.Empty : AppliedRules.Select(ar => ar.ID.ToString()).Concat(",");
            soInterface.NegativeAdjustmentBase = NegativeAdjustmentBase;
            soInterface.PositiveAdjustmentBase = PositiveAdjustmentBase;
            soInterface.BaseCurrencyCode = BaseCurrencyCode;
            soInterface.DiscountAmountBase = DiscountAmountBase;
            soInterface.DiscountCanceledBase = DiscountCanceledBase;
            soInterface.DiscountInvoicedBase = DiscountInvoicedBase;
            soInterface.DiscountRefundedBase = DiscountRefundedBase;
            soInterface.GrandTotalBase = GrandTotalBase;
            soInterface.DiscountTaxCompensationAmountBase = DiscountTaxCompensationAmountBase;
            soInterface.DiscountTaxCompensationInvoicedBase = DiscountTaxCompensationInvoicedBase;
            soInterface.DiscountTaxCompensationRefundedBase = DiscountTaxCompensationRefundedBase;
            soInterface.ShippingAmountBase = ShippingAmountBase;
            soInterface.ShippingCanceledBase = ShippingCanceledBase;
            soInterface.ShippingDiscountAmountBase = ShippingDiscountAmountBase;
            soInterface.ShippingDiscountTaxCompensationAmountBase = ShippingDiscountTaxCompensationAmountBase;
            soInterface.ShippingWithTaxBase = ShippingWithTaxBase;
            soInterface.ShippingInvoicedBase = ShippingInvoicedBase;
            soInterface.ShippingRefundedBase = ShippingRefundedBase;
            soInterface.ShippingTaxAmountBase = ShippingTaxAmountBase;
            soInterface.ShippingTaxRefundedBase = ShippingTaxRefundedBase;
            soInterface.SubtotalBase = SubtotalBase;
            soInterface.SubtotalCanceledBase = SubtotalCanceledBase;
            soInterface.SubtotalWithTaxBase = SubtotalWithTaxBase;
            soInterface.SubtotalInvoicedBase = SubtotalInvoicedBase;
            soInterface.SubtotalRefundedBase = SubtotalRefundedBase;
            soInterface.TaxAmountBase = TaxAmountBase;
            soInterface.TaxCanceledBase = TaxCanceledBase;
            soInterface.TaxInvoicedBase = TaxInvoicedBase;
            soInterface.TaxRefundedBase = TaxRefundedBase;
            soInterface.TaxCanceledTotalBase = TaxCanceledTotalBase;
            soInterface.TotalDueBase = TotalDueBase;
            soInterface.TotalInvoicedBase = TotalInvoicedBase;
            soInterface.TotalInvoicedCostBase = TotalInvoicedCostBase;
            soInterface.TotalOfflineRefundedBase = TotalOfflineRefundedBase;
            soInterface.TotalOnlineRefundedBase = TotalOnlineRefundedBase;
            soInterface.TotalPaidBase = TotalPaidBase;
            soInterface.TotalQuantityOrderedBase = TotalQuantityOrderedBase;
            soInterface.TotalRefundBase = TotalRefundBase;
            soInterface.BaseToGlobalRate = BaseToGlobalRate;
            soInterface.CanShipPartially = CanShipPartially;
            soInterface.CanShipItemPartially = CanShipItemPartially;
            soInterface.CouponCode = CouponCode;
            soInterface.CreatedAt = CreatedTimestamp.ToDateTimeUtc().ToString();
            soInterface.CustomerGroupID = CustomerGroup.ID;
            soInterface.CustomerID = Customer.ID;
            soInterface.CustomerIsGuest = CustomerIsGuest.ToMagentoBoolean();
            soInterface.Notice = Notice;
            soInterface.NotifyNotice = NotifyNotice;
            soInterface.DiscountAmount = DiscountAmount;
            soInterface.DiscountCanceled = DiscountCanceled;
            soInterface.DiscountDescription = DiscountDescription;
            soInterface.DiscountInvoiced = DiscountInvoiced;
            soInterface.DiscountRefunded = DiscountRefunded;
            soInterface.EditIncrement = EditIncrement;
            soInterface.EmailSent = EmailSent.ToMagentoBoolean();
            soInterface.ExternalOrderID = ExternalOrderID;
            soInterface.ExternalCustomerID = ExternalCustomerID;
            soInterface.ForcedShipmentWithInvoice = ForcedShipmentWithInvoice.ToMagentoBoolean();
            soInterface.GlobalCurrencyCode = GlobalCurrencyCode;
            soInterface.GrandTotal = GrandTotal;
            soInterface.DiscountTaxCompensationAmount = DiscountTaxCompensationAmount;
            soInterface.DiscountTaxCompensationInvoiced = DiscountTaxCompensationInvoiced;
            soInterface.DiscountTaxCompensationRefunded = DiscountTaxCompensationRefunded;
            soInterface.HoldBeforeState = HoldBeforeState;
            soInterface.HoldBeforeStatus = HoldBeforeStatus;
            soInterface.IncrementID = IncrementID;
            soInterface.IsVirtual = IsVirtual.ToMagentoBoolean();
            soInterface.OrderCurrencyCode = OrderCurrencyCode;
            soInterface.OriginalIncrementID = OriginalIncrementID;
            soInterface.PaymentAuthorizationAmount = PaymentAuthorizationAmount;
            soInterface.PaymentAuthorizationExpirationDate = PaymentAuthorizationExpirationDate;
            soInterface.ProtectCode = ProtectCode;
            soInterface.QuoteAddressID = QuoteAddress.ID;
            soInterface.QuoteID = QuoteID;
            soInterface.RelationChildID = RelationChildID;
            soInterface.RelationChildRealID = RelationChildRealID;
            soInterface.RelationParentID = RelationParentID;
            soInterface.RelationParentRealID = RelationParentRealID;
            soInterface.RemoteIP = (RemoteIP != null) ? RemoteIP.ToString() : String.Empty;
            soInterface.ShippingAmount = ShippingAmount;
            soInterface.ShippingCanceled = ShippingCanceled;
            soInterface.ShippingDescription = ShippingDescription;
            soInterface.ShippingDiscountAmount = ShippingDiscountAmount;
            soInterface.ShippingDiscountTaxCompensationAmount = ShippingDiscountTaxCompensationAmount;
            soInterface.ShippingWithTax = ShippingWithTax;
            soInterface.ShippingTaxRefunded = ShippingTaxRefunded;
            soInterface.Status = Status;
            soInterface.StoreID = Store.ID;
            soInterface.StoreCurrencyCode = StoreCurrencyCode;
            soInterface.StoreToBaseRate = StoreToBaseRate;
            soInterface.StoreToOrderRate = StoreToOrderRate;
            soInterface.Subtotal = Subtotal;
            soInterface.SubtotalCanceled = SubtotalCanceled;
            soInterface.SubtotalWithTax = SubtotalWithTax;
            soInterface.SubtotalInvoiced = SubtotalInvoiced;
            soInterface.SubtotalRefunded = SubtotalRefunded;
            soInterface.TaxAmount = TaxAmount;
            soInterface.TaxCanceled = TaxCanceled;
            soInterface.TaxInvoiced = TaxInvoiced;
            soInterface.TaxRefunded = TaxRefunded;
            soInterface.TotalCanceled = TotalCanceled;
            soInterface.TotalDue = TotalDue;
            soInterface.TotalInvoiced = TotalInvoiced;
            soInterface.TotalItemCount = TotalItemCount;
            soInterface.TotalOfflineRefunded = TotalOfflineRefunded;
            soInterface.TotalOnlineRefunded = TotalOnlineRefunded;
            soInterface.TotalPaid = TotalPaid;
            soInterface.TotalQuantityOrdered = TotalQuantityOrdered;
            soInterface.TotalRefunded = TotalRefunded;
            soInterface.UpdatedAt = (UpdatedTimestamp.HasValue) ? UpdatedTimestamp.Value.ToDateTimeUtc().ToString() : String.Empty;
            soInterface.Weight = Weight;
            soInterface.TransactionForwardedFor = TransactionForwardedFor;
            soInterface.Items = (Items == null) ? null : Items.Select(i => i.ToInterface()).ToArray();
            soInterface.BillingAddress = BillingAddress.ToInterface();
            soInterface.Payment = Payment.ToInterface();
            soInterface.StatusHistories = (StatusHistories == null) ? null : StatusHistories.Select(sh => sh.ToInterface()).ToArray();
            soInterface.ExtensionAttributes = new SalesOrderExtensionInterface();
            soInterface.ExtensionAttributes.ShippingAssignments = (ShippingAssignments == null) ? null : ShippingAssignments.Select(si => si.ToInterface()).ToArray();
            soInterface.ExtensionAttributes.PaymentAdditionalInformation = (PaymentAdditionalInformation == null) ? null : PaymentAdditionalInformation.Select(pi => pi.ToInterface()).ToArray();
            soInterface.ExtensionAttributes.AppliedTaxes = (Taxes == null) ? null : Taxes.Select(t => t.ToInterface()).ToArray();
            soInterface.ExtensionAttributes.ItemAppliedTaxes = (ItemTaxes == null) ? null : ItemTaxes.Select(t => t.ToInterface()).ToArray();
            soInterface.ExtensionAttributes.ConvertingFromQuote = ConvertingFromQuote;
            soInterface.ExtensionAttributes.CustomerBalanceAmountBase = BaseCustomerBalanceAmount;
            soInterface.ExtensionAttributes.CustomerBalanceAmount = CustomerBalanceAmount;
            soInterface.ExtensionAttributes.CustomerBalanceInvoiced = CustomerBalanceInvoiced;
            soInterface.ExtensionAttributes.CustomerBalanceInvoicedBase = BaseCustomerBalanceInvoiced;
            soInterface.ExtensionAttributes.CustomerBalanceRefundedBase = BaseCustomerBalanceRefunded;
            soInterface.ExtensionAttributes.CustomerBalanceRefunded = CustomerBalanceRefunded;
            soInterface.ExtensionAttributes.CustomerBalanceRefundTotalBase = BaseCustomerBalanceTotalRefunded;
            soInterface.ExtensionAttributes.CustomerBalanceRefundTotal = CustomerBalanceTotalRefunded;
            soInterface.ExtensionAttributes.GiftCards = (GiftCards == null) ? null : GiftCards.Select(gc => gc.ToInterface()).ToArray();
            soInterface.ExtensionAttributes.GiftCardsAmountBase = BaseGiftCardsAmount;
            soInterface.ExtensionAttributes.GiftCardsAmount = GiftCardsAmount;
            soInterface.ExtensionAttributes.GiftCardsInvoicedBase = BaseGiftCardsInvoiced;
            soInterface.ExtensionAttributes.GiftCardsInvoiced = GiftCardsInvoiced;
            soInterface.ExtensionAttributes.GiftCardsRefundedBase = BaseGiftCardsRefunded;
            soInterface.ExtensionAttributes.GiftCardsRefunded = GiftCardsRefunded;
            soInterface.ExtensionAttributes.GiftMessage = GiftMessage.ToInterface();
            soInterface.ExtensionAttributes.GiftWrapID = _GiftWrapID;
            soInterface.ExtensionAttributes.GiftWrapPriceBase = _GiftWrapPriceBase;
            soInterface.ExtensionAttributes.GiftWrapPrice = _GiftWrapPrice;
            soInterface.ExtensionAttributes.GiftWrapTaxAmountBase = _GiftWrapTaxAmountBase;
            soInterface.ExtensionAttributes.GiftWrapPriceInvoicedBase = _GiftWrapPriceInvoicedBase;
            soInterface.ExtensionAttributes.GiftWrapPriceInvoiced = _GiftWrapPriceInvoiced;
            soInterface.ExtensionAttributes.GiftWrapTaxAmountInvoicedBase = _GiftWrapTaxAmountInvoicedBase;
            soInterface.ExtensionAttributes.GiftWrapTaxAmountInvoiced = _GiftWrapTaxAmountInvoiced;
            soInterface.ExtensionAttributes.GiftWrapPriceRefundedBase = _GiftWrapPriceRefundedBase;
            soInterface.ExtensionAttributes.GiftWrapPriceRefunded = _GiftWrapPriceRefunded;
            soInterface.ExtensionAttributes.GiftWrapItemsTaxRefundedBase = _GiftWrapTaxAmountRefundedBase;
            soInterface.ExtensionAttributes.GiftWrapItemsTaxRefunded = _GiftWrapTaxAmountRefunded;
            soInterface.ExtensionAttributes.SendNotification = SendNotification.ToMagentoBoolean();
            soInterface.ExtensionAttributes.RewardCurrencyAmount = RewardCurrencyAmount;
            soInterface.ExtensionAttributes.RewardCurrencyAmountBase = RewardCurrencyAmountBase;
                         
            return soInterface;
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
            string[] appliedRuleIds = null;

            if (model != null)
            {
                appliedRuleIds = !String.IsNullOrWhiteSpace(model.AppliedRuleIDs) ? model.AppliedRuleIDs.Split(new char[] { ',' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries) : null;

                ID = model.ID;
                NegativeAdjustment = model.NegativeAdjustment;
                PositiveAdjustment = model.PositiveAdjustment;
                AppliedRules = (appliedRuleIds == null || appliedRuleIds.Length < 1) ? null : appliedRuleIds.Select(ar => new MagentoSalesRule(Convert.ToUInt32(ar))); 
                NegativeAdjustmentBase = model.NegativeAdjustmentBase;
                PositiveAdjustmentBase = model.PositiveAdjustmentBase;
                BaseCurrencyCode = model.BaseCurrencyCode;
                DiscountAmountBase = model.DiscountAmountBase;
                DiscountCanceledBase = model.DiscountCanceledBase;
                DiscountInvoicedBase = model.DiscountInvoicedBase;
                DiscountRefundedBase = model.DiscountRefundedBase;
                GrandTotalBase = model.GrandTotalBase;
                DiscountTaxCompensationAmountBase = model.DiscountTaxCompensationAmountBase;
                DiscountTaxCompensationInvoicedBase = model.DiscountTaxCompensationInvoicedBase;
                DiscountTaxCompensationRefundedBase = model.DiscountTaxCompensationRefundedBase;
                ShippingAmountBase = model.ShippingAmountBase;
                ShippingCanceledBase = model.ShippingCanceledBase;
                ShippingDiscountAmountBase = model.ShippingDiscountAmountBase;
                ShippingDiscountTaxCompensationAmountBase = model.ShippingDiscountTaxCompensationAmountBase;
                ShippingWithTaxBase = model.ShippingWithTaxBase;
                ShippingInvoicedBase = model.ShippingInvoicedBase;
                ShippingRefundedBase = model.ShippingRefundedBase;
                ShippingTaxAmountBase = model.ShippingTaxAmountBase;
                ShippingTaxRefundedBase = model.ShippingTaxRefundedBase;
                SubtotalBase = model.SubtotalBase;
                SubtotalCanceledBase = model.SubtotalCanceledBase;
                SubtotalWithTaxBase = model.SubtotalWithTaxBase;
                SubtotalInvoicedBase = model.SubtotalInvoicedBase;
                SubtotalRefundedBase = model.SubtotalRefundedBase;
                TaxAmountBase = model.TaxAmountBase;
                TaxCanceledBase = model.TaxCanceledBase;
                TaxInvoicedBase = model.TaxInvoicedBase;
                TaxRefundedBase = model.TaxRefundedBase;
                TaxCanceledTotalBase = model.TaxCanceledTotalBase;
                TotalDueBase = model.TotalDueBase;
                TotalInvoicedBase = model.TotalInvoicedBase;
                TotalInvoicedCostBase = model.TotalInvoicedCostBase;
                TotalOfflineRefundedBase = model.TotalOfflineRefundedBase;
                TotalOnlineRefundedBase = model.TotalOnlineRefundedBase;
                TotalPaidBase = model.TotalPaidBase;
                TotalQuantityOrderedBase = model.TotalQuantityOrderedBase;
                TotalRefundBase = model.TotalRefundBase;
                BaseToGlobalRate = model.BaseToGlobalRate;
                CanShipPartially = model.CanShipPartially;
                CanShipItemPartially = model.CanShipItemPartially;
                CouponCode = model.CouponCode;
                CreatedTimestamp = Instant.FromDateTimeUtc(DateTime.Parse(model.CreatedAt).ToUniversalTime(true));
                CustomerGroup = new CustomerGroup(Convert.ToUInt32(model.CustomerGroupID));
                Customer = new MagentoCustomer(Convert.ToUInt32(model.CustomerID));
                CustomerIsGuest = model.CustomerIsGuest.FromMagentoBoolean();
                Notice = model.Notice;
                NotifyNotice = model.NotifyNotice;
                DiscountAmount = model.DiscountAmount;
                DiscountCanceled = model.DiscountCanceled;
                DiscountDescription = model.DiscountDescription;
                DiscountInvoiced = model.DiscountInvoiced;
                DiscountRefunded = model.DiscountRefunded;
                EditIncrement = model.EditIncrement;
                EmailSent = model.EmailSent.FromMagentoBoolean();
                ExternalOrderID = model.ExternalOrderID;
                ExternalCustomerID = model.ExternalCustomerID;
                ForcedShipmentWithInvoice = model.ForcedShipmentWithInvoice.FromMagentoBoolean();
                GlobalCurrencyCode = model.GlobalCurrencyCode;
                GrandTotal = model.GrandTotal;
                DiscountTaxCompensationAmount = model.DiscountTaxCompensationAmount;
                DiscountTaxCompensationInvoiced = model.DiscountTaxCompensationInvoiced;
                DiscountTaxCompensationRefunded = model.DiscountTaxCompensationRefunded;
                HoldBeforeState = model.HoldBeforeState;
                HoldBeforeStatus = model.HoldBeforeStatus;
                IncrementID = model.IncrementID;
                IsVirtual = model.IsVirtual.FromMagentoBoolean();
                OrderCurrencyCode = model.OrderCurrencyCode;
                OriginalIncrementID = model.OriginalIncrementID;
                PaymentAuthorizationAmount = model.PaymentAuthorizationAmount;
                PaymentAuthorizationExpirationDate = model.PaymentAuthorizationExpirationDate;
                ProtectCode = model.ProtectCode;
                QuoteAddress = new SalesOrderAddress(Convert.ToUInt32(model.QuoteAddressID));
                QuoteID = model.QuoteID;
                RelationChildID = model.RelationChildID;
                RelationChildRealID = model.RelationChildRealID;
                RelationParentID = model.RelationParentID;
                RelationParentRealID = model.RelationParentRealID;
                RemoteIP = !String.IsNullOrWhiteSpace(model.RemoteIP) ? IPAddress.Parse(model.RemoteIP) : null;
                ShippingAmount = model.ShippingAmount;
                ShippingCanceled = model.ShippingCanceled;
                ShippingDescription = model.ShippingDescription;
                ShippingDiscountAmount = model.ShippingDiscountAmount;
                ShippingDiscountTaxCompensationAmount = model.ShippingDiscountTaxCompensationAmount;
                ShippingWithTax = model.ShippingWithTax;
                ShippingTaxRefunded = model.ShippingTaxRefunded;
                Status = model.Status;
                Store = new MagentoStore(Convert.ToUInt32(model.StoreID));
                StoreCurrencyCode = model.StoreCurrencyCode;
                StoreToBaseRate = model.StoreToBaseRate;
                StoreToOrderRate = model.StoreToOrderRate;
                Subtotal = model.Subtotal;
                SubtotalCanceled = model.SubtotalCanceled;
                SubtotalWithTax = model.SubtotalWithTax;
                SubtotalInvoiced = model.SubtotalInvoiced;
                SubtotalRefunded = model.SubtotalRefunded;
                TaxAmount = model.TaxAmount;
                TaxCanceled = model.TaxCanceled;
                TaxInvoiced = model.TaxInvoiced;
                TaxRefunded = model.TaxRefunded;
                TotalCanceled = model.TotalCanceled;
                TotalDue = model.TotalDue;
                TotalInvoiced = model.TotalInvoiced;
                TotalItemCount = model.TotalItemCount;
                TotalOfflineRefunded = model.TotalOfflineRefunded;
                TotalOnlineRefunded = model.TotalOnlineRefunded;
                TotalPaid = model.TotalPaid;
                TotalQuantityOrdered = model.TotalQuantityOrdered;
                TotalRefunded = model.TotalRefunded;
                UpdatedTimestamp = !String.IsNullOrWhiteSpace(model.UpdatedAt) ? Instant.FromDateTimeUtc(DateTime.Parse(model.UpdatedAt).ToUniversalTime(true)) : null;
                Weight = model.Weight;
                TransactionForwardedFor = model.TransactionForwardedFor;
                Items = (model.Items == null) ? null : model.Items.Select(i => new SalesOrderItem(i));
                BillingAddress = (model.BillingAddress != null) ? new SalesOrderAddress(model.BillingAddress) : null;
                Payment = (model.Payment != null) ? new SalesOrderPayment(model.Payment) : null;
                StatusHistories = (model.StatusHistories == null) ? null : model.StatusHistories.Select(sh => new SalesOrderStatusHistory(sh));
                ShippingAssignments = (model.ExtensionAttributes.ShippingAssignments == null) ? null : model.ExtensionAttributes.ShippingAssignments.Select(sa => new SalesOrderShippingAssignment(sa)); 
                PaymentAdditionalInformation = (model.ExtensionAttributes.PaymentAdditionalInformation == null) ? null : model.ExtensionAttributes.PaymentAdditionalInformation.Select(pa => new PaymentAdditionalInfo(pa));
                Taxes = (model.ExtensionAttributes.AppliedTaxes == null) ? null : model.ExtensionAttributes.AppliedTaxes.Select(at => new SalesOrderAppliedTax(at));
                ItemTaxes = (model.ExtensionAttributes.ItemAppliedTaxes == null) ? null : model.ExtensionAttributes.ItemAppliedTaxes.Select(it => new SalesOrderItemTaxDetails(it));
                ConvertingFromQuote = model.ExtensionAttributes.ConvertingFromQuote;
                BaseCustomerBalanceAmount = model.ExtensionAttributes.CustomerBalanceAmountBase;
                CustomerBalanceAmount = model.ExtensionAttributes.CustomerBalanceAmount;
                CustomerBalanceInvoiced = model.ExtensionAttributes.CustomerBalanceInvoiced;
                BaseCustomerBalanceInvoiced = model.ExtensionAttributes.CustomerBalanceInvoicedBase;
                BaseCustomerBalanceRefunded = model.ExtensionAttributes.CustomerBalanceRefundedBase;
                CustomerBalanceRefunded = model.ExtensionAttributes.CustomerBalanceRefunded;
                BaseCustomerBalanceTotalRefunded = model.ExtensionAttributes.CustomerBalanceRefundTotalBase;
                CustomerBalanceTotalRefunded = model.ExtensionAttributes.CustomerBalanceRefundTotal;
                GiftCards = (model.ExtensionAttributes.GiftCards == null) ? null : model.ExtensionAttributes.GiftCards.Select(gc => new MagentoGiftCard(gc));
                BaseGiftCardsAmount = model.ExtensionAttributes.GiftCardsAmountBase;
                GiftCardsAmount = model.ExtensionAttributes.GiftCardsAmount;
                BaseGiftCardsInvoiced = model.ExtensionAttributes.GiftCardsInvoicedBase;
                GiftCardsInvoiced = model.ExtensionAttributes.GiftCardsInvoiced;
                GiftCardsRefunded = model.ExtensionAttributes.GiftCardsRefundedBase;
                GiftCardsRefunded = model.ExtensionAttributes.GiftCardsRefunded;
                GiftMessage = (model.ExtensionAttributes.GiftMessage == null) ? default(MagentoGiftMessage) : new MagentoGiftMessage(model.ExtensionAttributes.GiftMessage);
                _GiftWrapID = model.ExtensionAttributes.GiftWrapID;
                _GiftWrapPriceBase = model.ExtensionAttributes.GiftWrapPriceBase;
                _GiftWrapPrice = model.ExtensionAttributes.GiftWrapPrice;
                _GiftWrapTaxAmountBase = model.ExtensionAttributes.GiftWrapTaxAmountBase;
                _GiftWrapPriceInvoicedBase = model.ExtensionAttributes.GiftWrapPriceInvoicedBase;
                _GiftWrapPriceInvoiced = model.ExtensionAttributes.GiftWrapPriceInvoiced;
                _GiftWrapTaxAmountInvoicedBase = model.ExtensionAttributes.GiftWrapTaxAmountInvoicedBase;
                _GiftWrapTaxAmountInvoiced = model.ExtensionAttributes.GiftWrapTaxAmountInvoiced;
                _GiftWrapPriceRefundedBase = model.ExtensionAttributes.GiftWrapPriceRefundedBase;
                _GiftWrapPriceRefunded = model.ExtensionAttributes.GiftWrapPriceRefunded;
                _GiftWrapTaxAmountRefundedBase = model.ExtensionAttributes.GiftWrapItemsTaxRefundedBase;
                _GiftWrapTaxAmountRefunded = model.ExtensionAttributes.GiftWrapItemsTaxRefunded;
                SendNotification = model.ExtensionAttributes.SendNotification.FromMagentoBoolean();
                RewardCurrencyAmount = model.ExtensionAttributes.RewardCurrencyAmount;
                RewardCurrencyAmountBase = model.ExtensionAttributes.RewardCurrencyAmountBase;
            }
        }

    }
}
