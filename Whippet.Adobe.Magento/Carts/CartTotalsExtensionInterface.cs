using System;
using Newtonsoft.Json;

namespace Athi.Whippet.Adobe.Magento.Carts
{
    /// <summary>
    /// Interface that provides extra information about a Magento cart's order.
    /// </summary>
    public class CartTotalsExtensionInterface : IExtensionInterface
    {
        /// <summary>
        /// Gets or sets the coupon label.
        /// </summary>
        public string CouponLabel
        { get; set; }
        
    }
}
