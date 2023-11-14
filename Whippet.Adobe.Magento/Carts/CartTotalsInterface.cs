using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a cart's line item totals in Magento.
    /// </summary>
    public class CartTotalsInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the grand total in cart currency.
        /// </summary>
        [JsonProperty("grand_total")]
        public decimal GrandTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the grand total in base currency.
        /// </summary>
        [JsonProperty("base_grand_total")]
        public decimal GrandTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal in cart currency.
        /// </summary>
        [JsonProperty("subtotal")]
        public decimal Subtotal
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal in base currency.
        /// </summary>
        [JsonProperty("base_subtotal")]
        public decimal SubtotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount in cart currency.
        /// </summary>
        [JsonProperty("discount_amount")]
        public decimal DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount in base currency.
        /// </summary>
        [JsonProperty("base_discount_amount")]
        public decimal DiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal in cart currency with applied discount.
        /// </summary>
        [JsonProperty("subtotal_with_discount")]
        public decimal SubtotalWithDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal in base currency with applied discount.
        /// </summary>
        [JsonProperty("base_subtotal_with_discount")]
        public decimal SubtotalWithDiscountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in cart currency.
        /// </summary>
        [JsonProperty("shipping_amount")]
        public decimal ShippingAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping amount in base currency.
        /// </summary>
        [JsonProperty("base_shipping_amount")]
        public decimal ShippingAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount in cart currency.
        /// </summary>
        [JsonProperty("shipping_discount_amount")]
        public decimal ShippingDiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping discount amount in base currency.
        /// </summary>
        [JsonProperty("base_shipping_discount_amount")]
        public decimal ShippingDiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in cart currency.
        /// </summary>
        [JsonProperty("tax_amount")]
        public decimal TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in base currency.
        /// </summary>
        [JsonProperty("base_tax_amount")]
        public decimal TaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the item's Waste Electrical and Electronic Equipment Device (WEEE) tax.
        /// </summary>
        [JsonProperty("weee_tax_applied_amount")]
        public decimal EcologicalTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the item's shipping tax amount in cart currency.
        /// </summary>
        [JsonProperty("shipping_tax_amount")]
        public decimal ShippingTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the item's shipping tax amount in base currency.
        /// </summary>
        [JsonProperty("base_shipping_tax_amount")]
        public decimal ShippingTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including tax in cart currency.
        /// </summary>
        [JsonProperty("subtotal_incl_tax")]
        public decimal SubtotalTaxSumAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the subtotal including tax in base currency.
        /// </summary>
        [JsonProperty("base_subtotal_incl_tax")]
        public decimal SubtotalTaxSumAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping including tax in cart currency.
        /// </summary>
        [JsonProperty("shipping_incl_tax")]
        public decimal ShippingTaxSumAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the shipping including tax in base currency.
        /// </summary>
        [JsonProperty("base_shipping_incl_tax")]
        public decimal ShippingTaxSumAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code.
        /// </summary>
        [JsonProperty("base_currency_code")]
        public string CurrencyCodeBase
        { get; set; }

        /// <summary>
        /// Gets or sets the cart currency code.
        /// </summary>
        [JsonProperty("quote_currency_code")]
        public string CurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the applied coupon code.
        /// </summary>
        [JsonProperty("coupon_code")]
        public string CouponCode
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of items in the cart.
        /// </summary>
        [JsonProperty("items_qty")]
        public int QuantitySold
        { get; set; }

        
    }
}
