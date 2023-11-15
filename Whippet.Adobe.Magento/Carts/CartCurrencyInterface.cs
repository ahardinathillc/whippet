using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about currencies that can be used in a Magento cart.
    /// </summary>
    public class CartCurrencyInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the global currency code.
        /// </summary>
        [JsonProperty("global_currency_code")]
        public string GlobalCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency code.
        /// </summary>
        [JsonProperty("base_currency_code")]
        public string BaseCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the store currency code.
        /// </summary>
        [JsonProperty("store_currency_code")]
        public string StoreCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the cart currency code.
        /// </summary>
        [JsonProperty("quote_currency_code")]
        public string CartCurrencyCode
        { get; set; }

        /// <summary>
        /// Gets or sets the store currency to base currency rate.
        /// </summary>
        [JsonProperty("store_to_base_rate")]
        public decimal StoreToBaseRate
        { get; set; }

        /// <summary>
        /// Gets or sets the store currency to cart current rate.
        /// </summary>
        [JsonProperty("store_to_quote_rate")]
        public decimal StoreToCartRate
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency to global currency rate.
        /// </summary>
        [JsonProperty("base_to_global_rate")]
        public decimal BaseToGlobalRate
        { get; set; }

        /// <summary>
        /// Gets or sets the base currency to cart currency rate.
        /// </summary>
        [JsonProperty("base_to_quote_rate")]
        public decimal BaseToCartRate
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes of the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartCurrencyExtensionInterface ExtensionAttributes
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartCurrencyInterface"/> class with no arguments.
        /// </summary>
        public CartCurrencyInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartCurrencyInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="globalCurrencyCode">Global currency code.</param>
        /// <param name="baseCurrencyCode">Base currency code.</param>
        /// <param name="storeCurrencyCode">Store currency code.</param>
        /// <param name="cartCurrencyCode">Cart currency code.</param>
        /// <param name="storeToBaseRate">Store to base rate.</param>
        /// <param name="storeToCartRate">Store to cart rate.</param>
        /// <param name="baseToGlobalRate">Base to global rate.</param>
        /// <param name="baseToCartRate">Base to cart rate.</param>
        /// <param name="extensionAttributes">Extension attributes.</param>
        public CartCurrencyInterface(string globalCurrencyCode, string baseCurrencyCode, string storeCurrencyCode, string cartCurrencyCode, decimal storeToBaseRate, decimal storeToCartRate, decimal baseToGlobalRate, decimal baseToCartRate, CartCurrencyExtensionInterface extensionAttributes)
            : this()
        {
            GlobalCurrencyCode = globalCurrencyCode;
            BaseCurrencyCode = baseCurrencyCode;
            StoreCurrencyCode = storeCurrencyCode;
            CartCurrencyCode = cartCurrencyCode;
            StoreToBaseRate = storeToBaseRate;
            StoreToCartRate = storeToCartRate;
            BaseToGlobalRate = baseToGlobalRate;
            BaseToCartRate = baseToCartRate;
            ExtensionAttributes = extensionAttributes;
        }
    }
}
