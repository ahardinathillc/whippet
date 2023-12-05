using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides information about a Magento sales order.
    /// </summary>
    public class SalesOrderInterface : IExtensionInterface, IExtensionAttributes<SalesOrderExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the negative adjustment value.
        /// </summary>
        [JsonProperty("adjustment_negative")]
        public decimal NegativeAdjustment
        { get; set; }

        /// <summary>
        /// Gets or sets the positive adjustment value.
        /// </summary>
        [JsonProperty("adjustment_positive")]
        public decimal PositiveAdjustment
        { get; set; }

        /// <summary>
        /// Gets or sets the applied rule IDs.
        /// </summary>
        [JsonProperty("applied_rule_ids")]
        public string AppliedRuleIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the negative adjustment value in base currency.
        /// </summary>
        [JsonProperty("base_adjustment_negative")]
        public decimal NegativeAdjustmentBase
        { get; set; }

        /// <summary>
        /// Gets or sets the positive adjustment value in base currency.
        /// </summary>
        [JsonProperty("base_adjustment_positive")]
        public decimal PositiveAdjustmentBase
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code.
        /// </summary>
        [JsonProperty("base_currency_code")]
        public string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount in base currency.
        /// </summary>
        [JsonProperty("base_discount_amount")]
        public decimal DiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount canceled in base currency.
        /// </summary>
        [JsonProperty("base_discount_canceled")]
        public decimal DiscountCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount invoiced in base currency.
        /// </summary>
        [JsonProperty("base_discount_invoiced")]
        public decimal DiscountInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount refunded in base currency.
        /// </summary>
        [JsonProperty("base_discount_refunded")]
        public decimal DiscountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total amount in base currency.
        /// </summary>
        [JsonProperty("base_grand_total")]
        public decimal GrandTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax compensation amount in base currency.
        /// </summary>
        [JsonProperty("base_discount_tax_compensation_amount")]
        public decimal DiscountTaxCompensationAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax compensation invoiced amount in base currency.
        /// </summary>
        [JsonProperty("base_discount_tax_compensation_invoiced")]
        public decimal DiscountTaxCompensationInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax compensation refunded amount in base currency.
        /// </summary>
        [JsonProperty("base_discount_tax_compensation_refunded")]
        public decimal DiscountTaxCompensationRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in base currency.
        /// </summary>
        [JsonProperty("base_shipping_amount")]
        public decimal ShippingAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount canceled in base currency.
        /// </summary>
        [JsonProperty("base_shipping_canceled")]
        public decimal ShippingCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount in base currency.
        /// </summary>
        [JsonProperty("base_shipping_discount_amount")]
        public decimal ShippingDiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount in base currency.
        /// </summary>
        [JsonProperty("base_shipping_discount_tax_compensation_amt")]
        public decimal ShippingDiscountTaxCompensationAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount including tax in base currency.
        /// </summary>
        [JsonProperty("base_shipping_incl_tax")]
        public decimal ShippingWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount invoiced in base currency.
        /// </summary>
        [JsonProperty("base_shipping_invoiced")]
        public decimal ShippingInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount refunded in base currency.
        /// </summary>
        [JsonProperty("base_shipping_refunded")]
        public decimal ShippingRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax amount in base currency.
        /// </summary>
        [JsonProperty("base_shipping_tax_amount")]
        public decimal ShippingTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping tax refunded amount in base currency.
        /// </summary>
        [JsonProperty("base_shipping_tax_refunded")]
        public decimal ShippingTaxRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount in base currency.
        /// </summary>
        [JsonProperty("base_subtotal")]
        public decimal SubtotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount canceled in base currency.
        /// </summary>
        [JsonProperty("base_subtotal_canceled")]
        public decimal SubtotalCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount including tax in base currency.
        /// </summary>
        [JsonProperty("base_subtotal_incl_tax")]
        public decimal SubtotalWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount invoiced in base currency.
        /// </summary>
        [JsonProperty("base_subtotal_invoiced")]
        public decimal SubtotalInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount refunded in base currency.
        /// </summary>
        [JsonProperty("base_subtotal_refunded")]
        public decimal SubtotalRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in base currency.
        /// </summary>
        [JsonProperty("base_tax_amount")]
        public decimal TaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount canceled in base currency.
        /// </summary>
        [JsonProperty("base_tax_canceled")]
        public decimal TaxCanceledBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount invoiced in base currency.
        /// </summary>
        [JsonProperty("base_tax_invoiced")]
        public decimal TaxInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount refunded in base currency.
        /// </summary>
        [JsonProperty("base_tax_refunded")]
        public decimal TaxRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount canceled in base currency.
        /// </summary>
        [JsonProperty("base_total_canceled")]
        public decimal TaxCanceledTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount due in base currency.
        /// </summary>
        [JsonProperty("base_total_due")]
        public decimal TotalDueBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount invoiced in base currency.
        /// </summary>
        [JsonProperty("base_total_due")]
        public decimal TotalInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total invoiced cost amount in base currency.
        /// </summary>
        [JsonProperty("base_total_invoiced_cost")]
        public decimal TotalInvoicedCostBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total refunded amount (offline) in base currency.
        /// </summary>
        [JsonProperty("base_total_offline_refunded")]
        public decimal TotalOfflineRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total refunded amount (online) in base currency.
        /// </summary>
        [JsonProperty("base_total_online_refunded")]
        public decimal TotalOnlineRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount paid in base currency.
        /// </summary>
        [JsonProperty("base_total_paid")]
        public decimal TotalPaidBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity ordered in base currency.
        /// </summary>
        [JsonProperty("base_total_qty_ordered")]
        public decimal TotalQuantityOrderedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded in base currency.
        /// </summary>
        [JsonProperty("base_total_refund")]
        public decimal TotalRefundBase
        { get; set; }

        /// <summary>
        /// Gets or sets the base-to-global rate.
        /// </summary>
        [JsonProperty("base_to_global_rate")]
        public decimal BaseToGlobalRate
        { get; set; }

        /// <summary>
        /// Gets or sets the billing address ID.
        /// </summary>
        [JsonProperty("billing_address_id")]
        public int BillingAddressID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the order can be shipped partially. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("can_ship_partially")]
        public int CanShipPartially
        { get; set; }

        /// <summary>
        /// Flag that indicates whether an item can be shipped partially. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("can_ship_partially_item")]
        public int CanShipItemPartially
        { get; set; }

        /// <summary>
        /// Gets or sets the coupon code associated with the order.
        /// </summary>
        [JsonProperty("coupon_code")]
        public string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the order entry was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the customer date of birth.
        /// </summary>
        /// <remarks>In keeping with current security and privacy best practices, be sure you are aware of any potential legal and security risks associated with the storage of customers’ full date of birth (month, day, year) along with other personal identifiers (e.g., full name) before collecting or processing such data.</remarks>
        [JsonProperty("customer_dob")]
        public string CustomerDateOfBirth
        { get; set; }

        /// <summary>
        /// Gets or sets the customer e-mail address.
        /// </summary>
        [JsonProperty("customer_email")]
        public string CustomerEmail
        { get; set; }

        /// <summary>
        /// Gets or sets the customer first name.
        /// </summary>
        [JsonProperty("customer_firstname")]
        public string CustomerFirstName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer gender.
        /// </summary>
        [JsonProperty("customer_gender")]
        public int CustomerGender
        { get; set; }

        /// <summary>
        /// Gets or sets the customer group ID.
        /// </summary>
        [JsonProperty("customer_group_id")]
        public int CustomerGroupID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        [JsonProperty("customer_id")]
        public int CustomerID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the customer is a guest and not registered. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("customer_is_guest")]
        public int CustomerIsGuest
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        [JsonProperty("customer_lastname")]
        public string CustomerLastName
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's middle name.
        /// </summary>
        [JsonProperty("customer_middlename")]
        public string CustomerMiddleName
        { get; set; }

        /// <summary>
        /// Gets or sets the notice text.
        /// </summary>
        [JsonProperty("customer_note")]
        public string Notice
        { get; set; }

        /// <summary>
        /// Gets or sets the customer notification flag.
        /// </summary>
        [JsonProperty("customer_note_notify")]
        public bool NotifyNotice
        { get; set; }

        /// <summary>
        /// Gets or sets the customer prefix.
        /// </summary>
        [JsonProperty("customer_prefix")]
        public string CustomerPrefix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer suffix.
        /// </summary>
        [JsonProperty("customer_suffix")]
        public string CustomerSuffix
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's Value Added Tax (VAT) number.
        /// </summary>
        [JsonProperty("customer_taxvat")]
        public string CustomerVAT
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        [JsonProperty("discount_amount")]
        public decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount canceled amount.
        /// </summary>
        [JsonProperty("discount_canceled")]
        public decimal DiscountCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the discount description.
        /// </summary>
        [JsonProperty("discount_description")]
        public string DiscountDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount invoiced.
        /// </summary>
        [JsonProperty("discount_invoiced")]
        public decimal DiscountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount refunded amount.
        /// </summary>
        [JsonProperty("discount_refunded")]
        public decimal DiscountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the edit increment value.
        /// </summary>
        [JsonProperty("edit_increment")]
        public int EditIncrement
        { get; set; }

        /// <summary>
        /// Flag that indicates whether an e-mail was sent to the customer. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("email_sent")]
        public int EmailSent
        { get; set; }

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        [JsonProperty("entity_id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the external customer ID.
        /// </summary>
        [JsonProperty("ext_customer_id")]
        public string ExternalCustomerID
        { get; set; }

        /// <summary>
        /// Gets or sets the external order ID.
        /// </summary>
        [JsonProperty("ext_order_id")]
        public string ExternalOrderID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the order is shipped regardless of the status of the invoice. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("forced_shipment_with_invoice")]
        public int ForcedShipmentWithInvoice
        { get; set; }

        /// <summary>
        /// Gets or sets the global currency code.
        /// </summary>
        [JsonProperty("global_currency_code")]
        public string GlobalCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total of the invoice.
        /// </summary>
        [JsonProperty("grand_total")]
        public decimal GrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount.
        /// </summary>
        [JsonProperty("discount_tax_compensation_amount")]
        public decimal DiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation invoiced.
        /// </summary>
        [JsonProperty("discount_tax_compensation_invoiced")]
        public decimal DiscountTaxCompensationInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation refunded.
        /// </summary>
        [JsonProperty("discount_tax_compensation_refunded")]
        public decimal DiscountTaxCompensationRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the hold before state.
        /// </summary>
        [JsonProperty("hold_before_state")]
        public string HoldBeforeState
        { get; set; }

        /// <summary>
        /// Gets or sets the hold before status.
        /// </summary>
        [JsonProperty("hold_before_status")]
        public string HoldBeforeStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the increment ID.
        /// </summary>
        [JsonProperty("increment_id")]
        public string IncrementID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the order is virtual. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>. 
        /// </summary>
        [JsonProperty("is_virtual")]
        public int IsVirtual
        { get; set; }

        /// <summary>
        /// Gets or sets the order currency code.
        /// </summary>
        [JsonProperty("order_currency_code")]
        public string OrderCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the original order increment ID.
        /// </summary>
        [JsonProperty("original_increment_id")]
        public string OriginalIncrementID
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization amount.
        /// </summary>
        [JsonProperty("payment_authorization_amount")]
        public decimal PaymentAuthorizationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the payment authorization expiration date.
        /// </summary>
        [JsonProperty("payment_auth_expiration")]
        public int PaymentAuthorizationExpirationDate
        { get; set; }

        /// <summary>
        /// Gets or sets the protect code of the order.
        /// </summary>
        [JsonProperty("protect_code")]
        public string ProtectCode
        { get; set; }

        /// <summary>
        /// Gets or sets the quote address ID.
        /// </summary>
        [JsonProperty("quote_address_id")]
        public int QuoteAddressID
        { get; set; }

        /// <summary>
        /// Gets or sets the quote ID.
        /// </summary>
        [JsonProperty("quote_id")]
        public int QuoteID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation child's ID.
        /// </summary>
        [JsonProperty("relation_child_id")]
        public string RelationChildID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation child's real ID.
        /// </summary>
        [JsonProperty("relation_child_real_id")]
        public string RelationChildRealID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation parent's ID.
        /// </summary>
        [JsonProperty("relation_parent_id")]
        public string RelationParentID
        { get; set; }

        /// <summary>
        /// Gets or sets the relation parent's real ID.
        /// </summary>
        [JsonProperty("relation_parent_real_id")]
        public string RelationParentRealID
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's remote IP address.
        /// </summary>
        [JsonProperty("remote_ip")]
        public string RemoteIP
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount.
        /// </summary>
        [JsonProperty("shipping_amount")]
        public decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping canceled amount.
        /// </summary>
        [JsonProperty("shipping_canceled")]
        public decimal ShippingCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping description.
        /// </summary>
        [JsonProperty("shipping_description")]
        public string ShippingDescription
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount. 
        /// </summary>
        [JsonProperty("shipping_discount_amount")]
        public decimal ShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount tax compensation amount.
        /// </summary>
        [JsonProperty("shipping_discount_tax_compensation_amount")]
        public decimal ShippingDiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping including tax amount.
        /// </summary>
        [JsonProperty("shipping_incl_tax")]
        public decimal ShippingWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping including tax refund amount.
        /// </summary>
        [JsonProperty("shipping_tax_refunded")]
        public decimal ShippingTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the customer state.
        /// </summary>
        [JsonProperty("state")]
        public string State
        { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        [JsonProperty("status")]
        public string Status
        { get; set; }

        /// <summary>
        /// Gets or sets the store currency code.
        /// </summary>
        [JsonProperty("store_currency_code")]
        public string StoreCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        [JsonProperty("store_id")]
        public int StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the store name.
        /// </summary>
        [JsonProperty("store_name")]
        public string StoreName
        { get; set; }

        /// <summary>
        /// Gets or sets the store-to-base rate.
        /// </summary>
        [JsonProperty("store_to_base_rate")]
        public decimal StoreToBaseRate
        { get; set; }

        /// <summary>
        /// Gets or sets the store-to-order rate.
        /// </summary>
        [JsonProperty("store_to_order_rate")]
        public decimal StoreToOrderRate
        { get; set; }

        /// <summary>
        /// Gets or sets the order subtotal.
        /// </summary>
        [JsonProperty("subtotal")]
        public decimal Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal canceled amount.
        /// </summary>
        [JsonProperty("subtotal_canceled")]
        public decimal SubtotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including tax amount.
        /// </summary>
        [JsonProperty("subtotal_incl_tax")]
        public decimal SubtotalWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal invoiced amount.
        /// </summary>
        [JsonProperty("subtotal_invoiced")]
        public decimal SubtotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal amount refunded.
        /// </summary>
        [JsonProperty("subtotal_refunded")]
        public decimal SubtotalRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        [JsonProperty("tax_amount")]
        public decimal TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the amount of tax canceled.
        /// </summary>
        [JsonProperty("tax_canceled")]
        public decimal TaxCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount invoiced.
        /// </summary>
        [JsonProperty("tax_invoiced")]
        public decimal TaxInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount refunded.
        /// </summary>
        [JsonProperty("tax_refunded")]
        public decimal TaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total canceled amount.
        /// </summary>
        [JsonProperty("total_canceled")]
        public decimal TotalCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount due. 
        /// </summary>
        [JsonProperty("total_due")]
        public decimal TotalDue
        { get; set; }

        /// <summary>
        /// Gets or sets the total invoiced amount.
        /// </summary>
        [JsonProperty("total_invoiced")]
        public decimal TotalInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items on the order.
        /// </summary>
        [JsonProperty("total_item_count")]
        public int TotalItemCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded offline.
        /// </summary>
        [JsonProperty("total_offline_refunded")]
        public decimal TotalOfflineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded online.
        /// </summary>
        [JsonProperty("total_online_refunded")]
        public decimal TotalOnlineRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount paid on the order.
        /// </summary>
        [JsonProperty("total_paid")]
        public decimal TotalPaid
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity ordered.
        /// </summary>
        [JsonProperty("total_qty_ordered")]
        public decimal TotalQuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded.
        /// </summary>
        [JsonProperty("total_refunded")]
        public decimal TotalRefunded
        { get; set; }

        /// <summary>
        /// Gets the date and time the order was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the order weight.
        /// </summary>
        [JsonProperty("weight")]
        public decimal Weight
        { get; set; }

        /// <summary>
        /// Gets or sets the transaction forwarded for (X-Forwarded-For) field.
        /// </summary>
        [JsonProperty("x_forwarded_for")]
        public string TransactionForwardedFor
        { get; set; }

        /// <summary>
        /// Gets or sets the items associated with the order.
        /// </summary>
        [JsonProperty("items")]
        public SalesOrderItemInterface[] Items
        { get; set; }

        /// <summary>
        /// Gets or sets the billing address associated with the order.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        [JsonProperty("billing_address")]
        public SalesOrderAddressInterface BillingAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the payment information for the order.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        [JsonProperty("payment")]
        public SalesOrderPaymentInterface Payment
        { get; set; }

        /// <summary>
        /// Gets or sets the status histories of the current order.
        /// </summary>
        [JsonProperty("status_histories")]
        public SalesOrderStatusHistoryInterface[] StatusHistories
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderInterface()
        { }
    }
}
