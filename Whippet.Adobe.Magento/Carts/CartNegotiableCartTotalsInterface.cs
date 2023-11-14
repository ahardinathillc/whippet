using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides extra information to cart totals in Magento.
    /// </summary>
    public class CartNegotiableCartTotalsInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the number of different items or products in the cart.
        /// </summary>
        [JsonProperty("items_count")]
        public int ItemsCount
        { get; set; }
        
        public string Status
        { get; set; }

    }
}
