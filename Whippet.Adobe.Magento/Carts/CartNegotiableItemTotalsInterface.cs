using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information on negotiable Magento cart item totals.
    /// </summary>
    public class CartNegotiableItemTotalsInterface : IExtensionInterface, IExtensionAttributes<CartNegotiableItemTotalsExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the cost for the item.
        /// </summary>
        [JsonProperty("cost")]
        public decimal Cost
        { get; set; }

        /// <summary>
        /// Gets or sets the catalog price for the item.
        /// </summary>
        [JsonProperty("catalog_price")]
        public decimal CatalogPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the catalog price for the item in base currency.
        /// </summary>
        [JsonProperty("base_catalog_price")]
        public decimal CatalogPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the catalog price for the item with included tax.
        /// </summary>
        [JsonProperty("catalog_price_incl_tax")]
        public decimal CatalogPriceWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the catalog price for the item with included tax in base currency.
        /// </summary>
        [JsonProperty("base_catalog_price_incl_tax")]
        public decimal CatalogPriceWithTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the cart price for the item.
        /// </summary>
        [JsonProperty("cart_price")]
        public decimal CartPrice
        { get; set; }

        /// <summary>
        /// Gets or sets the cart price for the item in base currency.
        /// </summary>
        [JsonProperty("base_cart_price")]
        public decimal CartPriceBase
        { get; set; }

        /// <summary>
        /// Gets or sets the tax from the catalog item for the cart item.
        /// </summary>
        [JsonProperty("cart_tax")]
        public decimal CartTax
        { get; set; }

        /// <summary>
        /// Gets or sets the tax from the catalog item for the cart item in base currency.
        /// </summary>
        [JsonProperty("base_cart_tax")]
        public decimal CartTaxBase
        { get; set; }

        /// <summary>
        /// Gets or sets the cart price for the item with included tax.
        /// </summary>
        [JsonProperty("cart_price_incl_tax")]
        public decimal CartPriceWithTax
        { get; set; }

        /// <summary>
        /// Gets or sets the cart price for the item with included tax in base currency.
        /// </summary>
        [JsonProperty("base_cart_price_incl_tax")]
        public decimal CartPriceWithTaxBase
        { get; set; }
        
        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartNegotiableItemTotalsExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartNegotiableItemTotalsInterface"/> class with no arguments.
        /// </summary>
        public CartNegotiableItemTotalsInterface()
        { }
    }
}
