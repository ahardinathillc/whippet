using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Orders.Taxes;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides extra information about a dynamically calculated total in Magento.
    /// </summary>
    public class CartTotalSegmentExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the tax details for the current total.
        /// </summary>
        [JsonProperty("tax_grandtotal_details")]
        public SalesOrderTaxGrandTotalDetailsInterface[] TaxDetails
        { get; set; }
        
        /// <summary>
        /// Gets or sets any gift card codes applied to the total.
        /// </summary>
        [JsonProperty("gift_cards")]
        public string GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap order ID.
        /// </summary>
        [JsonProperty("gw_order_id")]
        public string GiftWrapOrderID
        { get; set; }

        /// <summary>
        /// Gets or sets the item IDs of the gift wrapped items.
        /// </summary>
        [JsonProperty("gw_item_ids")]
        public string[] GiftWrapItems
        { get; set; }

        /// <summary>
        /// Gets or sets whether the order allows a gift receipt.
        /// </summary>
        [JsonProperty("gw_allow_gift_receipt")]
        public string GiftWrapAllowGiftReceipt
        { get; set; }

        /// <summary>
        /// Gets or sets whether a printed card should be included with the gift receipt.
        /// </summary>
        [JsonProperty("gw_add_card")]
        public string GiftWrapAddCard
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price in cart currency.
        /// </summary>
        [JsonProperty("gw_price")]
        public string GiftWrapPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price in base currency.
        /// </summary>
        [JsonProperty("gw_base_price")]
        public string GiftWrapPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap items price in cart currency.
        /// </summary>
        [JsonProperty("gw_items_price")]
        public string GiftWrapItemsPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap items price in base currency.
        /// </summary>
        [JsonProperty("gw_items_base_price")]
        public string GiftWrapItemsPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap card price in cart currency.
        /// </summary>
        [JsonProperty("gw_card_price")]
        public string GiftWrapCardPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap card price in base currency.
        /// </summary>
        [JsonProperty("gw_card_base_price")]
        public string GiftWrapCardPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount in base currency.
        /// </summary>
        [JsonProperty("gw_base_tax_amount")]
        public string GiftWrapTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap tax amount in cart currency.
        /// </summary>
        [JsonProperty("gw_tax_amount")]
        public string GiftWrapTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap items tax amount in base currency.
        /// </summary>
        [JsonProperty("gw_items_base_tax_amount")]
        public string GiftWrapItemsTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap items tax amount in cart currency.
        /// </summary>
        [JsonProperty("gw_items_tax_amount")]
        public string GiftWrapItemsTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap card tax amount in base currency.
        /// </summary>
        [JsonProperty("gw_card_base_tax_amount")]
        public string GiftWrapCardTaxAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap card tax amount in cart currency.
        /// </summary>
        [JsonProperty("gw_card_tax_amount")]
        public string GiftWrapCardTaxAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price including tax in cart currency.
        /// </summary>
        [JsonProperty("gw_price_incl_tax")]
        public string GiftWrapPriceIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price including tax in base currency.
        /// </summary>
        [JsonProperty("gw_base_price_incl_tax")]
        public string GiftWrapPriceIncludingTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap card price including tax in cart currency.
        /// </summary>
        [JsonProperty("gw_card_price_incl_tax")]
        public string GiftWrapCardPriceIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap card price including tax in base currency.
        /// </summary>
        [JsonProperty("gw_card_base_price_incl_tax")]
        public string GiftWrapCardPriceIncludingTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap items' price including tax in cart currency.
        /// </summary>
        [JsonProperty("gw_items_price_incl_tax")]
        public string GiftWrapItemsPriceIncludingTax
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap items' price including tax in base currency.
        /// </summary>
        [JsonProperty("gw_items_base_price_incl_tax")]
        public string GiftWrapItemsPriceIncludingTaxBase
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartTotalSegmentExtensionInterface"/> class with no arguments.
        /// </summary>
        public CartTotalSegmentExtensionInterface()
        { }
    }
}
