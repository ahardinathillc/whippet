using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.Customer;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information about a cart in Magento.
    /// </summary>
    public class CartInterface : IExtensionInterface, IExtensionAttributes<CartExtensionInterface>
    {
        /// <summary>
        /// Gets or sets the cart ID.
        /// </summary>
        [JsonProperty("id")]
        public int ID
        { get; set; }

        /// <summary>
        /// Gets or sets the cart creation date and time.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the last time the cart was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the cart was converted.
        /// </summary>
        [JsonProperty("converted_at")]
        public string ConvertedAt
        { get; set; }

        /// <summary>
        /// Specifies whether the cart is active.
        /// </summary>
        [JsonProperty("is_active")]
        public bool? Active
        { get; set; }

        /// <summary>
        /// Specifies whether the cart is virtual.
        /// </summary>
        [JsonProperty("is_virtual")]
        public bool? IsVirtual
        { get; set; }

        /// <summary>
        /// Gets or sets the items in the cart.
        /// </summary>
        [JsonProperty("items")]
        public CartItemInterface[] Items
        { get; set; }

        /// <summary>
        /// Gets or sets the number of different items in the cart.
        /// </summary>
        [JsonProperty("items_count")]
        public int? ItemsCount
        { get; set; }

        /// <summary>
        /// Gets or sets the total quantity of all cart items.
        /// </summary>
        [JsonProperty("items_qty")]
        public decimal? ItemsQuantity
        { get; set; }

        /// <summary>
        /// Gets or sets the customer entity associated with the current cart. 
        /// </summary>
        [JsonProperty("customer")]
        public CustomerInterface Customer
        { get; set; }

        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        [JsonProperty("billing_address")]
        public CartAddressInterface BillingAddress
        { get; set; }

        /// <summary>
        /// Gets or sets the reserved order ID.
        /// </summary>
        [JsonProperty("reserved_order_id")]
        public string ReservedOrderID
        { get; set; }

        /// <summary>
        /// Gets or sets the original order ID.
        /// </summary>
        [JsonProperty("orig_order_id")]
        public int? OriginalOrderID
        { get; set; }
        
        /// <summary>
        /// Gets or sets the currency information for the cart.
        /// </summary>
        [JsonProperty("currency")]
        public CartCurrencyInterface Currency
        { get; set; }

        /// <summary>
        /// Specifies whether the customer is a guest customer.
        /// </summary>
        [JsonProperty("customer_is_guest")]
        public bool CustomerIsGuest
        { get; set; }

        /// <summary>
        /// Gets or sets the notice text.
        /// </summary>
        [JsonProperty("customer_note")]
        public string Notice
        { get; set; }

        /// <summary>
        /// Gets or sets the customer notification flag.
        /// </summary>
        [JsonProperty("customer_note_notify")]
        public bool NotifyNotice
        { get; set; }

        /// <summary>
        /// Gets or sets the customer's tax class ID.
        /// </summary>
        [JsonProperty("customer_tax_class_id")]
        public int CustomerTaxClassID
        { get; set; }

        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        [JsonProperty("store_id")]
        public int StoreID
        { get; set; }

        /// <summary>
        /// Gets or sets the extension attributes for the current instance.
        /// </summary>
        [JsonProperty("extension_attributes")]
        public CartExtensionInterface ExtensionAttributes
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartInterface"/> class with no arguments.
        /// </summary>
        public CartInterface()
        { }
    }
}
