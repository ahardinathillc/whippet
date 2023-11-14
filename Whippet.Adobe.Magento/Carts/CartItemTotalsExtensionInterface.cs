using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides extra information to Magento cart item totals.
    /// </summary>
    public class CartItemTotalsExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the negotiable cart item totals.
        /// </summary>
        [JsonProperty("negotiable_quote_item_totals")]
        public CartNegotiableItemTotalsInterface[] NegotiableQuoteItemTotals
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartItemTotalsExtensionInterface"/> class with no arguments.
        /// </summary>
        public CartItemTotalsExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartItemTotalsExtensionInterface"/> class with the specified collection of <see cref="CartNegotiableItemTotalsInterface"/>.
        /// </summary>
        /// <param name="totals"></param>
        public CartItemTotalsExtensionInterface(IEnumerable<CartNegotiableItemTotalsInterface> totals)
            : this()
        {
            NegotiableQuoteItemTotals = (totals == null) ? null : totals.ToArray();
        }
    }
}
