using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Payment;
using Athi.Whippet.Adobe.Magento.Company;
using Athi.Whippet.Adobe.Magento.Sales.Taxes;
using Athi.Whippet.Adobe.Magento.GiftCard;
using Athi.Whippet.Adobe.Magento.GiftMessage;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides extra information about a sales order in Magento.
    /// </summary>
    public class SalesOrderExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the shipping assignments for the order.
        /// </summary>
        [JsonProperty("shipping_assignments")]
        public SalesOrderShippingAssignmentInterface[] ShippingAssignments
        { get; set; }

        /// <summary>
        /// Gets or sets the additional information concerning the payment related to the order.
        /// </summary>
        [JsonProperty("payment_additional_info")]
        public PaymentAdditionalInfoInterface[] PaymentAdditionalInformation
        { get; set; }

        /// <summary>
        /// Gets or sets the company order attributes for the order.
        /// </summary>
        [JsonProperty("company_order_attributes")]
        public CompanyOrderInterface CompanyOrderAttributes
        { get; set; }

        /// <summary>
        /// Gets or sets the taxes that were applied to the order on a per item basis.
        /// </summary>
        [JsonProperty("item_applied_taxes")]
        public SalesOrderAppliedTaxInterface[] AppliedTaxes
        { get; set; }

        /// <summary>
        /// Specifies whether the order is being converted from a quote.
        /// </summary>
        [JsonProperty("converting_from_quote")]
        public bool ConvertingFromQuote
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's balance in base currency.
        /// </summary>
        [JsonProperty("base_customer_balance_amount")]
        public decimal CustomerBalanceAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's balance.
        /// </summary>
        [JsonProperty("customer_balance_amount")]
        public decimal CustomerBalanceAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's balance that is invoiced in base currency.
        /// </summary>
        [JsonProperty("base_customer_balance_invoice")]
        public decimal CustomerBalanceInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's balance that is invoiced.
        /// </summary>
        [JsonProperty("customer_balance_invoice")]
        public decimal CustomerBalanceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance refunded in base currency.
        /// </summary>
        [JsonProperty("base_customer_balance_refunded")]
        public decimal CustomerBalanceRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the customer balance refunded.
        /// </summary>
        [JsonProperty("customer_balance_refunded")]
        public decimal CustomerBalanceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded to the customer in base currency.
        /// </summary>
        [JsonProperty("base_customer_balance_total_refunded")]
        public decimal CustomerBalanceRefundTotalBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount refunded to the customer.
        /// </summary>
        [JsonProperty("customer_balance_total_refunded")]
        public decimal CustomerBalanceRefundTotal
        { get; set; }

        /// <summary>
        /// Gets or sets the gift cards purchased on the order.
        /// </summary>
        [JsonProperty("gift_cards")]
        public GiftCardInterface[] GiftCards
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of gift cards purchased in base currency.
        /// </summary>
        [JsonProperty("base_gift_cards_amount")]
        public decimal GiftCardsAmountBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of gift cards purchased.
        /// </summary>
        [JsonProperty("gift_cards_amount")]
        public decimal GiftCardsAmount
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of gift cards invoiced in base currency.
        /// </summary>
        [JsonProperty("base_gift_cards_invoiced")]
        public decimal GiftCardsInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of gift cards invoiced.
        /// </summary>
        [JsonProperty("gift_cards_invoiced")]
        public decimal GiftCardsInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of gift cards refunded in base currency.
        /// </summary>
        [JsonProperty("base_gift_cards_refunded")]
        public decimal GiftCardsRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the total amount of gift cards refunded.
        /// </summary>
        [JsonProperty("gift_cards_refunded")]
        public decimal GiftCardsRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift message associated with the order.
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
        /// Gets or sets the option to allow a gift receipt with the order.
        /// </summary>
        [JsonProperty("gw_allow_gift_receipt")]
        public string AllowGiftReceipt
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
        /// Gets or sets the gift wrapping's price that was invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_base_price_invoiced")]
        public string GiftWrapPriceInvoicedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrapping's price that was invoiced.
        /// </summary>
        [JsonProperty("gw_base_price")]
        public string GiftWrapPriceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrapping's items price that was invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_items_base_price_invoiced")]
        public string GiftWrapItemsPriceInvoicedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrapping's items price that was invoiced.
        /// </summary>
        [JsonProperty("gw_items_base_price")]
        public string GiftWrapItemsPriceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrapping's card price that was invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_card_base_price_invoiced")]
        public string GiftWrapCardPriceInvoicedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrapping's card price that was invoiced.
        /// </summary>
        [JsonProperty("gw_card_base_price")]
        public string GiftWrapCardPriceInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrapping's tax amount that was invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_base_tax_amount_invoiced")]
        public string GiftWrapTaxAmountInvoicedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrapping's tax amount that was invoiced.
        /// </summary>
        [JsonProperty("gw_tax_amount_invoiced")]
        public string GiftWrapTaxAmountInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrapping's items tax amount that was invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_items_base_tax_invoiced")]
        public string GiftWrapItemsTaxInvoicedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrapping's items tax amount that was invoiced.
        /// </summary>
        [JsonProperty("gw_items_tax_invoiced")]
        public string GiftWrapItemsTaxInvoiced
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrapping's card tax invoiced in base currency.
        /// </summary>
        [JsonProperty("gw_card_base_tax_invoiced")]
        public string GiftWrapCardTaxInvoicedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrapping's card tax invoiced.
        /// </summary>
        [JsonProperty("gw_card_tax_invoiced")]
        public string GiftWrapCardTaxInvoiced
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap price refunded in base currency.
        /// </summary>
        [JsonProperty("gw_base_price_refunded")]
        public string GiftWrapPriceRefundedBase
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap price refunded.
        /// </summary>
        [JsonProperty("gw_price_refunded")]
        public string GiftWrapPriceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the amount refunded for the gift wrap items in base currency.
        /// </summary>
        [JsonProperty("gw_items_base_price_refunded")]
        public string GiftWrapItemsPriceRefundedBase        
        { get; set; }
        
        /// <summary>
        /// Gets or sets the amount refunded for the gift wrap items.
        /// </summary>
        [JsonProperty("gw_items_price_refunded")]
        public string GiftWrapItemsPriceRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the gift wrap card price that was refunded in base currency.
        /// </summary>
        [JsonProperty("gw_card_base_price_refunded")]
        public string GiftWrapCardPriceRefundedBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the gift wrap card price that was refunded.
        /// </summary>
        [JsonProperty("gw_card_price_refunded")]
        public string GiftWrapCardPriceRefunded
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
        /// Gets or sets the gift wrap items taxes that was refunded in base currency.
        /// </summary>
        [JsonProperty("gw_items_base_tax_refunded")]
        public string GiftWrapItemsTaxRefundedBase
        { get; set; }        
        
        /// <summary>
        /// Gets or sets the gift wrap items taxes that was refunded.
        /// </summary>
        [JsonProperty("gw_items_base_tax_refunded")]
        public string GiftWrapItemsTaxRefunded
        { get; set; }        

        /// <summary>
        /// Gets or sets the gift wrap card taxes that was refunded in base currency.
        /// </summary>
        [JsonProperty("gw_card_base_tax_refunded")]
        public string GiftWrapCardTaxRefundedBase
        { get; set; }        

        /// <summary>
        /// Gets or sets the gift wrap card taxes that was refunded.
        /// </summary>
        [JsonProperty("gw_card_tax_refunded")]
        public string GiftWrapCardTaxRefunded
        { get; set; }        

        /// <summary>
        /// Gets or sets the pickup location code.
        /// </summary>
        [JsonProperty("pickup_location_code")]
        public string PickupLocationCode
        { get; set; }        

        /// <summary>
        /// Flag that indicates whether a notification should be sent to the customer. Values greater than zero (0) are <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </summary>
        [JsonProperty("send_notification")]
        public int SendNotification
        { get; set; }        

        /// <summary>
        /// Gets or sets the rewards points balance.
        /// </summary>
        [JsonProperty("reward_points_balance")]
        public int RewardPointsBalance
        { get; set; }        

        /// <summary>
        /// Gets or sets the reward currency amount.
        /// </summary>
        [JsonProperty("reward_currency_amount")]
        public decimal RewardCurrencyAmount
        { get; set; }        

        /// <summary>
        /// Gets or sets the reward currency amount in base currency.
        /// </summary>
        [JsonProperty("base_reward_currency_amount")]
        public decimal RewardCurrencyAmountBase
        { get; set; }        

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderExtensionInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderExtensionInterface()
        { }
    }
}
