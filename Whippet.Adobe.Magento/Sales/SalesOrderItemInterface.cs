using System;
using Athi.Whippet.Adobe.Magento.Carts;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Catalog.Products;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides information about a Magento sales order.
    /// </summary>
    public class SalesOrderItemInterface : IExtensionInterface, IExtensionAttributes<SalesOrderItemExtensionInterface>
    {
        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonProperty("additional_data")]
        public string AdditionalData
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded.
        /// </summary>
        [JsonProperty("amount_refunded")]
        public decimal AmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the applied rule IDs.
        /// </summary>
        [JsonProperty("applied_rule_ids")]
        public string AppliedRuleIDs
        { get; set; }

        /// <summary>
        /// Gets or sets the base amount refunded in base currency.
        /// </summary>
        [JsonProperty("base_amount_refunded")]
        public decimal AmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the item cost in base currency.
        /// </summary>
        [JsonProperty("base_cost")]
        public decimal CostBase
        { get; set; }

        /// <summary>
        /// Gets or sets the base discount amount in base currency.
        /// </summary>
        [JsonProperty("base_discount_amount")]
        public decimal DiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount invoiced in base currency.
        /// </summary>
        [JsonProperty("base_discount_invoiced")]
        public decimal DiscountInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount refunded amount in base currency.
        /// </summary>
        [JsonProperty("base_discount_refunded")]
        public decimal DiscountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount in base currency.
        /// </summary>
        [JsonProperty("base_discount_tax_compensation_amount")]
        public decimal DiscountTaxCompensationAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation invoiced in base currency.
        /// </summary>
        [JsonProperty("base_discount_tax_compensation_invoiced")]
        public decimal DiscountTaxCompensationInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation refunded in base currency.
        /// </summary>
        [JsonProperty("base_discount_tax_compensation_refunded")]
        public decimal DiscountTaxCompensationRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the original price in base currency.
        /// </summary>
        [JsonProperty("base_original_price")]
        public decimal OriginalPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the price in base currency.
        /// </summary>
        [JsonProperty("base_price")]
        public decimal PriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the price including tax in base currency.
        /// </summary>
        [JsonProperty("base_price_incl_tax")]
        public decimal PriceWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the row invoiced in base currency.
        /// </summary>
        [JsonProperty("base_row_invoiced")]
        public decimal RowInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the row total in base currency.
        /// </summary>
        [JsonProperty("base_row_total")]
        public decimal RowTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the row total including tax in base currency.
        /// </summary>
        [JsonProperty("base_row_total_incl_tax")]
        public decimal RowTotalWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in base currency.
        /// </summary>
        [JsonProperty("base_tax_amount")]
        public decimal TaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount before discount in base currency.
        /// </summary>
        [JsonProperty("base_tax_before_discount")]
        public decimal TaxBeforeDiscountBase
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
        /// Gets or sets the Waste Electrical and Electronic Equipment Device (WEEE) tax that was applied in base currency. 
        /// </summary>
        [JsonProperty("base_wee_tax_applied_amount")]
        public decimal EcologicalTaxAppliedAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the Waste Electrical and Electronic Equipment Device (WEEE) tax that as applied to the row in base currency.
        /// </summary>
        [JsonProperty("base_wee_tax_applied_row_amnt")]
        public decimal EcologicalTaxAppliedRowAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the Waste Electrical and Electronic Equipment Device (WEEE) tax disposition in base currency.
        /// </summary>
        [JsonProperty("base_weee_tax_disposition")]
        public decimal EcologicalTaxDispositionBase
        { get; set; }

        /// <summary>
        /// Gets or sets the Waste Electrical and Electronic Equipment Device (WEEE) tax disposition applied to the row in base currency.
        /// </summary>
        [JsonProperty("base_weee_tax_row_disposition")]
        public decimal EcologicalTaxRowDispositionBase
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time that the order item entry was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the order item description.
        /// </summary>
        [JsonProperty("description")]
        public string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        [JsonProperty("discount_amount")]
        public decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount that was invoiced.
        /// </summary>
        [JsonProperty("discount_invoiced")]
        public decimal DiscountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount percentage.
        /// </summary>
        [JsonProperty("discount_percent")]
        public decimal DiscountPercent
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount refunded.
        /// </summary>
        [JsonProperty("discount_refunded")]
        public decimal DiscountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the event ID.
        /// </summary>
        [JsonProperty("event_id")]
        public int EventID
        { get; set; }

        /// <summary>
        /// Gets or sets the external order item ID.
        /// </summary>
        [JsonProperty("ext_order_item_id")]
        public string ExternalItemID
        { get; set; }

        /// <summary>
        /// Flag that specifies whether the item has free shipping. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("free_shipping")]
        public int FreeShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price in base currency.
        /// </summary>
        [JsonProperty("gw_base_price")]
        public decimal GiftWrapPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_base_price_invoiced")]
        public decimal GiftWrapPriceInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded in base currency.
        /// </summary>
        [JsonProperty("gw_base_price_refunded")]
        public decimal GiftWrapPriceRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount in base currency.
        /// </summary>
        [JsonProperty("gw_base_tax_amount")]
        public decimal GiftWrapTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_tax_amount_invoiced")]
        public decimal GiftWrapTaxAmountInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded in base currency.
        /// </summary>
        [JsonProperty("gw_tax_amount_refunded")]
        public decimal GiftWrapTaxAmountRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap ID.
        /// </summary>
        [JsonProperty("gw_id")]
        public int GiftWrapID
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price.
        /// </summary>
        [JsonProperty("gw_price")]
        public decimal GiftWrapPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price invoiced.
        /// </summary>
        [JsonProperty("gw_price_invoiced")]
        public decimal GiftWrapPriceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded.
        /// </summary>
        [JsonProperty("gw_price_refunded")]
        public decimal GiftWrapPriceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount.
        /// </summary>
        [JsonProperty("gw_tax_amount")]
        public decimal GiftWrapTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount invoiced.
        /// </summary>
        [JsonProperty("gw_tax_amount_invoiced")]
        public decimal GiftWrapTaxAmountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount refunded.
        /// </summary>
        [JsonProperty("gw_tax_amount_refunded")]
        public decimal GiftWrapTaxAmountRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount.
        /// </summary>
        [JsonProperty("discount_tax_compensation_amount")]
        public decimal DiscountTaxCompensationAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount that was canceled.
        /// </summary>
        [JsonProperty("discount_tax_compensation_canceled")]
        public decimal DiscountTaxCompensationCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount invoiced.
        /// </summary>
        [JsonProperty("discount_tax_compensation_invoiced")]
        public decimal DiscountTaxCompensationInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the discount tax compensation amount refunded.
        /// </summary>
        [JsonProperty("discount_tax_compensation_refunded")]
        public decimal DiscountTaxCompensationRefunded
        { get; set; }

        /// <summary>
        /// Flag that indicates whether quantity is an <see cref="Int32"/> or <see cref="Decimal"/>. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("is_qty_decimal")]
        public int QuantityIsDecimal
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the order item is virtual. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("is_virtual")]
        public int IsVirtual
        { get; set; }

        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemID
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the invoice is locked. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("locked_do_invoice")]
        public int LockedInvoice
        { get; set; }

        /// <summary>
        /// Flag that indicates whether the shipping is locked. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("locked_do_ship")]
        public int LockedShipping
        { get; set; }

        /// <summary>
        /// Gets or sets the item name. 
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Flag that indicates whether there is no discount. A value greater than zero (0) is <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("no_discount")]
        public int NoDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        [JsonProperty("order_id")]
        public int OrderID
        { get; set; }

        /// <summary>
        /// Gets or sets the original price.
        /// </summary>
        [JsonProperty("original_price")]
        public decimal OriginalPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the parent item ID.
        /// </summary>
        [JsonProperty("parent_item_id")]
        public int ParentItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the item price.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the item price including tax.
        /// </summary>
        [JsonProperty("price_incl_tax")]
        public decimal PriceWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        [JsonProperty("product_id")]
        public int ProductID
        { get; set; }

        /// <summary>
        /// Gets or sets the product type.
        /// </summary>
        [JsonProperty("product_type")]
        public string ProductType
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity backordered.
        /// </summary>
        [JsonProperty("qty_backordered")]
        public decimal QuantityBackordered
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity canceled.
        /// </summary>
        [JsonProperty("qty_canceled")]
        public decimal QuantityCanceled
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity invoiced.
        /// </summary>
        [JsonProperty("qty_invoiced")]
        public decimal QuantityInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity ordered.
        /// </summary>
        [JsonProperty("qty_ordered")]
        public decimal QuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity refunded. 
        /// </summary>
        [JsonProperty("qty_refunded")]
        public decimal QuantityRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity returned.
        /// </summary>
        [JsonProperty("qty_returned")]
        public decimal QuantityReturned
        { get; set; }

        /// <summary>
        /// Gets or sets the quantity shipped.
        /// </summary>
        [JsonProperty("qty_shipped")]
        public decimal QuantityShipped
        { get; set; }

        /// <summary>
        /// Gets or sets the quote item ID.
        /// </summary>
        [JsonProperty("quote_item_id")]
        public int QuoteItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the row invoiced.
        /// </summary>
        [JsonProperty("row_invoiced")]
        public decimal RowInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the row total.
        /// </summary>
        [JsonProperty("row_total")]
        public decimal RowTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the row total with tax.
        /// </summary>
        [JsonProperty("row_total_incl_tax")]
        public decimal RowTotalWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the row weight.
        /// </summary>
        [JsonProperty("row_weight")]
        public decimal RowWeight
        { get; set; }

        /// <summary>
        /// Gets or sets the product SKU.
        /// </summary>
        [JsonProperty("sku")]
        public string SKU
        { get; set; }

        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        [JsonProperty("store_id")]
        public int StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        [JsonProperty("tax_amount")]
        public decimal TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount before discount.
        /// </summary>
        [JsonProperty("tax_before_discount")]
        public decimal TaxBeforeDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount canceled.
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
        /// Gets or sets the tax percentage.
        /// </summary>
        [JsonProperty("tax_percent")]
        public decimal TaxPercent
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount refunded.
        /// </summary>
        [JsonProperty("tax_refunded")]
        public decimal TaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the order item was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Waste Electrical and Electronic Equipment Device (WEEE) tax was applied.
        /// </summary>
        [JsonProperty("weee_tax_applied")]
        public string EcologicalTaxApplied
        { get; set; }
        
        /// <summary>
        /// Gets or sets the item's Waste Electrical and Electronic Equipment Device (WEEE) tax.
        /// </summary>
        [JsonProperty("weee_tax_applied_amount")]
        public decimal EcologicalTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the row's Waste Electrical and Electronic Equipment Device (WEEE) tax.
        /// </summary>
        [JsonProperty("weee_tax_applied_row_amount")]
        public decimal EcologicalTaxRowAmount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the item's Waste Electrical and Electronic Equipment Device (WEEE) tax disposition.
        /// </summary>
        [JsonProperty("weee_tax_disposition")]
        public decimal EcologicalTaxDisposition
        { get; set; }
        
        /// <summary>
        /// Gets or sets the row's Waste Electrical and Electronic Equipment Device (WEEE) tax disposition.
        /// </summary>
        [JsonProperty("weee_tax_row_disposition")]
        public decimal EcologicalTaxRowDisposition
        { get; set; }

        /// <summary>
        /// Gets or sets the weight of the item.
        /// </summary>
        [JsonProperty("weight")]
        public decimal Weight
        { get; set; }

        /// <summary>
        /// Gets or sets the parent order item.
        /// </summary>
        /// <remarks>An order is a document that a web store issues to a customer. Magento generates a sales order that lists the product items, billing and shipping addresses, and shipping and payment methods. A corresponding external document, known as a purchase order, is emailed to the customer.</remarks>
        [JsonProperty("parent_item")]
        public SalesOrderItemInterface ParentItem
        { get; set; }

        /// <summary>
        /// Gets or sets the product options for the item.
        /// </summary>
        [JsonProperty("product_option")]
        public ProductOptionInterface ProductOption
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderItemExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItemInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderItemInterface()
        { }
    }
}
