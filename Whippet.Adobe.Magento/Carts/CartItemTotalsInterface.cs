using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides totals for individual items in a Magento cart.
    /// </summary>
    public class CartItemTotalsInterface : IExtensionInterface, IExtensionAttributes<CartItemTotalsExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemID
        { get; set; }

        /// <summary>
        /// Gets or sets the item price in cart currency.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price
        { get; set; }

        /// <summary>
        /// Gets or sets the item price in base currency.
        /// </summary>
        [JsonProperty("base_price")]
        public decimal PriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the item quantity.
        /// </summary>
        [JsonProperty("qty")]
        public decimal Quantity
        { get; set; }

        /// <summary>
        /// Gets or sets the row total in cart currency.
        /// </summary>
        [JsonProperty("row_total")]
        public decimal RowTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the row total in base currency.
        /// </summary>
        [JsonProperty("base_row_total")]
        public decimal RowTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the row total with discount in cart currency.
        /// </summary>
        [JsonProperty("row_total_with_discount")]
        public decimal? RowTotalWithDiscount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in cart currency.
        /// </summary>
        [JsonProperty("tax_amount")]
        public decimal? TaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the tax amount in base currency.
        /// </summary>
        [JsonProperty("base_tax_amount")]
        public decimal? TaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax percentage.
        /// </summary>
        [JsonProperty("tax_percent")]
        public decimal? TaxPercent
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount in cart currency.
        /// </summary>
        [JsonProperty("discount_amount")]
        public decimal? DiscountAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the discount amount in base currency.
        /// </summary>
        [JsonProperty("base_discount_amount")]
        public decimal? DiscountAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the discount percent in cart currency.
        /// </summary>
        [JsonProperty("discount_percent")]
        public decimal? DiscountPercent
        { get; set; }

        /// <summary>
        /// Gets or sets the price including tax in cart currency.
        /// </summary>
        [JsonProperty("price_incl_tax")]
        public decimal? PriceWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the price including tax in base currency.
        /// </summary>
        [JsonProperty("base_price_incl_tax")]
        public decimal? PriceWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the row total including tax in cart currency.
        /// </summary>
        [JsonProperty("row_total_incl_tax")]
        public decimal? RowTotalWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the row total including tax in base currency.
        /// </summary>
        [JsonProperty("base_row_total_incl_tax")]
        public decimal? RowTotalWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets options applied to the item.
        /// </summary>
        [JsonProperty("options")]
        public string Options
        { get; set; }

        /// <summary>
        /// Gets or sets the item's Waste Electrical and Electronic Equipment Device (WEEE) tax in cart currency.
        /// </summary>
        [JsonProperty("weee_tax_applied_amount")]
        public decimal EcologicalTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets whether the <see cref="EcologicalTaxAmount"/> was applied.
        /// </summary>
        [JsonProperty("wee_tax_applied")]
        public string EcologicalTaxApplied
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension interface for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartItemTotalsExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartItemTotalsInterface"/> class with no arguments.
        /// </summary>
        public CartItemTotalsInterface()
        { }
    }
}
