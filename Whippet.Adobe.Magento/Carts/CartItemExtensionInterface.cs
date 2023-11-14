using System;
using Newtonsoft.Json;
using Athi.Whippet.Adobe.Magento.SalesRule;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides extra information about Magento cart items.
    /// </summary>
    public class CartItemExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the discounts to apply to the cart item.
        /// </summary>
        [JsonProperty("discounts")]
        public SalesRuleDiscountInterface[] Discounts
        { get; set; }
        
        /// <summary>
        /// Gets or sets the negotiable item information of the cart item.
        /// </summary>
        [JsonProperty("negotiable_quote_item")]
        public CartNegotiableItemInterface NegotiableItem
        { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CartItemExtensionInterface"/> class with no arguments.
        /// </summary>
        public CartItemExtensionInterface()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartItemExtensionInterface"/> class with the specified parameters.
        /// </summary>
        /// <param name="discounts"><see cref="IEnumerable{T}"/> collection of <see cref="SalesRuleDiscountInterface"/> objects.</param>
        /// <param name="negotiableItem"><see cref="CartNegotiableItemInterface"/> object.</param>
        public CartItemExtensionInterface(IEnumerable<SalesRuleDiscountInterface> discounts, CartNegotiableItemInterface negotiableItem)
            : this()
        {
            Discounts = (discounts == null) ? null : discounts.ToArray();
            NegotiableItem = negotiableItem;
        }
    }
}
