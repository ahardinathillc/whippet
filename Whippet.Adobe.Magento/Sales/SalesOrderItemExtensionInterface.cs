using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.GiftMessage;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Provides extra information to a Magento sales order item entry.
    /// </summary>
    public class SalesOrderItemExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the gift message associated with the item.
        /// </summary>
        [JsonProperty("gift_message")]
        public GiftMessageInterface GiftMessage
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap ID.
        /// </summary>
        [JsonProperty("gw_id")]
        public string GiftWrapID
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
        /// Gets or sets the gift wrap price that was invoiced in cart currency.
        /// </summary>
        [JsonProperty("gw_price_invoiced")]
        public string GiftWrapInvoicedPrice
        { get; set; }        

        /// <summary>
        /// Gets or sets the gift wrap price that was invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_base_price_invoiced")]
        public string GiftWrapInvoicedPriceBase
        { get; set; }        

        /// <summary>
        /// Gets or sets the gift wrap tax amount that was invoiced in cart currency.
        /// </summary>
        [JsonProperty("gw_tax_amount_invoiced")]
        public string GiftWrapInvoicedTaxAmount
        { get; set; }        

        /// <summary>
        /// Gets or sets the gift wrap tax amount that was invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_base_tax_amount_invoiced")]
        public string GiftWrapInvoicedTaxAmountBase
        { get; set; }        
        
        /// <summary>
        /// Gets or sets the gift wrap price that was refunded in cart currency.
        /// </summary>
        [JsonProperty("gw_price_refunded")]
        public string GiftWrapRefundedPrice
        { get; set; }        

        /// <summary>
        /// Gets or sets the gift wrap price that was refunded in base currency.
        /// </summary>
        [JsonProperty("gw_base_price_refunded")]
        public string GiftWrapRefundedPriceBase
        { get; set; }        

        /// <summary>
        /// Gets or sets the gift wrap tax amount that was refunded in cart currency.
        /// </summary>
        [JsonProperty("gw_tax_amount_refunded")]
        public string GiftWrapRefundedTaxAmount
        { get; set; }        

        /// <summary>
        /// Gets or sets the gift wrap tax amount that was refunded in base currency.
        /// </summary>
        [JsonProperty("gw_base_tax_amount_refunded")]
        public string GiftWrapRefundedTaxAmountBase
        { get; set; }        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderItemExtensionInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderItemExtensionInterface()
        { }
    }
}
