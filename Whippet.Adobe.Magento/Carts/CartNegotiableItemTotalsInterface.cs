using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides information on negotiable Magento cart item totals.
    /// </summary>
    public class CartNegotiableItemTotalsInterface : IExtensionInterface
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
        
        //TODO - pick up here
        public decimal 

    }
}
