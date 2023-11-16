using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Sales
{
    /// <summary>
    /// Interface that provides information about a sales order's totals in Magento.
    /// </summary>
    public class SalesOrderTotalInterface : IExtensionInterface, IExtensionAttributes<SalesOrderTotalExtensionInterface>
    {
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
        /// Gets or sets the total shipping amount that was invoiced.
        /// </summary>
        [JsonProperty("shipping_invoiced")]
        public decimal ShippingInvoiced
        { get; set; }
        
        /// <summary>
        /// Gets or sets the shipping including tax refund amount.
        /// </summary>
        [JsonProperty("shipping_tax_refunded")]
        public decimal ShippingTaxRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the item's shipping tax amount.
        /// </summary>
        [JsonProperty("shipping_tax_amount")]
        public decimal ShippingTaxAmount
        { get; set; }
        
        /// <summary>
        /// Gets or sets the total shipping refund amount.
        /// </summary>
        [JsonProperty("shipping_refunded")]
        public decimal ShippingRefunded
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public SalesOrderTotalExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderTotalInterface"/> class with no arguments.
        /// </summary>
        public SalesOrderTotalInterface()
        { }
    }
}
