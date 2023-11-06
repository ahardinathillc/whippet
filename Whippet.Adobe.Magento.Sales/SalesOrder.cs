using System;
using System.Text;
using NodaTime;
using NodaMoney;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Customer;
using Athi.Whippet.Adobe.Magento.EAV;
using Athi.Whippet.Adobe.Magento.Customer.Extensions;
using Athi.Whippet.Adobe.Magento.Sales.Extensions;
using Athi.Whippet.Adobe.Magento.EAV.Extensions;
using MagentoCustomer = Athi.Whippet.Adobe.Magento.Customer.Customer;
using Athi.Whippet.Json.Newtonsoft.Extensions;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Represents a sales order in Magento.
    /// </summary>
    public class SalesOrder : MagentoEntity, IMagentoEntity, ISalesOrder, IEqualityComparer<ISalesOrder>
    {
        private SalesOrderAddress _billingAddress;
        private SalesOrderAddress _shippingAddress;
        private QuoteAddress _quoteAddress;
        private Quote _quote;
        private CustomerGroup _customerGroup;
        private MagentoCustomer _customer;
        private GiftMessage _giftMessage;
        private Store _store;

        /// <summary>
        /// Gets or sets the unique ID of the sales order.
        /// </summary>
        [JsonProperty("entity_id")]
        public virtual uint EntityID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the negative adjustment to the order total.
        /// </summary>
        [JsonProperty("adjustment_negative")]
        public virtual decimal? AdjustmentNegative
        { get; set; }

        /// <summary>
        /// Gets or sets the positive adjustment to the order total.
        /// </summary>
        [JsonProperty("adjustment_positive")]
        public virtual decimal? AdjustmentPositive
        { get; set; }

        /// <summary>
        /// Gets or sets a delimited list of applied sales rule IDs.
        /// </summary>
        [JsonProperty("applied_rule_ids")]
        public virtual string AppliedRuleIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the base negative adjustment amount.
        /// </summary>
        [JsonProperty("base_adjustment_negative")]
        public virtual decimal? BaseAdjustmentNegative
        { get; set; }

        /// <summary>
        /// Gets or sets the base positive adjustment amount.
        /// </summary>
        [JsonProperty("base_adjustment_positive")]
        public virtual decimal? BaseAdjustmentPositive
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code for the order total.
        /// </summary>
        [JsonProperty("base_currency_code")]
        public virtual string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the base customer balance.
        /// </summary>
        public virtual decimal? BaseCustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base customer balance that was invoiced.
        /// </summary>
        public virtual decimal? BaseCustomerBalanceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base customer balance that was refunded.
        /// </summary>
        public virtual decimal? BaseCustomerBalanceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount amount.
        /// </summary>
        [JsonProperty("base_discount_amount")]
        public virtual decimal? BaseDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount that was canceled.
        /// </summary>
        [JsonProperty("base_discount_canceled")]
        public virtual decimal? BaseDiscountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount that was invoiced.
        /// </summary>
        [JsonProperty("base_discount_invoiced")]
        public virtual decimal? BaseDiscountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount that was refunded.
        /// </summary>
        [JsonProperty("base_discount_refunded")]
        public virtual decimal? BaseDiscountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount tax compensation amount.
        /// </summary>
        [JsonProperty("base_discount_tax_compensation_amount")]
        public virtual decimal? BaseDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount tax compensation invoiced amount.
        /// </summary>
        [JsonProperty("base_discount_tax_compensation_invoiced")]
        public virtual decimal? BaseDiscountTaxCompensationInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount tax compensation refunded amount.
        /// </summary>
        [JsonProperty("base_discount_tax_compensation_refunded")]
        public virtual decimal? BaseDiscountTaxCompensationRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards amount.
        /// </summary>
        public virtual decimal? BaseGiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards invoiced amount.
        /// </summary>
        public virtual decimal? BaseGiftCardsInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base gift cards refunded amount.
        /// </summary>
        public virtual decimal? BaseGiftCardsRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base grand total amount.
        /// </summary>
        [JsonProperty("base_grand_total")]
        public virtual decimal? BaseGrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount.
        /// </summary>
        public virtual decimal? BaseRewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount that was refunded.
        /// </summary>
        public virtual decimal? BaseRewardCurrencyAmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base reward currency amount that was invoiced.
        /// </summary>
        public virtual decimal? BaseRewardCurrencyAmountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount.
        /// </summary>
        [JsonProperty("base_shipping_amount")]
        public virtual decimal? BaseShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or setes the base shipping amount that was canceled.
        /// </summary>
        [JsonProperty("base_shipping_canceled")]
        public virtual decimal? BaseShippingCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping discount amount.
        /// </summary>
        [JsonProperty("base_shipping_discount_amount")]
        public virtual decimal? BaseShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping discount tax compensation amount.
        /// </summary>
        [JsonProperty("base_shipping_discount_tax_compensation_amnt")]
        public virtual decimal? BaseShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount including tax.
        /// </summary>
        [JsonProperty("base_shipping_incl_tax")]
        public virtual decimal? BaseShippingIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount invoiced.
        /// </summary>
        [JsonProperty("base_shipping_invoiced")]
        public virtual decimal? BaseShippingInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping amount that was refunded.
        /// </summary>
        [JsonProperty("base_shipping_refunded")]
        public virtual decimal? BaseShippingRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping tax amount.
        /// </summary>
        [JsonProperty("base_shipping_tax_amount")]
        public virtual decimal? BaseShippingTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base shipping tax amount that was refunded.
        /// </summary>
        [JsonProperty("base_shipping_tax_refunded")]
        public virtual decimal? BaseShippingTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal amount. 
        /// </summary>
        [JsonProperty("base_subtotal")]
        public virtual decimal? BaseSubtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal canceled amount.
        /// </summary>
        [JsonProperty("base_subtotal_canceled")]
        public virtual decimal? BaseSubtotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal amount including tax.
        /// </summary>
        [JsonProperty("base_subtotal_incl_tax")]
        public virtual decimal? BaseSubtotalIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal invoiced amount.
        /// </summary>
        [JsonProperty("base_subtotal_invoiced")]
        public virtual decimal? BaseSubtotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base subtotal amount that was refunded.
        /// </summary>
        [JsonProperty("base_subtotal_refunded")]
        public virtual decimal? BaseSubtotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax amount.
        /// </summary>
        [JsonProperty("base_tax_amount")]
        public virtual decimal? BaseTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax amount that was canceled.
        /// </summary>
        [JsonProperty("base_tax_canceled")]
        public virtual decimal? BaseTaxCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax invoiced amount.
        /// </summary>
        [JsonProperty("base_tax_invoiced")]
        public virtual decimal? BaseTaxInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base tax amount that was refunded.
        /// </summary>
        [JsonProperty("base_tax_refunded")]
        public virtual decimal? BaseTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base amount converted to the global rate.
        /// </summary>
        [JsonProperty("base_to_global_rate")]
        public virtual decimal? BaseToGlobalRate
        { get; set; }

        /// <summary>
        /// Gets or sets the base amount converted to the order rate.
        /// </summary>
        [JsonProperty("base_to_order_rate")]
        public virtual decimal? BaseToOrderRate
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount that was canceled.
        /// </summary>
        [JsonProperty("base_total_canceled")]
        public virtual decimal? BaseTotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount due.
        /// </summary>
        [JsonProperty("base_total_due")]
        public virtual decimal? BaseTotalDue
        { get; set; }

        /// <summary>
        /// Gets or sets the base total invoiced amount.
        /// </summary>
        [JsonProperty("base_total_invoiced")]
        public virtual decimal? BaseTotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the base total invoiced amount cost.
        /// </summary>
        [JsonProperty("base_total_invoiced_cost")]
        public virtual decimal? BaseTotalInvoicedCost
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount refunded offline.
        /// </summary>
        [JsonProperty("base_total_offline_refunded")]
        public virtual decimal? BaseTotalOfflineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount refunded online.
        /// </summary>
        [JsonProperty("base_total_online_refunded")]
        public virtual decimal? BaseTotalOnlineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the base total amount paid.
        /// </summary>
        [JsonProperty("base_total_paid")]
        public virtual decimal? BaseTotalPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the base total quantity ordered.
        /// </summary>
        [JsonProperty("base_total_qty_ordered")]
        public virtual decimal? BaseTotalQuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the base total refunded amount.
        /// </summary>
        [JsonProperty("base_total_refunded")]
        public virtual decimal? BaseTotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SalesOrderAddress.EntityID"/> of the billing address.
        /// </summary>
        [JsonProperty("billing_address_id")]
        public virtual uint BillingAddressID
        {
            get
            {
                return BillingAddress.ID;
            }
            set
            {
                BillingAddress.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated billing address with the sales order.
        /// </summary>
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
        /// Gets or sets the associated billing address with the sales order.
        /// </summary>
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
        /// Gets or sets the base total refunded customer balance.
        /// </summary>
        public virtual decimal? BaseCustomerBalanceTotalRefunded
        { get; set; }

        /// <summary>
        /// Indicates whether the order can be partially shipped.
        /// </summary>
        [JsonProperty("can_ship_partially")]
        public virtual bool? CanShipPartially
        { get; set; }

        /// <summary>
        /// Indicates whether the order can be partially shipped.
        /// </summary>
        [JsonProperty("can_ship_partially_item")]
        public virtual bool? CanShipItemPartially
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code that was applied to the order.
        /// </summary>
        [JsonProperty("coupon_code")]
        public virtual string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon rule name.
        /// </summary>
        public virtual string CouponRuleName
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the entity was created.
        /// </summary>
        Instant ISalesOrder.CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the date/time the entity was created.
        /// </summary>
        [JsonProperty("created_at")]
        public virtual DateTime CreatedAt
        {
            get
            {
                return ((ISalesOrder)(this)).CreatedAt.ToDateTimeUtc();
            }
            set
            {
                ((ISalesOrder)(this)).CreatedAt = Instant.FromDateTimeUtc(value.ToUniversalTime());
            }
        }

        /// <summary>
        /// Gets or sets the total refunded customer balance.
        /// </summary>
        public virtual decimal? CustomerBalanceTotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance amount.
        /// </summary>
        public virtual decimal? CustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance that was invoiced.
        /// </summary>
        public virtual decimal? CustomerBalanceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance that was refunded.
        /// </summary>
        public virtual decimal? CustomerBalanceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's date of birth.
        /// </summary>
        Instant? ISalesOrder.CustomerDateOfBirth
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's date of birth.
        /// </summary>
        [JsonProperty("customer_dob")]        
        public virtual DateTime? CustomerDateOfBirth
        {
            get
            {
                return ((ISalesOrder)(this)).CustomerDateOfBirth.HasValue ? ((ISalesOrder)(this)).CustomerDateOfBirth.Value.ToDateTimeUtc() : null;
            }
            set
            {
                ((ISalesOrder)(this)).CustomerDateOfBirth = value.HasValue ? Instant.FromDateTimeUtc(value.Value.ToUniversalTime()) : null;
            }
        }

        /// <summary>
        /// Gets or sets the customer's e-mail address.
        /// </summary>
        [JsonProperty("customer_email")]
        public virtual string CustomerEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        [JsonProperty("customer_firstname")]
        public virtual string CustomerFirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's gender. Genders are stored in Magento configuration.
        /// </summary>
        [JsonProperty("customer_gender")]
        public virtual int? CustomerGender
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CustomerGroup.GroupID"/> value.
        /// </summary>
        [JsonProperty("customer_group_id")]
        public virtual uint CustomerGroupID
        {
            get
            {
                return CustomerGroup.ID;
            }
            set
            {
                CustomerGroup.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer group.
        /// </summary>
        public virtual CustomerGroup CustomerGroup
        {
            get
            {
                if (_customerGroup == null)
                {
                    _customerGroup = new CustomerGroup();
                }

                return _customerGroup;
            }
            set
            {
                _customerGroup = value;
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
        /// Gets or sets the <see cref="MagentoCustomer.EntityID"/> value of <see cref="Customer"/>.
        /// </summary>
        [JsonProperty("customer_id")]
        public virtual uint CustomerID
        {
            get
            {
                return Customer.ID;
            }
            set
            {
                Customer.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent customer for the sales order.
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
        /// Gets or sets the parent customer for the sales order.
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
        /// Indicates whether the customer is a guest and does not have an account.
        /// </summary>
        [JsonProperty("customer_is_guest")]
        public virtual bool? CustomerIsGuest
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        [JsonProperty("customer_lastname")]
        public virtual string CustomerLastName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's middle name.
        /// </summary>
        [JsonProperty("customer_middlename")]
        public virtual string CustomerMiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer note.
        /// </summary>
        [JsonProperty("customer_note")]
        public virtual string CustomerNote
        { get; set; }

        /// <summary>
        /// Specifies a flag whether the customer's note should be an alert.
        /// </summary>
        [JsonProperty("customer_note_notify")]
        public virtual bool? CustomerNotifyNote
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's prefix.
        /// </summary>
        [JsonProperty("customer_prefix")]
        public virtual string CustomerPrefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's suffix.
        /// </summary>
        [JsonProperty("customer_suffix")]
        public virtual string CustomerSuffix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's VAT number.
        /// </summary>
        [JsonProperty("customer_taxvat")]
        public virtual string CustomerValueAddedTax
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        [JsonProperty("discount_amount")]
        public virtual decimal? DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the canceled discount amount.
        /// </summary>
        [JsonProperty("discount_canceled")]
        public virtual decimal? DiscountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the discount description.
        /// </summary>
        [JsonProperty("discount_description")]
        public virtual string DiscountDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the invoiced discount.
        /// </summary>
        [JsonProperty("discount_invoiced")]
        public virtual decimal? DiscountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount that was refunded.
        /// </summary>
        [JsonProperty("discount_refunded")]
        public virtual decimal? DiscountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount.
        /// </summary>
        [JsonProperty("discount_tax_compensation_amount")]
        public virtual decimal? DiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation that was invoiced.
        /// </summary>
        [JsonProperty("discount_tax_compensation_invoiced")]
        public virtual decimal? DiscountTaxCompensationInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation that was refunded.
        /// </summary>
        [JsonProperty("discount_tax_compensation_refunded")]
        public virtual decimal? DiscountTaxCompensationRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of edits made to the sales order.
        /// </summary>
        [JsonProperty("edit_increment")]
        public virtual int? EditIncrement
        { get; set; }

        /// <summary>
        /// Indicates whether an e-mail has been dispatched for the sales order.
        /// </summary>
        [JsonProperty("email_sent")]
        public virtual bool? EmailSent
        { get; set; }

        /// <summary>
        /// Gets or sets the external customer ID.
        /// </summary>
        [JsonProperty("ext_customer_id")]
        public virtual string ExternalCustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the external order ID.
        /// </summary>
        [JsonProperty("ext_order_id")]
        public virtual string ExternalOrderID
        { get; set; }

        /// <summary>
        /// Indicates whether the shipment was forced with an unsatisfied invoice.
        /// </summary>
        [JsonProperty("forced_shipment_with_invoice")]
        public virtual bool? ForcedShipmentWithInvoice
        { get; set; }

        /// <summary>
        /// Gets or sets all gift cards that were applied to the sales order.
        /// </summary>
        public virtual string GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards amount.
        /// </summary>
        public virtual decimal? GiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards amount that was invoiced.
        /// </summary>
        public virtual decimal? GiftCardsInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards that were refunded.
        /// </summary>
        public virtual decimal? GiftCardsRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the associated gift message with the sales order.
        /// </summary>
        public virtual GiftMessage GiftMessage
        {
            get
            {
                if (_giftMessage == null)
                {
                    _giftMessage = new GiftMessage();
                }

                return _giftMessage;
            }
            set
            {
                _giftMessage = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated gift message with the sales order.
        /// </summary>
        IGiftMessage ISalesOrder.GiftMessage
        {
            get
            {
                return GiftMessage;
            }
            set
            {
                GiftMessage = value.ToGiftMessage();
            }
        }

        /// <summary>
        /// Gets or sets the global currency code.
        /// </summary>
        [JsonProperty("global_currency_code")]
        public virtual string GlobalCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total of the sales order.
        /// </summary>
        [JsonProperty("grand_total")]
        public virtual decimal? GrandTotal
        { get; set; }

        /// <summary>
        /// Specifies the order state to hold the sales order before releasing it.
        /// </summary>
        [JsonProperty("hold_before_state")]
        public virtual string HoldBeforeState
        { get; set; }

        /// <summary>
        /// Specifies the order status to hold the sales order before releasing it.
        /// </summary>
        [JsonProperty("hold_before_status")]
        public virtual string HoldBeforeStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the increment ID.
        /// </summary>
        [JsonProperty("increment_id")]
        public virtual string IncrementID
        { get; set; }

        /// <summary>
        /// Indicates whether the sales order is a virtual order.
        /// </summary>
        [JsonProperty("is_virtual")]
        public virtual bool? IsVirtual
        { get; set; }

        /// <summary>
        /// Specifies the currency code of the order.
        /// </summary>
        [JsonProperty("order_currency_code")]
        public virtual string OrderCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the original increment ID.
        /// </summary>
        [JsonProperty("original_increment_id")]
        public virtual string OriginalIncrementID
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization expiration.
        /// </summary>
        [JsonProperty("payment_auth_expiration")]
        public virtual int? PaymentAuthorizationExpiration
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization amount.
        /// </summary>
        [JsonProperty("payment_authorization_amount")]
        public virtual decimal? PaymentAuthorizationAmount
        { get; set; }

        /// <summary>
        /// Indicates whether the PayPal instant payment notification service has been notified.
        /// </summary>
        public virtual bool? PayPalCustomerNotified
        { get; set; }

        /// <summary>
        /// Gets or sets the protection code.
        /// </summary>
        [JsonProperty("protect_code")]
        public virtual string ProtectCode
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="QuoteAddress.AddressID"/> value of <see cref="QuoteAddress"/>.
        /// </summary>
        [JsonProperty("quote_address_id")]
        public virtual uint QuoteAddressID
        {
            get
            {
                return QuoteAddress.ID;
            }
            set
            {
                QuoteAddress.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated quote address.
        /// </summary>
        public virtual QuoteAddress QuoteAddress
        {
            get
            {
                if (_quoteAddress == null)
                {
                    _quoteAddress = new QuoteAddress();
                }

                return _quoteAddress;
            }
            set
            {
                _quoteAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated quote address.
        /// </summary>
        IQuoteAddress ISalesOrder.QuoteAddress
        {
            get
            {
                return QuoteAddress;
            }
            set
            {
                QuoteAddress = value.ToQuoteAddress();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Quote.EntityID"/> of <see cref="Quote"/>.
        /// </summary>
        [JsonProperty("quote_id")]
        public virtual uint QuoteID
        {
            get
            {
                return Quote.ID;
            }
            set
            {
                Quote.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated quote.
        /// </summary>
        public virtual Quote Quote
        {
            get
            {
                if (_quote == null)
                {
                    _quote = new Quote();
                }

                return _quote;
            }
            set
            {
                _quote = value;
            }
        }

        /// <summary>
        /// Gets or sets the associated quote.
        /// </summary>
        IQuote ISalesOrder.Quote
        {
            get
            {
                return Quote;
            }
            set
            {
                Quote = value.ToQuote();
            }
        }

        /// <summary>
        /// Gets the child ID for this entity.
        /// </summary>
        [JsonProperty("relation_child_id")]
        public virtual string ChildID
        { get; set; }

        /// <summary>
        /// Gets the child ID for this entity.
        /// </summary>
        [JsonProperty("relation_child_real_id")]
        public virtual string ChildRealID
        { get; set; }

        /// <summary>
        /// Gets the parent ID for this entity.
        /// </summary>
        [JsonProperty("relation_parent_id")]
        public virtual string ParentID
        { get; set; }

        /// <summary>
        /// Gets the parent ID for this entity.
        /// </summary>
        [JsonProperty("relation_parent_real_id")]
        public virtual string ParentRealID
        { get; set; }

        /// <summary>
        /// Gets or sets the remote IP address of the machine who created the sales order request.
        /// </summary>
        [JsonProperty("remote_ip")]
        public virtual string RemoteIP
        { get; set; }

        /// <summary>
        /// Gets or sets the reward currency amount.
        /// </summary>
        public virtual decimal? RewardCurrencyAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the reward points balance at the time of the sales order.
        /// </summary>
        public virtual int? RewardPointsBalance
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of reward points that were refunded.
        /// </summary>
        public virtual int? RewardPointsBalanceRefund
        { get; set; }

        /// <summary>
        /// Gets or sets the reward currency amount refunded total.
        /// </summary>
        public virtual decimal? RewardCurrencyAmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the reward currency amount invoiced.
        /// </summary>
        public virtual decimal? RewardCurrencyAmountInvoiced
        { get; set; }

        /// <summary>
        /// Indicates whether an e-mail should be dispatched about the sales order.
        /// </summary>
        public virtual bool? SendEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping address for the sales order.
        /// </summary>
        public virtual SalesOrderAddress ShippingAddress
        {
            get
            {
                if (_shippingAddress == null)
                {
                    _shippingAddress = new SalesOrderAddress();
                }

                return _shippingAddress;
            }
            set
            {
                _shippingAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the shipping address for the sales order.
        /// </summary>
        ISalesOrderAddress ISalesOrder.ShippingAddress
        {
            get
            {
                return ShippingAddress;
            }
            set
            {
                ShippingAddress = value.ToSalesOrderAddress();
            }
        }

        /// <summary>
        /// Gets or sets the shipping amount.
        /// </summary>
        [JsonProperty("shipping_amount")]
        public virtual decimal? ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the canceled shipping amount.
        /// </summary>
        [JsonProperty("shipping_canceled")]
        public virtual decimal? ShippingCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping description.
        /// </summary>
        [JsonProperty("shipping_description")]
        public virtual string ShippingDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount.
        /// </summary>
        [JsonProperty("shipping_discount_amount")]
        public virtual decimal? ShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount.
        /// </summary>
        [JsonProperty("shipping_discount_tax_compensation_amount")]
        public virtual decimal? ShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping amount including tax.
        /// </summary>
        [JsonProperty("shipping_incl_tax")]
        public virtual decimal? ShippingIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping amount that was invoiced.
        /// </summary>
        [JsonProperty("shipping_invoiced")]
        public virtual decimal? ShippingInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping method.
        /// </summary>
        public virtual string ShippingMethod
        { get; set; }

        /// <summary>
        /// Gets or sets the total shipping refund amount.
        /// </summary>
        [JsonProperty("shipping_refunded")]
        public virtual decimal? ShippingRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount.
        /// </summary>
        [JsonProperty("shipping_tax_amount")]
        public virtual decimal? ShippingTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount that was refunded.
        /// </summary>
        [JsonProperty("shipping_tax_refunded")]
        public virtual decimal? ShippingTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the state of the sales order.
        /// </summary>
        [JsonProperty("state")]
        public virtual string State
        { get; set; }

        /// <summary>
        /// Gets or sets the status of the sales order.
        /// </summary>
        [JsonProperty("status")]
        public virtual string Status
        { get; set; }

        /// <summary>
        /// Gets or sets the store currency code.
        /// </summary>
        [JsonProperty("store_currency_code")]
        public virtual string StoreCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Store.ID"/> value of <see cref="Store"/>.
        /// </summary>
        [JsonProperty("store_id")]
        public virtual uint StoreID
        {
            get
            {
                return Store.ID;
            }
            set
            {
                Store.ID = value;
            }
        }

        /// <summary>
        /// Gets or sets the store that generated the sales order.
        /// </summary>
        public virtual Store Store
        {
            get
            {
                if (_store == null)
                {
                    _store = new Store();
                }

                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /// <summary>
        /// Gets or sets the store that generated the sales order.
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
        /// Gets or sets the store name.
        /// </summary>
        [JsonProperty("store_name")]
        public virtual string StoreName
        { get; set; }

        /// <summary>
        /// Gets or sets the store to base rate.
        /// </summary>
        [JsonProperty("store_to_base_rate")]
        public virtual decimal? StoreToBaseRate
        { get; set; }

        /// <summary>
        /// Gets or sets the store to order rate.
        /// </summary>
        [JsonProperty("store_to_order_rate")]
        public virtual decimal? StoreToOrderRate
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal.
        /// </summary>
        [JsonProperty("subtotal")]
        public virtual decimal? Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal that was canceled.
        /// </summary>
        [JsonProperty("subtotal_canceled")]
        public virtual decimal? SubtotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including tax.
        /// </summary>
        [JsonProperty("subtotal_incl_tax")]
        public virtual decimal? SubtotalIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal that was invoiced.
        /// </summary>
        [JsonProperty("subtotal_invoiced")]
        public virtual decimal? SubtotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal that was refunded.
        /// </summary>
        [JsonProperty("subtotal_refunded")]
        public virtual decimal? SubtotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        [JsonProperty("tax_amount")]
        public virtual decimal? TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount that was canceled.
        /// </summary>
        [JsonProperty("tax_canceled")]
        public virtual decimal? TaxCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount that was invoiced.
        /// </summary>
        [JsonProperty("tax_invoiced")]
        public virtual decimal? TaxInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount that was refunded.
        /// </summary>
        [JsonProperty("tax_refunded")]
        public virtual decimal? TaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount that was canceled.
        /// </summary>
        [JsonProperty("total_canceled")]
        public virtual decimal? TotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount due.
        /// </summary>
        [JsonProperty("total_due")]
        public virtual decimal? TotalDue
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount invoiced.
        /// </summary>
        [JsonProperty("total_invoiced")]
        public virtual decimal? TotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items on the sales order.
        /// </summary>
        [JsonProperty("total_item_count")]
        public virtual ushort TotalItemCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded offline.
        /// </summary>
        [JsonProperty("total_offline_refunded")]
        public virtual decimal? TotalRefundedOffline
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded online.
        /// </summary>
        [JsonProperty("total_online_refunded")]
        public virtual decimal? TotalRefundedOnline
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount paid.
        /// </summary>
        [JsonProperty("total_paid")]
        public virtual decimal? TotalPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity ordered.
        /// </summary>
        [JsonProperty("total_qty_ordered")]
        public virtual decimal? TotalQuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded.
        /// </summary>
        [JsonProperty("total_refunded")]
        public virtual decimal? TotalRefunded
        { get; set; }

        /// <summary>
        /// Gets the date/time the entity was updated.
        /// </summary>
        Instant ISalesOrder.UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets the date/time the entity was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public virtual DateTime UpdatedAt
        {
            get
            {
                return ((ISalesOrder)(this)).UpdatedAt.ToDateTimeUtc();
            }
            set
            {
                ((ISalesOrder)(this)).UpdatedAt = Instant.FromDateTimeUtc(value.ToUniversalTime());
            }
        }

        /// <summary>
        /// Gets or sets the total weight of the items on the sales order.
        /// </summary>
        [JsonProperty("weight")]
        public virtual decimal? Weight
        { get; set; }

        /// <summary>
        /// Gets or sets who the transaction was forwarded for.
        /// </summary>
        [JsonProperty("x_forwarded_for")]
        public virtual string TransactionForwardedFor
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrder"/> class with no arguments.
        /// </summary>
        public SalesOrder()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrder"/> class with the specified rule ID and <see cref="MagentoServer"/>.
        /// </summary>
        /// <param name="orderId">Order ID.</param>
        /// <param name="server"><see cref="MagentoServer"/> the entity resides on.</param>
        public SalesOrder(uint orderId, MagentoServer server)
            : base(orderId, server)
        { }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return (obj == null || !(obj is ISalesOrder)) ? false : Equals(obj as ISalesOrder);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
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
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals =
                    x.AdjustmentNegative.GetValueOrDefault().Equals(y.AdjustmentNegative.GetValueOrDefault())
                    && x.AdjustmentPositive.GetValueOrDefault().Equals(y.AdjustmentPositive.GetValueOrDefault())
                    && String.Equals(x.AppliedRuleIDs, y.AppliedRuleIDs, StringComparison.InvariantCultureIgnoreCase)
                    && x.BaseAdjustmentNegative.GetValueOrDefault().Equals(y.BaseAdjustmentNegative.GetValueOrDefault())
                    && x.BaseAdjustmentPositive.GetValueOrDefault().Equals(y.BaseAdjustmentPositive.GetValueOrDefault())
                    && String.Equals(x.BaseCurrencyCode, y.BaseCurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                    && x.BaseCustomerBalanceAmount.GetValueOrDefault().Equals(y.BaseCustomerBalanceAmount.GetValueOrDefault())
                    && x.BaseCustomerBalanceInvoiced.GetValueOrDefault().Equals(y.BaseCustomerBalanceInvoiced.GetValueOrDefault())
                    && x.BaseCustomerBalanceRefunded.GetValueOrDefault().Equals(y.BaseCustomerBalanceRefunded.GetValueOrDefault())
                    && x.BaseCustomerBalanceTotalRefunded.GetValueOrDefault().Equals(y.BaseCustomerBalanceTotalRefunded.GetValueOrDefault())
                    && x.BaseDiscountAmount.GetValueOrDefault().Equals(y.BaseDiscountAmount.GetValueOrDefault())
                    && x.BaseDiscountCanceled.GetValueOrDefault().Equals(y.BaseDiscountCanceled.GetValueOrDefault())
                    && x.BaseDiscountInvoiced.GetValueOrDefault().Equals(y.BaseDiscountInvoiced.GetValueOrDefault())
                    && x.BaseDiscountRefunded.GetValueOrDefault().Equals(y.BaseDiscountRefunded.GetValueOrDefault())
                    && x.BaseDiscountTaxCompensationAmount.GetValueOrDefault().Equals(y.BaseDiscountTaxCompensationAmount.GetValueOrDefault())
                    && x.BaseDiscountTaxCompensationInvoiced.GetValueOrDefault().Equals(y.BaseDiscountTaxCompensationInvoiced.GetValueOrDefault())
                    && x.BaseDiscountTaxCompensationRefunded.GetValueOrDefault().Equals(y.BaseDiscountTaxCompensationRefunded.GetValueOrDefault())
                    && x.BaseGiftCardsAmount.GetValueOrDefault().Equals(y.BaseGiftCardsAmount.GetValueOrDefault())
                    && x.BaseGiftCardsInvoiced.GetValueOrDefault().Equals(y.BaseGiftCardsInvoiced.GetValueOrDefault())
                    && x.BaseGiftCardsRefunded.GetValueOrDefault().Equals(y.BaseGiftCardsRefunded.GetValueOrDefault())
                    && x.BaseGrandTotal.GetValueOrDefault().Equals(y.BaseGrandTotal.GetValueOrDefault())
                    && x.BaseRewardCurrencyAmount.GetValueOrDefault().Equals(y.BaseRewardCurrencyAmount.GetValueOrDefault())
                    && x.BaseRewardCurrencyAmountInvoiced.GetValueOrDefault().Equals(y.BaseRewardCurrencyAmountInvoiced.GetValueOrDefault())
                    && x.BaseRewardCurrencyAmountRefunded.GetValueOrDefault().Equals(y.BaseRewardCurrencyAmountRefunded.GetValueOrDefault())
                    && x.BaseShippingAmount.GetValueOrDefault().Equals(y.BaseShippingAmount.GetValueOrDefault())
                    && x.BaseShippingCanceled.GetValueOrDefault().Equals(y.BaseShippingCanceled.GetValueOrDefault())
                    && x.BaseShippingDiscountAmount.GetValueOrDefault().Equals(y.BaseShippingDiscountAmount.GetValueOrDefault())
                    && x.BaseShippingDiscountTaxCompensationAmount.GetValueOrDefault().Equals(y.BaseShippingDiscountTaxCompensationAmount.GetValueOrDefault())
                    && x.BaseShippingIncludingTax.GetValueOrDefault().Equals(y.BaseShippingIncludingTax.GetValueOrDefault())
                    && x.BaseShippingInvoiced.GetValueOrDefault().Equals(y.BaseShippingInvoiced.GetValueOrDefault())
                    && x.BaseShippingRefunded.GetValueOrDefault().Equals(y.BaseShippingRefunded.GetValueOrDefault())
                    && x.BaseShippingTaxAmount.GetValueOrDefault().Equals(y.BaseShippingTaxAmount.GetValueOrDefault())
                    && x.BaseShippingTaxRefunded.GetValueOrDefault().Equals(y.BaseShippingTaxRefunded.GetValueOrDefault())
                    && x.BaseSubtotal.GetValueOrDefault().Equals(y.BaseSubtotal.GetValueOrDefault())
                    && x.BaseSubtotalCanceled.GetValueOrDefault().Equals(y.BaseSubtotalCanceled.GetValueOrDefault())
                    && x.BaseSubtotalIncludingTax.GetValueOrDefault().Equals(y.BaseSubtotalIncludingTax.GetValueOrDefault())
                    && x.BaseSubtotalInvoiced.GetValueOrDefault().Equals(y.BaseSubtotalInvoiced.GetValueOrDefault())
                    && x.BaseSubtotalRefunded.GetValueOrDefault().Equals(y.BaseSubtotalRefunded.GetValueOrDefault())
                    && x.BaseTaxAmount.GetValueOrDefault().Equals(y.BaseTaxAmount.GetValueOrDefault())
                    && x.BaseTaxCanceled.GetValueOrDefault().Equals(y.BaseTaxCanceled.GetValueOrDefault())
                    && x.BaseTaxInvoiced.GetValueOrDefault().Equals(y.BaseTaxInvoiced.GetValueOrDefault())
                    && x.BaseTaxRefunded.GetValueOrDefault().Equals(y.BaseTaxRefunded.GetValueOrDefault())
                    && x.BaseToGlobalRate.GetValueOrDefault().Equals(y.BaseToGlobalRate.GetValueOrDefault())
                    && x.BaseToOrderRate.GetValueOrDefault().Equals(y.BaseToOrderRate.GetValueOrDefault())
                    && x.BaseTotalCanceled.GetValueOrDefault().Equals(y.BaseTotalCanceled.GetValueOrDefault())
                    && x.BaseTotalDue.GetValueOrDefault().Equals(y.BaseTotalDue.GetValueOrDefault())
                    && x.BaseTotalInvoiced.GetValueOrDefault().Equals(y.BaseTotalInvoiced.GetValueOrDefault())
                    && x.BaseTotalInvoicedCost.GetValueOrDefault().Equals(y.BaseTotalInvoicedCost.GetValueOrDefault())
                    && x.BaseTotalOfflineRefunded.GetValueOrDefault().Equals(y.BaseTotalOfflineRefunded.GetValueOrDefault())
                    && x.BaseTotalOnlineRefunded.GetValueOrDefault().Equals(y.BaseTotalOnlineRefunded.GetValueOrDefault())
                    && x.BaseTotalPaid.GetValueOrDefault().Equals(y.BaseTotalPaid.GetValueOrDefault())
                    && x.BaseTotalQuantityOrdered.GetValueOrDefault().Equals(y.BaseTotalQuantityOrdered.GetValueOrDefault())
                    && x.BaseTotalRefunded.GetValueOrDefault().Equals(y.BaseTotalRefunded.GetValueOrDefault())
                    && ((x.BillingAddress == null && y.BillingAddress == null) || (x.BillingAddress != null && x.BillingAddress.Equals(y.BillingAddress)))
                    && x.CanShipItemPartially.GetValueOrDefault().Equals(y.CanShipItemPartially.GetValueOrDefault())
                    && x.CanShipPartially.GetValueOrDefault().Equals(y.CanShipPartially.GetValueOrDefault())
                    && String.Equals(x.ChildID, y.ChildID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ChildRealID, y.ChildRealID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CouponCode, y.CouponCode, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CouponRuleName, y.CouponRuleName, StringComparison.InvariantCultureIgnoreCase)
                    && x.CreatedAt.Equals(y.CreatedAt)
                    && ((x.Customer == null && y.Customer == null) || (x.Customer != null && x.Customer.Equals(y.Customer)))
                    && x.CustomerBalanceAmount.GetValueOrDefault().Equals(y.CustomerBalanceAmount.GetValueOrDefault())
                    && x.CustomerBalanceInvoiced.GetValueOrDefault().Equals(y.CustomerBalanceInvoiced.GetValueOrDefault())
                    && x.CustomerBalanceRefunded.GetValueOrDefault().Equals(y.CustomerBalanceRefunded.GetValueOrDefault())
                    && x.CustomerBalanceTotalRefunded.GetValueOrDefault().Equals(y.CustomerBalanceTotalRefunded.GetValueOrDefault())
                    && x.CustomerDateOfBirth.GetValueOrDefault().Equals(y.CustomerDateOfBirth.GetValueOrDefault())
                    && String.Equals(x.CustomerEmail, y.CustomerEmail, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerFirstName, y.CustomerFirstName, StringComparison.InvariantCultureIgnoreCase)
                    && x.CustomerGender.GetValueOrDefault().Equals(y.CustomerGender.GetValueOrDefault())
                    && ((x.CustomerGroup == null && y.CustomerGroup == null) || (x.CustomerGroup != null && x.CustomerGroup.Equals(y.CustomerGroup)))
                    && x.CustomerIsGuest.GetValueOrDefault().Equals(y.CustomerIsGuest.GetValueOrDefault())
                    && String.Equals(x.CustomerLastName, y.CustomerLastName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerMiddleName, y.CustomerMiddleName, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerNote, y.CustomerNote, StringComparison.InvariantCultureIgnoreCase)
                    && x.CustomerNotifyNote.GetValueOrDefault().Equals(y.CustomerNotifyNote.GetValueOrDefault())
                    && String.Equals(x.CustomerPrefix, y.CustomerPrefix, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerSuffix, y.CustomerSuffix, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.CustomerValueAddedTax, y.CustomerValueAddedTax, StringComparison.InvariantCultureIgnoreCase)
                    && x.DiscountAmount.GetValueOrDefault().Equals(y.DiscountAmount.GetValueOrDefault())
                    && x.DiscountCanceled.GetValueOrDefault().Equals(y.DiscountCanceled.GetValueOrDefault())
                    && String.Equals(x.DiscountDescription, y.DiscountDescription, StringComparison.InvariantCultureIgnoreCase)
                    && x.DiscountInvoiced.GetValueOrDefault().Equals(y.DiscountInvoiced.GetValueOrDefault())
                    && x.DiscountRefunded.GetValueOrDefault().Equals(y.DiscountRefunded.GetValueOrDefault())
                    && x.DiscountTaxCompensationAmount.GetValueOrDefault().Equals(y.DiscountTaxCompensationAmount.GetValueOrDefault())
                    && x.DiscountTaxCompensationInvoiced.GetValueOrDefault().Equals(y.DiscountTaxCompensationInvoiced.GetValueOrDefault())
                    && x.DiscountTaxCompensationRefunded.GetValueOrDefault().Equals(y.DiscountTaxCompensationRefunded.GetValueOrDefault())
                    && x.EditIncrement.GetValueOrDefault().Equals(y.EditIncrement.GetValueOrDefault())
                    && x.EmailSent.GetValueOrDefault().Equals(y.EmailSent.GetValueOrDefault())
                    && String.Equals(x.ExternalCustomerID, y.ExternalCustomerID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ExternalOrderID, y.ExternalOrderID, StringComparison.InvariantCultureIgnoreCase)
                    && x.ForcedShipmentWithInvoice.GetValueOrDefault().Equals(y.ForcedShipmentWithInvoice.GetValueOrDefault())
                    && String.Equals(x.GiftCards, y.GiftCards, StringComparison.InvariantCultureIgnoreCase)
                    && x.GiftCardsAmount.GetValueOrDefault().Equals(y.GiftCardsAmount.GetValueOrDefault())
                    && x.GiftCardsInvoiced.GetValueOrDefault().Equals(y.GiftCardsInvoiced.GetValueOrDefault())
                    && x.GiftCardsRefunded.GetValueOrDefault().Equals(y.GiftCardsRefunded.GetValueOrDefault())
                    && ((x.GiftMessage == null && y.GiftMessage == null) || (x.GiftMessage != null && x.GiftMessage.Equals(y.GiftMessage)))
                    && String.Equals(x.GlobalCurrencyCode, y.GlobalCurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                    && x.GrandTotal.GetValueOrDefault().Equals(y.GrandTotal.GetValueOrDefault())
                    && String.Equals(x.HoldBeforeState, y.HoldBeforeState, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.HoldBeforeStatus, y.HoldBeforeStatus, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.IncrementID, y.IncrementID, StringComparison.InvariantCultureIgnoreCase)
                    && x.IsVirtual.GetValueOrDefault().Equals(y.IsVirtual.GetValueOrDefault())
                    && String.Equals(x.OrderCurrencyCode, y.OrderCurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.OriginalIncrementID, y.OriginalIncrementID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ParentID, y.ParentID, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.ParentRealID, y.ParentRealID, StringComparison.InvariantCultureIgnoreCase)
                    && x.PaymentAuthorizationAmount.GetValueOrDefault().Equals(y.PaymentAuthorizationAmount.GetValueOrDefault())
                    && x.PaymentAuthorizationExpiration.GetValueOrDefault().Equals(y.PaymentAuthorizationExpiration.GetValueOrDefault())
                    && x.PayPalCustomerNotified.GetValueOrDefault().Equals(y.PayPalCustomerNotified.GetValueOrDefault())
                    && String.Equals(x.ProtectCode, y.ProtectCode, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Quote == null && y.Quote == null) || (x.Quote != null && x.Quote.Equals(y.Quote)))
                    && ((x.QuoteAddress == null && y.QuoteAddress == null) || (x.QuoteAddress != null && x.QuoteAddress.Equals(y.QuoteAddress)))
                    && String.Equals(x.RemoteIP, y.RemoteIP, StringComparison.InvariantCultureIgnoreCase)
                    && x.RewardCurrencyAmount.GetValueOrDefault().Equals(y.RewardCurrencyAmount.GetValueOrDefault())
                    && x.RewardCurrencyAmountInvoiced.GetValueOrDefault().Equals(y.RewardCurrencyAmountInvoiced.GetValueOrDefault())
                    && x.RewardCurrencyAmountRefunded.GetValueOrDefault().Equals(y.RewardCurrencyAmountRefunded.GetValueOrDefault())
                    && x.RewardPointsBalance.GetValueOrDefault().Equals(y.RewardPointsBalance.GetValueOrDefault())
                    && x.RewardPointsBalanceRefund.GetValueOrDefault().Equals(y.RewardPointsBalanceRefund.GetValueOrDefault())
                    && x.SendEmail.GetValueOrDefault().Equals(y.SendEmail.GetValueOrDefault())
                    && ((x.ShippingAddress == null && y.ShippingAddress == null) || (x.ShippingAddress != null && x.ShippingAddress.Equals(y.ShippingAddress)))
                    && x.ShippingAmount.GetValueOrDefault().Equals(y.ShippingAmount.GetValueOrDefault())
                    && x.ShippingCanceled.GetValueOrDefault().Equals(y.ShippingCanceled.GetValueOrDefault())
                    && String.Equals(x.ShippingDescription, y.ShippingDescription, StringComparison.InvariantCultureIgnoreCase)
                    && x.ShippingDiscountAmount.GetValueOrDefault().Equals(y.ShippingDiscountAmount.GetValueOrDefault())
                    && x.ShippingDiscountTaxCompensationAmount.GetValueOrDefault().Equals(y.ShippingDiscountTaxCompensationAmount.GetValueOrDefault())
                    && x.ShippingIncludingTax.GetValueOrDefault().Equals(y.ShippingIncludingTax.GetValueOrDefault())
                    && x.ShippingInvoiced.GetValueOrDefault().Equals(y.ShippingInvoiced.GetValueOrDefault())
                    && String.Equals(x.ShippingMethod, y.ShippingMethod, StringComparison.InvariantCultureIgnoreCase)
                    && x.ShippingRefunded.GetValueOrDefault().Equals(y.ShippingRefunded.GetValueOrDefault())
                    && x.ShippingTaxAmount.GetValueOrDefault().Equals(y.ShippingTaxAmount.GetValueOrDefault())
                    && x.ShippingTaxRefunded.GetValueOrDefault().Equals(y.ShippingTaxRefunded.GetValueOrDefault())
                    && String.Equals(x.State, y.State, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.Status, y.Status, StringComparison.InvariantCultureIgnoreCase)
                    && ((x.Store == null && y.Store == null) || (x.Store != null && x.Store.Equals(y.Store)))
                    && String.Equals(x.StoreCurrencyCode, y.StoreCurrencyCode, StringComparison.InvariantCultureIgnoreCase)
                    && String.Equals(x.StoreName, y.StoreName, StringComparison.InvariantCultureIgnoreCase)
                    && x.StoreToBaseRate.GetValueOrDefault().Equals(y.StoreToBaseRate.GetValueOrDefault())
                    && x.StoreToOrderRate.GetValueOrDefault().Equals(y.StoreToOrderRate.GetValueOrDefault())
                    && x.Subtotal.GetValueOrDefault().Equals(y.Subtotal.GetValueOrDefault())
                    && x.SubtotalCanceled.GetValueOrDefault().Equals(y.SubtotalCanceled.GetValueOrDefault())
                    && x.SubtotalIncludingTax.GetValueOrDefault().Equals(y.SubtotalIncludingTax.GetValueOrDefault())
                    && x.SubtotalInvoiced.GetValueOrDefault().Equals(y.SubtotalInvoiced.GetValueOrDefault())
                    && x.SubtotalCanceled.GetValueOrDefault().Equals(y.SubtotalCanceled.GetValueOrDefault())
                    && x.SubtotalIncludingTax.GetValueOrDefault().Equals(y.SubtotalIncludingTax.GetValueOrDefault())
                    && x.SubtotalInvoiced.GetValueOrDefault().Equals(y.SubtotalInvoiced.GetValueOrDefault())
                    && x.SubtotalRefunded.GetValueOrDefault().Equals(y.SubtotalRefunded.GetValueOrDefault())
                    && x.TaxAmount.GetValueOrDefault().Equals(y.TaxAmount.GetValueOrDefault())
                    && x.TaxCanceled.GetValueOrDefault().Equals(y.TaxCanceled.GetValueOrDefault())
                    && x.TaxInvoiced.GetValueOrDefault().Equals(y.TaxInvoiced.GetValueOrDefault())
                    && x.TaxRefunded.GetValueOrDefault().Equals(y.TaxRefunded.GetValueOrDefault())
                    && x.TotalCanceled.GetValueOrDefault().Equals(y.TotalCanceled.GetValueOrDefault())
                    && x.TotalDue.GetValueOrDefault().Equals(y.TotalDue.GetValueOrDefault())
                    && x.TotalInvoiced.GetValueOrDefault().Equals(y.TotalInvoiced.GetValueOrDefault())
                    && x.TotalItemCount.Equals(y.TotalItemCount)
                    && x.TotalPaid.GetValueOrDefault().Equals(y.TotalPaid.GetValueOrDefault())
                    && x.TotalQuantityOrdered.GetValueOrDefault().Equals(y.TotalQuantityOrdered.GetValueOrDefault())
                    && x.TotalRefunded.GetValueOrDefault().Equals(y.TotalRefunded.GetValueOrDefault())
                    && x.TotalRefundedOffline.GetValueOrDefault().Equals(y.TotalRefundedOffline.GetValueOrDefault())
                    && x.TotalRefundedOnline.GetValueOrDefault().Equals(y.TotalRefundedOnline.GetValueOrDefault())
                    && String.Equals(x.TransactionForwardedFor, y.TransactionForwardedFor, StringComparison.InvariantCultureIgnoreCase)
                    && x.UpdatedAt.Equals(y.UpdatedAt)
                    && x.Weight.GetValueOrDefault().Equals(y.Weight.GetValueOrDefault());
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj"><see cref="IQuote"/> object.</param>
        /// <returns>Hash code for the specified object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual int GetHashCode(ISalesOrder obj)
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
            Currency currency = default(Currency);
            Money money = default(Money);

            builder.Append('[');
            builder.Append(EntityID);
            builder.Append(']');
            builder.Append(' ');

            if (!String.IsNullOrWhiteSpace(CustomerLastName))
            {
                builder.Append(CustomerLastName.Trim());

                if (!String.IsNullOrWhiteSpace(CustomerFirstName))
                {
                    builder.Append(", ");
                }
            }

            if (!String.IsNullOrWhiteSpace(CustomerFirstName))
            {
                builder.Append(CustomerFirstName.Trim());
            }

            builder = new StringBuilder(builder.ToString().Trim());
            builder.Append(' ');

            if (!String.IsNullOrEmpty(OrderCurrencyCode) || !String.IsNullOrWhiteSpace(BaseCurrencyCode))
            {
                if (String.IsNullOrWhiteSpace(OrderCurrencyCode))
                {
                    try
                    {
                        currency = Currency.FromCode(BaseCurrencyCode);
                    }
                    catch
                    {
                        currency = Currency.FromCode("USD");    // default to USD
                    }
                }
                else
                {
                    try
                    {
                        currency = Currency.FromCode(OrderCurrencyCode);
                    }
                    catch
                    {
                        currency = Currency.FromCode("USD");    // default to USD
                    }
                }
            }
            else
            {
                currency = Currency.FromCode("USD");    // default to USD
            }

            money = Money.Parse(Convert.ToString(GrandTotal.GetValueOrDefault()), currency);

            builder.Append('{');
            builder.Append(money.ToString());
            builder.Append('}');

            return builder.ToString();
        }

        /// <summary>
        /// Returns a JSON string representing the current object. This method must be inherited.
        /// </summary>
        /// <typeparam name="T">Type of object to serialize.</typeparam>
        /// <returns>JSON string.</returns>
        public override string ToJson<T>()
        {
            return this.SerializeJson(this);
        }
    }
}

