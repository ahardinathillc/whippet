using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that contains information about a negotiable Magento cart (quote). 
    /// </summary>
    public class CartNegotiableCartInterface : IExtensionInterface, IExtensionAttributes<CartNegotiableCartExtensionInterface>
    {   
        /// <summary>
        /// Gets or sets the quote ID.
        /// </summary>
        [JsonProperty("quote_id")]
        public int QuoteID
        { get; set; }

        /// <summary>
        /// Specifies whether the quote is a regular quote.
        /// </summary>
        [JsonProperty("is_regular_quote")]
        public bool IsRegularQuote
        { get; set; }

        /// <summary>
        /// Gets or sets the quote status.
        /// </summary>
        [JsonProperty("status")]
        public string Status
        { get; set; }

        /// <summary>
        /// Gets or sets the negotiated price type.
        /// </summary>
        [JsonProperty("negotiated_price_type")]
        public int NegotiatedPriceType
        { get; set; }

        /// <summary>
        /// Gets or sets the negotiated price.
        /// </summary>
        [JsonProperty("negotiated_price_value")]
        public decimal NegotiatedPriceValue
        { get; set; }

        /// <summary>
        /// Gets or sets the proposed shipping price.
        /// </summary>
        [JsonProperty("shipping_price")]
        public decimal ShippingPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the quote name.
        /// </summary>
        [JsonProperty("quote_name")]
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the expiration period.
        /// </summary>
        [JsonProperty("expiration_period")]
        public string ExpirationPeriod
        { get; set; }

        /// <summary>
        /// Gets or sets the e-mail notification status.
        /// </summary>
        [JsonProperty("email_notification_status")]
        public int EmailNotificationStatus
        { get; set; }

        /// <summary>
        /// Specifies whether the quote has unconfirmed changes.
        /// </summary>
        [JsonProperty("has_unconfirmed_changes")]
        public bool HasUnconfirmedChanges
        { get; set; }

        /// <summary>
        /// Specifies whether the shipping tax has changed.
        /// </summary>
        [JsonProperty("is_shipping_tax_changed")]
        public bool IsShippingTaxChanged
        { get; set; }

        /// <summary>
        /// Specifies whether the customer price has changed.
        /// </summary>
        [JsonProperty("is_customer_price_changed")]
        public bool IsCustomerPriceChanged
        { get; set; }

        /// <summary>
        /// Gets or sets the quote notifications.
        /// </summary>
        [JsonProperty("notifications")]
        public int Notifications
        { get; set; }

        /// <summary>
        /// Gets or sets the quote rules that are applied.
        /// </summary>
        [JsonProperty("applied_rule_ids")]
        public string AppliedRuleIDs
        { get; set; }

        /// <summary>
        /// Specifies whether the address given is a draft address.
        /// </summary>
        [JsonProperty("is_address_draft")]
        public bool IsDraftAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the deleted product SKU.
        /// </summary>
        [JsonProperty("deleted_sku")]
        public string DeletedProductSKU
        { get; set; }

        /// <summary>
        /// Gets or sets the quote creator ID.
        /// </summary>
        [JsonProperty("creator_id")]
        public int CreatorID
        { get; set; }

        /// <summary>
        /// Gets or sets the quote creator type.
        /// </summary>
        [JsonProperty("creator_type")]
        public int CreatorType
        { get; set; }

        /// <summary>
        /// Gets or sets the original total price.
        /// </summary>
        [JsonProperty("original_total_price")]
        public decimal OriginalTotalPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the original total price in base currency.
        /// </summary>
        [JsonProperty("base_original_total_price")]
        public decimal OriginalBaseTotalPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the negotiated total price.
        /// </summary>
        [JsonProperty("negotiated_total_price")]
        public decimal NegotiatedTotalPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the negotiated total price in base currency.
        /// </summary>
        [JsonProperty("base_negotiated_total_price")]
        public decimal NegotiatedBaseTotalPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartNegotiableCartExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartNegotiableCartInterface"/> class with no arguments.
        /// </summary>
        public CartNegotiableCartInterface()
        { }
    }
}
